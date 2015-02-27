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
    public class ExtractUserModule
    {

        public int PageID { get; set; }
        public string PaneName { get; set; }
        public int UserModuleId { get; set; }
        public int ModuleOrder { get; set; }
        public bool IsActive { get; set; }
        public string ShowInPages { get; set; }
        public string UserModuleTitle { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string SEOName { get; set; }
        public string SuffixClass { get; set; }
        public string HeaderText { get; set; }
        public string Query { get; set; }
        public bool AllPages { get; set; }
        public bool InheritViewPermissions { get; set; }
        public bool IsHandheld { get; set; }
        public bool ShowHeaderText { get; set; }
        public bool IsInAdmin { get; set; }
        public int Level { get; set; }
        
        public List<TemplatePermission> TemplatePermission { get; set; }
        public ExtractUserModule()
        {
        }
    }
}
