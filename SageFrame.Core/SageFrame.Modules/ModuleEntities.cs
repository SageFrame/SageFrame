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


namespace SageFrame.Modules
{
    public class ModuleEntities
    {
        public int ModuleControlID { get; set; }
        public int ModuleDefID { get; set; }
        public string ControlKey { get; set; }
        public string ControlTitle { get; set; }
        public string ControlSrc { get; set; }
        public string IconFile { get; set; }
        public int ControlType { get; set; }
        public int DisplayOrder { get; set; }
        public string HelpUrl { get; set; }
        public bool SupportsPartialRendering { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public ModuleEntities() { }
    }
}
