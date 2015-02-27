using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.Logo
{
    public class LogoDataProvider
    {
        public void SaveLogoSettings(string logoText, string logoPath, int userModuleID, int portalID, string Slogan, string URL,string CultureCode)
        {
            try
            {
                SQLHandler sqLH = new SQLHandler();
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@LogoText", logoText));
                Param.Add(new KeyValuePair<string, object>("@LogoPath", logoPath));
                Param.Add(new KeyValuePair<string, object>("@UserModuleID", userModuleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                Param.Add(new KeyValuePair<string, object>("@Slogan", Slogan));
                Param.Add(new KeyValuePair<string, object>("@url", URL));
                Param.Add(new KeyValuePair<string, object>("@CultureCode", CultureCode));
                sqLH.ExecuteNonQuery("usp_Logo_AddUpdate", Param);
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
                SQLHandler sqLH = new SQLHandler();
                List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
                Param.Add(new KeyValuePair<string, object>("@UserModuleID", userModuleID));
                Param.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                Param.Add(new KeyValuePair<string, object>("@CultureCode", CultureCode));
                return sqLH.ExecuteAsObject<SageFrame.Logo.LogoEntity>("usp_Logo_GetData", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}