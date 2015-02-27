/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
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
        public int StoreID { get; set; }
        public int CustomerID { get; set; }


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

        public UserInfo(string _UserName, int _PortalID, string _ApplicationName, string _AddedBy, int _StoreID)
        {
            this.UserName = _UserName;
            this.PortalID = _PortalID;
            this.ApplicationName = _ApplicationName;
            this.AddedBy = _AddedBy;
            this.StoreID = _StoreID;

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

        public UserInfo(string _ApplicationName, string _UserName, Guid _UserID, string _FirstName, string _LastName, string _Email, int _PortalID, bool _IsApproved, string _UpdatedBy, int _StoreID)
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
            this.StoreID = _StoreID;
        }

        public UserInfo(string _ApplicationName, string _UserName, Guid _UserID, string _FirstName, string _LastName, string _Email, int _PortalID, bool _IsApproved, string _UpdatedBy, int _StoreID, int _CustomerID)
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
            this.StoreID = _StoreID;
            this.CustomerID = _CustomerID;
        }

        public UserInfo(bool _UserExists)
        {
            this.UserExists = _UserExists;
        }



      
    }
}
