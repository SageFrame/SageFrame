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
using System.Web.Security;
using System.Data;
using SageFrame.Message;
using SageFrame.Web;
using SageFrame.Framework;
using System.Net.Mail;
using SageFrameClass.MessageManagement;
using SageFrame.SageFrameClass.MessageManagement;
using SageFrame.UserManagement;
using SageFrame.Security;
using SageFrame.Security.Entities;

namespace SageFrame.Modules.PasswordRecovery
{
    public partial class ctl_ForgetPassword : BaseAdministrationUserControl
    {
        public string helpTemplate = string.Empty;
        SageFrameConfig pb = new SageFrameConfig();
        bool IsUseFriendlyUrls = true;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //var template = dbMessageTemplate.sp_MessageTemplateByMessageTemplateTypeID(SystemSetting.PASSWORD_FORGET_HELP, GetPortalID).SingleOrDefault();
            ForgetPasswordInfo objInfo = UserManagementController.GetMessageTemplateByMessageTemplateTypeID(SystemSetting.PASSWORD_FORGET_HELP, GetPortalID);

            //if (template != null)
            //{

            //    helpTemplate = "<b>" + template.Body+ "</b>";
            //}
            if (objInfo != null)
            {

                helpTemplate = "<b>" + objInfo.Body + "</b>";
            }

            IsUseFriendlyUrls = pb.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
            if (!IsPostBack)
            {

                SetValidatorErrorMessage();
            }
        }

        private void SetValidatorErrorMessage()
        {
            rfvUsername.ErrorMessage = GetSageMessage("PasswordRecovery", "UserNameIsRequired");
            rfvEmail.ErrorMessage = GetSageMessage("PasswordRecovery", "UserEmailAddressIsRequired");
            revEmail.ErrorMessage = GetSageMessage("PasswordRecovery", "UserEmailAddressIsNotValid");
        }

        protected void wzdForgetPassword_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                GotoLoginPage();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        private void GotoLoginPage()
        {
            string strRedURL = string.Empty;
            if (IsUseFriendlyUrls)
            {
                if (GetPortalID > 1)
                {
                    strRedURL = ResolveUrl("~/portal/" + GetPortalSEOName + "/sf/" + pb.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
                }
                else
                {
                    strRedURL = ResolveUrl("~/sf/" + pb.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage) + ".aspx");
                }
            }
            else
            {
                strRedURL = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + pb.GetSettingsByKey(SageFrameSettingKeys.PlortalLoginpage));
            }
            Response.Redirect(strRedURL, false);
        }
        protected void wzdForgetPassword_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                MembershipController member = new MembershipController();
                if (txtEmail.Text != "" && txtUsername.Text != "")
                {

                    UserInfo user = member.GetUserDetails(GetPortalID, txtUsername.Text);
                        if (user.UserExists)
                        {
                            if (user.IsApproved == true)
                            {
                                if (user.Email.ToLower().Equals(txtEmail.Text.ToLower()))
                                {
                                    ForgetPasswordInfo objInfo = UserManagementController.GetMessageTemplateByMessageTemplateTypeID(SystemSetting.PASSWORD_FORGET_USERNAME_PASSWORD_MATCH, GetPortalID);

                                    if (objInfo != null)
                                    {
                                        ((Literal)WizardStep2.FindControl("litInfoEmailFinish")).Text = objInfo.Body;
                                    }

                                    List<ForgetPasswordInfo> objList = UserManagementController.GetMessageTemplateListByMessageTemplateTypeID(SystemSetting.PASSWORD_CHANGE_REQUEST_EMAIL, GetPortalID);

                                    foreach (ForgetPasswordInfo objPwd in objList)
                                    {
                                        
                                        DataTable dtTokenValues = UserManagementController.GetPasswordRecoveryTokenValue(txtUsername.Text, GetPortalID);

                                        CommonFunction comm = new CommonFunction();
                                        string replaceMessageSubject = MessageToken.ReplaceAllMessageToken(objPwd.Subject, dtTokenValues);
                                        string replacedMessageTemplate = MessageToken.ReplaceAllMessageToken(objPwd.Body, dtTokenValues);
                                        try
                                        {
                                            MailHelper.SendMailNoAttachment(objPwd.MailFrom, txtEmail.Text, replaceMessageSubject, replacedMessageTemplate, string.Empty, string.Empty);
                                        }
                                        catch (Exception)
                                        {
                                            divForgotPwd.Visible = false;
                                            ShowMessage("", GetSageMessage("PasswordRecovery", "SecureConnectionFPError"), "", SageMessageType.Alert);
                                            e.Cancel = true;
                                        }

                                    }
                                }
                                else
                                {
                                    ShowMessage("", GetSageMessage("PasswordRecovery", "UsernameOrEmailAddressDoesnotMatched"), "", SageMessageType.Alert);
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                ShowMessage("", GetSageMessage("PasswordRecovery", "UsernameNotActivated"), "", SageMessageType.Alert);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            ShowMessage("", GetSageMessage("UserManagement", "UserDoesNotExist"), "", SageMessageType.Alert);
                            e.Cancel = true;
                        }
                   
                }
                else
                {
                    e.Cancel = true;
                    ShowMessage("", GetSageMessage("PasswordRecovery", "PleaseEnterAllTheRequiredFields"), "", SageMessageType.Alert);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                GotoLoginPage();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

    }
}