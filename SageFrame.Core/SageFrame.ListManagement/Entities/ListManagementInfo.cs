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

namespace SageFrame.Core.ListManagement
{
    public class ListManagementInfo
    {







        public DateTime UpdatedOn { get; set; }  
        public DateTime AddedOn { get; set; }  
        public int HasChildren { get; set; }  
        public string ParentList { get; set; }  
        public bool SystemList { get; set; }  
        public int DisplayOrder { get; set; }  
        public int EntryID { get; set; }
        public string ListName { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayLocale { get; set; }
        public bool EnableDisplayOrder { get; set; }
        public int DefinitionID { get; set; }
        public string Description { get; set; }
        public int PortalID { get; set; }
        public bool IsActive { get; set; }
        public string AddedBy { get; set; }
        public string Culture { get; set; }
        public int EntryCount { get; set; }
        public string ParentKey { get; set; }
        public int Parent { get; set; }
        public int MaxSortOrder { get; set; }
        public string UpdatedBy { get; set; }




     
        
        public ListManagementInfo() { }
        
	
        public ListManagementInfo(string ListName,string Value,int EntryID,string Culture) 
        {
            this.ListName = ListName;
            this.Value = Value;
            this.EntryID = EntryID;
            this.Culture = Culture;
        }



        public ListManagementInfo(string _ListName, string _Value, string _Text, int _ParentID, int _Level, string _CurrencyCode, string _DisplayLocale, bool _EnableDisplayOrder, int _DefinitionID, string _Description, int _PortalID, bool _IsActive, string _AddedBy, string _Culture)
        {
            this.ListName = _ListName;
            this.Value = _Value;
            this.Text = _Text;
            this.ParentID = _ParentID;
            this.Level = _Level;
            this.CurrencyCode = _CurrencyCode;
            this.DisplayLocale = _DisplayLocale;
            this.EnableDisplayOrder = _EnableDisplayOrder;
            this.DefinitionID = _DefinitionID;
            this.Description = _Description;
            this.PortalID = _PortalID;
            this.IsActive = _IsActive;
            this.AddedBy = _AddedBy;
            this.Culture = _Culture;
        }
    }
}
