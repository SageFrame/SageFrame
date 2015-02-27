using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.Localization.Info
{
    public class LocalModuleInfo
    {
        public int UserModuleID { get; set; }
        public int PortalID { get; set; }
        public string UserModuleTitle { get; set; }
        public string LocalModuleTitle { get; set; }
        public string CultureCode { get; set; }
        public string UserModules { get; set; }

        public LocalModuleInfo() { }
    }
}
