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
using System.Web.Security;
using SageFrame.Framework;
using System.Data;
using SageFrame.Web;
using SageFrame.PortalSetting;
using System.Collections;
using SageFrame.Web.Utilities;
using SageFrame.SageFrameClass;
using SageFrame.Utilities;
using SageFrame.RolesManagement;
using SageFrame.Shared;
using System.IO;
using System.Text;
using SageFrame.Dashboard;
using SageFrame.Templating;
using System.Web.UI.HtmlControls;
using SageFrame.ModuleMessage;
using SageFrame.Security;
using SageFrame.Common;


namespace SageFrame
{
    public partial class Sagin_Default : PageBase, SageFrameRoute
    {
        public string ControlPath = string.Empty,SageFrameAppPath,SageFrameUserName;
        bool IsUseFriendlyUrls = true;
        public string appPath = "";
        
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!(Request.RawUrl.Contains(".gif") || Request.RawUrl.Contains(".jpg") || Request.RawUrl.Contains(".png")))
            {
                SageInitPart();                
            }
            appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";

            SageFrameAppPath = appPath;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar1", " var SageFrameAppPath='" + appPath + "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar2", " var SageFrameUserName='" + GetUsername+ "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar3", " var SageFramePortalName='" + GetPortalSEOName + "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar4", " var SageFramePortalID='" + GetPortalID + "';", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar5", " var SageFrameActiveTemplate='" + GetActiveTemplate + "';", true);
            
        }

        private void SageInitPart()
        {
            
            string IsInstalled = Config.GetSetting("IsInstalled").ToString();
            string InstallationDate = Config.GetSetting("InstallationDate").ToString();
            if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
            {
                if (!(Request.RawUrl.Contains(".gif") || Request.RawUrl.Contains(".jpg") || Request.RawUrl.Contains(".png")))
                {
                    SetPortalCofig();
                    InitializePage();
                    hypUpgrade.NavigateUrl = "~/Admin/sfUpgrader.aspx";
                    SageFrameConfig sfConfig = new SageFrameConfig();
                    IsUseFriendlyUrls = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);                  
                    LoadMessageControl();
                    BindModuleControls();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(ResolveUrl("~/Install/InstallWizard.aspx"));
            }
        }

        public void LoadMessageControl()
        {
            PlaceHolder phdPlaceHolder = Page.FindControl("message") as PlaceHolder;
            if (phdPlaceHolder != null)
            {
                LoadControl(phdPlaceHolder, "~/Controls/Message.ascx");
            }
        }
        private void SetPortalCofig()
        {
            Hashtable hstPortals = GetPortals();
            SageUserControl suc = new SageUserControl();
           
            suc.PagePath = PagePath;
            int portalID = 1;
            //ptlid=-9&ptSEO=contruction&pgnm=faqs
            if (string.IsNullOrEmpty(Request.QueryString["ptSEO"]))
            {
                if (string.IsNullOrEmpty(PortalSEOName))
                {
                    PortalSEOName = "default";
                }
                else if (!hstPortals.ContainsKey(PortalSEOName.ToLower().Trim()))
                {
                    PortalSEOName = "default";
                }
                else
                {
                    portalID = int.Parse(hstPortals[PortalSEOName.ToLower().Trim()].ToString());
                }
            }
            else
            {
                PortalSEOName = Request.QueryString["ptSEO"].ToString().ToLower().Trim();
                portalID = Int32.Parse(Request.QueryString["ptlid"].ToString());
            }
            suc.SetPortalSEOName(PortalSEOName.ToLower().Trim());          
            Session["SageFrame.PortalSEOName"] = PortalSEOName.ToLower().Trim();
            Session["SageFrame.PortalID"] = portalID;
            Session["SageFrame.AdminTheme"] = ThemeHelper.GetAdminTheme(GetPortalID, GetUsername);
            Session["SageFrame.ActiveTemplate"] = TemplateController.GetActiveTemplate(GetPortalID).TemplateSeoName;
            Session["SageFrame.ActivePreset"] = PresetHelper.LoadActivePagePreset(GetActiveTemplate, GetPageSEOName(Request.Url.ToString()));
            suc.SetPortalID(portalID);
            SetPortalID(portalID);
            if (HttpContext.Current.User != null)
            {
                if (Membership.GetUser() != null)
                {
                    string strRoles = string.Empty;
                    //RolesManagementDataContext dbRole = new RolesManagementDataContext(SystemSetting.SageFrameConnectionString);
                    //var userRoles = dbRole.sp_RoleGetByUsername(HttpContext.Current.User.Identity.Name, GetPortalID).ToList();
                    //foreach (var userRole in userRoles)
                    //{
                    //    strRoles += userRole.RoleId + ",";
                    //}
                    SettingProvider objSP = new SettingProvider();
                    List<SageUserRole> sageUserRolles = objSP.RoleListGetByUsername(HttpContext.Current.User.Identity.Name, GetPortalID);
                    if (sageUserRolles != null)
                    {
                        foreach (SageUserRole userRole in sageUserRolles)
                        {
                            strRoles += userRole.RoleId + ",";
                        }
                    }
                    if (strRoles.Length > 1)
                    {
                        strRoles = strRoles.Substring(0, strRoles.Length - 1);
                    }
                    if (strRoles.Length > 0)
                    {
                        SetUserRoles(strRoles);
                    }
                }
            }
        }
        public void SetUserRoles(string strRoles)
        {
            Session["SageUserRoles"] = strRoles;
            HttpCookie cookie = HttpContext.Current.Request.Cookies["SageUserRolesCookie"];
            if (cookie == null)
            {
                cookie = new HttpCookie("SageUserRolesCookie");
            }
            cookie["SageUserRolesProtected"] = strRoles;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        private Hashtable GetPortals()
        {
            
            Hashtable hstAll = new Hashtable();
            if (HttpContext.Current.Cache["Portals"] != null)
            {
                hstAll = (Hashtable)HttpContext.Current.Cache["Portals"];
            }
            else
            {
                SettingProvider objSP = new SettingProvider();
                List<SagePortals> sagePortals = objSP.PortalGetList();
                foreach (SagePortals portal in sagePortals)
                {
                    hstAll.Add(portal.SEOName.ToLower().Trim(), portal.PortalID);
                }
            }
            HttpContext.Current.Cache.Insert("Portals", hstAll);
            return hstAll;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!(Request.RawUrl.Contains(".gif") || Request.RawUrl.Contains(".jpg") || Request.RawUrl.Contains(".png")))
            {
                
                SagePageLoadPart();
            }
           
            //HtmlGenericControl spnMessage = Page.FindControl("divMessage") as HtmlGenericControl;
            //spnMessage.InnerHtml = "";
           
        }

        private void SagePageLoadPart()
        {
            if (!IsPostBack)
            {
                string sageNavigateUrl = string.Empty;
                SageFrameConfig sfConfig = new SageFrameConfig();
                if (IsUseFriendlyUrls)
                {
                    if (GetPortalID > 1)
                    {
                        sageNavigateUrl = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
                    }
                    else
                    {
                        sageNavigateUrl = ResolveUrl("~/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
                    }
                }
                else
                {
                    sageNavigateUrl = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage));
                }
                hypHome.NavigateUrl = sageNavigateUrl;
                hypHome.Text = sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage);
                hypHome.ImageUrl = GetAdminImageUrl("home.png", true);
                hypPreview.NavigateUrl = hypHome.NavigateUrl;
                lnkAccount.NavigateUrl = GetProfileLink(sfConfig);
                Image imgProgress = (Image)UpdateProgress1.FindControl("imgPrgress");
                if (imgProgress != null)
                {
                    imgProgress.ImageUrl = GetAdminImageUrl("ajax-loader.gif", true);
                }
                bool IsAdmin = false;  
                    if (HttpContext.Current.User != null)
                    {
                        MembershipUser user = Membership.GetUser();
                        FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;

                        if (identity != null)
                        {
                            FormsAuthenticationTicket ticket = identity.Ticket;
                            int LoggedInPortalID = int.Parse(ticket.UserData.ToString());

                            if (user != null && user.UserName != "")
                            {
                                string[] sysRoles = SystemSetting.SUPER_ROLE;

                                this.hypUpgrade.Visible = Roles.IsUserInRole(user.UserName, sysRoles[0])?true:false;
                                if (GetPortalID == LoggedInPortalID || Roles.IsUserInRole(user.UserName, sysRoles[0]))
                                {
                                    RoleController _role = new RoleController();
                                    string userinroles = _role.GetRoleNames(GetUsername, LoggedInPortalID);
                                    if (userinroles != "" || userinroles != null)
                                    {
                                        divAdminControlPanel.Attributes.Add("style", "display:block");                                        
                                        foreach (string role in sysRoles)
                                        {
                                            if (Roles.IsUserInRole(user.UserName, role))
                                            {   
                                                IsAdmin = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        divAdminControlPanel.Attributes.Add("style", "display:none");
                                    }
                                }
                                else
                                {
                                    divAdminControlPanel.Attributes.Add("style", "display:none");
                                }
                            }
                            else
                            {
                                divAdminControlPanel.Attributes.Add("style", "display:none");
                            }
                        }
                        else
                        {
                            divAdminControlPanel.Attributes.Add("style", "display:none");
                        }
                    }
                    if (IsHandheld())
                    {
                        divAdminControlPanel.Attributes.Add("style", "display:none");
                    }
             
                if (IsAdmin)
                {
                    //divAdminControlPanel.Attributes.Add("style", "display:block");
                }
                else
                {
                   // divAdminControlPanel.Attributes.Add("style", "display:none");
                }
            }
            SessionTracker sessionTracker = (SessionTracker)Session["Tracker"];
            if (string.IsNullOrEmpty(sessionTracker.PortalID))
            {
                sessionTracker.PortalID = GetPortalID.ToString();
                sessionTracker.Username = GetUsername;
                SageFrameConfig sfConfig = new SageFrameConfig();
                sessionTracker.InsertSessionTrackerPages = sfConfig.GetSettingsByKey(SageFrameSettingKeys.InsertSessionTrackingPages);
                SageFrame.Web.SessionLog SLog = new SageFrame.Web.SessionLog();
                SLog.SessionTrackerUpdateUsername(sessionTracker, GetUsername, GetPortalID.ToString());                
                Session["Tracker"] = sessionTracker;
            }
        }

        private void BindModuleControls()
        {
            string preFix = string.Empty;
            string paneName = string.Empty;
            string ControlSrc = string.Empty;
            string phdContainer = string.Empty;
            string PageSEOName = string.Empty;
            SageUserControl suc = new SageUserControl();
           
            string PageName = PagePath;
            if (PagePath == null)
            {
                string PageUrl = Request.RawUrl;
                PageName = Path.GetFileNameWithoutExtension(PageUrl);
            }
            else
            {
                PageName = PagePath;
            }
            suc.PagePath = PageName;
            if (Request.QueryString["pgnm"] != null)
            {
                PageSEOName = Request.QueryString["pgnm"].ToString();
            }
            else
            {
                PageSEOName = GetPageSEOName(PageName);
            }
            //:TODO: Need to get controlType and pageID from the selected page from routing path
            //string controlType = "0";
            //string pageID = "2";
            string redirecPath = string.Empty;
            if (PageSEOName != string.Empty)
            {
                DataSet dsPageSettings = new DataSet();
                SageFrameConfig sfConfig = new SageFrameConfig();
                dsPageSettings = sfConfig.GetPageSettingsByPageSEONameForAdmin("1", PageSEOName, GetUsername);
                if (bool.Parse(dsPageSettings.Tables[0].Rows[0][0].ToString()) == true)
                {
                    if (bool.Parse(dsPageSettings.Tables[0].Rows[0][1].ToString()) == true)
                    {
                        // Get ModuleControls data table
                        DataTable dtPages = dsPageSettings.Tables[1];
                        if (dtPages != null && dtPages.Rows.Count > 0)
                        {
                            OverridePageInfo(dtPages);
                        }

                        // Get ModuleDefinitions data table
                        DataTable dtPageModule = dsPageSettings.Tables[2];
                        if (dtPageModule != null && dtPageModule.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtPageModule.Rows.Count; i++)
                            {

                                paneName = dtPageModule.Rows[i]["PaneName"].ToString();
                                if (string.IsNullOrEmpty(paneName))
                                    paneName = "ContentPane";
                                string UserModuleID = dtPageModule.Rows[i]["UserModuleID"].ToString();
                                ControlSrc = "/" + dtPageModule.Rows[i]["ControlSrc"].ToString();
                                string SupportsPartialRendering = dtPageModule.Rows[i]["SupportsPartialRendering"].ToString();
                                PlaceHolder phdPlaceHolder = (PlaceHolder)this.FindControl(paneName);

                                if (paneName.ToLower().Equals("navigation")) { divNavigation.Attributes.Add("style", "display:block"); }
                                if (paneName.ToLower().Equals("middlemaincurrent")) { divRight.Attributes.Add("style", "display:block"); }
                                if (paneName.ToLower().Equals("cpanel")) { divBottompanel.Attributes.Add("style", "display:block"); }
                                if (paneName.ToLower().Equals("lefta")) { divLeft.Attributes.Add("style", "display:block"); }
                               

                                if (phdPlaceHolder != null)
                                {
                                    bool status=LoadModuleInfo(phdPlaceHolder, int.Parse(UserModuleID),0);
                                    phdPlaceHolder = LoadControl(i.ToString(), bool.Parse(SupportsPartialRendering), phdPlaceHolder, ControlSrc, paneName, UserModuleID,"","",false,new HtmlGenericControl("div"),new HtmlGenericControl("span"),false);
                                    if (!status) { LoadModuleInfo(phdPlaceHolder, int.Parse(UserModuleID), 1); }
                                }                              
                            }
                        }
                    } 
                    else
                    {
                        if (IsUseFriendlyUrls)
                        {
                            if (GetPortalID > 1)
                            {
                              
                                    redirecPath =
                                        ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" +
                                                   sfConfig.GetSettingsByKey(
                                                       SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
                              
                            }
                            else
                            {
                             
                                  redirecPath = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
                              
                            }
                        }
                        else
                        {
                            redirecPath = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible));
                        }
                        Response.Redirect(redirecPath);
                    }
                }
                else
                {
                    if (IsUseFriendlyUrls)
                    {
                        if (GetPortalID>1)
                        {
                            redirecPath = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                        }
                        else
                        {
                            redirecPath = ResolveUrl("~/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                        }
                    }
                    else
                    {
                        redirecPath = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound));
                    }
                    Response.Redirect(redirecPath);
                }
            }
          
          
        }

        private void LoadControl(PlaceHolder ContainerControl, string controlSource)
        {
            UserControl ctl = this.Page.LoadControl(controlSource) as UserControl;
            ctl.EnableViewState = true;
            ContainerControl.Controls.Add(ctl);
        }

        private string GetProfileLink(SageFrameConfig sfConfig)
        {
            string profileURL = "";
            if (IsUseFriendlyUrls)
            {
                if (GetPortalID > 1)
                {
                    profileURL = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + "User-Profile" + ".aspx");
                }
                else
                {
                    profileURL = ResolveUrl("~/Admin/" + "User-Profile" + ".aspx");
                }
            }
            else
            {
                profileURL = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + "User-Profile");
            }
            return profileURL;
        }

        private bool LoadModuleInfo(PlaceHolder Container,int UserModuleID,int position)
        {
            bool status = false;
            ModuleMessageInfo objMessage = ModuleMessageController.GetModuleMessageByUserModuleID(UserModuleID, GetCurrentCulture());
            if (objMessage != null)
            {
                if (objMessage.IsActive)
                {
                    if (objMessage.MessagePosition == position)
                    {
                        string modeStyle = "sfPersist";
                        switch (objMessage.MessageMode)
                        {
                            case 0:
                                modeStyle = "sfPersist";
                                break;
                            case 1:
                                modeStyle = "sfSlideup";
                                break;
                            case 2:
                                modeStyle = "sfFadeout";
                                break;
                        }
                        string messageTypeStyle = "sfInfo";
                        switch (objMessage.MessageType)
                        {
                            case 0:
                                messageTypeStyle = "sfInfo";
                                break;
                            case 1:
                                messageTypeStyle = "sfWarning";
                                break;
                        }
                        string totalStyle = string.Format("{0} {1}", modeStyle, messageTypeStyle);
                        HtmlGenericControl moduleDiv = new HtmlGenericControl("div");
                        moduleDiv.Attributes.Add("class", "sfModuleinfo");
                        StringBuilder sb = new StringBuilder();
                        string CloseForEver = string.Format("close_{0}", UserModuleID);
                        sb.Append("<div class='" + totalStyle + "'><div class='sfLinks'><a class='sfClose' href='#'>Close</a>   <a class='sfNclose' id='"+CloseForEver+"' href='#'>Close and Never Show Again</a></div>");
                        sb.Append(objMessage.Message);
                        sb.Append("</div>");
                        moduleDiv.InnerHtml = sb.ToString();
                        Container.Controls.Add(moduleDiv);
                        status = true;
                    }
                }
            }
            return status;

           
        }

        #region SageFrameRoute Members

        public string PagePath
        {
            get;
            set;
        }

        public string PortalSEOName
        {
            get;
            set;
        }
        public string UserModuleID
        { 
            get; 
            set; 
        }
        public string ControlType
        {
            get;
            set;
        }
		public string ControlMode { get; set; }
        public string Key { get; set; }
        #endregion

        public override void ShowMessage(string MessageTitle, string Message, string CompleteMessage, bool isSageAsyncPostBack, SageMessageType MessageType)
        {
         
            string strCssClass = GetMessageCssClass(MessageType);
            int Cont = this.Page.Controls.Count;           
            ControlCollection lstControls = Page.FindControl("form1").Controls;
           
                
                    PlaceHolder phd = Page.FindControl("message") as PlaceHolder;
                    if(phd!=null)
                    {
                        foreach (Control c in phd.Controls)
                        {
                            
                                    if (c.GetType().FullName.ToLower() == "ASP.Controls_message_ascx".ToLower())
                                    {
                                        SageUserControl tt = (SageUserControl)c;
                                        tt.Modules_Message_ShowMessage(tt, MessageTitle, Message, CompleteMessage, isSageAsyncPostBack, MessageType, strCssClass);
                                        
                                      
                                    }
                                
                            
                        }
                    
                }
            
        }

      

       
          

    

    
    }
}
