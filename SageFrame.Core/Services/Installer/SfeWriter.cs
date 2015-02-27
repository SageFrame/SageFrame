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
using System.Xml;
using System.IO;
using SageFrame.Web;
using RegisterModule;
using System.Web;
using System.Web.Hosting;
using SageFrame.SageFrameClass.Services;

namespace SageFrame.Core.Services.Installer
{
    public class SfeWriter : BaseAdministrationUserControl
    {
        private CompositeModule _Package;

        #region "Constructors"
        protected SfeWriter()
        {
        }

        public SfeWriter(CompositeModule package)
        {
            _Package = package;

        }
        #endregion

        #region "Public Properties"
        public string TempFolderPath { get; set; }
        public string ZipPath { get; set; }
        public CompositeModule Package
        {
            get
            {
                return _Package;
            }
            set
            {
                _Package = value;
            }
        }
        #endregion

        public void CreatePackage(string archiveName, string manifestName, HttpResponse response, string tempFolderPath)//, HttpResponse response
        {
            try
            {
                TempFolderPath = tempFolderPath;
                AddFile(manifestName);
                WriteManifest(manifestName);
              
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            CreateZipFile(archiveName, response);
      
        }

        private void AddFile(string manifestName)
        {
            string sourcepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Modules");
            DirectoryInfo dir = new DirectoryInfo(sourcepath);

            foreach (Component component in Package.Components)
            {
                DirectoryInfo[] sourcedir = dir.GetDirectories(component.Name, SearchOption.AllDirectories);
                foreach (DirectoryInfo dirs in sourcedir)
                {
                    Installers installhelp = new Installers();
                    string ZipPath = Path.Combine(TempFolderPath, dirs.Name + ".zip");
                    ZipUtil.ZipFiles(dirs.FullName, ZipPath, string.Empty);
                    component.IsChecked = true;

                }
            }

        }
        public void CreateZipFile(string archiveName, HttpResponse Response)//, HttpResponse response
        {
            try
            {
                string path =  TempFolderPath;
                
                ZipPath = Path.Combine(path, archiveName + ".zip");
                List<String> list = new List<string>();

                foreach (string fileName in Directory.GetFiles(TempFolderPath)) 
                {
                    list.Add(fileName);
                }

                ZipUtil.CreateZipResponse(list, Response, archiveName, TempFolderPath);
             //   ZipUtil.ZipFiles(TempFolderPath, ZipPath, string.Empty);
              
                //System.IO.FileInfo fileInfo = new System.IO.FileInfo(ZipPath);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { //HttpContext.Current.Response.End();
            }


        }
        public void WriteManifest(string manifestName)
        {

            string manifestfile = "sfe_" + manifestName;
            string manifestPath = Path.Combine(TempFolderPath, manifestfile);
            if (!manifestPath.EndsWith(".sfe"))
            {
                manifestPath = manifestPath + ".sfe";
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            XmlWriter writer = XmlWriter.Create(manifestPath, settings);

            WriteManifestStartElement(writer);

            WritePackageStartElement(writer);
            WriteComponentStartElement(writer);
            //Close Dotnetnuke Element
            WriteManifestEndElement(writer);
            WriteManifestEndElement(writer);

            //Close Writer
            writer.Close();

        }

        private void WritePackageEndElement(XmlWriter writer)
        {
            //Close components Element
            writer.WriteEndElement();

            //Close package Element
            writer.WriteEndElement();
        }

        private void WritePackageStartElement(XmlWriter writer)
        {
            //Start package Element
            writer.WriteStartElement("folder");
            writer.WriteElementString("name", Package.Name);
            writer.WriteElementString("foldername", Package.Name);

            writer.WriteElementString("type", Package.PackageType);
            writer.WriteElementString("version", Package.Version.ToString());

            //Write FriendlyName
            writer.WriteElementString("friendlyName", Package.FriendlyName);

            //Write Description
            writer.WriteElementString("description", Package.Description);



            writer.WriteElementString("owner", Package.Owner);
            writer.WriteElementString("organization", Package.Organization);
            writer.WriteElementString("url", Package.URL);
            writer.WriteElementString("email", Package.Email);


            //Write License
            writer.WriteElementString("license", Package.License);

            //Write Release Notes
            writer.WriteElementString("releasenotes", Package.ReleaseNotes);


            //Write components Element
            writer.WriteStartElement("modules");
        }

        private void WriteComponentStartElement(XmlWriter writer)
        {
            foreach (Component component in Package.Components)
            {
                if (component.IsChecked)
                {

                    writer.WriteStartElement("module");
                    writer.WriteElementString("name", component.Name);
                    writer.WriteElementString("friendlyname", component.FriendlyName);
                    writer.WriteElementString("description", component.Description);
                    writer.WriteElementString("version", component.Version.ToString());
                    writer.WriteElementString("businesscontrollerclass", component.BusinesscontrollerClass);
                    writer.WriteElementString("zipfile", component.ZipFile);
                    writer.WriteEndElement();
                }
            }


        }

        public static void WriteManifestEndElement(XmlWriter writer)
        {
            //Close packages Element
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

        public void GetTempPath(string manifestName)
        {
            string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string folderPath = Path.Combine(path, "temp");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            TempFolderPath = Path.Combine(folderPath, manifestName);
            if (Directory.Exists(TempFolderPath))
            {
                Directory.Delete(TempFolderPath, true);
            }
            Directory.CreateDirectory(TempFolderPath);
        }


    }


}
