<%@ WebService Language="C#" Class="TaskToDoWebService" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SageFrame.TaskToDo;
/// <summary>
/// Summary description for AccordanceWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class TaskToDoWebService : System.Web.Services.WebService
{    
    [WebMethod]
    public List<TaskToDoInfo> GetTask(string CultureField, int PortalID, int UserModuleId, int offset, string UserName, string str, string SearchDate)
    {
        TaskToDoController controller = new TaskToDoController();
        List<TaskToDoInfo> list = controller.GetTask(CultureField, PortalID, UserModuleId, offset, str, UserName,SearchDate);
        return list;
    }
    
    [WebMethod]
    public List<TaskToDoInfo> GetTaskContent(int Id, int PortalID, int UserModuleId, string CultureCode)
    {
        TaskToDoController controller = new TaskToDoController();
        List<TaskToDoInfo> list = controller.GetTaskContent(Id, PortalID, UserModuleId, CultureCode);
        return list;
    }  
    [WebMethod]
    public void SaveTask(string Note, DateTime date, string CultureField, int PortalID, int UserModuleId, string UserName, int Id)
    {
        // if (IsAuthenticated(PortalID, UserModuleID, userName))
        TaskToDoController controller = new TaskToDoController();
        string note = HttpUtility.HtmlEncode(Note);
        controller.SaveTask(note, date, CultureField, PortalID, UserModuleId, UserName, Id);
    }
    [WebMethod]
    public void DeleteTask(int Id, string UserName, int PortalID, int UserModuleId, string CultureCode)
    { 
        // if (IsAuthenticated(PortalID, UserModuleID, userName))
        TaskToDoController controller = new TaskToDoController();
        controller.DeleteTask(Id, UserName, PortalID, UserModuleId, CultureCode);
    }
}