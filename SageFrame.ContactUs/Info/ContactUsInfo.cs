using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.ContactUs
{
    public class ContactUsInfo
    {
        private int _ContactUsID;
		
		private string _Name;
		
		private string _Email;
		
		private string _Message;
		
		private System.Nullable<bool> _IsActive;
		
		private System.Nullable<bool> _IsDeleted;
		
		private System.Nullable<bool> _IsModified;
		
		private System.Nullable<System.DateTime> _AddedOn;
		
		private System.Nullable<System.DateTime> _UpdatedOn;
		
		private System.Nullable<System.DateTime> _DeletedOn;
		
		private System.Nullable<int> _PortalID;
		
		private string _AddedBy;
		
		private string _UpdatedBy;
		
		private string _DeletedBy;

        public ContactUsInfo()
		{
		}

        public int ContactUsID
        {
            get
            {
                return this._ContactUsID;
            }
            set
            {
                if ((this._ContactUsID != value))
                {
                    this._ContactUsID = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this._Email = value;
                }
            }
        }

        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if ((this._Message != value))
                {
                    this._Message = value;
                }
            }
        }

        public System.Nullable<bool> IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                if ((this._IsActive != value))
                {
                    this._IsActive = value;
                }
            }
        }

        public System.Nullable<bool> IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if ((this._IsDeleted != value))
                {
                    this._IsDeleted = value;
                }
            }
        }

        public System.Nullable<bool> IsModified
        {
            get
            {
                return this._IsModified;
            }
            set
            {
                if ((this._IsModified != value))
                {
                    this._IsModified = value;
                }
            }
        }

        public System.Nullable<System.DateTime> AddedOn
        {
            get
            {
                return this._AddedOn;
            }
            set
            {
                if ((this._AddedOn != value))
                {
                    this._AddedOn = value;
                }
            }
        }

        public System.Nullable<System.DateTime> UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                if ((this._UpdatedOn != value))
                {
                    this._UpdatedOn = value;
                }
            }
        }

        public System.Nullable<System.DateTime> DeletedOn
        {
            get
            {
                return this._DeletedOn;
            }
            set
            {
                if ((this._DeletedOn != value))
                {
                    this._DeletedOn = value;
                }
            }
        }

        public System.Nullable<int> PortalID
        {
            get
            {
                return this._PortalID;
            }
            set
            {
                if ((this._PortalID != value))
                {
                    this._PortalID = value;
                }
            }
        }

        public string AddedBy
        {
            get
            {
                return this._AddedBy;
            }
            set
            {
                if ((this._AddedBy != value))
                {
                    this._AddedBy = value;
                }
            }
        }

        public string UpdatedBy
        {
            get
            {
                return this._UpdatedBy;
            }
            set
            {
                if ((this._UpdatedBy != value))
                {
                    this._UpdatedBy = value;
                }
            }
        }

        public string DeletedBy
        {
            get
            {
                return this._DeletedBy;
            }
            set
            {
                if ((this._DeletedBy != value))
                {
                    this._DeletedBy = value;
                }
            }
        }
    }
}
