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
using System.Web.UI.HtmlControls;
using SageFrame.Web.Utilities;
public partial class Modules_Subscribe_Subscription : BaseUserControl
{
    
    public Int32 usermoduleIDControl = 0;
    NewsLetterSettingsInfo newsLetterSettingObj = new NewsLetterSettingsInfo(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeCss("Subscribe", "/Modules/Subscribe/css/module.css");
        try
        {
            usermoduleIDControl = Int32.Parse(SageUserModuleID);
            GetNewsLetterSettings();
            //if (!Page.IsPostBack)
            //{                
                BindToNewsDesign();
            //}
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void GetNewsLetterSettings()
    {
        List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
        ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", usermoduleIDControl));
        ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
        SQLHandler objSql = new SQLHandler();
        newsLetterSettingObj = objSql.ExecuteAsObject<NewsLetterSettingsInfo>("dbo.sp_NewsLetterSettingsGetAll", ParaMeterCollection);
        lblHelpText.Text = string.Format("<p class='sfSubscribedesc'>{0}</p>",newsLetterSettingObj.SubscriptionHelpText.ToString());
        txtWatermarkExtender.WatermarkText = newsLetterSettingObj.TextBoxWaterMarkText.ToString()!=""? newsLetterSettingObj.TextBoxWaterMarkText.ToString():"Email Address Required";
        btnSubscribe.Text = newsLetterSettingObj.SubmitButtonText.ToString();
        btnSubscribe.ToolTip = newsLetterSettingObj.SubmitButtonText.ToString();
    }

    private void BindToNewsDesign()
    {
        try
        {
            if (newsLetterSettingObj.SubscriptionType == "0")
            {
                lblHelpText.Visible = false;
            }
            else
            {
                if (newsLetterSettingObj.SubscriptionModuleTitle != "")
                {
                    HtmlGenericControl Top5Info = new HtmlGenericControl("h1");
                    lblHelpText.Visible = true;
                    Label title = new Label();
                    title.Text = newsLetterSettingObj.SubscriptionModuleTitle;
                    Top5Info.Controls.Add(title);
                    mainContainer.Controls.Add(Top5Info);
                }
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        try
        {
            
            string clientIP = Request.UserHostAddress.ToString();
            string email = txtNewsLetterEmail.Text;
            System.Nullable<Int32> newID = 0;
            if ((string.IsNullOrEmpty(clientIP) && string.IsNullOrEmpty(email)))
            {
                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsLetterSubscription", "EmailIsRequired"), "", SageMessageType.Alert);
            }
            else
            {
                
                newID = NewLetterSubscriberController.AddNewLetterSubscribers(email, clientIP, true, GetUsername, DateTime.Now, GetPortalID);
                if (newID > 0)
                {
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsLetterSubscription", "SubscribeSuccessfully"), "", SageMessageType.Success);
                    txtNewsLetterEmail.Text = "Subscribe to our newsletter";
                }
                else
                {
                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsLetterSubscription", "AlreadySubscribed"), "", SageMessageType.Alert);
                }
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }
}
