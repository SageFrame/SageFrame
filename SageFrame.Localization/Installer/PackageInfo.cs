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

  [Serializable]
    public class PackageInfo
    {
        #region Properties
        public string PackageName { get; set; }
        public string PackageType { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string ManifestFile { get; set; }
        public string Version { get; set; }
        public string OwnerName { get; set; }
        public string Organistaion { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        private string _ReleaseNotes;
        public string ReleaseNotes { get { return (_ReleaseNotes); } set {_ReleaseNotes=value ;} }
        private string _License;
        public string License { get { return (_License); } set { _License = value; } }
        private string _TempFolderPath;
        public string TempFolderPath { get { return (_TempFolderPath); } set {_TempFolderPath=value ;} }
        private string _InstalledFolderPath;
        public string InstalledFolderPath { get { return (_InstalledFolderPath); } set {_InstalledFolderPath=value;} }
        public string FolderName { get; set; }
        #endregion
        public PackageInfo() { }

    }

