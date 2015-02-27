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
    public class SettingInfo
    {
        public string ActiveLayout { get; set; }
        public string ActiveTheme { get; set; }
        public string ActiveWidth { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string UserName { get; set; }
        public int PortalID { get; set; }
        public SettingInfo() { }
        public SettingInfo(string _ActiveLayout, string _ActiveTheme)
        {
            this.ActiveLayout = _ActiveLayout;
            this.ActiveTheme = _ActiveTheme;
        }

        public SettingInfo(string _SettingKey,string _UserName,int _PortalID)
        {
            this.SettingKey = _SettingKey;
            this.UserName=_UserName;
            this.PortalID = _PortalID;
        }
    }
}
