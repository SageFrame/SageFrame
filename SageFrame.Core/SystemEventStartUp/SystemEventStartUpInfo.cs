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


namespace SageFrame.Core
{
    public class SystemEventStartUpInfo
    {
        public int PortalStartUpID { get; set; }
        public int PortalID { get; set; }       
        public string EventLocationName { get; set; }        
        public string ControlUrl { get; set; }      
        public bool IsAdmin { get; set; }
        public bool IsControlUrl { get; set; }
        public bool IsSystem { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
       
        
        public SystemEventStartUpInfo() { }

    }

    public class GetPortalStartUpList
    {
        public int PortalStartUpID { get; set; }
        public int PortalID { get; set; }
        public string EventLocationName { get; set; }
        public string ControlUrl { get; set; }        
        public GetPortalStartUpList()
        {
        }
    }

    public enum SystemEventLocation
    {
        Top = 1,
        Middle = 2,
        Bottom = 3
    }
}
