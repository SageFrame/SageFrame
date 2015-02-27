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
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SageFrame.ErrorLog;
using SageFrame.Web;
using SageFrame.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using SageFrame.Web.Common.SEO;
using SageFrame.Web.Utilities;
using System.Collections;
using SageFrame.Common;
using SageFrame.Templating;
using System.Text;
using System.IO;
//using AjaxControlToolkit;

namespace SageFrame.Web
{
    public class SageUserControl : System.Web.UI.UserControl
    {
        int PortalID = 1;
		int StoreID = 1;
        int CustomerID = 0;
        string PortalSEOName = string.Empty;
        public string SageUserModuleID
        {
            get
            {
                if (ViewState["__SageUserModuleID"] != null)
                {
                    return ViewState["__SageUserModuleID"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                ViewState["__SageUserModuleID"] = value;
            }
        }
        private static string _PagePath = string.Empty;
        public string PagePath
        {
            get { return _PagePath; }
            set { _PagePath = value; }
        }
        public SageUserControl()
        {
        }
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Session["SageUICulture"] = Thread.CurrentThread.CurrentUICulture;
            Session["SageCulture"] = Thread.CurrentThread.CurrentCulture;
        }
        protected string GetCurrentUICulture()
        {
            return Thread.CurrentThread.CurrentUICulture.ToString();
        }
        protected string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.ToString();
        }
        public string GetSageMessage(string ModuleName, string MessageNode)
        {
            try
            {
                return SageMessage.ProcessSageMessage(CultureInfo.CurrentCulture.Name, ModuleName, MessageNode);
            }
            catch (Exception)
            {                
                return string.Empty;
            }
        }

        protected void ShowMessage(string MessageTitle, string Message, string CompleteMessage, SageMessageType MessageType)
        {
            ScriptManager scp = (ScriptManager)this.Page.FindControl("ScriptManager1");
            if (scp != null)
            {
                bool isSageAsyncPostBack = false;
                if (scp.IsInAsyncPostBack)
                {
                    isSageAsyncPostBack = true;
                }

                if (this.Page == null)
                    return;

                Page SagePage = this.Page;
                if (SagePage == null)
                    return;

                PageBase mSagePage = SagePage as PageBase;
                if (mSagePage != null)
                    mSagePage.ShowMessage(MessageTitle, Message, CompleteMessage, isSageAsyncPostBack, MessageType);
            }
        }
        public string GetUserImage
        {
            get
            {
                try
                {
                    MembershipUser user = Membership.GetUser();
                    string userImage = "";

                    if (user != null && user.UserName != "anonymoususer")
                    {

                        if (HttpContext.Current.Session["SageFrame.UserProfilePic"] != null && HttpContext.Current.Session["SageFrame.UserProfilePic"].ToString() != "")
                        {
                            userImage = HttpContext.Current.Session["SageFrame.UserProfilePic"].ToString();
                        }
                        return string.Format("~/Modules/Admin/UserManagement/UserPic/{0}", userImage);


                    }
                    else
                    {
                        return "Image is not available";
                    }
                }
                catch
                {
                    return "Image is not available";
                }
            }
        }


        //protected void ShowMessage(string MessageTitle, string Message, string CompleteMessage, SageMessageType MessageType)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append("$(function(){$('div.sfMessage img.delete').live('click',function(){$('div.sfMessage').slideUp('slow');});");
        //    sb.Append("$('div.sfMessagewrapper').delay(4500).slideUp('slow',function(){$(this).remove();}); });");
        //    sb.Append("</script>");

        //    string styledclass="";
        //    string messageicon=string.Format("{0}/Administrator/Templates/Default/images/icon.png",GetApplicationName);
        //    switch (MessageType.ToString())
        //    {
        //        case "Success":
        //            styledclass="sfMessage sfSuccessmsg";
        //            messageicon = string.Format("{0}/Administrator/Templates/Default/images/icon2.png", GetApplicationName);
        //            break;
        //        case "Error":
        //            styledclass = "sfMessage sfErrormsg";
        //            messageicon=string.Format("{0}/Administrator/Templates/Default/images/icon3.png",GetApplicationName);
        //            break;
        //        case "Alert":
        //            styledclass = "sfMessage sfAlertmsg";
        //            messageicon=string.Format("{0}/Administrator/Templates/Default/images/icon.png",GetApplicationName);
        //            break;
        //        default:
        //            styledclass="sfMessage";
        //            break;

