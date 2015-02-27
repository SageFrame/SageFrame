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
using System.Text;
using SageFrame.Pages;

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

        

        public static List<MenuInfo> GetFooterMenu(int PortalID, string UserName,string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetFooterMenu(PortalID, UserName,CultureCode));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<MenuInfo>  GetSideMenu(int PortalID,string UserName,string PageName,string CultureCode)
        {
            try
            {
                return (MenuDataProvider.GetSideMenu(PortalID,UserName,PageName,CultureCode));
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


        public static List<MenuInfo> GetBackEndMenu(string UserName, int PortalID, string CultureCode,int UserMode)
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
