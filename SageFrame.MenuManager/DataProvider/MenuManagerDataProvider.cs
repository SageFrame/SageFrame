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
using System.Data.SqlClient;
using System.Data;
using SageFrame.Pages;

namespace SageFrame.MenuManager
{
   public class MenuManagerDataProvider
    {
       public static List<MenuManagerInfo> GetMenuList(string UserName,int PortalID)
       {
           try
           {
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuManagerGetMenu]",ParamCollInput);
           }
           catch (Exception)
           {
               
               throw;
           }
         
       }
       public static void UpdateMenu(List<MenuPermissionInfo> lstMenuPermissions, int MenuID, string MenuName, string MenuType, bool IsDefault, int PortalID)
       {
           string sp = "[dbo].[usp_MenuMgrUpdateMenu]";
           SQLHandler sagesql = new SQLHandler();

           try
           {

               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuName", MenuName));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuType", MenuType));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsDefault", IsDefault));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuID));

               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }
       public static List<MenuManagerInfo> GetSageMenuList(string UserName,int UserModuleID,int PortalID)
       {
           try
           {
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
               ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID",PortalID));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuManagerGetSageMenu]", ParamCollInput);
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
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuMgrSelectIsDefault]", ParamCollInput);
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
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuMgrGetMenuItem]", ParamCollInput);
           }
           catch (Exception)
           {
               
               throw;
           }
         
       }
       public static List<MenuManagerInfo> GetAllMenuItems(int UserModuleID,int PortalID)
       {
           try
           {
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuMgrLoadMenu]", ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }

       }

       public static List<MenuManagerInfo> GetSageMenu(int UserModuleID, int PortalID,string UserName)
       {
           try
           {
               SQLHandler SQLH = new SQLHandler();
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));
               return SQLH.ExecuteAsList<MenuManagerInfo>("[dbo].[usp_MenuMgrLoadSageMenuItems]", ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }

       }



       public static void AddNewMenu(List<MenuPermissionInfo> lstMenuPermissions, string MenuName, string MenuType, bool IsDefault, int PortalID)
       {
           string sp = "[dbo].[usp_MenuMgrAddNewMenu]";
           SQLHandler sagesql = new SQLHandler();
           int MenuID = 0;
           SqlTransaction tran = (SqlTransaction)sagesql.GetTransaction();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuName", MenuName));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuType", MenuType));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsDefault", IsDefault));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

               MenuID = sagesql.ExecuteNonQuery(sp, ParamCollInput, "@MenuID");

               foreach (MenuPermissionInfo menu in lstMenuPermissions)
               {
                   List<KeyValuePair<string, object>> ParamColl = new List<KeyValuePair<string, object>>();
                   ParamColl.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
                   ParamColl.Add(new KeyValuePair<string, object>("@PermissionID", menu.PermissionID));
                   ParamColl.Add(new KeyValuePair<string, object>("@AllowAccess", menu.AllowAccess));
                   ParamColl.Add(new KeyValuePair<string, object>("@RoleId", menu.RoleID == null ? Guid.Empty : new Guid(menu.RoleID)));
                   ParamColl.Add(new KeyValuePair<string, object>("@Username", menu.Username));
                   ParamColl.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                   sagesql.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[Usp_menumgraddmenupermission]", ParamColl);
               }

               tran.Commit();


           }
           catch (Exception)
           {

               throw;
           }
       }

       public static void AddSubText(int PageID, string SubText, bool IsActive, bool IsVisible)
       {
           string sp = "[dbo].[usp_MenuMgrAddSubText]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", PageID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@SubText", SubText));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsVisible", IsVisible));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }
       public static void DeleteMenu(int MenuID)
       {
           string sp = "[dbo].[usp_MenuMgrDeleteMenu]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }

       public static List<PageEntity> GetNormalPage(int PortalID, string UserName, string CultureCode)
       {
           List<PageEntity> lstPages = new List<PageEntity>();
           bool isAdmin = false;
           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAdmin", isAdmin));
           try
           {
               SQLHandler sagesql = new SQLHandler();
               lstPages = sagesql.ExecuteAsList<PageEntity>("[dbo].[usp_GetPages]", ParaMeterCollection);

               IEnumerable<PageEntity> lstParent = new List<PageEntity>();
               List<PageEntity> pageList = new List<PageEntity>();

               lstParent = isAdmin ? from pg in lstPages where pg.Level == 1 select pg : from pg in lstPages where pg.Level == 0 select pg;
               foreach (PageEntity parent in lstParent)
               {
                   pageList.Add(parent);
                   GetChildPages(ref pageList, parent, lstPages);
               }

               return pageList;
           }
           catch (Exception e)
           {
               throw e;
           }

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

       public static List<MenuManagerInfo> GetAdminPage(int PortalID, string UserName, string CultureCode)
       {
           List<MenuManagerInfo> lstPages = new List<MenuManagerInfo>();
           string StoredProcedureName = "[dbo].[usp_SageMenuGetAdminView]";
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
               lstPages.Add(new MenuManagerInfo(int.Parse(SQLReader["PageID"].ToString()), int.Parse(SQLReader["PageOrder"].ToString()), SQLReader["PageName"].ToString(), int.Parse(SQLReader["ParentID"].ToString()), int.Parse(SQLReader["Level"].ToString()), SQLReader["LevelPageName"].ToString(), SQLReader["SEOName"].ToString(), SQLReader["TabPath"].ToString(), bool.Parse(SQLReader["IsVisible"].ToString()), bool.Parse(SQLReader["ShowInMenu"].ToString())));
           }
           return lstPages;

       }

       
       public static void AddMenuItem(MenuManagerInfo MenuItems)
       {
           string sp = "[dbo].[usp_MenuMgrAddMenuItem]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuItems.MenuID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuItemID", MenuItems.MenuItemID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@LinkType",MenuItems.LinkType));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PageID", MenuItems.PageID));
              
               ParamCollInput.Add(new KeyValuePair<string, object>("@Title", MenuItems.Title));
               ParamCollInput.Add(new KeyValuePair<string, object>("@LinkURL", MenuItems.LinkURL));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ImageIcon", MenuItems.ImageIcon));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Caption", MenuItems.Caption));
               ParamCollInput.Add(new KeyValuePair<string, object>("@HtmlContent", MenuItems.HtmlContent));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID", MenuItems.ParentID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuLevel", MenuItems.MenuLevel));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuOrder",MenuItems.MenuOrder));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Mode", MenuItems.Mode));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PreservePageOrder", MenuItems.PreservePageOrder));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MainParent", MenuItems.MainParent));

               ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", MenuItems.IsActive));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsVisible", MenuItems.IsVisible));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       
       }

       public static void AddExternalLink(MenuManagerInfo MenuItems)
       {
           string sp = "[dbo].[usp_MenuMgrAddExternalLink]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuItems.MenuID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuItemID", MenuItems.MenuItemID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@LinkType",MenuItems.LinkType));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Title", MenuItems.Title));
               ParamCollInput.Add(new KeyValuePair<string, object>("@LinkURL", MenuItems.LinkURL));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ImageIcon", MenuItems.ImageIcon));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Caption", MenuItems.Caption));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID", MenuItems.ParentID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuLevel", MenuItems.MenuLevel));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsVisible", MenuItems.IsVisible));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", MenuItems.IsActive));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuOrder",MenuItems.MenuOrder));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Mode", MenuItems.Mode));
               
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       
       }

       public static void AddHtmlContent(MenuManagerInfo MenuItems)
       {
           string sp = "[dbo].[usp_MenuMgrAddHtmlContent]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuItems.MenuID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuItemID", MenuItems.MenuItemID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@LinkType",MenuItems.LinkType));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Title", MenuItems.Title));
               ParamCollInput.Add(new KeyValuePair<string, object>("@HtmlContent", MenuItems.HtmlContent));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ImageIcon", MenuItems.ImageIcon));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Caption", MenuItems.Caption));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID", MenuItems.ParentID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuLevel", MenuItems.MenuLevel));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsVisible", MenuItems.IsVisible));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Mode", MenuItems.Mode));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", MenuItems.IsActive));
               
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       
       }

       public static void SortMenu(int MenuItemID, int ParentID,int BeforeID, int AfterID, int PortalID)
       {
           string sp = "[dbo].[usp_MenuMgrSortMenu]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuItemID",MenuItemID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ParentID", ParentID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@BeforeID", BeforeID));

               ParamCollInput.Add(new KeyValuePair<string, object>("@AfterID",AfterID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID",PortalID));               

               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }

       }

       public static MenuManagerInfo GetMenuItemDetails(int MenuItemID)
       {
           List<MenuManagerInfo> lstPages = new List<MenuManagerInfo>();
           string StoredProcedureName = "[dbo].[usp_MenuMgrGetMenuItemDetails]";
           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@MenuItemID", MenuItemID));         
         
           try
           {
               SQLHandler sagesql = new SQLHandler();
               return(sagesql.ExecuteAsObject<MenuManagerInfo>(StoredProcedureName, ParaMeterCollection));
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       public static void AddSetting(List<MenuManagerInfo> objInfo)
       {
           foreach (MenuManagerInfo obj in objInfo)
           {
               List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@MenuID", obj.MenuID));
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", obj.SettingKey));
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingValue", obj.SettingValue));
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", obj.AddedBy));
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", obj.AddedBy));

               try
               {
                   SQLHandler sagesql = new SQLHandler();
                   sagesql.ExecuteNonQuery("[dbo].[usp_MenuMgrAddUpdSetting]", ParaMeterCollection);

               }
               catch (Exception)
               {

                   throw;
               }
           }

       }

       public static MenuManagerInfo GetMenuSetting(int PortalID, int MenuID)
       {
           MenuManagerInfo objSetting = new MenuManagerInfo();
           string StoredProcedureName = "[dbo].[usp_MenuMgrGetSetting]";
           SQLHandler sagesql = new SQLHandler();
           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
           try
           {
               objSetting = sagesql.ExecuteAsObject<MenuManagerInfo>(StoredProcedureName, ParaMeterCollection);

           }
           catch (Exception e)
           {
               throw e;
           }


           return objSetting;
       }
       public static List<MenuPermissionInfo> GetMenuPermission(int PortalID, int MenuID)
       {
         
           string StoredProcedureName = "[dbo].[usp_MenuMgrGetPermission]";
           SQLHandler sagesql = new SQLHandler();
           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
           try
           {
               return sagesql.ExecuteAsList<MenuPermissionInfo>(StoredProcedureName, ParaMeterCollection);

           }
           catch (Exception e)
           {
               throw e;
           }


           
       }
       public static void AddMenuPermission(List<MenuPermissionInfo> lstMenuPermissions,int MenuID, int PortalID)
       {
            

           SQLHandler sagesql = new SQLHandler();
           SqlTransaction tran = (SqlTransaction)sagesql.GetTransaction();
          

           try
           {
               string sp = "[dbo].[Usp_menumgrmenupermissiondelete]";      

           List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@MenuID",
                                                                                                           MenuID),
                                                                          new KeyValuePair<string, object>("@PortalID",
                                                                                                           PortalID)
                                                                      };

           sagesql.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp,
                               ParaMeterColl);


               foreach(MenuPermissionInfo menu in lstMenuPermissions)
               {
                   List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                   ParamCollInput.Add(new KeyValuePair<string, object>("@MenuID", MenuID));
                   ParamCollInput.Add(new KeyValuePair<string, object>("@PermissionID", menu.PermissionID));
                   ParamCollInput.Add(new KeyValuePair<string, object>("@AllowAccess", menu.AllowAccess));
                   ParamCollInput.Add(new KeyValuePair<string, object>("@RoleId", menu.RoleID==null?Guid.Empty:new Guid(menu.RoleID)));
                   ParamCollInput.Add(new KeyValuePair<string, object>("@Username", menu.Username));
                   ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                   sagesql.ExecuteNonQuery(tran, CommandType.StoredProcedure,"[dbo].[Usp_menumgraddmenupermission]",ParamCollInput);
               }
               
               tran.Commit();
           }
           catch (Exception)
           {
               tran.Rollback();
               throw;
           }
       }


       public static void DeleteLink(int MenuItemID)
       {
           string sp = "[dbo].[usp_MenuMgrDeleteLink]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@MenuItemID", MenuItemID));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }

       public static void UpdateSageMenuSelected(int UserModuleID,int PortalID,string SettingKey,string SettingValue)
       {
           string sp = "[dbo].[usp_SageMenuUpdateSelectedMenu]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@SettingKey", SettingKey));
               ParamCollInput.Add(new KeyValuePair<string, object>("@SettingValue", SettingValue));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }
       public static List<SitemapInfo> GetSiteMapPages(string UserName, string CultureCode)
       {
           List<SitemapInfo> lstPages = new List<SitemapInfo>();
           try
           {
               SQLHandler sagesql = new SQLHandler();
               lstPages = sagesql.ExecuteAsList<SitemapInfo>("[dbo].[usp_SEOGetPages]");

               return lstPages;
           }
           catch (Exception e)
           {
               throw e;
           }

       }

       

    }

}
