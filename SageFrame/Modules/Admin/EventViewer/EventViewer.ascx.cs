#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.ErrorLog;
using SageFrame.Web;
using SageFrame.Message;
using System.Text;
using SageFrame.Framework;
using SageFrame.LogView;
using SageFrame.SageFrameClass.MessageManagement;
#endregion 

namespace SageFrame.Modules.Admin.EventViewer
{
    public partial class EventViewer : BaseAdministrationUserControl
    {
        StringBuilder str = new StringBuilder();

        MailHelper SendMessage = new MailHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateLogType();
                BindGrid();
                imgLogClear.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("EventViewer", "AreYouSureToClearLogs") + "')");
                imgLogDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("EventViewer", "AreYouSureToDeleteLogs") + "')");
            }
        }

        private void BindGrid()
        {
            string logType = string.Empty;
            if (ddlLogType.SelectedValue != "-1")
            {
                logType = ddlLogType.SelectedItem.Text;
            }
            try
            {
                LogController objController = new LogController();
                gdvLog.DataSource = objController.GetLogView(GetPortalID, logType);
                gdvLog.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void PopulateLogType()
        {
            try
            {
                LogController objController = new LogController();
                ddlLogType.DataSource = objController.GetLogType();
                ddlLogType.DataValueField = "LogTypeID";
                ddlLogType.DataTextField = "Name";
                ddlLogType.DataBind();
                ddlLogType.Items.Insert(0, new ListItem("ALL", "-1"));
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void ddlLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvLog.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue.ToString());
            BindGrid();
        }

        protected void gdvLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvLog.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gdvLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdvLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void gdvLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Delete":
                    try
                    {
                        ErrorLogController objController = new ErrorLogController();
                        objController.DeleteLogByLogID(Id, GetPortalID, GetUsername);
                        BindGrid();
                        ShowMessage("", GetSageMessage("EventViewer", "LogDeletedSuccessfully"), "", SageMessageType.Success);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex);
                    }
                    break;
            }
        }

        protected void imgLogClear_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLogController objController = new ErrorLogController();
                objController.ClearLog(GetPortalID);
                BindGrid();
                ShowMessage("", GetSageMessage("EventViewer", "LogClearedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string messageText = txtMessage1.Text;
                    for (int i = 0; i < gdvLog.Rows.Count; i++)
                    {
                        GridViewRow row = gdvLog.Rows[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSendEmail")).Checked;
                        if (isChecked)
                        {
                            Literal exception = row.FindControl("ltrException") as Literal;
                            Literal pageurl = row.FindControl("ltrPageUrl") as Literal;
                            messageText += "<br/>" + pageurl.Text + "<br/>" + exception.Text;
                        }
                    }
                    SageFrameConfig pagebase = new SageFrameConfig();
                    string emailSuperAdmin = pagebase.GetSettingValueByIndividualKey(SageFrameSettingKeys.SuperUserEmail);
                    string emailSiteAdmin = pagebase.GetSettingValueByIndividualKey(SageFrameSettingKeys.SiteAdminEmailAddress);
                    MailHelper.SendMailNoAttachment(emailSiteAdmin, txtEmailAdd.Text, txtSubject1.Text, messageText, emailSuperAdmin, string.Empty);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("EventViewer", "MailSentSuccessfully"), "", SageMessageType.Success);
                    ClearEmailForm();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void ClearEmailForm()
        {
            txtEmailAdd.Text = "";
            txtSubject1.Text = "";
            txtMessage1.Text = "";
        }

        protected void imgLogDelete_Click(object sender, EventArgs e)
        {
            bool isChkChecked = false;
            for (int i = 0; i < gdvLog.Rows.Count; i++)
            {
                GridViewRow row = gdvLog.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSendEmail")).Checked;
                if (isChecked)
                {
                    HiddenField hdfLogID = (HiddenField)row.FindControl("hdfLogID");
                    int LogID = Int32.Parse(hdfLogID.Value);
                    ErrorLogController objController = new ErrorLogController();
                    objController.DeleteLogByLogID(LogID, GetPortalID, GetUsername);
                    isChkChecked = true;
                }
            }
            if (isChkChecked)
            {
                BindGrid();
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("EventViewer", "LogDeletedSuccessfully"), "", SageMessageType.Success);
            }
            else
            {
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("EventViewer", "CheckCheckBoxAlert"), "", SageMessageType.Alert);
            }
        }
    }
}



