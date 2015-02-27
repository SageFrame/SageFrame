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
using System.IO;
using System.Text;
using SageFrame.Security;

public partial class Modules_Pages_ManagePages :BaseAdministrationUserControl
{
    public int UserModuleID, PortalID;
    public string ContainerClientID = string.Empty;
    string baseURL = string.Empty;
    public string UserName = string.Empty, PageName = string.Empty, CultureCode = string.Empty,appPath=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeCssJs();
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";     
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageMenuAdminGlobal1", " var ServicePath='" + appPath + "';", true); 
        if (!IsPostBack)
        {
            BuildAccessControlledSelection();
            AddImageUrls();
            UserModuleID = int.Parse(SageUserModuleID);
            PortalID = GetPortalID;
            UserName = GetUsername;
            CultureCode = GetCurrentCulture();
            PageName = Path.GetFileNameWithoutExtension(PagePath);
            string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageMenuGlobal", " var Path='" + ResolveUrl(modulePath) + "';", true);
            string pagePath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
            pagePath = GetPortalID == 1 ? pagePath : pagePath + "/portal/" + GetPortalSEOName;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SageMenuGlobal1", " var PagePath='" + pagePath + "';", true);

        }

    }
    private void AddImageUrls()
    {
        string imageFolder = "~/Administrator/Templates/Default/images/";       
        imgRemove.Src = GetImageUrl(imageFolder, "context-delete.png", true);
        imgAddNew.Src = GetImageUrl(imageFolder, "context-add-page.png", true);
        //imgAddModule.Src = GetImageUrl(imageFolder, "btncreatepackage.png", true);
        
    }
    public string GetImageUrl(string _imageFolder, string imageName, bool isServerControl)
    {
        string path = string.Empty;
        if (isServerControl == true)
        {
            path = _imageFolder + imageName;
        }
        return path;
    }
    private void InitializeCssJs()
    {
        IncludeCss("PageManager", "/Administrator/Templates/Default/css/ui.tree.css");
        IncludeCss("PageManager", "/Modules/Pages/css/module.css");

        IncludeJs("PageManager", "/js/jquery.validate.js");
        IncludeJs("PageManager", "/Administrator/Templates/Default/js/ui.tree.js");
        IncludeJs("PageManager", "/Administrator/Templates/Default/js/contextmenu.js");
        IncludeJs("PageManager", "/Administrator/Templates/Default/js/ajaxupload.js");
        IncludeJs("PageManager", "/Modules/Pages/js/PageTreeView.js");
        IncludeJs("PageManager", "/Modules/Pages/js/PageMgr.js");
        IncludeJs("PageManager", "/js/jquery.pagination.js");
    }


    protected void BuildAccessControlledSelection()
    {


        StringBuilder sb = new StringBuilder();
        RoleController _role = new RoleController();
        string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
        if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
        {
            sb.Append("<div class='sfRadiobutton'>");           
            sb.Append("<input type='radio' id='rdbFronMenu' checked='checked' name='PageMode'/>");
            sb.Append("<label>Portal Pages</label>");          
            sb.Append("<input type='radio' id='rdbAdmin' name='PageMode'/><label>Admin Pages</label></div>");
        }       

        ltrPageRadioButtons.Text = sb.ToString();        
    }
}
