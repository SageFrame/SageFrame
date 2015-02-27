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

namespace SageFrame.Localization
{
    public class LocalPageInfo
    {
        public int ID { get; set; }
        public int PageID { get; set; }
        public string LocalPageName { get; set; }
        public string PageName { get; set; }
        public string  CultureCode { get; set; }
        public string LocalPageCaption { get; set; }
        public LocalPageInfo() { }

        public LocalPageInfo(int PageID, string LocalPageName, string CultureCode)
        {
            this.PageID = PageID;
            this.LocalPageName = LocalPageName;
            this.CultureCode = CultureCode;
        }
    }
}
