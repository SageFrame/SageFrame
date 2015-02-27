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
using SageFrame.Web;
using SageFrame.ModuleManager;

namespace SageFrame.ModuleManager
{
    public class LayoutMgrDataProvider
    {
        public static List<LayoutMgrInfo> GetModules(int PortalID)
        {
            SQLHandler SQLH = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            return SQLH.ExecuteAsList<LayoutMgrInfo>("[usp_ModuleManagerGetPortalModules]",ParaMeterCollection);
        }

        public static List<LayoutMgrInfo> GetAdminModules(int PortalID)
        {
            SQLHandler SQLH = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            return SQLH.ExecuteAsList<LayoutMgrInfo>("[dbo].[usp_ModuleManagerGetAdminModules]",ParaMeterCollection);
        }

        public static List<LayoutMgrInfo> GetModuleInformation(string ModuleName)
        {
            SQLHandler SQLH = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FriendlyName", ModuleName));

            return SQLH.ExecuteAsList<LayoutMgrInfo>("[dbo].[usp_GetModuleInformation]", ParaMeterCollection);
        }

        public static List<LayoutMgrInfo> SearchModules(string search,int PortalID,bool IsAdmin)
        {
            SQLHandler SQLH = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@SearchText", search));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAdmin", IsAdmin));
            return SQLH.ExecuteAsList<LayoutMgrInfo>("[dbo].[usp_ModuleManagerGetSearchModules]", ParaMeterCollection);
        }

        public static List<LayoutMgrInfo> GetSortModules(int flag, bool isAdmin,int PortalID)
        {
            SQLHandler SQLH = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@flag", flag));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@isAdmin", isAdmin));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            try
            {
                return SQLH.ExecuteAsList<LayoutMgrInfo>("[dbo].[usp_ModuleMgrSortModules]", ParaMeterCollection);
            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public static int AddLayOutMgr(LayoutMgrInfo obj)
        {
            try
            {

                SqlConnection SQLConn = new SqlConnection(SystemSetting.SageFrameConnectionString);
                SqlCommand SQLCmd = new SqlCommand();
                int ReturnValue = -1;
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = "[dbo].[usp_AddModulesOrder]";
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLCmd.Parameters.Add(new SqlParameter("@ModuleOrder", obj.ModuleOrder));
                SQLCmd.Parameters.Add(new SqlParameter("@PortelID", obj.PortelID));
                SQLCmd.Parameters.Add(new SqlParameter("@ModuleID", obj.ModuleID));
                SQLCmd.Parameters.Add(new SqlParameter("@ModuleName", obj.ModuleName));
                SQLCmd.Parameters.Add(new SqlParameter("@PaneName", obj.PaneName));
                SQLCmd.Parameters.Add(new SqlParameter("@UserModuleID", obj.UserModuleID));

                SQLCmd.Parameters.Add(new SqlParameter("@NewModuleID", SqlDbType.Int));
                SQLCmd.Parameters["@NewModuleID"].Direction = ParameterDirection.Output;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                ReturnValue = (int)SQLCmd.Parameters["@NewModuleID"].Value;
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
