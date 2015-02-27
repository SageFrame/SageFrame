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

namespace SageFrame.SEOExtension
{
    public class RobotsInfo
    {


       
        public string PageName { get; set; }
        public string TabPath { get; set; }
        public string SEOName { get; set; }
        public string Description { get; set; }
        public string UserAgent { get; set; }
        public int PortalID { get; set; }
        public string PagePath { get; set; }             
        public RobotsInfo() { }
        
        public RobotsInfo(string PageName, string TabPath, string SEOName, string Description) 
        {
            this.TabPath = TabPath;

        }

        public RobotsInfo(int PortalID, string UserAgent, string PagePath) 
        {
            this.PortalID = PortalID;
            this.UserAgent = UserAgent;
            this.PagePath = PagePath;

        }
    }
}
