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
using SageFrame.Web.Utilities;
using System.Data;
using System.Data.SqlClient;
using SageFrame.Web;
using SageFrame.Core;
using System.Data.Common;

namespace SageFrame.Dashboard
{
    public class DashboardDataProvider
    {
        public static bool AddQuickLink(QuickLink linkObj)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayName", linkObj.DisplayName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", linkObj.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ImagePath", linkObj.ImagePath));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder",linkObj.DisplayOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", linkObj.PageID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", linkObj.IsActive));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Link> GetAdminPages(int PortalID)
        {
            string sp = "[dbo].[usp_DashboardGetAdminPages]";
            SQLHandler sagesql = new SQLHandler();
            List<Link> lstPages = new List<Link>();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID",PortalID));
            try
            {
                lstPages = sagesql.ExecuteAsList<Link>(sp, ParamCollInput);
                return lstPages;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<QuickLink> GetQuickLinks(string UserName, int PortalID)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkGet]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            List<QuickLink> lstLinks = new List<QuickLink>();
           
            try
            {
                lstLinks = sagesql.ExecuteAsList<QuickLink>(sp,ParamCollInput);
                return lstLinks;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<QuickLink> GetQuickLinksAll(string UserName, int PortalID)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkGetAll]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            List<QuickLink> lstLinks = new List<QuickLink>();

            try
            {
                lstLinks = sagesql.ExecuteAsList<QuickLink>(sp, ParamCollInput);
                return lstLinks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteQuickLink(int QuickLinkID)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkDelete]";
            SQLHandler sagesql = new SQLHandler();
           
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@QuickLinkID", QuickLinkID));
            try
            {
                sagesql.ExecuteNonQuery(sp, ParamCollInput);
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static bool AddSidebar(Sidebar sbObj)
        {
            string sp = "[dbo].[usp_DashboardSidebarAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayName", sbObj.DisplayName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Depth", sbObj.Depth));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ImagePath", sbObj.ImagePath));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", sbObj.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID",sbObj.ParentID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", sbObj.IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", sbObj.DisplayOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", sbObj.PageID));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool UpdateSidebar(Sidebar sbObj)
        {
            string sp = "[dbo].[usp_DashboardSidebarUpdate]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayName", sbObj.DisplayName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Depth", sbObj.Depth));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ImagePath", sbObj.ImagePath));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", sbObj.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID", sbObj.ParentID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", sbObj.IsActive));               
                ParamCollInput.Add(new KeyValuePair<string, object>("@SidebarItemID", sbObj.SidebarItemID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", sbObj.PageID));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool UpdateLink(QuickLink linkObj)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkUpdate]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayName", linkObj.DisplayName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", linkObj.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ImagePath", linkObj.ImagePath));
                ParamCollInput.Add(new KeyValuePair<string, object>("@QuickLinkID", linkObj.QuickLinkID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", linkObj.PageID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", linkObj.IsActive));
                sagesql.ExecuteNonQuery(sp, ParamCollInput);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Sidebar> GetSidebar(string UserName,int PortalID)
        {
            string sp = "[dbo].[usp_DashboardSidebarGet]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

            List<Sidebar> lstLinks = new List<Sidebar>();

            try
            {
                lstLinks = sagesql.ExecuteAsList<Sidebar>(sp,ParamCollInput);
                return lstLinks;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Sidebar> GetSidebarAll(string UserName, int PortalID)
        {
            string sp = "[dbo].[usp_DashboardSidebarGetAll]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

            List<Sidebar> lstLinks = new List<Sidebar>();

            try
            {
                lstLinks = sagesql.ExecuteAsList<Sidebar>(sp, ParamCollInput);
                return lstLinks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Sidebar> GetParentLinks(int SidebarItemID)
        {
            string sp = "[dbo].[usp_DashboardSidebarGetParents]";
            SQLHandler sagesql = new SQLHandler();
            List<Sidebar> lstLinks = new List<Sidebar>();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@SidebarItemID", SidebarItemID));
            try
            {
                lstLinks = sagesql.ExecuteAsList<Sidebar>(sp,ParamCollInput);
                return lstLinks;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteSidebarItem(int SidebarItemID)
        {
            string sp = "[dbo].[usp_DashboardSidebarDelete]";
            SQLHandler sagesql = new SQLHandler();

            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@SidebarItemID", SidebarItemID));
            try
            {
                sagesql.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Sidebar GetSidebarDetails(int SidebarItemID)
        {
            string sp = "[dbo].[usp_DashboardSidebarGetDetails]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@SidebarItemID", SidebarItemID));
            try
            {
                return(sagesql.ExecuteAsObject<Sidebar>(sp, ParamCollInput));
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static QuickLink GetQuickLinkDetails(int QuickLinkItemID)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkGetDetails]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@QuickLinkItemID", QuickLinkItemID));
            try
            {
                return (sagesql.ExecuteAsObject<QuickLink>(sp, ParamCollInput));


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ReorderSidebarLink(List<DashboardKeyValue> lstOrder)
        {
            string sp = "[dbo].[usp_DashboardSidebarReorder]";
            SQLHandler sagesql = new SQLHandler();
            foreach (DashboardKeyValue kvp in lstOrder)
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@SidebarItemID", kvp.Key));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", kvp.Value));
                try
                {
                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static void ReorderQuickLinks(List<DashboardKeyValue> lstOrder)
        {
            string sp = "[dbo].[usp_DashboardQuickLinkReorder]";
            SQLHandler sagesql = new SQLHandler();
            foreach (DashboardKeyValue kvp in lstOrder)
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@QuickLinkID", kvp.Key));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", kvp.Value));
                try
                {
                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void AddUpdateDashboardSettings(DashbordSettingInfo objSetting)
        {
            string sp = "[dbo].[usp_DashboardSettingAddUpdate]";
            SQLHandler sagesql = new SQLHandler();
           
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingKey", objSetting.SettingKey));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingValue", objSetting.SettingValue));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", objSetting.UserName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", objSetting.PortalID));
                try
                {
                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }
                catch (Exception)
                {

                    throw;
                }
            
        }

        public static DashbordSettingInfo GetSettingByKey(DashbordSettingInfo objSetting)
        {
            string sp = "[dbo].[usp_DashboardGetSettingByKey]";
            SQLHandler sagesql = new SQLHandler();

            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@SettingKey", objSetting.SettingKey));           
            ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", objSetting.UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", objSetting.PortalID));
            try
            {
                return(sagesql.ExecuteAsObject<DashbordSettingInfo>(sp, ParamCollInput));

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
                SQLHandler Objsql = new SQLHandler();
                return Objsql.ExecuteAsObject<CountUserInfo>("[dbo].[usp_OnlineUserCountGet]");

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<ModuleWebInfo> GetModuleWebInfo()
        {
            SQLHandler sageSql = new SQLHandler();
            try
            {

                List<ModuleWebInfo> list = sageSql.ExecuteAsList<ModuleWebInfo>("usp_ModuleWebInfoGetAll");

                //foreach (ModuleWebInfo moduleInfo in list)
                //{
                //    moduleInfo.DownloadUrl = "";
                //}
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ModuleInfo> GetModules(int TotalCount)
        {
            SQLHandler sageSql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModulesCount", TotalCount));

                List<ModuleInfo> list = sageSql.ExecuteAsList<ModuleInfo>("usp_LatestModulesList", ParamCollInput);

                //foreach (ModuleWebInfo moduleInfo in list)
                //{
                //    moduleInfo.DownloadUrl = "";
                //}
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ModuleInfo> SearchModules(string keyword)
        {
            SQLHandler sageSql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@keyword", keyword));
                List<ModuleInfo> list = sageSql.ExecuteAsList<ModuleInfo>("usp_PackageSearch", ParamCollInput);

                //foreach (ModuleWebInfo moduleInfo in list)
                //{
                //    moduleInfo.DownloadUrl = "";
                //}
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AddModuleWebInfo(List<ModuleWebInfo> list)
        {
            string sp = "[dbo].[usp_ModuleWebInfoDelete]";
            SQLHandler sagesql = new SQLHandler();

            DbTransaction transaction = sagesql.GetTransaction();

            try
            {
                sagesql.ExecuteNonQuery(sp);

                sp = "[dbo].[usp_ModuleWebInfoAdd]";
                foreach (ModuleWebInfo Obj in list)
                {
                    List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                    ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", Obj.ModuleID));
                    ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleName", Obj.ModuleName));
                    ParamCollInput.Add(new KeyValuePair<string, object>("@ReleaseDate", Obj.ReleaseDate));
                    ParamCollInput.Add(new KeyValuePair<string, object>("@Description", Obj.Description));
                    ParamCollInput.Add(new KeyValuePair<string, object>("@Version", Obj.Version));
                    ParamCollInput.Add(new KeyValuePair<string, object>("@DownloadUrl", Obj.DownloadUrl));


                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }

                sagesql.CommitTransaction(transaction);
            }
            catch (Exception ex)
            {
                sagesql.RollbackTransaction(transaction);
                throw ex;
            }


        }


        public static void UpdateBlogContent(string content)
        {
            string sp = "[dbo].[usp_BlogRssContentAdd]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> paramColl = new List<KeyValuePair<string, object>>();
            paramColl.Add(new KeyValuePair<string, object>("@BlogContent", content));

            try
            {
                sagesql.ExecuteNonQuery(sp, paramColl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetBlogContent()
        {
            string sp = "[dbo].[usp_GetBlogRssContent]";
            SQLHandler sagesql = new SQLHandler();
            string content = "";
            try
            {
                SqlDataReader reader = sagesql.ExecuteAsDataReader(sp);

                while (reader.Read())
                {
                    content = reader["BlogContent"] as string;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return content;
        }

        public static void UpdateTutorialContent(string content)
        {
            string sp = "[dbo].[usp_TutorialRssContentUpdate]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> paramColl = new List<KeyValuePair<string, object>>();
            paramColl.Add(new KeyValuePair<string, object>("@TutorialContent", content));

            try
            {
                sagesql.ExecuteNonQuery(sp, paramColl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetTutorialContent()
        {
            string sp = "[dbo].[usp_TutorialRssContentGet]";
            SQLHandler sagesql = new SQLHandler();
            string content = "";
            try
            {
                SqlDataReader reader = sagesql.ExecuteAsDataReader(sp);

                while (reader.Read())
                {
                    content = reader["TutorialContent"] as string;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return content;
        }

        public static void UpdateNewsContent(string content)
        {
            string sp = "[dbo].[usp_NewsRssContentUpdate]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> paramColl = new List<KeyValuePair<string, object>>();
            paramColl.Add(new KeyValuePair<string, object>("@NewsContent", content));

            try
            {
                sagesql.ExecuteNonQuery(sp, paramColl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetNewsContent()
        {
            string sp = "[dbo].[usp_NewsRssContentGet]";
            SQLHandler sagesql = new SQLHandler();
            string content = "";
            try
            {
                SqlDataReader reader = sagesql.ExecuteAsDataReader(sp);

                while (reader.Read())
                {
                    content = reader["NewsContent"] as string;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return content;
        }
        public static CountUserInfo GetGeneralSnapShot(int PortalID, bool IsAdmin)
        {
            SQLHandler sageSql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsAdmin", IsAdmin));
                return sageSql.ExecuteAsObject<CountUserInfo>("[dbo].[usp_DashBoardPageModuleStatistics]", ParamCollInput);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
