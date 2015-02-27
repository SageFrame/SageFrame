/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
