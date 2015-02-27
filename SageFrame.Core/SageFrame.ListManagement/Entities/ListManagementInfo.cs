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

namespace SageFrame.Core.ListManagement
{
    public class ListManagementInfo
    {
        public int EntryID { get; set; }
        public string ListName { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int Level { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayLocale { get; set; }
        public int DisplayOrder { get; set; }
        public int DefinitionID { get; set; }
        public int ParentID { get; set; }
        public string Description { get; set; }
        public int PortalID { get; set; }
        public bool SystemList { get; set; }
        public string Culture { get; set; }
        public string ParentKey { get; set; }
        public string Parent { get; set; }
        public string ParentList { get; set; }
        public int MaxSortOrder { get; set; }
        public int EntryCount { get; set; }
        public int HasChildren { get; set; }
        public bool IsActive { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }      
        public bool EnableDisplayOrder { get; set; }

        //public ListManagementInfo() { }
        
	
        //public ListManagementInfo(string ListName,string Value,int EntryID,string Culture) 
        //{
        //    this.ListName = ListName;
        //    this.Value = Value;
        //    this.EntryID = EntryID;
        //    this.Culture = Culture;
        //}

        //public ListManagementInfo(string _ListName, string _Value, string _Text, int _ParentID, int _Level, string _CurrencyCode, string _DisplayLocale, bool _EnableDisplayOrder, int _DefinitionID, string _Description, int _PortalID, bool _IsActive, string _AddedBy, string _Culture)
        //{
        //    this.ListName = _ListName;
        //    this.Value = _Value;
        //    this.Text = _Text;
        //    this.ParentID = _ParentID;
        //    this.Level = _Level;
        //    this.CurrencyCode = _CurrencyCode;
        //    this.DisplayLocale = _DisplayLocale;
        //    this.EnableDisplayOrder = _EnableDisplayOrder;
        //    this.DefinitionID = _DefinitionID;
        //    this.Description = _Description;
        //    this.PortalID = _PortalID;
        //    this.IsActive = _IsActive;
        //    this.AddedBy = _AddedBy;
        //    this.Culture = _Culture;
        //}
    }
}
