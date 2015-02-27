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
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.Framework;
public partial class Modules_Admin_LoginControl_LoginStatus : SageUserControl
{
    public string RegisterURL = string.Empty;
    public string profileURL = string.Empty;
    public string profileText = string.Empty;
    
    bool IsUseFriendlyUrls = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        SageFrameConfig pb = new SageFrameConfig();
        IsUseFriendlyUrls = pb.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
        //if (!IsPostBack)
        //{
            profileText = GetSageMessage("LoginStatus", "MyProfile");
            Literal lnkProfileUrl = (Literal)LoginView1.TemplateControl.FindControl("lnkProfileUrl");
            RegisterURL = pb.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage) + ".aspx";
            if (pb.GetSettingsByKey(SageFrameSettingKeys.PortalShowProfileLink) == "1")
            {

                string profilepage = pb.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfilePage);
                profilepage = profilepage.ToLower().Equals("user-profile") ? string.Format("/sf/{0}", profilepage) : string.Format("/{0}", profilepage);
                if (GetPortalID > 1)                {
                    
                    profileURL = "<a  href='" +  ResolveUrl("~/portal/" + GetPortalSEOName + profilepage + ".aspx") + "'>" + profileText + "</a>";
                }
                else
                {                    
                    profileURL = "<a  href='" + ResolveUrl("~" + profilepage + ".aspx") + "'>" + profileText + "</a>";

                }
               
            }
            else
            {
                profileURL = "";
            }
            if (IsUseFriendlyUrls)
            {
                if (GetPortalID > 1)
                {
                    RegisterURL = ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage) + ".aspx");
                }
                else
                {
                    RegisterURL = ResolveUrl("~/sf/" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage) + ".aspx");
                }
            }
            else
            {
                RegisterURL = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage));
            }


            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == true)
                {
                    Label lblProfileURL = LoginView1.FindControl("lblProfileURL") as Label;
                    if (lblProfileURL != null)
                    {
                        if (profileURL != "")
                        {
                            lblProfileURL.Text = "<li>" + profileURL + "</li>";
                            lblProfileURL.Visible = true;
                        }
                        else
                        {
                            lblProfileURL.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect(pb.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");

                    }
                    
                }
            }
            int UserRegistrationType = pb.GetSettingIntByKey(SageFrameSettingKeys.PortalUserRegistration);
            if (UserRegistrationType > 0)
            {
                RegisterURL = "<span><a href='" + RegisterURL + "'>" + GetSageMessage("LoginStatus", "Register") +"</a></span>";
            }
            else
            {
                RegisterURL = "";
            }
        //}
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        SetUserRoles(string.Empty);
        SageFrameConfig pb = new SageFrameConfig();
        bool IsUseFriendlyUrls = pb.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
        if (IsUseFriendlyUrls)
        {
            if (GetPortalID > 1)
            {
                Response.Redirect("~/portal/" + GetPortalSEOName + "/" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
            }
            else
            {
                Response.Redirect("~/" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage));
        }
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
}
