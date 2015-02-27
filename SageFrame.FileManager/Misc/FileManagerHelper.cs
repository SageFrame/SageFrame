using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using SageFrame.Web;

namespace SageFrame.FileManager
{
    public enum StorageLocation
    {
        STANDARD = 0,
        SECURED_FILE_SYSTEM = 1,
        SECURED_DATABASE_SYSTEM = 2
    }
    public class FileManagerHelper
    {

        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".docx":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                //case ".zip":
                //    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".png":
                    return "image/png";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        public static bool CheckForValidExtensions(int UserModuleID, string ext, int PortalID)
        {
            string extension = "";
            SageFrameConfig config = new SageFrameConfig();
            extension = config.GetSettingsByKey(SageFrameSettingKeys.FileExtensions);
            string[] arrExt = extension.Split('#');
            if (arrExt.Contains(ext))
                return true;
            else return false;


        }
        public static void UnZipFiles(string zipPathAndFile, string outputFolder, ref string ExtractedPath, string password, bool deleteZipFile, int UserModuleID, int PortalID)
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
        public static string RemoveResourceExtension(string fileName)
        {
            return (fileName.Substring(0, fileName.LastIndexOf('.')));

        }

        /// <summary>
        /// Function to get byte array from a file
        /// </summary>
        /// <param name="_FileName">File name to get byte array</param>
        /// <returns>Byte Array</returns>
        public static byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception)
            {
                // Error

            }

