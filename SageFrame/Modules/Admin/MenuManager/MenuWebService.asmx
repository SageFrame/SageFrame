<%@ WebService Language="C#" Class="MenuWebService" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SageFrame.MenuManager;
using SageFrame.Security.Entities;
using SageFrame.Security;
using SageFrame.Templating;
using System.IO;
using SageFrame.Pages;

/// <summary>
/// Summary description for MenuWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class MenuWebService : System.Web.Services.WebService
{

    public MenuWebService()
    {
        
    }

    [WebMethod]
    public List<MenuManagerInfo> GetAllMenu(string UserName,int PortalID)
    {
        List<MenuManagerInfo> minfo = MenuManagerDataController.GetMenuList(UserName, PortalID);
        return (minfo);
    }
    [WebMethod]
    public List<MenuManagerInfo> GetSageMenu(string UserName, int UserModuleID, int PortalID)
    {
        return (MenuManagerDataController.GetSageMenuList(UserName, UserModuleID, PortalID));  
    }
    [WebMethod]
    public List<MenuManagerInfo> CheckDefaultMenu(int MenuID)
    {
        List<MenuManagerInfo> minfo = MenuManagerDataController.CheckDefaultMenu(MenuID);
        return (minfo);
    }
    [WebMethod]
    public void AddNewMenu(List<MenuPermissionInfo> lstMenuPermissions, string MenuName, string MenuType, bool IsDefault, int PortalID)
    {
        MenuManagerDataController.AddNewMenu(lstMenuPermissions, MenuName, MenuType, IsDefault, PortalID);
    }
    [WebMethod]
    public void UpdateMenu(List<MenuPermissionInfo> lstMenuPermissions, int MenuID, string MenuName, string MenuType, bool IsDefault, int PortalID)
    {
        MenuManagerDataController.UpdateMenu(lstMenuPermissions, MenuID, MenuName, MenuType, IsDefault, PortalID);
    }
    [WebMethod]
    public void AddSubText(int PageID, string SubText, bool IsActive, bool IsVisible)
    {

        MenuManagerDataController.AddSubText(PageID, SubText, IsActive, IsVisible);
    }
    
     [WebMethod]
    public void DeleteMenu( int MenuID)
    {
        MenuManagerDataController.DeleteMenu(MenuID);
    }

    [WebMethod]
    public List<PageEntity> GetNormalPage(int PortalID, string UserName, string CultureCode)
    {
        List<PageEntity> lstMenu = PageController.GetMenuFront(PortalID, false);
        foreach (PageEntity obj in lstMenu)
        {
            obj.ChildCount = lstMenu.Count(
                delegate(PageEntity objMenu)
                {
                    return (objMenu.ParentID == obj.PageID);
                }
                );
        }
        return lstMenu;
    }

    [WebMethod]
    public List<MenuManagerInfo> GetAdminPage(int PortalID, string UserName, string CultureCode)
    {
        List<MenuManagerInfo> lstMenu = MenuManagerDataController.GetAdminPage(PortalID, UserName, CultureCode);
        foreach (MenuManagerInfo obj in lstMenu)
        {
            obj.ChildCount = lstMenu.Count(
                delegate(MenuManagerInfo objMenu)
                {
                    return (objMenu.ParentID == obj.PageID);
                }
                );
        }
        return lstMenu;
    }

    [WebMethod]
    public void AddMenuItem(MenuManagerInfo objInfo)
    {
        objInfo.ImageIcon = objInfo.ImageIcon == "" || objInfo.ImageIcon == null ? "" : objInfo.ImageIcon;     
        MenuManagerDataController.AddMenuItem(objInfo);
        
    }


    [WebMethod]
    public List<MenuManagerInfo> GetAllMenuItem(int MenuID)
    {
        List<MenuManagerInfo> lstMenuItems = MenuManagerDataController.GetAllMenuItem(MenuID);

        IEnumerable<MenuManagerInfo> lstParent = new List<MenuManagerInfo>();
        List<MenuManagerInfo> lstHierarchy = new List<MenuManagerInfo>();
        lstParent = from pg in lstMenuItems
                    where pg.MenuLevel == "0"
                    select pg;
        foreach (MenuManagerInfo parent in lstParent)
        {
            lstHierarchy.Add(parent);
            GetChildPages(ref lstHierarchy, parent, lstMenuItems);
        }

        return (lstHierarchy);
    }



    public void GetChildPages(ref List<MenuManagerInfo> lstHierarchy, MenuManagerInfo parent, List<MenuManagerInfo> lstPages)
    {
        foreach (MenuManagerInfo obj in lstPages)
        {
            if (obj.ParentID == parent.MenuItemID)
            {                               
                lstHierarchy.Add(obj);
                GetChildPages(ref lstHierarchy, obj, lstPages);
            }
        }
    }
    [WebMethod]
    public int GetMenuOrder(string MenuLevel)
    {
        int MenuOrder = 1; 
        
        return MenuOrder;
    }


    [WebMethod]
    public void AddExternalLink(MenuManagerInfo objInfo)
    {
        objInfo.ImageIcon = objInfo.ImageIcon == "" || objInfo.ImageIcon == null ? "" : objInfo.ImageIcon;   
        MenuManagerDataController.AddExternalLink(objInfo);
    }
    
    [WebMethod]
    public void AddHtmlContent(MenuManagerInfo objInfo)
    {
        objInfo.ImageIcon = objInfo.ImageIcon == "" || objInfo.ImageIcon == null ? "" : objInfo.ImageIcon;   
        
        MenuManagerDataController.AddHtmlContent(objInfo);
    }

    [WebMethod]
    public void SortMenu(int MenuItemID, int ParentID, int BeforeID, int AfterID, int PortalID)
    {
        try
        {
            MenuManagerDataController.SortMenu(MenuItemID, ParentID, BeforeID, AfterID, PortalID);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [WebMethod]
    public MenuManagerInfo GetDetails(int MenuItemID)
    {
        return (MenuManagerDataController.GetMenuItemDetails(MenuItemID));
    }


    [WebMethod]
    public void AddSetting(List<MenuManagerInfo> lstSettings)
    {
        MenuManagerDataController.AddSetting(lstSettings);
    }

    [WebMethod]
    public MenuManagerInfo GetMenuSettings(int PortalID, int MenuID)
    {
        return (MenuManagerDataController.GetMenuSetting(PortalID, MenuID));
    }
    [WebMethod]
    public List<MenuPermissionInfo> GetMenuPermission(int PortalID, int MenuID)
    {
        return (MenuManagerDataController.GetMenuPermission(PortalID, MenuID));
    }
    [WebMethod]
    public List<RoleInfo> GetPortalRoles(int PortalID, string UserName)
    {

        RoleController _role = new RoleController();
        return (_role.GetPortalRoles(PortalID, 1, UserName));
    }
    [WebMethod]
    public void AddMenuPermission(List<MenuPermissionInfo> lstMenuPermissions, int MenuID, int PortalID)
    {
        MenuManagerDataController.AddMenuPermission(lstMenuPermissions,MenuID, PortalID);
    }

    [WebMethod]
    public List<UserInfo> SearchUsers(string SearchText, int PortalID, string UserName)
    {
        MembershipController msController = new MembershipController();
        List<UserInfo> lstUsers = msController.SearchUsers("", SearchText, PortalID, UserName).UserList;
        return lstUsers;
    }
    
    [WebMethod]
    public void DeleteIcon(string IconPath)
    {
        try
        {
            string filepath = Utils.GetAbsolutePath(string.Format("Modules/Admin/MenuManager/Icons/{0}",IconPath));
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

    [WebMethod]
    public void DeleteLink(int MenuItemID)
    {
        MenuManagerDataController.DeleteLink(MenuItemID);
    }

    [WebMethod]
    public void SaveSageMenu(int UserModuleID, int PortalID, string SettingKey, string SettingValue)
    {
        MenuManagerDataController.UpdateSageMenuSelected(UserModuleID, PortalID, SettingKey, SettingValue);
    }
    
   
  


    

}


