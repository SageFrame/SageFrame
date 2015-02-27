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
using SageFrame.Web.Utilities;
#endregion

namespace SageFrame.PortalManagement
{
    public class PortalMgrDataProvider
    {
        public static void AddPortal(string PortalName, bool IsParent, string UserName, string TemplateName,int ParentPortal,string PSEOName)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalName", PortalName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsParent", IsParent));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@TemplateName", TemplateName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", UserName));

            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalParentID", ParentPortal));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PSEOName", PSEOName));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("sp_PortalAdd", ParaMeterCollection);


        }
        public static void UpdatePortal(int PortalID, string PortalName, bool IsParent, string UserName, string TemplateName)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalName", PortalName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsParent", IsParent));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", UserName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@TemplateName", TemplateName));

            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("[sp_PortalUpdate]", ParaMeterCollection);


        }
        public int AddStoreSubscriber(string storeName, string firstName, string lastName, string email, string companyName, bool? contact, bool? isParent, string username,
           string password, string passwordSalt, int? passwordFormat, bool? isFromFront)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@StoreName", storeName));
            
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@FirstName", firstName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@LastName", lastName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Email", email));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@CompanyName", companyName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Contact", contact));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsParent", isParent));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", username));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Password", password));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PasswordSalt", passwordSalt));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PasswordFormat", passwordFormat));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsFromFront", isFromFront));
            SQLHandler sagesql = new SQLHandler();            
            int i = sagesql.ExecuteNonQuery("[usp_Aspx_AddStoreSubscriber]", ParaMeterCollection, "@CustomerID");
            return i;
        }
    }
}
