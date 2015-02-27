#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
#endregion

namespace SageFrame.Shared
{
    public class GoogleAnalyticsInfo
    {
        #region "Private Members"
        int _GoogleAnalyticsID;
        string _googleJSCode;
        bool _isActive;
        bool _isModified;
        DateTime _addedOn;
        DateTime _updatedOn;
        int _portalID;
        string _addedBy;
        string _updatedBy;
        #endregion

        #region "Constructors"
        public GoogleAnalyticsInfo()
        {
        }

        public GoogleAnalyticsInfo(int GoogleAnalyticsID, string googleJSCode, bool isActive, bool isModified, DateTime addedOn, DateTime updatedOn, int portalID, string addedBy, string updatedBy)
        {
            this.GoogleAnalyticsID = GoogleAnalyticsID;
            this.GoogleJSCode = googleJSCode;
            this.IsActive = isActive;
            this.IsModified = isModified;
            this.AddedOn = addedOn;
            this.UpdatedOn = updatedOn;
            this.PortalID = portalID;
            this.AddedBy = addedBy;
            this.UpdatedBy = updatedBy;
        }
        #endregion

        #region "Public Properties"
        public int GoogleAnalyticsID
        {
            get { return _GoogleAnalyticsID; }
            set { _GoogleAnalyticsID = value; }
        }

        public string GoogleJSCode
        {
            get { return _googleJSCode; }
            set { _googleJSCode = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public bool IsModified
        {
            get { return _isModified; }
            set { _isModified = value; }
        }

        public DateTime AddedOn
        {
            get { return _addedOn; }
            set { _addedOn = value; }
        }

        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
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
        #endregion
    }
}
