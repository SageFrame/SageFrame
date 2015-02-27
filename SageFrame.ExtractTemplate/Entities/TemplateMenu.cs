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
    public class TemplateMenu
    {
        public int UserModuleID { get; set; }
        public int MenuItemID { get; set; }
        public int MenuID { get; set; }
        public int LinkType { get; set; }
        public int PageID { get; set; }
        public int MenuLevel { get; set; }
        public int MenuOrder { get; set; }
        public bool Isvisible { get; set; }
        public bool IsActive{ get; set; }
        public string LinkURL { get; set; }
        public string ImageIcon { get; set; }
        public string Caption { get; set; }
        public string HtmlContent { get; set; }
        public string Title { get; set; }
        public string MenuName { get; set; }
        public int ParentID { get; set; }

        public TemplateMenu(){}
    }
}
