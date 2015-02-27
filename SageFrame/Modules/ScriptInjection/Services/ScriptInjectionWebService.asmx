<%@ WebService Language="C#" Class="ScriptInjectionWebService" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SageFrame.ScriptInjection.Entity;
using SageFrame.ScriptInjection.Controller;

/// <summary>
/// Summary description for ScriptInjectionWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ScriptInjectionWebService : System.Web.Services.WebService
{

    public ScriptInjectionWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<ScriptInjectionInfo> GetScriptInView(int UserModuleID, int PortalID)
    {
        try
        {
            List<ScriptInjectionInfo> Inf = new List<ScriptInjectionInfo>();
            ScriptInjectionController objC = new ScriptInjectionController();
            Inf = objC.GetScriptInView(UserModuleID, PortalID);
            return Inf;
        }
        catch (Exception EX)
        {
            throw EX;
        }


    }

}


