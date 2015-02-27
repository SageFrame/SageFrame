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
using SageFrame.ModuleManager;
using System.Data;
using SageFrame.Common;

namespace SageFrame.ModuleManager.DataProvider
{
    public class ModuleDataProvider
    {
        public string AddUserModule(UserModuleInfo module)
        {
            SageFrameSQLHelper sqlH = new SageFrameSQLHelper();
            SqlTransaction tran = (SqlTransaction)sqlH.GetTransaction();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {                                                                              
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ModuleDefID", module.ModuleDefID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@UserModuleTitle", module.UserModuleTitle),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AllPages", module.AllPages),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ShowInPages", module.ShowInPages),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@InheritViewPermissions", module.InheritViewPermissions),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsActive", module.IsActive),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedOn", DateTime.Now),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PortalID", module.PortalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedBy", module.PortalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@SEOName", module.SEOName),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@IsHandheld",module.IsHandheld),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@SuffixClass",module.SuffixClass),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@HeaderText",module.HeaderText),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@ShowHeaderText",module.ShowHeaderText),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@IsInAdmin",module.IsInAdmin) 
                                                                            };

                List<KeyValuePair<string, object>> ParaMeterInputCollection = new List<KeyValuePair<string, object>>
                                                                            {                                                                              
                                                                                new KeyValuePair<string, object>(
                                                                                    "@UserModuleID", 0),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ControlCount", 0)                                                                                
                                                                            };
               
              
                List<KeyValuePair<int, string>> resultColl = new List<KeyValuePair<int, string>>();
                resultColl = sqlH.ExecuteNonQueryWithMultipleOutput(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesAdd]", ParaMeterCollection, ParaMeterInputCollection);
                if (int.Parse(resultColl[0].Value) > 0)
                {
                    if (module.InheritViewPermissions)
                    {
                        SetUserModuleInheritedPermission(module.PageID, tran, int.Parse(resultColl[0].Value), module.PortalID, module.AddedBy, module.ModuleDefID);
                    }
                    else
                    {
                        SetUserModulePermission(module.LSTUserModulePermission, tran, int.Parse(resultColl[0].Value), module.PortalID, module.AddedBy, module.ModuleDefID);
                    }
                    SetPageModules(module, tran, int.Parse(resultColl[0].Value), module.PortalID, module.AddedBy);

                }
                tran.Commit();
                return (string.Format("{0}_{1}", resultColl[0].Value.ToString(), resultColl[1].Value.ToString())); 

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

        public void SetUserModulePermission(List<ModulePermissionInfo> lstPermission, SqlTransaction tran, int UserModuleID, int PortalID, string AddedBy,int ModuleDefID)
        {
            try
            {
              
                foreach (ModulePermissionInfo objPerm in lstPermission)
                {
                    if (objPerm == null) continue;
                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleDefID", ModuleDefID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID",UserModuleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AllowAccess",objPerm.AllowAccess),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@RoleID", objPerm.RoleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Username", objPerm.UserName),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", true),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedOn", DateTime.Now),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID", PortalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", AddedBy),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PermissionID", objPerm.PermissionID)
                                                                                };
                    SQLHandler sqlH = new SQLHandler();
                    sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesPermissionAdd]",
                                         ParaMeterCollection);
                    
                }
        
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SetUserModuleInheritedPermission(int PageID, SqlTransaction tran, int UserModuleID, int PortalID, string AddedBy, int ModuleDefID)
        {
            try
            {

                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleDefID", ModuleDefID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID",UserModuleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AllowAccess",true),                                                                                   
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", true),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedOn", DateTime.Now),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID", PortalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", AddedBy),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PageID", PageID)
                                                                                };
                    SQLHandler sqlH = new SQLHandler();
                    sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesInheritedPermissionAdd]",
                                         ParaMeterCollection);

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void UpdateUserModuleInheritedPermission(int PageID, SqlTransaction tran, int UserModuleID, int PortalID, string AddedBy, int ModuleDefID)
        {
            try
            {

                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleDefID", ModuleDefID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID",UserModuleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AllowAccess",true),                                                                                   
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", true),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedOn", DateTime.Now),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID", PortalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", AddedBy),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PageID", PageID)
                                                                                };
                SQLHandler sqlH = new SQLHandler();
                sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesInheritedPermissionAdd]",
                                     ParaMeterCollection);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SetPageModules(UserModuleInfo module, SqlTransaction tran, int UserModuleID, int PortalID, string AddedBy)
        {

            try
            {

                
                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PageID", module.PageID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID",UserModuleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PaneName",module.PaneName),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleOrder", module.ModuleOrder),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@CacheTime",module.CacheTime),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Alignment", module.Alignment),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Color", module.Color),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Border", ""),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IconFile", "none"),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Visibility", true),                                                                                       
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", true),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedOn", DateTime.Now),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID",PortalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", AddedBy)

                                                                                };
                    SQLHandler sqlH = new SQLHandler();
                    sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_PageModulesAdd]",
                                         ParaMeterCollection);
             
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<UserModuleInfo> GetPageModules(int PageID, int PortalID,bool IsHandheld)
        {
            List<UserModuleInfo> lstUserModules = new List<UserModuleInfo>();
            string StoredProcedureName = "[dbo].[usp_ModuleManagerGetPageModules]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                         {
                                                                             new KeyValuePair<string, object>(
                                                                                 "@PageID", PageID),
                                                                             new KeyValuePair<string, object>(
                                                                                 "@PortalID", PortalID),
                                                                             new KeyValuePair<string, object>(
                                                                                 "@IsHandheld", IsHandheld),
                                                                         };
            try
            {
                SQLHandler sagesql = new SQLHandler();
                lstUserModules = sagesql.ExecuteAsList<UserModuleInfo>(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }


            return lstUserModules;
        }


        public static void DeleteUserModule(int UserModuleID, int PortalID, string DeletedBy)
        {
            List<UserModuleInfo> lstUserModules = new List<UserModuleInfo>();
            string StoredProcedureName = "[dbo].[usp_UserModulesDelete]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                         {
                                                                             new KeyValuePair<string, object>(
                                                                                 "@UserModuleID", UserModuleID),
                                                                             new KeyValuePair<string, object>(
                                                                                 "@PortalID", PortalID),
                                                                             new KeyValuePair<string, object>(
                                                                                 "@DeletedBy", DeletedBy)
                                                                         };

            try
            {
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void UpdatePageModule(List<PageModuleInfo> lstPageModules)
        {

            string StoredProcedureName = "[dbo].[usp_PageModule_Update]";
            foreach (PageModuleInfo pm in lstPageModules)
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID", pm.UserModuleID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PaneName",pm.PaneName),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleOrder",pm.ModuleOrder)
                                                                                };

                try
                {
                    SQLHandler sagesql = new SQLHandler();
                    sagesql.ExecuteNonQuery(StoredProcedureName, ParaMeterCollection);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public static List<UserModuleInfo> GetPageUserModules(bool IsAdmin)
        {
            List<UserModuleInfo> lstUserModules = new List<UserModuleInfo>();
            string StoredProcedureName = "[dbo].[usp_usermodulesgetpagemodules]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsAdmin", IsAdmin)                                                                               
                                                                                    
                                                                                };          
            try
            {
                SQLHandler sagesql = new SQLHandler();
                lstUserModules = sagesql.ExecuteAsList<UserModuleInfo>(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }


            return lstUserModules;
        }

        public static UserModuleInfo GetUserModuleDetails(int UserModuleID, int PortalID)
        {
            UserModuleInfo objUserModule = new UserModuleInfo();
            string StoredProcedureName = "[dbo].[usp_UserModulesGetDetails]";
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID", UserModuleID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID",PortalID)
                                                                                };
           
            try
            {
                SQLHandler sagesql = new SQLHandler();
                objUserModule = sagesql.ExecuteAsObject<UserModuleInfo>(StoredProcedureName, ParaMeterCollection);
                objUserModule.LSTUserModulePermission = GetModulePermission(UserModuleID, PortalID);

            }
            catch (Exception e)
            {
                throw e;
            }


            return objUserModule;
        }

        public static List<ModulePermissionInfo> GetModulePermission(int UserModuleID,int PortalID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@UserModuleID",
                                                                                                             UserModuleID),
                                                                            new KeyValuePair<string, object>(
                                                                                "@PortalID", PortalID)
                                                                        };
            SQLHandler sqlH = new SQLHandler();
            return (sqlH.ExecuteAsList<ModulePermissionInfo>("[usp_UserModuleGetPermissions]", ParaMeterCollection));

           
        }


        public static void UpdateUserModule(UserModuleInfo module)
        {
            SQLHandler sqlH = new SQLHandler();
            SqlTransaction tran = (SqlTransaction)sqlH.GetTransaction();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                            {
                                                                               new KeyValuePair<string, object>(
                                                                                    "@UserModuleID", module.UserModuleID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ModuleDefID", module.ModuleDefID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@UserModuleTitle", module.UserModuleTitle),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AllPages", module.AllPages),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@ShowInPages", module.ShowInPages),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@InheritViewPermissions", module.InheritViewPermissions),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@IsActive", module.IsActive),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedOn", DateTime.Now),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@PortalID", module.PortalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@AddedBy", module.PortalID),
                                                                                new KeyValuePair<string, object>(
                                                                                    "@SEOName", module.SEOName),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@IsHandheld",module.IsHandheld),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@SuffixClass",module.SuffixClass),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@HeaderText",module.HeaderText),
                                                                                new KeyValuePair<string,object>(
                                                                                    "@ShowHeaderText",module.ShowHeaderText) 
                                                                                    
                                                                            };

                
                sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesUpdate]", ParaMeterCollection);
                if (module.InheritViewPermissions)
                {
                    UpdateUserModuleInheritedPermission(module.PageID, tran, module.UserModuleID, module.PortalID, module.AddedBy, module.ModuleDefID);

                }
                else
                {
                    UpdateUserModulePermission(module.LSTUserModulePermission, tran, module.UserModuleID, module.PortalID, module.AddedBy, module.ModuleDefID);                  

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

        public static void UpdateUserModulePermission(List<ModulePermissionInfo> lstPermission, SqlTransaction tran, int UserModuleID, int PortalID, string AddedBy, int ModuleDefID)
        {


            try
            {
                SQLHandler sqlH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamColl = new List<KeyValuePair<string, object>>
                                                                        {
                                                                            new KeyValuePair<string, object>("@UserModuleID",
                                                                                                             UserModuleID),
                                                                            new KeyValuePair<string, object>(
                                                                                "@PortalID", PortalID)
                                                                        };
                sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulePermissionDelete]",
                                        ParamColl);


                foreach (ModulePermissionInfo objPerm in lstPermission)
                {
                    if (objPerm == null) continue;
                    List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>
                                                                                {
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@ModuleDefID", ModuleDefID),                                                                                 
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@UserModuleID",UserModuleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AllowAccess",objPerm.AllowAccess),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@RoleID", objPerm.RoleID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@Username", objPerm.UserName),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@IsActive", true),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedOn", DateTime.Now),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@PortalID", PortalID),
                                                                                    new KeyValuePair<string, object>(
                                                                                        "@AddedBy", AddedBy),
                                                                                         new KeyValuePair<string, object>(
                                                                                        "@PermissionID", objPerm.PermissionID)
                                                                                };

                    sqlH.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[dbo].[usp_UserModulesPermissionAdd]",
                                         ParaMeterCollection);

                }
            }
            catch (Exception)
            {

                throw;
            }

              
              

        }

    }
}
