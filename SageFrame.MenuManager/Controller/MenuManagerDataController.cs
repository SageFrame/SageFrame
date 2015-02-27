#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Pages;
#endregion

namespace SageFrame.MenuManager
{
    public class MenuManagerDataController
    {

        public static List<MenuManagerInfo> GetMenuList(string UserName, int PortalID)
        {
            try
            {
                return (MenuManagerDataProvider.GetMenuList(UserName, PortalID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuManagerInfo> GetSageMenuList(string UserName, int UserModuleID, int PortalID)
        {
            try
            {
                return (MenuManagerDataProvider.GetSageMenuList(UserName, UserModuleID, PortalID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdateMenu(List<MenuPermissionInfo> lstMenuPermissions, int MenuID, string MenuName, string MenuType, bool IsDefault, int PortalID)
        {
            try
            {
                MenuManagerDataProvider.UpdateMenu(lstMenuPermissions, MenuID, MenuName, MenuType, IsDefault, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuManagerInfo> CheckDefaultMenu(int MenuID)
        {
            try
            {
                return (MenuManagerDataProvider.CheckDefaultMenu(MenuID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddNewMenu(List<MenuPermissionInfo> lstMenuPermissions, string MenuName, string MenuType, bool IsDefault, int PortalID)
        {
            try
            {
                MenuManagerDataProvider.AddNewMenu(lstMenuPermissions, MenuName, MenuType, IsDefault, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddSubText(int PageID, string SubText, bool IsActive, bool IsVisible)
        {
            try
            {
                MenuManagerDataProvider.AddSubText(PageID, SubText, IsActive, IsVisible);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteMenu(int MenuID)
        {
            try
            {
                MenuManagerDataProvider.DeleteMenu(MenuID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<PageEntity> GetNormalPage(int PortalID, string UserName, string CultureCode)
        {
            try
            {
                return (MenuManagerDataProvider.GetNormalPage(PortalID, UserName, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuManagerInfo> GetAdminPage(int PortalID, string UserName, string CultureCode)
        {
            try
            {
                return (MenuManagerDataProvider.GetAdminPage(PortalID, UserName, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void AddMenuItem(MenuManagerInfo MenuItems)
        {
            try
            {
                MenuManagerDataProvider.AddMenuItem(MenuItems);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddExternalLink(MenuManagerInfo MenuItems)
        {
            try
            {
                MenuManagerDataProvider.AddExternalLink(MenuItems);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddHtmlContent(MenuManagerInfo MenuItems)
        {
            try
            {
                MenuManagerDataProvider.AddHtmlContent(MenuItems);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<MenuManagerInfo> GetAllMenuItem(int MenuID)
        {
            try
            {
                return (MenuManagerDataProvider.GetAllMenuItem(MenuID));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SortMenu(int MenuItemID, int ParentID, int BeforeID, int AfterID, int PortalID)
        {
            try
            {
                MenuManagerDataProvider.SortMenu(MenuItemID, ParentID, BeforeID, AfterID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static MenuManagerInfo GetMenuItemDetails(int MenuItemID)
        {
            try
            {
                return (MenuManagerDataProvider.GetMenuItemDetails(MenuItemID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddSetting(List<MenuManagerInfo> objInfo)
        {
            try
            {
                MenuManagerDataProvider.AddSetting(objInfo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static MenuManagerInfo GetMenuSetting(int PortalID, int MenuID)
        {
            try
            {
                return (MenuManagerDataProvider.GetMenuSetting(PortalID, MenuID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuPermissionInfo> GetMenuPermission(int PortalID, int MenuID)
        {
            try
            {
                return (MenuManagerDataProvider.GetMenuPermission(PortalID, MenuID));
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<MenuManagerInfo> GetAllMenuItems(int UserModuleID, int PortalID)
        {
            try
            {
                return (MenuManagerDataProvider.GetAllMenuItems(UserModuleID, PortalID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuManagerInfo> GetSageMenu(int UserModuleID, int PortalID, string UserName)
        {
            try
            {
                return (MenuManagerDataProvider.GetSageMenu(UserModuleID, PortalID, UserName));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<MenuManagerInfo> GetSageMenu_Localized(int UserModuleID, int PortalID, string UserName, string CultureName)
        {
            try
            {
                return MenuManagerDataProvider.GetSageMenu_Localized(UserModuleID, PortalID, UserName, CultureName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddMenuPermission(List<MenuPermissionInfo> lstMenuPermissions, int MenuID, int PortalID)
        {
            try
            {
                MenuManagerDataProvider.AddMenuPermission(lstMenuPermissions, MenuID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteLink(int MenuItemID)
        {
            try
            {
                MenuManagerDataProvider.DeleteLink(MenuItemID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdateSageMenuSelected(int UserModuleID, int PortalID, string SettingKey, string SettingValue)
        {
            try
            {
                MenuManagerDataProvider.UpdateSageMenuSelected(UserModuleID, PortalID, SettingKey, SettingValue);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<SitemapInfo> GetSiteMapPages(string UserName, string CultureCode)
        {
            try
            {
                return MenuManagerDataProvider.GetSiteMapPages(UserName, CultureCode);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
