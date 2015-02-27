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
using System.Collections.Generic;
using SageFrame.Pages;
using SageFrame.ModuleManager;
using SageFrame.Dashboard;
using SageFrame.Security.Entities;
using System.Text.RegularExpressions;
using SageFrame.Security;

public partial class Modules_DashBoard_PageModuleStatistics : BaseAdministrationUserControl
{
    public int PortalID = 0;
    public string UserName = "";
    public string appPath = "";
    public string PortalName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        RegScript();
        GetVariable();

    }
    public  void RegScript()
    {
        Page.ClientScript.RegisterClientScriptInclude("tblPaging", ResolveUrl("~/Modules/DashBoard/js/quickpager.jquery.js"));
    }
    public void GetVariable()
    {
        PortalID = GetPortalID;
        PortalName = GetPortalSEOName;
        UserName = GetUsername;
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
    }
   
}
