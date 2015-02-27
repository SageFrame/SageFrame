<%@ WebService Language="C#" Class="BreadCrumbWebService" %>
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SageFrame.BreadCrum;

/// <summary>
/// Summary description for BreadCrumbWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class BreadCrumbWebService : System.Web.Services.WebService
{

    public BreadCrumbWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetBreadCrumb(int PortalID, string PageName,int MenuId)
    {
        string breadcrumb = string.Empty;
        BreadCrumInfo obj = BreadCrumDataProvider.GetBreadCrumb(PageName, PortalID,MenuId);
        return (obj.TabPath != "" ? obj.TabPath : "");

    }

}


