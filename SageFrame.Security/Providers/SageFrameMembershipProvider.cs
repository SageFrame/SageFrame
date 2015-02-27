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
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using SageFrame.Security;
using SageFrame.Security.Entities;
using SageFrame.Security.Helpers;
using SageFrame.Security.Enums;

namespace SageFrame.Security
{
    public abstract class SageFrameMembershipProvider
    {
        public abstract bool RequireUniqueEmail{ get; }
        public abstract int PasswordFormat { get; }
        public abstract bool EnableCaptcha { get; }
        public abstract bool CreateUser(UserInfo user, out UserCreationStatus status,UserCreationMode mode);
        public abstract bool DeleteUser(UserInfo user);
        public abstract bool DeleteUser(Guid UserID);
        public abstract bool DeleteUser(int PortalID);
        public abstract bool DeleteUser(int PortalID, string UserName);
        public abstract bool DeleteUser(string UserName);
        public abstract List<UserInfo> GetUsers(int PortalID);
        public abstract List<UserInfo> GetUnApprovedUsers(int PortalID);
        public abstract List<UserInfo> GetUsers();
        public abstract SageFrameUserCollection GetAllUsers();
        public abstract SageFrameUserCollection SearchUsers(string RoleID, string SearchText, int PortalID, string UserName);
        public abstract UserInfo GetUserDetails(Guid UserID);
        public abstract UserInfo GetUserDetails(int PortalID, string UserName);
        public abstract bool UpdateUser(UserInfo user, out UserCreationStatus status);
        public abstract bool UpdateUser(UserInfo user, out UserUpdateStatus status);
        public abstract bool ChangePassword(UserInfo user);
        public abstract string ActivateUser(string ActivationCode, int PortalID);
        public abstract string ActivateUser(string ActivationCode, int PortalID, int StoreID);
        public abstract bool EditPermissionExists(int UserModuleID, int PortalID, string UserName);
    }
}
