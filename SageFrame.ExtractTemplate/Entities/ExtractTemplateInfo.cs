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
    public class ExtractTemplateInfo
    {
        public int PageID { get; set; }
        public int RowNum { get; set; }
        public string PaneName { get; set; }
        public int UserModuleId { get; set; }
        public int IsCore { get; set; }
        public int ModuleOrder { get; set; }
        public int ModuleDefId { get; set; }
        public string FriendlyName { get; set; }
        public int ModuleID { get; set; }
        public bool IsActive { get; set; }
        public string ShowInPages { get; set; }

        public ExtractTemplateInfo()
        {
        }
    }
}
