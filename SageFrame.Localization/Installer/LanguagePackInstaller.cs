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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections;
using System.Xml.XPath;
using System.Xml;
using SageFrame.Modules;
using SageFrame.Web;
using SageFrame.Web.Utilities;
using RegisterModule;



namespace SageFrame.Localization
{
    public class LanguagePackInstaller
    {
        public ArrayList Step0CheckLogic(FileUpload fileModule)
        {
            PackageInfo package = new PackageInfo();
            int ReturnValue = 0;
            try
            {
                if (fileModule.HasFile)//check for Empty entry
                {
                    if (IsVAlidZipContentType(fileModule.FileName))//Check if valid Zip file submitted
                    {
                        string path = HttpContext.Current.Server.MapPath("~/");
                        string temPath = SageFrame.Core.RegisterModule.Common.TemporaryFolder;
                        string destPath = Path.Combine(path, temPath);
                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);

                        string filePath = destPath + "\\" + fileModule.FileName;
                        fileModule.SaveAs(filePath);
                        string ExtractedPath = string.Empty;
                        ZipUtil.UnZipFiles(filePath, destPath, ref ExtractedPath, SageFrame.Core.RegisterModule.Common.Password, SageFrame.Core.RegisterModule.Common.RemoveZipFile);
                        package.TempFolderPath = ExtractedPath;
                        fileModule.FileContent.Dispose();
                        if (!string.IsNullOrEmpty(package.TempFolderPath) && Directory.Exists(package.TempFolderPath))
                        {
                            switch (Step1CheckLogic(package.TempFolderPath, package))
                            {
                                case 0://No manifest file
                                    DeleteTempDirectory(package.TempFolderPath);
                                    ReturnValue = 3;
                                    break;
                                case -1://Invalid Manifest file
                                    DeleteTempDirectory(package.TempFolderPath);
                                    ReturnValue = 4;
                                    break;
                                case 1://Already exist
                                    ReturnValue = 2;
                                    break;
                                case 2://Fresh Installation
                                    ReturnValue = 1;
                                    break;
                            }
                        }
                        else
                        {
                            ReturnValue = 0;
                        }
                    }
                    else
                    {
                        ReturnValue = -1;//"Invalid Zip file submited to upload!";
                    }
                }
                else
                {
                    ReturnValue = 0;// "No package file is submited to upload!";
                }
            }
            catch
            {
                ReturnValue = -1;
            }
            ArrayList arrColl = new ArrayList();
            arrColl.Add(ReturnValue);
            arrColl.Add(package);
            return arrColl;
        }

        public bool checkValidManifestFile(XmlElement root, PackageInfo package)
        {
            if (root.Name == "sageframe")
            {
                return true;
            }
            return false;
        }

        public bool IsLanguageExists(string moduleName, PackageInfo package)
        {
            
            return false;
        }

        public int Step1CheckLogic(string TempUnzippedPath, PackageInfo package)
        {
            if (checkFormanifestFile(TempUnzippedPath, package) != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(TempUnzippedPath + '\\' + package.ManifestFile);
                XmlElement root = doc.DocumentElement;
                if (checkValidManifestFile(root, package))
                {
                    XmlNodeList xnList = doc.SelectNodes("sageframe/packages");
                    foreach (XmlNode xn in xnList)
                    {
                        package.PackageName = xn["package"].Attributes["name"].InnerXml.ToString();
                       
                        if (!String.IsNullOrEmpty(package.PackageName) && IsLanguageExists(package.PackageName.ToLower(),package))
                        {
                            string path = HttpContext.Current.Server.MapPath("~/");
                            string targetPath = path + SageFrame.Core.RegisterModule.Common.ModuleFolder + '\\' + package.FolderName;
                            package.InstalledFolderPath = targetPath;
                            return 1;//Already exist
                        }
                        else
                        {
                            return 2;//Not Exists
                        }
                    }
                }
                else
                {
                    return -1;//Invalid Manifest file
                }
            }
            return 0;//No manifest file
        }

