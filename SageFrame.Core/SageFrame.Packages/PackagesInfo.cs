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
    public class PackagesInfo
    {
        public int PackageID { get; set; }

        public int PortalID { get; set; }

        public int ModuleID { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public string Description { get; set; }

        public string PackageType { get; set; }

        public string Version { get; set; }

        public string License { get; set; }

        public string Manifest { get; set; }

        public string Owner { get; set; }

        public string Organization { get; set; }

        public string Url { get; set; }

        public string Email { get; set; }

        public string ReleaseNotes { get; set; }

        public bool IsSystemPackage { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsModified { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public string AddedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string DeletedBy { get; set; }

        public int InUse { get; set; }

        public bool IsAdmin { get; set; }
        public PackagesInfo() { }
    }
}