        //    }
        //    StringBuilder messagewrapper = new StringBuilder();
        //    messagewrapper.Append("<div class='" + styledclass + "'>");           
        //    messagewrapper.Append("<span  id='spnMessage' runat='server'>" + Message + "</span>");
        //    messagewrapper.Append("<img class='delete' src='/template/Administrator/Templates/Default/images/delete.png' alt='delete' /></div>");

          
        //    HtmlGenericControl spnMessage = Page.FindControl("divMessage") as HtmlGenericControl;
        //    spnMessage.InnerHtml = messagewrapper.ToString();
        //    this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "test", sb.ToString()); 
        //}

       

        public bool IsControlPostBack
        {
            get
            {
                bool retValue = false;
                if (ViewState["IsControlPostBack"] != null)
                {
                    retValue = true;
                }
                return retValue;
            }
            set { ViewState["IsControlPostBack"] = value; }
        }

        public string GetApplicationName
        {
            get
            {
                return (Request.ApplicationPath=="/"?"":Request.ApplicationPath);
            }
        }

        public string GetTemplateImageUrl(string imageName, bool isServerControl)
        {
            string path = string.Empty;
            if (isServerControl == true)
            {
                path = string.Format("~/Administrator/Templates/Default/images/{0}", imageName);
            }
            else
            {
                path = this.Page.ResolveUrl(string.Format("~/Administrator/Templates/images/{0}", imageName));
            }
            return path;
        }
        public string GetAdminImageUrl(string imageName, bool isServerControl)
        {
            string path = string.Empty;
            if (isServerControl == true)
            {
                path = string.Format("~/Administrator/Templates/Default/images/{0}",imageName);
            }
            else
            {
                path = this.Page.ResolveUrl(string.Format("~/Administrator/Templates/images/{0}",imageName));
            }
            return path;
        }

        public Int32 GetPortalID
        {
            get
            {
                if (HttpContext.Current.Session["SageFrame.PortalID"] != null && HttpContext.Current.Session["SageFrame.PortalID"].ToString() != "")
                {
                    PortalID = Int32.Parse(HttpContext.Current.Session["SageFrame.PortalID"].ToString());
                }
                return PortalID;
            }
        }

        public void SetPortalID(int portalID)
        {
            PortalID = portalID;
        }
		
		public Int32 GetStoreID
        {
            get
            {
                if (HttpContext.Current.Session["SageFrame.StoreID"] != null && HttpContext.Current.Session["SageFrame.StoreID"].ToString() != "")
                {
                    StoreID = Int32.Parse(HttpContext.Current.Session["SageFrame.StoreID"].ToString());
                }
                return StoreID;
            }
        }

        public void SetStoreID(int storeID)
        {
            StoreID = storeID;
        }

        public Int32 GetCustomerID
        {
            get
            {
                if (HttpContext.Current.Session["SageFrame.CustomerID"] != null && HttpContext.Current.Session["SageFrame.CustomerID"].ToString() != "")
                {
                    CustomerID = Int32.Parse(HttpContext.Current.Session["SageFrame.CustomerID"].ToString());
                }
                return CustomerID;
            }
        }

        public void SetCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

        public string GetUsername
        {
            get
            {
                try
                {
                    MembershipUser user = Membership.GetUser();
                    if (user != null)
                    {
                        return user.UserName;
                    }
                    else
                    {
                        return "anonymoususer";
                    }
                }
                catch
                {
                    return "anonymoususer";
                }
            }
        }

        public string TemplateName
        {
            get
            {
                try
                {
                    if (Session["SageFrame.ActiveTemplate"] != null && Session["SageFrame.ActiveTemplate"].ToString() != "")
                    {
                        return Session["SageFrame.ActiveTemplate"].ToString();
                    }
                    else
                    {
                        return (TemplateController.GetActiveTemplate(GetPortalID).TemplateSeoName);
                    }
                }
                catch
                {
                    return "Default";
                }
            }
        }

