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
using SageFrame.SageFrameClass;
using SageFrame.Modules.Admin.HostSettings;
using SageFrame.Shared;
using SageFrame.Web;
using SageFrame.Localization;
using SageFrame.Framework;
using System.Collections.Specialized;

using SageFrame.Web.Utilities;
using Twitter;

public partial class Modules_Twitter_TwitterSettings : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            imbSave.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
            BindSettings();
        }
    }

    protected void BindSettings()
    {
        TwitterSettingsInfo twtData = new TwitterSettingsInfo();
        TwitterSqlhandler twtSql = new TwitterSqlhandler();
        int userModuuleID;
        bool status = int.TryParse(SageUserModuleID, out userModuuleID);
        twtData = twtSql.GetTwitterSettingValues(userModuuleID, GetPortalID);      
        txtScreenName.Text = twtData.ScreenName.ToString();
        txtTwittsCount.Text = twtData.Count.ToString();
    }

    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {            
            int PortalID = GetPortalID;         
            string url = txtScreenName.Text;
            int userModuleID;
            bool status = int.TryParse(SageUserModuleID, out userModuleID);
            bool statuses;
            int count;
            statuses = int.TryParse(txtTwittsCount.Text, out count);
            TwitterSqlhandler twtSql = new TwitterSqlhandler();
            twtSql.SaveTwitterSettings(userModuleID.ToString(), GetPortalID.ToString(), "Tweets", url, count.ToString());
            ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/TwitterDeck/ModuleLocalText", "TwitterSettingSavedSuccessfully"), "", SageMessageType.Success);
        }
        catch (Exception Ex)
        {
            ProcessException(Ex);
        }
    }
}
