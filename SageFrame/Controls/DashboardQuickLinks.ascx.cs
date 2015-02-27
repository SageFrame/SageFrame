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
using SageFrame.Web;
using SageFrame.Dashboard;
using System.Text;
using SageFrame.Templating;
using System.Collections.Generic;
using SageFrame.Utilities;

public partial class Controls_DashboardQuickLinks : BaseAdministrationUserControl
{
    public string appPath = "",UserName=string.Empty,PortalName="";
    public int PortalID = 0;
    public int IsSideBarVisible = 0;
    protected void Page_Init(object sedner, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        UserName = GetUsername;
        PortalID = GetPortalID;
        PortalName = GetPortalSEOName;
     
        SageFrameConfig sfConfig = new SageFrameConfig();
        bool ShowSideBar = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.ShowSideBar);
        IsSideBarVisible = ShowSideBar ? 1 : 0;
        BuildQuickLinks();       
        lblVersion.Text = string.Format("V {0}",Config.GetSetting("SageFrameVersion"));
    }

    public void BuildQuickLinks()
    {
        List<QuickLink> lstQuickLinks = DashboardController.GetQuickLinks(GetUsername, GetPortalID);
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul>");
        foreach (QuickLink item in lstQuickLinks)
        {
            string image = string.Format("{0}/Modules/Dashboard/Icons/{1}", appPath, item.ImagePath);
            string url = Utils.BuildURL(item.URL,appPath,GetPortalSEOName,GetPortalID);
            sb.Append("<li><a href='" + url + "'><img src='" + image + "' width='24' height='24' alt='" + item.DisplayName + "' /><span>" + item.DisplayName + "</span></a></li>");
        }
        sb.Append("</ul>");
        ltrQuicklinks.Text = sb.ToString();

    }
  
}
