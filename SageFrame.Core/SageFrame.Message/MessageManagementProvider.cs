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
using System.Data.SqlClient;

#endregion


namespace SageFrame.Message
{
    public class MessageManagementProvider
    {

        public List<MessageManagementInfo> GetMessageTemplateTypeList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                string sp = "[dbo].[sp_GetMessageTemplateTypeList]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                return SQLH.ExecuteAsList<MessageManagementInfo>(sp, ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<MessageManagementInfo> GetMessageTemplateTypeTokenListByMessageTemplateType(int MessageTemplateTypeID, int PortalID)
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

        public static List<MessageManagementInfo> GetMessageTemplateByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_MessageTemplateByMessageTemplateTypeID]";
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

        public void UpdateMessageTemplate(int MessageTemplateID, int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime UpdatedOn, int PortalID, string UpdatedBy, string CurrentCulture)
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



        public int AddMessageTemplate(int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy, string CurrentCulture)
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

        public List<MessageManagementInfo> GetMessageTemplateList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                string sp = "[dbo].[sp_GetMessageTemplateList]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@CurrentCulture", CurrentCulture));

                return SQLH.ExecuteAsList<MessageManagementInfo>(sp, ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageManagementInfo GetMessageTemplate(int MessageTemplateID, int PortalID)
        {
            SqlDataReader reader = null;
            try
            {

                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateID", MessageTemplateID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
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
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }

        public void DeleteMessageTemplate(int MessageTemplateID, int PortalID, DateTime DeletedOn, string DeletedBy)
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

        public int AddMessageTemplateType(string Name, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
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

        public MessageManagementInfo GetUserFirstName(string Username, int PortalID)
        {
            SqlDataReader reader = null;
            try
            {
                string sp = "[dbo].[sp_GetUserFirstName]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

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
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public MessageManagementInfo GetUserLastName(string Username, int PortalID)
        {
            SqlDataReader reader = null;
            try
            {
                string sp = "[dbo].[sp_GetUserLastName]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

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
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public MessageManagementInfo GetUserEmail(string Username, int PortalID)
        {
            SqlDataReader reader = null;
            try
            {
                string sp = "[dbo].[sp_GetUserEmail]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

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
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public MessageManagementInfo GetUserActivationCode(string Username, int PortalID)
        {
            SqlDataReader reader = null;
            try
            {
                string sp = "[dbo].[sp_GetUserActivationCode]";
                SQLHandler SQLH = new SQLHandler();

                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

                reader = SQLH.ExecuteAsDataReader(sp, ParamCollInput);
                MessageManagementInfo objInfo = new MessageManagementInfo();

                while (reader.Read())
                {
                    objInfo.UserId = new Guid(reader["UserId"].ToString());
                }
                return objInfo;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public int MessageTemplateTokenAdd(int messageTokenID, int messageTemplateTypeID, string name, bool isActive, DateTime addedOn, int portalID, string addedBy)
        {
            try
            {
                string sp = "[dbo].[usp_MessageTemplateTokenAdd]";
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", messageTemplateTypeID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Name", name));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", isActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", addedOn));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", addedBy));
                return  SQLH.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@messageTokenID");
            }
            catch(Exception e)
            {
                throw e;
            }
        }        

        public bool CheckMessgeTemplateUnique(string messageTempTypeName, int portalID)
        {
            try
            {
                SQLHandler sqlH = new SQLHandler();
                List<KeyValuePair<string, object>> ParaMeter = new List<KeyValuePair<string, object>>();
                ParaMeter.Add(new KeyValuePair<string, object>("@MsgTemplateTypeName", messageTempTypeName));
                ParaMeter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                return sqlH.ExecuteNonQueryAsBool("[usp_MsgTempTypeUniquenessCheck]", ParaMeter, "@IsUnique");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckMessgeTokenUnique(string messageTempTokenName, int messageTemplateTypeID, int portalID)
        {
            try
            {
                SQLHandler sqlH = new SQLHandler();
                List<KeyValuePair<string, object>> ParaMeter = new List<KeyValuePair<string, object>>();
                ParaMeter.Add(new KeyValuePair<string, object>("@MsgTemplateTokenName", messageTempTokenName));
                ParaMeter.Add(new KeyValuePair<string, object>("@MsgTemplateTypeID", messageTemplateTypeID));
                ParaMeter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                return sqlH.ExecuteNonQueryAsBool("[usp_MsgTempTokenUniquenessCheck]", ParaMeter, "@IsUnique");
            }
            catch (Exception e)
            {
                throw e;
            }
        }     
    }
}
