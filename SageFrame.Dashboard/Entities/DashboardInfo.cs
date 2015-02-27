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

namespace SageFrame.Dashboard
{
    public class DashboardInfo
    {

        public int PageID { get; set; }
        public int PageOrder { get; set; }
        
        public string PageName { get; set; }
        public string Url { get; set; }
        public string IconFile { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string TabPath { get; set; }


        public DashboardInfo() { }

       
    }
}
