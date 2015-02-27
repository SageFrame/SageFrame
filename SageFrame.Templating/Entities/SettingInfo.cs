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

namespace SageFrame.Templating
{
    public class SettingInfo
    {
        public string ActiveLayout { get; set; }
        public string ActiveTheme { get; set; }
        public string ActiveWidth { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string UserName { get; set; }
        public int PortalID { get; set; }
        public SettingInfo() { }
        public SettingInfo(string _ActiveLayout, string _ActiveTheme)
        {
            this.ActiveLayout = _ActiveLayout;
            this.ActiveTheme = _ActiveTheme;
        }

        public SettingInfo(string _SettingKey,string _UserName,int _PortalID)
        {
            this.SettingKey = _SettingKey;
            this.UserName=_UserName;
            this.PortalID = _PortalID;
        }
    }
}
