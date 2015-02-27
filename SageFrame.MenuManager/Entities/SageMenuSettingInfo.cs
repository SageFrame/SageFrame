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

namespace SageFrame.SageMenu
{
    public class SageMenuSettingInfo
    {
        public int MenuID { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string MenuType { get; set; }
        public string TopMenuSubType { get; set; }
        public string MenuHeaderText { get; set; }
        public string SideMenuType { get; set; }
        public string DisplayMode { get; set; }
        public string Caption { get; set; }
        public string SubTitleLevel { get; set; }
        public int PortalID { get; set; }
        public int UserModuleID { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }

        public SageMenuSettingInfo() { }
    }
}
