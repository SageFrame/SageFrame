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

namespace SageFrame.ModuleControls
{
    public class ModuleControlInfo
    {
        public string UserModuleID { get; set; }
        public string ModuleDefID { get; set; }
        public string ControlTitle { get; set; }
        public string ControlType { get; set; }
        public string ControlSrc { get; set; }
            
        public ModuleControlInfo() { }
    }
}
