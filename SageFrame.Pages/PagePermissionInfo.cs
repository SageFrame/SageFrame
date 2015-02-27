/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.PagePermission
{
   public class PagePermissionInfo
    {
        #region Private Members

        private int _pageID;
        private int _portalID;
        private int _permissionID;
        private string _roleID;
        private string _username;
        private bool _allowAccess;
        private bool _isActive;
        private string _addedBy;

        #endregion

        #region Public Members

        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
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

        public PagePermissionInfo()
        {
        }
    }
}
