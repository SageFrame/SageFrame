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

namespace SageFrame.ProfileManagement
{
    [Serializable]
    public class ProfileManagementInfo
    {
        public int PropertyTypeID { get; set; }
        public string Name { get; set; }
        public int ProfileID { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int PortalID { get;set;}
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string PropertyTypeName { get; set; }

        public int EntryID { get; set; }
        public string ListName { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int LEVEL { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayLocale { get; set; }
        public int DisplayOrder { get; set; }
        public int DefinitionID { get; set; }
        public int ParentID { get; set; }
        public string Description { get; set; }
        public bool SystemList { get; set; }
        public string Culture { get; set; }
        public string ParentKey { get; set; }
        public string Parent { get; set; }
        public string ParentList { get; set; }
        public int MaxSortOrder { get; set; }
        public int EntryCount { get; set; }
        public int HasChildren { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedOn { get; set; }
        public int ProfileValueID { get; set; }

        public int UserProfileID { get; set; }
        public string Username { get; set; }
        public string EditUserName { get; set; }
		
	    public ProfileManagementInfo() { }
    }
}
