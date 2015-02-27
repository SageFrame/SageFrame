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
using SageFrame.Security.Providers;
using System.Web.Security;
using SageFrame.Security.Helpers;
using SageFrame.Security.Enums;

namespace SageFrame.Security
{
    public class MembershipController:SageFrameMembershipProvider
    {
        # region Public Properties
        public override bool RequireUniqueEmail
        {
            get
            {                
                bool _RequireUniqueEmail=((int)EmailConfig.UNIQUE_EMAIL)==1?true:false;
                foreach (SettingInfo obj in MembershipDataProvider.GetSettings())
                {
                    switch (obj.SettingKey)
                    {
                        case "DUPLICATE_EMAIL_ALLOWED":
                            _RequireUniqueEmail = int.Parse(obj.SettingValue)==1?true:false;
                            break;
                    }
                }
                return _RequireUniqueEmail;
            }           
        }
        public override int PasswordFormat
        {
            get {
                ///get password format from database else return the default format
                int _PasswordFormat=(int)SettingsEnum.DEFAULT_PASSWORD_FORMAT;
                foreach (SettingInfo obj in MembershipDataProvider.GetSettings())
                {
                    switch (obj.SettingKey)
                    {
                        case "SELECTED_PASSWORD_FORMAT":
                            _PasswordFormat=int.Parse(obj.SettingValue);
                            break; 
                    }
                }
                return _PasswordFormat;
                 }
        }
        public override bool EnableCaptcha
        {
            get
            {                
                bool _EnableCaptcha = (int)SettingsEnum.DEFAULT_CAPTCHA_STATUS==1?true:false;
                foreach (SettingInfo obj in MembershipDataProvider.GetSettings())
                {
                    switch (obj.SettingKey)
                    {
                        case "ENABLE_CAPTCHA":
                            _EnableCaptcha = int.Parse(obj.SettingValue)==1?true:false;
                            break;
                    }
                }
                return _EnableCaptcha;
            }
        }
       #endregion

        #region Public Methods
        public override bool CreateUser(UserInfo user, out UserCreationStatus status,UserCreationMode mode)
        {
            try
            {
                return (MembershipDataProvider.CreatePortalUser(user, out status,mode));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override bool DeleteUser(UserInfo user)
        {
            return (MembershipDataProvider.DeleteUser(user));
        }

        public override bool DeleteUser(Guid UserID)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(int PortalID)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(int PortalID, string UserName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string UserName)
        {
            throw new NotImplementedException();
        }

        public override List<UserInfo> GetUsers(int PortalID)
        {
            return (MembershipDataProvider.GetPortalUsers(PortalID));
        }

        public override List<UserInfo> GetUnApprovedUsers(int PortalID)
        {
            throw new NotImplementedException();
        }

        public override List<UserInfo> GetUsers()
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            List<UserInfo> lstUsers = new List<UserInfo>();
            foreach (MembershipUser user in users)
            {

                lstUsers.Add(new UserInfo(user.UserName, "", user.Email, 1, Guid.NewGuid()));
            }
            return lstUsers;
        }

        public override UserInfo GetUserDetails(Guid UserID)
        {
            throw new NotImplementedException();
        }

        public override UserInfo GetUserDetails(int PortalID, string UserName)
        {
            return (MembershipDataProvider.GetUserDetails(UserName, PortalID));
        }

        public override bool UpdateUser(UserInfo user, out UserCreationStatus status)
        {
            throw new NotImplementedException();
        }

        public override SageFrameUserCollection GetAllUsers()
        {
            return (MembershipDataProvider.GetAllUsers());
        }

        public override bool ChangePassword(UserInfo user)
        {
            return (MembershipDataProvider.ChangePassword(user));
        }

        public override SageFrameUserCollection SearchUsers(string RoleID, string SearchText, int PortalID, string UserName)
        {
            return (MembershipDataProvider.SearchUsers(RoleID, SearchText, PortalID, UserName));
        }

        public override bool UpdateUser(UserInfo user, out UserUpdateStatus status)
        {
            return(MembershipDataProvider.UpdateUser(user,out status));
        }

        public override string ActivateUser(string ActivationCode, int PortalID)
        {
            return (MembershipDataProvider.ActivateUser(ActivationCode, PortalID));
        }

        public override string ActivateUser(string ActivationCode, int PortalID, int StoreID)
        {
            return (MembershipDataProvider.ActivateUser(ActivationCode, PortalID, StoreID));
        }
        #endregion

        public override bool EditPermissionExists(int UserModuleID, int PortalID, string UserName)
        {
            return (MembershipDataProvider.EditPermissionExists(UserModuleID, PortalID, UserName));
        }
    }
}