            return _Buffer;
        }
        /// <summary>
        /// Set the file attributes
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="settingString"></param>
        public static void SetFileAttributes(string filePath, string settingString)
        {
            if (settingString != "")
            {
                string[] attributes = settingString.Split('-');
                int count = 0;
                foreach (string attr in attributes)
                {
                    count++;
                }

                switch (count)
                {
                    case 0:
                        File.SetAttributes(filePath, FileAttributes.Normal);
                        break;
                    case 1:
                        File.SetAttributes(filePath, GetAttributeKey(attributes[0]));
                        break;
                    case 2:
                        File.SetAttributes(filePath, GetAttributeKey(attributes[0]) | GetAttributeKey(attributes[1]));
                        break;
                    case 3:
                        File.SetAttributes(filePath, GetAttributeKey(attributes[0]) | GetAttributeKey(attributes[1]) | GetAttributeKey(attributes[2]));
                        break;
                    case 4:
                        File.SetAttributes(filePath, GetAttributeKey(attributes[0]) | GetAttributeKey(attributes[1]) | GetAttributeKey(attributes[2]) | GetAttributeKey(attributes[3]));
                        break;

                }
                foreach (string att in attributes)
                {
                    FileAttributes fa = GetAttributeKey(att);

                }
            }
            else
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
            }

        }
        /// <summary>
        /// Get the file attributes
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetAttributeString(string filePath)
        {

            string strResult = "";
            try
            {
                // check whether a file is read only
                bool isReadOnly = ((File.GetAttributes(filePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
                if (isReadOnly) strResult += "R-";
                // check whether a file is hidden
                bool isHidden = ((File.GetAttributes(filePath) & FileAttributes.Hidden) == FileAttributes.Hidden);
                if (isHidden) strResult += "H-";
                // check whether a file has archive attribute
                bool isArchive = ((File.GetAttributes(filePath) & FileAttributes.Archive) == FileAttributes.Archive);
                if (isArchive) strResult += "A-";
                // check whether a file is system file
                bool isSystem = ((File.GetAttributes(filePath) & FileAttributes.System) == FileAttributes.System);
                if (isSystem) strResult += "S-";
                if (strResult != "")
                {
                    strResult = strResult.Substring(0, strResult.LastIndexOf('-'));
                }
            }
            catch (Exception)
            {

                throw;
            }

            return strResult;
        }
        public static string GetValidExtensions(int UserModuleID, int PortalID)
        {
            string extension = "";
            List<FileManagerSettingInfo> lstSettings = FileManagerController.GetFileManagerSettings(UserModuleID, PortalID);
            foreach (FileManagerSettingInfo obj in lstSettings)
            {
                switch (obj.SettingKey)
                {
                    case "FileManagerExtensions":
                        extension = obj.SettingValue;
                        break;
                }
            }
            return extension;
        }
        public static System.IO.FileAttributes GetAttributeKey(string key)
        {
            FileAttributes fa = new FileAttributes();
            switch (key)
            {
                case "A":
                    fa = FileAttributes.Archive;
                    break;
                case "R":
                    fa = FileAttributes.ReadOnly;
                    break;
                case "H":
                    fa = FileAttributes.Hidden;
                    break;
                case "S":
                    fa = FileAttributes.System;
                    break;

            }
            return fa;
        }

        public static string GetFilePathWithoutExtension(string filepath)
        {
            return (filepath.Substring(0, filepath.LastIndexOf(".")));
        }

        /// <summary>
        /// Replace the backslash
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReplaceBackSlash(string filepath)
        {
            if (filepath != null)
            {
                filepath = filepath.Replace("\\", "/");
            }
            return filepath;
        }

        /// <summary>
        /// Write the byte content to the file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FileContent"></param>
        public static void WriteBinaryFile(string FilePath, byte[] FileContent)
        {
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(FileContent);
                    }
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Copy or Move the file to the fullToPath location
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileId"></param>
        /// <param name="toFolderId"></param>
        /// <param name="toPath"></param>
        /// <param name="action"></param>
        /// <param name="mode"></param>
        /// <param name="fullFilePath"></param>
        /// <param name="fullFromPath"></param>
        /// <param name="fullToPath"></param>
        public static void TransferFile(string filePath, int fileId, int toFolderId, string toPath, int action, int mode, string fullFilePath, string fullFromPath, string fullToPath)
        {
            switch (mode)
            {
                case 1:
                    switch (action)
                    {
                        case 1:
                            FileInfo fileCopy = new FileInfo(fullFilePath);
                            string fileNameCopy = fileCopy.Name;
                            if (!File.Exists(Path.Combine(fullToPath, fileNameCopy)))
                            {
                                try
                                {
                                    fileCopy.CopyTo(Path.Combine(fullToPath, fileNameCopy));
                                    FileManagerController.CopyFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath);
                            string fileNameMove = fileMove.Name;
                            if (fileMove.Exists)
                            {
                                try
                                {
                                    fileMove.MoveTo(fullToPath + fileNameMove);
                                    FileManagerController.MoveFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                    }
                    break;
                case 2:
                    switch (action)
                    {
                        case 1:
                            FileInfo fileCopy = new FileInfo(fullFilePath);
                            string fileNameCopy = fileCopy.Name;
                            /// Checking if file exists
                            if (!File.Exists(fullToPath + fileNameCopy + ".resources"))
                            {
                                try
                                {
                                    fileCopy.CopyTo(fullToPath + fileNameCopy + ".resources");
                                    FileManagerController.CopyFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath);
                            string fileName = fileMove.Name;
                            if (fileMove.Exists)
                            {
                                try
                                {
                                    fileMove.MoveTo(fullToPath + fileName + ".resources");
                                    FileManagerController.MoveFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                    }
                    break;
                case 3:
                    switch (action)
                    {
                        case 1:
                            FileInfo fileCopy = new FileInfo(fullFilePath);
                            ATTFile objCopy = new ATTFile();
                            objCopy.FileName = fileCopy.Name;
                            objCopy.Folder = toPath;
                            objCopy.FolderId = toFolderId;
                            objCopy.AddedBy = "superuser";
                            objCopy.Extension = fileCopy.Extension;
                            objCopy.PortalId = 1;
                            objCopy.UniqueId = Guid.NewGuid();
                            objCopy.VersionGuid = Guid.NewGuid();
                            objCopy.Size = int.Parse(fileCopy.Length.ToString());
                            objCopy.ContentType = FileManagerHelper.ReturnExtension(fileCopy.Extension);
                            objCopy.IsActive = 1;
                            objCopy.StorageLocation = 2;
                            if (fileCopy.Exists)
                            {
                                byte[] _fileContent = FileManagerHelper.FileToByteArray(fullFilePath);
                                objCopy.Content = _fileContent;
                                try
                                {
                                    FileManagerController.AddFile(objCopy);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath);
                            ATTFile objMove = new ATTFile();
                            objMove.FileName = fileMove.Name;
                            objMove.Folder = toPath;
                            objMove.FolderId = toFolderId;
                            objMove.AddedBy = "superuser";
                            objMove.Extension = fileMove.Extension;
                            objMove.PortalId = 1;
                            objMove.UniqueId = Guid.NewGuid();
                            objMove.VersionGuid = Guid.NewGuid();
                            objMove.Size = int.Parse(fileMove.Length.ToString());
                            objMove.ContentType = FileManagerHelper.ReturnExtension(fileMove.Extension);
                            objMove.IsActive = 1;
                            objMove.StorageLocation = 2;
                            if (fileMove.Exists)
                            {
                                byte[] _fileContent = FileManagerHelper.FileToByteArray(fullFilePath);
                                objMove.Content = _fileContent;
                                try
                                {
                                    FileManagerController.AddFile(objMove);
                                    fileMove.Delete();
                                    FileManagerController.DeleteFileFolder(0, fileId);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (action)
                    {
                        case 1:
                            FileInfo fileCopy = new FileInfo(fullFilePath + ".resources");
                            /// Checking if file exists
                            string fileNameCopy = "";
                            fileNameCopy = fileCopy.Name;
                            if (!File.Exists(Path.Combine(fullToPath, fileNameCopy.Replace(".resources", ""))))
                            {
                                try
                                {
                                    fileCopy.CopyTo(Path.Combine(fullToPath, fileNameCopy.Replace(".resources", "")));
                                    FileManagerController.CopyFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath + ".resources");
                            string fileNameMove = fileMove.Name;
                            if (fileMove.Exists)
                            {
                                try
                                {
                                    fileMove.MoveTo(Path.Combine(fullToPath, fileNameMove.Replace(".resources", "")));
                                    FileManagerController.MoveFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                    }
                    break;
                case 5:
                    switch (action)
                    {
                        case 1:
                            FileInfo file11 = new FileInfo(fullFilePath + ".resources");
                            /// Checking if file exists
                            string fileName11 = "";
                            fileName11 = filePath.Substring(filePath.LastIndexOf('/') + 1, filePath.Length - 1 - filePath.LastIndexOf('/'));
                            if (!File.Exists(fullToPath + fileName11 + ".resources"))
                            {
                                try
                                {
                                    file11.CopyTo(fullToPath + fileName11 + ".resources");
                                    FileManagerController.CopyFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath + ".resources");
                            /// Checking if file exists
                            string fileNameMove = fileMove.Name;
                            if (fileMove.Exists)
                            {
                                try
                                {
                                    fileMove.MoveTo(Path.Combine(fullFilePath, fileNameMove + ".resources"));
                                    FileManagerController.MoveFile(fileId, toFolderId, toPath, Guid.NewGuid(), Guid.NewGuid());
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            break;
                    }
                    break;
                case 6:
                    switch (action)
                    {
                        case 1:
                            FileInfo file12 = new FileInfo(fullFilePath + ".resources");
                            ATTFile obj12 = new ATTFile();
                            obj12.FileName = RemoveResourceExtension(file12.Name);
                            obj12.Folder = toPath;
                            obj12.FolderId = toFolderId;
                            obj12.AddedBy = "superuser";
                            obj12.Extension = file12.Extension;
                            obj12.PortalId = 1;
                            obj12.UniqueId = Guid.NewGuid();
                            obj12.VersionGuid = Guid.NewGuid();
                            obj12.Size = int.Parse(file12.Length.ToString());
                            obj12.ContentType = FileManagerHelper.ReturnExtension(file12.Extension);
                            obj12.IsActive = 1;
                            obj12.StorageLocation = 2;
                            if (new FileInfo(fullFilePath + ".resources").Exists)
                            {
                                File.Move(fullFilePath + ".resources", fullFilePath);
                                byte[] _fileContent = FileManagerHelper.FileToByteArray(fullFilePath);
                                obj12.Content = _fileContent;
                                try
                                {
                                    FileManagerController.AddFile(obj12);
                                    File.Move(fullFilePath, fullFilePath + ".resources");
                                }
                                catch (Exception)
                                {
                                    if (File.Exists(fullFilePath))
                                    {
                                        File.Move(fullFilePath, fullFilePath + ".resources");
                                    }

                                    throw;
                                }
                            }
                            break;
                        case 2:
                            FileInfo fileMove = new FileInfo(fullFilePath + ".resources");
                            ATTFile objMove = new ATTFile();
                            objMove.FileName = RemoveResourceExtension(fileMove.Name);
                            objMove.Folder = toPath;
                            objMove.FolderId = toFolderId;
                            objMove.AddedBy = "superuser";
                            objMove.Extension = fileMove.Extension;
                            objMove.PortalId = 1;
                            objMove.UniqueId = Guid.NewGuid();
                            objMove.VersionGuid = Guid.NewGuid();
                            objMove.Size = int.Parse(new FileInfo(fullFilePath + ".resources").Length.ToString());
                            objMove.ContentType = FileManagerHelper.ReturnExtension(fileMove.Extension);
                            objMove.IsActive = 1;
                            objMove.StorageLocation = 2;
                            if (new FileInfo(fullFilePath + ".resources").Exists)
                            {
                                byte[] _fileContent = FileManagerHelper.FileToByteArray(fullFilePath + ".resources");
                                objMove.Content = _fileContent;
                                try
                                {
                                    FileManagerController.AddFile(objMove);
                                    File.Delete(fullFilePath + ".resources");
                                    FileManagerController.DeleteFileFolder(0, fileId);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            break;
                    }
                    break;
                case 7:
                    switch (action)
                    {
                        case 1:
                            ATTFile obj20 = new ATTFile();
                            obj20 = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, obj20.FileName);
                                if (!File.Exists(newFilePath))
                                {
                                    FileManagerHelper.WriteBinaryFile(newFilePath, obj20.Content);
                                    FileInfo file20 = new FileInfo(newFilePath);
                                    ATTFile obj20New = new ATTFile(file20.Name, toPath, toFolderId, "superuser",
                                                                   file20.Extension, 1, Guid.NewGuid(), Guid.NewGuid(),
                                                                   int.Parse(file20.Length.ToString()),
                                                                   FileManagerHelper.ReturnExtension(file20.Extension), 1, 0);
                                    FileManagerController.AddFile(obj20New);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2:
                            ATTFile objMove = new ATTFile();
                            objMove = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, objMove.FileName);
                                FileManagerHelper.WriteBinaryFile(newFilePath, objMove.Content);
                                FileInfo file20 = new FileInfo(newFilePath);
                                ATTFile obj20New = new ATTFile(file20.Name, toPath, toFolderId, "superuser", file20.Extension, 1, Guid.NewGuid(), Guid.NewGuid(), int.Parse(file20.Length.ToString()), FileManagerHelper.ReturnExtension(file20.Extension), 1, 0);
                                FileManagerController.AddFile(obj20New);
                                FileManagerController.DeleteFileFolder(0, fileId);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                    }
                    break;
                case 8:
                    switch (action)
                    {
                        case 1:
                            ATTFile obj21 = new ATTFile();
                            obj21 = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, obj21.FileName);
                                if (!File.Exists(newFilePath + ".resources"))
                                {
                                    FileManagerHelper.WriteBinaryFile(newFilePath + ".resources", obj21.Content);
                                    FileInfo file21 = new FileInfo(newFilePath + ".resources");
                                    ATTFile obj21New = new ATTFile(file21.Name, toPath, toFolderId, "superuser",
                                                                   file21.Extension, 1, Guid.NewGuid(), Guid.NewGuid(),
                                                                   int.Parse(file21.Length.ToString()),
                                                                   FileManagerHelper.ReturnExtension(file21.Extension), 1, 1);
                                    FileManagerController.AddFile(obj21New);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2:
                            ATTFile objMove = new ATTFile();
                            objMove = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, objMove.FileName);
                                FileManagerHelper.WriteBinaryFile(newFilePath + ".resources", objMove.Content);
                                FileInfo file21 = new FileInfo(newFilePath + ".resources");
                                ATTFile obj21New = new ATTFile(file21.Name.Replace(".resources", ""), toPath, toFolderId, "superuser", file21.Extension, 1, Guid.NewGuid(), Guid.NewGuid(), int.Parse(file21.Length.ToString()), FileManagerHelper.ReturnExtension(file21.Extension), 1, 1);
                                FileManagerController.AddFile(obj21New);
                                FileManagerController.DeleteFileFolder(0, fileId);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                    }
                    break;
                case 9:
                    switch (action)
                    {
                        case 1:
                            ATTFile obj22 = new ATTFile();
                            obj22 = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, obj22.FileName);
                                FileInfo file22 = new FileInfo(newFilePath);
                                obj22.Folder = toPath;
                                obj22.FolderId = toFolderId;
                                obj22.AddedBy = "superuser";
                                FileManagerController.AddFile(obj22);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2:
                            ATTFile objMove = new ATTFile();
                            objMove = FileManagerController.GetFileDetails(fileId);
                            try
                            {
                                string newFilePath = Path.Combine(fullToPath, objMove.FileName);
                                FileInfo fileMove = new FileInfo(newFilePath);
                                objMove.Folder = toPath;
                                objMove.FolderId = toFolderId;
                                objMove.AddedBy = "superuser";
                                FileManagerController.AddFile(objMove);
                                FileManagerController.DeleteFileFolder(0, fileId);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                    }
                    break;

            }
        }
        /// <summary>
        /// Creates a html string to be rendered based upon the dynamic conditions
        /// </summary>
        /// <param name="IsZip"></param>
        /// <param name="IsImg"></param>
        /// <param name="StorageLocation"></param>
        /// <param name="ext"></param>
        /// <param name="urlPath"></param>
        /// <param name="absolutePath"></param>
        /// <param name="downloadPath"></param>
        /// <param name="checkId"></param>
        /// <param name="folderId"></param>
        /// <param name="file"></param>
        /// <param name="sb"></param>
        /// <param name="permission"></param>
        /// <param name="dictImages"></param>
        public static void ConstructHTMLString(bool IsZip, bool IsImg, int StorageLocation, string ext, string urlPath, string absolutePath, string downloadPath, string checkId, int folderId, ATTFile file, ref StringBuilder sb, string permission, Dictionary<string, string> dictImages, int index)
        {
            switch (StorageLocation)
            {
                case 0:
                    string attStr = FileManagerHelper.GetAttributeString(absolutePath);
                    if (IsZip)
                    {
                        sb.Append(AddExtension(ext, index));
                        sb.Append(AddCheckBox(checkId));
                        sb.Append(AddDownloadLink(downloadPath, folderId, file, permission, ext));
                        sb.Append(AddInfoSpan(file, attStr, StorageLocation));
                        sb.Append(AddExtractButton(Path.Combine(file.Folder, file.FileName), dictImages["Extract"].ToString(), permission));
                        sb.Append(AddEditButton(Path.Combine(file.Folder, file.FileName), dictImages["Edit"].ToString(), permission));
                        sb.Append(AddDeleteButton(Path.Combine(file.Folder, file.FileName), dictImages["Delete"].ToString(), permission));


                        sb.Append("</tr>");
                    }
                    else
                    {
                        if (IsImg)
                        {
                            sb.Append(AddExtension(ext, index));
                            sb.Append(AddCheckBox(checkId));
                            sb.Append(AddDownloadLink(downloadPath, folderId, file, permission, ext));
                            sb.Append(AddInfoSpan(file, attStr, StorageLocation));
                            sb.Append(AddPreviewButton(urlPath, dictImages["Preview"].ToString()));
                            sb.Append(AddEditButton(Path.Combine(file.Folder, file.FileName), dictImages["Edit"].ToString(), permission));
                            sb.Append(AddDeleteButton(Path.Combine(file.Folder, file.FileName), dictImages["Delete"].ToString(), permission));




                            sb.Append("</tr>");
                        }
                        else
                        {
                            sb.Append(AddExtension(ext, index));
                            sb.Append(AddCheckBox(checkId));
                            sb.Append(AddDownloadLink(downloadPath, folderId, file, permission, ext));
                            sb.Append(AddInfoSpan(file, attStr, StorageLocation));
                            sb.Append(AddBlankSpan());
                            sb.Append(AddEditButton(Path.Combine(file.Folder, file.FileName), dictImages["Edit"].ToString(), permission));

                            sb.Append(AddDeleteButton(Path.Combine(file.Folder, file.FileName), dictImages["Delete"].ToString(), permission));

                            sb.Append("</tr>");
                        }
                    }
                    break;
                case 1:
                    string attStr1 = FileManagerHelper.GetAttributeString(absolutePath + ".resources");
                    sb.Append(AddExtension(ext, index));
                    sb.Append(AddCheckBox(checkId));
                    sb.Append(AddDownloadLink(downloadPath, folderId, file, permission, ext));
                    sb.Append(AddInfoSpan(file, attStr1, StorageLocation));
                    sb.Append(AddDeleteButton(Path.Combine(file.Folder, file.FileName), dictImages["Delete"].ToString(), permission));

                    sb.Append(AddBlankSpan());
                    sb.Append(AddEditButton(Path.Combine(file.Folder, file.FileName), dictImages["Edit"].ToString(), permission));
                    sb.Append("</tr>");
                    break;
                case 2:
                    sb.Append(AddExtension(ext, index));
                    sb.Append(AddCheckBox(checkId));
                    sb.Append(AddDownloadLink(downloadPath, folderId, file, permission, ext));
                    sb.Append(AddInfoSpan(file, "", StorageLocation));
                    sb.Append(AddBlankSpan());
                    sb.Append(AddDeleteButton(Path.Combine(file.Folder, file.FileName), dictImages["Delete"].ToString(), permission));

                    sb.Append(AddEditButton(Path.Combine(file.Folder, file.FileName), dictImages["Edit"].ToString(), permission));
                    sb.Append("</li>");
                    break;
            }
        }

        #region HTMLConstructerHelper
        public static string AddExtension(string extension, int index)
        {
            extension = string.Format("{0}", index % 2 == 0 ? "sfEven" : "sfOdd");
            return ("<tr class=\"" + extension + "\">");
        }
        public static string AddCheckBox(string checkId)
        {
            return ("<td><span class=\"check\"><input type=\"checkbox\" id=" + checkId + "></span></td>");
        }
        public static string AddDownloadLink(string filePath, int folderId, ATTFile file, string permission, string extension)
        {
            extension = string.Format("ext_{0}", extension);
            string name = file.FileName;
            if (file.FileName.Length > 40)
            {
                name = file.FileName.Substring(0, 40) + "...";
            }
            if (permission == "edit" || permission == "view")
                return ("<td class='" + extension + "' width='30%'><a class=\"download_link\" href=\"" + filePath + "FileID=" + file.FileId + "&FolderID=" + folderId + "\" rel=" + file.FileId + ">" + name + "</a></td>");
            else
                return ("<td class='" + extension + "' width='30%'><a class=\"download_link\" href=\"#\" rel=" + file.FileId + ">" + file.FileName + "</a></td>");

        }
        public static string AddInfoSpan(ATTFile file, string attributeString, int mode)
        {
            string html = "";

            switch (mode)
            {
                case 2:
                    html = "<td><span class=\"info\">" + file.AddedOn + "||" + file.Size + "bytes" + "</span></span></td>";
                    break;
                default:
                    html = "<td><span class=\"info\">" + file.AddedOn + "||" + file.Size + "bytes" + "||<span class=\"attr\">" + attributeString + "</span></span></td>";
                    break;
            }
            return html;
        }
        public static string AddDeleteButton(string filePath, string image, string permission)
        {
            if (permission == "edit")
                return ("<td><a class=\"delete\" href=\"#\" rel=\"" + filePath + "\"><img src=\"" + image + "\"></a></td>");
            else
                return ("");

        }
        public static string AddEditButton(string filePath, string image, string permission)
        {
            if (permission == "edit")
                return ("<td><span class=\"edit\"><a class=\"edit\" href=\"#\" rel=\"" + filePath + "\"><img src=\"" + image + "\"></a></span></td>");
            else
                return ("");
        }
        public static string AddPreviewButton(string filePath, string image)
        {

            return ("<td><span class=\"preview\"><a class=\"preview\" href=\"" + filePath + "\" title=\"Preview\" rel=\"" + filePath + "\"><img src=\"" + image + "\"></a></span></td>");

        }
        public static string AddExtractButton(string filePath, string image, string permission)
        {
            if (permission == "edit")
                return ("<td><span class=\"decompress\"><a class=\"decompress\" title=\"Extract\" href=\"#\" rel=\"" + filePath + "\"><img src=\"" + image + "\"></a></span></td>");
            else
                return ("<td><span class=\"decompress\"></span></td>");
        }
        public static string AddBlankSpan()
        {
            return ("<td><span class=\"decompress\"></span></td>");
        }
        #endregion




    }



}
