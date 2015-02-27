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
    public class LanguageSwitchKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
        public LanguageSwitchKeyValue() { }
        public LanguageSwitchKeyValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
