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

namespace SageFrame.SageMenu
{
    public class MenuController
    {
        public static List<MenuInfo> GetMenuFront(int PortalID, string UserName, string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetMenuFront(PortalID, UserName, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuInfo> GetFooterMenu(int PortalID, string UserName, string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetFooterMenu(PortalID, UserName, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuInfo> GetSideMenu(int PortalID, string UserName, int menuID, string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetSideMenu(PortalID, UserName, menuID, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateSageMenuSettings(List<SageMenuSettingInfo> lstSetting)
        {
            try
            {
                MenuDataProvider.UpdateSageMenuSettings(lstSetting);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static SageMenuSettingInfo GetMenuSetting(int PortalID, int UserModuleID)
        {
            try
            {
                return (MenuDataProvider.GetMenuSetting(PortalID, UserModuleID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuInfo> GetAdminMenu()
        {
            try
            {
                return (MenuDataProvider.GetAdminMenu());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MenuInfo> GetAdminPages(int PortalID, string UserName, string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetAdminPages(PortalID, UserName, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static List<MenuInfo> GetBackEndMenu(string UserName, int PortalID, string CultureCode, int UserMode)
        {
            try
            {
                List<MenuInfo> AdminMenu = MenuDataProvider.GetBackEndMenu(2, UserName, PortalID, CultureCode);
                if (UserMode == 1)
                {
                    List<MenuInfo> SuperUserMenu = MenuDataProvider.GetBackEndMenu(3, UserName, PortalID, CultureCode);
                    AdminMenu.AddRange(SuperUserMenu);
                }
                return AdminMenu;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
