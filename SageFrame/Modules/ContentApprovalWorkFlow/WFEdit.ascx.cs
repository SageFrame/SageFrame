
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.WorkFlow;
using System.Text;

public partial class Modules_WFContent_WFEdit : BaseAdministrationUserControl
{
    public int userModuleID, portalID;
    public string cultureCode, userName;
    public bool CheckUser = false;
    public bool isTaskForModerator = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeCss("WorkflowCss", "/Modules/ContentApprovalWorkFlow/css/workflow.css");
        IncludeCss("WorkflowCssalert", "/css/jquery.alerts.css");
        IncludeJs("WorkflowJs", "/Modules/ContentApprovalWorkFlow/js/workflow.js");
        IncludeJs("WorkflowJs", "/js/jquery.alerts.js");
        IncludeJs("wfedit", false, "/Editors/ckeditor/ckeditor.js", "/Editors/ckeditor/adapters/jquery.js", "/js/jquery.validate.js");

        userModuleID = Int16.Parse(SageUserModuleID);
        portalID = GetPortalID;
        cultureCode = GetCurrentCultureName;
        userName = GetUsername;
        GetWFList();
        GetWFBasic();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ckEditorUserModuleID", " var ckEditorUserModuleID='" + SageUserModuleID + "';", true);
    }

    public void GetWFList()
    {
        WFController objWFController = new WFController();
        List<WFbasicList> objBasicList = objWFController.GetWFBasicList(portalID, userModuleID, cultureCode);
        StringBuilder html = new StringBuilder();
        int activeWFID = 0;
        if (userName == "superuser")
        {
            html.Append("<span id='btnAddnewWF' class='icon-addnew sfBtn'>Add New WorkFlow</span>");
        }
        html.Append("<div class='sfGridwrapper sfSimpleTable sfMargintop'><table width='100%' class='tblWF'><tr><th>WorkFlow Name</th><th>Moderator Name</th><th>Status</th>");

        if (userName == "superuser")
        {
            html.Append("<th>Edit</th>");
			html.Append("<th>Delete</th>");
            html.Append("<th>Published</th></tr>");
            
        }
        else
        {
            html.Append("</tr>");
        }
        foreach (WFbasicList objList in objBasicList)
        {
            bool isActive = objList.IsActive;
            bool isPublish = objList.IsPublished;
            if (isActive)
            {
                html.Append("<tr id='wfID_" + objList.WFID + "' class='sfTrActive'>");
                activeWFID = objList.WFID;
            }
            else
            {
                html.Append("<tr id='wfID_" + objList.WFID + "'>");
            }
            html.Append("<td>");
            html.Append(objList.WorkFlowName);
            html.Append("</td>");
            html.Append("<td>");
            html.Append(objList.ModeratorName);
            html.Append("</td>");
            html.Append("<td>");

            if (isActive)
            {
                if (userName == "superuser")
                {
                    html.Append("<span class='sfWFACtive'>Activated</span>");
                }
                else
                {
                    html.Append("<span>Activated</span>");
                }
            }
            else
            {
                if (userName == "superuser")
                {
                    html.Append("<span class='sfBtn sfWFdeActive'>Activate WF</span>");
                }
                else
                {
                    html.Append("<span >Deactivate WF</span>");
                }
            }
            html.Append("</td>");
            if (userName == "superuser" || (objList.ModeratorName == "none" && userName == "superuser"))
            {
                html.Append("<td>");
                html.Append("<span class='sfWFEdit icon-edit'></span>");
                html.Append("</td>");
                html.Append("<td>");
                if (!isPublish)
                {					
                    html.Append("<span class='sfWFDelete icon-delete'></span>");
                    html.Append("</td>");
					html.Append("<td>");
                    html.Append("<span class='sfBtn  sfUnPublished'>Publish WF</span>");
                    html.Append("</td>");                   
                }
                else
                {   
					html.Append("</td><td>");               
					html.Append("<span class='sfPublished'>Published</span>");                    
                    html.Append("</td>");
                }
            }
            html.Append("</tr>");
        }
        html.Append("</table></div>");
        lblWFID.Text = "<input type='hidden' value='" + activeWFID + "' id='WFID' /><input type='hidden' value='" + activeWFID + "' id='editWFID' />";
        ltrWFList.Text = html.ToString();
    }

    public void GetWFBasic()
    {
        if (GetUsername == "superuser")
        {
            CheckUser = true;
        }
        WFController objwfController = new WFController();
        WFbasic objWfBasic = objwfController.GetWFBasic(GetPortalID, Int16.Parse(SageUserModuleID), GetCurrentCultureName);
        StringBuilder html = new StringBuilder();
        if (objWfBasic != null)
        {
            if (GetUsername == "superuser" || objWfBasic.WorkFlowModerator == GetUsername)
            {
                CheckUser = true;
                html.Append("<span class='Moderator' id='spnMod'>Moderator</span>");
                ltrMod.Text = html.ToString();
                if (objWfBasic != null)
                {
                    if (objWfBasic.WFID != 0)
                    {
                        GetNotification();
                    }
                    if (objWfBasic.IsTaskForModeratior && objWfBasic.WorkFlowModerator == GetUsername)
                    {
                        isTaskForModerator = true;
                    }
                }
            }
            else if (objWfBasic.WorkFlowModerator != userName && userName != "anonymoususer")
            {
                isTaskForModerator = true;
            }
        }
        //else
        //{
        //    isTaskForModerator = true;
        //}
        GetNotification();
    }

    public string GetOption(int completion)
    {
        StringBuilder html = new StringBuilder();

        for (int i = 1; i < 100; i++)
        {
            if (i == completion)
                html.Append("<option selected='" + true + "'>");
            else
                html.Append("<option>");
            html.Append(i.ToString());
            html.Append("</option>");
        }
        return html.ToString();
    }

    public void GetNotification()
    {
        WFController objController = new WFController();
        List<Comments> objCommentList = objController.GetNotification(portalID, userModuleID, cultureCode, userName, 1, 10);
        StringBuilder html = new StringBuilder();
        StringBuilder html2 = new StringBuilder();

        html.Append("<div class='notification'>");
        html2.Append("<div class='divInbox' style='display:none;' >");
        html2.Append("<span class='notiClose icon-close' id='spnCloseNoti'>X</span>");
        html2.Append("<ul class='notiUl'>");
        int unseen = 0;
        int total = 0;
        int odd = 1;
        foreach (Comments objComment in objCommentList)
        {
            string activeClass = odd % 2 == 0 ? "active" : "inactive";
            html2.Append("<li class='" + activeClass + "' id='inbox_" + objComment.CommentID + "'>");
            html2.Append("<h3>");
            html2.Append(objComment.TaskName);
            html2.Append("</h3><p>");
            html2.Append(objComment.Comment);
            unseen = objComment.UnSeen;
            html2.Append("</p>");
            html2.Append("</li>");
            total = objComment.Total;
            odd++;
        }
        html2.Append("</ul>");
        if (total > 10)
        {
            html2.Append("<span class='btnShowmore' id='page_1'> Show More");
            html2.Append("</span>");
        }
        html.Append("<div class= 'notify'>Notification: <span class='NotificationSpan' id='spnModNoti'>  " + unseen + "</span></div>");

        html.Append("</div></div>"); html.Append(html2);
        ltrNotification.Text = html.ToString();
    }
}

