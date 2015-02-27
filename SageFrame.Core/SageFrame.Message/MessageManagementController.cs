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

namespace SageFrame.Message
{
    public class MessageManagementController
    {
        public static List<MessageManagementInfo> GetMessageTemplateTypeList(bool IsActive, bool IsDeleted, int PortalID, string Username, string CurrentCulture)
        {
            try
            {
                return MessageManagementProvider.GetMessageTemplateTypeList(IsActive, IsDeleted, PortalID, Username, CurrentCulture);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<MessageManagementInfo> GetMessageTemplateTypeTokenListByMessageTemplateType(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                return MessageManagementProvider.GetMessageTemplateTypeTokenListByMessageTemplateType(MessageTemplateTypeID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdateMessageTemplate(int MessageTemplateID, int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime UpdatedOn, int PortalID, string UpdatedBy, string CurrentCulture)
        {
            try
            {
                MessageManagementProvider.UpdateMessageTemplate(MessageTemplateID, MessageTemplateTypeID, Subject, Body, MailFrom, IsActive, UpdatedOn, PortalID, UpdatedBy, CurrentCulture);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int AddMessageTemplate( int MessageTemplateTypeID, string Subject, string Body, string MailFrom, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy, string CurrentCulture)
        {
            try
            {
                return MessageManagementProvider.AddMessageTemplate( MessageTemplateTypeID,  Subject,  Body,  MailFrom,  IsActive,  AddedOn,  PortalID,  AddedBy, CurrentCulture);
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
                return MessageManagementProvider.GetMessageTemplateList(IsActive, IsDeleted, PortalID, Username, CurrentCulture);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static MessageManagementInfo GetMessageTemplate(int MessageTemplateID, int PortalID)
        {
            try
            {
                return MessageManagementProvider.GetMessageTemplate(MessageTemplateID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void DeleteMessageTemplate(int MessageTemplateID, int PortalID, DateTime DeletedOn, string DeletedBy)
        {
            try
            {
                MessageManagementProvider.DeleteMessageTemplate(MessageTemplateID, PortalID, DeletedOn, DeletedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static int AddMessageTemplateType(string Name, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                return MessageManagementProvider.AddMessageTemplateType(Name, IsActive, AddedOn, PortalID, AddedBy);
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
                return MessageManagementProvider.GetUserFirstName(Username, PortalID);
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
                return MessageManagementProvider.GetUserLastName(Username, PortalID);
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
                return MessageManagementProvider.GetUserEmail(Username, PortalID);
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
                return MessageManagementProvider.GetUserActivationCode(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
