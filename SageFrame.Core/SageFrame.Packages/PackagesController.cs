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


namespace SageFrame.Packages
{
    public class PackagesController
    {
        public void UpdatePackagesChange(string ModuleIDs, string IsActives, string UpdatedBy)
        {
            try
            {
                PackagesProvider.UpdatePackagesChange(ModuleIDs, IsActives, UpdatedBy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<PackagesInfo> GetPackagesByPortalID(int PortalID, string SearchText)
        {
            try
            {
                return PackagesProvider.GetPackagesByPortalID(PortalID, SearchText);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
