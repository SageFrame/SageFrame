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
    public class ModulePermissionInfo
    {
        public int PermissionID { get; set; }
        public string RoleID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool AllowAccess { get; set; }

        public ModulePermissionInfo() { }

    }
}
