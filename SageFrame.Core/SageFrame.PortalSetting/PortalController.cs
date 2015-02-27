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


namespace SageFrame.PortalSetting
{
    public class PortalController
    {
        public static List<PortalInfo> GetPortalList()
        {
            try
            {
                return PortalProvider.GetPortalList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static PortalInfo GetPortalByPortalID(int PortalID, string UserName)
        {
            try
            {
                return PortalProvider.GetPortalByPortalID(PortalID, UserName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeletePortal(int PortalID, string UserName)
        {
            try
            {
                PortalProvider.DeletePortal(PortalID, UserName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdatePortal(int PortalID, string PortalName, bool IsParent, string UserName, string PortalURL, int ParentID)
        {
            try
            {
                PortalProvider.UpdatePortal(PortalID, PortalName, IsParent, UserName, PortalURL, ParentID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<PortalInfo> GetPortalModulesByPortalID(int PortalID, string UserName)
        {
            try
            {
                return PortalProvider.GetPortalModulesByPortalID(PortalID, UserName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdatePortalModules(string ModuleIDs, string IsActives, int PortalID, string UpdatedBy)
        {
            try
            {
                PortalProvider.UpdatePortalModules(ModuleIDs, IsActives, PortalID, UpdatedBy);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PortalInfo> GetParentPortalList()
        {
            try
            {
                PortalProvider objProvider = new PortalProvider();
                return objProvider.GetParentPortalList();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
