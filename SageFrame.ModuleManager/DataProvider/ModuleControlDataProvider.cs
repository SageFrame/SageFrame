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
using SageFrame.Web.Utilities;
#endregion

namespace SageFrame.ModuleControls
{
    public class ModuleControlDataProvider
    {
        public static int GetModuleID(int UserModuleID)
        {
            SQLHandler Objsql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               SQLHandler sqlh = new SQLHandler();
               int ModuleID = 0;
               ModuleID = sqlh.ExecuteAsScalar<int>("[dbo].[usp_ModuleControlGetModuleIdFromUserModuleId]", ParaMeterCollection);
               return ModuleID;
           }
           catch(Exception ex)
           {
               throw ex;
           
           }
        }
       
        public static string GetModuleName(int UserModuleID)
        {
            SQLHandler Objsql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                SQLHandler sqlh = new SQLHandler();
                string ModuleName = "";
                ModuleName = sqlh.ExecuteAsScalar<string>("[dbo].[usp_ModuleControlGetModuleNameFromUserModuleId]", ParaMeterCollection);
                return ModuleName;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static List<ModuleControlInfo> GetControlType(int ModuleDefID)
        {
            List<ModuleControlInfo> lstControl = new List<ModuleControlInfo>();
            string StoredProcedureName = "[dbo].[usp_ModuleControlGetControlTypeFromModuleID]";
            SQLHandler sqlh = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
            
            try
            {
                lstControl = sqlh.ExecuteAsList<ModuleControlInfo>(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstControl;
        }

    }
}
