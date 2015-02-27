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

    public class ResourceDefinition
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public ResourceDefinition() { }
    }
}
