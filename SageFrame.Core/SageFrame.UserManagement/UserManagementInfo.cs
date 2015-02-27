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
    public class UserManagementInfo
    {
        public string UserName { get; set; }
        public int MessageTemplateID { get; set; }
        public int MessageTemplateTypeID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailFrom { get; set; }

        public UserManagementInfo() { }
    }
}
