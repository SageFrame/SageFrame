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
using System.Globalization;

namespace SageFrame.Localization
{
    public class LocaleController
    {
        public static List<Language> GetCultures()
        {
            List<Language> lstLocales = new List<Language>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                Language obj = new Language();
                obj.LanguageCode = ci.Name;
                obj.LanguageName = ci.EnglishName;
                obj.NativeName = ci.NativeName;
                lstLocales.Add(obj);
            }
            return lstLocales;
        }

        public static List<Language> AddNativeNamesToList(List<Language> lstEnglishNames)
        {
            List<Language> lstWithNativeNames = GetCultures();
            foreach (Language obj in lstEnglishNames)
            {
                int index = lstWithNativeNames.FindIndex(
                    delegate(Language newObj)
                    {
                        return (newObj.LanguageCode == obj.LanguageCode);
                    }
                  );
                if (index > -1)
                {
                    obj.NativeName = lstWithNativeNames[index].NativeName;
                }
            }
            return lstEnglishNames;
        }

        public static string GetLanguageNameFromCode(string code)
        {
            string langugeFullName = code;
            List<Language> lstLanguage = GetCultures();
            int index = lstLanguage.FindIndex(
                delegate(Language obj)
                {
                    return (obj.LanguageCode == code);
                }
                );
            if (index > -1)
            {
                langugeFullName = lstLanguage[index].LanguageName + "(" + code + ")";
            }
            return langugeFullName;
        }
        public static string GetCodeFromLanguageName(string languageName)
        {
            string code = languageName;
            List<Language> lstLanguage = GetCultures();
            int index = lstLanguage.FindIndex(
                delegate(Language obj)
                {
                    return (obj.LanguageName ==languageName);
                }
                );
            if (index > -1)
            {
                code = lstLanguage[index].LanguageCode;
            }
            return code;
        }
        public static string GetLanguageNameOnly(string code)
        {
            string langugeFullName = code;
            List<Language> lstLanguage = GetCultures();
            int index = lstLanguage.FindIndex(
                delegate(Language obj)
                {
                    return (obj.LanguageCode == code);
                }
                );
            if (index > -1)
            {
                langugeFullName = lstLanguage[index].LanguageName;
            }
            return langugeFullName;
        }

        public static void AddLanguageSwitchSettings(List<LanguageSwitchKeyValue> lstKeyValue,int UserModuleID,int PortalID)
        {
            try
            {
                LocalizationSqlDataProvider.AddLanguageSwitchSettings(lstKeyValue,UserModuleID,PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<LanguageSwitchKeyValue> GetLanguageSwitchSettings(int portalId,int UserModuleID)
        {
            try
            {
                return (LocalizationSqlDataProvider.GetLanguageSwitchSettings(portalId, UserModuleID));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<LocalPageInfo> GetLocalPageName(int PortalID, string CultureCode)
        {
            try
            {
                return (LocalizationSqlDataProvider.GetLocalPageName(PortalID, CultureCode));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddUpdateLocalPage(List<LocalPageInfo> lstLocalPage)
        {
            try
            {
                LocalizationSqlDataProvider.AddUpdateLocalPage(lstLocalPage);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteLanguage(string code)
        {
            try
            {
                LocalizationSqlDataProvider.DeleteLanguage(code);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
