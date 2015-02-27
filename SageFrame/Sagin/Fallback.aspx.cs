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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using SageFrame.Templating;
using SageFrame.Web;
using SageFrame.Framework;

public partial class Sagin_Fallback : PageBase
{
    public int PortalID = 0;
    public string appPath = string.Empty;
    public string fallBackPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgLogo.ImageUrl = ResolveUrl("~/") + "images/sageframe.png";
        SageFrameConfig sfConfig = new SageFrameConfig();
        appPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
        string pagePath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BreadCrumGlobal1", " var BreadCrumPagePath='" + pagePath + "';", true);
        pagePath = GetPortalID == 1 ? pagePath : pagePath + "/portal/" + GetPortalSEOName;
        PortalID = GetPortalID;

        if (PortalID > 1)
        {
            fallBackPath = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
        }
        else
        {
            fallBackPath = ResolveUrl("~/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
        }

        if (Session["TemplateError"] != null)
        {
            Exception ex = Session["TemplateError"] as Exception;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<h3>{0}</h3>",ex.Message));
            sb.Append(string.Format("<p>{0}</p>", ex.ToString()));
            ltrErrorMessage.Text = sb.ToString();
        }
    }
}
