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


namespace SageFrame.Search
{
    public class SageFrameSearchProcedureInfo
    {
        #region "Private Members"
        int _sageFrameSearchProcedureID;
        string _sageFrameSearchTitle;
        string _sageFrameSearchProcedureName;
        string _sageFrameSearchProcedureExecuteAs;
        bool _isActive;
        bool _isDeleted;
        bool _isModified;
        DateTime _addedOn;
        DateTime _updatedOn;
        DateTime _deletedOn;
        int _portalID;
        string _addedBy;
        string _updatedBy;
        string _deletedBy;
        #endregion

        #region "Constructors"
        public SageFrameSearchProcedureInfo()
        {
        }

        public SageFrameSearchProcedureInfo(int sageFrameSearchProcedureID, string sageFrameSearchTitle, string sageFrameSearchProcedureName, string sageFrameSearchProcedureExecuteAs, bool isActive, bool isDeleted, bool isModified, DateTime addedOn, DateTime updatedOn, DateTime deletedOn, int portalID, string addedBy, string updatedBy, string deletedBy)
        {
            this.SageFrameSearchProcedureID = sageFrameSearchProcedureID;
            this.SageFrameSearchTitle = sageFrameSearchTitle;
            this.SageFrameSearchProcedureName = sageFrameSearchProcedureName;
            this.SageFrameSearchProcedureExecuteAs = sageFrameSearchProcedureExecuteAs;
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
        }
        #endregion

        #region "Public Properties"
        public int SageFrameSearchProcedureID
        {
            get { return _sageFrameSearchProcedureID; }
            set { _sageFrameSearchProcedureID = value; }
        }

        public string SageFrameSearchTitle
        {
            get { return _sageFrameSearchTitle; }
            set { _sageFrameSearchTitle = value; }
        }

        public string SageFrameSearchProcedureName
        {
            get { return _sageFrameSearchProcedureName; }
            set { _sageFrameSearchProcedureName = value; }
        }

        public string SageFrameSearchProcedureExecuteAs
        {
            get { return _sageFrameSearchProcedureExecuteAs; }
            set { _sageFrameSearchProcedureExecuteAs = value; }
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

        public DateTime DeletedOn
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
        #endregion
    }
}
