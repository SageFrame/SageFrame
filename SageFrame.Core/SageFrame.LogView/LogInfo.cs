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


namespace SageFrame.LogView
{
    public class LogInfo
    {
        public int LogTypeID { get; set; }
        public string Name { get; set; }
        public int LogID { get; set; }
        public DateTime AddedOn { get; set; }
        public string LogTypeName { get; set; }
        public string PortalName { get; set; }
        public string ClientIPAddress { get; set; }
        public string PageURL { get; set; }
        public string Exception { get; set; }

    }
}
