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


   [Serializable]
    public class ControlInfo
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string HelpUrl { get; set; }
        public string SupportSpatial { get; set; }
        public string Src { get; set; }
    }

