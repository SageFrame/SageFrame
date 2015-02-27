/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Security.Entities;
using SageFrame.Security.Helpers;
using System.Collections;

namespace SageFrame.Security
{
    public abstract class SageFrameRoleProvider
    {
        public abstract void CreateRole(RoleInfo role, out RoleCreationStatus status);
        public abstract void DeleteRole(string RoleName);
        public abstract void DeleteRole(string RoleName, int PortalID);
        public abstract bool DeleteRole(Guid RoleID, int PortalID);
        public abstract void DeleteRole(Guid RoleID);        
		public abstract RoleInfo GetRole(Guid RoleID);
        public abstract RoleInfo GetRole(int PortalRoleID);
        public abstract List<RoleInfo> GetPortalRoles(int PortalID, int IsAll, string UserName);
		public abstract string[] GetRoleNames(int PortalID);
		public abstract string[] GetRoleNames(int PortalID, int UserID);
        public abstract string GetRoleNames(string UserName, int PortalID);
		public abstract void UpdateRole(RoleInfo role);		
		public abstract bool AddUserToRole(int PortalID, UserInfo user, UserRoleInfo UserRole);
        public abstract bool AddUserToRoles(UserInfo user);
		public abstract UserRoleInfo GetUserRole(int PortalID, int UserID, int RoleID);		
		public abstract ArrayList GetUsersByRoleName(int PortalID, string RoleName);	
		public abstract void RemoveUserFromRole(int PortalID, UserInfo user, UserRoleInfo userRole);
		public abstract void UpdateUserRole(UserRoleInfo userRole);
        public abstract bool DeleteUserInRoles(UserInfo user);
        public abstract bool ChangeUserInRoles(string ApplicationName, Guid UserID, string RoleNamesUnselected, string RoleNamesSelected, int PortalID);
		
    }
}
