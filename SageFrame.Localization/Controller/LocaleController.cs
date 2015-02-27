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
using System.Globalization;
using SageFrame.Localization.Info;
#endregion

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

        public static List<LocalModuleInfo> GetLocalModuleTitle(int PortalID, string CultureCode)
        {
            try
            {
                return (LocalizationSqlDataProvider.GetLocalModuleTitle(PortalID, CultureCode));
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

        public static void AddUpdateLocalModuleTitle(List<LocalModuleInfo> lstLocalPage)
        {
            try
            {
                LocalizationSqlDataProvider.AddUpdateLocalModuleTitle(lstLocalPage);
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
