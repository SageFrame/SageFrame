using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;
using SageFrame.Message;

namespace SageFrame.NewsLetter
{
    public class NL_Provider
    {
        public void SaveEmailSubscriber(string Email, int UsermoduleID, int PortalID,string UserName,string clientIP)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@SubscriberEmail", Email));
                Param.Add(new KeyValuePair<string, object>("@UsermoduleID", UsermoduleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                Param.Add(new KeyValuePair<string, object>("@UserName", UserName));
                Param.Add(new KeyValuePair<string, object>("@clientIP", clientIP));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_SaveEmailSubscriber", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveMobileSubscriber(Int64 Phone, int UserModuleID, int PortalID, string UserName, string clientIP)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@SubscriberPhone", Phone));
                Param.Add(new KeyValuePair<string, object>("@UsermoduleID", UserModuleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                Param.Add(new KeyValuePair<string, object>("@UserName", UserName));
                Param.Add(new KeyValuePair<string, object>("@clientIP", clientIP));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_SaveMobileSubscriber", Param);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveNLSetting(string SettingKey, string SettingValue, int UserModuleID, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@SettingKeys", SettingKey));
                Param.Add(new KeyValuePair<string, object>("@SettingValues", SettingValue));
                Param.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_SaveNLSetting", Param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_SettingInfo> GetNLSetting(int UsermoduleID, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@UsermoduleID", UsermoduleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<NL_SettingInfo>("[usp_NLGetSetting]", Param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_Info> CheckPreviousEmailSubscription(string Email)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@Email", Email));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<NL_Info>("usp_NL_GetDataByEmail", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_SettingInfo> GetNLSettingForUnSubscribe()
        {
            try
            {
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<NL_SettingInfo>("usp_NL_GetNLSettingForUnSubscribe");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UnSubscribeUserByEmail(string Email)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@Email", Email));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_UnSubscribeUserByEmail", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UnSubscribeUserByMobile(Int64 Phone)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@Phone", Phone));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_UnSubscribeUserByPhone", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MessageManagementInfo> GetMessageTemplateListForSubscribe(int current, int pagesize, bool IsActive,bool IsDeleted, int PortalID, string UserName, string CultureName)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@Current", current));
                Param.Add(new KeyValuePair<string, object>("@Pagesize", pagesize));
                Param.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                Param.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
                Param.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                Param.Add(new KeyValuePair<string, object>("@UserName", UserName));
                Param.Add(new KeyValuePair<string, object>("@CurrentCulture", CultureName));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<MessageManagementInfo>("usp_NL_GetMessageTemplateList", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MessageManagementInfo> GetMessageInfoByMessageTemplateID(int messageTemplateID)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@messageTemplateID", messageTemplateID));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<MessageManagementInfo>("usp_NL_GetMessageInfoByID", Param);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UnSubscribeByEmailLink(int subscriberID)
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@subscriberID", subscriberID));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("usp_NL_UnSubscribeByEmailLink", Param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_Info>  GetSubscriberList(int index) 
        {
            try
            {
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@Offset", index));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<NL_Info>("usp_NL_GetSubscriberList", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_Info> GetSubscriberEmailList(int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<NL_Info>("[usp_NL_GetSubscriberEmailList]", Parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveNewsLetter(string Subject, string BodyMsg, int UserModuleID, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@Subject", Subject));
                Parameter.Add(new KeyValuePair<string, object>("@BodyMsg", BodyMsg));
                Parameter.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlh = new SQLHandler();
                sqlh.ExecuteNonQuery("[usp_NL_SaveNewsLetter]", Parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<MessageManagementInfo> GetMessageTemplateByTypeID(int MessageTemplateTypeID, string CultureName, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@MessageTemplateTypeID", MessageTemplateTypeID));
                Parameter.Add(new KeyValuePair<string, object>("@Culture", CultureName));
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlh = new SQLHandler();
                return sqlh.ExecuteAsList<MessageManagementInfo>("[usp_NL_GetMessageTemplateByTypeID]", Parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
