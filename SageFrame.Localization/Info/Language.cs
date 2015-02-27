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

namespace SageFrame.Localization
{
    [Serializable]
    public class Language
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
        public string FallBackLanguage { get; set; }
        public string FallBackLanguageCode { get; set; }
        public string NativeName { get; set; }
        public string FlagPath { get; set; }
        private string _Language;
        public string LanguageN
        {
            get {return(_Language.Substring(0,_Language.IndexOf('('))); }
            set { _Language = value; }
        }
        private string _Country;
        public string Country
        {
            get {return(_Country.Substring(_Country.IndexOf('(')+1,_Country.Length-_Country.IndexOf('(')-2));}
            set {_Country=value; }
        }
            
        public Language() { }
        public Language(int languageid,string languagename,string languagecode)
        {
            this.LanguageID = languageid;
            this.LanguageName = languagename;
            this.LanguageCode = languagecode;
        }

        public Language(string languagename, string languagecode, string fallbacklanguage)
        {
            this.LanguageName = languagename;
            this.LanguageCode = LanguageCode;
            this.FallBackLanguage = fallbacklanguage;
        }

        public Language(string languagename, string languagecode, string fallbacklanguage,string fallbacklanguagecode)
        {
            this.LanguageName = languagename;
            this.LanguageCode = LanguageCode;
            this.FallBackLanguage = fallbacklanguage;
            this.FallBackLanguageCode = fallbacklanguagecode;
        }
    }
}
