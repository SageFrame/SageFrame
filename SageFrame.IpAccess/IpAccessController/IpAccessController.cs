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
using SageFrame.Web.Utilities;
#endregion

namespace SageFrame.IpAccess
{
    public class IpAccessController
    {
        public IpAccessController()
        {
        }
        public List<IpRangeInfo> GetAccessIpList(int portalId)
        {
            var provider = new IpAccessProvider();
            return provider.GetAccessIpList(portalId);
        }
        public void SaveIpToAccess(IpRangeInfo ipinfo, int portalId, string userName)
        {
            var provider = new IpAccessProvider();
            provider.SaveIpToAccess(ipinfo, portalId, userName);
        }

        public void DeleteAccessIp(string ids, int portalId, string userName)
        {
            var provider = new IpAccessProvider();
            provider.DeleteAccessIp(ids, portalId, userName);
        }
        public bool IsExistIpRange(string ipfrom, string ipTo, int portalId)
        {
            var provider = new IpAccessProvider();
            return provider.IsExistIpRange(ipfrom, ipTo, portalId);
        }
        public bool CheckIpAccess(string ipAddress, int portalId)
        {
            var ipChecker = new Ipv4();
            return ipChecker.IsAccessIpAddress(ipAddress, portalId);
        }
    }
}