        public string GetActiveAdminTheme
        {
            get
            {
                try
                {
                    if (Session["SageFrame.AdminTheme"] != null)
                    {
                        return Session["SageFrame.AdminTheme"].ToString();
                    }
                    else
                    {
                        return (ThemeHelper.GetAdminTheme(GetPortalID, GetUsername));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public PresetInfo GetPresetDetails
        {
            get
            {
                try
                {
                    if (Session["SageFrame.ActivePreset"] != null)
                    {
                        return Session["SageFrame.ActivePreset"] as PresetInfo;
                    }
                    else
                    {
                        return (PresetHelper.LoadActivePagePreset(TemplateName, GetPageSEOName(Request.Url.ToString())));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public void SetActiveTheme(string newtheme)
        {          
          
          PresetInfo preset=GetPresetDetails;
          preset.ActiveTheme=newtheme;
          Session["SageFrame.ActivePreset"] = preset;
          PresetHelper.UpdatePreset(preset,TemplateName);
                   
        }
        public void SetActiveWidth(string newwidth)
        {

            PresetInfo preset = GetPresetDetails;
            preset.ActiveWidth = newwidth;
            Session["SageFrame.ActivePreset"] = preset;
            PresetHelper.UpdatePreset(preset, TemplateName);

        }

        public string GetPageSEOName(string pagePath)
        {
            string SEOName = string.Empty;
            if (string.IsNullOrEmpty(pagePath))
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
                SEOName = sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage);
            }
            else
            {
                string[] pagePaths = pagePath.Split('/');
                SEOName = pagePaths[pagePaths.Length - 1];
                if (string.IsNullOrEmpty(SEOName))
                {
                    SEOName = pagePaths[pagePaths.Length - 2];
                }
                SEOName = SEOName.Replace(".aspx", "");

            }
            return SEOName;
        }     

        public void ProcessCancelRequestBase(string RedirectUrl)
        {           
            string strURL = string.Empty;
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
            if (!IsUseFriendlyUrls)
            {
                string[] arrUrl;
                arrUrl = Request.RawUrl.Split('&');
                if (arrUrl.Length > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        strURL += arrUrl[i] + "&";                        
                    }
                   strURL = strURL.Remove(strURL.LastIndexOf('&'));
                }
            }
            else
            {
                if (RedirectUrl.Contains("?"))
                {
                    string[] d = RedirectUrl.Split('?');
                    strURL = d[0];                    
                }
            }
            HttpContext.Current.Response.Redirect(strURL, false);
        }

        protected string GetPortalSEOName
        {
            get
            {
                if (HttpContext.Current.Session["SageFrame.PortalSEOName"] != null && HttpContext.Current.Session["SageFrame.PortalSEOName"].ToString() != "")
                {
                    PortalSEOName = HttpContext.Current.Session["SageFrame.PortalSEOName"].ToString();
                }
                return PortalSEOName;
            }
        }

        public void SetPortalSEOName(string portalSEOName)
        {
            PortalSEOName = portalSEOName;
        }

        public void ProcessSourceControlUrlBase(string rawUrl, string controlPath, string parameter)
        {
            //Added For unique Control ID generation
            //int controlUniqueIDPrefix = GetRandomNumber(System.Int32.Parse(DateTime.Now.ToString()), System.Int32.MaxValue);

            string strURL = string.Empty;
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
            if (!IsUseFriendlyUrls)
            {
                if (rawUrl.Contains(parameter))
                {
                    rawUrl = rawUrl.Remove(rawUrl.IndexOf(parameter) - 1);
                }
                strURL = rawUrl + "&" + parameter + "=" + controlPath;
            }
            else
            {
                if (rawUrl.Contains("?"))
                {
                    string[] d = rawUrl.Split('?');
                    strURL = d[0];
                    strURL = strURL + "?" + parameter + "=" + controlPath;
                }
                else
                {
                    strURL = rawUrl + "?" + parameter + "=" + controlPath;
                }
            }
            HttpContext.Current.Response.Redirect(strURL, false);
        }

        //protected void SelectTab(TabContainer tabContainer, string TabID)
        //{
        //    if (tabContainer == null)
        //        throw new ArgumentNullException("tabContainer");

        //    if (!String.IsNullOrEmpty(TabID))
        //    {
        //        AjaxControlToolkit.TabPanel tab = tabContainer.FindControl(TabID) as AjaxControlToolkit.TabPanel;
        //        if (tab != null)
        //        {
        //            tabContainer.ActiveTab = tab;
        //        }
        //    }
        //}

        //protected string GetActiveTabID(TabContainer tabContainer)
        //{
        //    if (tabContainer == null)
        //        throw new ArgumentNullException("tabContainer");

        //    if (tabContainer.ActiveTab != null)
        //        return tabContainer.ActiveTab.ID;

        //    return string.Empty;
        //}

        //public string GetUserModuleID(TabContainer tabContainer)
        //{
        //    if (tabContainer == null)
        //        throw new ArgumentNullException("tabContainer");

        //    if (tabContainer.ActiveTab != null)
        //        return tabContainer.ActiveTab.ID;

        //    return string.Empty;
        //}

        public string GetCurrentCultureName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name;
                //return "hi-IN";
            }
        }

        public void Modules_Message_ShowMessage(Control ctl, string MessageTitle, string Message, string CompleteMessage, bool isSageAsyncPostBack, SageMessageType MessageType, string strCssClass)
        {

            Label lblUdpSageMesageTitle = ctl.FindControl("lblUdpSageMesageTitle") as Label;
            Label lblUdpSageMesageCustom = ctl.FindControl("lblUdpSageMesageCustom") as Label;
            Label lblUdpSageMesageDetail = ctl.FindControl("lblUdpSageMesageDetail") as Label;
            System.Web.UI.HtmlControls.HtmlGenericControl divUdpSageMessage = ctl.FindControl("divUdpSageMessage") as System.Web.UI.HtmlControls.HtmlGenericControl;


            isSageAsyncPostBack = true;
            bool isudpSageMessageVisible = false;
            if (isSageAsyncPostBack)
            {

                if (lblUdpSageMesageTitle != null && lblUdpSageMesageCustom != null && lblUdpSageMesageDetail != null && divUdpSageMessage != null)
                {
                    //lblUdpSageMesageTitle.Text = MessageTitle;
                    //if (MessageTitle == string.Empty)
                        lblUdpSageMesageTitle.Visible = false;

                    lblUdpSageMesageCustom.Text = Message;
                    if (Message == string.Empty)
                        lblUdpSageMesageCustom.Visible = false;

                    lblUdpSageMesageDetail.Text = CompleteMessage;
                    if (CompleteMessage == string.Empty)
                        lblUdpSageMesageDetail.Visible = false;

                    divUdpSageMessage.Attributes.Add("class", strCssClass);
                    isudpSageMessageVisible = true;
                }
            }

            System.Web.UI.HtmlControls.HtmlGenericControl divUdpMessage = ctl.FindControl("divUdpMessage") as System.Web.UI.HtmlControls.HtmlGenericControl;

            if (divUdpMessage != null)
            {
                if (isudpSageMessageVisible == true)
                {
                    divUdpMessage.Style.Add("display", "block");

                }

            }
        }

        /// <summary>
        /// File Url must be in "~/" nature
        /// like ~/js/scriptfile.js
        /// Note: Use only when script is required in head section other wise use IncludeScriptFile function
        /// </summary>
        /// <param name="FileUrl">File Url must be in "~/" nature</param>
        public void IncludeScriptFileInHeadSection(string FileUrl)
        {
            Literal LitSageScript = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
            if (LitSageScript != null)
            {
                string strScripts = string.Empty;
                if (FileUrl != string.Empty)
                {
                    strScripts += "<script src=\"" + ResolveUrl(FileUrl) + "\" type=\"text/javascript\"></script>";
                }
                if (!LitSageScript.Text.Contains(strScripts))
                {
                    LitSageScript.Text += strScripts;
                }
            }
        }

        /// <summary>
        /// File Url must be in "~/" nature
        /// like ~/js/scriptfile.js
        /// Note:
        /// For this block of code your page musth have Literal of ID "LitSageScript"
        /// </summary>
        /// <param name="FileUrls"></param>
        public void IncludeScriptFile(ArrayList FileUrls)
        {
            Literal LitSageScript = this.Page.FindControl("LitSageScript") as Literal;            
            if (LitSageScript != null)
            {
                if (FileUrls.Count > 0)
                {
                    for (int i = 0; i < FileUrls.Count; i++)
                    {
                        string strScripts = string.Empty;
                        strScripts = "<script src=\"" + ResolveUrl(FileUrls[i].ToString()) + "\" type=\"text/javascript\"></script>";
                        if (!LitSageScript.Text.Contains(strScripts))
                        {
                            LitSageScript.Text += strScripts;
                        }
                    }
                }                
            }
        }

        /// <summary>
        /// File Url must be in "~/" nature
        /// like ~/js/scriptfile.js
        /// Note:
        /// For this block of code your page musth have Literal of ID "LitSageScript"
        /// </summary>
        /// <param name="FileUrl"></param>
        public void IncludeScriptFile(string FileUrl)
        {
            Literal LitSageScript = this.Page.FindControl("LitSageScript") as Literal;            
            if (LitSageScript != null)
            {
                string strScripts = string.Empty;
                if (FileUrl != string.Empty)
                {
                    strScripts += "<script src=\"" + ResolveUrl(FileUrl) + "\" type=\"text/javascript\"></script>";
                }
                if (!LitSageScript.Text.Contains(strScripts))
                {
                    LitSageScript.Text += strScripts;
                }
            }
        }

        /// <summary>
        /// File Url must be in "~/" nature
        /// "~/Modules/ModuleName/cssfile.css
        /// Note :
        /// For This block of code your page must have Literal of ID "SageFrameModuleCSSlinks"
        /// Use only css file except having name other than module.css, module.css file will automatically inlcude in the file is in
        /// root of module
        /// </summary>
        /// <param name="FileUrl"></param>
        public void IncludeCssFile(string FileUrl)
        {
            Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
            if (SageFrameModuleCSSlinks != null)
            {               
                string linkText = "<link href=\"" + Page.ResolveUrl(FileUrl) + "\" id=\"test\" rel=\"stylesheet\" type=\"text/css\" />";
                if (!SageFrameModuleCSSlinks.Text.Contains(linkText))
                {
                    SageFrameModuleCSSlinks.Text += linkText;
                }
            }

           
        }

        public void RegisterClientScriptToPage(string Key, string Value,bool checkMode)
        {
            if (checkMode)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered(Key))
                {
                    Page.ClientScript.RegisterClientScriptInclude(Key, Value);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptInclude(Key, Value);
            }
        }



        public void IncludeJs(string ModuleName, params string[] files)
        {
            List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
            foreach (string FilePath in files)
            {
                string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
                string FileName = Path.GetFileName(FilePath);
                //if (File.Exists(Server.MapPath(string.Format("~{0}", FilePath))))
                //{
                    if (HttpContext.Current.Session["ModuleJs"] != null)
                    {
                        lstResources = HttpContext.Current.Session["ModuleJs"] as List<CssScriptInfo>;
                    }
                    bool exists = lstResources.Exists(
                                        delegate(CssScriptInfo obj)
                                        {
                                            return (obj.FileName == FileName && obj.ModuleName == ModuleName);
                                        }
                                    );
                    if (!exists)
                    {
                        lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 1, true));
                    }
                //}
            }
            HttpContext.Current.Session["ModuleJs"] = lstResources;
        }
        public void IncludeJs(string ModuleName, bool AllowCompression, params string[] files)
        {
            List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
            foreach (string FilePath in files)
            {
                //if (File.Exists(Server.MapPath(string.Format("~{0}", FilePath))))
                //{
                    string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
                    string FileName = Path.GetFileName(FilePath);
                    if (HttpContext.Current.Session["ModuleJs"] != null)
                    {
                        lstResources = HttpContext.Current.Session["ModuleJs"] as List<CssScriptInfo>;
                    }
                    bool exists = lstResources.Exists(
                                        delegate(CssScriptInfo obj)
                                        {
                                            return (obj.FileName == FileName && obj.ModuleName == ModuleName);
                                        }
                                    );
                    if (!exists)
                    {
                        lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 1, false));
                    }
               // }
            }
            HttpContext.Current.Session["ModuleJs"] = lstResources;
        }
        public void IncludeJsTop(string ModuleName, params string[] files)
        {
            List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
            foreach (string FilePath in files)
            {
                //if (File.Exists(Server.MapPath(string.Format("~{0}", FilePath))))
               // {
                    string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
                    string FileName = Path.GetFileName(FilePath);
                    if (HttpContext.Current.Session["ModuleJs"] != null)
                    {
                        lstResources = HttpContext.Current.Session["ModuleJs"] as List<CssScriptInfo>;
                    }
                    bool exists = lstResources.Exists(
                                        delegate(CssScriptInfo obj)
                                        {
                                            return (obj.FileName == FileName && obj.ModuleName == ModuleName);
                                        }
                                    );
                    if (!exists)
                    {
                        lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 0));
                    }
               // }
            }
            HttpContext.Current.Session["ModuleJs"] = lstResources;
        }
        public void IncludeJsTop(string ModuleName, bool AllowCompression, params string[] files)
        {
            List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
            foreach (string FilePath in files)
            {
                //if (File.Exists(Server.MapPath(string.Format("~{0}", FilePath))))
                // {
                string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
                string FileName = Path.GetFileName(FilePath);
                if (HttpContext.Current.Session["ModuleJs"] != null)
                {
                    lstResources = HttpContext.Current.Session["ModuleJs"] as List<CssScriptInfo>;
                }
                bool exists = lstResources.Exists(
                                    delegate(CssScriptInfo obj)
                                    {
                                        return (obj.FileName == FileName && obj.ModuleName == ModuleName);
                                    }
                                );
                if (!exists)
                {
                    lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 0,false));
                }
                // }
            }
            HttpContext.Current.Session["ModuleJs"] = lstResources;
        }
        public void IncludeCss(string ModuleName, params string[] files)
        {
            List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
            foreach (string FilePath in files)
            {
                string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
                string FileName = Path.GetFileName(FilePath);
                if (HttpContext.Current.Session["ModuleCss"] != null)
                {
                    lstResources = HttpContext.Current.Session["ModuleCss"] as List<CssScriptInfo>;
                }
                bool exists = lstResources.Exists(
                                    delegate(CssScriptInfo obj)
                                    {
                                        return (obj.FileName == FileName && obj.ModuleName == ModuleName);
                                    }
                                );
                if (!exists)
                {
                    lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 1));
                }
            }
            HttpContext.Current.Session["ModuleCss"] = lstResources;
        }
        //public void IncludeCss(string ModuleName, params string[] files)
        //{
        //    List<CssScriptInfo> lstResources = new List<CssScriptInfo>();
        //    foreach (string FilePath in files)
        //    {
        //        if (File.Exists(Server.MapPath(string.Format("~{0}", FilePath))))
        //        {
        //            string folderPath = FilePath.LastIndexOf("/") > -1 ? FilePath.Substring(0, FilePath.LastIndexOf("/") + 1) : "";
        //            string FileName = Path.GetFileName(FilePath);
        //            if (HttpContext.Current.Session["ModuleCss"] != null)
        //            {
        //                lstResources = HttpContext.Current.Session["ModuleCss"] as List<CssScriptInfo>;
        //            }
        //            bool exists = lstResources.Exists(
        //                                delegate(CssScriptInfo obj)
        //                                {
        //                                    return (obj.FileName == FileName && obj.ModuleName == ModuleName);
        //                                }
        //                            );
        //            if (!exists)
        //            {
        //                lstResources.Add(new CssScriptInfo(ModuleName, FileName, folderPath, 1));
        //            }
        //        }
        //    }
        //    HttpContext.Current.Session["ModuleCss"] = lstResources;
        //}

       
    }
}
