﻿#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SageFrame.Web.Common.SEO;
using System.Web.UI.WebControls;
using SageFrame.Web.Utilities;
using System.Collections;
using SageFrame.Web;
using SageFrame.Shared;
using SageFrame.ErrorLog;
using System.Text;
using SageFrame.Utilities;
using SageFrame.Common;
using System.Xml;
using System.IO;
using SageFrame.Templating;
using SageFrame.Templating.xmlparser;
using SageFrame.Common.Shared;
using SageFrame.Core;
using SageFrame.UserAgent;
using CssJscriptOptimizer.Minifiers;
using System.Text.RegularExpressions;
using SageFrame.PortalSetting;
using SageFrame.Dashboard;
using System.Management;

#endregion

namespace SageFrame.Framework
{
    /// <summary>
    /// The base class which  initializes all the properties and method for the page Load
    /// </summary>
    [Serializable]
    public partial class PageBase : System.Web.UI.Page
    {
        #region "Public Properties"

        //string Comment = "";
        string Description = "";
        string KeyWords = "";
        string Copyright = "";
        string Generator = "";
        string Author = "";
        string SageTitle = "";
        string Refresh = "";
        string Robots = "";
        string ResourceType = "";
        string Distribution = "";
        string RevisitAfter = "";
        string PageEnter = "";

        #endregion

        #region Private Property
        int PortalID = 1;
        string PortalSEOName = string.Empty;
        int StoreID = 1;
        int CustomerID = 0;
        #endregion

        #region "Private Methods"

        /// <summary>
        /// Returns color css path based on active template
        /// </summary>
        /// <param name="activeTemplate"> active template name</param>
        /// <param name="preset">PresetInfo object</param>
        /// <returns>Returns color css path</returns>
        private string cssColorTemplate(string activeTemplate, PresetInfo preset)
        {
            string cssColorTemplate = !IsHandheld() ? Decide.IsTemplateDefault(activeTemplate)
                                            ? string.Format("~/Core/Template/themes/{0}/css/color.css", preset.ActiveTheme)
                                            : string.Format("~/Templates/{0}/themes/{1}/css/color.css", activeTemplate, preset.ActiveTheme)
                                            : string.Format("~/Templates/{0}/css/handheld/color.css", TemplateName);
            return cssColorTemplate;
        }

        /// <summary>
        /// Generates uniqueID based on date
        /// </summary>
        /// <returns>Unique ID</returns>
        private string GenerateUniqueId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>
        /// Optmizes collection of js into one
        /// </summary>
        /// <param name="lstJsColl">list of js script to be optimize</param>
        /// <param name="Mode">set 1 for the first call </param>

