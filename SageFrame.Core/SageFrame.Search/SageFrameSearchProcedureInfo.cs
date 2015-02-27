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
