<%@ WebService Language="C#"  Class="MenuWebService" %>
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SageFrame.Framework;
using SageFrame.SageMenu;
using System.Collections.Generic;
using SageFrame.MenuManager;


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

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
               
        [WebMethod]
        public List<MenuInfo> GetBackEndMenu(int PortalID, string UserName, string CultureCode, int UserMode, string PortalSEOName)
        {
            try
            {
                List<MenuInfo> lstMenu = MenuController.GetBackEndMenu(UserName, PortalID, CultureCode, UserMode);
                string PortalName = PortalSEOName.ToLower() != "default" ? "/portal/" + PortalSEOName : "";
                lstMenu.Add(new MenuInfo(2, 0, "Admin", 0, PortalName + "/Admin/Admin.aspx"));
                if (UserMode == 1)
                {
                    lstMenu.Add(new MenuInfo(3, 0, "SuperUser", 0, PortalName + "/Super-User/Super-User.aspx"));
                }
                foreach (MenuInfo obj in lstMenu)
                {
                    obj.ChildCount = lstMenu.Count(
                        delegate(MenuInfo objMenu)
                        {
                            return (objMenu.ParentID == obj.PageID);
                        }
                        );
                }
                return lstMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<MenuManagerInfo> GetMenuFront(int PortalID, string UserName, string CultureCode,int UserModuleID)
        {
           
            List<MenuManagerInfo> lstMenuItems = MenuManagerDataController.GetSageMenu(UserModuleID,PortalID,UserName);

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

        [WebMethod]
        public List<MenuManagerInfo> GetCustomSideMenu(int PortalID, string UserName, string CultureCode, int UserModuleID)
        {

            List<MenuManagerInfo> lstMenuItems = MenuManagerDataController.GetSageMenu(UserModuleID, PortalID, UserName);

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

        [WebMethod]
        public List<MenuManagerInfo> GetFooterMenu(int PortalID, string UserName, string CultureCode, int UserModuleID)
        {

            List<MenuManagerInfo> lstMenuItems = MenuManagerDataController.GetSageMenu(UserModuleID, PortalID, UserName);

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
        public List<MenuInfo> GetPages()
        {
            List<MenuInfo> lstMenu = MenuController.GetMenuFront(1, "superuser", "en-US");
            foreach (MenuInfo obj in lstMenu)
            {
                obj.ChildCount = lstMenu.Count(
                    delegate(MenuInfo objMenu)
                    {
                        return (objMenu.ParentID == obj.PageID);
                    }
                    );
            }
            return lstMenu;
        }
       

        [WebMethod]
        public List<MenuInfo> GetSideMenu(int PortalID, string UserName, string PageName, string CultureCode)
        {
            List<MenuInfo> lstMenu = MenuController.GetSideMenu(PortalID, UserName, PageName, CultureCode);
            foreach (MenuInfo obj in lstMenu)
            {
                obj.ChildCount = lstMenu.Count(
                    delegate(MenuInfo objMenu)
                    {
                        return (objMenu.ParentID == obj.PageID);
                    }
                    );
                obj.Title = obj.PageName;
            }
            return lstMenu;
        }

        [WebMethod]
        public SageMenuSettingInfo GetMenuSettings(int PortalID, int UserModuleID)
        {
            return (MenuController.GetMenuSetting(PortalID, UserModuleID));
        }

        [WebMethod]
        public void SaveMenuSetting(List<SageMenuSettingInfo> lstMenuSetting)
        {
            MenuController.UpdateSageMenuSettings(lstMenuSetting);
        }

        [WebMethod]
        public List<MenuInfo> GetAdminPages(int PortalID, string UserName, string CultureCode)
        {
            List<MenuInfo> lstMenu = MenuController.GetAdminPages(PortalID, UserName, CultureCode);
            foreach (MenuInfo obj in lstMenu)
            {
                obj.ChildCount = lstMenu.Count(
                    delegate(MenuInfo objMenu)
                    {
                        return (objMenu.ParentID == obj.PageID);
                    }
                    );
            }
            return lstMenu;
        }
    }



