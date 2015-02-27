/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace SageFrame.Dashboard
{
    public class QuickLink
    {
        public int QuickLinkID { get; set; }
        public string DisplayName { get; set; }
        public string URL { get; set; }
        public string ImagePath { get; set; }
        public int DisplayOrder { get; set; }
        public int PageID { get; set; }
        public bool IsActive { get; set; }

        public QuickLink() { }
    }
}
