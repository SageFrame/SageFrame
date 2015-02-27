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


namespace SageFrame.NewLetterSubscriber
{
    public class NewLetterSubscriberController
    {
        public static int AddNewLetterSubscribers(string Email, string ClientIP, bool IsActive, string AddedBy, DateTime AddedOn, int PortalID)
        {
            try
            {
                return NewLetterSubscriberProvider.AddNewLetterSubscribers(Email, ClientIP, IsActive, AddedBy, AddedOn, PortalID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static int UpdateNewLetterSettings(int UserModuleID, string SettingKey, string SettingValue, bool IsActive, int PortalID, string UpdatedBy, string AddedBy)
        {
            try
            {
                return NewLetterSubscriberProvider.UpdateNewLetterSettings(UserModuleID, SettingKey, SettingValue, IsActive, PortalID, UpdatedBy, AddedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public NewsLetterSettingsInfo GetNewsLetterSetting(int usermoduleIDControl, int portalID)
        {
            try
            {
                NewLetterSubscriberProvider objProvider = new NewLetterSubscriberProvider();
                NewsLetterSettingsInfo objNewsletterSettingInfo = objProvider.GetNewsLetterSetting(usermoduleIDControl, portalID);
                return objNewsletterSettingInfo;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
