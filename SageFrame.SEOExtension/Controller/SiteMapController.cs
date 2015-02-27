using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
