using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.Shared;
using SageFrame.Modules.Admin.PortalSettings;

public partial class Modules_Admin_DashboardInfo_DashboardInfo : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        SageFrameConfig objConfig = new SageFrameConfig();
        bool isDashboardHelpEnabled = objConfig.GetSettingBoolValueByIndividualKey(SageFrameSettingKeys.EnableDasboardHelp);
        if (isDashboardHelpEnabled)
        {
            divDashboardHelp.Visible = true;
        }
        else
        {
            divDashboardHelp.Visible = false;
        }
        IncludeCss("DashboardHelp", "/Modules/Admin/DashboardInformation/css/module.css");
        IncludeJs("DashboardHelp", "/Modules/Admin/DashboardInformation/js/DashBoardInfoJs.js");
    }
    protected void btnDisableDashboardhelp_Click(object sender, EventArgs e)
    {
        try
        {
            SettingProvider objSettingProvider = new SettingProvider();
            objSettingProvider.SaveSageSetting(SettingType.SiteAdmin.ToString(), SageFrameSettingKeys.EnableDasboardHelp, "false", GetUsername, GetPortalID.ToString());
            divDashboardHelp.Visible = false;
            ShowMessage("", GetSageMessage("DashboardHelp", "Cancelled"), "", SageMessageType.Success);
        }
        catch (Exception exec)
        {
            ProcessException(exec);
        }
    }
}
