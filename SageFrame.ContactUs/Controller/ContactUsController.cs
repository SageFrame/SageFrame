using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web;
using SageFrame.Framework;
using SageFrame.ContactUs;
using SageFrame.Message;
using SageFrame.SageFrameClass.MessageManagement;

namespace SageFrame.ContactUs
{
    public class ContactUsController
    {

        public void ContactUsAdd(string name, string email, string subject, string message, bool isActive, int portalID, string addedBy)
        {
            try
            {
                ContactUsDataProvider contactProvider = new ContactUsDataProvider();
                contactProvider.ContactUsAdd(name, email, message, isActive, portalID, addedBy);
                SageFrameConfig pagebase = new SageFrameConfig();
                string emailSuperAdmin = pagebase.GetSettingValueByIndividualKey(SageFrameSettingKeys.SuperUserEmail);
                string emailSiteAdmin = pagebase.GetSettingValueByIndividualKey(SageFrameSettingKeys.SiteAdminEmailAddress);
                MailHelper.SendMailNoAttachment(email, emailSiteAdmin, subject, email, emailSuperAdmin, string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ContactUsDeleteByID(int contactUsID, int portalID, string deletedBy)
        {
            try
            {
                ContactUsDataProvider contactProvider = new ContactUsDataProvider();
                contactProvider.ContactUsDeleteByID(contactUsID, portalID, deletedBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactUsInfo> ContactUsGetAll(int portalID)
        {
            try
            {
                ContactUsDataProvider contactProvider = new ContactUsDataProvider();
                return (contactProvider.ContactUsGetAll(portalID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
