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
    public class LayoutMgrInfo
    {
        public string ModuleID { get; set; }
        public string FriendlyName { get; set; }
        public string ModuleOrder { get; set; }
        public int PortelID { get; set; }
        public int  ModuleDefID { get; set; }

        public int UserModuleID { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string PaneName { get; set; }
        public string NewModuleID { get; set; }

        public LayoutMgrInfo() { }
    }
}
