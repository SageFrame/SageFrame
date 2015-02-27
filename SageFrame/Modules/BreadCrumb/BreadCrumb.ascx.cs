using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using SageFrame.BreadCrum;
using SageFrame.Web;
using System.IO;
using SageFrame.Common.Shared;
using System.Text;

public partial class Modules_BreadCrumb_BreadCrumb : BaseAdministrationUserControl
{
    public int PortalID = 0;
    public string PageName = "", AppPath = string.Empty, pagePath = string.Empty;
    public string DefaultPortalHomePage = "";
    public int MenuID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
         SageFrameConfig sfConfig = new SageFrameConfig();
        string pagePath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BreadCrumGlobal1", " var BreadCrumPagePath='" + pagePath + "';", true);
        pagePath = GetPortalID == 1 ? pagePath : pagePath + "/portal/" + GetPortalSEOName;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "BreadCrumAdminGlobal" + GetPortalID, " var BreadCrumPageLink='" + ResolveUrl(pagePath) + "';", true);
        PortalID = GetPortalID;
        if(PortalID >1)
        {
            DefaultPortalHomePage =ResolveUrl("~/portal/" + GetPortalSEOName + "/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
        }
        else
        {
            DefaultPortalHomePage =ResolveUrl("~/" + sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) + ".aspx");
        }
    }
	
    public void Initialize()
    {
        PortalID = GetPortalID;
        PageName = Path.GetFileNameWithoutExtension(PagePath);
        AppPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        RegisterClientScriptToPage(ScriptMap.BreadCrumbScript.Key, ResolveUrl(AppPath + ScriptMap.BreadCrumbScript.Value), true);
        MenuID = Convert.ToInt32(Session["MenuID"]);
		IncludeCss("BreadCrumb", "/Modules/BreadCrumb/css/module.css");
	}
}
