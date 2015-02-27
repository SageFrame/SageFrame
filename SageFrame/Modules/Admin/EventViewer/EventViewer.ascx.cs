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
using SageFrame.ErrorLog;
using SageFrame.Web;
using SageFrame.Message;
using SageFrame.SageFrameClass.MessageManagement;
using System.Text;
using SageFrame.Framework;
using SageFrame.LogView;



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
                imgLogClear.ImageUrl = GetTemplateImageUrl("imgclearlog.png", true);
                imgLogDelete.ImageUrl = GetTemplateImageUrl("imgdelete.png", true);
                imgSendEmail.ImageUrl = GetTemplateImageUrl("imgsend.png", true);
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
                gdvLog.DataSource = LogController.GetLogView(GetPortalID, logType);
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
                ddlLogType.DataSource = LogController.GetLogType();
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
                        
                        ErrorLogController.DeleteLogByLogID(Id, GetPortalID, GetUsername);
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

        protected void imgLogClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ErrorLogController.ClearLog(GetPortalID);
                BindGrid();
                //ShowMessage(SageMessageTitle.Information.ToString(), "Log Cleared Successfully.", "", SageMessageType.Success);
                ShowMessage("", GetSageMessage("EventViewer", "LogClearedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgSendEmail_Click(object sender, ImageClickEventArgs e)
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
                    string emailSuperAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserEmail);//"milsonmun@hotmail.com";
                    string emailSiteAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
                    MailHelper.SendMailNoAttachment(emailSiteAdmin,txtEmailAdd.Text,txtSubject1.Text, messageText, emailSuperAdmin, string.Empty);
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

        protected void imgLogDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gdvLog.Rows.Count; i++)
            {
                GridViewRow row = gdvLog.Rows[i];                
                bool isChecked = ((CheckBox)row.FindControl("chkSendEmail")).Checked;
                if (isChecked)
                {
                    HiddenField hdfLogID = (HiddenField)row.FindControl("hdfLogID");
                    int LogID = Int32.Parse(hdfLogID.Value);
                    ErrorLogController.DeleteLogByLogID(LogID, GetPortalID, GetUsername);                  
                }
            }
            BindGrid();
            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("EventViewer", "LogDeletedSuccessfully"), "", SageMessageType.Success);
        }
}
}


 
