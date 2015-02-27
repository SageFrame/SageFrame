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
using System.Collections.Generic;
using System.Text;
using SageFrame.Templating;


public partial class Controls_Sidebar : BaseAdministrationUserControl
{
    public string appPath = "";
    public int SidebarMode = 0, IsSideBarVisible=0,PortalID = 0;
    public string UserName = "", PortalName = "";
    protected void Page_Init(object sedner, EventArgs e)
    {
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        SageFrameConfig sfConfig = new SageFrameConfig();
        bool ShowSideBar = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.ShowSideBar);
        IsSideBarVisible = ShowSideBar ? 1 : 0;
        if(ShowSideBar)
        GetSidebarStatus();
        UserName = GetUsername;
        PortalID = GetPortalID;
        PortalName = GetPortalSEOName;
        
        if (SidebarMode == 0)
        {
            BuildCollapsedSidebar();
        }
        else
        {
            BuildExpandedSidebar();
        }
      

        
    }
   
    protected void GetSidebarStatus()
    {
        DashbordSettingInfo objSetting = DashboardController.GetSettingByKey(new DashbordSettingInfo(DashboardSettingKeys.SIDEBAR_MODE.ToString(), GetUsername.ToString(), GetPortalID));       
        SidebarMode = objSetting!=null?(objSetting.SettingValue=="open"?1:0):1;
    }

    public void BuildCollapsedSidebar()
    {
        List<Sidebar> lstSidebar=DashboardController.GetSidebar(UserName, PortalID);
        StringBuilder sb=new StringBuilder();
        sb.Append("<div class='sfSidebar sfSidebarhide' style='width:45px' id='sidebar'><ul class='menu'>");
        foreach(Sidebar item in lstSidebar)
        {
                    string image = string.Format("{0}/Modules/Dashboard/Icons/{1}",appPath,item.ImagePath);
                    string url = Utils.BuildURL(item.URL, appPath, GetPortalSEOName, GetPortalID);
                    string sidebartext = string.Format("<span style='display:none'>{0}</span>", item.DisplayName);
                    if (item.ChildCount == 0 && item.ParentID == 0) {
                         sb.Append("<li class='sfLevel0'><a href='" + url + "'><img src='" + image + "'>" + sidebartext + "</a></li>");
                    }
                    else if (item.ChildCount > 0) {
                        sb.Append("<li class='parent sfLevel0'><a href='#'><img src='" + image + "' >" + sidebartext + "</a>");
                        sb.Append("<ul style='visibility: hidden; display: none;' class='acitem sfCollapsed'>");
                        foreach(Sidebar it in lstSidebar) {
                            string url1 = Utils.BuildURL(it.URL, appPath, GetPortalSEOName, GetPortalID);
                            if (it.ParentID == item.SidebarItemID) {
                                 sb.Append("<li><a href='" + url1 + "'>" + it.DisplayName + "</a></li>");
                            }
                        }
                         sb.Append("</ul>");
                         sb.Append("</li>");
                    }
        }
        sb.Append("</ul>");
        string imagePath = string.Format("{0}/Administrator/Templates/Default/images/show-arrow.png",appPath);
        sb.Append("<div class='sfHidepanel clearfix'><a href='#'><img src="+imagePath+" alt='Hide' /><span style='display:none'>Hide Panel</span></a></div>");
        sb.Append("</div>");
        ltrSidebar.Text = sb.ToString();
       
               
             
    }
    public void BuildExpandedSidebar()
    {
        List<Sidebar> lstSidebar = DashboardController.GetSidebar(UserName, PortalID);
        StringBuilder sb = new StringBuilder();
        sb.Append("<div class='sfSidebar' id='sidebar'><ul class='menu'>");
        foreach (Sidebar item in lstSidebar)
        {
            string image = string.Format("{0}/Modules/Dashboard/Icons/{1}", appPath, item.ImagePath);
            string url = Utils.BuildURL(item.URL, appPath, GetPortalSEOName, GetPortalID);
            string sidebartext = string.Format("<span>{0}</span>", item.DisplayName);
            if (item.ChildCount == 0 && item.ParentID == 0)
            {
                sb.Append("<li class='sfLevel0'><a href='" + url + "'><img src='" + image + "'>" + sidebartext + "</a></li>");
            }
            else if (item.ChildCount > 0)
            {
                sb.Append("<li class='parent sfLevel0'><a href='#'><img src='" + image + "' >" + sidebartext + "</a>");
                sb.Append("<ul class='acitem' style='display:none'>");
                foreach (Sidebar it in lstSidebar)
                {
                    string url1 = Utils.BuildURL(it.URL, appPath, GetPortalSEOName, GetPortalID);
                    if (it.ParentID == item.SidebarItemID)
                    {
                        sb.Append("<li><a href='" + url1 + "'>" + it.DisplayName + "</a></li>");
                    }
                }
                sb.Append("</ul>");
                sb.Append("</li>");
            }
        }
        sb.Append("</ul>");
        string imagePath = string.Format("{0}/Administrator/Templates/Default/images/hide-arrow.png", appPath);
        sb.Append("<div class='sfHidepanel clearfix'><a href='#'><img src="+imagePath+" alt='Hide' /><span>Hide Panel</span></a></div>");
        sb.Append("</div>");
        ltrSidebar.Text = sb.ToString();



    }

   
}
