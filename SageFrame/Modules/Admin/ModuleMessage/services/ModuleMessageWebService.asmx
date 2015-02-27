<%@ WebService Language="C#" Class="ModuleMessageWebService" %>
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SageFrame.ModuleMessage;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Summary description for ModuleMessageWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ModuleMessageWebService : System.Web.Services.WebService
{

    public ModuleMessageWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public List<ModuleMessageInfo> GetModules()
    {
       
        return (ModuleMessageController.GetAllModules());
    }
    
    [WebMethod]
    public List<KeyValue> GetCultures()
    {
        List<KeyValue> lstAllCultures = new List<KeyValue>();
        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {           
            lstAllCultures.Add(new KeyValue(ci.Name,ci.DisplayName));
        }
        return lstAllCultures;
    }

    [WebMethod]
    public void AddMessage(ModuleMessageInfo objMessage)
    {
        ModuleMessageController.AddModuleMessage(objMessage);
    }

    [WebMethod]
    public ModuleMessageInfo GetMessage(int ModuleID, string Culture)
    {
        return (ModuleMessageController.GetModuleMessage(ModuleID, Culture));
    }
    [WebMethod]
    public void UpdateMessage(int ModuleID, bool IsActive)
    {
        ModuleMessageController.UpdateMessageStatus(ModuleID, IsActive);
    }

}


