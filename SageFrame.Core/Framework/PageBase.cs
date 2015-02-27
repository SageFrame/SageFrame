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


namespace SageFrame.Framework
{

    public class PageBase : System.Web.UI.Page
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

        public virtual void ShowMessage(string MessageTitle, string Message, string CompleteMessage, bool isSageAsyncPostBack, SageMessageType MessageType)
        {

        }

        public string GetCurrentCultureName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name;
            }
        }

        protected override void InitializeCulture()
        {

            string IsInstalled = Config.GetSetting("IsInstalled").ToString();
            string InstallationDate = Config.GetSetting("InstallationDate").ToString();
            if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
            {
                SageFrameConfig sfConf = new SageFrameConfig();
                string portalCulture = sfConf.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultLanguage);
                if (Session["SageUICulture"] != null)
                {
                    Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["SageUICulture"];
                }
                else
                {
                    CultureInfo newUICultureInfo = new CultureInfo(portalCulture);
                    Thread.CurrentThread.CurrentUICulture = newUICultureInfo;
                    Session["SageUICulture"] = newUICultureInfo;
                }
                if (Session["SageCulture"] != null)
                {
                    Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["SageCulture"];
                }
                else
                {
                    CultureInfo newCultureInfo = new CultureInfo(portalCulture);
                    Thread.CurrentThread.CurrentCulture = newCultureInfo;
                    Session["SageCulture"] = newCultureInfo;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(ResolveUrl("~/Install/InstallWizard.aspx"));
            }


            base.InitializeCulture();
        }
       
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Session["SageUICulture"] = Thread.CurrentThread.CurrentUICulture;
            Session["SageCulture"] = Thread.CurrentThread.CurrentCulture;
        }

        public static void SetCultureInfo(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            HttpContext.Current.Session["SageUICulture"] = Thread.CurrentThread.CurrentUICulture;
            HttpContext.Current.Session["SageCulture"] = Thread.CurrentThread.CurrentCulture;
        }

        protected string GetCurrentUICulture()
        {
            return Thread.CurrentThread.CurrentUICulture.ToString();
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

        protected string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.ToString();
        }

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

        public void SetTemplateCss()
        {
            string TemplateName = GetActiveTemplate;
            string CssTemplatePath = string.Empty;
            string cssColoredTemplate = "";
            string CssLayoutPath = string.Empty;
            Literal SageFrameCoreCss = this.Page.FindControl("SageFrameCoreCss") as Literal;

            if (HttpContext.Current.Request.RawUrl.Contains("/Admin/") || HttpContext.Current.Request.RawUrl.Contains("/Sagin/") || HttpContext.Current.Request.RawUrl.Contains("/Admin.aspx") || HttpContext.Current.Request.RawUrl.Contains("/Super-User/") || HttpContext.Current.Request.RawUrl.Contains("/Super-User.aspx") || HttpContext.Current.Request.RawUrl.Contains("ManageReturnURL="))
            {
                string adminTheme = GetActiveAdminTheme;

                CssTemplatePath = "~/Administrator/Templates/Default/css/admin.css";
                switch (adminTheme.ToLower())
                {
                    case "green":
                        cssColoredTemplate = string.Format("~/Administrator/Templates/Default/themes/{0}/css/green.css", adminTheme);
                        break;
                    case "red":
                        cssColoredTemplate = string.Format("~/Administrator/Templates/Default/themes/{0}/css/blue.css", adminTheme);
                        break;
                    case "gray":
                        cssColoredTemplate = string.Format("~/Administrator/Templates/Default/themes/{0}/css/gray.css", adminTheme);
                        break;
                    case "black":
                        cssColoredTemplate = string.Format("~/Administrator/Templates/Default/themes/{0}/css/black.css", adminTheme);
                        break;
                }

            }
            else
            {              
                string pcTemplatePath = Decide.IsTemplateDefault(GetActiveTemplate) ? "~/Core/Template/css/template.css"
                                        : string.Format("~/Templates/{0}/css/template.css", GetActiveTemplate);

                CssTemplatePath = !IsHandheld() ? pcTemplatePath
                                    : "~/Administrator/Templates/Default/css/handheld/template.css";

                PresetInfo preset = GetPresetDetails;
                if (preset.ActiveTheme != "" && preset.ActiveTheme.ToLower() != "default")
                {
                    cssColoredTemplate = !IsHandheld() ? Decide.IsTemplateDefault(GetActiveTemplate)
                                            ?string.Format("~/Core/Template/themes/{0}/css/color.css",preset.ActiveTheme)
                                            :string.Format("~/Templates/{0}/themes/{1}/css/color.css", GetActiveTemplate, preset.ActiveTheme)
                                            :string.Format("~/Templates/{0}/css/handheld/color.css", TemplateName);
                }

            }
            if (!Decide.IsTemplateDefault(GetActiveTemplate) && !IsAdmin())
            {
                if (SageFrameCoreCss != null)
                {
                    SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/front.css") + "\" rel=\"stylesheet\" type=\"text/css\" />";
                }
            }
            if (!IsAdmin())
            {
                if (SageFrameCoreCss != null)
                {
                    SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/front.css") + "\" rel=\"stylesheet\" type=\"text/css\" />";
                }

            }
            if (SageFrameCoreCss != null)
            {
                SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl("~/Administrator/Templates/Default/css/core.css") + "\" rel=\"stylesheet\" type=\"text/css\" />";
                SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl(CssTemplatePath) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                SageFrameCoreCss.Text += "<link href=\"" + Page.ResolveUrl(cssColoredTemplate) + "\" rel=\"stylesheet\" type=\"text/css\" />";
            }


        }

        public string GetTemplateCssPath()
        {
            string CssTemplatePath = "";           
            CssTemplatePath = !IsHandheld() ? !Decide.IsTemplateDefault(TemplateName) 
                              ?"~/Templates/" + GetActiveTemplate + "/css/template.css" 
                              :"~/Core/Template/css/template.css" 
                              :"~/Templates/" + GetActiveTemplate + "/css/handheld/template.css";

            PresetInfo preset = GetPresetDetails;
            if (preset.ActiveTheme != "" && preset.ActiveTheme.ToLower() != "default")
            {
                CssTemplatePath = !IsHandheld() ? !Decide.IsTemplateDefault(TemplateName) 
                                    ?string.Format("~/Templates/{0}/themes/{1}/css/template.css",GetActiveTemplate,preset.ActiveTheme)
                                    : "~/Core/Template/css/template.css"
                                    : string.Format("~/Templates/{0}/css/handheld/template.css",GetActiveTemplate);
            }
            return Server.MapPath(CssTemplatePath);

        }

        public string GetAdminTemplatePath()
        {
            return (Server.MapPath("~/Administrator/Templates/Default/css/admin.css"));
        }

        public void SetScreenWidth()
        {
            PresetInfo preset = GetPresetDetails;
            if (preset.ActiveWidth != "")
            {
                PlaceHolder pchWhole = Page.FindControl("pchWhole") as PlaceHolder;
                UserControl uc = pchWhole.FindControl("lytA") as UserControl;
                HtmlGenericControl div = uc.FindControl("sfOuterWrapper") as HtmlGenericControl;
                div.Attributes.Add("class", GetWidthClass(preset.ActiveWidth.ToLower()));
            }
        }

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

        public bool IsHandheld()
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            bool status = false;
            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                    strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                    strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                    strUserAgent.Contains("palm"))
                {
                    status = true;
                }
            }
            return status;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!(Request.CurrentExecutionFilePath.Contains(".gif") || Request.CurrentExecutionFilePath.Contains(".jpg") || Request.CurrentExecutionFilePath.Contains(".png")))
            {
                base.OnPreRender(e);
                SetGoogleAnalytics();
                LoadModuleCss();
                LoadModuleJs();
                HttpContext.Current.Session["ModuleCss"] = new List<CssScriptInfo>();
                HttpContext.Current.Session["ModuleJs"] = new List<CssScriptInfo>();
            }

        }

        public bool IsAdmin()
        {
            bool status = HttpContext.Current.Request.RawUrl.Contains("/Admin/") || HttpContext.Current.Request.RawUrl.Contains("/Sagin/") || HttpContext.Current.Request.RawUrl.Contains("/Admin.aspx") || HttpContext.Current.Request.RawUrl.Contains("/Super-User/") || HttpContext.Current.Request.RawUrl.Contains("/Super-User.aspx") || HttpContext.Current.Request.RawUrl.Contains("ManageReturnURL=");
            return status;
        }

        public void LoadModuleCss()
        {
            List<CssScriptInfo> lstModuleResources = new List<CssScriptInfo>();
            StringBuilder modulecss = new StringBuilder();

            if (HttpContext.Current.Session["ModuleCss"] != null)
                lstModuleResources = HttpContext.Current.Session["ModuleCss"] as List<CssScriptInfo>;

            if (!IsAdmin())
                lstModuleResources.AddRange(CoreCss.GetTemplateCss(GetActiveTemplate));

            List<KeyValue> lstCssInclude = new List<KeyValue>();
            List<string> lstCss = new List<string>();

            if (lstModuleResources != null)
            {
                PresetInfo preset = GetPresetDetails;
                foreach (CssScriptInfo css in lstModuleResources)
                {
                    lstCss.Add(css.ModuleName.ToLower());
                    string fullPath_theme = Server.MapPath(string.Format("~/{0}/{1}/themes/{2}/modules/{3}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, preset.ActiveTheme, css.ModuleName));
                    string fullPath_template = Server.MapPath(string.Format("~/{0}/{1}/modules/{2}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, css.ModuleName));
                    string fullPath_module = Server.MapPath(string.Format("~/{0}", css.Path));

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

                    ///Strategy 1-Priority-1:Check the themes
                    if (Directory.Exists(fullPath_theme))
                    {
                        ///Check to see if the file exists in the root level
                        if (File.Exists(fullPath_theme + "/" + css.FileName))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/themes/{2}/modules/{3}/{4}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, preset.ActiveTheme, css.ModuleName, css.FileName), css.Path));
                        }
                        ///Check to see if the file exists in the css folder
                        else if (File.Exists(string.Format("{0}/css/{1}", fullPath_theme, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/themes/{2}/modules/{3}/css/{4}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, preset.ActiveTheme, css.ModuleName, css.FileName), css.Path));

                        }
                    }
                    ///Strategy 2-Priority-2:Check at the template level
                    else if (Directory.Exists(fullPath_template))
                    {
                        ///Check to see if the file exists in the root level
                        if (File.Exists(string.Format("{0}/{1}", fullPath_template, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/modules/{2}/{3}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, css.ModuleName, css.FileName), css.Path));
                        }
                        ///Check to see if the file exists in the css folder
                        else if (File.Exists(string.Format("{0}/css/{1}", fullPath_template, css.FileName)))
                        {
                            lstCssInclude.Add(new KeyValue(string.Format("~/{0}/{1}/modules/{2}/css/{3}", Decide.IsTemplateDefault(GetActiveTemplate) ? "Core" : "Templates", Decide.IsTemplateDefault(GetActiveTemplate) ? "Template" : GetActiveTemplate, css.ModuleName, css.FileName), css.Path));
                        }
                    }
                }

                SageFrameConfig pagebase = new SageFrameConfig();
                bool IsCompressCss = bool.Parse(pagebase.GetSettingsByKey(SageFrameSettingKeys.OptimizeCss));
                if (IsCompressCss)
                {
                    ///1.Loop through the list
                    ///2.Read the Css File
                    ///3.Rewrite the Image Paths in Css Files
                    ///4.Compress the Css file 
                    ///5.Include it in the Css Literal

                    lstCss.Insert(0, IsAdmin() ? "admintemplate" : "template");
                    string[] cssArr = lstCss.ToArray().Distinct().ToArray();

                    ///Check cache and refresh it if the files optimized folder do not exist
                    ///Synchronize the cache and the map data in the files
                    Hashtable hst = new Hashtable();
                    if (HttpContext.Current.Cache["SageFrameCss"] != null)
                    {
                        hst = (Hashtable)HttpContext.Current.Cache["SageFrameCss"];
                        Hashtable hstNew = new Hashtable();
                        foreach (string modulekey in hst.Keys)
                        {
                            string file = string.Format("{0}.css", hst[modulekey].ToString());
                            if (File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", file))))
                            {
                                hstNew.Add(modulekey, hst[modulekey].ToString());
                            }
                        }
                        HttpContext.Current.Cache["SageFrameCss"] = hstNew;
                    }

                    ///Read the map file and check if the css for this combination already exists
                    if (HttpContext.Current.Cache["SageFrameCss"] != null)
                    {
                        hst = (Hashtable)HttpContext.Current.Cache["SageFrameCss"];
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

                    bool IsExists = false;
                    string optimizedcss = string.Empty;
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
                            HttpContext.Current.Cache["SageFrameCss"] = hst;
                            ///Only when the optimized file does not exists..else the development mode needs to be on to recreate the css file
                            if (!File.Exists(optimized_css_path))
                            {
                                using (StreamWriter sw = new StreamWriter(optimized_css_path))
                                {
                                    ///Read the template.css file

                                    string compressedcss = "";
                                    string uncompcss = "";
                                    string templatecsspath = IsAdmin() ? GetAdminTemplatePath() : GetTemplateCssPath();
                                    string imagerewrite = IsAdmin() ? "/Administrator/Templates/Default/css/" : presetObj.ActiveTheme.ToLower().Equals("default") ? string.Format("/Templates/{0}/css", GetActiveTemplate) : string.Format("/Templates/{0}/themes/{1}/css", GetActiveTemplate, presetObj.ActiveTheme);
                                    string cssText = IsAdmin() ? "admin.css" : "template.css";

                                    using (StreamReader rdr = new StreamReader(templatecsspath))
                                    {
                                        uncompcss = rdr.ReadToEnd();
                                    }
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, imagerewrite, Request.ApplicationPath == "/" ? "" : Request.ApplicationPath, "images");
                                    sw.Write("\n");
                                    sw.Write("/*-----'" + cssText + "'----*/");
                                    sw.Write("\n");
                                    sw.Write(compressedcss);
                                    sw.Write("\n");
                                   
                                    string path = Server.MapPath("~/js/jquery-ui-1.8.14.custom/css/redmond/jquery-ui-1.8.16.custom.css");
                                    using (StreamReader rdr = new StreamReader(path))
                                    {
                                        uncompcss = rdr.ReadToEnd();
                                    }
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                    compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, "/js/jquery-ui-1.8.14.custom/css/redmond/", Request.ApplicationPath == "/" ? "" : Request.ApplicationPath, "images");

                                    sw.Write("\n");
                                    sw.Write("/*-----JQuery UI----*/");
                                    sw.Write("\n");
                                    sw.Write(compressedcss);
                                    sw.Write("\n");
                                    
                                    ///Read the module files    
                                    if (!IsAdmin())
                                    {
                                        lstCssInclude.Insert(0, new KeyValue("~/Administrator/Templates/Default/css/front.css", "/Administrator/Templates/Default/css/"));
                                        lstCssInclude.Insert(1, new KeyValue("~/Administrator/Templates/Default/css/core.css", "/Administrator/Templates/Default/css/"));

                                    }
                                    else
                                    {
                                        lstCssInclude.Insert(0, new KeyValue("~/Administrator/Templates/Default/css/core.css", "/Administrator/Templates/Default/css/"));

                                    }
                                    foreach (KeyValue cssfile in lstCssInclude)
                                    {
                                        using (StreamReader rdr = new StreamReader(Server.MapPath(cssfile.Key)))
                                        {
                                            uncompcss = rdr.ReadToEnd();
                                        }
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.CssMinify(uncompcss);
                                        compressedcss = CssJscriptOptimizer.Minifiers.CssMinifier.RewriteCssImagePath(compressedcss, string.Format("{0}", cssfile.Value), Request.ApplicationPath == "/" ? "" : Request.ApplicationPath, "images");

                                        sw.Write("\n");
                                        sw.Write("/*-----" + Path.GetFileName(cssfile.Key) + "----*/");
                                        sw.Write("\n");
                                        sw.Write(compressedcss);
                                        sw.Write("\n");
                                    }
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
                }
                else
                {
                    Literal SageFrameModuleCSSlinks = this.Page.FindControl("SageFrameModuleCSSlinks") as Literal;
                    if (SageFrameModuleCSSlinks != null)
                    {
                        SageFrameModuleCSSlinks.Text = "";
                    }
                    SetTemplateCss();                    
                    AddModuleCssToPage("~/js/jquery-ui-1.8.14.custom/css/redmond/jquery-ui-1.8.16.custom.css");                    
                    foreach (KeyValue cssfile in lstCssInclude)
                    {
                        AddModuleCssToPage(cssfile.Key);
                    }
                }
            }

        }

        public bool IsUserLoggedIn()
        {
            bool IsLoggedIn = false;
            if (HttpContext.Current.User != null)
            {
                MembershipUser user = Membership.GetUser();
                FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;

                if (identity != null)
                {
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    int LoggedInPortalID = ticket.UserData != "" && ticket.UserData != null ? int.Parse(ticket.UserData.ToString()) : 0;

                    if (user != null)
                    {
                        string[] sysRoles = SystemSetting.SUPER_ROLE;
                        if (GetPortalID == LoggedInPortalID || Roles.IsUserInRole(user.UserName, sysRoles[0]))
                        {
                            IsLoggedIn = true;
                        }
                    }
                }

            }
            return IsLoggedIn;
        }

        private string GenerateUniqueId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public void LoadModuleJs()
        {

            List<CssScriptInfo> lstJsColl = new List<CssScriptInfo>();
            lstJsColl.AddRange(GetCorejsFiles());
            List<CssScriptInfo> lstJsTop = new List<CssScriptInfo>();
            List<CssScriptInfo> lstJsBottom = new List<CssScriptInfo>();
            if (HttpContext.Current.Session["ModuleJs"] != null)
            {
                lstJsColl.AddRange(HttpContext.Current.Session["ModuleJs"] as List<CssScriptInfo>);
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

        private void OptimizeJs(List<CssScriptInfo> lstJsColl, int Mode)
        {
            Literal LitSageScript = Mode == 1 ? Page.Header.FindControl("LitSageScript") as Literal : Page.Header.FindControl("SageFrameModuleCSSlinks") as Literal;

            List<string> lstJs = new List<string>();
            foreach (CssScriptInfo js in lstJsColl)
            {
                lstJs.Add(js.ModuleName);
            }
            lstJs.Insert(0, IsAdmin() ? "admin" : "portal");
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsCompressJs = bool.Parse(pagebase.GetSettingsByKey(SageFrameSettingKeys.OptimizeJs));
            if (IsCompressJs)
            {

                Hashtable hst = new Hashtable();

                ///Check cache and refresh it if the files optimized folder do not exist              
                if (HttpContext.Current.Cache["SageFrameJs"] != null)
                {
                    hst = (Hashtable)HttpContext.Current.Cache["SageFrameJs"];
                    Hashtable hstNew = new Hashtable();
                    foreach (string modulekey in hst.Keys)
                    {
                        string file = string.Format("{0}.js", hst[modulekey].ToString());
                        if (File.Exists(Server.MapPath(string.Format("~/Optimized/{0}", file))))
                        {
                            hstNew.Add(modulekey, hst[modulekey].ToString());
                        }
                    }
                    HttpContext.Current.Cache["SageFrameJs"] = hstNew;
                }


                if (HttpContext.Current.Cache["SageFrameJs"] != null)
                {
                    hst = (Hashtable)HttpContext.Current.Cache["SageFrameJs"];
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
                string[] jsArr = lstJs.ToArray().Distinct().ToArray();
                ///Read the map file and check if the css for this combination already exists

                bool IsExists = false;
                string optimizedjs = string.Empty;
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
                        HttpContext.Current.Cache["SageFrameJs"] = hst;
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
                                        string compressedjs = CssJscriptOptimizer.Minifiers.JsMinifier.GetMinifiedCode(uncompjs);
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
                        if (!obj.AllowOptimization && LitSageScript!=null)
                        {
                            string uncompressedjs = "<script src=\"" + ResolveUrl(string.Format("~/{0}/{1}", obj.Path, obj.FileName)) + "\" type=\"text/javascript\"></script>";
                            LitSageScript.Text += uncompressedjs;
                        }
                    }
                }
            }
            else
            {
                if (LitSageScript != null)
                {
                    foreach (CssScriptInfo obj in lstJsColl)
                    {

                        string js = "<script src=\"" + ResolveUrl(string.Format("~/{0}/{1}", obj.Path, obj.FileName)) + "\" type=\"text/javascript\"></script>";
                        LitSageScript.Text += js;
                    }
                }
            }
        }

        private List<CssScriptInfo> GetCorejsFiles()
        {

            return (CoreJs.GetList(IsAdmin(), IsUserLoggedIn()));
        }

        private void SetGoogleAnalytics()
        {
            try
            {
                if (!Request.RawUrl.Contains("Admin") || !Request.RawUrl.Contains("Super-User"))
                {

                    Hashtable hst = new Hashtable();
                    if (HttpContext.Current.Cache["SageGoogleAnalytics"] != null)
                    {
                        hst = (Hashtable)HttpContext.Current.Cache["SageGoogleAnalytics"];
                    }
                    else
                    {
                        SettingProvider sp = new SettingProvider();
                        List<GoogleAnalyticsInfo> objList = sp.GetGoogleAnalyticsActiveOnlyByPortalID(GetPortalID);
                        foreach (GoogleAnalyticsInfo objl in objList)
                        {
                            hst.Add("SageGoogleAnalytics_" + objl.PortalID, objl.GoogleJSCode);
                        }
                        HttpContext.Current.Cache.Insert("SageGoogleAnalytics", hst);
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

        public int GetPortalID
        {
            get
            {
                try
                {
                    if (Session["SageFrame.PortalID"] != null && Session["SageFrame.PortalID"].ToString() != "")
                    {
                        return int.Parse(Session["SageFrame.PortalID"].ToString());
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

        public string GetActiveTemplate
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

                        string templateName = TemplateController.GetActiveTemplate(GetPortalID).TemplateSeoName;
                        string tempPath = Utils.GetAbsolutePath(templateName);
                        if (Directory.Exists(tempPath))
                            return templateName;
                        else
                            return "Default";

                    }
                }
                catch
                {
                    return "Default";
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
                        return (PresetHelper.LoadActivePagePreset(GetActiveTemplate, GetPageSEOName(Request.Url.ToString())));
                    }
                }
                catch (Exception)
                {

                    throw;
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

        public void SetActiveTemplate(string ActiveTemplate)
        {
            Session["SageFrame.ActiveTemplate"] = ActiveTemplate;
        }

        public void SetPortalID(int portalID)
        {
            PortalID = portalID;
        }

        public int GetStoreID
        {
            get
            {
                try
                {
                    if (Session["SageFrame.StoreID"] != null && Session["SageFrame.StoreID"].ToString() != "")
                    {
                        return int.Parse(Session["SageFrame.StoreID"].ToString());
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

        public void SetStoreID(int storeID)
        {
            StoreID = storeID;
        }

        public System.Nullable<Int32> GetCustomerID
        {
            get
            {
                try
                {
                    if (Session["SageFrame.CustomerID"] != null && Session["SageFrame.CustomerID"].ToString() != "")
                    {
                        return int.Parse(Session["SageFrame.CustomerID"].ToString());
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

        public PlaceHolder LoadControl(string UpdatePanelIDPrefix, bool IsPartialRendring, PlaceHolder ContainerControl, string ControlSrc, string PaneName, string strUserModuleID, string suffixClass, string HeaderText, bool IsUserAdmin, HtmlGenericControl divControl, HtmlGenericControl paneControl,bool IsEdit)
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
                        if(IsEdit)
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

        public UpdatePanel CreateUpdatePanel(string Prefix, UpdatePanelUpdateMode Upm, int PaneUpdatePanelCount)
        {
            UpdatePanel udp = new UpdatePanel();
            udp.UpdateMode = Upm;
            PaneUpdatePanelCount++;
            udp.ID = "_udp_" + "_" + PaneUpdatePanelCount + Prefix;
            //udp.EnableViewState = false;
            return udp;
        }

        public string ConvetVisibility(bool i)
        {
            string Visible = "Same As Page";
            if (i == false)
            {
                Visible = "Page Editor Only";
            }
            return Visible;
        }

        private string SettingPortal
        {
            get
            {
                string strPortalName = "default";
                try
                {
                    if (HttpContext.Current.Session["SageFrame.PortalSEOName"] != null)
                    {
                        strPortalName = HttpContext.Current.Session["SageFrame.PortalSEOName"].ToString();
                    }
                }
                catch
                {
                    strPortalName = "default";
                }
                return strPortalName;
            }
        }

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

        protected void ProcessException(Exception exc)
        {
            int inID = 0;
            inID = ErrorLogController.InsertLog((int)SageFrame.Web.SageFrameEnums.ErrorType.AdministrationArea, 11, exc.Message, exc.ToString(),
             HttpContext.Current.Request.UserHostAddress, Request.RawUrl, true, GetPortalID, GetUsername);

            ShowMessage(SageMessageTitle.Exception.ToString(), exc.Message, exc.ToString(), SageMessageType.Error);
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

        public string TemplateName
        {
            get
            {
                SageFrameConfig sfConfig = new SageFrameConfig();
                return sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalCssTemplate);
            }
        }

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
    }
}
