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

namespace SageFrame.Security.Entities
{
    [Serializable]
    public class UserInfo
    {
        public int PortalUserID { get; set; }        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool IsApproved { get; set; }
        public string ApplicationName { get; set; }
        public DateTime  CurrentTimeUtc { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UniqueEmail { get; set; }
        public int PasswordFormat { get; set; }
        public int PortalID { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public Guid UserID { get; set; }
        public bool IsActive { get; set; }
        public string  UpdatedBy { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public string EmailCurrent { get; set; }
        public bool UserExists { get; set; }
        public List<RoleInfo> LSTRoles { get; set; }
        public string RoleNames { get; set; }


        public UserInfo() { }
        public UserInfo(string _UserName, string _FirstName, string _Email, int _PortalID, Guid _UserID)
        {
            this.UserName = _UserName;
            this.FirstName = _FirstName;
            this.Email = _Email;
            this.PortalID = _PortalID;
            this.UserID = _UserID;
        }

        public UserInfo(string _UserName, int _PortalID, string _ApplicationName, string _AddedBy)
        {
            this.UserName = _UserName;
            this.PortalID = _PortalID;
            this.ApplicationName = _ApplicationName;
            this.AddedBy = _AddedBy;

        }

        public UserInfo(string _ApplicationName, Guid _UserID, string _RoleNames, int _PortalID)
        {
            this.ApplicationName = _ApplicationName;
            this.UserID = _UserID;
            this.RoleNames = _RoleNames;
            this.PortalID = _PortalID;
        }

        public UserInfo(Guid _UserID, string _Password, string _PasswordSalt)
        {
            this.UserID = _UserID;
            this.Password = _Password;
            this.PasswordSalt = _PasswordSalt;
        }
        public UserInfo(Guid _UserID, string _Password, string _PasswordSalt,int _PasswordFormat)
        {
            this.UserID = _UserID;
            this.Password = _Password;
            this.PasswordSalt = _PasswordSalt;
            this.PasswordFormat = _PasswordFormat;
        }

        public UserInfo(string _ApplicationName, string _UserName, Guid _UserID, string _FirstName, string _LastName, string _Email, int _PortalID, bool _IsApproved, string _UpdatedBy)
        {
            this.ApplicationName = _ApplicationName;
            this.UserName = _UserName;
            this.UserID = _UserID;
            this.FirstName = _FirstName;
            this.LastName = _LastName;
            this.Email = _Email;
            this.PortalID = _PortalID;
            this.IsApproved = _IsApproved;
            this.UpdatedBy = _UpdatedBy;        
        }

        public UserInfo(bool _UserExists)
        {
            this.UserExists = _UserExists;
        }



      
    }
}
