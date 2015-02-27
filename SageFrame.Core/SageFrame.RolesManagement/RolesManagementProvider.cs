/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
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
        public  RolesManagementInfo GetRoleIDByRoleName(string RoleName)
        {
            SqlDataReader reader = null;
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@RoleName", RoleName));
                reader = SQLH.ExecuteAsDataReader("[dbo].[sp_GetRoleIDByRoleName]", ParamCollInput);
                RolesManagementInfo objList = new RolesManagementInfo();
                while (reader.Read())
                {
                    objList.ApplicationId = new Guid(reader["ApplicationId"].ToString());
                    objList.RoleId = new Guid(reader["RoleId"].ToString());
                    objList.RoleName = reader["RoleName"].ToString();
                    objList.LoweredRoleName = reader["LoweredRoleName"].ToString();
                    objList.Description = reader["Description"].ToString();
                }
                reader.Close();
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        public  List<RolesManagementInfo> PortalRoleList(int PortalID, bool IsAll, string Username)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsAll", IsAll));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                return SQLH.ExecuteAsList<RolesManagementInfo>("[dbo].[sp_PortalRoleList]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<RolesManagementInfo> GetPortalRoleSelectedList(int PortalID, string Username)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                return SQLH.ExecuteAsList<RolesManagementInfo>("[dbo].[usp_GetPortalRoleSelectedList]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
