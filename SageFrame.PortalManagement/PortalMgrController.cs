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

namespace SageFrame.PortalManagement
{
    public class PortalMgrController
    {
        public static void AddPortal(string PortalName, bool IsParent, string UserName, string TemplateName,int ParentPortal,string  PSEOName)
        {
            try
            {
                PortalMgrDataProvider.AddPortal(PortalName, IsParent, UserName, TemplateName, ParentPortal, PSEOName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdatePortal(int PortalID, string PortalName, bool IsParent, string UserName, string TemplateName)
        {
            try
            {
                PortalMgrDataProvider.UpdatePortal(PortalID, PortalName, IsParent, UserName, TemplateName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int AddStoreSubscriber(string storeName, string firstName, string lastName, string email, string companyName,
          System.Nullable<bool> contact, System.Nullable<bool> isParent, string username, string password,
          string passwordSalt, System.Nullable<int> passwordFormat, System.Nullable<bool> isFromFront)
        {
            try
            {
                PortalMgrDataProvider pmdp = new PortalMgrDataProvider();
                int i = pmdp.AddStoreSubscriber(storeName, firstName, lastName, email, companyName,
             contact, isParent, username, password, passwordSalt, passwordFormat, isFromFront);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
