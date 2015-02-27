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

namespace SageFrame.UserProfile
{
    public class UserProfileController
    {
        public static void AddUpdateProfile(UserProfileInfo objProfile)
        {
            try
            {
                UserProfileDataProvider.AddUpdateProfile(objProfile);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static UserProfileInfo GetProfile(string UserName, int PortalID)
        {
            try
            {
                return UserProfileDataProvider.GetProfile(UserName, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void DeleteProfilePic(string UserName, int PortalID)
        {
            try
            {
                UserProfileDataProvider.DeleteProfilePic(UserName, PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool UpdateCartAnonymoususertoRegistered(int storeID, int portalID, int customerID, string sessionCode)
        {
            try
            {
                return UserProfileDataProvider.UpdateCartAnonymoususertoRegistered(storeID, portalID, customerID, sessionCode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
