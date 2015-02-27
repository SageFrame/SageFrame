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

namespace SageFrame.UserManagement
{
    public class ForgotPasswordInfo
    {
        public int MessageTemplateID{get;set;}
		public int MessageTemplateTypeID{get;set;}
		public string Subject{get;set;}
		public string Body{get;set;}
		public string MailFrom{get;set;}
		public bool IsActive{get;set;}
		public bool IsDeleted{get;set;}
		public bool IsModified{get;set;}
		public DateTime AddedOn{get;set;}
		public DateTime UpdatedOn{get;set;}
		public DateTime DeletedOn{get;set;}
		public int PortalID{get;set;}
		public string AddedBy{get;set;}
		public string UpdatedBy{get;set;}
		public string DeletedBy{get;set;}

        public Guid _UserActivationCode_ { get; set; }
        public string _Username_ { get; set; }
        public string _UserFirstName_ { get; set; }
        public string _UserLastName_ { get; set; }
        public string _UserEmail_ { get; set; }


        public Guid Code { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string CodeForPurpose { get; set; }
        public string CodeForUsername { get; set; }


          public bool IsAlreadyUsed { get; set; }

        public ForgotPasswordInfo(){}
      
		
    }
}
