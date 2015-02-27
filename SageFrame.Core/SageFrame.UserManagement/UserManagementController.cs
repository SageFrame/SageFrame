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
using System.Data;

namespace SageFrame.UserManagement
{
    public class UserManagementController
    {
        public static void UpdateUsersChanges(string Usernames, string IsActives, int PortalId, string UpdatedBy)
        {
            try
            {
                UserManagementProvider.UpdateUsersChanges(Usernames, IsActives, PortalId, UpdatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void DeleteSelectedUser(string Usernames, int PortalId, string DeletedBy)
        {
            try
            {
                UserManagementProvider.DeleteSelectedUser(Usernames, PortalId, DeletedBy);
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
                return UserManagementProvider.GetUsernameByPortalIDAuto(Prefix, Count, PortalID, Username);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static ForgetPasswordInfo GetMessageTemplateByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetMessageTemplateByMessageTemplateTypeID(MessageTemplateTypeID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<ForgetPasswordInfo> GetMessageTemplateListByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetMessageTemplateListByMessageTemplateTypeID(MessageTemplateTypeID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static DataTable GetPasswordRecoverySuccessfulTokenValue(string Username, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetPasswordRecoverySuccessfulTokenValue(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public static void DeactivateRecoveryCode(string Username, int PortalID)
        {
            try
            {
                UserManagementProvider.DeactivateRecoveryCode(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static DataTable GetActivationSuccessfulTokenValue(string Username, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetActivationSuccessfulTokenValue(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static ForgetPasswordInfo GetUsernameByActivationOrRecoveryCode(string Code, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetUsernameByActivationOrRecoveryCode(Code,PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static DataTable GetPasswordRecoveryTokenValue(string Username, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetPasswordRecoveryTokenValue(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static DataTable GetActivationTokenValue(string Username, int PortalID)
        {
            try
            {
                return UserManagementProvider.GetActivationTokenValue(Username, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        

    }
}
