using System;
using System.Collections.Generic;
using System.Text;
using SageFrame.Web;
using System.Web;

namespace SageFrame.Common
{
    public partial class PortalAPI
    {

        # region "Page Name With Extension only"

        public static string RegistrationPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalRegistrationPage);
            }
        }
        public static string LoginPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalLoginpage);
            }
        }
        public static string DefaultPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalDefaultPage);
            }
        }
        public static string ProfilePageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalUserProfilePage);
            }
        }
        public static string ForgotPasswordPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalForgotPassword);
            }
        }
        public static string PageNotFoundPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalPageNotFound);
            }
        }

        public static string PasswordRecoveryPageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalPasswordRecovery);
            }
        }

        public static string PageNotAccessiblePageWithExtension
        {
            get
            {
                return BuildPageNameWithExtension(SageFrameSettingKeys.PortalPageNotAccessible);
            }
        }
        #endregion
        #region "WithOut Root URL"

        public static string RegistrationURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalRegistrationPage, false);
            }
        }
        public static string LoginURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalLoginpage, false);
            }
        }
        public static string DefaultPageURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalDefaultPage, false);
            }
        }
        public static string ProfilePageURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalUserProfilePage, false);
            }
        }
        public static string ForgotPasswordURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalForgotPassword, false);
            }
        }
        public static string PageNotFoundURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPageNotFound, false);
            }
        }

        public static string PasswordRecoveryURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPasswordRecovery, false);
            }
        }

        public static string PageNotAccessibleURL
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPageNotAccessible, false);
            }
        }

        #endregion

        #region "With Root URL"

        public static string RegistrationURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalRegistrationPage, true);
            }
        }
        public static string LoginURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalLoginpage, true);
            }
        }
        public static string DefaultPageURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalDefaultPage, true);
            }
        }
        public static string ProfilePageURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalUserProfilePage, true);
            }
        }
        public static string ForgotPasswordURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalForgotPassword, true);
            }
        }
        public static string PageNotFoundURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPageNotFound, true);
            }
        }

        public static string PasswordRecoveryURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPasswordRecovery, true);
            }
        }

        public static string PageNotAccessibleURLWithRoot
        {
            get
            {
                return BuildURL(SageFrameSettingKeys.PortalPageNotAccessible, true);
            }
        }

        #endregion

        /// <summary>
        /// Returns  Application Path
        /// </summary>
        public static string GetApplicationName
        {
            get
            {
                return (HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath);
            }
        }

        #region "Private Methods"

        private static string BuildPageNameWithExtension(string settingKey)
        {
            StringBuilder strBuilder = new StringBuilder();
            SageFrameConfig sfConfig = new SageFrameConfig();
            strBuilder.Append(ReplaceString(sfConfig.GetSettingValueByIndividualKey(settingKey)));
            strBuilder.Append(SageFrameSettingKeys.PageExtension);
            return strBuilder.ToString();
        }

        private static string BuildURL(string settingKey, bool withRoot)
        {
            string url = string.Empty;
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                SageFrameConfig sfConfig = new SageFrameConfig();

                if (withRoot)
                {                    
                    strBuilder.Append(HttpContext.Current.Request.Url.Authority);
                }
                strBuilder.Append(GetApplicationName);
                strBuilder.Append("/");
                strBuilder.Append(ReplaceString(sfConfig.GetSettingValueByIndividualKey(settingKey)));
                strBuilder.Append(SageFrameSettingKeys.PageExtension);
                url = strBuilder.ToString();
            }
            catch
            {
            }
            return url;
        }

        public static string ReplaceString(string strPageName)
        {
            strPageName = strPageName.Replace(" ", "-");
            strPageName = strPageName.Replace("&", "-and-");
            return strPageName;
        }

        #endregion
    }
}