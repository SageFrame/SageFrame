using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.ContactUs
{
    public class ContactUsDataProvider
    {
        public void ContactUsAdd(string name, string email, string message, bool isActive, int portalID, string addedBy)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Name", name));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Email", email));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Message", message));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", isActive));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", addedBy));
            SQLHandler sqlH = new SQLHandler();
            sqlH.ExecuteNonQuery("sp_ContactUsAdd", ParaMeterCollection);
        }

        public void ContactUsDeleteByID(int contactUsID, int portalID, string deletedBy)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ContactUsID", contactUsID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DeletedBy", deletedBy));
            SQLHandler sqlH = new SQLHandler();
            sqlH.ExecuteNonQuery("sp_ContactUsDeletebyID", ParaMeterCollection);
        }

        public List<ContactUsInfo> ContactUsGetAll(int portalID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
            SQLHandler sqlH = new SQLHandler();
            return sqlH.ExecuteAsList<ContactUsInfo>("sp_ContactUsGetAll", ParaMeterCollection);
        }
    }
}
