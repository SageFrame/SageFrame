using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SageFrame.Logo
{
    public class LogoController
    {
        public void SaveLogoSettings(string logoText, string logoPath, int userModuleID, int portalID, string Slogan, string URL, string CultureCode)
        {
            try
            {
                LogoDataProvider objProvider = new LogoDataProvider();
                objProvider.SaveLogoSettings(logoText, logoPath, userModuleID, portalID, Slogan, URL, CultureCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LogoEntity GetLogoData(int userModuleID, int portalID, string CultureCode)
        {
            try
            {
                LogoEntity objLogoEntity = new LogoEntity();
                if (HttpRuntime.Cache["LogoImage_" + CultureCode + "_" + userModuleID.ToString()] != null)
                {
                    objLogoEntity = HttpRuntime.Cache["LogoImage_" + CultureCode + "_" + userModuleID.ToString()] as LogoEntity;
                }
                else
                {
                    LogoDataProvider objProvider = new LogoDataProvider();
                    objLogoEntity = objProvider.GetLogoData(userModuleID, portalID, CultureCode);
                    if (objLogoEntity != null)
                    {
                        HttpRuntime.Cache["LogoImage_" + CultureCode + "_" + userModuleID.ToString()] = objLogoEntity;
                    }
                }
                return objLogoEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
