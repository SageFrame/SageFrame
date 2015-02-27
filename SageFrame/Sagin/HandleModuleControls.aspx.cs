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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Framework;
using SageFrame.Web;
using SageFrame.ModuleControls;
using SageFrame;
using System.Collections.Generic;
using SageFrame.Shared;
using SageFrame.Security;

public partial class Sagin_HandleModuleControls : PageBase, SageFrameRoute
{
    public int portalid = 0, tabcount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        string redirectPathLogin = "", redirectPathNoAccess = "";
        SageFrameConfig sfConfig = new SageFrameConfig();
        if (GetPortalID > 1)
        {

            redirectPathLogin =
                ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" +
                           sfConfig.GetSettingsByKey(
                               SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
            redirectPathNoAccess =
                ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" +
                           sfConfig.GetSettingsByKey(
                               SageFrameSettingKeys.PortalPageNotAccessible) + ".aspx");

        }
        else
        {

            redirectPathLogin = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
            redirectPathNoAccess = ResolveUrl("~/sf/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible) + ".aspx");

        }



        string url = Request.RawUrl.ToString();
        int UserModuleID = 0;
        if (Request.QueryString["uid"] != null)
        {
            UserModuleID = int.Parse(Request.QueryString["uid"].ToString());
            MembershipController _member = new MembershipController();
            if (!_member.EditPermissionExists(UserModuleID, GetPortalID, GetUsername))
            {
                Response.Redirect(redirectPathNoAccess);
            }
            LoadModuleControls(UserModuleID);

        }
        if (Request.QueryString["pid"] != null)
        {
            portalid = int.Parse(Request.QueryString["pid"].ToString());
        }



        SetPortalCofig();
        LoadMessageControl();




        string appPath = Request.ApplicationPath;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar1", " var SageFrameAppPath='" + appPath + "';", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar2", " var SageFrameUserName='" + GetUsername + "';", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar3", " var SageFramePortalName='" + GetPortalSEOName + "';", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar4", " var SageFramePortalID='" + GetPortalID + "';", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageFrameGlobalVar5", " var SageFrameActiveTemplate='" + GetActiveTemplate + "';", true);
    }
    public void LoadMessageControl()
    {
        PlaceHolder phdPlaceHolder = Page.FindControl("message") as PlaceHolder;
        if (phdPlaceHolder != null)
        {
            LoadControl(phdPlaceHolder, "~/Controls/Message.ascx");
        }
    }
    private void LoadControl(PlaceHolder ContainerControl, string controlSource)
    {
        UserControl ctl = this.Page.LoadControl(controlSource) as UserControl;
        ctl.EnableViewState = true;
        ContainerControl.Controls.Add(ctl);
    }

    private void LoadModuleControls(int UserModuleID)
    {
        int MID = ModuleControlDataProvider.GetModuleID(UserModuleID);
        string MName = ModuleControlDataProvider.GetModuleName(UserModuleID);
        List<ModuleControlInfo> lstModCtls = ModuleControlDataProvider.GetControlType(MID);
        tabcount = lstModCtls.Count;
        ShowHideTabs(lstModCtls);
        string appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath + "/" : "/";
        foreach (ModuleControlInfo obj in lstModCtls)
        {

            switch (obj.ControlType)
            {
                case "2":
                    LoadControl(pchEdit, appPath + obj.ControlSrc, UserModuleID.ToString());
                    break;
                case "3":
                    LoadControl(lstModCtls.Count > 2 ? pchSetting : pchEdit, appPath + obj.ControlSrc, UserModuleID.ToString());
                    break;
            }
        }
    }

    private void ShowHideTabs(List<ModuleControlInfo> lstModCtls)
    {
        bool ShowEdit = lstModCtls.Exists(
                delegate(ModuleControlInfo obj)
                {
                    return (obj.ControlType == "2");
                }
            );
        bool ShowSettings = lstModCtls.Exists(
                delegate(ModuleControlInfo obj)
                {
                    return (obj.ControlType == "3");
                }
            );
        TabPanelEdit.Visible = true;
        TabPanelSettings.Visible = tabcount > 2 ? ShowSettings : false;

        if (tabcount == 2 && ShowSettings)
        {
            TabPanelEdit.HeaderText = "Settings";
        }

    }

    private void LoadControl(PlaceHolder ContainerControl, string controlSource, string UserModuleID)
    {
        SageUserControl ctl = this.Page.LoadControl(controlSource) as SageUserControl;
        ctl.EnableViewState = true;
        ctl.SageUserModuleID = UserModuleID;
        ContainerControl.Controls.Add(ctl);
    }

    private void SetPortalCofig()
    {

        Session["SageFrame.PortalID"] = portalid;

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


        PlaceHolder phd = Page.FindControl("message") as PlaceHolder;
        if (phd != null)
        {
            foreach (Control c in phd.Controls)
            {

                if (c.GetType().FullName.ToLower() == "ASP.Controls_message_ascx".ToLower())
                {
                    SageUserControl tt = (SageUserControl)c;
                    tt.Modules_Message_ShowMessage(tt, MessageTitle, Message, CompleteMessage, isSageAsyncPostBack, MessageType, strCssClass);


                }


            }

        }

    }
}


