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
    public class FolderPermission
    {
        public int FolderPermissionID { get; set; }
        public int FolderID { get; set; }
        public int UserID { get; set; }
        public Guid RoleID { get; set; }
        public string PermissionKey { get; set; }
        public int PermissionID { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string AddedBy { get; set; }

        public FolderPermission() { }
    }
}