        private void OptimizeJs(List<CssScriptInfo> lstJsColl, int Mode)
        {
            Literal LitSageScript = Mode == 1 ? Page.Header.FindControl("LitSageScript") as Literal : Page.Header.FindControl("SageFrameModuleCSSlinks") as Literal;

            bool isAdmin = IsAdmin();
            List<string> lstJs = new List<string>();
            foreach (CssScriptInfo js in lstJsColl)
            {
                lstJs.Add(js.ModuleName);
            }
            string portalType = isAdmin ? ApplicationKeys.admin.ToLower() : ApplicationKeys.portal;
            lstJs.Insert(0, portalType);
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsCompressJs = bool.Parse(pagebase.GetSettingsByKeyIndividual(SageFrameSettingKeys.OptimizeJs));

            #region "IncludeJs Logic"

            if (IsCompressJs && !isAdmin && !IsHandheld())
            {
                #region "Check cache and refresh it if the files optimized folder do not exist"

                Hashtable hst = new Hashtable();
                ///Check cache and refresh it if the files optimized folder do not exist              
                if (HttpRuntime.Cache[CacheKeys.SageFrameJs] != null)
                {
                    hst = (Hashtable)HttpRuntime.Cache[CacheKeys.SageFrameJs];
                    Hashtable hstNew = new Hashtable();
                    foreach (string modulekey in hst.Keys)
                    {
                        string file = string.Format("{0}.js", hst[modulekey].ToString());
                        if (File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", file))))
                        {
                            hstNew.Add(modulekey, hst[modulekey].ToString());
                        }
                    }
                    HttpRuntime.Cache[CacheKeys.SageFrameJs] = hstNew;
                }

                if (HttpRuntime.Cache[CacheKeys.SageFrameJs] != null)
                {
                    hst = (Hashtable)HttpRuntime.Cache[CacheKeys.SageFrameJs];
                }
                else
                {
                    XmlDocument doc = SageFrame.Templating.xmlparser.XmlHelper.LoadXMLDocument(Server.MapPath("~/Optimized/map_js.xml"));
                    XmlNode xnresourcemap = doc.SelectSingleNode("resourcemaps");
                    XmlNodeList xnlist = xnresourcemap.ChildNodes;
                    foreach (XmlNode node in xnlist)
                    {
                        string modules = node.SelectSingleNode("modules").InnerText;
                        string map = node.SelectSingleNode("map").InnerText;
                        if (modules != "" && !hst.Contains(modules))
                            hst.Add(modules, map);
                    }

                }

                #endregion

                string[] jsArr = lstJs.ToArray().Distinct().ToArray();
                ///Read the map file and check if the css for this combination already exists

                bool IsExists = false;
                string optimizedjs = string.Empty;

                #region "Get Optimized Js file name"

                foreach (string modulekey in hst.Keys)
                {
                    string modules = modulekey;
                    string[] modulesArr = modules.Split(',');
                    if (ArrayHelper.ArraysEqual<string>(jsArr, modulesArr))
                    {
                        IsExists = true;
                        optimizedjs = string.Format("{0}.js", hst[modulekey].ToString());
                        break;
                    }
                }

                #endregion

                #region "Optimize JS"

                if (IsExists)
                {
                    IsExists = File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", optimizedjs)));
                }
                if (!IsExists)
                {
                    string uniqueid = GenerateUniqueId();
                    XmlDocument doc = SageFrame.Templating.xmlparser.XmlHelper.LoadXMLDocument(Server.MapPath("~/Optimized/map_js.xml"));
                    XmlNode xnresourcemap = doc.SelectSingleNode("resourcemaps");
                    string optimized_js_path = Server.MapPath(string.Format("~/Optimized/{0}.js", uniqueid));
                    ///Write the combination into the map file
                    XmlElement resourcemap = doc.CreateElement("resourcemap");
                    XmlElement modules = doc.CreateElement("modules");
                    XmlElement map = doc.CreateElement("map");
                    modules.InnerText = string.Join(",", jsArr);
                    map.InnerText = uniqueid;
                    resourcemap.AppendChild(modules);
                    resourcemap.AppendChild(map);
                    xnresourcemap.AppendChild(resourcemap);
                    if (jsArr.Length > 0 && !hst.Contains(string.Join(",", jsArr)))
                    {
                        doc.Save(Server.MapPath("~/Optimized/map_js.xml"));
                        ///Hashtable+Cache needs to be reset

                        hst.Add(string.Join(",", jsArr), uniqueid);
                        HttpRuntime.Cache[CacheKeys.SageFrameJs] = hst;
                        ///Only when the optimized file does not exists..else the development mode needs to be on to recreate the css file
                        if (!File.Exists(optimized_js_path))
                        {
                            using (StreamWriter sw = new StreamWriter(optimized_js_path))
                            {

                                foreach (CssScriptInfo obj in lstJsColl)
                                {
                                    if (obj.AllowOptimization)
                                    {
                                        string uncompjs = "";
                                        string fullPath = string.Format("{0}/{1}/{2}", Request.PhysicalApplicationPath, obj.Path, obj.FileName);
                                        using (StreamReader rdr = new StreamReader(fullPath))
                                        {
                                            uncompjs = rdr.ReadToEnd();
                                        }
                                        string compressedjs = JsMinifier.GetMinifiedCode(uncompjs);
                                        sw.Write("\n");
                                        sw.Write("/*-----" + obj.FileName + "----*/");
                                        sw.Write("\n");
                                        sw.Write(compressedjs);
                                        sw.Write("\n");
                                    }
                                    else
                                    {

                                        string uncompressedjs = "<script src=\"" + ResolveUrl(string.Format("~/{0}/{1}", obj.Path, obj.FileName)) + "\" type=\"text/javascript\"></script>";
                                        LitSageScript.Text += uncompressedjs;
                                    }
                                }
                            }

                            string js = "<script src=\"" + ResolveUrl(string.Format("~/Optimized/{0}.js", uniqueid)) + "\" type=\"text/javascript\"></script>";
                            LitSageScript.Text += js;

                        }
                    }
                    else
                    {
                        string js = "<script src=\"" + ResolveUrl(string.Format("~/Optimized/{0}", optimizedjs)) + "\" type=\"text/javascript\"></script>";
                        LitSageScript.Text += js;
                    }
                }
                else
                {
                    string js = "<script src=\"" + ResolveUrl(string.Format("~/Optimized/{0}", optimizedjs)) + "\" type=\"text/javascript\"></script>";
                    LitSageScript.Text += js;
                    foreach (CssScriptInfo obj in lstJsColl)
                    {
                        if (!obj.AllowOptimization && LitSageScript != null)
                        {
                            string uncompressedjs = "<script src=\"" + ResolveUrl(string.Format("~/{0}/{1}", obj.Path, obj.FileName)) + "\" type=\"text/javascript\"></script>";
                            LitSageScript.Text += uncompressedjs;
                        }
                    }
                }

                #endregion
            }
            else
            {
                if (LitSageScript != null)
                {
                    foreach (CssScriptInfo obj in lstJsColl)
                    {
                        string js = string.Empty;
                        if (obj.IsCDN)
                        {
                            if (obj.IsJs)
                            {
                                js = "<script src=\"" + ResolveUrl(string.Format("{0}", obj.Path)) + "\" type=\"text/javascript\"></script>";
                            }
                            else
                            {
                                js = "<script src=\"" + ResolveUrl(string.Format("{0}", obj.Path)) + "\" rel=\"stylesheet\" type=\"text/css\" ></script>";
                            }
                        }
                        else
                        {
                            js = "<script src=\"" + ResolveUrl(string.Format("~/{0}/{1}", obj.Path, obj.FileName)) + "\" type=\"text/javascript\"></script>";
                        }
                        LitSageScript.Text += js;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// Returns js files
        /// </summary>
        /// <returns>Returns js files</returns>
        private List<CssScriptInfo> GetCorejsFiles()
        {
            return (CoreJs.GetList(IsAdmin(), IsUserLoggedIn(), IsHandheld(), GetPortalID));
        }

        /// <summary>
        /// Set google analytics
        /// </summary>
        private void SetGoogleAnalytics()
        {
            try
            {
                if (!IsAdmin())
                {
                    Hashtable hst = new Hashtable();
                    if (HttpRuntime.Cache[CacheKeys.SageGoogleAnalytics] != null)
                    {
                        hst = (Hashtable)HttpRuntime.Cache[CacheKeys.SageGoogleAnalytics];
                    }
                    else
                    {
                        SettingProvider sp = new SettingProvider();
                        List<GoogleAnalyticsInfo> objList = sp.GetGoogleAnalyticsActiveOnlyByPortalID(GetPortalID);
                        foreach (GoogleAnalyticsInfo objl in objList)
                        {
                            hst.Add("SageGoogleAnalytics_" + objl.PortalID, objl.GoogleJSCode);
                        }
                        HttpRuntime.Cache.Insert(CacheKeys.SageGoogleAnalytics, hst);
                    }
                    if (hst != null && hst.Count > 0 && hst.ContainsKey("SageGoogleAnalytics_" + GetPortalID))
                    {
                        Literal LitSageScript = Page.Header.FindControl("LitSageScript") as Literal;
                        if (LitSageScript != null)
                        {
                            string strGoogleJS = hst["SageGoogleAnalytics_" + GetPortalID].ToString();
                            if (!strGoogleJS.Contains("<script type=\"text/javascript\">"))
                            {
                                strGoogleJS = "<script type=\"text/javascript\">" + strGoogleJS + "</script>";
                            }
                            LitSageScript.Text += strGoogleJS;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Sets portalseo name
        /// </summary>
        private string SettingPortal
        {
            get
            {
                string strPortalName = ApplicationKeys.DefaultPortalName;
                try
                {
                    if (HttpContext.Current.Session[SessionKeys.SageFrame_PortalSEOName] != null)
                    {
                        strPortalName = HttpContext.Current.Session[SessionKeys.SageFrame_PortalSEOName].ToString();
                    }
                }
                catch
                {
                    strPortalName = ApplicationKeys.DefaultPortalName;
                }
                return strPortalName;
            }
        }

        #endregion

        #region "Protected Methods"

        /// <summary>
        /// 
        /// </summary>
        //protected override void InitializeCulture()
        //{
        //    ApplicationController objAppController = new ApplicationController();
        //    if (objAppController.IsInstalled())
        //    {
        //        SageFrameConfig sfConf = new SageFrameConfig();
        //        string portalCulture = sfConf.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultLanguage);

        //        CultureInfo newUICultureInfo = new CultureInfo(portalCulture);
        //        Thread.CurrentThread.CurrentUICulture = newUICultureInfo;
        //        Session[SessionKeys.SageUICulture] = newUICultureInfo;

        //        Thread.CurrentThread.CurrentCulture = newUICultureInfo;
        //        Session[SessionKeys.SageCulture] = newUICultureInfo;

        //    }
        //    else
        //    {
        //        HttpContext.Current.Response.Redirect(ResolveUrl("~/Install/InstallWizard.aspx"));
        //    }
        //    base.InitializeCulture();
        //}

        /// <summary>
        /// Initialize Culture
        /// </summary>
        protected override void InitializeCulture()
        {
            ApplicationController objAppController = new ApplicationController();
            if (objAppController.IsInstalled())
            {
                SageFrameConfig sfConf = new SageFrameConfig();
                string portalCulture = sfConf.GetSettingValueByIndividualKey(SageFrameSettingKeys.PortalDefaultLanguage);
                if (Session[SessionKeys.SageUICulture] != null)
                {
                    Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session[SessionKeys.SageUICulture];
                }
                else
                {
                    CultureInfo newUICultureInfo = new CultureInfo(portalCulture);
                    Thread.CurrentThread.CurrentUICulture = newUICultureInfo;
                    Session[SessionKeys.SageUICulture] = newUICultureInfo;
                }
                if (Session[SessionKeys.SageUICulture] != null)
                {
                    Thread.CurrentThread.CurrentCulture = (CultureInfo)Session[SessionKeys.SageUICulture];
                }
                else
                {
                    CultureInfo newCultureInfo = new CultureInfo(portalCulture);
                    Thread.CurrentThread.CurrentCulture = newCultureInfo;
                    Session[SessionKeys.SageUICulture] = newCultureInfo;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(ResolveUrl("~/Install/InstallWizard.aspx"));
            }
            base.InitializeCulture();
        }

        /// <summary>
        /// Set culture to the current thread and session
        /// </summary>
        /// <param name="name"> culture name</param>
        /// <param name="locale"></param>
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Session[SessionKeys.SageUICulture] = Thread.CurrentThread.CurrentUICulture;
            Session[SessionKeys.SageCulture] = Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Returns current UI Culture from thread
        /// </summary>
        /// <returns>Returns UI current Culture </returns>
        protected string GetCurrentUICulture()
        {
            return Thread.CurrentThread.CurrentUICulture.ToString();
        }

        /// <summary>
        /// Returns current UI Culture from thread
        /// </summary>
        /// <returns>Returns UI current Culture</returns>
        protected string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.ToString();
        }

        /// <summary>
        /// Executes on prerendering of the page
        /// </summary>
        /// <param name="e">EventArgs e</param>
        protected override void OnPreRender(EventArgs e)
        {
            ApplicationController objAppController = new ApplicationController();
            if (!objAppController.CheckRequestExtension(Request))
            {
                base.OnPreRender(e);
                SetGoogleAnalytics();
                LoadModuleCss();
                LoadModuleJs();
                HttpContext.Current.Session[SessionKeys.ModuleCss] = new List<CssScriptInfo>();
                HttpContext.Current.Session[SessionKeys.ModuleJs] = new List<CssScriptInfo>();
            }
        }

        /// <summary>
        ///  Returns portalSEO name
        /// </summary>
        protected string GetPortalSEOName
        {
            get
            {
                if (HttpContext.Current.Session[SessionKeys.SageFrame_PortalSEOName] != null &&
                    HttpContext.Current.Session[SessionKeys.SageFrame_PortalSEOName].ToString() != string.Empty)
                {
                    PortalSEOName = HttpContext.Current.Session[SessionKeys.SageFrame_PortalSEOName].ToString();
                }
                return PortalSEOName;
            }
        }

        /// <summary>
        /// Registers exception to the error log
        /// </summary>
        /// <param name="exc">Exception</param>
        protected void ProcessException(Exception exc)
        {
            int inID = 0;
            ErrorLogController objController = new ErrorLogController();
            inID = objController.InsertLog((int)SageFrame.Web.SageFrameEnums.ErrorType.AdministrationArea, 11, exc.Message, exc.ToString(),
             HttpContext.Current.Request.UserHostAddress, Request.RawUrl, true, GetPortalID, GetUsername);
            ShowMessage(SageMessageTitle.Exception.ToString(), exc.Message, exc.ToString(), SageMessageType.Error);
        }

        /// <summary>
        /// Displays the message with provided message, title, complete message and message type.
        /// </summary>
        /// <param name="MessageTitle">Message tittle</param>
        /// <param name="Message">Message</param>
        /// <param name="CompleteMessage">Complete message</param>
        /// <param name="MessageType">Message type</param>
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

        /// <summary>
        /// Displays HttpRequest validation exception
        /// </summary>
        protected void ProcessHttpRequestValidationException()
        {
            if (HttpContext.Current.Request.QueryString["sagealert"] != null && HttpContext.Current.Request.QueryString["sagealert"].ToString() != string.Empty)
            {
                string ShortAlert = "Malicious activity found, your activity is recorded, if you repeat the same action, you may not able to browse this site in future.";
                ShortAlert += " Your IP Address: " + HttpContext.Current.Request.UserHostAddress;
                ShortAlert += " Mechine Name: " + HttpContext.Current.Request.UserHostName;
                string FullAllert = string.Empty;//"A potentially dangerous Request.Form value was detected from the client. Please remove < and > from your entry and re-submit information";
                ShowMessage(SageMessageTitle.Notification.ToString(), ShortAlert, FullAllert, SageMessageType.Alert);
            }
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Show Message In The Page
        /// </summary>
        /// <param name="MessageTitle"> Display Message Title</param>
        /// <param name="Message"> Display Message</param>
        /// <param name="CompleteMessage">Complete Message</param>
        /// <param name="isSageAsyncPostBack">Set True If Update Panel Post Back</param>
        /// <param name="MessageType">Message Type</param>
        public virtual void ShowMessage(string MessageTitle, string Message, string CompleteMessage, bool isSageAsyncPostBack, SageMessageType MessageType)
        {

        }

        /// <summary>
        /// Get Current Culture Name
        /// </summary>
        public string GetCurrentCultureName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name;
            }
        }

        /// <summary>
        /// Set Current Culture Name
        /// </summary>
        /// <param name="name"> UI Culture Name</param>
        /// <param name="locale">Local Culture Name</param>
        public static void SetCultureInfo(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            HttpContext.Current.Session[SessionKeys.SageUICulture] = Thread.CurrentThread.CurrentUICulture;
            HttpContext.Current.Session[SessionKeys.SageCulture] = Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Check For Parent Portal
        /// </summary>
        public bool IsParent
        {
            get
            {
                try
                {
                    int portalID = GetPortalID;
                    bool flag = false;
                    if (HttpContext.Current.Session[SessionKeys.IsParent + portalID] != null)
                    {
                        flag = bool.Parse(HttpContext.Current.Session[SessionKeys.IsParent + portalID].ToString()) == true ? true : false;
                    }
                    else
                    {
                        SageFrameConfig obj = new SageFrameConfig();
                        flag = obj.DecideIsParent(portalID);
                        HttpContext.Current.Session[SessionKeys.IsParent + portalID] = flag;
                    }
                    return flag;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        ///Get Portal Parent URL
        /// </summary>
        public string GetParentURL
        {
            get
            {
                try
                {
                    string ParentURL = string.Empty;
                    if (HttpContext.Current.Session[SessionKeys.ParentURL] != null)
                    {
                        ParentURL = HttpContext.Current.Session[SessionKeys.ParentURL].ToString();
                    }
                    else
                    {
                        int PID = GetPortalID;
                        SageFrameConfig obj = new SageFrameConfig();
                        ParentURL = obj.GetPortalParentURL(PID);
                    }
                    if (ParentURL.ToLower() == "default")
                    {
                        ParentURL = "~/";
                    }
                    HttpContext.Current.Session[SessionKeys.ParentURL] = ParentURL;
                    return ParentURL;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// Check and reduce "/" of URL
        /// </summary>
        public string GetReduceApplicationName
        {
            get
            {
                return (Request.ApplicationPath == "/" ? "/" : "");
            }
        }

        /// <summary>
        /// Get Current User Image
        /// </summary>
        public string GetUserImage
        {
            get
            {
                try
                {
                    SecurityPolicy objSecurity = new SecurityPolicy();
                    string userName = objSecurity.GetUser(GetPortalID);
                    string userImage = "";
                    if (userName != ApplicationKeys.anonymousUser)
                    {
                        if (HttpContext.Current.Session[SessionKeys.SageFrame_UserProfilePic] != null &&
                            HttpContext.Current.Session[SessionKeys.SageFrame_UserProfilePic].ToString() != "")
                        {
                            userImage = HttpContext.Current.Session[SessionKeys.SageFrame_UserProfilePic].ToString();
                        }
                        else
                        {
                            //userImage = UserProfileController.GetProfile
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

        /// <summary>
        /// Initialize pae Meta tags
        /// </summary>
        public void InitializePage()
        {

            #region "Page Meta Section"

            SageFrameConfig sfConfig = new SageFrameConfig();
            SageTitle = sfConfig.GetSettingsByKey(SageFrameSettingKeys.PageTitle);
            Description = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaDescription);
            KeyWords = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaKeywords);
            Refresh = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaRefresh);
            Copyright = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaCopyright);
            Generator = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaGenerator);
            Author = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaAuthor);
            ResourceType = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaRESOURCE_TYPE);
            Distribution = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaDISTRIBUTION);
            Robots = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaRobots);
            PageEnter = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaPAGE_ENTER);
            RevisitAfter = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MetaREVISIT_AFTER);

            SEOHelper.RenderTitle(this.Page, SageTitle, false, true, this.GetPortalID);
            SEOHelper.RenderMetaTag(this.Page, "Refresh", Refresh, true);
            SEOHelper.RenderMetaTag(this.Page, "DESCRIPTION", Description, true);
            SEOHelper.RenderMetaTag(this.Page, "KEYWORDS", KeyWords, true);
            SEOHelper.RenderMetaTag(this.Page, "COPYRIGHT", Copyright, true);
            SEOHelper.RenderMetaTag(this.Page, "GENERATOR", Generator, true);
            SEOHelper.RenderMetaTag(this.Page, "AUTHOR", Author, true);
            SEOHelper.RenderMetaTag(this.Page, "RESOURCE-TYPE", ResourceType, false);
            SEOHelper.RenderMetaTag(this.Page, "DISTRIBUTION", Distribution, false);
            SEOHelper.RenderMetaTag(this.Page, "ROBOTS", Robots, true);
            SEOHelper.RenderMetaTag(this.Page, "REVISIT-AFTER", RevisitAfter, false);
            SEOHelper.RenderMetaTag(this.Page, "PAGE-ENTER", PageEnter, false);
            #endregion

            if (!IsPostBack)
            {
                ProcessHttpRequestValidationException();
            }
        }

        /// <summary>
        /// Set Current Template Css
        /// </summary>
        public void SetTemplateCss()
        {
            string cssTemplatePath = string.Empty;
            string cssResponsive = string.Empty;
            Literal SageFrameCoreCss = this.Page.FindControl("SageFrameCoreCss") as Literal;
            string activeTemplate = GetActiveTemplate;
            bool isHandheld = IsHandheld();
            bool isAdmin = IsAdmin();
            if (isAdmin)
            {
                cssTemplatePath = "~/Administrator/Templates/Default/css/admin.css";
                //cssResponsive = "~/Administrator/Templates/Default/css/responsive.css";
            }
            else
            {
                string pcTemplatePath = Decide.IsTemplateDefault(activeTemplate) ? "~/Core/Template/css/template.css"
                                        : string.Format("~/Templates/{0}/css/template.css", activeTemplate);
                cssResponsive = Decide.IsTemplateDefault(activeTemplate) ? "~/Core/Template/css/responsive.css"
                                       : string.Format("~/Templates/{0}/css/responsive.css", activeTemplate);
                cssTemplatePath = !isHandheld ? pcTemplatePath
                                    : string.Format("~/Templates/{0}/css/handheld/template.css", activeTemplate);
                PresetInfo preset = GetPresetDetails;
                //if (preset.ActiveTheme != "" && preset.ActiveTheme.ToLower() != "default")
                //{
                //    cssColoredTemplate = cssColorTemplate(activeTemplate, preset);
                //}
            }
            if (!Decide.IsTemplateDefault(activeTemplate) && !isAdmin && !isHandheld)
            {
                if (SageFrameCoreCss != null)
                {
                    // SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/normalize.css") + "\" rel=\"stylesheet\" type=\"text/css\" />";
                }
            }
            // css must be in order: normalize.css --> topstickybar.css --> grid.css --> (template/admin.css) --> theme.css  -->  responsive.css
            StringBuilder coreCss = new StringBuilder();
            if (!isAdmin && !isHandheld)
            {
                if (SageFrameCoreCss != null)
                {
                    coreCss.Append("<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/normalize.css") + "\" rel=\"stylesheet\" type=\"text/css\" />");
                }
            }
            if (SageFrameCoreCss != null)
            {

                coreCss.Append("<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/grid.css") + "\" rel=\"stylesheet\" type=\"text/css\" />");
                if (!isHandheld && IsUserLoggedIn())
                {
                    coreCss.Append("<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/topstickybar.css") + "\" rel=\"stylesheet\" type=\"text/css\" />");
                }
                coreCss.Append("<link href=\"" + Page.ResolveUrl(cssTemplatePath) + "\" rel=\"stylesheet\" type=\"text/css\" />");
                coreCss.Append("<link href=\"" + Page.ResolveUrl(cssResponsive) + "\" rel=\"stylesheet\" type=\"text/css\" />");
                SageFrameCoreCss.Text += coreCss.ToString();
            }
        }
        /// <summary>
        /// Get Current Template Css path
        /// </summary>
        /// <returns>Current Template Path</returns>
        public string GetTemplateCssPath()
        {
            string activeTemplate = GetActiveTemplate;
            string CssTemplatePath = "";
            CssTemplatePath = !IsHandheld() ? (!Decide.IsTemplateDefault(activeTemplate)
                              ? "~/Templates/" + activeTemplate + "/css/template.css"
                              : "~/Core/Template/css/template.css")
                              : "~/Templates/" + activeTemplate + "/css/handheld/template.css";

            PresetInfo preset = GetPresetDetails;
            if (preset.ActiveTheme != "" && preset.ActiveTheme.ToLower() != "default")
            {
                CssTemplatePath = !IsHandheld() ? !Decide.IsTemplateDefault(activeTemplate)
                                    ? string.Format("~/Templates/{0}/themes/{1}/css/template.css", activeTemplate, preset.ActiveTheme)
                                    : "~/Core/Template/css/template.css"
                                    : string.Format("~/Templates/{0}/css/handheld/template.css", activeTemplate);
            }
            return Server.MapPath(CssTemplatePath);
        }

        /// <summary>
        /// Get Current Responsive Css path
        /// </summary>
        /// <returns>Returns current template path</returns>
        public string GetResponsiveCssPath()
        {
            string activeTemplate = GetActiveTemplate;
            string responsiveCssPath = "";
            responsiveCssPath = !IsHandheld() ? (!Decide.IsTemplateDefault(activeTemplate)
                              ? "~/Templates/" + activeTemplate + "/css/responsive.css"
                              : "~/Core/Template/css/responsive.css")
                              : "~/Templates/" + activeTemplate + "/css/handheld/responsive.css";

            PresetInfo preset = GetPresetDetails;
            if (preset.ActiveTheme != "" && preset.ActiveTheme.ToLower() != "default")
            {
                responsiveCssPath = !IsHandheld() ? !Decide.IsTemplateDefault(activeTemplate)
                                    ? string.Format("~/Templates/{0}/themes/{1}/css/responsive.css", activeTemplate, preset.ActiveTheme)
                                    : "~/Core/Template/css/responsive.css"
                                    : string.Format("~/Templates/{0}/css/handheld/responsive.css", activeTemplate);
            }
            return Server.MapPath(responsiveCssPath);
        }

        /// <summary>
        /// Get Current Admin Template Path
        /// </summary>
        /// <returns>Current Admin Template Path</returns>
        public string GetAdminTemplatePath()
        {
            return (Server.MapPath("~/Administrator/Templates/Default/css/admin.css"));
        }

        /// <summary>
        /// Set Current Screen Width Parse From Preset XML File
        /// </summary>      

        public void SetScreenWidth(string userName)
        {
            string appendClass = " sfLoggedTopBar";
            if (userName.ToLower() == "anonymoususer")
            {
                appendClass = "";
            }
            PresetInfo preset = GetPresetDetails;
            if (preset.ActiveWidth != "")
            {
                ApplicationController objAppController = new ApplicationController();
                objAppController.ChangeCss(Page, "pchWhole", "lytA", "sfOuterWrapper", "class", "sf" + preset.ActiveWidth.ToLower() + appendClass);
            }
        }

        /// <summary>
        /// Get Width Class According To The Setting 
        /// </summary>
        /// <param name="activewidth"></param>
        /// <returns></returns>
        public string GetWidthClass(string activewidth)
        {
            string width = "wide";
            switch (activewidth.ToLower())
            {
                case "wide":
                    width = "Wide";
                    break;
                case "narrow":
                    width = "Narrow";
                    break;
                case "fluid":
                    width = "Fluid";
                    break;
            }
            return (string.Format("sf{0}", width));
        }

        /// <summary>
        /// Check If The Device Is Handheld
        /// </summary>
        /// <returns>True If The Device Is Handheld</returns>
        public bool IsHandheld()
        {
            SageFrameConfig sfConf = new SageFrameConfig();
            string GetMode = sfConf.GetSettingsByKey(SageFrameSettingKeys.UserAgentMode);
            bool status = false;
            if (GetMode == "3")
            {
                string strUserAgent = Request.UserAgent.ToString().ToLower();
                if (strUserAgent != null)
                {
                    if (Request.Browser.IsMobileDevice == true
                        || strUserAgent.Contains("mobile")
                        //|| strUserAgent.Contains("iphone") ||
                        //strUserAgent.Contains("blackberry") || 
                        //strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                        //strUserAgent.Contains("palm")
                        )
                    {
                        status = true;
                    }
                }
            }
            else
            {
                int Mode = 0;
                Mode = int.Parse(GetMode);
                if (Mode == 2) status = true;
                else status = false;
            }
            return status;
        }

        /// <summary>
        /// Compress all the css of all the modules at once and load it
        /// </summary>
        public void LoadModuleCss()
        {
            string activeTemplate = GetActiveTemplate;
            List<CssScriptInfo> lstModuleResources = new List<CssScriptInfo>();
            StringBuilder modulecss = new StringBuilder();
            bool isAdmin = IsAdmin();
            if (HttpContext.Current.Session[SessionKeys.ModuleCss] != null)
            {
                lstModuleResources = HttpContext.Current.Session[SessionKeys.ModuleCss] as List<CssScriptInfo>;
            }
            if (!isAdmin)
            {
                lstModuleResources.AddRange(CoreCss.GetTemplateCss(activeTemplate));
            }
            List<KeyValue> lstCssInclude = new List<KeyValue>();
            List<string> lstCss = new List<string>();
            bool isTemplateDefault = Decide.IsTemplateDefault(activeTemplate);


            if (lstModuleResources != null)
            {
                PresetInfo preset = GetPresetDetails;
                string templatePathFirst = isTemplateDefault ? "Core" : "Templates";
                string templatePathSecond = isTemplateDefault ? "Template" : activeTemplate;

                #region "Get Modules Resources path"

                foreach (CssScriptInfo css in lstModuleResources)
                {
                    lstCss.Add(css.ModuleName.ToLower());
                    string fullPath_theme = Server.MapPath(string.Format("~/{0}/{1}/themes/{2}/modules/{3}",
                        templatePathFirst, templatePathSecond, preset.ActiveTheme, css.ModuleName));

                    string fullPath_template = Server.MapPath(string.Format("~/{0}/{1}/modules/{2}",
                        templatePathFirst, templatePathSecond, css.ModuleName));

                    string fullPath_module = Server.MapPath(string.Format("~/{0}", css.Path));

                    #region "Strategy 3-Priority-3:Check at the module level(the default fallback)"

                    ///Strategy 3-Priority-3:Check at the module level(the default fallback)
                    if (Directory.Exists(fullPath_module))
                    {
                        ///Check to see if the file exists in the root level
                        if (File.Exists(string.Format("{0}/{1}", fullPath_module, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}", css.Path, css.FileName), css.Path));
                        }
                        ///Check to see if the file exists in the css folder
                        else if (File.Exists(string.Format("{0}/css/{1}", fullPath_module, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}", css.Path, css.FileName), css.Path));
                        }
                    }

                    #endregion

                    #region "Strategy 1-Priority-1:Check the themes"

                    ///Strategy 1-Priority-1:Check the themes                   
                    if (Directory.Exists(fullPath_theme))
                    {
                        ///Check to see if the file exists in the root level
                        if (File.Exists(fullPath_theme + "/" + css.FileName))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/themes/{2}/modules/{3}/{4}",
                                templatePathFirst, templatePathSecond, preset.ActiveTheme, css.ModuleName, css.FileName), css.Path));
                        }
                        ///Check to see if the file exists in the css folder
                        else if (File.Exists(string.Format("{0}/css/{1}", fullPath_theme, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/themes/{2}/modules/{3}/css/{4}",
                                templatePathFirst, templatePathSecond, preset.ActiveTheme, css.ModuleName, css.FileName), css.Path));

                        }
                    }

                    #endregion

                    #region "Strategy 2-Priority-2:Check at the template level"

                    ///Strategy 2-Priority-2:Check at the template level
                    else if (Directory.Exists(fullPath_template))
                    {
                        ///Check to see if the file exists in the root level
                        if (File.Exists(string.Format("{0}/{1}", fullPath_template, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/modules/{2}/{3}", templatePathFirst, templatePathSecond, css.ModuleName, css.FileName), css.Path));
                        }
                        ///Check to see if the file exists in the css folder
                        else if (File.Exists(string.Format("{0}/css/{1}", fullPath_template, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/modules/{2}/css/{3}", templatePathFirst, templatePathSecond, css.ModuleName, css.FileName), css.Path));
                        }
                    }

                    #endregion
                }

                #endregion

                #region "Css Compress"

                SageFrameConfig pagebase = new SageFrameConfig();
                bool IsCompressCss = bool.Parse(pagebase.GetSettingsByKeyIndividual(SageFrameSettingKeys.OptimizeCss));
                if (IsCompressCss && !isAdmin && !IsHandheld())
                {
                    ///1.Loop through the list
                    ///2.Read the Css File
                    ///3.Rewrite the Image Paths in Css Files
                    ///4.Compress the Css file 
                    ///5.Include it in the Css Literal
                    string templateTypeName = isAdmin ? "admintemplate" : "template";
                    lstCss.Insert(0, templateTypeName);
                    string[] cssArr = lstCss.ToArray().Distinct().ToArray();

                    #region "Synchronize the cache and the map data in the files"

                    ///Check cache and refresh it if the files optimized folder do not exist
                    ///Synchronize the cache and the map data in the files
                    Hashtable hst = new Hashtable();
                    if (HttpRuntime.Cache[CacheKeys.SageFrameCss] != null)
                    {
                        hst = (Hashtable)HttpRuntime.Cache[CacheKeys.SageFrameCss];
                        Hashtable hstNew = new Hashtable();
                        foreach (string modulekey in hst.Keys)
                        {
                            string file = string.Format("{0}.css", hst[modulekey].ToString());
                            if (File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", file))))
                            {
                                hstNew.Add(modulekey, hst[modulekey].ToString());
                            }
                        }
                        HttpRuntime.Cache[CacheKeys.SageFrameCss] = hstNew;
                    }

                    #endregion

                    #region "Read the map file and check if the css for this combination already exists"

                    ///Read the map file and check if the css for this combination already exists
                    if (HttpRuntime.Cache[CacheKeys.SageFrameCss] != null)
                    {
                        hst = (Hashtable)HttpRuntime.Cache[CacheKeys.SageFrameCss];
                    }
                    else
                    {
                        XmlDocument doc = SageFrame.Templating.xmlparser.XmlHelper.LoadXMLDocument(Server.MapPath("~/Optimized/map_css.xml"));
                        XmlNode xnresourcemap = doc.SelectSingleNode("resourcemaps");
                        XmlNodeList xnlist = xnresourcemap.ChildNodes;
                        foreach (XmlNode node in xnlist)
                        {
                            string modules = node.SelectSingleNode("modules").InnerText;
                            string map = node.SelectSingleNode("map").InnerText;
                            if (modules != "" && !hst.Contains(modules))
                                hst.Add(modules, map);
                        }
                    }

                    #endregion

                    bool IsExists = false;
                    string optimizedcss = string.Empty;
                    #region "Get optimize css Path"

                    foreach (string modulekey in hst.Keys)
                    {
                        string modules = modulekey;
                        string[] modulesArr = modules.Split(',');
                        if (ArrayHelper.ArraysEqual<string>(cssArr, modulesArr))
                        {
                            IsExists = true;
                            optimizedcss = string.Format("{0}.css", hst[modulekey].ToString());
                            break;
                        }
                    }

                    #endregion

                    #region "Css Optimization"

                    if (IsExists)
                    {
                        IsExists = File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", optimizedcss)));
                    }
                    if (!IsExists)
                    {
                        PresetInfo presetObj = GetPresetDetails;
                        string uniqueid = GenerateUniqueId();
                        XmlDocument doc = SageFrame.Templating.xmlparser.XmlHelper.LoadXMLDocument(Server.MapPath("~/Optimized/map_css.xml"));
                        XmlNode xnresourcemap = doc.SelectSingleNode("resourcemaps");
                        string optimized_css_path = Server.MapPath(string.Format("~/Optimized/{0}.css", uniqueid));
                        ///Write the combination into the map file
                        XmlElement resourcemap = doc.CreateElement("resourcemap");
                        XmlElement modules = doc.CreateElement("modules");
                        XmlElement map = doc.CreateElement("map");
                        modules.InnerText = string.Join(",", cssArr);
                        map.InnerText = uniqueid;
                        resourcemap.AppendChild(modules);
                        resourcemap.AppendChild(map);
                        xnresourcemap.AppendChild(resourcemap);
                        if (cssArr.Length > 0 && !hst.Contains(string.Join(",", cssArr)))
                        {
                            doc.Save(Server.MapPath("~/Optimized/map_css.xml"));

                            ///Hashtable+Cache needs to be reset

                            hst.Add(string.Join(",", cssArr), uniqueid);
                            HttpRuntime.Cache[CacheKeys.SageFrameCss] = hst;
                            ///Only when the optimized file does not exists..else the development mode needs to be on to recreate the css file
                            if (!File.Exists(optimized_css_path))
                            {
                                using (StreamWriter sw = new StreamWriter(optimized_css_path))
                                {
                                    ///Read the template.css file

                                    string compressedcss = "";
                                    string uncompcss = "";
                                    string templatecsspath = isAdmin ? GetAdminTemplatePath() : GetTemplateCssPath();
                                    SageFrameConfig sageConfig = new SageFrameConfig();
                                    string defaultAdminTheme = sageConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.DefaultAdminTheme);
                                    string themeCssPath = "~/Administrator/Templates/Default/themes/" + defaultAdminTheme + ".css";
                                    string cssResponsivePath = GetResponsiveCssPath();
                                    string imageWritePath = isTemplateDefault ? string.Format("/Core/Template/css") : string.Format("/Templates/{0}/css", activeTemplate);
                                    string imagerewrite = isAdmin ? "/Administrator/Templates/Default/css/" : imageWritePath;
                                    string cssText = isAdmin ? "admin.css" : "template.css";
                                    string cssResponsiveText = "responsive.css";
                                    string path = Server.MapPath("~/js/jquery-ui-1.8.14.custom/css/redmond/jquery-ui-1.8.16.custom.css");
                                    using (StreamReader rdr = new StreamReader(path))
                                    {
                                        uncompcss = rdr.ReadToEnd();
                                    }
                                    compressedcss = CssMinifier.CssMinify(uncompcss);
                                    compressedcss = CssMinifier.RewriteCssImagePath(compressedcss, "/js/jquery-ui-1.8.14.custom/css/redmond/", GetAppPath(), "images");

                                    sw.Write("\n");
                                    sw.Write("/*-----JQuery UI----*/");
                                    sw.Write("\n");
                                    sw.Write(compressedcss);
                                    sw.Write("\n");

                                    ///Read the module files    
                                    if (!isAdmin && !IsHandheld())
                                    {
                                        lstCssInclude.Insert(0, new KeyValue("~/Administrator/Templates/Default/css/normalize.css", "/Administrator/Templates/Default/css/"));
                                        lstCssInclude.Insert(1, new KeyValue("~/Administrator/Templates/Default/css/topstickybar.css", "/Administrator/Templates/Default/css/"));
                                        lstCssInclude.Insert(2, new KeyValue("~/Administrator/Templates/Default/css/grid.css", "/Administrator/Templates/Default/css/"));

                                    }
                                    else
                                    {
                                        lstCssInclude.Insert(0, new KeyValue("~/Administrator/Templates/Default/css/topstickybar.css", "/Administrator/Templates/Default/css/"));
                                        lstCssInclude.Insert(1, new KeyValue("~/Administrator/Templates/Default/css/grid.css", "/Administrator/Templates/Default/css/"));
                                    }
                                    if (isAdmin)
                                    {
                                        lstCssInclude.Insert(3, new KeyValue("~/Administrator/Templates/Default/css/admin.css", "/Administrator/Templates/Default/css/"));
                                    }

                                    foreach (KeyValue cssfile in lstCssInclude)
                                    {
                                        using (StreamReader rdr = new StreamReader(Server.MapPath(cssfile.Key)))
                                        {
                                            uncompcss = rdr.ReadToEnd();
                                        }
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, string.Format("{0}", cssfile.Value), GetAppPath(), "images");
                                        sw.Write("\n");
                                        sw.Write("/*-----" + Path.GetFileName(cssfile.Key) + "----*/");
                                        sw.Write("\n");
                                        sw.Write(compressedcss);
                                        sw.Write("\n");
                                    }
                                    // read from template.css and compress it
                                    using (StreamReader rdr = new StreamReader(templatecsspath))
                                    {
                                        uncompcss = rdr.ReadToEnd();
                                    }
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, imagerewrite, GetAppPath(), "images");

                                    sw.Write("\n");
                                    sw.Write("/*-----'" + cssText + "'----*/");
                                    sw.Write("\n");
                                    sw.Write(compressedcss);
                                    sw.Write("\n");

                                    if (isAdmin)
                                    {
                                        // read from theme.css and compress it
                                        using (StreamReader rdr = new StreamReader(themeCssPath))
                                        {
                                            uncompcss = rdr.ReadToEnd();
                                        }
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, imagerewrite, GetAppPath(), "images");

                                        sw.Write("\n");
                                        sw.Write("/*-----'" + cssText + "'----*/");
                                        sw.Write("\n");
                                        sw.Write(compressedcss);
                                        sw.Write("\n");
                                    }

                                    // read from responsive.css and compress it
                                    using (StreamReader rdr = new StreamReader(cssResponsivePath))
                                    {
                                        uncompcss = rdr.ReadToEnd();
                                    }
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, imagerewrite, GetAppPath(), "images");

                                    sw.Write("\n");
                                    sw.Write("/*-----'" + cssResponsiveText + "'----*/");
                                    sw.Write("\n");
                                    sw.Write(compressedcss);
                                    sw.Write("\n");
                                }
                                Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                                if (SageFrameModuleCSSlinks != null)
                                {
                                    string linkText = "<link href=\"" + Page.ResolveUrl(string.Format("~/Optimized/{0}.css", uniqueid)) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                                    SageFrameModuleCSSlinks.Text += linkText;
                                }
                            }
                        }
                        else
                        {
                            Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                            if (SageFrameModuleCSSlinks != null)
                            {
                                string linkText = "<link href=\"" + Page.ResolveUrl("~/Optimized/" + optimizedcss) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                                SageFrameModuleCSSlinks.Text += linkText;
                            }
                        }
                    }
                    else
                    {
                        Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                        if (SageFrameModuleCSSlinks != null)
                        {
                            string linkText = "<link href=\"" + Page.ResolveUrl("~/Optimized/" + optimizedcss) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                            SageFrameModuleCSSlinks.Text += linkText;
                        }
                    }

                    #endregion
                }
                else
                {
                    Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                    if (SageFrameModuleCSSlinks != null)
                    {
                        SageFrameModuleCSSlinks.Text = "";
                    }
                    SetTemplateCss();
                    if (IsUserLoggedIn())
                    {
                        AddModuleCssToPage("~/js/jquery-ui-1.8.14.custom/css/redmond/jquery-ui-1.8.16.custom.css");
                    }

                    foreach (KeyValue cssfile in lstCssInclude)
                    {
                        AddModuleCssToPage(cssfile.Key);
                    }

                    if (isAdmin)
                    {
                        string cssColoredTemplate = string.Empty;
                        SageFrameConfig sageConfig = new SageFrameConfig();
                        string defaultAdminTheme = sageConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.DefaultAdminTheme);
                        cssColoredTemplate = "~/Administrator/Templates/Default/themes/" + defaultAdminTheme + ".css";
                        AddModuleCssToPage(cssColoredTemplate);
                    }


                }

                #endregion
            }

        }

        /// <summary>
        ///  Check whether is user is loggedIn or not
        /// </summary>
        /// <returns>Retunrs true if the user is loggedIn</returns>
        public bool IsUserLoggedIn()
        {
            bool IsLoggedIn = false;
            SecurityPolicy objSecurity = new SecurityPolicy();
            FormsAuthenticationTicket ticket = objSecurity.GetUserTicket(GetPortalID);
            if (ticket != null)
            {
                int LoggedInPortalID = ticket.UserData != "" && ticket.UserData != null ? int.Parse(ticket.UserData.ToString()) : 0;
                if (ticket.Name != ApplicationKeys.anonymousUser)
                {
                    string[] sysRoles = SystemSetting.SUPER_ROLE;
                    if (GetPortalID == LoggedInPortalID || Roles.IsUserInRole(ticket.Name, sysRoles[0]))
                    {
                        IsLoggedIn = true;
                    }
                }
            }
            return IsLoggedIn;
        }

        /// <summary>
        /// Loads All The Module Js At Once
        /// </summary>
        public void LoadModuleJs()
        {
            List<CssScriptInfo> lstJsColl = new List<CssScriptInfo>();
            lstJsColl.AddRange(GetCorejsFiles());
            List<CssScriptInfo> lstJsTop = new List<CssScriptInfo>();
            List<CssScriptInfo> lstJsBottom = new List<CssScriptInfo>();
            if (HttpContext.Current.Session[SessionKeys.ModuleJs] != null)
            {
                lstJsColl.AddRange(HttpContext.Current.Session[SessionKeys.ModuleJs] as List<CssScriptInfo>);
            }

            ///Get js from the templates as well if any
            if (lstJsColl != null)
                lstJsColl.AddRange(CoreJs.GetTemplateJs(GetActiveTemplate));

            foreach (CssScriptInfo script in lstJsColl)
            {
                if (script.Position == 0)
                {
                    lstJsTop.Add(script);
                }
                else
                {
                    lstJsBottom.Add(script);
                }
            }
            OptimizeJs(lstJsTop, 0);
            OptimizeJs(lstJsBottom, 1);
        }

        /// <summary>
        /// Get Color Css File Of Current Template
        /// </summary>
        public string TemplateName
        {
            get
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
                return sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalCssTemplate);
            }
        }

        /// <summary>
        ///  Get Current Template Image URL
        /// </summary>
        /// <param name="imageName">Image Name</param>
        /// <param name="isServerControl">Set True If It Is Server Control</param>
        /// <returns></returns>
        public string GetTemplateImageUrl(string imageName, bool isServerControl)
        {
            string path = string.Empty;
            if (isServerControl == true)
            {
                path = "~/Templates/Default/images/admin/" + imageName;
            }
            else
            {
                path = this.Page.ResolveUrl("~/") + "Templates/Default/images/admin/" + imageName;
            }
            return path;
        }

        /// <summary>
        /// Get Admin Image URL
        /// </summary>
        /// <param name="imageName"> Image Name</param>
        /// <param name="isServerControl"> Set True If It Is Server Control</param>
        /// <returns>Returns Image Path</returns>
        public string GetAdminImageUrl(string imageName, bool isServerControl)
        {
            string path = string.Empty;
            if (isServerControl == true)
            {
                path = "~/Administrator/Templates/Default/images/" + imageName;
            }
            else
            {
                path = this.Page.ResolveUrl("~/") + "Administrator/Templates/Default/images/" + imageName;
            }
            return path;
        }

        /// <summary>
        /// Get message css class by message type
        /// </summary>
        /// <param name="MessageType"> Messsage Type (Enum) SageMessageType</param>
        /// <returns>Css Class </returns>
        public string GetMessageCssClass(SageMessageType MessageType)
        {
            string cssClass = string.Empty;
            switch (MessageType)
            {
                case SageMessageType.Alert:
                    cssClass = "sfMessage sfAlertmsg sfCurve";
                    break;
                case SageMessageType.Error:
                    cssClass = "sfMessage sfErrormsg sfCurve";
                    break;
                case SageMessageType.Success:
                    cssClass = "sfMessage sfSuccessmsg sfCurve";
                    break;
            }
            return cssClass;
        }
        /// <summary>
        /// Get current PortalID
        /// </summary>
        public int GetPortalID
        {
            get
            {
                try
                {
                    Hashtable hstPortals = GetPortals();
                    string URL = HttpContext.Current.Request.Url.ToString();
                    if (URL.Contains("/portal/"))
                    {
                        var RegMatch = Regex.Matches(URL, @"^http[s]?\s*:.*\/portal\/([^/]+)+\/.*");
                        string PortalName = "";
                        foreach (Match match in RegMatch)
                        {
                            PortalName = match.Groups[1].Value;
                        }
                        int PortalID = Int32.Parse(hstPortals[PortalName].ToString());
                        HttpContext.Current.Session[SessionKeys.SageFrame_PortalID] = PortalID.ToString();
                        return PortalID;
                    }
                    else if (URL.Contains("/Sagin/HandleModuleControls.aspx"))
                    {
                        int PortalID = int.Parse(HttpContext.Current.Request.QueryString["pid"].ToString());
                        return PortalID;
                    }
                    else
                    {
                        string ParentURL = HttpContext.Current.Request.Url.Authority + GetAppPath();
                        int PID = 1;
                        foreach (DictionaryEntry entry in hstPortals)
                        {
                            if (ParentURL.ToString().ToLower() == entry.Key.ToString())
                                PID = int.Parse(entry.Value.ToString());
                        }
                        HttpContext.Current.Session[SessionKeys.SageFrame_PortalID] = PID;
                        return PID;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Get current active template name
        /// </summary>
        public string GetActiveTemplate
        {
            get
            {
                try
                {
                    if (Globals.sysHst[ApplicationKeys.ActiveTemplate + "_" + GetPortalID] != null)
                    {
                        return (string)Globals.sysHst[ApplicationKeys.ActiveTemplate + "_" + GetPortalID];
                    }
                    else
                    {
                        string templateName = TemplateController.GetActiveTemplate(GetPortalID).TemplateSeoName;
                        string tempPath = Decide.IsTemplateDefault(templateName) ? Utils.GetTemplatePath_Default(templateName) : Utils.GetTemplatePath(templateName);
                        if (Directory.Exists(tempPath))
                        {
                            Globals.sysHst[ApplicationKeys.ActiveTemplate + "_" + GetPortalID] = templateName;
                            return templateName;
                        }
                        else
                        {
                            Globals.sysHst[ApplicationKeys.ActiveTemplate + "_" + GetPortalID] = ApplicationKeys.DefaultActiveTemplateName;
                            return ApplicationKeys.DefaultActiveTemplateName;
                        }
                    }
                }
                catch
                {
                    return ApplicationKeys.DefaultActiveTemplateName;
                }
            }
        }

        /// <summary>
        /// Get current active preset information
        /// </summary>
        public PresetInfo GetPresetDetails
        {
            get
            {
                try
                {
                    if (Globals.sysHst[ApplicationKeys.ActivePagePreset + "_" + PortalID] != null)
                    {
                        return Globals.sysHst[ApplicationKeys.ActivePagePreset + "_" + PortalID] as PresetInfo;
                    }
                    else
                    {
                        return (PresetHelper.LoadActivePagePreset(GetActiveTemplate, GetPageSEOName(Request.Url.ToString())));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Get current active admin theme
        /// </summary>
        public string GetActiveAdminTheme
        {
            get
            {
                try
                {
                    if (Session[SessionKeys.SageFrame_AdminTheme] != null)
                    {
                        return Session[SessionKeys.SageFrame_AdminTheme].ToString();
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

        /// <summary>
        /// Set Active TemplateName In The Session
        /// </summary>
        /// <param name="ActiveTemplate">Active Template Name</param>
        public void SetActiveTemplate(string ActiveTemplate)
        {
            Globals.sysHst[ApplicationKeys.ActiveTemplate + "_" + PortalID] = ActiveTemplate;
        }

        /// <summary>
        /// Set Portal ID
        /// </summary>
        /// <param name="portalID">PortalID</param>
        public void SetPortalID(int portalID)
        {
            PortalID = portalID;
        }

        /// <summary>
        /// Get Current StoreID
        /// </summary>
        public int GetStoreID
        {
            get
            {
                try
                {
                    if (Session[SessionKeys.SageFrame_StoreID] != null && Session[SessionKeys.SageFrame_StoreID].ToString() != "")
                    {
                        return int.Parse(Session[SessionKeys.SageFrame_StoreID].ToString());
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Set StoreID
        /// </summary>
        /// <param name="storeID">StoreID</param>
        public void SetStoreID(int storeID)
        {
            StoreID = storeID;
        }

        /// <summary>
        /// Get Current CustomerID
        /// </summary>
        public System.Nullable<Int32> GetCustomerID
        {
            get
            {
                try
                {
                    if (Session[SessionKeys.SageFrame_CustomerID] != null && Session[SessionKeys.SageFrame_CustomerID].ToString() != "")
                    {
                        return int.Parse(Session[SessionKeys.SageFrame_CustomerID].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Set CustomerID
        /// </summary>
        /// <param name="customerID">CustomerID</param>
        public void SetCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

        /// <summary>
        /// Get Current UserName
        /// </summary>
        public string GetUsername
        {
            get
            {
                try
                {
                    SecurityPolicy objSecurity = new SecurityPolicy();
                    string userName = objSecurity.GetUser(GetPortalID);
                    return userName;
                }
                catch
                {
                    return ApplicationKeys.anonymousUser;
                }
            }
        }

        /// <summary>
        /// Loads user control to the Page.
        /// </summary>
        /// <param name="UpdatePanelIDPrefix">Update panel Prefix</param>
        /// <param name="IsPartialRendring">Set true if partial rendering is needed</param>
        /// <param name="ContainerControl">Placeholder name</param>
        /// <param name="ControlSrc">UserControl source</param>
        /// <param name="PaneName">Pane name</param>
        /// <param name="strUserModuleID">UserModuleID</param>
        /// <param name="suffixClass">Suffix class</param>
        /// <param name="HeaderText">Header text</param>
        /// <param name="IsUserAdmin">Set true if the module is admin </param>
        /// <param name="divControl">HtmlGenericControl</param>
        /// <param name="paneControl">HtmlGenericControl</param>
        /// <param name="IsEdit">true when user cotrol have edit permission </param>
        /// <returns>Returns PlaceHolder object</returns>
        public PlaceHolder LoadControl(string UpdatePanelIDPrefix, bool IsPartialRendring, PlaceHolder ContainerControl, string ControlSrc, string PaneName, string strUserModuleID, string suffixClass, string HeaderText, bool IsUserAdmin, HtmlGenericControl divControl, HtmlGenericControl paneControl, bool IsEdit)
        {
            try
            {
                SageUserControl ctl;
                if (ControlSrc.ToLower().EndsWith(".ascx"))
                {
                    if (IsPartialRendring)
                    {
                        UpdatePanel udp = CreateUpdatePanel(UpdatePanelIDPrefix, UpdatePanelUpdateMode.Always, ContainerControl.Controls.Count);
                        ctl = this.Page.LoadControl("~" + ControlSrc) as SageUserControl;
                        ctl.EnableViewState = true;
                        ctl.SageUserModuleID = strUserModuleID;

                        HtmlGenericControl header = new HtmlGenericControl("h2");
                        header.InnerText = HeaderText;

                        HtmlGenericControl divInner = new HtmlGenericControl("div");
                        divInner.Attributes.Add("class", "sfModulecontent clearfix");
                        divInner.Controls.Add(ctl);

                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("class", suffixClass);

                        if (HeaderText != "")
                            div.Controls.Add(header);
                        if (IsEdit)
                            div.Controls.Add(divControl);
                        if (IsUserAdmin)
                        {

                            div.Controls.Add(paneControl);

                        }
                        div.Controls.Add(divInner);


                        udp.ContentTemplateContainer.Controls.Add(div);
                        ContainerControl.Controls.Add(udp);
                    }
                    else
                    {
                        ctl = this.Page.LoadControl("~" + ControlSrc) as SageUserControl;
                        ctl.EnableViewState = true;
                        ctl.SageUserModuleID = strUserModuleID;

                        if (ctl.GetType().FullName.ToLower() != "ASP.modules_message_message_ascx".ToLower())
                        {
                            HtmlGenericControl header = new HtmlGenericControl("h2");
                            header.InnerText = HeaderText;
                            HtmlGenericControl divInner = new HtmlGenericControl("div");
                            divInner.Attributes.Add("class", "sfModulecontent clearfix");
                            divInner.Controls.Add(ctl);
                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Attributes.Add("class", suffixClass);
                            if (HeaderText != "")
                                div.Controls.Add(header);
                            if (IsEdit)
                                div.Controls.Add(divControl);
                            if (IsUserAdmin)
                            {
                                div.Controls.Add(divControl); div.Controls.Add(paneControl);
                            }
                            div.Controls.Add(divInner);
                            ContainerControl.Controls.Add(div);
                        }
                        else
                        {
                            ContainerControl.Controls.Add(ctl);
                        }
                    }
                }
                else
                {
                }
                return ContainerControl;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return ContainerControl;
            }
        }

        /// <summary>
        /// Builds update panel 
        /// </summary>
        /// <param name="Prefix">panel prefix</param>
        /// <param name="Upm">Update panel Update Mode</param>
        /// <param name="PaneUpdatePanelCount"></param>
        /// <returns>Returns UpdatePanel object</returns>
        public UpdatePanel CreateUpdatePanel(string Prefix, UpdatePanelUpdateMode Upm, int PaneUpdatePanelCount)
        {
            UpdatePanel udp = new UpdatePanel();
            udp.UpdateMode = Upm;
            PaneUpdatePanelCount++;
            udp.ID = "_udp_" + "_" + PaneUpdatePanelCount + Prefix;
            return udp;
        }

        /// <summary>
        /// Use To Display Permission For The User
        /// </summary>
        /// <param name="i">Set True For Same As Page And Set False For Page Editors Only</param>
        /// <returns></returns>
        public string ConvetVisibility(bool i)
        {
            string Visible = ApplicationKeys.Same_As_Page;
            if (i == false)
            {
                Visible = ApplicationKeys.Page_Editor_Only;
            }
            return Visible;
        }

        /// <summary>
        /// Returns pageSEO name by page path
        /// </summary>
        /// <param name="pagePath"> opage path</param>
        /// <returns> Returns pageSEO name</returns>
        public string GetPageSEOName(string pagePath)
        {
            string SEOName = string.Empty;
            if (string.IsNullOrEmpty(pagePath))
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
                SEOName = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.PortalDefaultPage);
            }
            else
            {
                string[] pagePaths = pagePath.Split('/');
                SEOName = pagePaths[pagePaths.Length - 1];
                if (string.IsNullOrEmpty(SEOName))
                {
                    SEOName = pagePaths[pagePaths.Length - 2];
                }
                SEOName = SEOName.Replace(SageFrameSettingKeys.PageExtension, "");
            }
            return SEOName;
        }

        /// <summary>
        /// Override page information
        /// </summary>
        /// <param name="dt">Page information (Enum)DataTable</param>
        public void OverridePageInfo(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                string PageTitle = dt.Rows[0]["Title"].ToString();
                string PageRefresh = dt.Rows[0]["RefreshInterval"].ToString();
                string PageDescription = dt.Rows[0]["Description"].ToString();
                string PageKeyWords = dt.Rows[0]["KeyWords"].ToString();

                if (!string.IsNullOrEmpty(PageTitle))
                    SEOHelper.RenderTitle(this.Page, PageTitle, false, true, this.GetPortalID);

                if (!string.IsNullOrEmpty(PageRefresh) && PageRefresh != "0.00")
                    SEOHelper.RenderMetaTag(this.Page, "Refresh", PageRefresh, true);
                else
                {
                    foreach (Control control in this.Page.Header.Controls)
                        if (control is HtmlMeta)
                        {
                            HtmlMeta meta = (HtmlMeta)control;
                            if (meta.Name.ToLower().Equals("Refresh".ToLower()))
                            {
                                meta.Visible = false;
                            }
                        }
                }

                if (!string.IsNullOrEmpty(PageDescription))
                    SEOHelper.RenderMetaTag(this.Page, "DESCRIPTION", PageDescription, true);

                if (!string.IsNullOrEmpty(PageKeyWords))
                    SEOHelper.RenderMetaTag(this.Page, "KEYWORDS", PageKeyWords, true);

            }
            else
            {
                foreach (Control control in this.Page.Header.Controls)
                    if (control is HtmlMeta)
                    {
                        HtmlMeta meta = (HtmlMeta)control;
                        if (meta.Name.ToLower().Equals("Refresh".ToLower()))
                        {
                            meta.Visible = false;
                        }
                    }
            }
        }

        /// <summary>
        /// Override page information by userModule
        /// </summary>
        /// <param name="usermodule">UserModule information (Enum) userModuleInfo</param>
        public void OverridePageInfo(UserModuleInfo usermodule)
        {
            if (usermodule != null)
            {
                string PageTitle = usermodule.Title;
                string PageRefresh = usermodule.RefreshInterval;
                string PageDescription = usermodule.Description;
                string PageKeyWords = usermodule.KeyWords;

                if (!string.IsNullOrEmpty(PageTitle))
                    SEOHelper.RenderTitle(this.Page, PageTitle, false, true, this.GetPortalID);

                if (!string.IsNullOrEmpty(PageRefresh) && PageRefresh != "0.00")
                    SEOHelper.RenderMetaTag(this.Page, "Refresh", PageRefresh, true);
                else
                {
                    foreach (Control control in this.Page.Header.Controls)
                        if (control is HtmlMeta)
                        {
                            HtmlMeta meta = (HtmlMeta)control;
                            if (meta.Name.ToLower().Equals("Refresh".ToLower()))
                            {
                                meta.Visible = false;
                            }
                        }
                }
                if (!string.IsNullOrEmpty(PageDescription))
                    SEOHelper.RenderMetaTag(this.Page, "DESCRIPTION", PageDescription, true);

                if (!string.IsNullOrEmpty(PageKeyWords))
                    SEOHelper.RenderMetaTag(this.Page, "KEYWORDS", PageKeyWords, true);

            }
            else
            {
                foreach (Control control in this.Page.Header.Controls)
                    if (control is HtmlMeta)
                    {
                        HtmlMeta meta = (HtmlMeta)control;
                        if (meta.Name.ToLower().Equals("Refresh".ToLower()))
                        {
                            meta.Visible = false;
                        }
                    }
            }

        }

        /// <summary>
        /// Add module css to page by control path
        /// </summary>
        /// <param name="ControlSrc">Module control root source</param>
        /// <param name="IsModuleFolerName">Set true if path is of folder name</param>
        public void AddModuleCssToPage(string ControlSrc, bool IsModuleFolerName)
        {
            string ModuleRootLocation = string.Empty;
            if (IsModuleFolerName)
            {
                ModuleRootLocation = "~/Modules/" + ControlSrc + "/module.css";
            }
            else
            {
                ControlSrc = ControlSrc.Replace("/Modules/", "");
                while (ControlSrc.Contains("/"))
                {
                    ControlSrc = ControlSrc.Remove(ControlSrc.LastIndexOf("/"));
                }
            }
            ModuleRootLocation = "~/Modules/" + ControlSrc + "/module.css";
            string FullPath = Server.MapPath(ModuleRootLocation);
            if (System.IO.File.Exists(FullPath))
            {
                Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                if (SageFrameModuleCSSlinks != null)
                {
                    string linkText = "<link href=\"" + Page.ResolveUrl(ModuleRootLocation) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                    SageFrameModuleCSSlinks.Text += linkText;
                }
            }
        }

        /// <summary>
        /// Add module Css To Page By Css File Path
        /// </summary>
        /// <param name="cssFilePath"> Css File Path</param>
        public void AddModuleCssToPage(string cssFilePath)
        {
            string ModuleRootLocation = string.Empty;
            ModuleRootLocation = cssFilePath;
            string FullPath = Server.MapPath(ModuleRootLocation);
            if (System.IO.File.Exists(FullPath))
            {
                Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                if (SageFrameModuleCSSlinks != null)
                {
                    string linkText = "<link href=\"" + Page.ResolveUrl(ModuleRootLocation) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                    SageFrameModuleCSSlinks.Text += linkText;
                }
            }
        }

        /// <summary>
        /// Get Default Portal Name By PortalID
        /// </summary>
        /// <param name="hstPortals">HashTable Containing PortalID and PortalName</param>
        /// <param name="portalID">PortalID</param>
        /// <returns>PortalName</returns>
        public string GetDefaultPortalName(Hashtable hstPortals, int portalID)
        {
            string portalname = string.Empty;
            foreach (string key in hstPortals.Keys)
            {
                if (Int32.Parse(hstPortals[key].ToString()) == portalID)
                {
                    portalname = key;
                }
            }
            return portalname;
        }

        /// <summary>
        /// Get PortalID And Respective Name List
        /// </summary>
        /// <returns>PortalID And PortalName</returns>
        public Hashtable GetPortals()
        {
            Hashtable hstAll = new Hashtable();
            if (HttpRuntime.Cache[CacheKeys.Portals] != null)
            {
                hstAll = (Hashtable)HttpRuntime.Cache[CacheKeys.Portals];
            }
            else
            {
                SettingProvider objSP = new SettingProvider();
                List<SagePortals> sagePortals = objSP.PortalGetList();
                foreach (SagePortals portal in sagePortals)
                {
                    hstAll.Add(portal.SEOName.Replace("https://", "").Replace("http://", "").ToLower().Trim(), portal.PortalID);
                }
            }
            HttpRuntime.Cache.Insert(CacheKeys.Portals, hstAll);
            return hstAll;
        }

        /// <summary>
        /// Set User Roles
        /// </summary>
        /// <param name="strRoles">User Role</param>
        public void SetUserRoles(string strRoles)
        {
            HttpContext.Current.Session[SessionKeys.SageUserRoles] = strRoles;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookiesKeys.SageUserRolesCookie];
            if (cookie == null)
            {
                cookie = new HttpCookie(CookiesKeys.SageUserRolesCookie);
            }
            cookie[CookiesKeys.SageUserRolesProtected] = strRoles;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Get Application Root Path
        /// </summary>
        /// <returns> Application Root Path</returns>
        public string GetAppPath()
        {
            return HttpContext.Current.Request.ApplicationPath != "/" ? HttpContext.Current.Request.ApplicationPath : "";
        }

        /// <summary>
        /// Check Either The User Is Admin Or Not By URL 
        /// </summary>
        /// <returns>True If The User Is Admin</returns>
        public bool IsAdmin()
        {
            {
                string url = HttpContext.Current.Request.RawUrl.ToLower();
                if (url.Contains("?"))
                {
                    url = url.Split('?')[0];
                }
                bool status = url.Contains("/admin/") ||
                    url.Contains("/sagin/") ||
                    url.Contains("/admin" + SageFrameSettingKeys.PageExtension) ||
                    url.Contains("/super-User/") ||
                    url.Contains("/super-User" + SageFrameSettingKeys.PageExtension) ||
                    url.Contains("managereturnurl=");
                return status;
            }
        }

        /// <summary>
        /// Registers startup events
        /// </summary>
        /// <param name="PortalID">PortalID</param>
        /// <param name="pchWhole">Placeholder name</param>
        /// <param name="IsAdmin">Set true for admin part</param>
        public void IncludeStartup(int PortalID, PlaceHolder pchWhole, bool IsAdmin)
        {
            try
            {
                IncludeStartupEvents(SystemEventLocation.Top, PortalID, pchWhole, IsAdmin);
                IncludeStartupEvents(SystemEventLocation.Middle, PortalID, pchWhole, IsAdmin);
                IncludeStartupEvents(SystemEventLocation.Bottom, PortalID, pchWhole, IsAdmin);
            }
            catch (Exception ex)
            {
                Session[SessionKeys.TemplateError] = ex;
            }
        }

        /// <summary>
        /// Registers startup events
        /// </summary>
        /// <param name="EventLocation"> Event locations</param>
        /// <param name="PortalID">portalID</param>
        /// <param name="phdContainer">Placeholder name</param>  
        /// <param name="IsAdmin">Set true for admin part</param>
        public void IncludeStartupEvents(SystemEventLocation EventLocation, int PortalID, PlaceHolder phdContainer, bool IsAdmin)
        {
            SystemStartupController obj = new SystemStartupController();
            ArrayList arrColl = new ArrayList();
            switch (EventLocation)
            {
                case SystemEventLocation.Top:
                    arrColl = obj.GetStartUpControls("Top", PortalID, IsAdmin);
                    for (int i = 0; i < arrColl.Count; i++)
                    {
                        try
                        {
                            UserControl ctl = this.Page.LoadControl("~/" + arrColl[i].ToString()) as SageFrameStartUpControl;
                            if (ctl != null)
                            {
                                this.Page.Controls.AddAt(0, ctl);
                            }
                        }
                        catch
                        {
                        }

                    }
                    break;
                case SystemEventLocation.Middle:
                    arrColl = obj.GetStartUpControls("Middle", PortalID, IsAdmin);
                    UserControl uc = phdContainer.FindControl("lytA") as UserControl;
                    for (int i = 0; i < arrColl.Count; i++)
                    {
                        try
                        {
                            UserControl ctl = this.Page.LoadControl("~/" + arrColl[i].ToString()) as SageFrameStartUpControl;
                            PlaceHolder phdPlaceHolderMiddle = uc.FindControl("pch_middlemaincurrent") as PlaceHolder;
                            if (phdPlaceHolderMiddle != null && ctl != null)
                            {
                                phdPlaceHolderMiddle.Controls.Add(ctl);
                            }
                        }
                        catch
                        {
                        }
                    }
                    break;
                case SystemEventLocation.Bottom:
                    arrColl = obj.GetStartUpControls("Bottom", PortalID, IsAdmin);
                    for (int i = 0; i < arrColl.Count; i++)
                    {
                        try
                        {
                            UserControl ctl = this.Page.LoadControl("~/" + arrColl[i].ToString()) as SageFrameStartUpControl;
                            if (ctl != null)
                            {
                                this.Page.Controls.AddAt(this.Page.Controls.Count, ctl);
                            }
                        }
                        catch
                        {
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Returns favicon path
        /// </summary>
        /// <param name="activeTemplate">active template name</param>
        /// <returns>Returns favicon absolute Path</returns>
        public string SetFavIcon(string activeTemplate)
        {
            return Decide.IsTemplateDefault(activeTemplate) ? ResolveUrl("~/favicon.ico") : ResolveUrl(string.Format("~/Templates/{0}/favicon.ico", activeTemplate));
        }

        /// <summary>
        /// Return the host path
        /// for eg: http://sageframe.com/ or http://localhost:2511/SageFrame/
        /// </summary>
        /// <returns>Returns HostURL</returns>
        public string GetHostURL
        {
            get
            {
                string hostUrl = Page.Request.Url.Scheme + "://" + Request.Url.Authority + GetAppPath();
                return hostUrl;
            }
        }

        /// <summary>
        /// Get a unique token to  check User LoggedIn 
        /// </summary>
        public string SageFrameSecureToken
        {
            get
            {
                string authToken = string.Empty;
                SecurityPolicy objSecurity = new SecurityPolicy();
                authToken = objSecurity.FormsCookieName(GetPortalID);
                return authToken;
            }
        }

        /// <summary>
        /// Registers the Javascript variables to the browser
        /// </summary>
        public void RegisterSageGlobalVariable()
        {
            try
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar1", " var SageFrameAppPath='" + GetAppPath() + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar2", " var SageFrameUserName='" + GetUsername + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar4", " var SageFrameCurrentCulture='" + GetCurrentCulture() + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar5", " var SageFramePortalID='" + GetPortalID + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar6", " var SageFramePortalName='" + GetPortalSEOName + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar3", " var SageFrameActiveTemplate='" + GetActiveTemplate + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar7", " var SageFrameHostURL='" + GetHostURL + "';", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar8", " var SageFrameSecureToken='" + SageFrameSecureToken + "';", true);
                SageFrameConfig sfConfig = new SageFrameConfig();
                string ms = sfConfig.GetSettingsByKey(SageFrameSettingKeys.MessageTemplate);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageMsgTemplate", " var MsgTemplate='" + ms + "';", true);
            }
            catch
            {
            }
        }


        #endregion

        #region "Depreciated Methods"

        /// <summary>
        /// 
        /// </summary>



        #endregion
    }
}
