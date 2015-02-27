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

#endregion


namespace SageFrame.Message
{
    public class MessageManagementController
    {
        public List<MessageManagementInfo> GetMessageTemplateTypeList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetMessageTemplateTypeList(IsActive, IsDeleted, PortalID, Username, CurrentCulture);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<MessageManagementInfo> GetMessageTemplateTypeTokenListByMessageTemplateType(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetMessageTemplateTypeTokenListByMessageTemplateType(MessageTemplateTypeID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<MessageManagementInfo> GetMessageTemplateByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                return MessageManagementProvider.GetMessageTemplateByMessageTemplateTypeID(MessageTemplateTypeID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateMessageTemplate(int MessageTemplateID, int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime UpdatedOn, int PortalID, string UpdatedBy, string CurrentCulture)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                objProvider.UpdateMessageTemplate(MessageTemplateID, MessageTemplateTypeID, Subject, Body, MailFrom, IsActive, UpdatedOn, PortalID, UpdatedBy, CurrentCulture);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddMessageTemplate(int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy, string CurrentCulture)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.AddMessageTemplate(MessageTemplateTypeID, Subject, Body, MailFrom, IsActive, AddedOn, PortalID, AddedBy, CurrentCulture);
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
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetMessageTemplateList(IsActive, IsDeleted, PortalID, Username, CurrentCulture);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageManagementInfo GetMessageTemplate(int MessageTemplateID, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetMessageTemplate(MessageTemplateID, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteMessageTemplate(int MessageTemplateID, int PortalID, DateTime DeletedOn, string DeletedBy)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                objProvider.DeleteMessageTemplate(MessageTemplateID, PortalID, DeletedOn, DeletedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddMessageTemplateType(string Name, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.AddMessageTemplateType( Name, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageManagementInfo GetUserFirstName(string Username, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetUserFirstName(Username, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageManagementInfo GetUserLastName(string Username, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetUserLastName(Username, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageManagementInfo GetUserEmail(string Username, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetUserEmail(Username, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageManagementInfo GetUserActivationCode(string Username, int PortalID)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.GetUserActivationCode(Username, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int MessageTemplateTokenAdd(int messageTokenID, int messageTemplateTypeID, string name, bool isActive, DateTime addedOn, int portalID, string addedBy)
        {
            try
            {
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.MessageTemplateTokenAdd(messageTokenID, messageTemplateTypeID, name, isActive, addedOn, portalID, addedBy);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public void MessageTemplateTypeAdd(ref int messageTemplateTypeID, string name, bool isActive, DateTime addedOn, int portalID, string addedBy)
        //{
        //    try
        //    {
        //        MessageManagementProvider objProvider = new MessageManagementProvider();
        //        objProvider.MessageTemplateTypeAdd(ref messageTemplateTypeID, name, isActive, addedOn, portalID, addedBy);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool CheckMessgeTemplateUnique(string messageTempTypeName, int portalID)
        {
            try
            {
                 MessageManagementProvider objProvider = new MessageManagementProvider();
                 return objProvider.CheckMessgeTemplateUnique(messageTempTypeName, portalID);
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
                MessageManagementProvider objProvider = new MessageManagementProvider();
                return objProvider.CheckMessgeTokenUnique(messageTempTokenName, messageTemplateTypeID, portalID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
