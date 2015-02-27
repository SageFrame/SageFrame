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

public partial class Modules_Language_LocalizerSwitchSettings :BaseAdministrationUserControl
{
    public string ImagePath = "";
    public int UserModuleID = 0;
    public int PortalID = 0;
    public string appPath = string.Empty;
    public void Initialize()
    {
        
       IncludeJs("LanguageSwitch","/Modules/LanguageSwitcher/js/jquery.dd.js");
       IncludeCss("LanguageSwitch", "/Modules/LanguageSwitcher/css/carousel.css");
       IncludeCss("LanguageSwitch", "/Modules/LanguageSwitcher/css/module.css");
       IncludeCss("LanguageSwitch", "/Modules/LanguageSwitcher/css/dd.css");


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        Initialize();
        PortalID = GetPortalID;
        UserModuleID = int.Parse(SageUserModuleID);
        string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
        
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LocalizationLangSwitchGlobalVariable1", " var LanguageSwitchSettingFilepath='" + ResolveUrl(modulePath) + "';", true);
        ImagePath = ResolveUrl(modulePath);
       
    }
}
