using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using System.Web.Hosting;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web.Script.Services;
using System.Web.Services;
namespace SageFrame.Modules.Admin.Extensions.Editors
{
    [ScriptService]
    public partial class PackageCreator : BaseAdministrationUserControl
    {
        private void InitializeJS()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "GlobalVariable1", " var CancelURL='" + ResolveUrl("~/") + "Admin/Modules" + SageFrameSettingKeys.PageExtension + "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "GlobalVariable2", " var sageRootPah='" + ResolveUrl("~/") + "';", true);
            Page.ClientScript.RegisterClientScriptInclude("Validater1", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "Script/json2.js"));
            Page.ClientScript.RegisterClientScriptInclude("Validater3", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "Script/jquery.validate.js"));
            Page.ClientScript.RegisterClientScriptInclude("AjaxUploader1", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "Script/ajaxupload.js"));
            Page.ClientScript.RegisterClientScriptInclude("SageFrameTreeView", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "Script/jqueryFileTree.js"));

            string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "FileManagerGlobalVariable1234", " var FileManagerPath123='" + ResolveUrl(modulePath) + "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "FileMangerUserModuleID", " var FileMangerUserModuleID='" + SageUserModuleID + "';", true);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeJS();
            IncludeCss("treeView", "/Modules/Admin/Extensions/Editors/Css/jqueryFileTree.css");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDropDown();
                    BindAssemblyDropDown();
                    this.tmpFoldName.Value = String.Format("{0}", DateTime.Now.ToString("dd-MMM-yyyy.hhmmssffff"));
                }
            }
            catch (Exception ex)
            {

                ProcessException(ex);
            }

        }

        protected void ImbAddRight_Click(object sender, EventArgs e)
        {
            if (lbModulesList.Items.Count > 0) lbModulesList.Items.Clear();
            string module = lbAvailableModules.SelectedItem.Value as string;
            lbModulesList.Items.Add(new ListItem(module));
            lbAvailableModules.Items.Remove(lbAvailableModules.SelectedItem);
            BindFolderFilesDropDown(module);
        }

        protected void ImbAddLeft_Click(object sender, EventArgs e)
        {
            string module = lbModulesList.SelectedItem.Value as string;
            lbAvailableModules.Items.Add(new ListItem(module));
            lbModulesList.Items.Remove(lbModulesList.SelectedItem);
        }

        private void BindDropDown()
        {
            try
            {
                string folderpath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Modules");

                List<string> dirList = new List<string>();

                foreach (string subdir in Directory.GetDirectories(folderpath))
                {
                    string dirName = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    if (!dirName.Equals("Admin"))
                    {
                        dirList.Add(dirName);
                    }
                }
                //adding folder in admin
                foreach (string subdir in Directory.GetDirectories(folderpath + "\\Admin"))
                {
                    string dirName = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    dirList.Add("Admin\\" + dirName);
                }
                lbAvailableModules.DataSource = dirList;
                lbAvailableModules.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindFolderFilesDropDown(string path)
        {
            try
            {
                string folderpath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Modules\\" + path);
                List<string> dirList = new List<string>();
                List<string> ControlFileList = new List<string>();
                foreach (string subdir in Directory.GetFiles(folderpath))
                {
                    string fName = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    fName = fName.ToLower();
                    if (!fName.EndsWith(".sqldataprovider") && !fName.EndsWith(".sfe") && !fName.EndsWith(".dll"))
                    {
                        dirList.Add(fName);

                        if (fName.EndsWith(".ascx"))
                        {
                            ControlFileList.Add(fName);
                        }
                    }
                }
                //adding folder in admin
                foreach (string subdir in Directory.GetDirectories(folderpath))
                {
                    string dirName = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    foreach (string file in Directory.GetFiles(folderpath + "\\" + dirName))
                    {
                        string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                        fileName = fileName.ToLower();
                        if (!fileName.EndsWith(".sqldataprovider") && !fileName.EndsWith(".sfe") && !fileName.EndsWith(".dll"))
                        {
                            dirList.Add(dirName + "\\" + fileName);

                            if (fileName.EndsWith(".ascx"))
                            {
                                ControlFileList.Add(dirName + "\\" + fileName);
                            }
                        }

                    }
                }

                lstFolderFiles.DataSource = dirList;
                lstFolderFiles.DataBind();
                ddlEditControlSrc.DataSource = ControlFileList;
                ddlViewControlSrc.DataSource = ControlFileList;
                ddlSettingControlSrc.DataSource = ControlFileList;
                ddlEditControlSrc.DataBind();
                ddlViewControlSrc.DataBind();
                ddlSettingControlSrc.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private string GetTempPath()
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
            folderPath = Path.Combine(folderPath, "NewPackage");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            folderPath = Path.Combine(folderPath, this.tmpFoldName.Value);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return "Resources\\temp\\NewPackage\\" + this.tmpFoldName.Value + "\\";
        }

        private void BindAssemblyDropDown()
        {
            try
            {
                string folderpath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "bin");
                List<string> dirList = new List<string>();
                foreach (string subdir in Directory.GetFiles(folderpath))
                {
                    string dirName = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    if (!dirName.Equals("Admin"))
                    {
                        dirList.Add(dirName);
                    }
                }
                lstAssembly.DataSource = dirList;
                lstAssembly.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClientScriptManager script = Page.ClientScript;
            Button btn = sender as Button;
            if (btn.Text == "Next")
            {
                string module = lbAvailableModules.SelectedItem.Value as string;
                BindFolderFilesDropDown(module);
                if (!script.IsClientScriptBlockRegistered(GetType(), "divShow1"))
                {
                    script.RegisterClientScriptBlock(this.GetType(), "divShow1", "<script>$(function(){$('#div1').hide();$('#div2').show(); counter=1;$('#' + NewPackage.Settings.next).val('Next');});</script>");
                }
                btn.Text = "Submit";
            }
            else
            {
                string rootPath = HostingEnvironment.ApplicationPhysicalPath;
                ModuleInfoPackage package = new ModuleInfoPackage();
                package.Description = this.PackageDetails1.Description;
                package.Version = this.PackageDetails1.FirstVersion + "." + this.PackageDetails1.SecondVersion + ".";
                package.ReleaseNotes = this.PackageDetails1.ReleaseNotes;
                package.Owner = this.PackageDetails1.Owner;
                package.Organization = this.PackageDetails1.Organization;
                package.URL = this.PackageDetails1.Url;
                package.Email = this.PackageDetails1.Email;
                package.FriendlyName = this.txtfriendlyname.Text;
                package.ModuleName = this.txtmodulename.Text;
                package.BusinessControllerClass = this.txtbusinesscontrollerclass.Text;
                if (lbAvailableModules.SelectedItem != null)
                    package.FolderName = lbAvailableModules.SelectedItem.Value as string;
                package.License = this.PackageDetails1.License;
                package.CompatibleVersions = this.txtcompatibleversions.Text;
                //Populate ModuleElement and add to package
                ModuleElement moduleElement = new ModuleElement();
                moduleElement.FriendlyName = this.txtfriendlyname.Text;
                moduleElement.CacheTime = this.txtCacheTime.Text;
                moduleElement.Controls = GetControls();
                package.ModuleElements.Add(moduleElement);
                package.FileNames.AddRange(GetSelectedItems(this.lstAssembly, Path.Combine(rootPath, "bin\\")));

                package.FileNames.AddRange(GetSelectedItems(this.lstFolderFiles, Path.Combine(rootPath, "Modules\\" + package.FolderName + "\\")));
                string tempFolderPath = rootPath + GetTempPath();
                if (this.hdnInstallScriptFileName.Value != null && this.hdnInstallScriptFileName.Value.Length > 0)
                {
                    package.FileNames.Add(Path.Combine(tempFolderPath, this.hdnInstallScriptFileName.Value));
                }
                else if (!string.IsNullOrEmpty(this.InstallScriptTxt.Text))
                {
                    string filePath = tempFolderPath + package.Version + ddlOrder.SelectedValue + ".SqlDataProvider";
                    StreamWriter writer = File.CreateText(filePath);
                    writer.Write(this.InstallScriptTxt.Text);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    package.FileNames.Add(filePath);
                }

                if (this.hdnInstallScriptFileName2.Value != null && this.hdnInstallScriptFileName2.Value.Length > 0)
                {
                    package.FileNames.Add(Path.Combine(tempFolderPath, this.hdnInstallScriptFileName2.Value));
                }
                else if (!string.IsNullOrEmpty(this.InstallScriptTxt2.Text))
                {
                    string filePath = tempFolderPath + package.Version + ddlOrder2.SelectedValue + ".SqlDataProvider";
                    StreamWriter writer = File.CreateText(filePath);
                    writer.Write(this.InstallScriptTxt2.Text);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    package.FileNames.Add(filePath);
                }

                if (this.hdnInstallScriptFileName3.Value != null && this.hdnInstallScriptFileName3.Value.Length > 0)
                {
                    package.FileNames.Add(Path.Combine(tempFolderPath, this.hdnInstallScriptFileName3.Value));
                }
                else if (!string.IsNullOrEmpty(this.InstallScriptTxt3.Text))
                {
                    string filePath = tempFolderPath + package.Version + ddlOrder3.SelectedValue + ".SqlDataProvider";
                    StreamWriter writer = File.CreateText(filePath);
                    writer.Write(this.InstallScriptTxt3.Text);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    package.FileNames.Add(filePath);
                }

                if (this.hdnUnInstallSQLFileName.Value != null && this.hdnUnInstallSQLFileName.Value.Length > 0)
                {
                    package.FileNames.Add(Path.Combine(tempFolderPath, this.hdnUnInstallSQLFileName.Value));
                }
                else if (!string.IsNullOrEmpty(this.UnistallScriptTxt.Text))
                {
                    string filePath = tempFolderPath + package.Version + ddlUnInstallOrder.SelectedValue + ".SqlDataProvider";
                    StreamWriter writer = File.CreateText(filePath);

                    writer.Write(this.UnistallScriptTxt.Text);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    package.FileNames.Add(filePath);
                }
                if (!string.IsNullOrEmpty(this.hdnSrcZipFile.Value) && this.hdnSrcZipFile.Value.Trim().Length > 1)
                {
                    package.FileNames.Add(Path.Combine(tempFolderPath, this.hdnSrcZipFile.Value));
                }

                ModuleSfeWriter moduleWriter = new ModuleSfeWriter(package);
                try
                {
                    moduleWriter.CreatePackage(package.FolderName, "SFE_" + package.FolderName, package.FileNames, this.Context.Response, tempFolderPath, package, hdnSourceFile.Value);
                    if (script.IsClientScriptBlockRegistered(GetType(), "script1"))
                    {
                        script.RegisterClientScriptBlock(GetType(), "script1", "<script>$(function(){ counter=0;});</script>");
                    }
                }
                catch (Exception)
                {
                }
            }
        }



        protected void ReturnBack()
        {
            HttpContext.Current.Response.Redirect("Super-User/Module-Definitions.aspx", true);

        }


        public List<String> GetSelectedItems(ListBox lbx, string DirectoryPath)
        {
            List<string> list = new List<string>();
            foreach (ListItem item in lbx.Items)
            {
                if (item.Selected) list.Add(DirectoryPath + item.Value);
            }
            return list;
        }

        public List<ControlInfo> GetControls()
        {
            List<ControlInfo> list = new List<ControlInfo>();
            ControlInfo controlInfo = new ControlInfo
            {
                Key = this.txtViewKey.Text,
                Title = this.txtViewTitle.Text,
                Src = this.ddlViewControlSrc.SelectedValue as string,
                HelpUrl = this.txtViewHelpURL.Text,
                Type = "View",
                SupportSpatial = this.chkViewSupportsPartialRendering.Checked ? "true" : "false"
            };
            list.Add(controlInfo);

            //loading edit
            if (this.txtEditKey.Text != null && !string.IsNullOrEmpty(this.txtEditKey.Text.Trim()))
            {
                controlInfo = new ControlInfo
                {
                    Key = this.txtEditKey.Text,
                    Title = this.txtEditTitle.Text,
                    Src = this.ddlEditControlSrc.SelectedValue as string,
                    HelpUrl = this.txtEditHelpURL.Text,
                    Type = "Edit",
                    SupportSpatial = this.chkEditSupportsPartialRendering.Checked ? "true" : "false"
                };
                list.Add(controlInfo);
            }

            //loading Setting
            if (this.txtSettingKey.Text != null && !string.IsNullOrEmpty(this.txtSettingKey.Text.Trim()))
            {
                controlInfo = new ControlInfo
                {
                    Key = this.txtSettingKey.Text,
                    Title = this.txtSettingTitle.Text,
                    Src = this.ddlSettingControlSrc.SelectedValue as string,
                    HelpUrl = this.txtSettingHelpURL.Text,
                    Type = "Setting",
                    SupportSpatial = this.chkSettingSupportsPartialRendering.Checked ? "true" : "false"
                };
                list.Add(controlInfo);
            }
            return list;
        }
        protected void btnCancelled_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin/Modules" + SageFrameSettingKeys.PageExtension);
            //ProcessCancelRequest(Request.RawUrl);
        }
    }
}

