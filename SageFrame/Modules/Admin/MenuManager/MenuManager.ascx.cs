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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using System.Collections;
using System.Text;
using SageFrame.Security;
using System.IO;

public partial class Modules_Admin_MenuManager_MenuManager : BaseAdministrationUserControl
{
    string appPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
         appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";        
        IncludeJs("MenuManager", "/Modules/Admin/MenuManager/js/MenuManager.js");
        IncludeJs("MenuManager",false,"/Editors/ckeditor/ckeditor.js", "/Editors/ckeditor/adapters/jquery.js", "/Administrator/Templates/Default/js/ui.tree.js", "/Administrator/Templates/Default/js/contextmenu.js");
        IncludeJs("MenuManager",false,"/Administrator/Templates/Default/js/ajaxupload.js","/js/jquery.validate.js");
        IncludeCss("MenuManager", "/Modules/Admin/MenuManager/css/module.css", "/Administrator/Templates/Default/css/ui.tree.css");
        BuildAccessControlledSelection();
        AddImageUrls();
    }

    protected void BuildAccessControlledSelection()
    {

        StringBuilder sb = new StringBuilder();
        RoleController _role = new RoleController();
        string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
        if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()))
        {
            sb.Append("<input id='rdbPages' type='radio' name='rdbMenuItem' value='0' />");
            sb.Append("<label>");
            sb.Append("Pages</label>");
            //sb.Append("<input id='rdbAdminPages' type='radio' name='rdbMenuItem' value='3' />");
            //sb.Append("<label>");
           // sb.Append("Admin Pages</label>");
            sb.Append("<input id='rdbExternalLink' type='radio' name='rdbMenuItem' value='2' />");
            sb.Append("<label>");
            sb.Append("External Link</label>");
            sb.Append("<input id='rdbHtmlContent' type='radio' name='rdbMenuItem' value='1' />");
            sb.Append("<label>");
            sb.Append("HTML Content</label>");
        }
        else
        {
            sb.Append("<input id='rdbPages' type='radio' name='rdbMenuItem' value='0' />");
            sb.Append("<label>");
            sb.Append("Pages</label>");          
            sb.Append("<input id='rdbExternalLink' type='radio' name='rdbMenuItem' value='2' />");
            sb.Append("<label>");
            sb.Append("External Link</label>");
            sb.Append("<input id='rdbHtmlContent' type='radio' name='rdbMenuItem' value='1' />");
            sb.Append("<label>");
            sb.Append("HTML Content</label>");
        }
        ltrMenuRadioButtons.Text = sb.ToString();

    }

    private void AddImageUrls()
    {
        string imageFolder = "~/Administrator/Templates/Default/images/";
        imgRemove.Src = GetImageUrl(imageFolder, "context-delete.png", true);      
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
}
