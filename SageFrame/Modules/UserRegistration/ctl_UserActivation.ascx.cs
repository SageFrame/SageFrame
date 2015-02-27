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
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.Framework;
using SageFrame.UserManagement;
using SageFrame.Message;
using SageFrameClass.MessageManagement;
using SageFrame.SageFrameClass.MessageManagement;
using SageFrame.Security;
using SageFrame.Security.Entities;
using System.Web.Security;
using SageFrame.Security.Helpers;

namespace SageFrame.Modules.UserRegistration
{
    public partial class ctl_UserActivation : BaseUserControl
    {
        
        MembershipController _member = new MembershipController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    SageFrameConfig pb = new SageFrameConfig();
                    //hypGotoLogin.NavigateUrl = "~/" + pb.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage) + ".aspx";
                    //hypGotoLogin.Text = GetSageMessage("UserRegistration", "GoToLogin");
                    string ActivationCode = string.Empty;
                    if (Request.QueryString["ActivationCode"] != null)
                    {
                        ActivationCode = Request.QueryString["ActivationCode"].ToString();
                        try
                        {
                            ActivationCode = EncryptionMD5.Decrypt(ActivationCode);
                        }
                        catch
                        {
                            ShowMessage("", GetSageMessage("UserRegistration", "InvalidActivationCode"), "", SageMessageType.Alert);
                            return;
                        }
                        ForgetPasswordInfo sageframeuser = new ForgetPasswordInfo();
                        sageframeuser = UserManagementController.GetUsernameByActivationOrRecoveryCode(ActivationCode, GetPortalID);
                        if (sageframeuser.CodeForUsername != null)
                        {
                            if (!sageframeuser.IsAlreadyUsed)
                            {
                                string UserName = _member.ActivateUser(ActivationCode, GetPortalID);
                                if (!String.IsNullOrEmpty(UserName))
                                {
                                    UserInfo user = _member.GetUserDetails(GetPortalID, UserName);
                                    if (user.UserExists)
                                    {
                                        List<ForgetPasswordInfo> messageTemplates = UserManagementController.GetMessageTemplateListByMessageTemplateTypeID(SystemSetting.ACTIVATION_SUCCESSFUL_EMAIL, GetPortalID);

                                        foreach (ForgetPasswordInfo messageTemplate in messageTemplates)
                                        {
                                            DataTable dtActivationSuccessfulTokenValues = UserManagementController.GetActivationSuccessfulTokenValue(user.UserName, GetPortalID);
                                            string replaceMessageSubject = MessageToken.ReplaceAllMessageToken(messageTemplate.Subject, dtActivationSuccessfulTokenValues);
                                            string replacedMessageTemplate = MessageToken.ReplaceAllMessageToken(messageTemplate.Body, dtActivationSuccessfulTokenValues);
                                            try
                                            {
                                                MailHelper.SendMailNoAttachment(messageTemplate.MailFrom, user.Email, replaceMessageSubject, replacedMessageTemplate, string.Empty, string.Empty);
                                            }
                                            catch (Exception)
                                            {

                                                ShowMessage("", GetSageMessage("UserRegistration", "SecureConnectionUAEmailError"), "", SageMessageType.Alert);
                                                return;     
                                            }
                                           

                                        }
                                        ForgetPasswordInfo template = UserManagementController.GetMessageTemplateByMessageTemplateTypeID(SystemSetting.ACTIVATION_SUCCESSFUL_INFORMATION, GetPortalID);
                                        if (template != null)
                                        {
                                            ACTIVATION_INFORMATION.Text = template.Body;
                                        };
                                        LogInPublicModeRegistration(user);
                                    }
                                    else
                                    {
                                        ShowMessage("", GetSageMessage("UserManagement", "UserDoesNotExist"), "", SageMessageType.Alert);
                                        //hypGotoLogin.Visible = false;
                                    }
                                }
                                else
                                {
                                    ForgetPasswordInfo template = UserManagementController.GetMessageTemplateByMessageTemplateTypeID(SystemSetting.ACTIVATION_FAIL_INFORMATION, GetPortalID);
                                    if (template != null)
                                    {
                                        ACTIVATION_INFORMATION.Text = template.Body;
                                    };
                                }

                            }
                            else
                            {
                                ShowMessage("", GetSageMessage("UserRegistration","ActivationCodeAlreadyUsed"), "", SageMessageType.Alert);
                                //hypGotoLogin.Visible = false;


                            }
                        }
                        else
                        {

                            ShowMessage("", GetSageMessage("UserManagement", "UserDoesNotExist"), "", SageMessageType.Alert);
                                //hypGotoLogin.Visible = false;     
                        }

                      
                    }
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }
        }

        protected string GetActivationCode(string pagePath)
        {
            string ActivationCode = string.Empty;
            if (string.IsNullOrEmpty(ActivationCode))
            {
                ActivationCode = "Home";
            }
            else
            {
                string[] pagePaths = pagePath.Split('/');
                ActivationCode = pagePaths[pagePaths.Length - 1];
                if (string.IsNullOrEmpty(ActivationCode))
                {
                    ActivationCode = pagePaths[pagePaths.Length - 2];
                }
                ActivationCode = ActivationCode.Replace(".aspx", "");

            }
            return ActivationCode;
        }

        private void LogInPublicModeRegistration(UserInfo user)
        {
            string strRoles = string.Empty;           
            RoleController role = new RoleController();
            SageFrameConfig sfConfig = new SageFrameConfig();
                
                    string userRoles = role.GetRoleNames(user.UserName, GetPortalID);
                    strRoles += userRoles;
                    if (strRoles.Length > 0)
                    {
                        SetUserRoles(strRoles);
                        SessionTracker sessionTracker = (SessionTracker)Session["Tracker"];
                        sessionTracker.PortalID = GetPortalID.ToString();
                        sessionTracker.Username = user.UserName;
                        Session["Tracker"] = sessionTracker;
                        SageFrame.Web.SessionLog SLog = new SageFrame.Web.SessionLog();
                        SLog.SessionTrackerUpdateUsername(sessionTracker, sessionTracker.Username, GetPortalID.ToString());
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

                            bool IsUseFriendlyUrls = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
                            if (IsUseFriendlyUrls)
                            {
                                if (GetPortalID > 1)
                                {
                                    Response.Redirect(ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx"), false);
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx"), false);
                                }
                            }
                            else
                            {
                                Response.Redirect(ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage)), false);
                            }

                        }
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
}