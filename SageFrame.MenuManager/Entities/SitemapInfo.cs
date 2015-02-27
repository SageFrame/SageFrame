﻿#region "Copyright"
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

namespace SageFrame.Pages
{
    public class SitemapInfo
    {
        public string PageName { get; set; }
        public string TabPath { get; set; }
        public string PortalName { get; set; }
        public int PortalID { get; set; }
        public string  UpdatedOn { get; set; }
        public string AddedOn { get; set; }

        public SitemapInfo() { }

    }
}
