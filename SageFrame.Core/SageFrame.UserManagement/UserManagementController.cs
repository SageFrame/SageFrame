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
using System.Data;

#endregion


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
        public static ForgotPasswordInfo GetMessageTemplateByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
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
        public static List<ForgotPasswordInfo> GetMessageTemplateListByMessageTemplateTypeID(int MessageTemplateTypeID, int PortalID)
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
        public static ForgotPasswordInfo GetUsernameByActivationOrRecoveryCode(string Code, int PortalID)
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
