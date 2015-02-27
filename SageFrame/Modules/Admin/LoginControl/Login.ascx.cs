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
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Framework;
using System.Web.Security;
using SageFrame.Web;
using SageFrame.RolesManagement;
using SageFrame.Web.Utilities;
using SageFrame.Security.Crypto;
using SageFrame.Security.Helpers;
using SageFrame.Security.Entities;
using SageFrame.Security;

namespace SageFrame.Modules.Admin.LoginControl
{
    public partial class Login : BaseAdministrationUserControl
    {
        string strRoles = string.Empty;
        SageFrameConfig pagebase = new SageFrameConfig();
        public bool RegisterURL = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HideSignUp();
                Password.Attributes.Add("onkeypress", "return clickButton(event,'" + LoginButton.ClientID + "')");
                hypForgetPassword.Text = "Forgot Password?";

                if (GetPortalID > 1)
                {
                    hypForgetPassword.NavigateUrl =
                        ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" +
                                   pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalForgetPassword) + ".aspx");
                }
                else
                {
                    hypForgetPassword.NavigateUrl =
                        ResolveUrl("~/sf/" + pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalForgetPassword) +
                                   ".aspx");
                }
                string registerUrl =
                    ResolveUrl("~/sf/" + pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalUserRegistration) +
                               ".aspx");
                //signup.Attributes.Add("href", ResolveUrl("~/sf/sfRegister.aspx"));
                //signup1.Attributes.Add("href", ResolveUrl("~/sf/sfRegister.aspx"));

                if (pagebase.GetSettingBollByKey(SageFrameSettingKeys.RememberCheckbox))
                {
                    chkRememberMe.Visible = true;
                    lblrmnt.Visible = true;
                }
                else
                {
                    chkRememberMe.Visible = false;
                    lblrmnt.Visible = false;
                }
            }

            if (HttpContext.Current.User != null)
            {
                MembershipUser user = Membership.GetUser();
                FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;

                if (identity != null)
                {
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    int LoggedInPortalID = int.Parse(ticket.UserData.ToString());

                    if (user != null && user.UserName != "")
                    {
                        string[] sysRoles = SystemSetting.SUPER_ROLE;
                        if (GetPortalID == LoggedInPortalID || Roles.IsUserInRole(user.UserName, sysRoles[0]))
                        {
                            RoleController _role = new RoleController();
                            string userinroles = _role.GetRoleNames(GetUsername, LoggedInPortalID);
                            if (userinroles != "" || userinroles != null)
                            {
                                MultiView1.ActiveViewIndex = 1;
                            }
                            else
                            {
                                MultiView1.ActiveViewIndex = 0;
                            }
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 0;
                        }
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                }
            }
          
        }

        private void  HideSignUp()
        {
            int UserRegistrationType = pagebase.GetSettingIntByKey(SageFrameSettingKeys.PortalUserRegistration);
            RegisterURL = UserRegistrationType > 0 ? true : false;
            if (!RegisterURL)
            {
                //this.divSignUp.Visible = false;
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

        protected void LoginButton_Click(object sender, EventArgs e)
        {   
            MembershipController member=new MembershipController();
            RoleController role=new RoleController();
            UserInfo user=member.GetUserDetails(GetPortalID,UserName.Text);
            if (user.UserExists && user.IsApproved)
            {
                if (!(string.IsNullOrEmpty(UserName.Text) && string.IsNullOrEmpty(Password.Text)))
                {
                    if (PasswordHelper.ValidateUser(user.PasswordFormat, Password.Text, user.Password, user.PasswordSalt))
                    {
                        string userRoles = role.GetRoleNames(user.UserName, GetPortalID);
                        strRoles += userRoles;
                        if (strRoles.Length > 0)
                        {
                            SetUserRoles(strRoles);
                            SessionTracker sessionTracker = (SessionTracker)Session["Tracker"];
                            sessionTracker.PortalID = GetPortalID.ToString();
                            sessionTracker.Username = UserName.Text;
                            Session["Tracker"] = sessionTracker;
                            SageFrame.Web.SessionLog SLog = new SageFrame.Web.SessionLog();
                            SLog.SessionTrackerUpdateUsername(sessionTracker, sessionTracker.Username, GetPortalID.ToString());

                            if (Request.QueryString["ReturnUrl"] != null)
                            {
                                
                                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                  user.UserName,
                                  DateTime.Now,
                                  DateTime.Now.AddMinutes(30),
                                  true,
                                  GetPortalID.ToString(),
                                  FormsAuthentication.FormsCookiePath);

                                // Encrypt the ticket.
                                string encTicket = FormsAuthentication.Encrypt(ticket);

                                // Create the cookie.
                                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                                
                                string PageNotFoundPage = Path.Combine(this.Request.ApplicationPath.ToString(), pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotFound) + ".aspx").Replace("\\", "/"); ;
                                string UserRegistrationPage = Path.Combine(this.Request.ApplicationPath.ToString(), pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalRegistrationPage) + ".aspx").Replace("\\", "/"); ;
                                string PasswordRecoveryPage = Path.Combine(this.Request.ApplicationPath.ToString(), pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPasswordRecovery) + ".aspx").Replace("\\", "/"); ;
                                string ForgotPasswordPage = Path.Combine(this.Request.ApplicationPath.ToString(), pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalForgetPassword) + ".aspx").Replace("\\", "/"); ;
                                string PageNotAccessiblePage = Path.Combine(this.Request.ApplicationPath.ToString(), pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalPageNotAccessible) + ".aspx").Replace("\\", "/"); ;

                                string ReturnUrlPage = Request.QueryString["ReturnUrl"].Replace("%2f", "-").ToString();

                                if (ReturnUrlPage == PageNotFoundPage || ReturnUrlPage == UserRegistrationPage || ReturnUrlPage == PasswordRecoveryPage || ReturnUrlPage == ForgotPasswordPage || ReturnUrlPage == PageNotAccessiblePage)
                                {
                                    Response.Redirect("~/" + pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx", false);
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl(Request.QueryString["ReturnUrl"].ToString()), false);
                                }
                            }
                            else
                            {
                                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                 user.UserName,
                                 DateTime.Now,
                                 DateTime.Now.AddMinutes(30),
                                 true,
                                 GetPortalID.ToString(),
                                 FormsAuthentication.FormsCookiePath);

                                // Encrypt the ticket.
                                string encTicket = FormsAuthentication.Encrypt(ticket);

                                // Create the cookie.
                                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                               
                                    if (GetPortalID > 1)
                                    {
                                        Response.Redirect("~/portal/" + GetPortalSEOName + "/" + pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("~/" + pagebase.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx", false);
                                    }
                               
                            }
                        }
                        else
                        {
                            FailureText.Text = string.Format("<p class='sfError'>{0}</p>",GetSageMessage("UserLogin", "Youarenotauthenticatedtothisportal"));//"You are not authenticated to this portal!";
                        }
                    }
                    else
                    {
                        FailureText.Text = string.Format("<p class='sfError'>{0}</p>",GetSageMessage("UserLogin", "UsernameandPasswordcombinationdoesntmatched"));//"Username and Password combination doesn't matched!";
                    }
                }
            }
            else
            {
                FailureText.Text =string.Format("<p class='sfError'>{0}</p>",GetSageMessage("UserLogin", "UserDoesnotExist"));
            }
        }
    }
}