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


namespace SageFrame.Core.SageFrame.Search
{
    public class SageFrameSearchInfo
    {
        public string PageName { get; set; }
        public string UserModuleTitle { get; set; }
        public string HTMLContent { get; set; }
        public string URL { get; set; }
        public string UpdatedContentOn { get; set; }
        public int RowTotal { get; set; }
        public string SearchWord { get; set; }

        public SageFrameSearchInfo() { }

    }
}
