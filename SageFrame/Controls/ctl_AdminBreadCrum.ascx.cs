/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2010 by SageFrame
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
using System.IO;
using SageFrame.Common.Shared;
using SageFrame.BreadCrum;
using System.Text;

namespace SageFrame.Controls
{
    public partial class ctl_AdminBreadCrum : BaseUserControl
    {
        public int PortalID = 0;
        public int MenuID = 0;
        public string PageName = "", AppPath = string.Empty, pagePath = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            Initialize();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            pagePath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
            pagePath = GetPortalID == 1 ? pagePath : pagePath + "/portal/" + GetPortalSEOName;
            BuildBreadCrumb();

        }
        public void Initialize()
        {
            PortalID = GetPortalID;

        }

        public void BuildBreadCrumb()
        {
            string breadcrumb = string.Empty;
            PageName = Path.GetFileNameWithoutExtension(PagePath);
            BreadCrumInfo obj = BreadCrumDataProvider.GetBreadCrumb(PageName, PortalID, MenuID);
            if (obj != null)
            {
                breadcrumb = obj.TabPath != "" ? obj.TabPath : "";

                string[] arrPages = breadcrumb.Split('/');
                StringBuilder html = new StringBuilder();
                html.Append("<ul>");
                int length = arrPages.Length;
                string childPages = "";
                int index = 0;
                foreach (string item in arrPages)
                {
                    if (item != "")
                    {
                        childPages += item + "/";
                        childPages = childPages.Substring(0, childPages.Length - 1);
                        var pageLink = pagePath + "/" + childPages + ".aspx";

                        if (item.IndexOf("Admin") > -1)
                        {
                            pageLink = pagePath + "/Admin/Admin.aspx";
                        }
                        if (item.IndexOf("Super-User") > -1)
                        {
                            pageLink = pagePath + "/Admin/Admin.aspx";
                        }

                        childPages += "/";
                        if (index == length - 1)
                        {
                            if (item == "Admin" || item == "Super-User")
                            {
                                html.Append("");
                            }
                            else
                            {
                                html.Append("<li><span>" + item.Replace("-", " ") + "</span></li>");
                            }

                        }
                        else
                        {
                            if (item == "Admin" || item == "Super-User")
                            {
                                var homeimage = Request.ApplicationPath != "/" ? Request.ApplicationPath : "" + "/Administrator/Templates/default/images/home-icon.png";
                                html.Append("<li class='sfFirst'><a href=" + pageLink + "><img src=" + homeimage + "  alt='Home' /></a></li>");
                            }
                            else
                            {
                                html.Append("<li><a href=" + pageLink + ">" + item.Replace("-", " ") + "</a></li>");
                            }
                        }
                    }
                    index++;
                }
                html.Append("</ul>");

                ltrBreadCrumb.Text = html.ToString();
            }
        }

    }
}