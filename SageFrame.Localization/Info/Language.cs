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
            get { return (_Language.Substring(0, _Language.IndexOf('('))); }
            set { _Language = value; }
        }
        private string _Country;
        public string Country
        {
            get { return (_Country.Substring(_Country.IndexOf('(') + 1, _Country.Length - _Country.IndexOf('(') - 2)); }
            set { _Country = value; }
        }

        public Language() { }
        public Language(int languageid, string languagename, string languagecode)
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
        public Language(string languagename, string languagecode, string fallbacklanguage, string fallbacklanguagecode)
        {
            this.LanguageName = languagename;
            this.LanguageCode = LanguageCode;
            this.FallBackLanguage = fallbacklanguage;
            this.FallBackLanguageCode = fallbacklanguagecode;
        }
    }
}
