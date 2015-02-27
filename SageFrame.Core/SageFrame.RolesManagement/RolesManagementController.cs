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


namespace SageFrame.RolesManagement
{
    public class RolesManagementController
    {
        public RolesManagementInfo GetRoleIDByRoleName(string RoleName)
        {
            try
            {
                RolesManagementProvider objProvider = new RolesManagementProvider();
                return objProvider.GetRoleIDByRoleName(RoleName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RolesManagementInfo> PortalRoleList(int PortalID, bool IsAll, string Username)
        {
            try
            {
                RolesManagementProvider objProvider = new RolesManagementProvider();
                return objProvider.PortalRoleList(PortalID, IsAll, Username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RolesManagementInfo> GetPortalRoleSelectedList(int PortalID, string Username)
        {
            try
            {
                RolesManagementProvider objProvider = new RolesManagementProvider();
                return objProvider.GetPortalRoleSelectedList(PortalID,Username);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
