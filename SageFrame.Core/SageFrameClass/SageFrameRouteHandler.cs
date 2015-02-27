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
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;

namespace SageFrame
{
    public class SageFrameRouteHandler: IRouteHandler
    {
        public SageFrameRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

    public string VirtualPath { get; private set; }

    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        var page = BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page)) as SageFrameRoute;
        if (requestContext.RouteData.Values["PagePath"] != null)
        {
            page.PagePath = requestContext.RouteData.Values["PagePath"].ToString();
        }
        if (requestContext.RouteData.Values["PortalSEOName"] != null)
        {
            page.PortalSEOName = requestContext.RouteData.Values["PortalSEOName"].ToString();
        }
        if (requestContext.RouteData.Values["UserModuleID"] != null)
        {
            page.UserModuleID = requestContext.RouteData.Values["UserModuleID"].ToString();
        }
        if (requestContext.RouteData.Values["ControlType"] != null)
        {
            page.ControlType = requestContext.RouteData.Values["ControlType"].ToString();
        }
            if (requestContext.RouteData.Values["uniqueWord"] != null)
            {
                Route route = (Route)requestContext.RouteData.Route;
                string url = route.Url;

                if (url.Equals("category/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/category/{*uniqueWord}"))
                {
                    page.ControlMode = "category";
                }
                else if (url.Equals("item/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/item/{*uniqueWord}"))
                {
                    page.ControlMode = "item";
                }
                else if (url.Equals("tags/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/tags/{*uniqueWord}"))
                {
                    page.ControlMode = "tags";
                }
                else if (url.Equals("tagsitems/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/tagsitems/{*uniqueWord}"))
                {
                    page.ControlMode = "tagsitems";
                }
                else if (url.Equals("search/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/search/{*uniqueWord}"))
                {
                    page.ControlMode = "search";
                }
                else if (url.Equals("option/{*uniqueWord}") || url.Equals("portal/{PortalSEOName}/option/{*uniqueWord}"))
                {
                    page.ControlMode = "option";
                }

                string pageName = requestContext.RouteData.Values["uniqueWord"].ToString();
                if (pageName.IndexOf(".aspx") > 0)
                {
                    page.Key = pageName.Substring(0, pageName.IndexOf(".aspx"));
                    page.PagePath = "Show-Details-Page.aspx";
                }
            }
        return page;
    }

    }
}
