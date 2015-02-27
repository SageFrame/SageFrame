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

namespace SageFrame.FileManager
{
    public class Roles
    {
        public int ApplicationID { get; set; }
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public Roles() { }
    }
}
