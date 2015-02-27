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

namespace SageFrame.MenuManager
{
   
        public class MenuPermissionInfo
        {
            #region Private Members

            private int _menuID;
            private int _portalID;
            private int _permissionID;
            private string _roleID;
            private string _username;
            private bool _allowAccess;
            private bool _isActive;
            private string _addedBy;

            #endregion

            #region Public Members

            public int MenuID
            {
                get { return _menuID; }
                set { _menuID = value; }
            }
            public int PortalID
            {
                get { return _portalID; }
                set { _portalID = value; }
            }
            public int PermissionID
            {
                get { return _permissionID; }
                set { _permissionID = value; }
            }
            public string RoleID
            {
                get { return _roleID; }
                set { _roleID = value; }
            }
            public string Username
            {
                get { return _username; }
                set { _username = value; }
            }
            public bool AllowAccess
            {
                get { return _allowAccess; }
                set { _allowAccess = value; }
            }
            public bool IsActive
            {
                get { return _isActive; }
                set { _isActive = value; }
            }
            public string AddedBy
            {
                get { return _addedBy; }
                set { _addedBy = value; }
            }

            //public int PageID { get; set; }

            //public int PortalID { get; set; }

            //public int PermissionID { get; set; }

            //public string RoleID { get; set; }

            //public string Username { get; set; }

            //public bool AllowAccess { get; set; }

            //public bool IsActive { get; set; }

            //public bool AddedBy { get; set; }

            #endregion

            public MenuPermissionInfo()
            {
            }
        }
    
}
