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
using SageFrame.Common;
using System.Data.SqlClient;

namespace SageFrame.Modules
{
    public class ModuleProvider
    {

       /// <summary>
       /// AddModules
       /// </summary>
       /// <param name="objList"></param>
       /// <param name="isAdmin"></param>
       /// <param name="PackageID"></param>
       /// <param name="IsActive"></param>
       /// <param name="AddedOn"></param>
       /// <param name="PortalID"></param>
       /// <param name="AddedBy"></param>
       /// <returns></returns>
       
        public static int[] AddModules(ModuleInfo objList,bool isAdmin, int PackageID,bool IsActive,DateTime AddedOn,int PortalID,string AddedBy)
        {
            string sp = "[dbo].[sp_ModulesAdd]";
            //SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleName", objList.ModuleName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", objList.Name));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FriendlyName", objList.FriendlyName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Description", objList.Description));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FolderName", objList.FolderName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Version", objList.Version));

                ParamCollInput.Add(new KeyValuePair<string, object>("@isPremium", objList.isPremium));
                ParamCollInput.Add(new KeyValuePair<string, object>("@isAdmin",isAdmin));


                ParamCollInput.Add(new KeyValuePair<string, object>("@Owner", objList.Owner));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Organization", objList.Organization));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", objList.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Email", objList.Email));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ReleaseNotes", objList.ReleaseNotes));
                ParamCollInput.Add(new KeyValuePair<string, object>("@License", objList.License));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PackageType", objList.PackageType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@supportedFeatures", objList.supportedFeatures));
                ParamCollInput.Add(new KeyValuePair<string, object>("@BusinessControllerClass", objList.BusinessControllerClass));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CompatibleVersions", objList.CompatibleVersions));
                ParamCollInput.Add(new KeyValuePair<string, object>("@dependencies", objList.dependencies));
                ParamCollInput.Add(new KeyValuePair<string, object>("@permissions", objList.permissions));

                ParamCollInput.Add(new KeyValuePair<string, object>("@PackageID", PackageID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));



                List<KeyValuePair<string, object>> ParamCollOutput = new List<KeyValuePair<string, object>>();
                ParamCollOutput.Add(new KeyValuePair<string, object>("@ModuleID", objList.ModuleID));
                ParamCollOutput.Add(new KeyValuePair<string, object>("@ModuleDefID", objList.ModuleDefID));

                SageFrameSQLHelper sagesql = new SageFrameSQLHelper();

                List<KeyValuePair<int, string>> OutputValColl = new List<KeyValuePair<int, string>>();
                OutputValColl = sagesql.ExecuteNonQueryWithMultipleOutput(sp, ParamCollInput, ParamCollOutput);
                int[] arrOutPutValue = new int[2];
                arrOutPutValue[0] = int.Parse(OutputValColl[0].Value);
                arrOutPutValue[1] = int.Parse(OutputValColl[1].Value);

                return arrOutPutValue;
              
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// AddPortalModules
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="ModuleID"></param>
        /// <param name="IsActive"></param>
        /// <param name="AddedOn"></param>
        /// <param name="AddedBy"></param>
        /// <returns></returns>
        public static int AddPortalModules(int? PortalID, int? ModuleID, bool IsActive, DateTime AddedOn, string AddedBy)
        {
           
            string sp = "[dbo].[sp_PortalModulesAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", ModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
             
                int pmID = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@PortalModuleID");
                return pmID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// GetPermissionByCodeAndKey
        /// </summary>
        /// <param name="PermissionCode"></param>
        /// <param name="PermissionKey"></param>
        /// <returns></returns>
        public static int GetPermissionByCodeAndKey(string PermissionCode, string PermissionKey)
        {

            string sp = "[dbo].[sp_GetPermissionByCodeAndKey]";
            SQLHandler SQLH = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PermissionCode", PermissionCode));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PermissionKey", PermissionKey));

                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                int PermissionID = 0;

                while (reader.Read())
                {
                    PermissionID = int.Parse( reader["PermissionID"].ToString());

                }
                return PermissionID;
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// AddModulePermission
        /// </summary>
        /// <param name="ModuleDefID"></param>
        /// <param name="PermissionID"></param>
        /// <param name="PortalID"></param>
        /// <param name="PortalModuleID"></param>
        /// <param name="AllowAccess"></param>
        /// <param name="Username"></param>
        /// <param name="IsActive"></param>
        /// <param name="AddedOn"></param>
        /// <param name="AddedBy"></param>
        /// <returns></returns>
        public static int[] AddModulePermission(int? ModuleDefID, int? PermissionID, int? PortalID, int? PortalModuleID, bool AllowAccess, string Username, bool IsActive, DateTime AddedOn, string AddedBy)
        {
    
           
            string sp = "[dbo].[sp_ModulesPermissionAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PermissionID", PermissionID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalModuleID", PortalModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AllowAccess", AllowAccess));

                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

                //int ListID = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@ModuleDefPermissionID");
                //return ListID;

                ModuleInfo objInfo= new ModuleInfo();
                List<KeyValuePair<string, object>> ParamCollOutput = new List<KeyValuePair<string, object>>();
                ParamCollOutput.Add(new KeyValuePair<string, object>("@ModuleDefPermissionID", objInfo.ModuleDefPermissionID));
                ParamCollOutput.Add(new KeyValuePair<string, object>("@PortalModulePermissionID", objInfo.PortalModulePermissionID));

                SageFrameSQLHelper objHelper = new SageFrameSQLHelper();

                List<KeyValuePair<int, string>> OutputValColl = new List<KeyValuePair<int, string>>();
                OutputValColl = objHelper.ExecuteNonQueryWithMultipleOutput(sp, ParamCollInput, ParamCollOutput);
                int[] arrOutPutValue = new int[2];
                arrOutPutValue[0] = int.Parse(OutputValColl[0].Value);
                arrOutPutValue[1] = int.Parse(OutputValColl[1].Value);

                return arrOutPutValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int AddModuleCoontrols(int? ModuleDefID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {

            string sp = "[dbo].[sp_ModuleControlsAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlKey", ControlKey));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlTitle", ControlTitle));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlSrc", ControlSrc));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IconFile", IconFile));

                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlType", ControlType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", DisplayOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@HelpUrl", HelpUrl));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SupportsPartialRendering", SupportsPartialRendering));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));

                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));


                int MCID = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@ModuleControlID");
                return MCID;


            }
            catch (Exception)
            {

                throw;
            }
        }
        // [dbo].[sp_ModuleControlsUpdate]
        public static void UpdateModuleCoontrols(int ModuleControlID, string ControlKey, string ControlTitle, string ControlSrc, string IconFile, int ControlType, int DisplayOrder, string HelpUrl, bool SupportsPartialRendering, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {

            string sp = "[dbo].[sp_ModuleControlsUpdate]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleControlID", ModuleControlID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlKey", ControlKey));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlTitle", ControlTitle));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlSrc", ControlSrc));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IconFile", IconFile));

                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlType", ControlType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DisplayOrder", DisplayOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@HelpUrl", HelpUrl));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SupportsPartialRendering", SupportsPartialRendering));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsModified", IsModified));

                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));


                sagesql.ExecuteNonQuery(sp, ParamCollInput);



            }
            catch (Exception)
            {

                throw;
            }
        }
        //sp_ExtensionUpdate
        public static void UpdateExtension(ModuleInfo objInfo)
        {
            string sp = "[dbo].[sp_ExtensionUpdate]";
            SQLHandler sagesql = new SQLHandler();
            try
            {

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID",objInfo.ModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FolderName", objInfo.FolderName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@BusinessControllerClass",objInfo.BusinessControllerClass));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Dependencies", objInfo.dependencies));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Permissions", objInfo.permissions));

                ParamCollInput.Add(new KeyValuePair<string, object>("@IsPortable", objInfo.IsPortable));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsSearchable", objInfo.IsSearchable));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsUpgradable", objInfo.IsUpgradable));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsPremium", objInfo.isPremium));


                ParamCollInput.Add(new KeyValuePair<string, object>("@PackageName", objInfo.PackageName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PackageDescription", objInfo.PackageDescription));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Version", objInfo.Version));
                ParamCollInput.Add(new KeyValuePair<string, object>("@License", objInfo.License));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ReleaseNotes", objInfo.ReleaseNotes));

                ParamCollInput.Add(new KeyValuePair<string, object>("@Owner", objInfo.Owner));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Organization", objInfo.Organization));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Url", objInfo.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Email", objInfo.Email));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", objInfo.PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", objInfo.Username));
               

                 sagesql.ExecuteNonQuery(sp, ParamCollInput);
                


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
     
        public static void DeletePackagesByModuleID(int PortalID, int ModuleID)
        {
            string sp = "[dbo].[sp_ModulesRollBack]";
            SQLHandler sagesql = new SQLHandler();
            try
            {

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", ModuleID));              
             
                sagesql.ExecuteNonQuery(sp, ParamCollInput);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //var LINQModule = db.usp_ModuleGetAllExisting();
        public static List<ModuleInfo> GetAllExistingModule()
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                return SQLH.ExecuteAsList<ModuleInfo>("[dbo].[usp_ModuleGetAllExisting]");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //sp_ModuleControlsGetByModuleControlID
        public static ModuleEntities ModuleControlsGetByModuleControlID(int ModuleControlID)
        {
            try
            {
                string sp = "[dbo].[sp_ModuleControlsGetByModuleControlID]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleControlID", ModuleControlID));

                return SQLH.ExecuteAsObject<ModuleEntities>(sp, ParamCollInput);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //[dbo].[sp_CheckUnquieModuleControlsControlType] 
        public static int CheckUnquieModuleControlsControlType(int ModuleControlID, int ModuleDefID, int ControlType, int PortalID, bool isEdit)
        {

            string sp = "[dbo].[sp_CheckUnquieModuleControlsControlType]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleControlID", ModuleControlID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ControlType", ControlType));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@isEdit", isEdit));
                int Count = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@Count");
                return Count;

            }
            catch (Exception)
            {
                throw;
            }
        }
        //sp_ModuleControlsDeleteByModuleControlID
        public static void ModuleControlsDeleteByModuleControlID(int ModuleControlID, string DeletedBy)
        {
            try
            {
                string sp = "[dbo].[sp_ModuleControlsDeleteByModuleControlID]";
                SQLHandler sagesql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleControlID", ModuleControlID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", DeletedBy));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public static void UpdateModuleDefinitions(int ModuleDefID, string FriendlyName, int DefaultCacheTime, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            string sp = "sp_ModuleDefinitionsUpdate";
            SQLHandler SQLH = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@FriendlyName", FriendlyName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DefaultCacheTime", DefaultCacheTime));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsModified", IsModified));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                SQLH.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static ModuleInfo GetModuleInformationByModuleID(int ModuleID)
        {
            try
            {
                string sp = "[dbo].[sp_ModuleGetByModuleID]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@ModuleID", ModuleID));

                return SQLH.ExecuteAsObject<ModuleInfo>(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
