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
using SageFrame.SageFrameClass.Services;
using System.Collections;
using SageFrame.Web.Utilities;
using SageFrame.Web;
using System.Xml;
using RegisterModule;
using System.IO;
using System.Web.Hosting;

namespace SageFrame.DesktopModules.Admin.Extensions
{
    public partial class Modules_Admin_Extensions_ctl_AvailableModules : BaseAdministrationUserControl
    {
        List<ModuleInfo> lstAvailableModules ;
        Installers installhelp = new Installers();
        ModuleInfo module = new ModuleInfo();

        string Exceptions = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lstAvailableModules = new List<ModuleInfo>();
                    Bindgrid();
                }
               
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void AddImageUrls()
        {
            wizInstall.CancelButtonImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            wizInstall.StartNextButtonImageUrl = GetTemplateImageUrl("imgforward.png", true);
            wizInstall.StepNextButtonImageUrl = GetTemplateImageUrl("imgforward.png", true);
            wizInstall.StepPreviousButtonImageUrl = GetTemplateImageUrl("imgback.png", true);
            wizInstall.FinishPreviousButtonImageUrl = GetTemplateImageUrl("imgback.png", true);
            wizInstall.FinishCompleteButtonImageUrl = GetTemplateImageUrl("imgfinished.png", true);
        }

        protected void Bindgrid()
        {
            wizInstall.ActiveStepIndex = 0;
            lstAvailableModules = installhelp.GetAvailableModulesList(GetPortalID);
            ViewState["AvailableModuleList"] = lstAvailableModules;

            if (lstAvailableModules != null && lstAvailableModules.Count > 0)
            {
                gdvModule.DataSource = lstAvailableModules;
                gdvModule.DataBind();
                gdvModule.Visible = true;
                lblWarningMessage.Visible = false;
            }
            else
            {   
                lblWarningMessage.Visible = true;
                gdvModule.Visible = false;
                lblWarningMessage.Text = "There are no any modules available now"; 
               //wizInstall.StartNextButtonStyle.CssClass="hidden";

                Button btnNext = (Button)wizInstall.FindControl("StartNavigationTemplateContainerID").FindControl("StartNextButton");
                btnNext.Visible = false;
                
                
            }       
        }


