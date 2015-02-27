#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

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
using SageFrame.Core;
using System.Web.Hosting;
using System.Reflection;
using SageFrame.Core.Services;

#endregion



namespace SageFrame.SageFrameClass.Services
{
    public class Installers : BaseAdministrationUserControl
    {
        #region "Private Members"

       
        System.Nullable<Int32> _newModuleID = 0;
        System.Nullable<Int32> _newModuleDefID = 0;
        System.Nullable<Int32> _newPortalmoduleID = 0;

        string Exceptions = string.Empty;

        public enum ControlType
        {
            View = 1,
            Edit = 2,
            Setting = 3
        }

        #endregion

        #region "Public Properties"

        #endregion

        public Installers()
        {
        }

        public static ModuleInfo GetModuleByModuleName(string ModuleName, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleName", ModuleName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return SQLH.ExecuteAsObject<ModuleInfo>("[dbo].[sp_ModulesGetByModuleName]", ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ModuleInfo GetModuleByName(string moduleName)
        {
            ModuleInfo module = null;
            ModuleInfo objModule = Installers.GetModuleByModuleName(moduleName, GetPortalID);
            if (objModule != null)
            {
                module = new ModuleInfo();


                module.ModuleName = objModule.ModuleName;
                module.Name = objModule.ModuleName;
                module.FriendlyName = objModule.FriendlyName;
                module.Description = objModule.Description;
                module.Version = objModule.Version;
                module.BusinessControllerClass = objModule.BusinessControllerClass;
                module.FolderName = objModule.FolderName;
                module.CompatibleVersions = objModule.CompatibleVersions;

                module.ModuleID = objModule.ModuleID;
                module.PackageType = "Module";

                module.isPremium = true;
                module.supportedFeatures = 0;
                module.BusinessControllerClass = "";
                module.CompatibleVersions = "";
                module.dependencies = "";
                module.permissions = "";

            }
            return module;
        }

        /// <summary>
        /// index 0 will contain integer part of the function
        /// index 1 will contain module object
        /// </summary>
        /// <param name="fileModule"></param>
        /// <returns></returns>
        public ArrayList Step0CheckLogic(FileUpload fileModule)
        {
            CompositeModule compositeModule = new CompositeModule();
            ModuleInfo module = new ModuleInfo();
            bool IsCompositeModule = false;
            int ReturnValue = 0;
            try
            {
                if (fileModule.HasFile)//check for Empty entry
                {
                    if (IsVAlidZipContentType(fileModule.FileName))//Check if valid Zip file submitted
                    {
                        string path = HttpContext.Current.Server.MapPath("~/");
                        string temPath = SageFrame.Common.RegisterModule.Common.TemporaryFolder + "\\" + fileModule.FileName.Substring(0, fileModule.FileName.IndexOf("."));
                        string destPath = Path.Combine(path, temPath);
                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);

                        string filePath = destPath + "\\" + fileModule.FileName;
                        fileModule.SaveAs(filePath);
                        string ExtractedPath = string.Empty;
                        ZipUtil.UnZipFiles(filePath, destPath, ref ExtractedPath, SageFrame.Common.RegisterModule.Common.Password, SageFrame.Common.RegisterModule.Common.RemoveZipFile);



                        fileModule.FileContent.Dispose();
                        if (!string.IsNullOrEmpty(ExtractedPath) && Directory.Exists(ExtractedPath))
                        {
                            string ManifestFile = checkFormanifestFile(ExtractedPath);

                            if (ManifestFile.Trim() != "")
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(ExtractedPath + '\\' + ManifestFile);
                                XmlElement root = doc.DocumentElement;
                                if (checkValidManifestFile(root))
                                {
                                    int logic = 2;

                                    if (IsMultipleModule(doc))
                                    {
                                        logic = Step1CheckLogic(ExtractedPath, doc);
                                        IsCompositeModule = true;
                                        // if (logic == 2)
                                        // PopulateCompositeModule(ExtractedPath, doc, ref compositeModule);
                                        compositeModule.TempFolderPath = ExtractedPath;
                                        compositeModule.ManifestFile = ManifestFile;


                                    }
                                    else
                                    {
                                        logic = Step1CheckLogic(module.TempFolderPath, module, doc);
                                        module.TempFolderPath = ExtractedPath;
                                        module.ManifestFile = ManifestFile;

                                    }

                                    switch (logic)
                                    {
                                        case 0://No manifest file
                                            DeleteTempDirectory(ExtractedPath);
                                            ReturnValue = 3;
                                            break;
                                        case -1://Invalid Manifest file
                                            DeleteTempDirectory(ExtractedPath);
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
                            }//end of  if (ManifestFile.Trim() 


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

            if (IsCompositeModule)
                arrColl.Add(compositeModule);
            else arrColl.Add(module);
            arrColl.Add(IsCompositeModule);

            return arrColl;
        }



        /// <summary>
        /// index 0 will contain integer part of the function
        /// index 1 will contain module object
        /// </summary>
        /// <param name="fileModule"></param>
        /// <returns></returns>
        public ArrayList Step0CheckLogic(string fileName, string parentPath)
        {
            CompositeModule compositeModule = new CompositeModule();
            ModuleInfo module = new ModuleInfo();
            bool IsCompositeModule = false;
            int ReturnValue = 0;
            try
            {
                if (!string.IsNullOrEmpty(fileName))//check for Empty entry
                {
                    if (IsVAlidZipContentType(fileName))//Check if valid Zip file submitted
                    {
                        string path = HttpContext.Current.Server.MapPath("~/");
                        string temPath = SageFrame.Common.RegisterModule.Common.TemporaryFolder + fileName.Substring(0, fileName.IndexOf("."));
                        string destPath = Path.Combine(path, temPath);
                        destPath = parentPath;

                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);

                        string filePath = destPath + "\\" + fileName;

                        string ExtractedPath = string.Empty;
                        ZipUtil.UnZipFiles(filePath, destPath, ref ExtractedPath, SageFrame.Common.RegisterModule.Common.Password, SageFrame.Common.RegisterModule.Common.RemoveZipFile);


                        if (!string.IsNullOrEmpty(ExtractedPath) && Directory.Exists(ExtractedPath))
                        {


                            string ManifestFile = checkFormanifestFile(ExtractedPath);

                            if (ManifestFile.Trim() != "")
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(ExtractedPath + '\\' + ManifestFile);
                                XmlElement root = doc.DocumentElement;
                                if (checkValidManifestFile(root))
                                {
                                    int logic = 2;

                                    if (IsMultipleModule(doc))
                                    {
                                        logic = Step1CheckLogic(ExtractedPath, doc);
                                        IsCompositeModule = true;
                                        if (logic == 1) PopulateCompositeModule(ExtractedPath, doc, ref compositeModule);
                                        compositeModule.TempFolderPath = ExtractedPath;
                                        compositeModule.ManifestFile = ManifestFile;
                                    }
                                    else
                                    {
                                        logic = Step1CheckLogic(module.TempFolderPath, module, doc);
                                        module.TempFolderPath = ExtractedPath;
                                        module.ManifestFile = ManifestFile;
                                    }

                                    switch (logic)
                                    {
                                        case 0://No manifest file
                                            DeleteTempDirectory(ExtractedPath);
                                            ReturnValue = 3;
                                            break;
                                        case -1://Invalid Manifest file
                                            DeleteTempDirectory(ExtractedPath);
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
                            }//end of  if (ManifestFile.Trim() 


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
            if (IsCompositeModule)
                arrColl.Add(compositeModule);
            else arrColl.Add(module);
            arrColl.Add(IsCompositeModule);

            return arrColl;
        }
        public bool checkValidManifestFile(XmlElement root, ModuleInfo module)
        {
            if (root.Name == "sageframe")//need to change the root node for valid manifest file at root node  
            {
                string PackageType = root.GetAttribute("type"); //root.NodeType
                module.PackageType = PackageType;
                switch (PackageType.ToLower())
                {
                    //need to check for many cases for like skin /..
                    case "module":
                        return true;
                }
            }
            return false;
        }


        public bool checkValidManifestFile(XmlElement root)
        {
            if (root.Name == "sageframe")//need to change the root node for valid manifest file at root node  
            {
                string PackageType = root.GetAttribute("type"); //root.NodeType
                // module.PackageType = PackageType;
                switch (PackageType.ToLower())
                {
                    //need to check for many cases for like skin /..
                    case "module":
                        return true;
                }
            }
            return false;
        }

        public bool IsModuleExist(string moduleName, ModuleInfo module)
        {
            ModuleController objProvider = new ModuleController();
            List<ModuleInfo> lstExistingModules = objProvider.GetAllExistingModule();
            bool exists = lstExistingModules.Exists(
                delegate(ModuleInfo obj)
                    {
                        bool returntype = false;
                        if (obj.ModuleName.ToLower() == moduleName.ToLower())
                        {
                            module.ModuleID = obj.ModuleID;
                            returntype = true;
                        }
                        return returntype;
                    }
                );
            return exists;
        }

        public bool IsModuleExist(string moduleName)
        {
            ModuleController objProvider = new ModuleController();
            List<ModuleInfo> lstExistingModules = objProvider.GetAllExistingModule();
            bool exists = lstExistingModules.Exists(
                delegate(ModuleInfo obj)
                    {
                        bool returntype = false;
                        if (obj.ModuleName.ToLower() == moduleName.ToLower())
                        {
                            returntype = true;
                        }
                        return returntype;
                    }
                );

            return exists;
        }

        public int Step1CheckLogic(string TempUnzippedPath, ModuleInfo module, XmlDocument doc)
        {
            XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");


            foreach (XmlNode xn in xnList)
            {
                module.ModuleName = xn["modulename"].InnerXml.ToString();
                module.FolderName = xn["foldername"].InnerXml.ToString();
                if (!String.IsNullOrEmpty(module.ModuleName) && IsModuleExist(module.ModuleName.ToLower()))
                {
                    /**********add code****************/

                    string path = HttpContext.Current.Server.MapPath("~/");
                    string targetPath = path + SageFrame.Common.RegisterModule.Common.ModuleFolder + '\\' + module.FolderName;
                    module.InstalledFolderPath = targetPath;
                    return 1;//Already exist
                }
                else
                {
                    return 2;//Not Exists
                }
            }

            return 0;
        }



        public int Step1CheckLogic(string TempUnzippedPath, XmlDocument doc)
        {
            XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");


            foreach (XmlNode xn in xnList)
            {
                string ModuleName = xn["name"].InnerXml.ToString();
                string FolderName = xn["foldername"].InnerXml.ToString();



                if (!String.IsNullOrEmpty(ModuleName) && IsModuleExist(FolderName.ToLower()))
                {
                    /**********add code****************/

                    string path = HttpContext.Current.Server.MapPath("~/");
                    string targetPath = path + SageFrame.Common.RegisterModule.Common.ModuleFolder + '\\' + FolderName;
                    //module.InstalledFolderPath = targetPath;
                    return 1;//Already exist
                }
                else
                {
                    return 2;//Not Exists
                }
            }

            return 0;
        }


        public void PopulateCompositeModule(string TempUnzippedPath, XmlDocument doc, ref CompositeModule compositeModule)
        {
            checkFormanifestFile(TempUnzippedPath);

            XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");

            foreach (XmlNode xn in xnList)
            {
                XmlNodeList xnModulesList = xn.SelectNodes("modules/module");

                foreach (XmlNode xmn in xnModulesList)
                {
                    Component component = new Component();
                    component.Name = xmn["name"].InnerXml.ToString();
                    component.Description = xmn["description"].InnerXml.ToString();
                    component.Version = xmn["version"].InnerXml.ToString();
                    component.ZipFile = xmn["ZipFile"].InnerXml.ToString();

                    compositeModule.Components.Add(component);
                }
            }

        }

        public string checkFormanifestFile(string TempUnzippedPath)
        {
            string ManifestFile = "";
            DirectoryInfo dir = new DirectoryInfo(TempUnzippedPath);
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                if (f.Extension.ToLower() == ".sfe")
                {
                    ManifestFile = f.Name;
                    return ManifestFile;
                }
                else
                {
                    ManifestFile = "";
                }
            }
            return ManifestFile;
        }


        public string checkFormanifestFile(string TempUnzippedPath, ModuleInfo module)
        {
            DirectoryInfo dir = new DirectoryInfo(TempUnzippedPath);
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                if (f.Extension.ToLower() == ".sfe")
                {
                    module.ManifestFile = f.Name;
                    return module.ManifestFile;
                }
                else
                {
                    module.ManifestFile = "";
                }
            }
            return module.ManifestFile;
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

        private int checkControlType(string _controlType)
        {
            int returnValue = 0;
            switch (_controlType)
            {
                case "View":
                    returnValue = (int)ControlType.View;
                    break;
                case "Edit":
                    returnValue = (int)ControlType.Edit;
                    break;
                case "Setting":
                    returnValue = (int)ControlType.Setting;
                    break;
                default:
                    returnValue = 0;
                    break;
            }
            return returnValue;
        }

        public void ModulesRollBack(int ModuleID, int PortalID)
        {
            try
            {
                SQLHandler objSQL = new SQLHandler();
                objSQL.ModulesRollBack(ModuleID, PortalID);
            }
            catch (Exception e)
            {
                ProcessException(e);
            }
        }

        public string ReadSQLFile(string TempUnzippedPath, string _sqlProvidername)
        {
            string Exceptions = string.Empty;
            try
            {
                StreamReader objReader = new StreamReader(TempUnzippedPath + '\\' + _sqlProvidername);
                string sLine = "";
                string scriptDetails = "";
                ArrayList arrText = new ArrayList();

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();
                foreach (string sOutput in arrText)
                {
                    scriptDetails += sOutput + "\r\n";
                }
                SQLHandler sqlHandler = new SQLHandler();
                Exceptions = sqlHandler.ExecuteScript(scriptDetails, true);
            }
            catch (Exception ex)
            {
                Exceptions += ex.Message.ToString();
            }
            return Exceptions;
        }
        public CompositeModule fillCompositeModuleInfo(CompositeModule Package)
        {



            XmlDocument doc = new XmlDocument();
            doc.Load(Package.TempFolderPath + '\\' + Package.ManifestFile);
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {
                XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");
                foreach (XmlNode xn in xnList)
                {
                    Package.Name = xn["name"].InnerXml.ToString();
                    Package.FolderName = xn["foldername"].InnerXml.ToString();
                    Package.Description = xn["description"].InnerXml.ToString();
                    Package.Version = xn["version"].InnerXml.ToString();
                    Package.Owner = xn["owner"].InnerXml.ToString();
                    Package.Organization = xn["organization"].InnerXml.ToString();
                    Package.URL = xn["url"].InnerXml.ToString();
                    Package.Email = xn["email"].InnerXml.ToString();
                    Package.ReleaseNotes = xn["releasenotes"].InnerXml.ToString();
                    Package.License = xn["license"].InnerXml.ToString();

                    XmlNodeList list = doc.SelectNodes("sageframe/folders/folder/modules/module");
                    foreach (XmlNode nod in list)
                    {
                        Component Component = new Component();

                        Component.Name = nod["name"].InnerXml.ToString();
                        Component.FriendlyName = nod["friendlyname"].InnerXml.ToString();
                        Component.Description = nod["description"].InnerXml.ToString();
                        Component.Version = nod["version"].InnerXml.ToString();
                        Component.BusinesscontrollerClass = nod["businesscontrollerclass"].InnerXml.ToString();
                        Component.ZipFile = nod["ZipFile"].InnerXml.ToString();


                        Package.Components.Add(Component);
                    }

                }
            }
            return Package;
        }
        public ModuleInfo fillModuleInfo(ModuleInfo module)
        {
            if (!string.IsNullOrEmpty(module.ManifestFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(module.TempFolderPath + '\\' + module.ManifestFile);
                XmlElement root = doc.DocumentElement;
                if (!String.IsNullOrEmpty(root.ToString()))
                {
                    XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");
                    foreach (XmlNode xn in xnList)
                    {
                        module.ModuleName = xn["modulename"].InnerXml.ToString();
                        module.Name = xn["name"].InnerXml.ToString();
                        module.FriendlyName = xn["friendlyname"].InnerXml.ToString();
                        module.Description = xn["description"].InnerXml.ToString();
                        module.Version = xn["version"].InnerXml.ToString();
                        module.BusinessControllerClass = xn["businesscontrollerclass"].InnerXml.ToString();
                        module.FolderName = xn["foldername"].InnerXml.ToString();
                        module.CompatibleVersions = xn["compatibleversions"].InnerXml.ToString();
                        module.Owner = xn["owner"].InnerXml.ToString();
                        module.Organization = xn["organization"].InnerXml.ToString();
                        module.URL = xn["url"].InnerXml.ToString();
                        module.Email = xn["email"].InnerXml.ToString();
                        module.ReleaseNotes = xn["releasenotes"].InnerXml.ToString();
                        module.License = xn["license"].InnerXml.ToString();
                        module.PackageType = "Module";
                    }
                }
                return module;
            }
            return null;
        }



        public bool IsMultipleModule(XmlDocument xmlDocument)
        {
            bool flag = false;
            XmlNodeList list = xmlDocument.SelectNodes("sageframe/folders/folder/modules/module");

            if (list.Count > 1) flag = true;

            return flag;
        }


        public void InstallPackageCore(ModuleInfo module, XmlDocument doc, ref  ArrayList dllFiles, ref  string _unistallScriptFile)
        {
            #region "Module Creation Logic"

            // add into module table
            int[] outputValue;
            ModuleController objProvider = new ModuleController();
            outputValue = objProvider.AddModules(module, false, 0, true, DateTime.Now, GetPortalID, GetUsername);
            module.ModuleID = outputValue[0];
            module.ModuleDefID = outputValue[1];
            _newModuleID = module.ModuleID;
            _newModuleDefID = module.ModuleDefID;


            //insert into ProtalModule table
            _newPortalmoduleID = objProvider.AddPortalModules(GetPortalID, _newModuleID, true, DateTime.Now, GetUsername);

            //install permission for the installed module in ModuleDefPermission table with ModuleDefID and PermissionID
            try
            {
                // get the default module VIEW permissions
                int _permissionIDView = objProvider.GetPermissionByCodeAndKey("SYSTEM_VIEW", "VIEW");

                //insert into module permissions i.e., ModuleDefPermission and PortalModulePermission
                objProvider.AddModulePermission(_newModuleDefID, _permissionIDView, GetPortalID, _newPortalmoduleID, true, GetUsername, true, DateTime.Now, GetUsername);

                // get the default module EDIT permissions
                int _permissionIDEdit = objProvider.GetPermissionByCodeAndKey("SYSTEM_EDIT", "EDIT");

                //insert into module permissions i.e., ModuleDefPermission and PortalModulePermission
                objProvider.AddModulePermission(_newModuleDefID, _permissionIDEdit, GetPortalID, _newPortalmoduleID, true, GetUsername, true, DateTime.Now, GetUsername);
            }
            catch (Exception ex)
            {
                Exceptions += ex.Message;
                return;
            }

            XmlNodeList xnList2 = doc.SelectNodes("sageframe/folders/folder/modules/module/controls/control");
            foreach (XmlNode xn2 in xnList2)
            {
                string _moduleControlKey = null;
                if (xn2["key"] != null)
                {
                    _moduleControlKey = xn2["key"].InnerXml;// exists
                }
                string _moduleControlTitle = xn2["title"].InnerXml;
                string _moduleControlSrc = xn2["src"].InnerXml;
                string _controlType = xn2["type"].InnerXml;
                string _moduleControlHelpUrl = xn2["helpurl"].InnerXml;
                bool _moduleSupportsPartialRendering = false;
                if (xn2["supportspartialrendering"] != null)
                {
                    string _moduleControlSupportsPartialRendering = xn2["supportspartialrendering"].InnerXml;

                    if (_moduleControlSupportsPartialRendering == "true")
                    {
                        _moduleSupportsPartialRendering = true;
                    }
                }
                int controlType = 0;
                controlType = checkControlType(_controlType);
                string IconFile = "";

                //add into module control table
                objProvider.AddModuleCoontrols(_newModuleDefID, _moduleControlKey, _moduleControlTitle, _moduleControlSrc,
                                           IconFile, controlType, 0, _moduleControlHelpUrl, _moduleSupportsPartialRendering, true, DateTime.Now,
                                           GetPortalID, GetUsername);
            }
            XmlNodeList xnList3 = doc.SelectNodes("sageframe/folders/folder/files/file");
            if (xnList3.Count != 0)
            {
                #region CheckValidDataSqlProvider
                string moduleFile = GetSqlDataProviderFile(module.TempFolderPath);
                if (moduleFile.Trim().Length < 2)
                    moduleFile = module.Version;

               
                #endregion

                bool orderSpecified = (from XmlNode xn3 in xnList3 select xn3.Attributes["order"]).Select(order => order != null).FirstOrDefault();

                if (orderSpecified)
                {

                    var sortedItems = xnList3.OfType<XmlElement>()
                        .OrderBy(item => int.Parse(item.GetAttribute("order")));

                    foreach (var item in sortedItems)
                    {
                        string _fileName = item["name"].InnerXml;

                        try
                        {
                            #region ReadSqlProviderfile

                            if (!String.IsNullOrEmpty(moduleFile) && !_fileName.Contains("Uninstall.SqlDataProvider") && _fileName.Contains(".SqlDataProvider"))
                            {
                                Exceptions = ReadSQLFile(module.TempFolderPath, _fileName);
                            }

                            #endregion

                            #region CheckAlldllFiles

                            if (!String.IsNullOrEmpty(_fileName) && _fileName.Contains(".dll"))
                            {
                                dllFiles.Add(_fileName);
                            }

                            #endregion

                            #region ReadUninstall SQL FileName

                            if (!String.IsNullOrEmpty(_fileName) && _fileName.Contains("Uninstall.SqlDataProvider"))
                            {
                                _unistallScriptFile = _fileName;
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            Exceptions += ex.Message;
                            break;
                        }
                    }

                }
                else
                {


                    foreach (XmlNode xn3 in xnList3)
                    {


                        string _fileName = xn3["name"].InnerXml;



                        try
                        {
                            #region ReadSqlProviderfile

                            if (!String.IsNullOrEmpty(moduleFile) && !_fileName.Contains("Uninstall.SqlDataProvider") && _fileName.Contains(".SqlDataProvider"))
                            {
                                Exceptions = ReadSQLFile(module.TempFolderPath, moduleFile + ".SqlDataProvider");
                            }

                            #endregion

                            #region CheckAlldllFiles

                            if (!String.IsNullOrEmpty(_fileName) && _fileName.Contains(".dll"))
                            {
                                dllFiles.Add(_fileName);
                            }

                            #endregion

                            #region ReadUninstall SQL FileName

                            if (!String.IsNullOrEmpty(_fileName) && _fileName.Contains("Uninstall.SqlDataProvider"))
                            {
                                _unistallScriptFile = _fileName;
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            Exceptions += ex.Message;
                            break;
                        }
                    }
                }
            }
            XmlNodeList xnList4 = doc.SelectNodes("sageframe/folders/folder/templates/template");
             if (xnList4 != null && xnList4.Count != 0)
             {
                  foreach (XmlNode xn4 in xnList4)
                  {
                       string _templateName = xn4["name"].InnerXml;
                      #region Read Template file
                       if (!String.IsNullOrEmpty(_templateName))
                      {
                          string templateName = _templateName;
                          AddTemplateZip(templateName, module.TempFolderPath);
                      }
                      #endregion
                  }

             }
             XmlNodeList directrylist = doc.SelectNodes("sageframe/folders/folder/move/directories/directory");

             if (directrylist != null && directrylist.Count != 0)
             {
                 foreach (XmlNode directory in directrylist)
                 {
                   
                     if (directory["from"] != null && directory["to"]!=null)
                     {
                         string fromdirectory = module.TempFolderPath + "\\" + directory["from"].InnerXml;
                         string todirectory = HttpContext.Current.Server.MapPath(@"~/" + directory["to"].InnerXml);
                         MoveDirectory(fromdirectory, todirectory);

                     }
                    
                 }
             }

             XmlNodeList fileList = doc.SelectNodes("sageframe/folders/folder/move/files/file");

             if (fileList != null && fileList.Count != 0)
             {
                 foreach (XmlNode file in fileList)
                 {

                     if (file["to"] != null && file["name"]!=null)
                     {
                         string fileName = file["name"] != null ? file["name"].InnerXml : "";
                         string fromLocation = module.TempFolderPath + "\\" + file["from"].InnerXml;
                         string toLocation = HttpContext.Current.Server.MapPath(@"~/" + file["to"].InnerXml);
                         MoveFile(fileName, fromLocation, toLocation);
                     }

                 }
             }

            if (Exceptions != string.Empty)
            {
                if (module.ModuleID.ToString() != null && module.ModuleID > 0 && _newModuleDefID != null && _newModuleDefID > 0)
                {
                    //Run unstallScript
                    if (_unistallScriptFile != "")
                    {
                        Exceptions = ReadSQLFile(module.TempFolderPath, _unistallScriptFile);
                    }
                    //Delete Module info from data base
                    ModulesRollBack(module.ModuleID, GetPortalID);
                    module.ModuleID = -1;
                }
            }
            #endregion

        }

        public void AddTemplateZip(string templateName, string tempPath)
        {
            string templateFolder = Path.Combine(tempPath, templateName);
            string path = HttpContext.Current.Server.MapPath("~/");

            string templateFolderPath = path + "Templates\\" + templateName;
            CopyDirectory(templateFolder, templateFolderPath);
            //Directory.Delete(templateFolder);
            DeleteTempDirectory(templateFolder);
        }


        public string GetSqlDataProviderFile(string path)
        {
            string file = "";
            string[] files = Directory.GetFiles(path, "*.SqlDataProvider", SearchOption.TopDirectoryOnly);

            List<KeyValuePair<string, int>> fileNames = new List<KeyValuePair<string, int>>();
            foreach (string fileName in files)
            {
                string fName = fileName.Substring(fileName.LastIndexOf("\\") + 1).Replace(".SqlDataProvider", "");

                string str = fName.Replace(".", "");

                try
                {   int num =0;
                bool isNumeric = int.TryParse(str, out num);



                if (isNumeric && num > 0)
                        fileNames.Add(new KeyValuePair<string, int>(fName, Convert.ToInt32(num)));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            if (fileNames.Count > 0)
            {
                KeyValuePair<string, int> val =
                    fileNames.Where(x => x.Value == fileNames.Max(y => y.Value)).SingleOrDefault();
                file = val.Key;
            }
            return file;

        }

        public void InstallPackage(ModuleInfo module)
        {
            XmlDocument doc = new XmlDocument();
            ArrayList dllFiles = new ArrayList();
            string _unistallScriptFile = string.Empty;
            doc.Load(module.TempFolderPath + '\\' + module.ManifestFile);
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {


                XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");


                foreach (XmlNode xn in xnList)
                {
                    #region Module Exist check
                    try
                    {// "Module Creation Logic"
                        InstallPackageCore(module, doc, ref dllFiles, ref _unistallScriptFile);

                    }
                    catch
                    {
                        if (module.ModuleID.ToString() != null && module.ModuleID > 0 && _newModuleDefID != null && _newModuleDefID > 0)
                        {
                            //Run unstallScript
                            if (_unistallScriptFile != "")
                            {
                                Exceptions = ReadSQLFile(module.TempFolderPath, _unistallScriptFile);
                            }
                            //Delete Module info from data base
                            ModulesRollBack(module.ModuleID, GetPortalID);
                            module.ModuleID = -1;
                        }
                    }
                    #endregion
                }
            }

            if (module.ModuleID.ToString() != null && module.ModuleID > 0 && Exceptions == string.Empty)
            {
                string path = HttpContext.Current.Server.MapPath("~/");
                string targetPath = path + SageFrame.Common.RegisterModule.Common.ModuleFolder + '\\' + module.FolderName;
                CopyDirectory(module.TempFolderPath, targetPath);
                for (int i = 0; i < dllFiles.Count; i++)
                {
                    string sourcedllFile = module.TempFolderPath + '\\' + dllFiles[i].ToString();
                    string targetdllPath = path + SageFrame.Common.RegisterModule.Common.DLLTargetPath + '\\' + dllFiles[i].ToString();
                    File.Copy(sourcedllFile, targetdllPath, true);
                    //File.Move();
                }
            }
            // check IModuleExtraCodeExecute interface is implemented or not for insallation of module
            if (IsIModuleExtraCodeInterfaceImplemented(doc))
            {
                ExtraCodeOnInstallation(doc, module.TempFolderPath);
            }

            //-----------------------------------//
            RemoveFromAvailableResources(module.ModuleName + ".zip");
            //------------------------------------------//
            DeleteTempDirectory(module.TempFolderPath);

        }

        private void MoveDirectory(string sourceDirectory, string destination)
        {
            if (Directory.Exists(sourceDirectory))
            {
                if (Directory.Exists(destination))
                {
                    CopyDirectory(sourceDirectory, destination);
                }
                else
                {
                    Directory.CreateDirectory(destination);
                    CopyDirectory(sourceDirectory, destination);
                }
            }
        }

        private void MoveFile(string filename, string sourceDirectory, string destination)
        {
            if (Directory.Exists(sourceDirectory))
            {
                string filePath = Path.Combine(sourceDirectory, filename.Trim());
                string destfilePath = Path.Combine(destination, filename.Trim());
                if (File.Exists(filePath))
                {
                    //if (File.Exists(destfilePath))
                    //{   //OverWrite file
                    File.Copy(filePath, destfilePath, true);
                    File.Delete(filePath);
                    //}
                }
            }
        }

        public void CopyDirectory(string SourceDirectory, string DestinationDirectory)
        {
            if (Directory.Exists(SourceDirectory))
            {
                string[] files = Directory.GetFiles(SourceDirectory);
                if (!Directory.Exists(DestinationDirectory))
                {
                    Directory.CreateDirectory(DestinationDirectory);
                }
                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(DestinationDirectory, ParseFileNameWithoutPath(fileName));
                    File.Copy(s, destFile, true);
                }
                string[] directories = Directory.GetDirectories(SourceDirectory);
                foreach (string d in directories)
                {
                    char splitter = '\\';
                    string[] directory = d.Split(splitter);
                    string directoryName = directory[directory.Length - 1];
                    string destDirectory = Path.Combine(DestinationDirectory, directoryName);
                    CopyDirectory(d, destDirectory);
                }
            }
        }

        private string ParseFileNameWithoutPath(string path)
        {
            if (path != null && path != string.Empty)
            {
                char seperator = '\\';
                string[] file = path.Split(seperator);
                return file[file.Length - 1];
            }
            return string.Empty;
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

        //--------------------------------------------------------//
        protected void RemoveFromAvailableResources(string filename)
        {
            string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources");
            string FilePath = Path.Combine(path, filename);
            if (File.Exists(FilePath))
            {
                DeleteModuleZipfile(FilePath);
                RemoveAvailableModule(filename);
            }

        }

        public void AddAvailableModules(string TempFolderpath, Component Component)
        {
            string DestinationPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources");
            string SourcePath = Path.Combine(TempFolderpath, Component.ZipFile);

            int result = CopyModuleZipFiles(SourcePath, DestinationPath);
            if (result == 1)
            {
                AddToAvailableModule(Component);
            }

        }
        protected void AddToAvailableModule(Component Component)
        {
            try
            {
                string sp = "usp_AvailableModulesAdd";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@FriendlyName", Component.FriendlyName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Description", Component.Description));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Version", Component.Version));
                ParamCollInput.Add(new KeyValuePair<string, object>("@BusinesscontrollerClass", Component.BusinesscontrollerClass));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FolderName", Component.ZipFile));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleName", Component.Name));

                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", true));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsDeleted", false));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsModified", false));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", GetUsername));

                SQLH.ExecuteNonQuery(sp, ParamCollInput);


            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected void AddToAvailableModule(Component Component)
        //{
        //    try
        //    {

        //        db.usp_AvailableModulesAdd(Component.FriendlyName, Component.Description, Component.Version, Component.BusinesscontrollerClass, Component.ZipFile, Component.Name, true, false, false, GetPortalID, GetUsername);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //protected void RemoveAvailableModule(string filename)
        //{
        //    try
        //    {
        //        db.usp_AvailableModulesUpdate(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        protected void RemoveAvailableModule(string filename)
        {
            try
            {
                string sp = "usp_AvailableModulesUpdate";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@FileName", filename));
                SQLH.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int CopyModuleZipFiles(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    string fileName = Path.GetFileName(sourcePath);
                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    if (!File.Exists(destinationPath + "\\" + fileName))
                    {
                        File.Copy(sourcePath, destinationPath + "\\" + fileName, true);
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;

            }
        }

        public void DeleteModuleZipfile(string Path)
        {
            try
            {
                if (!string.IsNullOrEmpty(Path))
                {
                    if (File.Exists(Path))
                        File.Delete(Path);
                }
            }
            catch (IOException ex)
            {
                throw ex;//cant delete folder
            }
        }

        public List<ModuleInfo> GetAvailableModulesList(int PortalID)
        {
            try
            {
                List<ModuleInfo> lstModule = new List<ModuleInfo>();
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                lstModule = sqlH.ExecuteAsList<ModuleInfo>("usp_AvailableModulesGet", ParaMeterCollection);
                return lstModule;

            }

            catch (Exception)
            {
                return null;
            }

        }

        //-----------------------------------------------------------//

        #region Extra Code Execution on Insallation & UnInstallation of Module
        /// <summary>
        /// function GetAssemblyNameWithIClass(doc); return list with two value
        /// index 0 consist the AssemblyName
        /// index 1 consist the Interface implemented Class Name for Install and Unstall of module
        /// </summary>
        /// <param name="doc"></param>
        public void ExtraCodeOnInstallation(XmlDocument doc, string tempFolderPath)
        {
            try
            {
                List<string> assemblyClassIName = GetAssemblyNameWithIClass(doc);
                AppDomain.CurrentDomain.Load(assemblyClassIName[0]);
                foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                {
                    string assName = ass.GetName().Name.ToString();
                    if (assName == assemblyClassIName[0])
                    {
                        Type type = ass.GetType(assemblyClassIName[0] + "." + assemblyClassIName[1], false);
                        IModuleExtraCodeExecute imece = (IModuleExtraCodeExecute)Activator.CreateInstance(type);

                        imece.ExecuteOnInstallation(doc, tempFolderPath);
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public void ExtraCodeOnUnInstallation(XmlDocument doc)
        {
            try
            {
                List<string> assemblyClassIName = GetAssemblyNameWithIClass(doc);
                foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                {
                    string assName = ass.GetName().Name.ToString();
                    if (assName == assemblyClassIName[0])
                    {
                        Type type = ass.GetType(assemblyClassIName[0] + "." + assemblyClassIName[1], false);
                        IModuleExtraCodeExecute imece = (IModuleExtraCodeExecute)Activator.CreateInstance(type);
                        imece.ExecuteOnUnInstallation(doc);
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        /// <summary>
        ///Function GetAssemblyNameWithIClass(XmlDocument doc) checks for "interfaceimplementedclass" node in sfe
        /// "interfaceimplementedclass" node consists assembly name and IModuleExtraCodeExecute interface implemented class name with comma seperated like
        ///  <interfaceimplementedclass>AssemblyName,IModuleExtraCodeExecuteImplemented</interfaceimplementedclass>
        ///  function returns list with two values, AssemblyName at index 0 and IModuleExtraCodeExecute interface implemented class name at in index 1
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<string> GetAssemblyNameWithIClass(XmlDocument doc)
        {
            XmlNodeList xnInterfaceImplement = doc.SelectNodes("sageframe/folders/folder/interfaceimplementedclass");
            string[] assemblyValue = new string[] { };
            if (xnInterfaceImplement != null && xnInterfaceImplement.Count != 0)
            {
                char[] commaSeparator = new char[] { ',' };
                foreach (XmlNode interFaceCode in xnInterfaceImplement)
                {
                    assemblyValue = interFaceCode.InnerText.Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            return new List<string> { assemblyValue[0], assemblyValue[1] };
        }

        public bool IsIModuleExtraCodeInterfaceImplemented(XmlDocument doc)
        {
            XmlNodeList xnListModule = doc.SelectNodes("sageframe/folders/folder/interfaceimplementedclass");
            if (xnListModule != null && xnListModule.Count != 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}