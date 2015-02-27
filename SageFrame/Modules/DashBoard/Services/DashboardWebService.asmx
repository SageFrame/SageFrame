<%@ WebService Language="C#" Class="DashboardWebService" %>
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using SageFrame.Web;
using SageFrame.Dashboard;
using System.IO;
using SageFrame.Pages;
using SageFrame.ModuleManager;
using SageFrame.Security.Entities;
using SageFrame.Security;

/// <summary>
/// Summary description for DashboardWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class DashboardWebService : System.Web.Services.WebService
{

    public DashboardWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public List<Link> GetPages(int PortalID)
    {
        return DashboardController.GetAdminPages(PortalID);
    }

    [WebMethod]
    public void AddLink(QuickLink linkObj)
    {
        try
        {
            linkObj.ImagePath = linkObj.ImagePath == null || linkObj.ImagePath == "" ? "" : linkObj.ImagePath;
            DashboardController.AddQuickLink(linkObj);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [WebMethod]
    public List<QuickLink> GetQuickLinks(string UserName,int PortalID)
    {
        try
        {
            return (DashboardController.GetQuickLinksAll(UserName, PortalID));
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public void DeleteQuickLink(int QuickLinkID)
    {
        DashboardController.DeleteQuickLink(QuickLinkID);

    }

    [WebMethod]
    public List<Sidebar> GetSidebar(string UserName,int PortalID)
    {
        try
        {
            return (DashboardController.GetSidebarAll(UserName,PortalID));
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public List<Sidebar> GetParentLinks(int SidebarItemID)
    {
        try
        {
            return(DashboardController.GetParentLinks(SidebarItemID));
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public void AddSidebar(Sidebar sidebarObj)
    {
        try
        {
            sidebarObj.ImagePath = sidebarObj.ImagePath == null || sidebarObj.ImagePath == "" ? "" : sidebarObj.ImagePath;
    DashboardController.AddSidebar(sidebarObj);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public void DeleteSidebarItem(int SidebarItemID)
    {
        try
        {
            DashboardController.DeleteSidebarItem(SidebarItemID);

        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [WebMethod]
    public Sidebar GetSidebarItem(int SidebarItemID)
    {
        try
        {
            return (DashboardController.GetSidebarDetails(SidebarItemID));
        }
        catch (Exception)
        {
            
            throw;
        }
    }


    [WebMethod]
    public QuickLink GetQuickLinkItem(int QuickLinkItemID)
    {
        try
        {
            return (DashboardController.GetQuickLinkDetails(QuickLinkItemID));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [WebMethod]
    public void ReorderSidebar(List<DashboardKeyValue> OrderList)
    {
        try
        {
            DashboardController.ReorderSidebarLink(OrderList);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public void ReorderQuickLinks(List<DashboardKeyValue> OrderList)
    {
        try
        {
            DashboardController.ReorderQuickLinks(OrderList);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [WebMethod]
    public void UpdateSidebarLinks(Sidebar sidebarObj)
    {
        try
        {
            sidebarObj.ImagePath = sidebarObj.ImagePath != null ? sidebarObj.ImagePath : "";
            DashboardController.UpdateSidebar(sidebarObj);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [WebMethod]
    public void UpdateLink(QuickLink linkObj)
    {
        try
        {
            linkObj.ImagePath = linkObj.ImagePath != null ? linkObj.ImagePath : "";
            DashboardController.UpdateLink(linkObj);
        }
        catch (Exception)
        {

            throw;
        }
    }


    [WebMethod]
    public DashboardInfo GetDashboardLinks(string UserName,int PortalID)
    {
        DashboardInfo dashObj = new DashboardInfo();
        dashObj.LSTQuickLinks = DashboardController.GetQuickLinks(UserName, PortalID);       
        return dashObj;
       
    }

    [WebMethod]
    public string GetLocalizedMessage(string CultureCode,string ModuleName,string MessageType)
    {
        return (SageMessage.ProcessSageMessage(CultureCode, ModuleName, MessageType));
    }

    [WebMethod]
    public void UpdateSidebar(string status,int PortalID,string UserName)
    {
        DashbordSettingInfo objSetting = new DashbordSettingInfo();
        objSetting.SettingKey = DashboardSettingKeys.SIDEBAR_MODE.ToString();
        objSetting.SettingValue = status;
        objSetting.PortalID = PortalID;
        objSetting.UserName = UserName;
        try
        {
            DashboardController.AddUpdateDashboardSettings(objSetting);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    [WebMethod]
    public void UpdateAppearance(string theme, int PortalID, string UserName)
    {
        DashbordSettingInfo objSetting = new DashbordSettingInfo();
        objSetting.SettingKey = DashboardSettingKeys.DASHBOARD_THEME.ToString();
        objSetting.SettingValue = theme;
        objSetting.PortalID = PortalID;
        objSetting.UserName = UserName;
        try
        {
            DashboardController.AddUpdateDashboardSettings(objSetting);
          
        }
        catch (Exception)
        {

            throw;
        }
    }
    [WebMethod]
    public List<ModuleWebInfo> GetModuleWebInfo()
    {
        try
        {

            return DashboardController.GetModuleWebInfo();
        }
        catch (Exception)
        {

            throw;
        }
    }

    [WebMethod]
    public string GetDefaultBlog()
    {
        try
        {
            return DashboardController.GetBlogContent();
        }
        catch (Exception)
        {

            throw;
        }

    }

    [WebMethod]
    public string GetDefaultNews()
    {
        try
        {
            return DashboardController.GetNewsContent();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod]
    public string GetDefaultTutorial()
    {
        try
        {
            return DashboardController.GetTutorialContent();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod]
    public void UpdageDefaultBlog(string content)
    {
        try
        {
            DashboardController.UpdateBlogContent(content);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public void UpdateDefaultTutorial(string content)
    {
        try
        {
            DashboardController.UpdateTutorialContent(content);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public void UpdateDefaultNews(string content)
    {
        try
        {
            DashboardController.UpdateNewsContent(content);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public void DeleteIcon(string IconPath)
    {
        try
        {
            string filepath = SageFrame.Templating.Utils.GetAbsolutePath(string.Format("Modules/DashBoard/Icons/{0}", IconPath));
            if (File.Exists(filepath))
            {
                File.SetAttributes(filepath, System.IO.FileAttributes.Normal);
                File.Delete(filepath);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    //---------PageModuleStatistics--------------------
    [WebMethod]
    public List<PageEntity> GetPageName(int PortalID, bool IsAdmin)
    {
        try
        {
            return (PageController.GetPages(PortalID, IsAdmin));
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    [WebMethod]
    public List<LayoutMgrInfo> Getmodules(int PortalID)
    {
        try
        {
            return (LayoutMgrDataProvider.GetModules(PortalID));
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }


    [WebMethod]
    public CountUserInfo GeneralSnapShot(int PortalID, bool IsAdmin)
    {
        try
        {
            return (DashboardDataProvider.GetGeneralSnapShot(PortalID, IsAdmin));
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }


    [WebMethod]
    public List<UserInfo> GetUsers(int PortalID, string UserName)
    {
        try
        {
            MembershipController m = new MembershipController();
            return (m.SearchUsers("", "", PortalID, UserName).UserList);
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }


}

