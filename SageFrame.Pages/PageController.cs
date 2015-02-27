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
using SageFrame.PagePermission;
using System.Data.SqlClient;
using SageFrame.Web.Utilities;
using System.Data;

namespace SageFrame.Pages
{
    public class PageController
    {
        
        public static List<PageEntity> GetMenuFront(int PortalID, bool isAdmin)
        {
            List<PageEntity> lstPages = new List<PageEntity>();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAdmin", isAdmin));
            try
            {
                SQLHandler sagesql = new SQLHandler();
                lstPages = sagesql.ExecuteAsList<PageEntity>("[dbo].[usp_GetPages]", ParaMeterCollection);

                IEnumerable<PageEntity> lstParent = new List<PageEntity>();
                List<PageEntity> pageList = new List<PageEntity>();

                lstParent = isAdmin?from pg in lstPages where pg.Level == 1 select pg:from pg in lstPages where pg.Level == 0 select pg;
                foreach (PageEntity parent in lstParent)
                {
                    parent.PageName = parent.PageName.Replace(" ", "-");
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
        public void AddUpdatePages(PageEntity objPage)
        {
            objPage.PortalID = objPage.PortalID == -1 ? 1 : objPage.PortalID;
            SQLHandler sqlH = new SQLHandler();
            SqlTransaction tran = (SqlTransaction)sqlH.GetTransaction();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageID", objPage.PageID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageOrder", objPage.PageOrder),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageName", objPage.PageName.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsVisible", objPage.IsVisible),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ParentID", objPage.ParentID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IconFile", objPage.IconFile.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@DisableLink", objPage.DisableLink),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@Title", objPage.Title.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@Description", objPage.Description.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@KeyWords", objPage.KeyWords.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@Url", objPage.Url.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@StartDate", objPage.StartDate.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@EndDate", objPage.EndDate.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@RefreshInterval",
                                                                                    objPage.RefreshInterval),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageHeadText",
                                                                                    objPage.PageHeadText.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsSecure", objPage.IsSecure),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsActive", objPage.IsActive),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsShowInFooter",
                                                                                    objPage.IsShowInFooter),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsRequiredPage",
                                                                                    objPage.IsRequiredPage),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@BeforeID", objPage.BeforeID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AfterID", objPage.AfterID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PortalID", objPage.PortalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedBy", objPage.AddedBy.ToString()),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsAdmin", objPage.IsAdmin), 
                                                                            };
                int pageID = 0;
                pageID = sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "sp_AddUpdatePage", ParaMeterCollection, "@InsertedPageID");
                if (pageID > 0)
                {
                    AddUpdatePagePermission(objPage.LstPagePermission, tran, pageID, objPage.PortalID, objPage.AddedBy);
                    if (objPage.Mode == "A")
                    {
                        MenuPageUpdate(objPage.MenuList, tran, pageID);
                    }
                    AddUpdateSelectedMenu(objPage.MenuList, tran, pageID, objPage.ParentID, objPage.Mode, objPage.Caption,objPage.PortalID,objPage.UpdateLabel);
                }



                tran.Commit();

            }
            catch (SqlException sqlEx)
            {
                tran.Rollback();
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<PageEntity> GetPages(int PortalID, bool isAdmin)
        {
            List<PageEntity> lstPages = new List<PageEntity>();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAdmin", isAdmin));
            try
            {
                SQLHandler sagesql = new SQLHandler();
                lstPages = sagesql.ExecuteAsList<PageEntity>("[dbo].[usp_GetPages]", ParaMeterCollection);

                IEnumerable<PageEntity> lstParent = new List<PageEntity>();
                List<PageEntity> pageList = new List<PageEntity>();

                lstParent = (from pg in lstPages where pg.Level == 0 select pg);
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

       

        public void AddUpdatePagePermission(List<PagePermissionInfo> lstPPI, SqlTransaction tran, int pageID, int portalID, string addedBy)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@PageID",
                                                                                                           pageID),
                                                                          new KeyValuePair<string, object>("@PortalID",
                                                                                                           portalID)
                                                                      };
                SQLHandler sql = new SQLHandler();
                sql.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[sp_PagePermissionDeleteByPageID]",
                                    ParaMeterColl);

                foreach (PagePermissionInfo objPagePI in lstPPI)
                {
                    if (objPagePI == null) continue;
                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PageID", pageID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@RoleID", objPagePI.RoleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PermissionID",
                                                                                        objPagePI.PermissionID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AllowAccess",
                                                                                        objPagePI.AllowAccess),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Username", objPagePI.Username),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", objPagePI.IsActive),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID", portalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", addedBy)
                                                                                };
                    SQLHandler sqlH = new SQLHandler();
                    sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[sp_AddPagePermission]",
                                         ParaMeterCollection);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AddUpdateSelectedMenu(string SelectedMenu, SqlTransaction tran, int pageID, int ParentID, string Mode, string Caption, int PortalID, string UpdateLabel)
        {
            try
            {
                string[] menuArr = SelectedMenu.Split(',');
                foreach (string menu in menuArr)
                {
                   
                        List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@MenuID",
                                                                                                           menu),
                                                                          new KeyValuePair<string, object>("@MenuIDs",
                                                                                                           SelectedMenu),
                                                                                                           new KeyValuePair<string, object>("@Mode",
                                                                                                           Mode),
                                                                          new KeyValuePair<string, object>("@PageID",
                                                                                                           pageID),
                                                                          new KeyValuePair<string, object>("@ParentID",
                                                                                                           ParentID),
                                                                        new KeyValuePair<string, object>("@caption",
                                                                                                           Caption),
                                                                        new KeyValuePair<string, object>("@UpdateLabel",
                                                                                                           UpdateLabel)
                                                                        
                                                                      };
                        SQLHandler sqlH = new SQLHandler();
                        sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_PageManagerAddPageToMenu]",
                                            ParaMeterColl);
                    
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void MenuPageUpdate(string MenuIDs, SqlTransaction tran, int pageID)
        {
            try
            {
                string[] menuArr = MenuIDs.Split(',');

                List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@MenuIDs",
                                                                                                           MenuIDs),
                                                                          new KeyValuePair<string, object>("@PageID",
                                                                                                           pageID)
                                                                      };
                SQLHandler sqlH = new SQLHandler();
                sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_PageManagerMenuPageUpdate]",
                                    ParaMeterColl);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public PageEntity GetPageDetails(int pageID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageID", pageID)
                                                                            };
                SQLHandler sqlH = new SQLHandler();
                PageEntity objPE = sqlH.ExecuteAsObject<PageEntity>("[dbo].[sp_PagesGetByPageID]", ParaMeterCollection);
                objPE.PortalID = objPE.PortalID == -1 ? 1 : objPE.PortalID;
                objPE.LstPagePermission = GetPagePermissionDetails(objPE);
                return objPE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PagePermissionInfo> GetPagePermissionDetails(PageEntity obj)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@PageID",
                                                                                                             obj.PageID),
                                                                            new KeyValuePair<string, object>(
                                                                                "@portalID", obj.PortalID)
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            List<PagePermissionInfo> lst = new List<PagePermissionInfo>();
            SqlDataReader reader = sqlH.ExecuteAsDataReader("sp_GetPagePermissionByPageID", ParaMeterCollection);

            while (reader.Read())
            {
                PagePermissionInfo objPP = new PagePermissionInfo
                {
                    PageID = int.Parse(reader["PageID"].ToString()),
                    PermissionID =
                        int.Parse(reader["PermissionID"].ToString()),
                    RoleID =
                        reader["RoleID"] == DBNull.Value
                            ? ""
                            : reader["RoleID"].ToString(),
                    Username =
                        reader["Username"] == DBNull.Value
                            ? ""
                            : reader["Username"].ToString(),
                    IsActive =
                        bool.Parse(reader["IsActive"].ToString()),
                    AllowAccess =
                        bool.Parse(reader["AllowAccess"].ToString()),
                    AddedBy = reader["AddedBy"].ToString()
                };
                lst.Add(objPP);
            }
            return lst;
        }

        public List<PageEntity> GetChildPage(int parentID, bool? isActive, bool? isVisiable, bool? isRequiredPage, string userName, int portalID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@ParentID",
                                                                            parentID),
                                                                             new KeyValuePair<string, object>("@IsActive",
                                                                            isActive),
                                                                             new KeyValuePair<string, object>("@IsVisible",
                                                                            isVisiable),
                                                                             new KeyValuePair<string, object>("@IsRequiredPage",
                                                                            isRequiredPage),
                                                                             new KeyValuePair<string, object>("@Username",
                                                                            userName),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            portalID)
                                                                          
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            return sqlH.ExecuteAsList<PageEntity>("[dbo].[sp_PageGetByParentID]", ParaMeterCollection);

        }

        public List<PageModuleInfo> GetPageModules(int pageID, int portalID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {                                                                          
                                                                             new KeyValuePair<string, object>("@PageID",
                                                                            pageID),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            portalID)                                                                          
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            return sqlH.ExecuteAsList<PageModuleInfo>("[dbo].[usp_GetPageModulesByPageID]", ParaMeterCollection);

        }

        public void DeletePageModule(int moduleID, string deletedBY, int portalID)
        {
            List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@ModuleID",
                                                                                                           moduleID),
                                                                             new KeyValuePair<string, object>("@DeletedBy",
                                                                            deletedBY),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            portalID)                                                                        
                                                                      };
            SQLHandler sql = new SQLHandler();
            sql.ExecuteNonQuery("[dbo].[sp_ModulesDelete]", ParaMeterColl);

        }


        public void DeleteChildPage(int pageID, string deletedBY, int portalID)
        {
            List<KeyValuePair<string, object>> ParaMeterColl = new List<KeyValuePair<string, object>>
                                                                      {
                                                                          new KeyValuePair<string, object>("@PageID",
                                                                                                           pageID),
                                                                             new KeyValuePair<string, object>("@DeletedBy",
                                                                            deletedBY),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            portalID)                                                                        
                                                                      };
            SQLHandler sql = new SQLHandler();
            sql.ExecuteNonQuery("[dbo].[sp_PagesDelete]", ParaMeterColl);

        }

        public void UpdatePageAsContextMenu(int pageID, bool? isVisiable, bool? isPublished, int portalID, string userName, string updateFor)
        {
            SQLHandler sqlH = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageID", pageID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsVisible", isVisiable),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsPublish", isPublished),
                                                                                new KeyValuePair<string, object>( 
                                                                                    "@PortalID", portalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedBy", userName),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@updateFor", updateFor)                                                                                 
                                                                            };

                sqlH.ExecuteNonQuery("[dbo].[sp_UpdatePageAsContextMenu]", ParaMeterCollection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SortFrontEndMenu(int pageID, int parentID, string pageName, int BeforeID, int AfterID, int portalID, string userName)
        {
            SQLHandler sqlH = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageID", pageID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ParentID", parentID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageName", pageName),                                                                                                                                                      
                                                                                new KeyValuePair<string, object>(
                                                                                    "@BeforeID", BeforeID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AfterID", AfterID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PortalID", portalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedBy", userName)
                                                                            };

                sqlH.ExecuteNonQuery("[dbo].[usp_SortPages]", ParaMeterCollection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SortAdminPages(List<PageEntity> lstPages)
        {
            SQLHandler sqlH = new SQLHandler();

            try
            {
                foreach (PageEntity obj in lstPages)
                {
                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageID", obj.PageID),                                                                                                                                                                                                                                   
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PageOrder", obj.PageOrder),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PortalID", obj.PortalID)
                                                                            };
                    sqlH.ExecuteNonQuery("[dbo].[usp_SortAdminPages]", ParaMeterCollection);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PageEntity> GetPortalPages(int PortalID, string UserName, string prefix, bool IsActive, bool IsDeleted, object IsVisible, object IsRequiredPage)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@prefix",
                                                                            prefix),
                                                                             new KeyValuePair<string, object>("@IsActive",
                                                                            IsActive),
                                                                             new KeyValuePair<string, object>("@IsDeleted",
                                                                            IsDeleted),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            PortalID),
                                                                             new KeyValuePair<string, object>("@Username",
                                                                            UserName),
                                                                             new KeyValuePair<string, object>("@IsVisible",
                                                                            IsVisible),
                                                                            new KeyValuePair<string, object>("@IsRequiredPage",
                                                                            IsRequiredPage)
                                                                          
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            return sqlH.ExecuteAsList<PageEntity>("[dbo].[sp_PagePortalGetByCustomPrefix]", ParaMeterCollection);

        }
        public static List<PageEntity> GetActivePortalPages(int PortalID, string UserName, string prefix, bool IsActive, bool IsDeleted, object IsVisible, object IsRequiredPage)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@prefix",
                                                                            prefix),
                                                                             new KeyValuePair<string, object>("@IsActive",
                                                                            IsActive),
                                                                             new KeyValuePair<string, object>("@IsDeleted",
                                                                            IsDeleted),
                                                                             new KeyValuePair<string, object>("@PortalID",
                                                                            PortalID),
                                                                             new KeyValuePair<string, object>("@Username",
                                                                            UserName),
                                                                             new KeyValuePair<string, object>("@IsVisible",
                                                                            IsVisible),
                                                                            new KeyValuePair<string, object>("@IsRequiredPage",
                                                                            IsRequiredPage)
                                                                          
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            return sqlH.ExecuteAsList<PageEntity>("[dbo].[usp_PagePortalGetByCustomPrefix]", ParaMeterCollection);

        }
    }
}
