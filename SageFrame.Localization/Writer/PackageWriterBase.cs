/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.Xml;
using SageFrame.Common;
using SageFrame.Localization;


 public class PackageWriterBase
    {
        public static void WriteZipFile(List<FileDetails> filesToZip, string path,string manifestPath,string manifest )
        {
            int compression = 9;
          
            FileDetails fd = new FileDetails(manifest, manifestPath,manifestPath);
            filesToZip.Insert(0,fd);

            foreach (FileDetails obj in filesToZip)
                if (!File.Exists(obj.FilePath))
                    throw new ArgumentException(string.Format("The File {0} does not exist!", obj.FileName));

            Object _locker=new Object();
            lock(_locker)
            {
                Crc32 crc32 = new Crc32();
                ZipOutputStream stream = new ZipOutputStream(File.Create(path));
                stream.SetLevel(compression);
                for (int i = 0; i < filesToZip.Count; i++)
                {
                    ZipEntry entry = new ZipEntry(filesToZip[i].FolderInfo + "/" + filesToZip[i].FileName);
                    entry.DateTime = DateTime.Now;
                    if (i == 0)
                    {
                        entry = new ZipEntry(manifest);
                    }

                    using (FileStream fs = File.OpenRead(filesToZip[i].FilePath))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        entry.Size = fs.Length;
                        fs.Close();
                        crc32.Reset();
                        crc32.Update(buffer);
                        entry.Crc = crc32.Value;
                        stream.PutNextEntry(entry);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
                stream.Finish();
                stream.Close();
                DeleteManifest(manifestPath);
            }
            

          

           
        }

        public static void WriteManifest(string path,string filename,List<FileDetails> selectedResxFiles,PackageInfo package)
        {
            
            XmlWriter writer = XmlWriter.Create(path + @"/" + filename + ".sfe",XMLUtils.GetXmlWriterSettings());
            
            // Write first element
            writer.WriteStartElement("sageframe");
            writer.WriteAttributeString("type", "Package");
            writer.WriteAttributeString("version", "1.0.0.1");
            writer.WriteStartElement("packages");
            WritePackageDetails(writer,selectedResxFiles,package);

            // close writer
            writer.Close();
           
        }

        private static void WritePackageDetails(XmlWriter writer, List<FileDetails> selectedResxFiles,PackageInfo package)
        {
            writer.WriteStartElement("package");
            writer.WriteAttributeString("name", package.PackageName);
            writer.WriteAttributeString("type", package.PackageType);
            writer.WriteAttributeString("version", package.Version);
            writer.WriteElementString("friendlyname", package.FriendlyName);
            writer.WriteElementString("description", package.Description);
            writer.WriteStartElement("owner");
            writer.WriteElementString("name", package.OwnerName);
            writer.WriteElementString("organization",package.Organistaion);
            writer.WriteElementString("url","");
            writer.WriteElementString("email", package.Email);
            writer.WriteEndElement();
            writer.WriteElementString("license", package.License);
            writer.WriteElementString("releasenotes", package.ReleaseNotes);
            writer.WriteStartElement("components");
            writer.WriteStartElement("component");
            writer.WriteAttributeString("type", "CoreLanguage");
            writer.WriteStartElement("languagefiles");
            writer.WriteElementString("code","");
            writer.WriteElementString("displayname", "");
            writer.WriteElementString("fallback", "");           
           
            WritePackageResources(writer,selectedResxFiles);

            WritePackageEndElements(writer);
           

        }
        public static void WritePackageResources(XmlWriter writer, List<FileDetails> selectedResxFiles)
        {
            foreach (FileDetails fd in selectedResxFiles)
            {
                writer.WriteStartElement("languagefile");
                writer.WriteElementString("path", fd.FolderInfo);
                writer.WriteElementString("name", fd.FileName);
                writer.WriteEndElement();
            }
        }

        public static void WritePackageEndElements(XmlWriter writer)
        {
           
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
      
        public static void DeleteManifest(string manifest)
        {
            if(File.Exists(manifest))
            File.Delete(manifest);
        }
    }

