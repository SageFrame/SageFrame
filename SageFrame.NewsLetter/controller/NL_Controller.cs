using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Message;
using System.Net.Mail;
using SageFrame.Web;
namespace SageFrame.NewsLetter
{
    public  class NL_Controller
    {
        public void SaveEmailSubscriber(string Email, int UsermoduleID, int PortalID, string UserName, string clientIP)
        {
            try
            {
                NL_Provider cont = new NL_Provider();
                cont.SaveEmailSubscriber(Email, UsermoduleID, PortalID, UserName, clientIP);
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
                NL_Provider cont = new NL_Provider();
                cont.SaveMobileSubscriber(Phone, UserModuleID, PortalID, UserName, clientIP);


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
                NL_Provider cont = new NL_Provider();
                cont.SaveNLSetting(SettingKey, SettingValue, UserModuleID, PortalID);

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
                NL_Provider cont = new NL_Provider();
                return cont.GetNLSetting(UsermoduleID, PortalID);

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
                NL_Provider cont = new NL_Provider();
                return cont.CheckPreviousEmailSubscription(Email);
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
                NL_Provider cont = new NL_Provider();
                return cont.GetNLSettingForUnSubscribe();

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
                NL_Provider cont = new NL_Provider();
                cont.UnSubscribeUserByEmail(Email);
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
                NL_Provider cont = new NL_Provider();
                cont.UnSubscribeUserByMobile(Phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MessageManagementInfo> GetMessageTemplateListForSubscribe(int current, int pagesize, bool IsActive, bool IsDeleted, int PortalID, string UserName, string CultureName)
        {
            try
            {
                NL_Provider provider = new NL_Provider();
                return provider.GetMessageTemplateListForSubscribe(current, pagesize, true, false, PortalID, UserName, CultureName);
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
                NL_Provider provider = new NL_Provider();
                return provider.GetMessageInfoByMessageTemplateID(messageTemplateID);
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
                NL_Provider provider = new NL_Provider();
                provider.UnSubscribeByEmailLink(subscriberID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NL_Info> GetSubscriberList(int index)
        {
            NL_Provider provider = new NL_Provider();
            return provider.GetSubscriberList(index);
        }
        public List<NL_Info> GetSubscriberEmailList(int PortalID)
        {
            try
            {
                NL_Provider provider = new NL_Provider();
                return provider.GetSubscriberEmailList(PortalID);

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
                NL_Provider provider = new NL_Provider();
                provider.SaveNewsLetter(Subject, BodyMsg,UserModuleID,PortalID);
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
                NL_Provider provider = new NL_Provider();
                return provider.GetMessageTemplateByTypeID(MessageTemplateTypeID, CultureName, PortalID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

    }


}
