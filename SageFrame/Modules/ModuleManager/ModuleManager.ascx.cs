/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
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
using SageFrame.Web;
using System.Web.Services;
using SageFrame.ModuleManager;
using System.Text;
using SageFrame.Security;

public partial class Modules_ModuleManager_ModuleManager : BaseAdministrationUserControl
{
    public int PortalID = 0, IsSideBarVisible=0;  
    public string appPath = "",UserName="";
    public string ActiveTemplate = "",PortalName;
    protected void Page_Init(object sender, EventArgs e)
    {
        IncludeJs("ModuleManager",false,"/js/jquery.floatobject-1.0.js", "/js/cookie.js","/js/jquery.dialogextend.js");
        IncludeCss("ModuleManager", "/Modules/ModuleManager/css/widget.css", "/Modules/ModuleManager/css/module.css");
        IncludeJs("ModuleManager",false,"/js/jquery.pagination.js");   
        IncludeJs("ModuleManager",false,"/js/jquery.validate.js");        
        Page.ClientScript.RegisterClientScriptInclude("ModuleManagerJS", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "/js/ModuleManager.js"));

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        ActiveTemplate = TemplateName;
        UserName = GetUsername;
        PortalID = GetPortalID;
        PortalName = GetPortalSEOName;           
        BuildAccessControlledSelection();
        SageFrameConfig sfConfig = new SageFrameConfig();
        bool ShowSideBar = sfConfig.GetSettingBollByKey(SageFrameSettingKeys.ShowSideBar);
        IsSideBarVisible = ShowSideBar ? 1 : 0;        
    }

    [WebMethod]
    public static int AddUserModule(LayoutMgrInfo layout)
    {
        return (LayoutMgrDataProvider.AddLayOutMgr(layout));

    }
    protected void BuildAccessControlledSelection()
    {

        StringBuilder sb = new StringBuilder();
        RoleController _role = new RoleController();
        string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
        if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
        {
			
			sb.Append("<div class='sfRadiobutton'>");
            sb.Append("<input id='rdbGenralModules' name='ModuleSwitcher' type='radio' checked='checked' value='0'/>");
			sb.Append("<label>General</label>");
			sb.Append("<input id='rdbAdminModules' name='ModuleSwitcher' type='radio' value='1' />");
            sb.Append("<label>Admin</label></div>");
            sb.Append("<div id='divIncludeModules' class='sfLeft'><input type='checkbox' id='chkPortalModules' class='sfCheckbox'><label>Include Portal Modules</label></div>");
        }

        ltrModuleRadioButtons.Text = sb.ToString();

    }
}
