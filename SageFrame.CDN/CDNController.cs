using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.CDN
{
    public class CDNController
    {
        public void SaveLinks(List<CDNInfo> objInfo)
        {
            try
            {
                CDNProvider obj = new CDNProvider();
                obj.SaveLinks(objInfo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<CDNInfo> GetCDNLinks(int PortalID)
        {
            try
            {
                CDNProvider obj = new CDNProvider();
                return obj.GetCDNLinks(PortalID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveOrder(List<CDNInfo> objOrder)
        {
            try
            {
                CDNProvider obj = new CDNProvider();
                obj.SaveOrder(objOrder);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteURL(int UrlID, int PortalID)
        {
            CDNProvider objController = new CDNProvider();
            objController.DeleteURL(UrlID, PortalID);
        }
    }
}
