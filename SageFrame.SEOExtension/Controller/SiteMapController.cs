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

namespace SageFrame.SEOExtension
{
    public class SiteMapController
    {
        public static List<SiteMapInfo> GetSiteMap(string prefix, bool IsActive, bool IsDeleted, int PortalID, string Username, bool IsVisible, bool IsRequiredPage)
        {
            try
            {
                return (SiteMapDataProvider.GetSiteMap(prefix, IsActive, IsDeleted, PortalID, Username, IsVisible, IsRequiredPage));
            }
            catch (Exception)
            {

                throw;
            }
        }
    
    }
}
