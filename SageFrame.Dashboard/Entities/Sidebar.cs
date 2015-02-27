/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace SageFrame.Dashboard
{
    public class Sidebar
    {
        public int SidebarItemID { get; set; }
        public string DisplayName { get; set; }
        public string ImagePath { get; set; }
        public string URL { get; set; }
        public int Depth { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int ParentID { get; set; }
        public int ChildCount { get; set; }
        public int PageID { get; set; }       
        
        public Sidebar() { }
    }

    public class DisplayOrder
    {
        public string ID { get; set; }
        public string Order { get; set; }
        public DisplayOrder() { }
    }
}
