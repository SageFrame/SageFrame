using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.SEOExtension
{
    public class SiteMapInfo
    {
        public string PageID { get; set; }
        public string PageName { get; set; }
        public string TabPath { get; set; }
        public string SEOName { get; set; }
        public string LevelPageName { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime AddedOn { get; set; }

        public string ChangeFreq { get; set; }
       
        public SiteMapInfo() { }

        public SiteMapInfo(string PageID, string PageName, string TabPath, string SEOName, string LevelPageName, string Description, DateTime UpdatedOn,DateTime AddedOn) 
        {
            this.PageID = PageID;
            this.PageName = PageName;
            this.TabPath = TabPath;
            this.SEOName = SEOName;
            this.LevelPageName = LevelPageName;
            this.Description = Description;
            this.UpdatedOn = UpdatedOn;
            this.AddedOn = AddedOn;
        
        }

    }
}
