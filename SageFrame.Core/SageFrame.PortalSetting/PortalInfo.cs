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


namespace SageFrame.PortalSetting
{
    public class PortalInfo
    {
        public int PortalID { get; set; }
        public string Name { get; set; }
        public string SEOName { get; set; }
        public bool IsParent { get; set; }
        public string DefaultPage { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public int ModuleID { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsPortalModuleActive { get; set; }
        public string ParentPortalName { get; set; }
        public PortalInfo() { }
    }
}
