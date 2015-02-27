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

namespace SageFrame.ExtractTemplate
{
    public class TemplatePermission
    {
        public int UserModuleID { get; set; }
        public int AllowAccess { get; set; }
        public string RoleName { get; set; }
        public int PermissionID { get; set; }
        public TemplatePermission() { }
        
    }
}
