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

namespace SageFrame.UserProfile
{
    public class UserProfileInfo
    {
        public int UserID { get; set; }
        public string Image { get; set; }
        public string UserName { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public string Location { get; set; }
        public string AboutYou { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Mobile { get; set; }
        public string ResPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Others { get; set; }
        public bool IsDeleted{get;set;}
        public bool IsModified	{get;set;}
        public DateTime AddedOn{get;set;}
        public DateTime UpdatedOn{get;set;}
        public DateTime DeletedOn { get; set; }
        public DateTime BirthDate { get; set; }
        public int PortalID{get;set;}
        public string  AddedBy{get;set;}
        public string UpdatedBy	{get;set;}
        public string DeletedBy { get; set; }
        public UserProfileInfo() { }

    }
}