        public string checkFormanifestFile(string TempUnzippedPath, PackageInfo package)
        {
            DirectoryInfo dir = new DirectoryInfo(TempUnzippedPath);
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                if (f.Extension.ToLower() == ".sfe")
                {
                    package.ManifestFile = f.Name;
                    return package.ManifestFile;
                }
                else
                {
                    package.ManifestFile = "";
                }
            }
            return package.ManifestFile;
        }

        private bool IsVAlidZipContentType(string p)
        {
            // extract and store the file extension into another variable
            String fileExtension = p.Substring(p.Length - 3, 3);
            // array of allowed file type extensions
            string[] validFileExtensions = { "zip" };
            var flag = false;
            // loop over the valid file extensions to compare them with uploaded file
            for (var index = 0; index < validFileExtensions.Length; index++)
            {
                if (fileExtension.ToLower() == validFileExtensions[index].ToString().ToLower())
                {
                    flag = true;
                }
            }
            return flag;
        }
        public void ModulesRollBack(int ModuleID, int PortalID)
        {
            try
            {
                SQLHandler objSQL = new SQLHandler();
                objSQL.ModulesRollBack(ModuleID, PortalID);
            }
            catch
            {
                //ProcessException(e);
            }
        }

        public PackageInfo fillPackageInfo(PackageInfo package)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(package.TempFolderPath + '\\' + package.ManifestFile);
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {
                XmlNodeList xnList = doc.SelectNodes("sageframe/packages/package");
                foreach (XmlNode xn in xnList)
                {
                    package.PackageType = xn.Attributes["type"].InnerText.ToString();
                    package.FriendlyName = xn["friendlyname"].InnerXml.ToString();
                    package.Description = xn["description"].InnerXml.ToString();
                    package.Version = xn.Attributes["version"].InnerText.ToString();
                    package.OwnerName = xn["owner"].ChildNodes[0].InnerXml.ToString();
                    package.Organistaion = xn["owner"].ChildNodes[1].InnerXml.ToString();
                    package.URL = xn["owner"].ChildNodes[2].InnerXml.ToString();
                    package.Email = xn["owner"].ChildNodes[3].InnerXml.ToString();
                    package.ReleaseNotes = xn["releasenotes"].InnerXml.ToString();
                    package.License = xn["license"].InnerXml.ToString();
                }
            }
            return package;
        }

        public void InstallPackage(PackageInfo package,string destinationpath,bool isOverWrite,List<FileDetails> selectedModules)
        {
            XmlDocument doc = new XmlDocument();
            ArrayList dllFiles = new ArrayList();
          
            doc.Load(package.TempFolderPath + '\\' + package.ManifestFile);
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {
                XmlNodeList xnList = doc.SelectNodes("sageframe/packages/package/components/component/languagefiles/languagefile");
                foreach (XmlNode xn in xnList)
                {
                    string dir = xn["path"].InnerText.ToString();
                    bool isExist = selectedModules.Exists(
                        delegate(FileDetails fd)
                        {
                            return (dir.Contains(fd.FilePath));
                        }

                        );
                    if (isExist)
                    {
                        string sourcefile = package.TempFolderPath + "\\" + dir + "\\" + xn["name"].InnerText.ToString();

                        if (Directory.Exists(destinationpath + "/" + dir))
                        {
                            if (!File.Exists(destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString()))
                            {
                                File.Copy(sourcefile, destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString());
                            }
                            else if (isOverWrite)
                            {
                                File.Delete(destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString());
                                File.Copy(sourcefile, destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString());
                            }
                        }
                        else if (!Directory.Exists(destinationpath + "/" + dir))
                        {
                            Directory.CreateDirectory(destinationpath + "/" + dir);
                            File.Copy(sourcefile, destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString());
                        }

                    }
                }
            }
               
            DeleteTempDirectory(package.TempFolderPath);
        }

        public static List<FileDetails> CompareExistingFiles(PackageInfo package,string destinationpath)
        {
            XmlDocument doc = new XmlDocument();
            ArrayList dllFiles = new ArrayList();
            List<FileDetails> lstFiles = new List<FileDetails>();
            doc.Load(package.TempFolderPath + '\\' + package.ManifestFile);
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {
                XmlNodeList xnList = doc.SelectNodes("sageframe/packages/package/components/component/languagefiles/languagefile");
                foreach (XmlNode xn in xnList)
                {
                    string dir = xn["path"].InnerText.ToString();
                    string sourcefile = package.TempFolderPath + "\\" + dir + "\\" + xn["name"].InnerText.ToString();

                    FileDetails obj = new FileDetails();
                    obj.FilePath = dir + "\\" + xn["name"].InnerText.ToString();

                    if (File.Exists(destinationpath + "/" + dir + "\\" + xn["name"].InnerText.ToString()))
                    {                       
                        obj.IsExists = true;
                       
                    }
                    else
                    {
                        obj.IsExists = false;

                    }
                    lstFiles.Add(obj);
                 

                }
            }
            return lstFiles;
        }

       


        public void DeleteTempDirectory(string TempDirectory)
        {
            try
            {
                if (!string.IsNullOrEmpty(TempDirectory))
                {
                    if (Directory.Exists(TempDirectory))
                        Directory.Delete(TempDirectory, true);
                }
            }
            catch (IOException ex)
            {
                throw ex;//cant delete folder
            }
        }
    }
}

