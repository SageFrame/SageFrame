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

namespace SageFrame.GoogleAdsense
{
    public class GoogleAdsenseController
    {
        public int CountAdsenseSettings(int UserModuleID, int PortalID)
        {
            try
            {
                GoogleAdsenseProvider objProvider = new GoogleAdsenseProvider();
                return objProvider.CountAdsenseSettings(UserModuleID, PortalID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public List<GoogleAdsenseInfo> GetAdSenseSettingsByUserModuleID(int UserModuleID, int PortalID)
        {
            try
            {
                GoogleAdsenseProvider objProvider = new GoogleAdsenseProvider();
                return objProvider.GetAdSenseSettingsByUserModuleID(UserModuleID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void AddUpdateAdSense(int UserModuleID, string SettingName, string SettingValue, bool IsActive, int PortalID, string UpdatedBy, bool UpdateFlag)
        {
            try
            {
                GoogleAdsenseProvider objProvider = new GoogleAdsenseProvider();
                objProvider.AddUpdateAdSense(UserModuleID, SettingName, SettingValue, IsActive, PortalID, UpdatedBy, UpdateFlag);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteAdSense(int UserModuleID, int PortalID)
        {
            try
            {
                GoogleAdsenseProvider objProvider = new GoogleAdsenseProvider();
                objProvider.DeleteAdSense(UserModuleID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CountAdSense(int UserModuleID, int PortalID)
        {
            try
            {
                GoogleAdsenseProvider objProvider = new GoogleAdsenseProvider();
                return objProvider.CountAdSense(UserModuleID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
