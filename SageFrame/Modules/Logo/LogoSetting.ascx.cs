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
public partial class Modules_Logo_LogoSetting :BaseAdministrationUserControl
{
    public int moduleID, portalID;
    public string culture, userName, resolvedUrl, currentDirectory;
    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeJs("LogoSeting", "/Modules/Logo/js/setting.js");
        IncludeJs("LogoUploader", "/Modules/Logo/js/ajaxupload.js");
        IncludeCss("Logo", "/Modules/Logo/css/module.css");
        moduleID = UserModuleID;
        portalID = GetPortalID;
        resolvedUrl = ResolveUrl("~/");
        currentDirectory = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
    }
    public int UserModuleID
    {
        get
        {
            if (!string.IsNullOrEmpty(SageUserModuleID))
            {
                moduleID = Int32.Parse(SageUserModuleID);
            }
            return moduleID;
        }
    }
}
