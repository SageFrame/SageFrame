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
using SageFrame.Pages;
using SageFrame.PagePermission;

namespace SageFrame.Pages
{
    public class PageEntity
    {
        #region "Private Members"

        int _pageID;
        int _pageOrder;
        string _pageName;
        bool _isVisible;
        int _parentID;
        int _level;
        string _iconFile;
        bool _disableLink;
        string _title;
        string _description;
        string _keyWords;
        string _url;
        string _tabPath;
        string _startDate;
        string _endDate;
        decimal _refreshInterval;
        string _pageHeadText;
        bool _isSecure;
        bool _isPublished;
        bool _isActive;
        bool _isDeleted;
        bool _isModified;
        string _addedOn;
        string _updatedOn;
        string _deletedOn;
        int _portalID;
        string _addedBy;
        string _updatedBy;
        string _deletedBy;
        string _sEOName;
        bool _isShowInFooter;
        bool _isRequiredPage;
        int _beforeID;
        int _afterID;
        string _viewPermissionRoles;
        string _editPermissionRoles;
        string _viewUsers;
        string _editUsers;
        string _prefix;
        int _childCount;
        string _pageNameWithoughtPrefix;
        private List<PagePermissionInfo> _lstPagePermission;

        #endregion

        #region "Public Properties"

        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        public int PageOrder
        {
            get { return _pageOrder; }
            set { _pageOrder = value; }
        }

        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string IconFile
        {
            get { return _iconFile; }
            set { _iconFile = value; }
        }

        public bool DisableLink
        {
            get { return _disableLink; }
            set { _disableLink = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string KeyWords
        {
            get { return _keyWords; }
            set { _keyWords = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string TabPath
        {
            get { return _tabPath; }
            set { _tabPath = value; }
        }

        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public decimal RefreshInterval
        {
            get { return _refreshInterval; }
            set { _refreshInterval = value; }
        }

        public string PageHeadText
        {
            get { return _pageHeadText; }
            set { _pageHeadText = value; }
        }

        public bool IsSecure
        {
            get { return _isSecure; }
            set { _isSecure = value; }
        }

        public bool IsPublished
        {
            get { return _isPublished; }
            set { _isPublished = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public bool IsModified
        {
            get { return _isModified; }
            set { _isModified = value; }
        }

        public string AddedOn
        {
            get { return _addedOn; }
            set { _addedOn = value; }
        }

        public string UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        public string DeletedOn
        {
            get { return _deletedOn; }
            set { _deletedOn = value; }
        }

        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }

        public string DeletedBy
        {
            get { return _deletedBy; }
            set { _deletedBy = value; }
        }

        public string SEOName
        {
            get { return _sEOName; }
            set { _sEOName = value; }
        }

        public bool IsShowInFooter
        {
            get { return _isShowInFooter; }
            set { _isShowInFooter = value; }
        }

        public bool IsRequiredPage
        {
            get { return _isRequiredPage; }
            set { _isRequiredPage = value; }
        }
        public int BeforeID
        {
            get { return _beforeID; }
            set { _beforeID = value; }
        }

        public int AfterID
        {
            get { return _afterID; }
            set { _afterID = value; }
        }

        public string ViewPermissionRoles
        {
            get { return _viewPermissionRoles; }
            set { _viewPermissionRoles = value; }
        }

        public string EditPermissionRoles
        {
            get { return _editPermissionRoles; }
            set { _editPermissionRoles = value; }
        }
        public string ViewUsers
        {
            get { return _viewUsers; }
            set { _viewUsers = value; }
        }
        public string EditUsers
        {
            get { return _editUsers; }
            set { _editUsers = value; }
        }
        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }
        public int ChildCount
        {
            get { return _childCount; }
            set { _childCount = value; }
        }
        public string PageNameWithoughtPrefix
        {
            get { return _pageNameWithoughtPrefix; }
            set { _pageNameWithoughtPrefix = value; }
        }


        
        public List<PagePermissionInfo> LstPagePermission
        {
            get { return _lstPagePermission; }
            set { _lstPagePermission = value; }
        }
        public string LevelPageName { get; set; }
        public int MaxPageOrder { get; set; }
        public int MinPageOrder { get; set; }
        public bool IsAdmin { get; set; }


        public string MenuList { get; set; }


        public string MenuPages {get;set;}
        #endregion
        public string Mode { get; set; }
        public string Caption { get; set; }
        public string UpdateLabel { get; set; }

        #region "Constructors"

        public PageEntity()
        {
        }

        public PageEntity(int pageID, int pageOrder, string pageName, bool isVisible, int parentID, int level, string iconFile, bool disableLink, string title, string description, string keyWords, string url, string tabPath, string startDate, string endDate, decimal refreshInterval, string pageHeadText, bool isSecure, bool isActive, bool isDeleted, bool isModified, string addedOn, string updatedOn, string deletedOn, int portalID, string addedBy, string updatedBy, string deletedBy, string sEOName, bool isShowInFooter, bool isRequiredPage)
        {
            this.PageID = pageID;
            this.PageOrder = pageOrder;
            this.PageName = pageName;
            this.IsVisible = isVisible;
            this.ParentID = parentID;
            this.Level = level;
            this.IconFile = iconFile;
            this.DisableLink = disableLink;
            this.Title = title;
            this.Description = description;
            this.KeyWords = keyWords;
            this.Url = url;
            this.TabPath = tabPath;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RefreshInterval = refreshInterval;
            this.PageHeadText = pageHeadText;
            this.IsSecure = isSecure;
            this.IsActive = isActive;
            this.IsDeleted = isDeleted;
            this.IsModified = isModified;
            this.AddedOn = addedOn;
            this.UpdatedOn = updatedOn;
            this.DeletedOn = deletedOn;
            this.PortalID = portalID;
            this.AddedBy = addedBy;
            this.UpdatedBy = updatedBy;
            this.DeletedBy = deletedBy;
            this.SEOName = sEOName;
            this.IsShowInFooter = isShowInFooter;
            this.IsRequiredPage = isRequiredPage;
        }
        #endregion
    }

}