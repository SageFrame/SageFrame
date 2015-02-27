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

namespace SageFrame.ExtractTemplate
{
    public class ExtractModuleInfo
    {
        public int ModuleID { get; set; }
        public int SupportedFeatures { get; set; }
        public int PackageID { get; set; }
        public string Description { get; set; }
        public string FriendlyName { get; set; }
        public string Version { get; set; }
        public string BusinessControllerClass { get; set; }
        public string FolderName { get; set; }
        public string Permissions { get; set; }
        public string ModuleName { get; set; }
        public string CompatibleVersions { get; set; }
        public string Dependencies { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }

        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }

        public ExtractModuleDefInfo ModuleDef { get; set; }
        public ExtractModuleInfo()
        {
        }
    }
}
