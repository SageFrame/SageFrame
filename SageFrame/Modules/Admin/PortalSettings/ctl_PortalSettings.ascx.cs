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
using SageFrame.Web;
using SageFrame.Localization;
using SageFrame.Framework;
using System.Collections.Specialized;
using SageFrame.Core.ListManagement;
using System.Collections;
using System.IO;
using SageFrame.SageFrameClass;
using System.Text;
using SageFrame.Modules.Admin.HostSettings;
using SageFrame.Shared;
using SageFrame.Common;
using SageFrame.Pages;
using SageFrame.FileManager;
using SageFrame.SageFrameClass.MessageManagement;
using SageFrame.Security;
namespace SageFrame.Modules.Admin.PortalSettings
{
    public partial class ctl_PortalSettings : BaseAdministrationUserControl
    {
        private string languageMode = "Normal";
        protected string BaseDir;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IncludeCss("PortalSettings", "/Modules/Admin/PortalSettings/css/popup.css");
                if (!IsPostBack)
                {
                    AddImageUrls();
                    BinDDls();
                    BindData();
                    SageFrameConfig sfConf = new SageFrameConfig();
                    ViewState["SelectedLanguageCulture"] = sfConf.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultLanguage);
                    GetLanguageList();
                    GetFlagImage();
                  
                   
                }

                RoleController _role = new RoleController();
                string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
                if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
                {
                    BaseDir = GetAbsolutePath(HttpContext.Current.Request.PhysicalApplicationPath.ToString());
                    BaseDir = BaseDir.Substring(0, BaseDir.Length - 1);
                    Initialize();
                    if (!IsPostBack)
                    {


                        if (Request.QueryString["d"] != null)
                        {
                            //BindTree();
                            //TreeView1.Nodes[0].Selected = true;
                        }
                        else
                        {
                            //BindTree();
                        }
                        GetRootFolders();
                        LoadPagerDDL(int.Parse(ViewState["RowCount"].ToString()));
                    }
                }
                else
                {
                    TabContainer.Tabs[2].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        private void ShowHideSMTPCredentials()
        {
            if (Int32.Parse(rblSMTPAuthentication.SelectedItem.Value) == 1)
            {
                trSMTPUserName.Style.Add("display", "");
                trSMTPPassword.Style.Add("display", "");
            }
            else
            {
                trSMTPUserName.Style.Add("display", "none");
                trSMTPPassword.Style.Add("display", "none");
            }
        }
      

        protected void rblSMTPAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHideSMTPCredentials();
        }

        protected void lnkTestSMTP_Click(object sender, EventArgs e)
        {
            TestEmailServer();
        }

        private void TestEmailServer()
        {
            try
            {
                if (txtSMTPServerAndPort.Text.Trim() != string.Empty)
                {
                    MailHelper.SendMailNoAttachment(txtHostEmail.Text, txtHostEmail.Text, "Test Email for configration", "Test Email", string.Empty, string.Empty);

                    lblSMTPEmailTestResult.Text = GetSageMessage("HostSettings", "SMTPServerIsWorking");
                    lblSMTPEmailTestResult.Visible = true;
                    lblSMTPEmailTestResult.CssClass = "Normalbold";
                }
                else
                {
                    // lblSMTPEmailTestResult.Text = "Please Fill Server Address";
                    lblSMTPEmailTestResult.Text = GetSageMessage("HostSettings", "PleaseFillServerAddress");
                    lblSMTPEmailTestResult.Visible = true;
                    lblSMTPEmailTestResult.CssClass = "NormalRed";
                }
            }
            catch (Exception ex)
            {
                lblSMTPEmailTestResult.Text = ex.Message;
                lblSMTPEmailTestResult.Visible = true;
                lblSMTPEmailTestResult.CssClass = "NormalRed";
            }
        }
        protected void imbRestart_Click(object sender, ImageClickEventArgs e)
        {
            RestartApplication();
        }

        private void RestartApplication()
        {
            //System.Web.HttpRuntime.UnloadAppDomain();
            //Response.Redirect("./");
            SageFrame.Application.Application app = new SageFrame.Application.Application();
            File.SetLastWriteTime((app.ApplicationMapPath + "\\web.config"), System.DateTime.Now);
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect(Page.ResolveUrl("~/" + CommonHelper.DefaultPage), true);
        }

        private void BindSMTPAuthntication()
        {
            rblSMTPAuthentication.DataSource = SageFrameLists.SMTPAuthntication();
            rblSMTPAuthentication.DataTextField = "value";
            rblSMTPAuthentication.DataValueField = "key";
            rblSMTPAuthentication.DataBind();
            if (rblSMTPAuthentication.Items.Count > 0)
            {
                rblSMTPAuthentication.SelectedIndex = 0;
            }
        }
        private void AddImageUrls()
        {
            imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbRefresh.ImageUrl = GetTemplateImageUrl("imgrefresh.png", true);
            imbRestart.ImageUrl = GetAdminImageUrl("imgrestart.png", true);
        }

        private void BinDDls()
        {
           

            BindPageDlls();

            Bindlistddls();


            BindddlTimeZone();

            //BinSearchEngines();

            BindRegistrationTypes();

            BindYesNoRBL();
        }

