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
using System.Collections;
using SageFrame.SageFrameClass.Services;
using SageFrame.Web;
using SageFrame.Localization;
using System.Threading;

public partial class Localization_LanguagePackInstaller : BaseAdministrationUserControl
{
    LanguagePackInstaller installhelp = new LanguagePackInstaller();
    PackageInfo package = new PackageInfo();
    public event ImageClickEventHandler CancelButtonClick;
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.wzrdInstallLanguagePack.ActiveStepIndex = 0;
        imbCancel.ImageUrl = GetAdminImageUrl("btncancel.png", true);
       
    }
    protected void wzrdInstallLanguagePack_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        string name = "";
        switch (e.CurrentStepIndex)
        {
            case 0://upload the zipped file
                bool status = fluLanguagePack.HasFile;
                name=fluLanguagePack.FileName.ToString();
                ViewState["FileName"] = name;
                ArrayList arrColl = installhelp.Step0CheckLogic(this.fluLanguagePack);
                int ReturnValue;
                if (arrColl != null && arrColl.Count > 0)
                {
                    ReturnValue = (int)arrColl[0];
                    package = (PackageInfo)arrColl[1];
                    ViewState["PackageInfo"] = package;
                    if (ReturnValue == 0)
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("LanguageModule", "SelectAFileFirst"), "", SageMessageType.Alert);
                        e.Cancel = true;
                        break;
                    }
                    else if (ReturnValue == -1)
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "InvalidFileExtension"), "", SageMessageType.Alert);
                        e.Cancel = true;
                        break;
                    }
                    else if (ReturnValue == 1)
                    {
                        BindPackage();
                        break;
                    }
                    else if (ReturnValue == 2)
                    {
                        BindPackage();
                        break;
                    }
                    else if (ReturnValue == 3)
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ThisPackageIsNotValid"), "", SageMessageType.Alert);
                        e.Cancel = true;
                        break;
                    }
                    else if (ReturnValue == 4)
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ThisPackageDoesNotAppearToBeValid"), "", SageMessageType.Alert);
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "ThereIsErrorWhileInstallingThisModule"), "", SageMessageType.Alert);
                        e.Cancel = true;
                        break;
                    }
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                if (chkAcceptLicense.Checked)
                {
                    package = (PackageInfo)ViewState["PackageInfo"];
                    LoadExistingResourceDetails(package);
                }
                else
                {
                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("Extensions_Editors", "AcceptThePackageLicenseAgreementFirst"), "", SageMessageType.Alert);
                    e.Cancel = true;
                }
                break;
            case 4:
                package = (PackageInfo)ViewState["PackageInfo"];
                bool isOverWrite = chkOverWrite.Checked ? true : false;
                List<FileDetails> lstModules = GetSelectedModules();
                try
                {
                    installhelp.InstallPackage(package, Server.MapPath("~/"), isOverWrite, lstModules);
                    CheckAndAddLanguageToDatabase();
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("LanguageModule", "LanguagePackageInstalledSuccessfully"), "", SageMessageType.Success);
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }                
                break;
        }
    }
    public void CheckAndAddLanguageToDatabase()
    {
        List<Language> lstAvailableLocales = LocalizationSqlDataProvider.GetAvailableLocales();
        List<Language> lstAllLocales = LocaleController.GetCultures();
        int index=lstAvailableLocales.FindIndex(delegate(Language obj){return (obj.LanguageCode == GetLocaleFromZipFileName());});
        if (index < 0)
        {
            int localeIndex=lstAllLocales.FindIndex(delegate(Language obj) { return (obj.LanguageCode == GetLocaleFromZipFileName()); });
            AddToDataBase(lstAllLocales[localeIndex]);
        }
    }
    string GetLocaleFromZipFileName()
    {
        string fileName = ViewState["FileName"].ToString();
        return (fileName.Substring(fileName.IndexOf("-") - 2, 5));
        
    }
    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        CancelButtonClick(sender, e);
        this.wzrdInstallLanguagePack.ActiveStepIndex = 0;

    }
    protected void AddToDataBase(Language objLang)
    {
        objLang.FallBackLanguage = Thread.CurrentThread.CurrentCulture.EnglishName;
        objLang.FallBackLanguageCode = Thread.CurrentThread.CurrentCulture.ToString();
        LocalizationSqlDataProvider.AddLanguage(objLang);
    }    
    private void BindPackage()
    {
        if (ViewState["PackageInfo"] != null)
        {
            PackageInfo packageInfo = installhelp.fillPackageInfo(package);
            ViewState["PackageInfo"] = packageInfo;
            lblPackageNameD.Text = packageInfo.PackageName;
            lblTypeD.Text = packageInfo.PackageType;
            lblFriendlyNameD.Text = packageInfo.FriendlyName;
            lblDescriptionD.Text = packageInfo.Description;
            lblVersionD.Text = packageInfo.Version;
            lblOwnerD.Text = packageInfo.OwnerName;
            lblOrganisationD.Text = packageInfo.Organistaion;
            lblEmailD.Text = packageInfo.Email;
            lblLicense.Text = packageInfo.License;
            lblReleaseNotes.Text = packageInfo.ReleaseNotes;

        }
    }
    private void LoadExistingResourceDetails(PackageInfo package)
    {
        List<FileDetails> lstFiles = LanguagePackInstaller.CompareExistingFiles(package, Server.MapPath("~/"));
        List<Module> ModuleList = new List<Module>();
        foreach (FileDetails fd in lstFiles)
        {
            string modulename = "";
            if (fd.FilePath.Contains("Modules\\Admin"))
            {
                modulename = fd.FilePath.Replace("Modules\\Admin\\", "");
                int index = modulename.IndexOf("\\");
                modulename = modulename.Substring(0, index);
            }
            else if (fd.FilePath.Contains("Modules"))
            {
                modulename = fd.FilePath.Replace("Modules\\", "");
                int index = modulename.IndexOf("\\");
                modulename = modulename.Substring(0, index);
            }
            else if (fd.FilePath.Contains("XMLMessage"))
            {
                modulename = "XMLMessage";
            }
            bool isContains = ModuleList.Exists(
                delegate(Module obj)
                {
                    return (obj.ModuleName == modulename);
                }
                );
            if (!isContains && modulename != "")
                ModuleList.Add(new Module(modulename, fd.IsExists));
        }
        gvLangFiles.DataSource = ModuleList;
        gvLangFiles.DataBind();

    }
    protected void gvLangFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "True")
            {
                ((CheckBox)e.Row.FindControl("chkSelect")).Enabled = false;
            }
        }
        e.Row.Cells[2].Visible = false;
    }
    public List<FileDetails> GetSelectedModules()
    {
        List<FileDetails> lstModules = new List<FileDetails>();
        foreach (GridViewRow row in gvLangFiles.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                lstModules.Add(new FileDetails("", row.Cells[1].Text, ""));
            }
        }
        return lstModules;
    }
    public class Module
    {
        public string ModuleName { get; set; }
        public bool IsExist { get; set; }
        public Module() { }
        public Module(string modulename, bool isexist)
        {
            this.ModuleName = modulename;
            this.IsExist = isexist;
        }
    }
    protected void wzrdInstallLanguagePack_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        this.wzrdInstallLanguagePack.ActiveStepIndex = 0;
        
    }
}
