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

namespace SageFrame.Message
{
    public class MessageManagementProvider
    {
        
        public static List<MessageManagementInfo> GetMessageTemplateTypeList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                string sp = "[dbo].[sp_GetMessageTemplateTypeList]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                return SQLH.ExecuteAsList<MessageManagementInfo>(sp, ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
        public static List<MessageManagementInfo> GetMessageTemplateTypeTokenListByMessageTemplateType(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_MessageTemplateTypeTokenListByMessageTemplateType]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                return SQLH.ExecuteAsList<MessageManagementInfo>(sp, ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   
        
        public static void UpdateMessageTemplate(int MessageTemplateID,int MessageTemplateTypeID,string Subject,string Body,string MailFrom,bool IsActive,DateTime UpdatedOn,int PortalID,string UpdatedBy,string CurrentCulture)
        {
            try
            {
                string sp = "sp_MessageTemplateUpdate";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateID", MessageTemplateID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Subject", Subject));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Body", Body));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MailFrom", MailFrom));

                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                SQLH.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

   
        
        public static int AddMessageTemplate(int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy, string CurrentCulture)
        {
            try
            {
                string sp = "[dbo].[sp_MessageTemplateAdd]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Subject", Subject));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Body", Body));
                ParamCollInput.Add(new KeyValuePair<string, object>("@MailFrom", MailFrom));

                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                return SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@MessageTemplateID");


            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public static List<MessageManagementInfo> GetMessageTemplateList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                string sp = "[dbo].[sp_GetMessageTemplateList]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                return SQLH.ExecuteAsList<MessageManagementInfo>(sp, ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public static MessageManagementInfo GetMessageTemplate(int MessageTemplateID, int PortalID)
        {
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateID", MessageTemplateID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader("[dbo].[sp_GetMessageTemplate]", ParamCollInput);
                MessageManagementInfo objList = new MessageManagementInfo();

                while (reader.Read())
                {

                    objList.Subject = reader["Subject"].ToString();
                    objList.Body = reader["Body"].ToString();
                    objList.MailFrom = reader["MailFrom"].ToString();
                    objList.IsActive = bool.Parse(reader["IsActive"].ToString());
                    objList.MessageTemplateTypeID = int.Parse(reader["MessageTemplateTypeID"].ToString());

                }
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
                
        public static void DeleteMessageTemplate(int MessageTemplateID, int PortalID, DateTime DeletedOn, string DeletedBy)
        {
            try
            {
                string sp = "[dbo].[sp_MessageTemplateDelete]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateID", MessageTemplateID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedOn", DeletedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", DeletedBy));

                SQLH.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public static int AddMessageTemplateType(string Name, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                string sp = "[dbo].[sp_MessageTemplateTypeAdd]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();

                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", Name));

                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));


                return SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@MessageTemplateTypeID");


            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static MessageManagementInfo GetUserFirstName(string Username, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_GetUserFirstName]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                MessageManagementInfo objInfo = new MessageManagementInfo();

                while (reader.Read())
                {
                    objInfo.FirstName = reader["FirstName"].ToString();
                }
                return objInfo;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public static MessageManagementInfo GetUserLastName(string Username, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_GetUserLastName]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                MessageManagementInfo objInfo = new MessageManagementInfo();

                while (reader.Read())
                {
                    objInfo.LastName = reader["LastName"].ToString();
                }
                return objInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static MessageManagementInfo GetUserEmail(string Username, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_GetUserEmail]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                MessageManagementInfo objInfo = new MessageManagementInfo();

                while (reader.Read())
                {
                    objInfo.Email = reader["Email"].ToString();
                }
                return objInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static MessageManagementInfo GetUserActivationCode(string Username, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_GetUserActivationCode]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Username", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SqlDataReader reader = null;
                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                MessageManagementInfo objInfo = new MessageManagementInfo();

                while (reader.Read())
                {
                    objInfo.UserId =new Guid(reader["UserId"].ToString());
                }
                return objInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

     

    }
}
