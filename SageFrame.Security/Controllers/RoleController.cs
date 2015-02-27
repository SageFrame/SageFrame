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
using SageFrame.Security.Entities;
using SageFrame.Security.Helpers;
using SageFrame.Security.Providers;
#endregion

namespace SageFrame.Security
{
    public class RoleController:SageFrameRoleProvider
    {

        public override void CreateRole(RoleInfo role, out RoleCreationStatus status)
        {
            MembershipDataProvider.CreateRole(role, out status);            
        }

        public override void DeleteRole(string RoleName)
        {
            throw new NotImplementedException();
        }

        public override void DeleteRole(string RoleName, int PortalID)
        {
            throw new NotImplementedException();
        }

        public override void DeleteRole(Guid RoleID)
        {
            throw new NotImplementedException();
        }

        public override RoleInfo GetRole(Guid RoleID)
        {
            throw new NotImplementedException();
        }

        public override RoleInfo GetRole(int PortalRoleID)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRoleNames(int PortalID)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRoleNames(int PortalID, int UserID)
        {
            throw new NotImplementedException();
        }

        public override void UpdateRole(RoleInfo role)
        {
            throw new NotImplementedException();
        }

        public override bool AddUserToRole(int PortalID, UserInfo user, UserRoleInfo UserRole)
        {
            throw new NotImplementedException();
        }

        public override UserRoleInfo GetUserRole(int PortalID, int UserID, int RoleID)
        {
            throw new NotImplementedException();
        }

        public override System.Collections.ArrayList GetUsersByRoleName(int PortalID, string RoleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUserFromRole(int PortalID, UserInfo user, UserRoleInfo userRole)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUserRole(UserRoleInfo userRole)
        {
            throw new NotImplementedException();
        }

        public override List<RoleInfo> GetPortalRoles(int PortalID, int IsAll, string UserName)
        {
            return (MembershipDataProvider.GetPortalRoles(PortalID, IsAll, UserName));
        }

        public override bool DeleteRole(Guid RoleID, int PortalID)
        {
            return (MembershipDataProvider.DeletePortalRole(RoleID, PortalID));
        }

        public override string GetRoleNames(string UserName, int PortalID)
        {
            return (MembershipDataProvider.GetRoleNames(UserName, PortalID));
        }

        public override bool DeleteUserInRoles(UserInfo user)
        {
            return (MembershipDataProvider.DeleteUserInRoles(user));
        }

        public override bool AddUserToRoles(UserInfo user)
        {
            return (MembershipDataProvider.AddUserInRoles(user));
        }

        public override bool ChangeUserInRoles(string ApplicationName, Guid UserID, string RoleNamesUnselected, string RoleNamesSelected, int PortalID)
        {
            return (MembershipDataProvider.ChangeUserInRoles(ApplicationName, UserID, RoleNamesUnselected, RoleNamesSelected, PortalID));
        }
    }
}
