#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections.Generic;
using System.Web;
using System.Threading;

#endregion

namespace RegisterModule
{
    public static class ZipUtil
    {
        public static void ZipFiles(string inputFolderPath, string outputPathAndFile, string password)
        {
            ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
            int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove 	// from orginal file path
            TrimLength += 1; //remove '\'
            FileStream ostream;
            byte[] obuffer;
            string outPath = outputPathAndFile;
            ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            if (password != null && password != String.Empty)
                oZipStream.Password = password;
            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string Fil in ar) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                oZipStream.PutNextEntry(oZipEntry);

                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = File.OpenRead(Fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
            }
            oZipStream.Finish();
            oZipStream.Close();
            oZipStream.Dispose();
        }




        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }

            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }

        public static void UnZipFiles(string zipPathAndFile, string outputFolder, ref string ExtractedPath, string password, bool deleteZipFile)
        {
            if (File.Exists(zipPathAndFile))
            {
                ZipInputStream s = new ZipInputStream(File.OpenRead(zipPathAndFile));
                if (password != null && password != String.Empty)
                    s.Password = password;
                ZipEntry theEntry;
                string tmpEntry = String.Empty;
                theEntry = s.GetNextEntry();
                ExtractedPath = Path.GetDirectoryName(outputFolder + "\\" + theEntry.Name);
                while (theEntry != null)
                {
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }
                    if (fileName != String.Empty)
                    {
                        if (theEntry.Name.IndexOf(".ini") < 0)
                        {
                            string fullPath = outputFolder + "\\" + theEntry.Name;
                            fullPath = fullPath.Replace("\\ ", "\\");
                            string fullDirPath = Path.GetDirectoryName(fullPath);
                            if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
                            FileStream streamWriter = File.Create(fullPath);
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                    }
                    theEntry = s.GetNextEntry();
                }
                s.Close();
                if (deleteZipFile)
                {
                    File.Delete(zipPathAndFile);
                }
            }
        }


        public static void CreateZipResponse(List<string> ZipFileList, HttpResponse Response, string ZipFileName, string TempFolder)
        {
            Response.Clear();

            Response.ContentType = "application/octet-stream"; // "application/zip";

            Response.AddHeader("content-disposition", "filename=\"" + ZipFileName + ".zip\"");
            try
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    foreach (string fileName in ZipFileList)
                    {
                        string path = fileName.Contains("Modules\\" + ZipFileName + "\\")
                                          ? fileName.Substring(fileName.LastIndexOf(ZipFileName + "\\"),
                                                               fileName.Substring(
                                                                   fileName.LastIndexOf(ZipFileName + "\\")).LastIndexOf
                                                                   ("\\"))
                                          : ZipFileName;

                        zip.AddFile(fileName, path);
                    }

                    zip.Save(Response.OutputStream);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.End();
            }
        }


        public static void CreateZipResponseOld(List<string> ZipFileList ,HttpResponse Response,string ZipFileName,string TempFolder)
        {

            Response.Clear();
            Response.ContentType = "application/x-zip-compressed";
            Response.AppendHeader("content-disposition", "attachment; filename=\"" + ZipFileName + ".zip\"");



            ZipEntry entry = default(ZipEntry);
            const int size = 409600;
            byte[] bytes = new byte[size + 1];
            int numBytes = 0;

            FileStream fs = null;
            ZipOutputStream zipStream = new ZipOutputStream(Response.OutputStream);
            try
            {
                try
                {
                    zipStream.IsStreamOwner = false;
                    zipStream.SetLevel(0);
                    foreach (string file in ZipFileList)
                    {
                        string folderName = ZipFileName + @"\";
                        entry =
                            new ZipEntry(folderName +
                                         ZipEntry.CleanName(file.Contains(ZipFileName + "\\")
                                                                ? file.Substring(file.LastIndexOf(ZipFileName + "\\") +
                                                                                 ZipFileName.Length + 1)
                                                                : file.Substring(file.LastIndexOf("\\") + 1)));
                        zipStream.PutNextEntry(entry);

                        fs = System.IO.File.OpenRead(file);
                        numBytes = fs.Read(bytes, 0, size);
                        while (numBytes > 0)
                        {
                            zipStream.Write(bytes, 0, numBytes);
                            numBytes = fs.Read(bytes, 0, size);
                            if (Response.IsClientConnected == false)
                            {
                                break;
                            }
                            Response.Flush();
                        }
                        fs.Close();
                    }

                    foreach (string fileName in Directory.GetFiles(TempFolder))
                    {
                        File.Delete(fileName);
                    }
                    Directory.Delete(TempFolder);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    zipStream.Finish();
                    zipStream.Close();
                    zipStream.Dispose();
                    Response.End();
                }
            }
            catch (ThreadAbortException err)
            {
                throw err;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static bool UnZipConfigFile(string zipPathAndFile, string outputFolder, ref string ExtractedPath, string password, bool deleteZipFile, string configFileName)
        {
            bool IsConfigFileFound = false;
            if (File.Exists(zipPathAndFile))
            {
                ZipInputStream s = new ZipInputStream(File.OpenRead(zipPathAndFile));
                if (password != null && password != String.Empty)
                    s.Password = password;
                ZipEntry theEntry;
                string tmpEntry = String.Empty;
                theEntry = s.GetNextEntry();
                ExtractedPath = Path.GetDirectoryName(outputFolder + "\\" + theEntry.Name);
                while (theEntry != null && !IsConfigFileFound)
                {
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }
                    if (fileName != String.Empty)
                    {
                        if (theEntry.Name.IndexOf(configFileName) > -1)
                        {
                            string fullPath = outputFolder + "\\" + theEntry.Name;
                            fullPath = fullPath.Replace("\\ ", "\\");
                            string fullDirPath = Path.GetDirectoryName(fullPath);
                            if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
                            FileStream streamWriter = File.Create(fullPath);
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            streamWriter.Close();
                            streamWriter.Dispose();
                            IsConfigFileFound = true;

                        }
                    }
                    theEntry = s.GetNextEntry();
                }
                s.Close();
            }

            return IsConfigFileFound;
        }

    }
    
}