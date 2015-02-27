#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace SageFrame.Templating
{
    public class ThemeHelper
    {
        public static string GetAdminTheme(int PortalID,string UserName)
        {
            SettingInfo objSetting = TemplateController.GetSettingByKey(new SettingInfo("DASHBOARD_THEME", UserName, PortalID));
            return (objSetting!=null?objSetting.SettingValue.ToString():"default");

        }
        
    }
}