        private void BindData()
        {
            SageFrameConfig pagebase = new SageFrameConfig();
            txtPortalTitle.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PageTitle);
            txtDescription.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.MetaDescription);
            txtKeyWords.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.MetaKeywords);
            txtCopyright.Text = Server.HtmlDecode(pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalCopyright));
            txtLogoTemplate.Text = Server.HtmlDecode(pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalLogoTemplate));
            txtPortalGoogleAdSenseID.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalGoogleAdSenseID);
            chkOptCss.Checked=bool.Parse(pagebase.GetSettingsByKey(SageFrameSettingKeys.OptimizeCss));
            chkOptJs.Checked=bool.Parse(pagebase.GetSettingsByKey(SageFrameSettingKeys.OptimizeJs));
            chkLiveFeeds.Checked = bool.Parse(pagebase.GetSettingsByKey(SageFrameSettingKeys.EnableLiveFeeds));
            txtSiteAdminEmailAddress.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
            //txtPortalUserProfileMaxImageSize.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfileMaxImageSize);
            //txtPortalUserProfileMediumImageSize.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfileMediumImageSize);
            //txtPortalUserProfileSmallImageSize.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfileSmallImageSize);
            //txtPortalMenuImageExtension.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalMenuImageExtension);
            chkShowSidebar.Checked = pagebase.GetSettingBollByKey(SageFrameSettingKeys.ShowSideBar);
           

            if (rblPortalShowProfileLink.Items.Count > 0)
            {
                string ExistingPortalShowProfileLink = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalShowProfileLink);
                rblPortalShowProfileLink.SelectedIndex = rblPortalShowProfileLink.Items.IndexOf(rblPortalShowProfileLink.Items.FindByValue(ExistingPortalShowProfileLink));
            }

            //RemeberMe setting
            chkEnableRememberme.Checked = pagebase.GetSettingBollByKey(SageFrameSettingKeys.RememberCheckbox);           

           
            if (rblUserRegistration.Items.Count > 0)
            {
                string ExistingData = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserRegistration);
                rblUserRegistration.SelectedIndex = rblUserRegistration.Items.IndexOf(rblUserRegistration.Items.FindByValue(ExistingData));
            }

          
            if (ddlLoginPage.Items.Count > 0)
            {
                string ExistingPlortalLoginpage = pagebase.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage);
                ddlLoginPage.SelectedIndex = ddlLoginPage.Items.IndexOf(ddlLoginPage.Items.FindByValue(ExistingPlortalLoginpage));

            }

            if (ddlUserRegistrationPage.Items.Count > 0)
            {
                string ExistingPortalUserActivation = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserActivation);
                ddlPortalUserActivation.SelectedIndex = ddlPortalUserActivation.Items.IndexOf(ddlPortalUserActivation.Items.FindByValue(ExistingPortalUserActivation));
            }

            if (ddlUserRegistrationPage.Items.Count > 0)
            {
                string ExistingPortalRegistrationPage = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage);
                ddlUserRegistrationPage.SelectedIndex = ddlUserRegistrationPage.Items.IndexOf(ddlUserRegistrationPage.Items.FindByValue(ExistingPortalRegistrationPage));
            }
            
            if (ddlPortalForgetPassword.Items.Count > 0)
            {
                string ExistingPortalForgetPassword = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalForgetPassword);
                ddlPortalForgetPassword.SelectedIndex = ddlPortalForgetPassword.Items.IndexOf(ddlPortalForgetPassword.Items.FindByValue(ExistingPortalForgetPassword));
            }

            //ddlPortalPageNotAccessible
            if (ddlPortalPageNotAccessible.Items.Count > 0)
            {
                string ExistingPortalPageNotAccessible = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible);
                ddlPortalPageNotAccessible.SelectedIndex = ddlPortalPageNotAccessible.Items.IndexOf(ddlPortalPageNotAccessible.Items.FindByValue(ExistingPortalPageNotAccessible));
            }

            //ddlPortalPageNotFound
            if (ddlPortalPageNotFound.Items.Count > 0)
            {
                string ExistingPortalPageNotFound = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound);
                ddlPortalPageNotFound.SelectedIndex = ddlPortalPageNotFound.Items.IndexOf(ddlPortalPageNotFound.Items.FindByValue(ExistingPortalPageNotFound));
            }

            //ddlPortalPasswordRecovery
            if (ddlPortalPasswordRecovery.Items.Count > 0)
            {
                string ExistingPortalPasswordRecovery = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPasswordRecovery);
                ddlPortalPasswordRecovery.SelectedIndex = ddlPortalPasswordRecovery.Items.IndexOf(ddlPortalPasswordRecovery.Items.FindByValue(ExistingPortalPasswordRecovery));
            }

            //ddlPortalDefaultPage
            if (ddlPortalDefaultPage.Items.Count > 0)
            {
                string ExistingPortalDefaultPage = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage);
                ddlPortalDefaultPage.SelectedIndex = ddlPortalDefaultPage.Items.IndexOf(ddlPortalDefaultPage.Items.FindByValue(ExistingPortalDefaultPage));
            }

            //ddlPortalUserProfilePage
            if (ddlPortalUserProfilePage.Items.Count > 0)
            {
                string ExistingPortalUserProfilePage = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfilePage);
                ddlPortalUserProfilePage.SelectedIndex = ddlPortalUserProfilePage.Items.IndexOf(ddlPortalUserProfilePage.Items.FindByValue(ExistingPortalUserProfilePage));
            }

            if (ddlDefaultLanguage.Items.Count > 0)
            {
                string ExistingDefaultLanguage = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultLanguage);
                ddlDefaultLanguage.SelectedIndex = ddlDefaultLanguage.Items.IndexOf(ddlDefaultLanguage.Items.FindByValue(ExistingDefaultLanguage));
            }

            if (ddlPortalTimeZone.Items.Count > 0)
            {
                string ExistingPortalTimeZone = pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalTimeZone);
                ddlPortalTimeZone.SelectedIndex = ddlPortalTimeZone.Items.IndexOf(ddlPortalTimeZone.Items.FindByValue(ExistingPortalTimeZone));
            }

            ///Superuser settings
            SageFrame.Application.Application app = new SageFrame.Application.Application();
           

            lblVProduct.Text = app.Description;
            lblVVersion.Text = app.FormatVersion(app.Version, true);

            //imbIsUpgradeAvilable.ImageUrl = GetTemplateImageUrl("imgupgrade.png", true);

            lblVDataProvider.Text = app.DataProvider;
            lblVDotNetFrameWork.Text = app.NETFrameworkIISVersion.ToString();
            lblVASPDotNetIdentiy.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lblVServerName.Text = app.DNSName;
            lblVIpAddress.Text = app.ServerIPAddress;
            lblVPermissions.Text = Framework.SecurityPolicy.Permissions;
            lblVRelativePath.Text = app.ApplicationPath;

            lblVPhysicalPath.Text = app.ApplicationMapPath;
            lblVServerTime.Text = DateTime.Now.ToString();

            lblVGUID.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.GUID);
            //ServerController svc = new ServerController();
            //chkIsWebFarm.Checked = svc.IsWebFarm;
            BindSitePortal();
            if (ddlHostPortal.Items.Count > 0)
            {
                ddlHostPortal.SelectedIndex = ddlHostPortal.Items.IndexOf(ddlHostPortal.Items.FindByValue(pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserPortalId)));
            }

            txtHostTitle.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserTitle);
            txtHostUrl.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserURL);
            txtHostEmail.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserEmail);

            //Apprence
            chkCopyright.Checked = pagebase.GetSettingBollByKey(SageFrameSettingKeys.SuperUserCopyright);
            chkUseCustomErrorMessages.Checked = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseCustomErrorMessages);



            //SMTP
            txtSMTPServerAndPort.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SMTPServer);
            BindSMTPAuthntication();
            if (rblSMTPAuthentication.Items.Count > 0)
            {
                string ExistsSMTPAuth = pagebase.GetSettingsByKey(SageFrameSettingKeys.SMTPAuthentication);
                if (!string.IsNullOrEmpty(ExistsSMTPAuth))
                {
                    rblSMTPAuthentication.SelectedIndex = rblSMTPAuthentication.Items.IndexOf(rblSMTPAuthentication.Items.FindByValue(ExistsSMTPAuth));
                }
            }
            chkSMTPEnableSSL.Checked = pagebase.GetSettingBollByKey(SageFrameSettingKeys.SMTPEnableSSL);
            txtSMTPUserName.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.SMTPUsername);
            string ExistsSMTPPassword = pagebase.GetSettingsByKey(SageFrameSettingKeys.SMTPPassword);
            if (!string.IsNullOrEmpty(ExistsSMTPPassword))
            {
                txtSMTPPassword.Attributes.Add("value", ExistsSMTPPassword);
            }
            ShowHideSMTPCredentials();

          

            //Others
            txtFileExtensions.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.FileExtensions);
            txtHelpUrl.Text = pagebase.GetSettingsByKey(SageFrameSettingKeys.HelpURL);
        }
        private void BindSitePortal()
        {
            try
            {
                SettingProvider spr = new SettingProvider();
                ddlHostPortal.DataSource = spr.GetAllPortals();
                ddlHostPortal.DataTextField = "Name";
                ddlHostPortal.DataValueField = "PortalID";
                ddlHostPortal.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
       
        private void BindPageDlls()
        {
            try
            {

                var LINQParentPages = PageController.GetActivePortalPages(GetPortalID, GetUsername, "---", true, false, DBNull.Value, DBNull.Value);
                ddlLoginPage.Items.Clear();
                ddlLoginPage.DataSource = LINQParentPages;
                ddlLoginPage.DataTextField = "PageName";
                ddlLoginPage.DataValueField = "SEOName";
                ddlLoginPage.DataBind();
                ddlLoginPage.Items.Insert(0, new ListItem("<Not Specified>", "-1"));


                ddlUserRegistrationPage.Items.Clear();
                ddlUserRegistrationPage.DataSource = LINQParentPages;
                ddlUserRegistrationPage.DataTextField = "PageName";
                ddlUserRegistrationPage.DataValueField = "SEOName";
                ddlUserRegistrationPage.DataBind();
                ddlUserRegistrationPage.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalUserActivation
                ddlPortalUserActivation.Items.Clear();
                ddlPortalUserActivation.DataSource = LINQParentPages;
                ddlPortalUserActivation.DataTextField = "PageName";
                ddlPortalUserActivation.DataValueField = "SEOName";
                ddlPortalUserActivation.DataBind();
                ddlPortalUserActivation.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalForgetPassword
                ddlPortalForgetPassword.Items.Clear();
                ddlPortalForgetPassword.DataSource = LINQParentPages;
                ddlPortalForgetPassword.DataTextField = "PageName";
                ddlPortalForgetPassword.DataValueField = "SEOName";
                ddlPortalForgetPassword.DataBind();
                ddlPortalForgetPassword.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalPageNotAccessible
                ddlPortalPageNotAccessible.Items.Clear();
                ddlPortalPageNotAccessible.DataSource = LINQParentPages;
                ddlPortalPageNotAccessible.DataTextField = "PageName";
                ddlPortalPageNotAccessible.DataValueField = "SEOName";
                ddlPortalPageNotAccessible.DataBind();
                ddlPortalPageNotAccessible.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalPageNotFound
                ddlPortalPageNotFound.Items.Clear();
                ddlPortalPageNotFound.DataSource = LINQParentPages;
                ddlPortalPageNotFound.DataTextField = "PageName";
                ddlPortalPageNotFound.DataValueField = "SEOName";
                ddlPortalPageNotFound.DataBind();
                ddlPortalPageNotFound.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalPasswordRecovery
                ddlPortalPasswordRecovery.Items.Clear();
                ddlPortalPasswordRecovery.DataSource = LINQParentPages;
                ddlPortalPasswordRecovery.DataTextField = "PageName";
                ddlPortalPasswordRecovery.DataValueField = "SEOName";
                ddlPortalPasswordRecovery.DataBind();
                ddlPortalPasswordRecovery.Items.Insert(0, new ListItem("<Not Specified>", "-1"));

                //ddlPortalDefaultPage
                ddlPortalDefaultPage.Items.Clear();
                ddlPortalDefaultPage.DataSource = LINQParentPages;
                ddlPortalDefaultPage.DataTextField = "PageName";
                ddlPortalDefaultPage.DataValueField = "SEOName";
                ddlPortalDefaultPage.DataBind();
                ddlPortalDefaultPage.Items.Insert(0, new ListItem("<Not Specified>", "-1"));


                //ddlPortalUserProfilePage
                ddlPortalUserProfilePage.Items.Clear();
                ddlPortalUserProfilePage.DataSource = LINQParentPages;
                ddlPortalUserProfilePage.DataTextField = "PageName";
                ddlPortalUserProfilePage.DataValueField = "SEOName";
                ddlPortalUserProfilePage.DataBind();
                ddlPortalUserProfilePage.Items.Insert(0, new ListItem("<Not Specified>", "-1"));
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void Bindlistddls()
        {
            try
            {
                //ListManagementDataContext db = new ListManagementDataContext(SystemSetting.SageFrameConnectionString);
                //var LINQ = db.sp_GetListEntrybyNameAndID("Country", -1,GetCurrentCultureName);
                //ddlDefaultLanguage.DataSource = ListManagementController.GetListEntrybyNameAndID("Country", -1,GetCurrentCultureName);
                //ddlDefaultLanguage.DataTextField = "Text";
                //ddlDefaultLanguage.DataValueField = "Value";
                //ddlDefaultLanguage.DataBind();
                //LINQ = db.sp_GetListEntrybyNameAndID("Processor", -1,GetCurrentCultureName);
                //ddlPaymentProcessor.DataSource = LINQ;
                //ddlPaymentProcessor.DataTextField = "Text";
                //ddlPaymentProcessor.DataValueField = "Value";
                //ddlPaymentProcessor.DataBind();

                ////ddlCurrency
                //LINQ = db.sp_GetListEntrybyNameAndID("Currency", -1,GetCurrentCultureName);
                //ddlCurrency.DataSource = LINQ;
                //ddlCurrency.DataTextField = "Text";
                //ddlCurrency.DataValueField = "Value";
                //ddlCurrency.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindddlTimeZone()
        {
            try
            {
                NameValueCollection nvlTimeZone = SageFrame.Localization.Localization.GetTimeZones(((PageBase)this.Page).GetCurrentCultureName);
                ddlPortalTimeZone.DataSource = nvlTimeZone;
                ddlPortalTimeZone.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            
        }

        private void BindRegistrationTypes()
        {
            rblUserRegistration.DataSource = SageFrameLists.UserRegistrationTypes();
            rblUserRegistration.DataValueField = "key";
            rblUserRegistration.DataTextField = "value";
            rblUserRegistration.DataBind();
        }

        //private void BinSearchEngines()
        //{
        //    ddlSearchEngine.DataSource = SageFrameLists.SearchEngines();
        //    ddlSearchEngine.DataTextField = "value";
        //    ddlSearchEngine.DataValueField = "key";
        //    ddlSearchEngine.DataBind();
        //}

        private void BindRBLWithREF(RadioButtonList rbl)
        {
            rbl.DataSource = SageFrameLists.YESNO();
            rbl.DataTextField = "value";
            rbl.DataValueField = "key";
            rbl.DataBind();
            rbl.RepeatColumns = 2;
            rbl.RepeatDirection = RepeatDirection.Horizontal;
        }

        private void BindYesNoRBL()
        {
            //rblPortalShowProfileLink
            BindRBLWithREF(rblPortalShowProfileLink);            

            ////rblPortalShowSubscribe
            //BindRBLWithREF(rblPortalShowSubscribe);            

            ////rblPortalShowLogo
            //BindRBLWithREF(rblPortalShowLogo);            

            ////rblPortalShowFooterLink
            //BindRBLWithREF(rblPortalShowFooterLink);

            ////rblPortalShowFooter
            //BindRBLWithREF(rblPortalShowFooter);

            ////rblPortalShowBreadCrum
            //BindRBLWithREF(rblPortalShowBreadCrum);            

            ////rblPortalShowCopyRight
            //BindRBLWithREF(rblPortalShowCopyRight);

            ////rblPortalShowLoginStatus
            //BindRBLWithREF(rblPortalShowLoginStatus);

           
           
        }

        private void RefreshPage()
        {
            try
            {
                HttpContext.Current.Cache.Remove("SageSetting");
                BindData();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void SavePortalSettings()
        {
            try
            {
                SettingProvider sageSP = new SettingProvider();
                //Add Single Key Values that may contain Comma values so need to be add sepratly
                #region "Single Key Value Add/Updatge"

                //SageFrameSettingKeys.PageTitle
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.PageTitle,
                    txtPortalTitle.Text.Trim(), GetUsername, GetPortalID.ToString());

                //SageFrameSettingKeys.MetaDescription
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.MetaDescription,
                    txtDescription.Text, GetUsername, GetPortalID.ToString());

                //SageFrameSettingKeys.MetaKeywords
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.MetaKeywords,
                    txtKeyWords.Text, GetUsername, GetPortalID.ToString());

                //SageFrameSettingKeys.PortalLogoTemplate
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.PortalLogoTemplate,
                    txtLogoTemplate.Text.Trim(), GetUsername, GetPortalID.ToString());

                //SageFrameSettingKeys.PortalCopyright
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.PortalCopyright,
                    txtCopyright.Text.Trim(), GetUsername, GetPortalID.ToString());

                //SageFrameSettingKeys.PortalTimeZone
                sageSP.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.PortalTimeZone,
                    ddlPortalTimeZone.SelectedItem.Value, GetUsername, GetPortalID.ToString());

                #endregion

                //For Multiple Keys and Values
                #region "Multiple Key Value Add/Update"

                StringBuilder sbSettingKey = new StringBuilder();
                StringBuilder sbSettingValue = new StringBuilder();
                StringBuilder sbSettingType = new StringBuilder();

                //Collecting Setting Values
                ///Super user settings
                StringBuilder sbSettingKey_super = new StringBuilder();
                StringBuilder sbSettingValue_super = new StringBuilder();
                StringBuilder sbSettingType_super = new StringBuilder();


                //SageFrameSettingKeys.SiteAdminEmailAddress
                sbSettingKey.Append(SageFrameSettingKeys.SiteAdminEmailAddress + ",");
                sbSettingValue.Append(txtSiteAdminEmailAddress.Text.Trim() + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");               
                
                //SageFrameSettingKeys.PortalGoogleAdSenseID
                sbSettingKey.Append(SageFrameSettingKeys.PortalGoogleAdSenseID + ",");
                sbSettingValue.Append(txtPortalGoogleAdSenseID.Text.Trim() + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

               
                //SageFrameSettingKeys.PortalShowProfileLink
                sbSettingKey.Append(SageFrameSettingKeys.PortalShowProfileLink + ",");
                sbSettingValue.Append(rblPortalShowProfileLink.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //SageFrameSettingKeys.RememberCheckbox
                sbSettingKey.Append(SageFrameSettingKeys.RememberCheckbox + ",");
                sbSettingValue.Append(chkEnableRememberme.Checked + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //CssJs Optimization
                sbSettingKey.Append(SageFrameSettingKeys.OptimizeCss+",");
                sbSettingValue.Append(chkOptCss.Checked + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                sbSettingKey.Append(SageFrameSettingKeys.OptimizeJs + ",");
                sbSettingValue.Append(chkOptJs.Checked + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                sbSettingKey.Append(SageFrameSettingKeys.EnableLiveFeeds + ",");
                sbSettingValue.Append(chkLiveFeeds.Checked + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");
                
                //SageFrameSettingKeys.ShowSideBar
                sbSettingKey.Append(SageFrameSettingKeys.ShowSideBar + ",");
                sbSettingValue.Append(chkShowSidebar.Checked+ ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");


                //SageFrameSettingKeys.PortalUserRegistration
                sbSettingKey.Append(SageFrameSettingKeys.PortalUserRegistration + ",");
                sbSettingValue.Append(rblUserRegistration.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");


                //SageFrameSettingKeys.PlortalLoginpage
                sbSettingKey.Append(SageFrameSettingKeys.PlortalLoginpage + ",");
                sbSettingValue.Append(ddlLoginPage.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //SageFrameSettingKeys.PortalUserActivation
                sbSettingKey.Append(SageFrameSettingKeys.PortalUserActivation + ",");
                sbSettingValue.Append(ddlPortalUserActivation.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //SageFrameSettingKeys.PortalRegistrationPage
                sbSettingKey.Append(SageFrameSettingKeys.PortalRegistrationPage + ",");
                sbSettingValue.Append(ddlUserRegistrationPage.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //SageFrameSettingKeys.PortalForgetPassword
                sbSettingKey.Append(SageFrameSettingKeys.PortalForgetPassword + ",");
                sbSettingValue.Append(ddlPortalForgetPassword.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");
                
                //SageFrameSettingKeys.PortalPageNotAccessible
                sbSettingKey.Append(SageFrameSettingKeys.PortalPageNotAccessible + ",");
                sbSettingValue.Append(ddlPortalPageNotAccessible.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //SageFrameSettingKeys.PortalPageNotFound
                sbSettingKey.Append(SageFrameSettingKeys.PortalPageNotFound + ",");
                sbSettingValue.Append(ddlPortalPageNotFound.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                
                //SageFrameSettingKeys.PortalPasswordRecovery
                sbSettingKey.Append(SageFrameSettingKeys.PortalPasswordRecovery + ",");
                sbSettingValue.Append(ddlPortalPasswordRecovery.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //PortalUserProfilePage
                sbSettingKey.Append(SageFrameSettingKeys.PortalUserProfilePage + ",");
                sbSettingValue.Append(ddlPortalUserProfilePage.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                //PortalDefaultPage
                sbSettingKey.Append(SageFrameSettingKeys.PortalDefaultPage + ",");
                sbSettingValue.Append(ddlPortalDefaultPage.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");
               

                //SageFrameSettingKeys.PortalDefaultLanguage
                sbSettingKey.Append(SageFrameSettingKeys.PortalDefaultLanguage + ",");
                sbSettingValue.Append(ddlDefaultLanguage.SelectedItem.Value + ",");
                sbSettingType.Append(SettingType.SiteAdmin + ",");

                RoleController _role = new RoleController();
                string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
                if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
                {
                    ///Superuser Settings 
                    //Collecting Setting Values
                    sbSettingKey_super.Append(SageFrameSettingKeys.SuperUserPortalId + ",");
                    sbSettingValue_super.Append(ddlHostPortal.SelectedItem.Value + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SuperUserTitle                
                    sbSettingKey_super.Append(SageFrameSettingKeys.SuperUserTitle + ",");
                    sbSettingValue_super.Append(txtHostTitle.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SuperUserURL
                    sbSettingKey_super.Append(SageFrameSettingKeys.SuperUserURL + ",");
                    sbSettingValue_super.Append(txtHostUrl.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SuperUserEmail
                    sbSettingKey_super.Append(SageFrameSettingKeys.SuperUserEmail + ",");
                    sbSettingValue_super.Append(txtHostEmail.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SuperUserCopyright
                    sbSettingKey_super.Append(SageFrameSettingKeys.SuperUserCopyright + ",");
                    sbSettingValue_super.Append(chkCopyright.Checked + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.UseCustomErrorMessages
                    sbSettingKey_super.Append(SageFrameSettingKeys.UseCustomErrorMessages + ",");
                    sbSettingValue_super.Append(chkUseCustomErrorMessages.Checked + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");


                    //SageFrameSettingKeys.UseFriendlyUrls
                    sbSettingKey_super.Append(SageFrameSettingKeys.UseFriendlyUrls + ",");
                    sbSettingValue_super.Append(true + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");



                    //SageFrameSettingKeys.SMTPServer
                    sbSettingKey_super.Append(SageFrameSettingKeys.SMTPServer + ",");
                    sbSettingValue_super.Append(txtSMTPServerAndPort.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SMTPAuthentication
                    sbSettingKey_super.Append(SageFrameSettingKeys.SMTPAuthentication + ",");
                    sbSettingValue_super.Append(rblSMTPAuthentication.SelectedItem.Value + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SMTPEnableSSL
                    sbSettingKey_super.Append(SageFrameSettingKeys.SMTPEnableSSL + ",");
                    sbSettingValue_super.Append(chkSMTPEnableSSL.Checked + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SMTPUsername
                    sbSettingKey_super.Append(SageFrameSettingKeys.SMTPUsername + ",");
                    sbSettingValue_super.Append(txtSMTPUserName.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.SMTPPassword
                    sbSettingKey_super.Append(SageFrameSettingKeys.SMTPPassword + ",");
                    sbSettingValue_super.Append(txtSMTPPassword.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");


                    //SageFrameSettingKeys.FileExtensions
                    sbSettingKey_super.Append(SageFrameSettingKeys.FileExtensions + ",");
                    sbSettingValue_super.Append(txtFileExtensions.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");

                    //SageFrameSettingKeys.HelpURL
                    sbSettingKey_super.Append(SageFrameSettingKeys.HelpURL + ",");
                    sbSettingValue_super.Append(txtHelpUrl.Text.Trim() + ",");
                    sbSettingType_super.Append(SettingType.SuperUser + ",");
                }
                string SettingTypes = sbSettingType.ToString();
                if (SettingTypes.Contains(","))
                {
                    SettingTypes = SettingTypes.Remove(SettingTypes.LastIndexOf(","));
                }
                string SettingKeys = sbSettingKey.ToString();
                if (SettingKeys.Contains(","))
                {
                    SettingKeys = SettingKeys.Remove(SettingKeys.LastIndexOf(","));
                }
                string SettingValues = sbSettingValue.ToString();
                if (SettingValues.Contains(","))
                {
                    SettingValues = SettingValues.Remove(SettingValues.LastIndexOf(","));
                }
                string SettingTypes_super = sbSettingType_super.ToString();
                if (SettingTypes_super.Contains(","))
                {
                    SettingTypes_super = SettingTypes_super.Remove(SettingTypes_super.LastIndexOf(","));
                }
                string SettingKeys_super = sbSettingKey_super.ToString();
                if (SettingKeys_super.Contains(","))
                {
                    SettingKeys_super = SettingKeys_super.Remove(SettingKeys_super.LastIndexOf(","));
                }
                string SettingValues_super = sbSettingValue_super.ToString();
                if (SettingValues_super.Contains(","))
                {
                    SettingValues_super = SettingValues_super.Remove(SettingValues_super.LastIndexOf(","));
                }
                
                sageSP.SaveSageSettings(SettingTypes, SettingKeys, SettingValues, GetUsername, GetPortalID.ToString());
                if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
                {
                    sageSP.SaveSageSettings(SettingTypes_super, SettingKeys_super, SettingValues_super, GetUsername, "1");
                }
                HttpContext.Current.Cache.Remove("SageSetting");
                BindData();

                #endregion

                ShowMessage("", GetSageMessage("PortalSettings", "PortalSettingIsSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }       

        protected void imbSave_Click(object sender, ImageClickEventArgs e)
        {
            SavePortalSettings();
        }

        //protected void lnkSave_Click(object sender, EventArgs e)
        //{
        //    SavePortalSettings();
        //}

        protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
        {
            RefreshPage();
        }

        //protected void lnkRefresh_Click(object sender, EventArgs e)
        //{
        //    RefreshPage();
        //}
        protected void ddlDefaultLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFlagImage();
            ViewState["SelectedLanguageCulture"] = this.ddlDefaultLanguage.SelectedValue;
        }
        protected void GetFlagImage()
        {
            string code = this.ddlDefaultLanguage.SelectedValue;
            imgFlag.ImageUrl = ResolveUrl(this.Request.ApplicationPath+ "/images/flags/" + code.Substring(code.IndexOf("-") + 1) + ".png");
        }
        protected void rbLanguageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rbLanguageType.SelectedIndex)
            {
                case 0:
                    GetLanguageList();                   
                    break;
                case 1:
                    LoadNativeNames();
                    break;
            }
        }
        protected void LoadNativeNames()
        {
            languageMode = "Native";
            GetLanguageList();           
        }
        public void GetLanguageList()
        {
            string mode = languageMode == "Native" ? "NativeName" : "LanguageName";
            List<Language> lstAvailableLocales = LocaleController.AddNativeNamesToList(LocalizationSqlDataProvider.GetAvailableLocales());

            ddlDefaultLanguage.DataSource = lstAvailableLocales;
            ddlDefaultLanguage.DataTextField = mode;
            ddlDefaultLanguage.DataValueField = "LanguageCode";
            ddlDefaultLanguage.DataBind();
            ddlDefaultLanguage.SelectedIndex = ddlDefaultLanguage.Items.IndexOf(ddlDefaultLanguage.Items.FindByValue(ViewState["SelectedLanguageCulture"].ToString()));
            ViewState["RowCount"] = lstAvailableLocales.Count;

        }

        protected void btnRefreshCache_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Cache.Remove("SageFrameCss");
            HttpContext.Current.Cache.Remove("SageFrameJs");
            string optimized_path = Server.MapPath(SageFrameConstants.OptimizedResourcePath);
            IOHelper.DeleteDirectoryFiles(optimized_path,".js,.css");
            if (File.Exists(Server.MapPath(SageFrameConstants.OptimizedCssMap)))
            {
                XmlHelper.DeleteNodes(Server.MapPath(SageFrameConstants.OptimizedCssMap),"resourcemaps/resourcemap");
            } 
            if (File.Exists(Server.MapPath(SageFrameConstants.OptimizedJsMap)))
            {
                XmlHelper.DeleteNodes(Server.MapPath(SageFrameConstants.OptimizedJsMap), "resourcemap/resourcemap");
            }
        }

        #region FileManagerSettings

        protected void Initialize()
        {
            IncludeCssFile(AppRelativeTemplateSourceDirectory + "css/popup.css");
        }
        public void LoadPagerDDL(int gridRowsCount)
        {
            ddlPageSize.Items.Clear();
            for (int i = 0; i < gridRowsCount; i += 10)
            {
                if (i == 0)
                {
                    ddlPageSize.Items.Add(new ListItem("All", i.ToString(), true));
                }
                else
                {
                    ddlPageSize.Items.Add(new ListItem(i.ToString(), i.ToString(), true));
                }
            }
            ddlPageSize.SelectedIndex = ddlPageSize.Items.IndexOf(ddlPageSize.Items.FindByValue("10"));
        }
        private void BindTree()
        {
            TreeView1.Nodes.Clear();
            string rootFolder = BaseDir;
            TreeNode rootNode = new TreeNode();

            string relativePath = FileManagerHelper.ReplaceBackSlash(Request.PhysicalApplicationPath.ToString());
            relativePath = relativePath.Substring(0, relativePath.LastIndexOf("/"));
            string root = Request.ApplicationPath.ToString();
            rootNode.Text = Path.Combine(BaseDir.Replace(relativePath, ""), root);
            rootNode.Expanded = true;
            rootNode.Value = rootFolder.Replace("\\", "~").Replace(" ", "|");
            TreeView1.Nodes.Add(rootNode);
            TreeView1.ShowLines = true;
            BuildTreeDirectory(rootFolder, rootNode);

        }
        public string GetAbsolutePath(string filepath)
        {
            return (FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filepath)));
        }
        private void BuildTreeDirectory(string dirPath, TreeNode parentNode)
        {
            string[] subDirectories = Directory.GetDirectories(dirPath);
            foreach (string directory in subDirectories)
            {
                string[] parts = directory.Split('\\');
                string name = parts[parts.Length - 1];
                TreeNode node = new TreeNode();
                node.Text = name;
                node.ImageUrl = "images/folder.gif";
                node.Expanded = false;
                parentNode.ChildNodes.Add(node);
                //BuildSubDirectory(directory, node);
            }

        }
        private void BuildSubDirectory(string dirPath, TreeNode parentNode)
        {
            string[] subDirectories = Directory.GetDirectories(dirPath);

            foreach (string directory in subDirectories)
            {
                string[] parts = directory.Split('\\');
                string name = parts[parts.Length - 1];
                TreeNode node = new TreeNode();
                node.Text = name;
                node.ImageUrl = "images/folder.gif";
                parentNode.ChildNodes.Add(node);
                node.Expanded = false;
                BuildSubDirectory(directory, node);
            }

        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.PopUp.Hide();
            shcFileManager.IsExpanded = true;
            AddRootFolder(TreeView1.SelectedNode.ValuePath.ToString());

        }
        protected void btnShowPopUp_Click(object sender, EventArgs e)
        {
            BindTree();
            this.PopUp.Show();
        }
        protected void AddRootFolder(string path)
        {
            Folder folder = new Folder();
            folder.PortalId = GetPortalID;
            folder.FolderPath = path.Replace(BaseDir + "/", "");
            folder.StorageLocation = 0;
            folder.UniqueId = Guid.NewGuid();
            folder.VersionGuid = Guid.NewGuid();
            folder.IsActive = 1;
            folder.AddedBy = GetUsername;
            try
            {
                FileManagerController.AddRootFolder(folder);
                CacheHelper.Clear("FileManagerRootFolders");
                CacheHelper.Clear("FileManagerFolders");
                GetRootFolders();
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void GetRootFolders()
        {
            List<Folder> lstRootFolders = FileManagerController.GetRootFolders();
            gdvRootFolders.DataSource = lstRootFolders;
            gdvRootFolders.DataBind();
            ViewState["RowCount"] = lstRootFolders.Count;
        }
        protected void gdvRootFolders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                this.gdvRootFolders.HeaderRow.Cells[0].Visible = false;
            }
        }
        protected void gdvRootFolders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DeleteRootFolder"))
            {
                FileManagerController.DeleteRootFolder(int.Parse(e.CommandArgument.ToString()));
                CacheHelper.Clear("FileManagerRootFolders");
                CacheHelper.Clear("FileManagerFolders");
                GetRootFolders();
                shcFileManager.IsExpanded = true;
            }
        }
        protected void gdvRootFolders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRootFolders.PageIndex = e.NewPageIndex;
            GetRootFolders();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue != "0")
            {
                gdvRootFolders.AllowPaging = true;
                gdvRootFolders.PageSize = int.Parse(ddlPageSize.SelectedValue);
                gdvRootFolders.PageIndex = 0;
            }
            else
            {
                gdvRootFolders.AllowPaging = false;
            }
            GetRootFolders();
        }
        protected void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            GridViewRow objItem = (GridViewRow)chk.Parent.Parent;
            int FolderID = int.Parse(gdvRootFolders.Rows[objItem.RowIndex].Cells[0].Text);
            try
            {
                FileManagerController.EnableRootFolder(FolderID, chk.Checked);
                CacheHelper.Clear("FileManagerRootFolders");
                CacheHelper.Clear("FileManagerFolders");
                GetRootFolders();
            }
            catch (Exception ex)
            {

                ProcessException(ex);
            }


        }

        protected void imgClosePopUp_Click(object sender, EventArgs e)
        {
            PopUp.Hide();
            shcFileManager.IsExpanded = true;
        }

        #endregion
}
}