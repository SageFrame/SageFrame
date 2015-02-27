<%@ WebService Language="C#"  Class="ModuleManagerWebService" %>
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SageFrame.ModuleManager;
using SageFrame.Templating.xmlparser;
using SageFrame.Templating;
using System.IO;
using SageFrame.Security.Entities;
using SageFrame.Security;
using SageFrame.ModuleManager.DataProvider;
using SageFrame.ModuleManager.Controller;
using System.Collections.Generic;

/// <summary>
/// Summary description for ModuleManagerWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ModuleManagerWebService : System.Web.Services.WebService
{

    public ModuleManagerWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<LayoutMgrInfo> GetAllModules(int PortalID)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.GetModules(PortalID);
        return (lminfo);

    }
    [WebMethod]
    public List<LayoutMgrInfo> GetModuleInformation(string FriendlyName)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.GetModuleInformation(FriendlyName);
        return (lminfo);

    }

    [WebMethod]
    public int AddModuleOrder(string ModuleOrder, int PortelID, string ModuleID, string ModuleName, string PaneName, int UserModuleID)
    {
        try
        {
            LayoutMgrInfo obj = new LayoutMgrInfo();

            obj.ModuleOrder = ModuleOrder;
            obj.PortelID = PortelID;
            obj.ModuleID = ModuleID;
            obj.ModuleName = ModuleName;
            obj.PaneName = PaneName;
            obj.UserModuleID = UserModuleID;

            int i = LayoutMgrDataProvider.AddLayOutMgr(obj);
            return i;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string LoadActiveLayout(string PageName, string TemplateName, int PortalID)
    {
        try
        {
            string activeLayout = PresetHelper.LoadActivePagePreset(TemplateName, PageName).ActiveLayout;
            List<XmlTag> lstXmlTags = new List<XmlTag>();
            XmlParser parser = new XmlParser();
            string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            if (!Directory.Exists(templatePath))
            {
                templatePath = Utils.GetTemplatePath_Default(TemplateName);
            }
            string filePath = string.Format("{0}/layouts/{1}.xml", templatePath, activeLayout);
            lstXmlTags = parser.GetXmlTags(filePath, "layout/section");
            List<XmlTag> lstWrappers = parser.GetXmlTags(filePath, "layout/wrappers");
            ModulePaneGenerator wg = new ModulePaneGenerator();
            return (wg.GenerateHTML(lstXmlTags, lstWrappers, 1));
        }
        catch (Exception ex)
        {

            throw ex;

        }


    }

    [WebMethod]
    public string LoadHandHeldLayout(string PageName, string TemplateName, int PortalID)
    {
        List<XmlTag> lstXmlTags = new List<XmlTag>();
        XmlParser parser = new XmlParser();
        string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string filePath = templatePath + "/layouts/handheld.xml";
        filePath = File.Exists(filePath) ? filePath : string.Format("{0}/layouts/handheld.xml", Utils.GetTemplatePath_Default(TemplateName));
        lstXmlTags = parser.GetXmlTags(filePath, "layout/section");
        ModulePaneGenerator wg = new ModulePaneGenerator();
        return (wg.GenerateHTML(lstXmlTags, lstXmlTags, 1));

    }



    [WebMethod]
    public List<RoleInfo> GetPortalRoles(int PortalID, string UserName)
    {
        RoleController _role = new RoleController();
        return (_role.GetPortalRoles(PortalID, 1, UserName));
    }

    [WebMethod]
    public List<UserInfo> SearchUsers(string SearchText, int PortalID, string UserName)
    {
        MembershipController m = new MembershipController();
        List<UserInfo> lstUsers = m.SearchUsers("", SearchText, PortalID, UserName).UserList;
        return lstUsers;
    }

    [WebMethod]
    public string AddUserModule(UserModuleInfo UserModule)
    {
        return (ModuleController.AddUserModule(UserModule));
    }
    [WebMethod]
    public void UpdateUserModule(UserModuleInfo UserModule)
    {
        ModuleController.UpdateUserModule(UserModule);
    }

    [WebMethod]
    public List<UserModuleInfo> GetPageModules(int PageID, int PortalID, bool IsHandheld)
    {
        return (ModuleController.GetPageModules(PageID, PortalID, IsHandheld));
    }

    [WebMethod]
    public void DeleteUserModule(int UserModuleID, int PortalID, string DeletedBy)
    {
        ModuleController.DeleteUserModule(UserModuleID, PortalID, DeletedBy);
    }

    [WebMethod]
    public void UpdatePageModules(List<PageModuleInfo> lstPageModules)
    {
        try
        {
            ModuleController.UpdatePageModule(lstPageModules);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [WebMethod]
    public UserModuleInfo GetUserModuleDetails(int UserModuleID, int PortalID)
    {
        try
        {
            return (ModuleController.GetUserModuleDetails(UserModuleID, PortalID));
        }
        catch (Exception)
        {

            throw;
        }
    }


    [WebMethod]
    public List<LayoutMgrInfo> GetAllGenralModules(int PortalID)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.GetModules(PortalID);
        return (lminfo);

    }
    [WebMethod]
    public List<LayoutMgrInfo> GetAllAdminModules(int PortalID)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.GetAdminModules(PortalID);
        return (lminfo);

    }

    [WebMethod]
    public List<LayoutMgrInfo> GetSortModules(int flag, string isAdmin, int PortalID)
    {
        bool IsAdmin = isAdmin == "0" ? false : true;
        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.GetSortModules(flag, IsAdmin, PortalID);
        return (lminfo);

    }
    [WebMethod]
    public List<LayoutMgrInfo> GetAllSearchAdminModules(string SearchText, int PortalID, bool IsAdmin)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.SearchModules(SearchText, PortalID, IsAdmin);
        return (lminfo);

    }

    [WebMethod]
    public List<LayoutMgrInfo> GetAllSearchGenralModules(string SearchText, int PortalID, bool IsAdmin)
    {

        List<LayoutMgrInfo> lminfo = LayoutMgrDataProvider.SearchModules(SearchText, PortalID, IsAdmin);
        return (lminfo);

    }
    [WebMethod]
    public string LoadAdminLayout(string PageName, string TemplateName)
    {
        List<XmlTag> lstXmlTags = new List<XmlTag>();
        XmlParser parser = new XmlParser();
        string templatePath = Utils.GetAdminTemplatePath();
        string filePath = templatePath + "Default/layouts/layout.xml";
        lstXmlTags = parser.GetXmlTags(filePath, "layout/section");
        ModulePaneGenerator wg = new ModulePaneGenerator();
        return (wg.GenerateHTML(lstXmlTags, lstXmlTags, 1));
    }

}

