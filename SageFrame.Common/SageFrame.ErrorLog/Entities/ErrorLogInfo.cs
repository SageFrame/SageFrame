#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace SageFrame.ErrorLog
{
    public class ErrorLogInfo
    {
   
        public int LogID { get; set; }
        public int LogTypeID { get; set; }
        public int Severity { get; set; }
        
        public string Message { get; set; }
        public string Exception { get; set; }
        public string ClientIPAddress { get; set; }
       
        public string PageURL { get; set; }
        public bool IsActive { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }


        public ErrorLogInfo() { }


       
    }
}
