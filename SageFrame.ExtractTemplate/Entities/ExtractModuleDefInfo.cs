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
    public class ExtractModuleDefInfo
    {

        public int ModuleDefID { get; set; }
        public string FriendlyName { get; set; }
        public int ModuleID { get; set; }
        public int DefaultCacheTime { get; set; }
        public int PortalID { get; set; }

        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }

        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        public ExtractUserModule UserModule { get; set; }
        //public Extra MyProperty { get; set; }
        public ExtractModuleDefInfo()
        {
        }
    }
}
