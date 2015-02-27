<%@ WebService Language="C#" Class="SageBannerService" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SageFrame.SageBannner.Info;
using SageFrame.Web.Utilities;
using SageFrame.SageBannner.Controller;

/// <summary>
/// Summary description for SageBannerService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SageBannerService : System.Web.Services.WebService
{

    public SageBannerService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<SageBannerInfo> GetBannerImages(int BannerID, int UserModuleID, int PortalID)
    {
        try
        {
            SageBannerController obj = new SageBannerController();
            return obj.GetBannerImages(BannerID, UserModuleID, PortalID);
        }
        catch (Exception ex)
        {
            throw ex;
        }




    }
}


