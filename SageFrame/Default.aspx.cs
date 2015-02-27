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
using System.Web.UI.HtmlControls;
using SageFrame.Web.Common.SEO;
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using SageFrame.Templating;
using SageFrame.ModuleControls;
using SageFrame.Templating.xmlparser;
using SageFrame.Common;
using SageFrame.Security;


namespace SageFrame
{
    public partial class _Default : PageBase, SageFrameRoute
    {
        public string ControlPath = string.Empty;
        bool IsUseFriendlyUrls = true;
        public static string path = string.Empty,appPath=string.Empty,layoutcontrol=string.Empty;
        public static int ModuleId = 0;
        public string prevpage,templatefavicon="favicon.ico";
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                SetPortalCofig();
                BuildLayoutControl();
                SetFavIcon();
                
            }
            catch (Exception ex)
            {
                Session["TemplateError"] = ex;
                HttpContext.Current.Response.Redirect(ResolveUrl("~/Sagin/Fallback.aspx"));
               
            }
            SageInitPart();
            ManageSSLConnection();
            appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar1", " var SageFrameAppPath='" + appPath + "';", true);
        }
        
        public List<SecurePageInfo> GetSecurePage(int portalID, string culture)
        {
            try
            {
                List<SecurePageInfo> portalRoleCollection = new List<SecurePageInfo>();
                SQLHandler sqLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParaMeter = new List<KeyValuePair<string, object>>();                
                ParaMeter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                ParaMeter.Add(new KeyValuePair<string, object>("@CultureName", culture));
                return sqLH.ExecuteAsList<SecurePageInfo>("usp_GetAllSecurePages", ParaMeter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public void BuildLayoutControl()
        {
           
                string activeTemplate = GetActiveTemplate;
                string pagename = Request.Url.ToString();
                SageFrameConfig sfConfig = new SageFrameConfig();
                pagename = Path.GetFileNameWithoutExtension(pagename);
                pagename = pagename.ToLower().Equals("default") ? sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) : pagename;               
                layoutcontrol = IsHandheld() ? PresetHelper.LoadHandheldControl(activeTemplate) : PresetHelper.LoadActivePresetForPage(activeTemplate, pagename);
                if (!File.Exists(Server.MapPath(layoutcontrol)))
                {
                    PresetInfo objPreset = GetPresetDetails;
                    if (IsHandheld())
                    {
                        LayoutHelper.CreateHandheldLayoutControls(GetActiveTemplate);
                    }
                    else
                    {
                        LayoutHelper.CreateLayoutControls(GetActiveTemplate, objPreset);
                    }
                }

                LoadControl(pchWhole, layoutcontrol, 3);
                LoadMessageControl();
           
           
          
        }

        public void LoadMessageControl()
        {
            UserControl uc = pchWhole.FindControl("lytA") as UserControl;
            PlaceHolder phdPlaceHolder = uc.FindControl("pch_message") as PlaceHolder;
            if (phdPlaceHolder != null)
            {
                LoadControl(phdPlaceHolder, "~/Controls/Message.ascx");
            }
        }
        public void InitPositions(string layout)
        {
            layout = Path.GetFileNameWithoutExtension(layout);
            string filePath = Decide.IsTemplateDefault(GetActiveTemplate)
                              ? string.Format("{0}/Layouts/{1}.xml", Utils.GetTemplatePath_Default("Default"), layout)
                              : string.Format("{0}/Layouts/{1}.xml", Utils.GetTemplatePath(GetActiveTemplate), layout);
            XmlParser _parser = new XmlParser();
            List<string> lstPositions = _parser.GetLayoutPositions(filePath, "layout/section");
            foreach (string pos in lstPositions)
            {

                string controlid = string.Format("pch_{0}", pos.ToLower());
                UserControl uc = pchWhole.FindControl("lytA") as UserControl;
                PlaceHolder phd = uc.FindControl(controlid) as PlaceHolder;
                if (phd != null)
                {
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "sfUsermoduletitle");
                    span.InnerText = pos;
                    phd.Controls.Add(span);
                }

            }


        }

        public void SetFavIcon()
        {
            templatefavicon = Decide.IsTemplateDefault(GetActiveTemplate) ? ResolveUrl("~/favicon.ico") : ResolveUrl(string.Format("~/Templates/{0}/favicon.ico", GetActiveTemplate));
        }




        private void SageInitPart()
        {
            try
            {
                string IsInstalled = Config.GetSetting("IsInstalled").ToString();
                string InstallationDate = Config.GetSetting("InstallationDate").ToString();
                if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
                {
                    if (!(Request.CurrentExecutionFilePath.Contains(".gif") || Request.CurrentExecutionFilePath.Contains(".jpg") || Request.CurrentExecutionFilePath.Contains(".png")))
                    {
                        //SetPortalCofig();
                        InitializePage();
                        SageFrameConfig sfConfig = new SageFrameConfig();
                        IsUseFriendlyUrls = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
                        SetAdminParts();
                        BindModuleControls();
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect(ResolveUrl("~/Install/InstallWizard.aspx"));
                }
            }
            catch(Exception ex)
            {
                //throw ex;
            }
        }

        
        private void SetAdminParts()
        {
            //HtmlGenericControl divAdminControlPanel = lytLayout.FindControl("divAdminControlPanel") as HtmlGenericControl;
            if (HttpContext.Current.User != null)
            {
                MembershipUser user = Membership.GetUser();
                FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;

                if (identity != null)
                {
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    int LoggedInPortalID = ticket.UserData != "" ? int.Parse(ticket.UserData.ToString()) : 0;

                    if (user != null && user.UserName!="")
                    {
                        string[] sysRoles = SystemSetting.SUPER_ROLE;
                        if ((GetPortalID == LoggedInPortalID || Roles.IsUserInRole(user.UserName,sysRoles[0])) && LoggedInPortalID!=0)
                        {                           
                            RoleController _role = new RoleController();
                            string userinroles = _role.GetRoleNames(GetUsername, LoggedInPortalID);
                            if (userinroles != "" || userinroles != null)
                            {
                                divAdminControlPanel.Visible = true;
                                LeaveMargin();
                                InitPositions(layoutcontrol);
                                foreach (string role in sysRoles)
                                {
                                    if (Roles.IsUserInRole(user.UserName, role))
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                divAdminControlPanel.Visible = false;
                            }
                        }
                        else
                        {
                            divAdminControlPanel.Visible = false;
                        }
                    }
                    else
                    {
                        divAdminControlPanel.Visible = false;
                    }
                }
                else
                {
                    divAdminControlPanel.Visible = false;
                }
            }
            if (IsHandheld())
            {
                divAdminControlPanel.Visible = false;
            }
           
        }

        private void SetPortalCofig()
        {
            Hashtable hstPortals = GetPortals();
            SageUserControl suc = new SageUserControl();
            int portalID = 1;
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
            string tempName = TemplateController.GetActiveTemplate(GetPortalID).TemplateSeoName;
            string tempPath=Decide.IsTemplateDefault(tempName)?Utils.GetTemplatePath_Default(tempName):Utils.GetTemplatePath(tempName);
            if (!Directory.Exists(tempPath)) { tempName = "default"; }
            Session["SageFrame.ActiveTemplate"] = tempName;
            Session["SageFrame.ActivePreset"] = PresetHelper.LoadActivePagePreset(tempName, GetPageSEOName(Request.Url.ToString()));

            suc.SetPortalID(portalID);
            SetPortalID(portalID);
            if (HttpContext.Current.User != null)
            {
                if (Membership.GetUser() != null)
                {
                    string strRoles = string.Empty;                    
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
            if (!(Request.CurrentExecutionFilePath.Contains(".gif") || Request.CurrentExecutionFilePath.Contains(".jpg") || Request.CurrentExecutionFilePath.Contains(".png")))
            {
                SagePageLoadPart();               
                
            }
        }

        
        private void SagePageLoadPart()
        {
            try
            {
                if (!IsPostBack)
                {
                    SageFrameConfig sfConfig = new SageFrameConfig();
                    string sageNavigateUrl = string.Empty;
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
            catch
            {
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
            if (PagePath != null)
            {
                suc.PagePath = PagePath;
            }
            else
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
               suc.PagePath= sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage)+".aspx";
            }
            if (Request.QueryString["pgnm"] != null)
            {
                PageSEOName = Request.QueryString["pgnm"].ToString();
            }
            else
            {
                PageSEOName = GetPageSEOName(PagePath);
            }

           
            
            //:TODO: Need to get controlType and pageID from the selected page from routing path
            //string controlType = "0";
            //string pageID = "2";
            string redirecPath = string.Empty;
            if (PageSEOName != string.Empty)
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
                string SEOName = sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage);
              
             
                List<UserModuleInfo> lstUserModules = sfConfig.GetPageModules("1", PageSEOName, GetUsername);
                if (lstUserModules[0].IsPageAvailable)
                {
                    if (lstUserModules[0].IsPageAccessible)
                    {
                        if (lstUserModules.Count > 0)
                        {
                            OverridePageInfo(lstUserModules[0]);

                            int i = 0;

                            foreach (UserModuleInfo usermodule in lstUserModules)
                            {

                                bool handheld_status = bool.Parse(usermodule.IsHandHeld.ToString());
                                if (IsHandheld() == handheld_status)
                                {
                                    paneName = usermodule.PaneName;
                                    paneName = "pch_" + paneName;

                                    if (string.IsNullOrEmpty(paneName))
                                        paneName = "ContentPane";
                                    string UserModuleTitle = usermodule.UserModuleTitle != "" ? usermodule.UserModuleTitle.ToString() : "";

                                    ControlSrc = usermodule.ControlSrc;
                                    string SupportsPartialRendering = usermodule.SupportsPartialRendering.ToString();

                                    string SuffixClass = usermodule.SuffixClass.ToString();
                                    string HeaderText = usermodule.ShowHeaderText ? usermodule.HeaderText : "";

                                    bool ContainsEdit = usermodule.IsEdit;
                                    int ControlCount = usermodule.ControlsCount;
                                    UserControl uc = pchWhole.FindControl("lytA") as UserControl;
                                    PlaceHolder phdPlaceHolder = uc.FindControl(paneName) as PlaceHolder;

                                    SuffixClass = IsUserLoggedIn() || ContainsEdit ? string.Format("sfLogged sfModule{0}", SuffixClass) : string.Format("sfModule{0}", SuffixClass);


                                    if (phdPlaceHolder != null)
                                    {
                                        string TemplateControls = Server.MapPath(string.Format("~/Templates/{0}/modules/{1}", GetActiveTemplate, ControlSrc.Substring(ControlSrc.IndexOf('/'), ControlSrc.Length - ControlSrc.IndexOf('/'))));
                                        ControlSrc = File.Exists(TemplateControls) ? string.Format("/Templates/{0}/modules/{1}", GetActiveTemplate, ControlSrc.Substring(ControlSrc.IndexOf('/'), ControlSrc.Length - ControlSrc.IndexOf('/'))) : string.Format("/{0}", ControlSrc);
                                        phdPlaceHolder = LoadControl(i.ToString(), bool.Parse(SupportsPartialRendering), phdPlaceHolder, ControlSrc, paneName, usermodule.UserModuleID.ToString(), SuffixClass, HeaderText, IsUserLoggedIn(), GetModuleControls(usermodule.UserModuleID, ContainsEdit, ControlCount), GetPaneNameContainer(UserModuleTitle),ContainsEdit);
                                    }
                                    i++;

                                }
                            }
                        }


                        else
                        {

                            if (GetPortalID > 1)
                            {
                                redirecPath = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                            }
                            else
                            {
                                redirecPath = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                            }
                            Response.Redirect(redirecPath);

                           
                        }
                    }
                    else
                    {
                        if (GetPortalID > 1)
                        {
                            redirecPath = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible) + ".aspx");
                        }
                        else
                        {
                            redirecPath = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible) + ".aspx");
                        }
                        Response.Redirect(redirecPath);
                    }
                }
                else
                {
                    //page is not found
                    if (GetPortalID > 1)
                    {
                        redirecPath = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                    }
                    else
                    {
                        redirecPath = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx");
                    }
                    Response.Redirect(redirecPath);
                }
               
            }
           


            SetScreenWidth();

            
        }
        public void LeaveMargin()
        {
            PlaceHolder pchWhole = Page.FindControl("pchWhole") as PlaceHolder;
            UserControl uc = pchWhole.FindControl("lytA") as UserControl;
            HtmlGenericControl div = uc.FindControl("sfOuterWrapper") as HtmlGenericControl;
            div.Attributes.Add("style","margin-top:30px");
        }


        public HtmlGenericControl GetModuleControls(int UserModuleID,bool ContainsEdit,int ControlCount)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            if (ContainsEdit && ControlCount>1)
            {
                div.Attributes.Add("class", "sfModuleControl");
                string url = string.Format("{0}/Sagin/HandleModuleControls.aspx?uid={1}&pid={2}", Request.ApplicationPath == "/" ? "" : Request.ApplicationPath, UserModuleID,GetPortalID);
                string html = "<a class='sfManageControl' href='#' rel='" + url + "'></a>";
                div.InnerHtml = html;
            }
           
            return div;

        }
        public HtmlGenericControl GetPaneNameContainer(string PaneName)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "sfPosition");
            span.InnerHtml = PaneName;
            return span;

        }
        private void LoadControl(PlaceHolder ContainerControl, string controlSource)
        {
            UserControl ctl = this.Page.LoadControl(controlSource) as UserControl;
            ctl.EnableViewState = true;            
            ContainerControl.Controls.Add(ctl);
        }

        private void LoadControl(PlaceHolder ContainerControl, string controlSource,int id)
        {
            UserControl ctl = this.Page.LoadControl(controlSource) as UserControl;
            ctl.EnableViewState = true;
            ctl.ID = "lytA";
            ContainerControl.Controls.Add(ctl);
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

            UserControl uc = pchWhole.FindControl("lytA") as UserControl;          
            PlaceHolder phd = uc.FindControl("pch_message") as PlaceHolder;
            if (phd != null)
            {
                foreach (Control c in phd.Controls)
                {

                    if (c.GetType().FullName.ToLower() == "ASP.controls_message_ascx".ToLower())
                    {
                        SageUserControl tt = (SageUserControl)c;
                        tt.Modules_Message_ShowMessage(tt, MessageTitle, Message, CompleteMessage, isSageAsyncPostBack, MessageType, strCssClass);
                    }


                }

            }

        }

        public void ManageSSLConnection()
        {
            if (Request.CurrentExecutionFilePath.Contains("fonts") || Request.CurrentExecutionFilePath.Contains(".gif") || Request.CurrentExecutionFilePath.Contains(".jpg") || Request.CurrentExecutionFilePath.Contains(".png"))
            {
                if (Session["Ssl"] == null)
                {
                    Session["Ssl"] = "True";
                    //check logic redirect to or not
                    //btn click login and logout prob
                    List<SecurePageInfo> sp = GetSecurePage(GetPortalID, GetCurrentCulture());
                    string pagename = GetPageSEOName(PagePath);
                    if (pagename != "Page-Not-Found")
                    {
                        if (Session["pagename"] != null)
                        {
                            prevpage = Session["pagename"].ToString();
                        }

                        if (prevpage != pagename)
                        {

                            Session["pagename"] = pagename;

                            for (int i = 0; i < sp.Count; i++)
                            {
                                if (pagename.ToLower() == sp[i].SecurePageName.ToString().ToLower())
                                {
                                    if (bool.Parse(sp[i].IsSecure.ToString()))
                                    {
                                        if (!HttpContext.Current.Request.IsSecureConnection)
                                        {
                                            if (!HttpContext.Current.Request.Url.IsLoopback) //Don't check when in development mode (i.e. localhost)
                                            {
                                                Session["prevurl"] = "https";
                                                Response.Redirect(Request.Url.ToString().Replace("http://", "https://"));

                                            }
                                        }
                                    }
                                    else
                                    {
                                        Session["prevurl"] = "http";
                                        Response.Redirect(Request.Url.ToString().Replace("https://", "http://"));
                                    }
                                }
                            }
                        }
                        else if (Session["prevurl"] != null)
                        {

                            if (Session["prevurl"].ToString() != Request.Url.ToString().Split(':')[0].ToString())
                            {
                                for (int i = 0; i < sp.Count; i++)
                                {
                                    if (pagename.ToLower() == sp[i].SecurePageName.ToString().ToLower())
                                    {
                                        if (bool.Parse(sp[i].IsSecure.ToString()))
                                        {
                                            if (!HttpContext.Current.Request.IsSecureConnection)
                                            {
                                                if (!HttpContext.Current.Request.Url.IsLoopback) //Don't check when in development mode (i.e. localhost)
                                                {
                                                    Response.Redirect(Request.Url.ToString().Replace("http://", "https://"));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Response.Redirect(Request.Url.ToString().Replace("https://", "http://"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
