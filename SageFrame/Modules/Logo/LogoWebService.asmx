<%@ WebService Language="C#" Class="LogoWebService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using SageFrame.Web;
using SageFrame.Web.Utilities;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class LogoWebService  : System.Web.Services.WebService {

    SQLHandler sqLH = new SQLHandler();
    [WebMethod]
    public void SaveLogoSettings(string logoText, string logoPath, int userModuleID, int portalID,string Slogan,string URL)
    {
        try
        {
            List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
            Param.Add(new KeyValuePair<string, object>("@LogoText", logoText));
            Param.Add(new KeyValuePair<string, object>("@LogoPath", logoPath));
            Param.Add(new KeyValuePair<string,object>("@UserModuleID",userModuleID));
            Param.Add(new KeyValuePair<string,object>("@PortalID",portalID));
            Param.Add(new KeyValuePair<string, object>("@Slogan", Slogan));
            Param.Add(new KeyValuePair<string, object>("@url", URL));
            sqLH.ExecuteNonQuery("usp_Logo_AddUpdate", Param);           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [WebMethod]
    public SageFrame.Logo.LogoEntity GetLogoData(int userModuleID, int portalID)
    {
        try
        {
            List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
            Param.Add(new KeyValuePair<string,object>("@UserModuleID",userModuleID));
            Param.Add(new KeyValuePair<string,object>("@PortalID",portalID));           
           return sqLH.ExecuteAsObject<SageFrame.Logo.LogoEntity>("usp_Logo_GetData",Param);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public void DeleteIcon(string IconPath)
    {
        try
        {
            string filepath = SageFrame.Templating.Utils.GetAbsolutePath(string.Format("Modules/Logo/image/{0}", IconPath));
            if (File.Exists(filepath))
            {
                File.SetAttributes(filepath, System.IO.FileAttributes.Normal);
                File.Delete(filepath);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    
    
}

