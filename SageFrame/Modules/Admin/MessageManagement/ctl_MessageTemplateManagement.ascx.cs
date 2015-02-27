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
using System.Data;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Framework;
using SageFrame.Web;
using SageFrameClass.MessageManagement;
using SageFrame.Message;
using System.Text;

namespace SageFrame.Modules.Admin.MessageManagement
{
    public partial class ctl_MessageTemplateManagement : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    AddImageUrls();
                    BindMessageTemplateType();
                    ClearForm();
                    BindData();
                    pnlMessageTemplateList.Style.Add("display", "block");
                    //BindMessageToken();
                    lnkAddSubjectMessageToken.Attributes.Add("onclick", "showMessageToken('" + txtSubject.ClientID + "','" + mpeAddMessageTokenModalPopup.ClientID + "',false)");
                    btnAddMessageTokenOk.Attributes.Add("onclick", "AddMessageToken('" + lstMessageToken.ClientID + "','" + mpeAddMessageTokenModalPopup.ClientID + "' )");
                    btnAddMessageTokenCancel.Attributes.Add("onclick", "hideModalPopup('" + mpeAddMessageTokenModalPopup.ClientID + "' )");
                    lnkAddBodyMessageToken.Attributes.Add("onclick", "showMessageToken('" + txtBody.ClientID + "','" + mpeAddMessageTokenModalPopup.ClientID + "',true)");
                    lstMessageToken.Attributes.Add("onchange", "setMessageToken(this.value);");
                    hypAddMessageTemplateType.Attributes.Add("onclick", "showModalPopup('" + mpeMessageTemplateType.ClientID + "');");
                    lblAddSubjectMessageToken.Attributes.Add("onclick", "showMessageToken('" + txtSubject.ClientID + "','" + mpeAddMessageTokenModalPopup.ClientID + "',false)");
                    lblAddBodyMessageToken.Attributes.Add("onclick", "showMessageToken('" + txtBody.ClientID + "','" + mpeAddMessageTokenModalPopup.ClientID + "',true)");
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void AddImageUrls()
        {
            hypAddMessageTemplateType.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
            lnkAddSubjectMessageToken.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
            lnkAddBodyMessageToken.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
            imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imbAddNew.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
        }

