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

namespace SageFrame.ExtractTemplate
{
    public class TemplateMenuSettingValue
    {
        public int MenuMgrSettingValueID { get; set; }
        public string MenuName { get; set; }
        public int MenuID { get; set; }
        public string SettingKey { get; set; }
        public int SettingValue { get; set; }
        public TemplateMenuSettingValue(){}

    }
}
