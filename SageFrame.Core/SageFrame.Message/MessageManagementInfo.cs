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


namespace SageFrame.Message
{
    public class MessageManagementInfo
    {
        public int MessageTemplateTypeID { get; set; }
        public int MessageTemplateID { get; set; }
        public string Name { get; set; }
        public string CultureName { get; set; }
        public string Subject { get; set; }
        public string MailFrom { get; set; }
        public string Body { get; set; }


        public int MessageTemplateTypeTokenID { get; set; }
        public int MessageTokenID { get; set; }

        public string MessageTokenKey { get; set; }
        public string MessageTokenName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        
		
        public MessageManagementInfo() { }
    }
}
