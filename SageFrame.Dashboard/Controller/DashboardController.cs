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
using SageFrame.Web;

namespace SageFrame.Dashboard
{
    public class DashboardController
    {
        public static bool AddQuickLink(QuickLink linkObj)
        {
            try
            {
                return (DashboardDataProvider.AddQuickLink(linkObj));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Link> GetAdminPages(int PortalID)
        {
            try
            {
                return (DashboardDataProvider.GetAdminPages(PortalID));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<QuickLink> GetQuickLinks(string UserName,int PortalID)
        {
            try
            {
                return (DashboardDataProvider.GetQuickLinks(UserName, PortalID));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<QuickLink> GetQuickLinksAll(string UserName, int PortalID)
        {
            try
            {
                return (DashboardDataProvider.GetQuickLinksAll(UserName, PortalID));
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void DeleteQuickLink(int QuickLinkID)
        {
            try
            {
                DashboardDataProvider.DeleteQuickLink(QuickLinkID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool AddSidebar(Sidebar sbObj)
        {
            try
            {
                return (DashboardDataProvider.AddSidebar(sbObj));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<Sidebar> GetSidebar(string UserName,int PortalID)
        {
            try
            {
                List<Sidebar> lstSidebar = DashboardDataProvider.GetSidebar(UserName, PortalID);
                return lstSidebar;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Sidebar> GetSidebarAll(string UserName, int PortalID)
        {
            try
            {
                List<Sidebar> lstSidebar = DashboardDataProvider.GetSidebarAll(UserName, PortalID);
                return lstSidebar;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdateLink(QuickLink linkObj)
        {
            try
            {
                DashboardDataProvider.UpdateLink(linkObj);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Sidebar> GetParentLinks(int SidebarItemID)
        {
            try
            {
                List<Sidebar> lstSidebar = DashboardDataProvider.GetParentLinks(SidebarItemID);
                Sidebar zeroItem = new Sidebar();
                zeroItem.DisplayName = "[None Specified]";
                lstSidebar.Insert(0, zeroItem);
                return lstSidebar;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void DeleteSidebarItem(int SidebarItemID)
        {
            try
            {
                DashboardDataProvider.DeleteSidebarItem(SidebarItemID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Sidebar GetSidebarDetails(int SidebarItemID)
        {
            return (DashboardDataProvider.GetSidebarDetails(SidebarItemID));
        }
        public static QuickLink GetQuickLinkDetails(int SidebarItemID)
        {
            return (DashboardDataProvider.GetQuickLinkDetails(SidebarItemID));
        }
        public static void ReorderSidebarLink(List<DashboardKeyValue> lstOrder)
        {
            try
            {
                DashboardDataProvider.ReorderSidebarLink(lstOrder);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void ReorderQuickLinks(List<DashboardKeyValue> lstOrder)
        {
            try
            {
                DashboardDataProvider.ReorderQuickLinks(lstOrder);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool UpdateSidebar(Sidebar sbObj)
        {
            try
            {
                return (DashboardDataProvider.UpdateSidebar(sbObj));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void AddUpdateDashboardSettings(DashbordSettingInfo objSetting)
        {
            try
            {
                DashboardDataProvider.AddUpdateDashboardSettings(objSetting);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static DashbordSettingInfo GetSettingByKey(DashbordSettingInfo objSetting)
        {
            try
            {
                return (DashboardDataProvider.GetSettingByKey(objSetting));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static CountUserInfo GetOnlineUserCount()
        {
            try
            {
                return (DashboardDataProvider.GetOnlineUserCount());
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<ModuleInfo> GetModules(int TotalCount)
        {
            try
            {
                return (DashboardDataProvider.GetModules(TotalCount));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ModuleWebInfo> GetModuleWebInfo()
        {
            try
            {
                return (DashboardDataProvider.GetModuleWebInfo());
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void AddModuleWebInfo(List<ModuleWebInfo> list)
        {
            try
            {
                DashboardDataProvider.AddModuleWebInfo(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ModuleInfo> SearchModules(string keyword)
        {
            try
            {
                return DashboardDataProvider.SearchModules(keyword);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateBlogContent(string content)
        {
            try
            {
                DashboardDataProvider.UpdateBlogContent(content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetBlogContent()
        {

            try
            {
                return DashboardDataProvider.GetBlogContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateTutorialContent(string content)
        {
            try
            {
                DashboardDataProvider.UpdateTutorialContent(content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetTutorialContent()
        {
            try
            {
                return DashboardDataProvider.GetTutorialContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateNewsContent(string content)
        {
            try
            {
                DashboardDataProvider.UpdateNewsContent(content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetNewsContent()
        {
            try
            {
                return DashboardDataProvider.GetNewsContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
