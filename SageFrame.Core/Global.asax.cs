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
using System.Web.SessionState;
using System.Web.Routing;
using SageFrame.RolesManagement;
using SageFrame.Web;
using SageFrame.Framework;
using System.Data.SqlClient;
using SageFrame.Utilities;
using System.Web.UI;
using System.IO.Compression;
using System.IO;
using SageFrame.Common;

namespace SageFrame
{
    public class Global : System.Web.HttpApplication
    {
        public string ANONYMOUS_ROLEID;
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                string IsInstalled = Config.GetSetting("IsInstalled").ToString();
                string InstallationDate = Config.GetSetting("InstallationDate").ToString();
                if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
                {
                    SageFrameConfig pagebase = new SageFrameConfig();
                    RolesManagementInfo res = RolesManagementController.GetRoleIDByRoleName(SystemSetting.AnonymousUsername);
                    if (res != null)
                    {
                        SystemSetting.ANONYMOUS_ROLEID = res.RoleId.ToString();
                    }
                    bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
                    if (IsUseFriendlyUrls)
                    {
                        RegisterRoutes(RouteTable.Routes);
                    }
                }
            }
            catch
            {
            }
            
        }
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("", new StopRoutingHandler()));
            routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
            routes.RouteExistingFiles = false;
            routes.Add(new Route("{Template}/{TemplateName}/images/{imagefolder}/{filename}.jpg", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{imagefolder}/{filename}.png", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{imagefolder}/{filename}.gif", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{imagefolder}/{filename}.bmp", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{filename}.png", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{filename}.jpg", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{filename}.gif", new StopRoutingHandler()));
            routes.Add(new Route("{Template}/{TemplateName}/images/{filename}.bmp", new StopRoutingHandler()));

            routes.Add("SageFrameRouting0", new Route("portal/{PortalSEOName}/category/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            routes.Add("SageFrameRouting01", new Route("portal/{PortalSEOName}/item/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            routes.Add("SageFrameRouting02", new Route("portal/{PortalSEOName}/tags/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            routes.Add("SageFrameRouting03", new Route("portal/{PortalSEOName}/tagsitems/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            routes.Add("SageFrameRouting04", new Route("portal/{PortalSEOName}/search/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            routes.Add("SageFrameRouting05", new Route("portal/{PortalSEOName}/option/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));            

            routes.Add("SageFrameRouting12", new System.Web.Routing.Route("sf/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Admin.aspx")));
            routes.Add("SageFrameRouting13", new System.Web.Routing.Route("portal/{PortalSEOName}/sf/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Admin.aspx")));
            
            routes.Add("SageFrameRouting1", new Route("portal/{PortalSEOName}/{UserModuleID}/Sagin/{ControlType}/{*PagePath}", new SageFrameRouteHandler("~/Sagin/ManagePage.aspx")));
            routes.Add("SageFrameRouting2", new Route("{UserModuleID}/Sagin/{ControlType}/{*PagePath}", new SageFrameRouteHandler("~/Sagin/ManagePage.aspx")));
            routes.Add("SageFrameRouting3", new System.Web.Routing.Route("portal/{PortalSEOName}/admin/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting4", new System.Web.Routing.Route("portal/{PortalSEOName}/Super-User/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting10", new System.Web.Routing.Route("admin/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting11", new System.Web.Routing.Route("Admin.aspx", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting5", new System.Web.Routing.Route("Super-User.aspx", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting6", new System.Web.Routing.Route("Super-User/{*PagePath}", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRouting7", new System.Web.Routing.Route("portal/{PortalSEOName}/{*PagePath}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            

            //routes.Add("SageFrameRouting8", new System.Web.Routing.Route("/Admin.aspx", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            //routes.Add("SageFrameRouting9", new System.Web.Routing.Route("/Super-User.aspx", new SageFrameRouteHandler("~/Sagin/Default.aspx")));
            routes.Add("SageFrameRoutingCategory", new Route("category/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            
            routes.Add("SageFrameRoutingProductDetail", new Route("item/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            
            routes.Add("SageFrameRoutingTagsAll", new Route("tags/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            
            routes.Add("SageFrameRoutingTagsItems", new Route("tagsitems/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            
            routes.Add("SageFrameRoutingSearchTerm", new Route("search/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));

            routes.Add("SageFrameRoutingShoppingOption", new Route("option/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));

            routes.Add("SageFrameRoutingCouponsAll", new Route("coupons/{*uniqueWord}", new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));
            
            routes.Add("SageFrameRouting9", new Route("{*PagePath}",new SageFrameRouteHandler("~/" + CommonHelper.DefaultPage)));

            
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            try
            {

                HttpContext.Current.Session["ModuleCss"] = new List<CssScriptInfo>();
                HttpContext.Current.Session["ModuleJs"] = new List<CssScriptInfo>();

                string IsInstalled = Config.GetSetting("IsInstalled").ToString();
                string InstallationDate = Config.GetSetting("InstallationDate").ToString();
                if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
                {
                    HttpContext.Current.Cache.Remove("SageSetting");
                    HttpContext.Current.Session["SageFrame.PortalID"] = null;
                    SessionTracker sessionTracker = new SessionTracker();
                    if (sessionTracker != null)
                    {
                        SageFrame.Web.SessionLog sLog = new SageFrame.Web.SessionLog();
                        sLog.SessionLogStart(sessionTracker);
                    }
                    HttpContext.Current.Session["Tracker"] = sessionTracker;
                }
            }
            catch
            {
            }
        }

       

        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

           
        }
        public void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            try
            {

                
                string IsInstalled = Config.GetSetting("IsInstalled").ToString();
                string InstallationDate = Config.GetSetting("InstallationDate").ToString();
                if ((IsInstalled != "" && IsInstalled != "false") && InstallationDate != "")
                {
                    if ((Context.Session != null))
                    {
                        SessionTracker tracker = (SessionTracker)Session["Tracker"];
                        if ((tracker != null))
                        {
                            tracker.AddPage(Request.Url.ToString());
                        }
                    }
                }
                //else
                //{
                //    string path = HttpContext.Current.Server.MapPath("~/");
                //    HttpContext.Current.Response.Redirect("./Install/InstallWizard.aspx");
                //}
            }
            catch
            {
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                HttpRequest SageRequest = HttpContext.Current.Request;
                if (IsExtensionisAllowedToCompress(SageRequest))
                {
                    HttpResponse Response = HttpContext.Current.Response;
                    if (IsCompressionAllowed()) // If client browser supports HTTP compression
                    {
                        //Browser supported encoding format
                        //string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
                        //if client browser supports both "deflate"
                        //and "gzip" compression, Then we will consider "deflate" first , because it is
                        // more efficient than "gzip"
                        HttpApplication app = sender as HttpApplication;
                        string AcceptEncoding = app.Request.Headers["Accept-Encoding"];
                        Stream prevUncompressedStream = app.Response.Filter;

                        if (!(app.Context.CurrentHandler is Page ||
                            app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") ||
                            app.Request["HTTP_X_MICROSOFTAJAX"] != null)
                            return;

                        if (AcceptEncoding == null || AcceptEncoding.Length == 0)
                            return;

                        AcceptEncoding = AcceptEncoding.ToLower();
                        if (AcceptEncoding != null && AcceptEncoding.Contains("deflate"))
                        {
                            Response.AppendHeader("Content-Encoding", "deflate");
                            Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);

                        }
                        else
                        {
                            Response.AppendHeader("Content-Encoding", "gzip");
                            Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);

                        }
                    }

                    // Allow proxy servers to cache encoded and unencoded versions separately
                    Response.AppendHeader("Vary", "Content-Encoding");
                }
            }
            catch
            {
            }
            try
            {
                HttpRequest SageRequest = HttpContext.Current.Request;
                if (IsExtensionisAllowedToCompress(SageRequest))
                {
                    HttpResponse Response = HttpContext.Current.Response;
                    if (IsCompressionAllowed()) // If client browser supports HTTP compression
                    {
                        //Browser supported encoding format
                        string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
                        //if client browser supports both "deflate"
                        //and "gzip" compression, Then we will consider "deflate" first , because it is
                        // more efficient than "gzip"
                        if (AcceptEncoding != null && AcceptEncoding.Contains("deflate"))
                        {
                            Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);
                            Response.AppendHeader("Content-Encoding", "deflate");
                        }
                        else
                        {
                            Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
                            Response.AppendHeader("Content-Encoding", "gzip");
                        }
                    }

                    // Allow proxy servers to cache encoded and unencoded versions separately
                    Response.AppendHeader("Vary", "Content-Encoding");
                }
            }
            catch
            {
            }
        }

        public bool IsExtensionisAllowedToCompress(HttpRequest SageRequest)
        {
            string RequestRawURL = SageRequest.RawUrl;
            return (CommonHelper.Contains(SystemSetting.INCOMPRESSIBLE_EXTENSIONS, RequestRawURL));
        }

        public bool IsCompressionAllowed()
        {
            //Browser supported encoding format
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];

            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                if (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))
                    return true; ////If browser supports encoding
            }

            return false;

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (null != HttpContext.Current)
            {
                string url = HttpContext.Current.Request.Url.ToString();
                if (!url.EndsWith("png") && !url.EndsWith("jpg") && !url.EndsWith("gif") && !url.EndsWith("jpeg") && !url.EndsWith("bmp") )
                {
                    ErrorHandler erHandler = new ErrorHandler();
                    erHandler.LogCommonException(ex);
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                 SessionTracker sessionTracker = (SessionTracker)Session["Tracker"];
                 FormsAuthentication.SignOut();
                if ((sessionTracker == null))
                {
                    return;
                }
                else
                {
                    SageFrame.Web.SessionLog sLog = new SageFrame.Web.SessionLog();
                    sLog.SessionLogEnd(sessionTracker);
                }

            }
            catch
            {
            }
            if (HttpContext.Current != null)
            {
                if (null != HttpContext.Current.Session)
                    HttpContext.Current.Session.Abandon();
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

      
    }
}