<%@ WebService Language="C#" Class="WebService" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SageFrame.WorkFlow;
using SageFrame.RolesManagement;
using SageFrame.Security.Entities;
using System.Text;
using SageFrame.SageFrameClass.MessageManagement;
using SageFrame.Web;
using System.Xml;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string WFGetUsers(int portalID, string roleID, int userModuleID, string userName, string secureToken)
    {
        WFController objController = new WFController();
        return objController.GetUserListByRoleID(portalID, roleID);
    }
    [WebMethod]
    public void AddUpdateBasic(WFbasicList objWfList, int portalID, int userModuleID, string userName, string secureToken)
    {
        objWfList.CreateDate = DateTime.Now;
        WFController objController = new WFController();
        objController.AddUpdateBasic(objWfList);
    }

    [WebMethod]
    public int AddUpdateWFTask(BasicTask objWfTask, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objController = new WFController();
        string subjectAssign = GetMessage("assign", "subject");
        string subjectUpdate = GetMessage("taskUpdated", "subject");
        Email objEmail = objController.AddUpdateWFTask(objWfTask, subjectAssign, subjectUpdate);
        int taskID = 0;
        if (objEmail != null)
        {
            taskID = objEmail.TaskID;
            string message = GetMessage("assign", "message");
            Sendmail(objEmail, subjectAssign, message);
        }
        return taskID;
    }

    [WebMethod]
    public WFbasic GetBasic(int portalID, int userModuleID, string cultureCode, string userName, string secureToken)
    {
        WFController objwfController = new WFController();
        return objwfController.GetWFBasic(portalID, userModuleID, cultureCode);
    }
    [WebMethod]
    public List<RolesManagementInfo> WFGetRoles(int portalID, int userModuleID, string userName, string secureToken)
    {
        RolesManagementController objController = new RolesManagementController();
        List<RolesManagementInfo> objRoles = objController.PortalRoleList(1, true, "");
        List<RolesManagementInfo> objRoleList = new List<RolesManagementInfo>();
        foreach (RolesManagementInfo obj in objRoles)
        {
            if (obj.RoleName != "Super User" && obj.RoleName != "Anonymous User")
            {
                objRoleList.Add(obj);
            }
        }
        return objRoleList;
    }

    [WebMethod]
    public List<BasicTask> GetTaskList(int portalID, int userModuleID, string cultureCode, int WFID, string userName, string secureToken)
    {
        //List<BasicTask> objTasklist = new List<BasicTask>();
        //BasicTask objwflst = new BasicTask();
        WFController objController = new WFController();
        List<BasicTask> objTask = objController.GetTaskList(portalID, userModuleID, cultureCode, WFID);
        return objTask;
    }
    [WebMethod]
    public BasicTask GetTaskByID(int TaskID, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objController = new WFController();
        BasicTask objTask = objController.GetTaskByID(TaskID);
        return objTask;
    }
    [WebMethod]
    public void DeleteTaskByID(int TaskID, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objController = new WFController();
        objController.DeleteTaskByID(TaskID);
    }
    [WebMethod]
    public void SaveOrder(List<TOrder> objOrder, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objController = new WFController();
        objController.SaveOrder(objOrder);
    }


    [WebMethod]
    public void SaveContents(int wfID, int portalID, int userModuleID, string cultureCode, string userName, string contents, int contentID, int complete, string secureToken)
    {
        WFController objController = new WFController();
        Email objEmail = objController.SaveContents(wfID, portalID, userModuleID, cultureCode, userName, contentID, contents, complete);
        if (objEmail != null)
        {
            if (objEmail.Emails != null)
            {
                string subject = GetMessage("forward", "subject");
                string message = GetMessage("forward", "message");
                Sendmail(objEmail, subject, message);
            }
        }
    }
    [WebMethod]
    public List<ModeratorInfo> GetContainForModerator(int userModuleID, int portalID, string cultureCode, string userName, string secureToken)
    {
        WFController objwfController = new WFController();
        return objwfController.GetContainForModerator(userModuleID, portalID, cultureCode);

    }
    [WebMethod]
    public ModeratorInfo GetContainByID(string CID, int portalID, int userModuleID, string userName, string secureToken)
    {
        string[] cid = CID.Split('_');
        int ContainID = int.Parse(cid[0]);
        int TaskID = int.Parse(cid[1]);
        WFController objwfController = new WFController();
        return objwfController.GetContainByID(ContainID, TaskID);
    }

    [WebMethod]
    public ModeratorInfo GetContainByLevel(int TaskID, int ContentLevel, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objwfController = new WFController();
        return objwfController.GetContainByLevel(TaskID, ContentLevel);

    }

    [WebMethod]
    public void ReassigneTask(int WFID, int ContentLevel, int TaskID, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFController objwfController = new WFController();
        string subject = GetMessage("reassign", "subject");
        List<Email> objEmailList = objwfController.ReassigneTask(WFID, ContentLevel, TaskID, subject);

        if (objEmailList.Count > 0)
        {

            string message = GetMessage("reassign", "message");
            Sendmail(objEmailList, subject, message);
        }
    }

    [WebMethod]
    public string GetWFBasicList(int portalID, int userModuleID, string cultureCode, string userName, string secureToken)
    {
        WFController objController = new WFController();
        List<WFbasicList> objBasicList = objController.GetWFBasicList(portalID, userModuleID, cultureCode);
        StringBuilder html = new StringBuilder();
        if (userName == "superuser")
        {
            html.Append("<span id='btnAddnewWF' class='sfBtn'>Add New Work Flow</span>");
        }
        html.Append("<div class='sfGridwrapper sfSimpleTable'><table width='100%' class='tblWF'><tr><th>WorkFlow Name</th><th>Moderator Name</th><th>Status</th>");

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
                    html.Append("<span >Deactive WF</span>");
                }
            }
            html.Append("</td>");
            if (userName == "superuser") // || (objList.ModeratorName == "none" && userName == "superuser"))
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
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        html.Append("</table></div>");
        return html.ToString();
    }

    [WebMethod]
    public int ActivateWF(int portalID, int userModuleID, string cultureCode, int wfID, string userName, string secureToken)
    {
        WFDataProvider objDataProvider = new WFDataProvider();
        objDataProvider.ActivateWF(portalID, userModuleID, cultureCode, wfID);
        return wfID;
    }

    [WebMethod]
    public void DeleteWF(int wfID, int portalID, int userModuleID, string userName, string secureToken)
    {
        WFDataProvider objDataProvider = new WFDataProvider();
        objDataProvider.DeleteWF(wfID);
    }

    [WebMethod]
    public List<StatusInfo> GetWFStatus(int portalID, int userModuleID, string cultureCode, int WFID, string userName, string secureToken)
    {
        WFController objDataProvider = new WFController();
        return objDataProvider.GetWFStatus(portalID, userModuleID, cultureCode, WFID);
    }

    [WebMethod]
    public string GetContent(int portalID, int userModuleID, string cultureCode, string userName, int wfID, string secureToken)
    {
        WFController objController = new WFController();
        ContentInfo objContent = objController.GetContents(portalID, userModuleID, cultureCode, userName, wfID);
        StringBuilder html = new StringBuilder();
        if (objContent != null)
        {
            if (objContent.ContentID != 0)
            {
                html.Append("<input type='hidden' id='hdnContentID' value='" + objContent.ContentID + "' />");
                html.Append("<textarea id='txtContent' rows='3' cols='2'>");
                html.Append(objContent.Contents);
                html.Append("</textarea>");
                html.Append("percentageComplete  <select class='sfDropDown' id='ddlComplete'>");
                html.Append(GetOption(objContent.Completion, portalID, userModuleID, userName, secureToken));
                html.Append("</select><br />");
                html.Append("<label class='icon-save sfBtn' id='btnSaveContent'>Save</label>");

            }
            else
            {
                int con = int.Parse(objContent.Contents);
                if (con == 0)
                {
                    html.Append("<p class='sfUnderDevelop'>Work is in progress.</p>");
                }
                else
                {
                    html.Append("<p class='sfUnderDevelop'>Work has been sent for Approval.</p>");
                }
            }
        }
        return html.ToString();
    }

    public string GetOption(int completion, int portalID, int userModuleID, string userName, string secureToken)
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

    [WebMethod]
    public void PublishContent(int wfID, int contentID, string userName, int portalID, int userModuleID, string secureToken)
    {
        WFController objController = new WFController();
        List<Email> objEmailList = objController.PublishContent(wfID, contentID, userName);
        if (objEmailList.Count > 0)
        {
            string subject = GetMessage("publish", "subject");
            string message = GetMessage("publish", "message");
            Sendmail(objEmailList, subject, message);
        }
    }

    [WebMethod]
    public void PublishWF(int wfID, int userModuleID, string userName, int portalID, string cultureCode)
    {
        WFController objController = new WFController();
        objController.PublishWF(wfID, portalID, userModuleID, cultureCode);
    }

    [WebMethod]
    public string GetNotification(int wfID, int userModuleID, string userName, int portalID, string cultureCode, int pageNo, int dataAmount, string secureToken)
    {
        WFController objController = new WFController();
        List<Comments> objCommentList = objController.GetNotification(portalID, userModuleID, cultureCode, userName, pageNo, dataAmount);
        StringBuilder html = new StringBuilder();
        StringBuilder html2 = new StringBuilder();
        int unseen = 0;
        int total = 0;
        foreach (Comments objComment in objCommentList)
        {
            html2.Append("<li id='inbox_" + objComment.CommentID + "'>");
            html2.Append("<h3>");
            html2.Append(objComment.TaskName);
            html2.Append("</h3><p>");
            html2.Append(objComment.Comment);
            unseen = objComment.UnSeen;
            html2.Append("</p>");
            html2.Append("</li>");
            total = objComment.Total;
        }
        if (total > pageNo * dataAmount)
        {
            html2.Append("<span class='sfBtn btnShowmore'> ShowMore");
            html2.Append("</span>");
        }
        return html2.ToString();
    }

    [WebMethod]
    public void SeenComments(int wfID, string userName, int portalID, int userModuleID, string secureToken)
    {
        WFController objCon = new WFController();
        objCon.SeenComments(wfID, userName);
    }


    public void Sendmail(Email email, string subject, string message)
    {
        SageFrameConfig sfConfig = new SageFrameConfig();
        string mailfrom = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
        MailHelper.SendMailNoAttachment(mailfrom, email.Emails, subject, message, string.Empty, string.Empty);
    }

    public void Sendmail(List<Email> emails, string subject, string message)
    {
        foreach (Email email in emails)
        {
            SageFrameConfig sfConfig = new SageFrameConfig();
            string mailfrom = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
            MailHelper.SendMailNoAttachment(mailfrom, email.Emails, subject, message, string.Empty, string.Empty);
        }
    }

    public static string GetMessage(string ModuleName, string MessageNode)
    {
        XmlDocument doc = new XmlDocument();
        string xmlPath = HttpContext.Current.Server.MapPath("~/Modules/ContentApprovalWorkFlow/Message/WorkFlowMessage.xml");
        if (!System.IO.File.Exists(xmlPath))
            xmlPath = HttpContext.Current.Server.MapPath("~/Modules/ContentApprovalWorkFlow/Message/WorkFlowMessage.xml");
        doc.Load(xmlPath);
        XmlNode root = doc.DocumentElement;
        return root.SelectSingleNode(ModuleName).SelectSingleNode(MessageNode).ChildNodes[0].Value;
    }
}