/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.BreadCrum
{
    public class BreadCrumInfo
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public string TabPath { get; set; }
        public string SEOName { get; set; }
        public string LocalPage { get; set; }

        public BreadCrumInfo() { }

    }
}
