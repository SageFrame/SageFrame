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
using SageFrame.Core;
using SageFrame.Common;
using SageFrame.Web;
using System.Text;
public partial class Modules_ScriptInjection_ViewScriptInjection :BaseAdministrationUserControl
{
    public int UserModuleID;
    public int PortalID;
    protected void Page_Load(object sender, EventArgs e)
    {
        string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "globalVariables", " var ServicePath='" + ResolveUrl(modulePath) + "';", true);
        UserModuleID = Int32.Parse(SageUserModuleID);
        PortalID = GetPortalID;
        GenerateDynamicContainer();
       
            IncludeJS();
        
    }
    private void IncludeJS()
    {
        Page.ClientScript.RegisterClientScriptInclude("JQuery_json", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "/js/json2.js"));
        Page.ClientScript.RegisterClientScriptInclude("ModuleScript", ResolveUrl(this.AppRelativeTemplateSourceDirectory + "/js/EmbedScript.js"));

    }

    public void GenerateDynamicContainer()
    {
        int UserModID = int.Parse(SageUserModuleID);
        StringBuilder sb = new StringBuilder();
        string divId="divScript_"+UserModID;
        sb.Append("<div id=" + divId + "></div>");
        ltrScriptInject.Text = sb.ToString();
    }
}
