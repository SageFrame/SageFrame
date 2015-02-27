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
using SageFrame.Localization;

public partial class Modules_Language_LangSwitch : BaseAdministrationUserControl
{
    public string ContainerClientID = string.Empty;
    public int LangUserModuleID = 0,PortalID=0,UserModuleID=0;
   
    public void Initialize()
    {

        IncludeCss("LanguageSwitch", "/Modules/LanguageSwitcher/css/carousel.css", "/Modules/LanguageSwitcher/css/module.css", "/Modules/LanguageSwitcher/css/dd.css");
        IncludeJs("LanguageSwitch",false, "/Modules/LanguageSwitcher/js/jquery.dd.js", "/Modules/LanguageSwitcher/js/jquery.tools.min.js");             
        IncludeJs("LanguageSwitch","/Modules/LanguageSwitcher/js/LangSwitch.js");


    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        PortalID = GetPortalID;
        GetAvailableLanguages();
            CreateDynamicNav();
            PortalID = GetPortalID;
            UserModuleID = int.Parse(SageUserModuleID);
            LangUserModuleID = int.Parse(SageUserModuleID);
            string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LanguageSwitchGlobalVariable1", " var LanguageSwitchFilePath='" + ResolveUrl(modulePath) + "';", true);
            string flagPath = ResolveUrl(Request.ApplicationPath);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LanguageSwitchGlobalVariable2", " var LanguageSwitchFlagPath='" + ResolveUrl(flagPath) + "';", true);
           
        
    }
   
    public void CreateDynamicNav()
    {
        ContainerClientID = "divNav_" + SageUserModuleID;
        StringBuilder sb = new StringBuilder();
        sb.Append("<div id='" + ContainerClientID + "'>");
        sb.Append("<div id='divFlagButton_"+SageUserModuleID+"' class='FlagButtonWrapper'> </div>");
        sb.Append("<div id='divFlagDDL_"+SageUserModuleID+"'> </div>");
        sb.Append("<div id='divPlainDDL_"+SageUserModuleID+"'> </div>");
        sb.Append("<div id='carousel_container_"+SageUserModuleID+"' class='CssClassLanguageWrapper'>");
        sb.Append("<div class='CssClassLanguageWrapperInside' id='divLangWrap_"+SageUserModuleID+"'>");
        sb.Append("<div id='left_scroll_"+SageUserModuleID+"' class='cssClassLeftScroll'><img class='imgLeftScroll' /></div>");
        sb.Append("<div id='carousel_inner_"+SageUserModuleID+"' class='cssClassCarousel'>");
        sb.Append("<ul id='carousel_ul_"+SageUserModuleID+"'></ul></div>");
        sb.Append("<div id='right_scroll_"+SageUserModuleID+"' class='cssClassRightScroll'><img class='imgRightScroll'/></div></div></div>");
        sb.Append("</div>");
        ltrNav.Text = sb.ToString();       
    }

    private void GetAvailableLanguages()
    {
        List<Language> lstLanguage = LocalizationSqlDataProvider.GetPortalLanguages(PortalID);
        if (lstLanguage.Count <= 1)
        {
            ltrNav.Visible = false;
        }
    }
}



