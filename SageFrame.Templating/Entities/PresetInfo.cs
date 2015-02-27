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

namespace SageFrame.Templating
{
    public class PresetInfo
    {
        public string PresetName { get; set; }
        public string ActiveTheme { get; set; }
        public string ActiveLayout { get; set; }
        public string ActiveWidth { get; set; }
        public bool IsCssOptimizationEnabled { get; set; }
        public bool IsJsOptimizationEnabled { get; set; }
        public string Pages { get; set; }
        public List<string> LSTPages { get; set; }
        public bool CPanel { get; set; }
        public bool HandHeld { get; set; }
        public bool IsDefault { get; set; }
        public string HandHeldLayout { get; set; }
        public List<KeyValue> lstLayouts { get; set; }
        public List<string> lstPages { get; set; }
        public PresetInfo GetPresetObject(string _PresetName)
        {
            return new PresetInfo
            {
                PresetName=_PresetName
            };
        }

        public static PresetInfo GetPresetPages(string _PresetName, string _Pages)
        {
            return new PresetInfo
            {
                PresetName=_PresetName,
                Pages=_Pages
            };
        }

        public static List<string> GetPresetSettings()
        {
            List<string> presetCols = new List<string>();
            presetCols.Add("activelayout");
            presetCols.Add("activetheme");
            presetCols.Add("activewidth");
            presetCols.Add("cssopt");
            presetCols.Add("jsopt");
            presetCols.Add("cpanel");
            presetCols.Add("handheld");
            presetCols.Add("handheldlayout");
            return presetCols;
        }

    }
}
