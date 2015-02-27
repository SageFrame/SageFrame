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

namespace SageFrame.ModuleManager
{
    public class UserModuleInfo
    {
        public int UserModuleID { get; set; }
        public int ModuleDefID { get; set; }
        public string UserModuleTitle { get; set; }
        public bool AllPages { get; set; }
        public string ShowInPages { get; set; }
        public bool InheritViewPermissions { get; set; }
        public string SEOName { get; set; }
        public int PageID { get; set; }
        public string PaneName { get; set; }
        public int ModuleOrder { get; set; }
        public string CacheTime { get; set; }
        public string Alignment { get; set; }
        public string Color { get; set; }
        public string IconFile { get; set; }
        public bool Visibility { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedOn { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }
        public int ErrorCode { get; set; }
        public string PageName { get; set; }
        public bool IsHandheld { get; set; }
        public string FriendlyName { get; set; }
        public string HeaderText { get; set; }
        public bool ShowHeaderText { get; set; }
        public int ControlsCount { get; set; }
        public List<ModulePermissionInfo> LSTUserModulePermission { get; set; }
        public bool IsInAdmin { get; set; }
        public string PageModuleName
        {
            get { return (PageName + "-->" + UserModuleTitle); }
        }
        public string SuffixClass { get; set; }

        public UserModuleInfo() { }


    }
}
