#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using SageFrame.Web;
using RegisterModule;
using System.Web.Hosting;
using SageFrame.SageFrameClass.Services;
using System.Web;

#endregion


[Serializable]
    public class ModuleSfeWriter : BaseAdministrationUserControl
    {
        private ModuleInfoPackage _module;

        #region "Constructors"
        protected ModuleSfeWriter()
        {
        }

        public ModuleSfeWriter(ModuleInfoPackage module)
        {
            _module = module;

        }
        #endregion

        #region "Public Properties"
        public string TempFolderPath { get; set; }
        public ModuleInfoPackage Module
        {
            get {return _module;}
            set { _module = value; }
        }

        string strFilesToMove = "";
        #endregion

        public void CreatePackage(string archiveName, string manifestName,List<string> FileList,HttpResponse Response,string SFEPath,ModuleInfoPackage package,string strFiles)
        {
            strFilesToMove = strFiles;
            WriteManifest(manifestName, SFEPath, package);
            CreateZipResponse(FileList, Response, Module.FolderName, SFEPath);
        }

        private void AddFile(string manifestName)
        {
            string sourcepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Modules");
            DirectoryInfo dir = new DirectoryInfo(sourcepath);

            foreach (string fileName in _module.FileNames)
            {
                DirectoryInfo[] sourcedir = dir.GetDirectories(fileName, SearchOption.AllDirectories);
                foreach (DirectoryInfo dirs in sourcedir)
                {
                    Installers installhelp = new Installers();
                    string ZipPath = Path.Combine(TempFolderPath, dirs.Name + ".zip");

                    ZipUtil.ZipFiles(dirs.FullName, ZipPath, string.Empty);
                }
            }

        }


        public void CreateZipResponse(List<string> ZipFileList,HttpResponse Response,string FolderName,string TempFolder)
        {
            try
            {
                ZipUtil.CreateZipResponse(ZipFileList, Response, FolderName, TempFolder);
            }
            catch { }
        }
        public void CreateZipFile(string archiveName)
        {
            string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources\\temp\\TempResources");
            path = Path.Combine(path, "NewPackage");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string ZipPath = Path.Combine(path, archiveName + ".zip");

            ZipUtil.ZipFiles(TempFolderPath, ZipPath, string.Empty);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(ZipPath);      


        }




        public void WriteManifest(string manifestName, string SFEPath,ModuleInfoPackage package)
        {
            string manifestfile = manifestName+".SFE";// "sfe_" +
            string manifestPath = Path.Combine(SFEPath, manifestfile);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = false;

            XmlWriter writer = XmlWriter.Create(manifestPath, settings);

            WriteManifestStartElement(writer);
            
            WritePackageStartElement(writer);
            WriteModuleElements(writer);
            WriteFilesInfo(writer);           
            WriteFileMoveInfo(writer);
          
            WriteManifestEndElement(writer);
           // WriteManifestEndElement(writer);

            //Close Writer
            writer.Close();
            package.FileNames.Add(manifestPath);

        }


        private void WriteModuleElements(XmlWriter writer)
        {
            writer.WriteStartElement("modules");
            WriteModuleElement(writer);
            writer.WriteEndElement();        
        }
        private void WritePackageEndElement(XmlWriter writer)
        {
           
            writer.WriteEndElement();

           
            writer.WriteEndElement();
        }

        private void WritePackageStartElement(XmlWriter writer)
        {
            //Start package Element
            writer.WriteStartElement("folder");
            writer.WriteElementString("name",Module.FriendlyName);
            writer.WriteElementString("friendlyname", Module.FriendlyName);
            writer.WriteElementString("foldername", Module.FolderName);
            writer.WriteElementString("modulename", Module.ModuleName);
            writer.WriteElementString("description", Module.Description);
            writer.WriteElementString("version", Module.Version);
            writer.WriteElementString("businesscontrollerclass", Module.BusinessControllerClass);
            writer.WriteElementString("compatibleversions", Module.CompatibleVersions);
            writer.WriteElementString("owner", Module.Owner);
            writer.WriteElementString("organization", Module.Organization);
            writer.WriteElementString("url", Module.URL);
            writer.WriteElementString("email", Module.Email);
            writer.WriteElementString("releasenotes", Module.ReleaseNotes);
            writer.WriteElementString("license", Module.License);   
        }


        private void WriteModuleElement(XmlWriter writer)
        {
           writer.WriteStartElement("module");

            foreach(ModuleElement moduleElement in Module.ModuleElements)
            {
                 writer.WriteElementString("friendlyname",moduleElement.FriendlyName);
                 writer.WriteElementString("cachetime",moduleElement.CacheTime);

                 writer.WriteStartElement("controls");
                foreach(ControlInfo controlInfo in moduleElement.Controls)
                {
                    WriteControlElement(writer,controlInfo);
                }
                writer.WriteEndElement();
           }
         
          writer.WriteEndElement();
        
        }

        private void WriteControlElement(XmlWriter writer,ControlInfo controlInfo)
        {                            
                    writer.WriteStartElement("control");
                    writer.WriteElementString("key", controlInfo.Key);
                    writer.WriteElementString("title", controlInfo.Title);
                    writer.WriteElementString("src", controlInfo.Src);
                    writer.WriteElementString("type", controlInfo.Type);
                    writer.WriteElementString("helpurl", controlInfo.HelpUrl);
                    writer.WriteElementString("supportspartialrendering", controlInfo.SupportSpatial);
                    writer.WriteEndElement();                         
        }

        private void WriteFilesInfo(XmlWriter writer)
        {
            string file = "";
            writer.WriteStartElement("files");
            foreach (string fileName in Module.FileNames)
            {
                if (!string.IsNullOrEmpty(fileName) && (fileName.EndsWith(".dll") || fileName.EndsWith(".SqlDataProvider")))
                {
                    file = fileName.Substring(fileName.LastIndexOf("\\") + 1);

                    writer.WriteStartElement("file");
                    if (fileName.EndsWith(".dll"))
                        writer.WriteAttributeString("order", "0");
                    //else if (file.Split('.')[0].ToString() == "Uninstall")
                    //    writer.WriteAttributeString("order", "4");
                    else
                        writer.WriteAttributeString("order", "" + int.Parse(file.Split('.')[2].ToString()) + "");

                    writer.WriteElementString("name", file);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private void WriteFileMoveInfo(XmlWriter writer)
        {
            if (strFilesToMove.Length > 0)
            {
                string[] str = strFilesToMove.Split(',');
                writer.WriteStartElement("move");
                writer.WriteStartElement("files");
                foreach (string fileName in str)
                {
                    if (!Directory.Exists(fileName.Split('#')[0]))
                    {
                        writer.WriteStartElement("file");
                        writer.WriteElementString("from", fileName.Split('#')[0]);
                        writer.WriteElementString("to", fileName.Split('#')[1]);
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
                WriteDirectriesInfo(writer);
                writer.WriteEndElement();
            }
        }

        private void WriteDirectriesInfo(XmlWriter writer)
        {
            writer.WriteStartElement("directories");
            string[] str = strFilesToMove.Split(',');
            foreach (string fileName in str)
            {
                if (Directory.Exists(fileName.Split('#')[0]))
                {                   
                    writer.WriteStartElement("directory");
                    writer.WriteElementString("from", fileName.Split('#')[0]);
                    writer.WriteElementString("to", fileName.Split('#')[1]);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
        public static void WriteManifestEndElement(XmlWriter writer)
        {            
            writer.WriteEndElement();         
            writer.WriteEndElement();
            //Close root Element
            writer.WriteEndElement();
        }

        public static void WriteManifestStartElement(XmlWriter writer)
        {
            //Start the new Root Element
            writer.WriteStartElement("sageframe");
            writer.WriteAttributeString("version", "1.0.0.0");
            writer.WriteAttributeString("type", "module");

            //Start packages Element
            writer.WriteStartElement("folders");

        }
    }

