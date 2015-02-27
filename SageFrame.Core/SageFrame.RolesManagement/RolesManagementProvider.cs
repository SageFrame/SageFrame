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

namespace SageFrame.RolesManagement
{
    public class RolesManagementProvider
    {
        public static RolesManagementInfo GetRoleIDByRoleName(string RoleName)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@RoleName",RoleName));
               
                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader("[dbo].[sp_GetRoleIDByRoleName]", ParamCollInput);
                RolesManagementInfo objList = new RolesManagementInfo();

                while (reader.Read())
                {

                    objList.ApplicationId =  new Guid(reader["ApplicationId"].ToString());
                    objList.RoleId = new Guid(reader["RoleId"].ToString());
                    objList.RoleName = reader["RoleName"].ToString();
                    objList.LoweredRoleName = reader["LoweredRoleName"].ToString();
                    objList.Description = reader["Description"].ToString();
                                       
                }
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static List<RolesManagementInfo> PortalRoleList(int PortalID, bool IsAll, string Username)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsAll", IsAll));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                return SQLH.ExecuteAsList<RolesManagementInfo>("[dbo].[sp_PortalRoleList]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
