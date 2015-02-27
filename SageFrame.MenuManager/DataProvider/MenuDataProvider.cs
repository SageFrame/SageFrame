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
using SageFrame.Pages;

namespace SageFrame.SageMenu
{
    public class MenuDataProvider
    {
        public static List<MenuInfo> GetMenuFront(int PortalID, string UserName, string CultureCode)
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            string StoredProcedureName = "[dbo].[usp_SageMenuGetClientView]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@prefix", "---"));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsDeleted", 0));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureCode", CultureCode));
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {
                lstPages.Add(new MenuInfo(int.Parse(SQLReader["PageID"].ToString()), int.Parse(SQLReader["PageOrder"].ToString()), SQLReader["PageName"].ToString(), int.Parse(SQLReader["ParentID"].ToString()), int.Parse(SQLReader["Level"].ToString()), SQLReader["LevelPageName"].ToString(), SQLReader["SEOName"].ToString(), SQLReader["TabPath"].ToString(), bool.Parse(SQLReader["IsVisible"].ToString()), bool.Parse(SQLReader["ShowInMenu"].ToString()),SQLReader["IconFile"].ToString()));
            }
            return lstPages;

        } 

      
        public static void GetChildPages(ref List<PageEntity> pageList, PageEntity parent, List<PageEntity> lstPages)
        {
            foreach (PageEntity obj in lstPages)
            {
                if (obj.ParentID == parent.PageID)
                {
                    obj.PageNameWithoughtPrefix = obj.PageName;
                    obj.Prefix = GetPrefix(obj.Level);
                    obj.PageName = obj.Prefix + obj.PageName;
                    pageList.Add(obj);
                    GetChildPages(ref pageList, obj, lstPages);
                }
            }
        }
        public static string GetPrefix(int Level)
        {
            string prefix = "";
            for (int i = 0; i < Level; i++)
            {
                prefix += "----";
            }
            return prefix;
        }

        public static List<MenuInfo> GetFooterMenu(int PortalID, string UserName,string CultureCode)
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            string StoredProcedureName = "[dbo].[usp_SageMenuGetFooter]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureCode", CultureCode));
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName,ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {
                lstPages.Add(new MenuInfo(int.Parse(SQLReader["PageID"].ToString()), int.Parse(SQLReader["PageOrder"].ToString()), SQLReader["PageName"].ToString(), int.Parse(SQLReader["ParentID"].ToString()), int.Parse(SQLReader["Level"].ToString()), SQLReader["LevelPageName"].ToString(), SQLReader["SEOName"].ToString(), SQLReader["TabPath"].ToString(), bool.Parse(SQLReader["IsVisible"].ToString()), bool.Parse(SQLReader["ShowInMenu"].ToString())));                               
               
               
            }
            return lstPages;

        }
        public static List<MenuInfo> GetAdminMenu()
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            string StoredProcedureName = "[dbo].[usp_sagemenugetadminmenu]";
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {
                lstPages.Add(new MenuInfo(int.Parse(SQLReader["PageID"].ToString()), int.Parse(SQLReader["PageOrder"].ToString()), SQLReader["PageName"].ToString(), int.Parse(SQLReader["ParentID"].ToString()), int.Parse(SQLReader["Level"].ToString()), SQLReader["LevelPageName"].ToString(), SQLReader["SEOName"].ToString(), SQLReader["TabPath"].ToString(), bool.Parse(SQLReader["IsVisible"].ToString()), bool.Parse(SQLReader["ShowInMenu"].ToString())));                               
               
                
            }
            return lstPages;

        }
        public static List<MenuInfo> GetSideMenu(int PortalID,string UserName,string PageName,string CultureCode)
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            string StoredProcedureName = "[dbo].[usp_SageMenuGetSideMenu]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PageName", PageName));            
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName,ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {                
                MenuInfo objMenu = new MenuInfo();
                objMenu.PageID = int.Parse(SQLReader["PageID"].ToString());
                objMenu.PageOrder = int.Parse(SQLReader["PageOrder"].ToString());
                objMenu.PageName = SQLReader["PageName"].ToString();
                objMenu.ParentID = int.Parse(SQLReader["ParentID"].ToString());
                objMenu.Level = int.Parse(SQLReader["Level"].ToString());
                objMenu.TabPath = SQLReader["TabPath"].ToString();
                lstPages.Add(objMenu);
                
            }
            return lstPages;

        }

        public static void UpdateSageMenuSettings(List<SageMenuSettingInfo> lstSetting)
        {
            foreach (SageMenuSettingInfo obj in lstSetting)
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", obj.UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", obj.SettingKey));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingValue", obj.SettingValue));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", obj.IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", obj.AddedBy));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", obj.AddedBy));

                try
                {
                    SQLHandler sagesql = new SQLHandler();
                    sagesql.ExecuteNonQuery("[dbo].[usp_SageMenuSettingAddUpdate]", ParaMeterCollection);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static SageMenuSettingInfo GetMenuSetting(int PortalID, int UserModuleID)
        {
            SageMenuSettingInfo objSetting = new SageMenuSettingInfo();
            string StoredProcedureName = "[dbo].[usp_SageMenuSettingGetAll]";
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           
            try
            {
                objSetting = sagesql.ExecuteAsObject<SageMenuSettingInfo>(StoredProcedureName, ParaMeterCollection);

            }
            catch (Exception e)
            {
                throw e;
            }


            return objSetting;
        }

        public static List<MenuInfo> GetBackEndMenu(int ParentNodeID,string UserName,int PortalID,string CultureCode)
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ParentNodeID", ParentNodeID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureCode",CultureCode));
            string StoredProcedureName = "[usp_SageMenuAdminGet]";
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName,ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {
                MenuInfo objMenu = new MenuInfo();
                objMenu.PageID=int.Parse(SQLReader["PageID"].ToString());
                objMenu.PageOrder= int.Parse(SQLReader["PageOrder"].ToString());
                objMenu.PageName=SQLReader["PageName"].ToString();
                objMenu.ParentID= int.Parse(SQLReader["ParentID"].ToString());
                objMenu.Level=int.Parse(SQLReader["Level"].ToString());
                objMenu.TabPath=SQLReader["TabPath"].ToString();
                lstPages.Add(objMenu);


            }
            return lstPages;
        }

        public static List<MenuInfo> GetAdminPages(int PortalID, string UserName, string CultureCode)
        {
            List<MenuInfo> lstPages = new List<MenuInfo>();
            string StoredProcedureName = "[dbo].[usp_GetAdminPages]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@prefix", "---"));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsDeleted", 0));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureCode", CultureCode));
            SqlDataReader SQLReader;
            try
            {
                SQLHandler sagesql = new SQLHandler();
                SQLReader = sagesql.ExecuteAsDataReader(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

            while (SQLReader.Read())
            {
  
                MenuInfo objMenu = new MenuInfo();
                objMenu.PageID = int.Parse(SQLReader["PageID"].ToString());
                objMenu.PageOrder = int.Parse(SQLReader["PageOrder"].ToString());
                objMenu.PageName = SQLReader["PageName"].ToString();
                objMenu.ParentID = int.Parse(SQLReader["ParentID"].ToString());
                objMenu.Level = int.Parse(SQLReader["Level"].ToString());
                objMenu.TabPath = SQLReader["TabPath"].ToString();
                lstPages.Add(objMenu);
            }
            return lstPages;

        } 


    }
}
