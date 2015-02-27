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
    public class ExtractPageInfo
    {
        public int PageID { get; set; }
        public int PageOrder { get; set; }
        public int Isvisible { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public int PortalID { get; set; }


        public bool DisableLink { get; set; }
        public bool IsSecure { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public bool IsShowInFooter { get; set; }
        public bool IsRequiredPage { get; set; }

        public string PageName { get; set; }
        public string IconFile { get; set; }
        public string PageHeadText { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string Url { get; set; }
        public string TabPath { get; set; }
        public string Title { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string SEOName { get; set; }
        

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }


        public List<ExtractModuleInfo> ModuleList { get; set; }
        public List<PagePermission> PagePermissionList { get; set; }

        public float RefreshInterval { get; set; }

        public ExtractPageInfo()
        {
        }
    }
}
