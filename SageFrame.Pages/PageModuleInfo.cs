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

namespace SageFrame.Pages
{   
   public class PageModuleInfo
    {
       public int UserModuleID { get; set; }
       public string UserModuleTitle { get; set; }
       public string PaneName { get; set; }
       public int _RowTotal { get; set; }
       public PageModuleInfo() { }
       
    }
}
