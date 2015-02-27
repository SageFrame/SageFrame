#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
#endregion

namespace SageFrame.Common
{
    [Serializable]
    public class CssScriptInfo
    {
        public int Index { get; set; }
        public string ModuleName { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public int MyProperty { get; set; }
        public bool AllowOptimization { get; set; }
        public bool AllowCombination { get; set; }
        public int Position { get; set; }
        public int LoadingMode { get; set; }
        public bool IsHandheld { get; set; }
        public bool PathMode { get; set; }
        public bool IsCompress { get; set; }
        public bool IsCDN { get; set; }
        public bool IsJs { get; set; }
        public ResourceType rtype { get; set; }


        public CssScriptInfo(string _ModuleName, string _FileName, string _Path, int _Position)
        {
            this.ModuleName = _ModuleName;
            this.FileName = _FileName;
            this.Path = _Path;
            this.Position = _Position;

        }
        public CssScriptInfo(string _ModuleName, string _FileName, string _Path, int _Position, bool _AllowOptimization)
        {
            this.ModuleName = _ModuleName;
            this.FileName = _FileName;
            this.Path = _Path;
            this.Position = _Position;
            this.AllowOptimization = _AllowOptimization;

        }
        public CssScriptInfo(string _ModuleName, string _FileName)
        {
            this.ModuleName = _ModuleName;
            this.FileName = _FileName;
        }
        public CssScriptInfo(string _ModuleName, string _Path, int _Position, bool _IsCDN, bool _IsJs)
        {
            this.ModuleName = _ModuleName;
            this.Path = _Path;
            this.Position = _Position;
            this.IsCDN = _IsCDN;
            this.IsJs = _IsJs;

        }

    }
}