        protected void wizInstall_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                //System.Threading.Thread.Sleep(9000);
                int activeIndex = 0;
                 
                
                switch (e.CurrentStepIndex)
                {
                                    
                    case 0:
                        Panel pnl = (Panel)this.Step2.FindControl("pnlPackage");
                        GridView grd = (GridView)pnl.FindControl("gdvModule");
                        List<ModuleInfo> FinalModules = new List<ModuleInfo>();
                        foreach (GridViewRow row in grd.Rows)
                        {
                            CheckBox cbInstall = (CheckBox)row.FindControl("cbInstall");
                            if (cbInstall.Checked == true)
                            {
                                Label lbl = (Label)row.FindControl("lblname");

                                lstAvailableModules = (List<ModuleInfo>)ViewState["AvailableModuleList"];
                                
                                    //this.lblLicense.Text = compositeModule.License.ToString();
                                    //this.lblReleaseNotesD.Text = compositeModule.ReleaseNotes.ToString();
                                    foreach (ModuleInfo Module in lstAvailableModules)
                                    {
                                        if (Module.Name.Equals(lbl.Text))
                                        {

                                                FinalModules.Add(Module);
                                            
                                            break;
                                        }
                                    }
                                    ViewState["FinalModuleList"] = FinalModules;
                            }
                           
                        }
                        if (FinalModules.Count > 1)
                        {
                            activeIndex = 2;
                            this.lblLicense.Visible = false;
                        }
                        else if(FinalModules.Count==1) 
                        {
                            ModuleInfo Module = (ModuleInfo)FinalModules[0];
                            string SourcePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources");
                            string filename = Path.Combine(SourcePath, Module.FolderName);

                            string path = HttpContext.Current.Server.MapPath("~/");
                            string temPath = SageFrame.Core.RegisterModule.Common.TemporaryFolder;
                            string destPath = Path.Combine(path, temPath);

                            Module.TempFolderPath = destPath;
                            installhelp.CopyModuleZipFiles(filename, destPath);

                            ArrayList list = installhelp.Step0CheckLogic(Module.FolderName, Module.TempFolderPath);
                            Module = (ModuleInfo)list[1];

                            installhelp.fillModuleInfo(Module);

                            this.lblReleaseNotesD.Text = Module.ReleaseNotes;
                            this.lblLicenseD.Text = Module.License;
                            FinalModules = new List<ModuleInfo>();
                            FinalModules.Add(Module);
                            ViewState["FinalModuleList"] = FinalModules;
                            activeIndex = 1;
                        }

                        break;
                    case 1:
                        activeIndex = 2;
                        break;
                    case 2 ://Accept Terms
                        if (chkAcceptLicense.Checked)
                        {                            
                                ModuleInfo moduleInfo = null;
                                lstAvailableModules = (List<ModuleInfo>)ViewState["FinalModuleList"];
                              
                                bool confirmationFlag = true;
                           
                                foreach (ModuleInfo Module in lstAvailableModules)
                                {
                                    if (lstAvailableModules.Count > 1)
                                    {
                                        string SourcePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Resources");
                                        string filename = Path.Combine(SourcePath, Module.FolderName);

                                        string path = HttpContext.Current.Server.MapPath("~/");
                                        string temPath = SageFrame.Core.RegisterModule.Common.TemporaryFolder;
                                        string destPath = Path.Combine(path, temPath);



                                        Module.TempFolderPath = destPath;
                                        installhelp.CopyModuleZipFiles(filename, destPath);

                                        ArrayList list = installhelp.Step0CheckLogic(Module.FolderName, Module.TempFolderPath);
                                        moduleInfo = (ModuleInfo)list[1];

                                        installhelp.fillModuleInfo(moduleInfo);
                                    }
                                    else if (lstAvailableModules.Count == 1)
                                    {
                                        moduleInfo = (ModuleInfo)Module;
                                    }

                                        installhelp.InstallPackage(moduleInfo);

                                        if (moduleInfo.ModuleID < 0)
                                        {
                                            confirmationFlag = false;
                                            InstallConfirmation(moduleInfo, ref activeIndex);
                                            break;
                                        } 
                                


                                if (confirmationFlag && moduleInfo != null)
                                {
                                    InstallConfirmation(moduleInfo, ref activeIndex);
                                }
                            }
                            

                        }
                            

                        else
                        {
                            lblAcceptMessage.Text = GetSageMessage("Extensions_Editors", "AcceptThePackageLicenseAgreementFirst");
                            e.Cancel = true;
                            activeIndex = 2;
                           
                        }
                        break;
                    case 3:
                        Bindgrid();
                        activeIndex = 0;
                        ViewState["FinalModuleList"] = null;
                        ViewState["AvailableModuleList"] = null;
                        break;
                        
                }
                wizInstall.ActiveStepIndex = activeIndex;

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }


        public void InstallConfirmation(ModuleInfo module, ref int activeIndex)
        {

            if (module.ModuleID <= 0)
            {
                // lblLoadMessage.Text = GetSageMessage("Extensions_Editors", "ThereIsErrorWhileInstalling");
                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ErrorWhileInstalling"), "", SageMessageType.Error);
                //lblLoadMessage.Visible = true;
                chkAcceptLicense.Checked = false;
                ViewState["ModuleInfo"] = null;
                activeIndex = 0;
            }
            else
            {
                lblInstallMessage.Text = GetSageMessage("Extensions_Editors", "ModuleInstalledSuccessfully");
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("Extensions_Editors", "TheModuleIsInstalledSuccessfully"), "", SageMessageType.Success);
                wizInstall.DisplayCancelButton = false;
                activeIndex = 3;
            }
        }


        protected void wizInstall_ActiveStepChanged(object sender, EventArgs e)
        {
            switch (wizInstall.ActiveStepIndex)
            {
                case 1:
                    lblWarningMessage.Text = GetSageMessage("Extensions_Editors", "WarningMessageWillDeleteAllFiles");
                    //chkRepairInstall.Checked = true;
                    break;
                
            }
        }

        private Button GetWizardButton(string containerID, string buttonID)
        {
            Control navContainer = wizInstall.FindControl(containerID);
            Button button = null;
            if ((navContainer != null))
            {
                button = navContainer.FindControl(buttonID) as Button;
            }
            return button;
        }
        #region Uninstall Existing Module

        private void UninstallModule(ModuleInfo moduleInfo, bool deleteModuleFolder)
        {
            Installers installerClass = new Installers();
            string path = HttpContext.Current.Server.MapPath("~/");

            //checked if directory exist for current module foldername
            string moduleFolderPath = moduleInfo.InstalledFolderPath;
            if (!string.IsNullOrEmpty(moduleFolderPath))
            {
                if (Directory.Exists(moduleFolderPath))
                {
                    //check for valid .sfe file exist or not
                    if (installerClass.checkFormanifestFile(moduleFolderPath, moduleInfo) != "")
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(moduleFolderPath + '\\' + moduleInfo.ManifestFile);
                        XmlElement root = doc.DocumentElement;
                        if (installerClass.checkValidManifestFile(root, moduleInfo))
                        {
                            XmlNodeList xnList = doc.SelectNodes("sageframe/folders/folder");
                            foreach (XmlNode xn in xnList)
                            {
                                moduleInfo.ModuleName = xn["modulename"].InnerXml.ToString();
                                moduleInfo.FolderName = xn["foldername"].InnerXml.ToString();

                                if (!String.IsNullOrEmpty(moduleInfo.ModuleName) && !String.IsNullOrEmpty(moduleInfo.FolderName) && installerClass.IsModuleExist(moduleInfo.ModuleName.ToLower(), moduleInfo))
                                {

                                }
                                else
                                {
                                    ShowMessage(SageMessageTitle.Exception.ToString(), GetSageMessage("Extensions_Editors", "ThisModuleSeemsToBeCorrupted"), "", SageMessageType.Error);
                                }
                            }
                            try
                            {
                                if (moduleInfo.ModuleID > 0)
                                {
                                    //Run script  
                                    ReadUninstallScriptAndDLLFiles(doc, moduleFolderPath, installerClass);
                                    //Rollback moduleid
                                    installerClass.ModulesRollBack(moduleInfo.ModuleID, GetPortalID);
                                    if (deleteModuleFolder == true)
                                    {
                                        //Delete Module's Folder
                                        installerClass.DeleteTempDirectory(moduleInfo.InstalledFolderPath);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Exceptions = ex.Message;
                            }

                            if (Exceptions != string.Empty)
                            {
                                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ModuleExtensionIsUninstallError"), "", SageMessageType.Alert);
                            }
                            else
                            {
                                string ExtensionMessage = GetSageMessage("Extensions_Editors", "ModuleExtensionIsUninstalledSuccessfully");
                                //UninstallProcessCancelRequestBase(Request.RawUrl, true, ExtensionMessage);
                            }
                        }
                        else
                        {
                            ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ThisPackageIsNotValid"), "", SageMessageType.Alert);
                        }
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ThisPackageDoesNotAppearToBeValid"), "", SageMessageType.Alert);
                    }
                }
                else
                {
                    ShowMessage(SageMessageTitle.Exception.ToString(), GetSageMessage("Extensions_Editors", "ModuleFolderDoesnotExist"), "", SageMessageType.Error);
                }
            }
        }

        private void ReadUninstallScriptAndDLLFiles(XmlDocument doc, string moduleFolderPath, Installers installerClass)
        {
            XmlElement root = doc.DocumentElement;
            if (!String.IsNullOrEmpty(root.ToString()))
            {
                ArrayList dllFiles = new ArrayList();
                string _unistallScriptFile = string.Empty;
                XmlNodeList xnFileList = doc.SelectNodes("sageframe/folders/folder/files/file");
                if (xnFileList.Count != 0)
                {
                    foreach (XmlNode xn in xnFileList)
                    {
                        string _fileName = xn["name"].InnerXml;
                        try
                        {
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
                            Exceptions = ex.Message;
                        }
                    }
                    if (_unistallScriptFile != "")
                    {
                        RunUninstallScript(_unistallScriptFile, moduleFolderPath, installerClass);
                    }
                    DeleteAllDllsFromBin(dllFiles, moduleFolderPath);
                }
            }
        }

        private void RunUninstallScript(string _unistallScriptFile, string moduleFolderPath, Installers installerClass)
        {
            Exceptions = installerClass.ReadSQLFile(moduleFolderPath, _unistallScriptFile);
        }

        private void DeleteAllDllsFromBin(ArrayList dllFiles, string moduleFolderPath)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/");

                foreach (string dll in dllFiles)
                {
                    string targetdllPath = path + SageFrame.Core.RegisterModule.Common.DLLTargetPath + '\\' + dll;
                    FileInfo imgInfo = new FileInfo(targetdllPath);
                    if (imgInfo != null)
                    {
                        imgInfo.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions = ex.Message;
            }
        }

        #endregion

        //private void BindPackage()
        //{

            
        //    else if (ViewState["ModuleInfo"] != null)
        //    {
        //        ModuleInfo moduleInfo = installhelp.fillModuleInfo(module);
        //        ViewState["ModuleInfo"] = moduleInfo;
        //        gdvModule.DataSource = moduleInfo;
        //        gdvModule.DataBind();
        //    }

        //}


        protected void wizInstall_CancelButtonClick(object sender, EventArgs e)
        {
            try
            {
                lstAvailableModules = (List<ModuleInfo>)ViewState["FinalModuleList"];
                if (lstAvailableModules != null)
                {
                    foreach (ModuleInfo module in lstAvailableModules)
                    {
                        if (module != null)
                        {
                            installhelp.DeleteTempDirectory(module.TempFolderPath+"\\"+module.FolderName);

                        }
                    }
                }

                ViewState["FinalModuleList"] = null;
                ViewState["AvailableModuleList"] = null;
                ReturnBack();

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void wizInstall_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                lstAvailableModules = (List<ModuleInfo>)ViewState["FinalModuleList"];
                if (lstAvailableModules != null)
                {
                    foreach (ModuleInfo module in lstAvailableModules)
                    {
                        if (module != null)
                        {
                            installhelp.DeleteTempDirectory(module.TempFolderPath + "\\" + module.ModuleName);

                        }
                    }
                }
                             
                ViewState["FinalModuleList"] = null;
                ViewState["AvailableModuleList"] = null;
                ReturnBack();

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void ReturnBack()
        {
            ProcessCancelRequest(Request.RawUrl);
        }
    }
}







