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
    #region "Countries"
    public class Countries
    {
        public string ImagePath { get; set; }
        public string CountryName { get; set; }
        public string CultureCode { get; set; }
        public Countries(string imagepath, string countryname, string culturecode)
        {
            this.ImagePath = imagepath;
            this.CountryName = countryname;
            this.CultureCode = culturecode;
        }
    }
    #endregion

    #region "Languages"
    public class FallBackLanguages
    {
        public string CultureName { get; set; }
        public string CultureInfo { get; set; }
        public string ImagePath { get; set; }
        public FallBackLanguages(string culturename, string cultureinfo, string imagepath)
        {
            this.CultureName = culturename;
            this.CultureInfo = cultureinfo;
            this.ImagePath = imagepath;
        }
    }
    #endregion

}