        private void BindMessageToken()
        {
            try
            {
                lstMessageToken.Items.Clear();
                if (ddlMessageTemplateType.SelectedIndex != -1)
                {
                    if (Int32.Parse(ddlMessageTemplateType.SelectedValue) > 0)
                    {

                        //var messageTokens = messageTokenDB.sp_MessageTemplateTypeTokenListByMessageTemplateType(Int32.Parse(ddlMessageTemplateType.SelectedValue), GetPortalID);
                        List<MessageManagementInfo> messageTokens = MessageManagementController.GetMessageTemplateTypeTokenListByMessageTemplateType(Int32.Parse(ddlMessageTemplateType.SelectedValue), GetPortalID);

                        foreach (MessageManagementInfo messageToken in messageTokens)
                        {
                            ListItem li = new ListItem(messageToken.MessageTokenKey, messageToken.MessageTokenKey);
                            lstMessageToken.Items.Add(li);
                        }
                    }
                }
                if (lstMessageToken.Items.Count > 0)
                {
                    lstMessageToken.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "InitializedMessageToken", "setMessageToken('" + lstMessageToken.SelectedValue + "');", true);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindMessageTemplateType()
        {
            try
            {
                //CommonFunction comm = new CommonFunction();
                //var LINQ = messageTemplateTypeDB.sp_GetMessageTemplateTypeList(true, false, GetPortalID,GetUsername,GetCurrentCultureName);
                //DataTable dtTemplateType = comm.LINQToDataTable(LINQ);
                //ddlMessageTemplateType.DataSource = dtTemplateType;

                ddlMessageTemplateType.DataSource = MessageManagementController.GetMessageTemplateTypeList(true, false, GetPortalID, GetUsername, GetCurrentCultureName);
                ddlMessageTemplateType.DataTextField = "CultureName";
                ddlMessageTemplateType.DataValueField = "MessageTemplateTypeID";
                ddlMessageTemplateType.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                hdnMessageTemplateID.Value = "0";
                pnlMessageTemplate.Style.Add("display", "block");
                pnlMessageTemplateList.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }

        }

        protected void imbSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                StringBuilder strMessage = new StringBuilder();
                if (Validate(strMessage))
                {
                    if (Int32.Parse(hdnMessageTemplateID.Value) > 0)
                    {
                        try
                        {
                            Int32 MessageTemplateID = Int32.Parse(Session["MessageTemplateID"].ToString());
                            //messageTemplateDB.sp_MessageTemplateUpdate(MessageTemplateID, Int32.Parse(ddlMessageTemplateType.SelectedValue), txtSubject.Text,
                            //    txtBody.Value, txtMailFrom.Text, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername,GetCurrentCultureName);

                            MessageManagementController.UpdateMessageTemplate(MessageTemplateID, Int32.Parse(ddlMessageTemplateType.SelectedValue), txtSubject.Text,
                                txtBody.Value, txtMailFrom.Text, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername, GetCurrentCultureName);


                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("MessageManagement", "MessageTemplateIsUpdatedSuccessfully"), "", SageMessageType.Success);
                            BindData();
                            ClearForm();
                        }
                        catch
                        {


                            ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("MessageManagement", "MessageTemplateCouldnotBeUpdated"), "", SageMessageType.Error);
                        }
                    }
                    else
                    {
                        int newMessageTemplateID = 0;

                        //messageTemplateDB.sp_MessageTemplateAdd(ref newMessageTemplateID, Int32.Parse(ddlMessageTemplateType.SelectedValue), txtSubject.Text, txtBody.Value, txtMailFrom.Text, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername,GetCurrentCultureName);
                        newMessageTemplateID = MessageManagementController.AddMessageTemplate(int.Parse(ddlMessageTemplateType.SelectedValue), txtSubject.Text, txtBody.Value, txtMailFrom.Text, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername, GetCurrentCultureName);

                        if (newMessageTemplateID > 0)
                        {
                            BindData();


                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("MessageManagement", "MessageTemplateIsAddedSuccessfully"), "", SageMessageType.Success);
                            ClearForm();
                        }
                        else
                        {

                            ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("MessageManagement", "MessageTemplateCouldnotBeAdded"), "", SageMessageType.Error);
                        }
                    }
                }
                else
                {
                    ShowMessage(SageMessageTitle.Information.ToString(), strMessage.ToString(), "", SageMessageType.Success);

                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private bool Validate(StringBuilder strMessage)
        {
            bool IsValid = true;

            strMessage.AppendLine(GetSageMessage("MessageManagement", "PleaseFill") + Environment.NewLine);
            if (txtSubject.Text.Trim() == string.Empty)
            {
                IsValid = false;

                strMessage.AppendLine(GetSageMessage("MessageManagement", "MessageTemplateSubject") + Environment.NewLine);
            }
            if (txtBody.Value.Trim() == string.Empty)
            {
                IsValid = false;

                strMessage.AppendLine(GetSageMessage("MessageManagement", "MessageTemplateBody") + Environment.NewLine);
            }
            if (txtMailFrom.Text.Trim() == string.Empty)
            {
                IsValid = false;

                strMessage.AppendLine(GetSageMessage("MessageManagement", "FromEmailAddressIsRequired") + Environment.NewLine);
            }
            return IsValid;
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void ClearForm()
        {
            try
            {
                chkIsActive.Checked = false;
                txtSubject.Text = "";
                txtBody.Value = "";
                txtMailFrom.Text = "";
                Session["MessageTemplateID"] = null;
                HideAll();
                pnlMessageTemplateList.Style.Add("display", "block");
                pnlMessageTemplate.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void HideAll()
        {
            try
            {
                pnlMessageTemplate.Style.Add("display", "none");
                pnlMessageTemplateList.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindData()
        {
            try
            {
                //var LINQ = messageTemplateDB.sp_GetMessageTemplateList(true, false, GetPortalID,GetUsername,GetCurrentCultureName);
                //grdList.DataSource = LINQ;
                grdList.DataSource = MessageManagementController.GetMessageTemplateList(true, false, GetPortalID, GetUsername, GetCurrentCultureName);
                grdList.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdList.PageIndex = e.NewPageIndex;
                BindData();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void grdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Int32 MessageTemplateID = Int32.Parse(e.CommandArgument.ToString());
                switch (e.CommandName.ToString())
                {
                    case "Edit":
                        EditMessageTemplate(MessageTemplateID);
                        BindMessageToken();
                        break;
                    case "Delete":
                        DeleteMessageTemplate(MessageTemplateID);
                        break;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void EditMessageTemplate(Int32 MessageTemplateID)
        {
            try
            {
                //var LINQ = messageTemplateDB.sp_GetMessageTemplate(MessageTemplateID, GetPortalID).SingleOrDefault();
                MessageManagementInfo objInfo = MessageManagementController.GetMessageTemplate(MessageTemplateID, GetPortalID);


                if (objInfo != null)
                {
                    hdnMessageTemplateID.Value = MessageTemplateID.ToString();
                    txtSubject.Text = objInfo.Subject;
                    txtBody.Value = objInfo.Body;
                    txtMailFrom.Text = objInfo.MailFrom;
                    chkIsActive.Checked = (objInfo.IsActive == true ? true : false);
                    ddlMessageTemplateType.SelectedValue = objInfo.MessageTemplateTypeID.ToString();
                    Session["MessageTemplateID"] = MessageTemplateID;
                    HideAll();
                    pnlMessageTemplate.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void DeleteMessageTemplate(Int32 MessageTemplateID)
        {
            try
            {
                //messageTemplateDB.sp_MessageTemplateDelete(MessageTemplateID, GetPortalID, DateTime.Now, GetUsername);
                MessageManagementController.DeleteMessageTemplate(MessageTemplateID, GetPortalID, DateTime.Now, GetUsername);

                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("MessageManagement", "MessageTemplateIsDeletedSuccessfully"), "", SageMessageType.Success);
                BindData();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnOkMessageTemplateType_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMessageTemplateType.Text != "")
                {
                    int MessageTemplateTypeID = 0;
                    //messageTemplateTypeDB.sp_MessageTemplateTypeAdd(ref MessageTemplateTypeID, txtMessageTemplateType.Text, true, DateTime.Now, GetPortalID, GetUsername);
                    MessageTemplateTypeID = MessageManagementController.AddMessageTemplateType(txtMessageTemplateType.Text, true, DateTime.Now, GetPortalID, GetUsername);
                    if (MessageTemplateTypeID > 0)
                    {

                        ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("MessageManagement", "MessageTemplateIsAddedSuccessfully"), "", SageMessageType.Success);
                        BindMessageTemplateType();
                        txtMessageTemplateType.Text = "";
                    }
                    else
                    {

                        ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("MessageManagement", "PleaseSaveMessageTemplateTypeAgain"), "", SageMessageType.Error);
                    }
                }
                else
                {

                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("MessageManagement", "MessageTemplateTypeIsRequiredField"), "", SageMessageType.Alert);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void ddlMessageTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMessageToken();
        }

        protected void btnCustomizeEditor_Click(object sender, EventArgs e)
        {
            //txtBody.ToolbarSet = "Default";
            btnCustomizeEditor.Visible = false;
            btnDefault.Visible = true;
            txtBody.Visible = true;
        }

        protected void btnDefault_Click(object sender, EventArgs e)
        {
            // txtBody.ToolbarSet = "SageFrameLimited";
            btnCustomizeEditor.Visible = true;
            btnDefault.Visible = false;
            txtBody.Visible = true;
        }
    }
}