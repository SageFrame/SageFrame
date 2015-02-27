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
using SageFrame.NewLetterSubscriber;
using SageFrame.SageFrameClass;
using SageFrame.Web.Utilities;

public partial class Modules_Subscribe_SubscriptionSetting : BaseAdministrationUserControl
{
    public Int32 usermoduleIDControl = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            usermoduleIDControl = Int32.Parse(SageUserModuleID);
            if (!Page.IsPostBack)
            {
                AddImageUrl();
                LoadSettingtoControl();
                RowVisibility();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void AddImageUrl()
    {
        imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
    }

    private void LoadSettingtoControl()
    {
        try
        {
            ddlSubscriptionType.Items.Clear();
            BindSubscriptionTypeList();

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", usermoduleIDControl));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
            SQLHandler objSql = new SQLHandler();
            NewsLetterSettingsInfo newsLetterSettingObj = objSql.ExecuteAsObject<NewsLetterSettingsInfo>("dbo.sp_NewsLetterSettingsGetAll", ParaMeterCollection);

            if (newsLetterSettingObj != null)
            {
                ddlSubscriptionType.SelectedIndex = ddlSubscriptionType.Items.IndexOf(ddlSubscriptionType.Items.FindByValue(newsLetterSettingObj.SubscriptionType.ToString()));
                txtSubscriptionModuleTitle.Text = newsLetterSettingObj.SubscriptionModuleTitle.ToString();
                txtSubscriptionHelpText.Text = newsLetterSettingObj.SubscriptionHelpText.ToString();
                txtTextBoxWaterMark.Text = newsLetterSettingObj.TextBoxWaterMarkText.ToString()!=""?newsLetterSettingObj.TextBoxWaterMarkText.ToString():"Email Address Required";
                txtSubmitButtonText.Text = newsLetterSettingObj.SubmitButtonText.ToString();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void BindSubscriptionTypeList()
    {
        try
        {
            ddlSubscriptionType.DataSource = SageFrameLists.SubscriptionDisplayType();
            ddlSubscriptionType.DataTextField = "Value";
            ddlSubscriptionType.DataValueField = "Key";
            ddlSubscriptionType.DataBind();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }
    protected void ddlSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RowVisibility();            
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void RowVisibility()
    {
        if (ddlSubscriptionType.SelectedItem.Value == "0")
        {
            rowSubscriptionModuleTitle.Visible = false;
            rowSubscriptionHelpText.Visible = false;
        }
        else
        {
            rowSubscriptionModuleTitle.Visible = true;
            rowSubscriptionHelpText.Visible = true;
        }
    }

    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SaveSetting("SubscriptionType", ddlSubscriptionType.SelectedItem.Value);
            if (ddlSubscriptionType.SelectedItem.Value != "0")
            {
                SaveSetting("SubscriptionModuleTitle", txtSubscriptionModuleTitle.Text);
                SaveSetting("SubscriptionHelpText", txtSubscriptionHelpText.Text);
            }
            SaveSetting("TextBoxWaterMarkText", txtTextBoxWaterMark.Text);
            SaveSetting("SubmitButtonText", txtSubmitButtonText.Text);
            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsLetterSubscription", "SubscribtionSettingSuccessfullySaved"), "", SageMessageType.Success);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void SaveSetting(string key, string value)
    {
        //db.sp_NewsLetterSettingsUpdate(ref _subscriptionSettingValueID, usermoduleIDControl, key, value, true, GetPortalID, GetUsername, GetUsername);
        NewLetterSubscriberController.UpdateNewLetterSettings(usermoduleIDControl, key, value, true, GetPortalID, GetUsername, GetUsername);
    }
}
