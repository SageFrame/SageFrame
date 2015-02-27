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

namespace SageFrame.UserManagement
{
    public class UserManagementProvider
    {
        public static void UpdateUsersChanges(string Usernames, string IsActives, int PortalId, string UpdatedBy)
        {
            string sp = "[dbo].[sp_UsersUpdateChanges]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Usernames", Usernames));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActives", IsActives));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalId));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteSelectedUser(string Usernames, int PortalId, string DeletedBy)
        {
            string sp = "[dbo].[sp_UsersDeleteSeleted]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Usernames", Usernames));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalId));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", DeletedBy));

                sagesql.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<UserManagementInfo> GetUsernameByPortalIDAuto(string Prefix, int Count, int PortalID, string Username)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Prefix", Prefix));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Count", Count));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));

                return SQLH.ExecuteAsList<UserManagementInfo>("[dbo].[sp_GetUsernameByPortalIDAuto]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static ForgetPasswordInfo GetMessageTemplateByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));


                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader("[dbo].[sp_MessageTemplateByMessageTemplateTypeID]", ParamCollInput);
                ForgetPasswordInfo objList = new ForgetPasswordInfo();

                while (reader.Read())
                {

                    objList.MessageTemplateID = int.Parse(reader["MessageTemplateID"].ToString());
                    objList.MessageTemplateTypeID = int.Parse(reader["MessageTemplateTypeID"].ToString());
                    objList.Subject = reader["Subject"].ToString();
                    objList.Body = reader["Body"].ToString();
                    objList.MailFrom = reader["MailFrom"].ToString();

                }
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static List<ForgetPasswordInfo> GetMessageTemplateListByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                return SQLH.ExecuteAsList<ForgetPasswordInfo>("[dbo].[sp_MessageTemplateByMessageTemplateTypeID]", ParamCollInput);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        
        public static DataTable GetPasswordRecoverySuccessfulTokenValue(string Username, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                DataSet ds = SQLH.ExecuteAsDataSet("[dbo].[sp_GetPasswordRecoverySuccessfulTokenValue]", ParamCollInput);
                return ds.Tables[0];
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
         public static void DeactivateRecoveryCode(string Username, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLH.ExecuteNonQuery("[dbo].[usp_PasswordRecoveryDeactivateCode]", ParamCollInput);
              
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataTable GetActivationSuccessfulTokenValue(string Username, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                DataSet ds = SQLH.ExecuteAsDataSet("[dbo].[sp_GetActivationSuccessfulTokenValue]", ParamCollInput);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public static DataTable GetActivationTokenValue(string Username, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                DataSet ds = SQLH.ExecuteAsDataSet("[dbo].[sp_GetActivationTokenValue]", ParamCollInput);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataTable  GetPasswordRecoveryTokenValue(string Username, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                DataSet ds= SQLH.ExecuteAsDataSet("[dbo].[sp_GetPasswordRecoveryTokenValue]", ParamCollInput);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
    
        public static ForgetPasswordInfo GetUsernameByActivationOrRecoveryCode(string Code, int PortalID)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Code", Code));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                List<ForgetPasswordInfo> lstpwdinfo = new List<ForgetPasswordInfo>();
                lstpwdinfo = SQLH.ExecuteAsList<ForgetPasswordInfo>("[dbo].[sp_GetUsernameByActivationOrRecoveryCode]", ParamCollInput);
                ForgetPasswordInfo objInfo = new ForgetPasswordInfo();              
                if (lstpwdinfo.Count > 0)
                {
                    return lstpwdinfo[0];
                }
                else
                {
                    objInfo.IsAlreadyUsed = true;
                    return objInfo;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       

    }
}
