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
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using SageFrame.Web.Common.SEO;
using SageFrame.Web;
using SageFrame.RssReader;

public partial class Modules_LatestBlog_ctl_RSSReaderSetting : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AddImageUrls();
                SetPageLoadData();
                LoadAllSettings();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void AddImageUrls()
    {

        imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
        imbCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);

        //Add Java Script Validateion //NumberKey
        txtMaxNumberofPosts.Attributes.Add("OnKeydown", "return NumberKey(event)");
        txtMaxDescriptionsLength.Attributes.Add("OnKeydown", "return NumberKey(event)");
    }

    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        Save();
    }

    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        ReLoad();
    }

    private void Save()
    {
        try
        {
            if (txtDisplayTitle.Text.Trim() != string.Empty && txtLastEdndent.Text.Trim() != string.Empty && txtMaxDescriptionsLength.Text.Trim() != string.Empty && txtMaxNumberofPosts.Text.Trim() != string.Empty && txtRssURL.Text.Trim() != string.Empty)
            {
                if (hdnRssURLID.Value != string.Empty && hdnMaxNumberofPostsID.Value != string.Empty && hdnMaxDescriptionsLengthID.Value != string.Empty && hdnLastEdndentID.Value != string.Empty && hdnDisplayTitleID.Value != string.Empty)
                {
                    int URLID = Int32.Parse(hdnRssURLID.Value);
                    int MaxNumberofPostsID = Int32.Parse(hdnMaxNumberofPostsID.Value);
                    int MaxDescriptionsLengthID = Int32.Parse(hdnMaxDescriptionsLengthID.Value);
                    int LastEdndentID = Int32.Parse(hdnLastEdndentID.Value);
                    int DisplayTitleID = Int32.Parse(hdnDisplayTitleID.Value);
                    int UserModuleID = Int32.Parse(hdnUserModuleID.Value);

                    RSSReaderSettingValueInfo objRssSetingInfo = new RSSReaderSettingValueInfo();
                    objRssSetingInfo.PortalID = GetPortalID;
                    objRssSetingInfo.CultureName = GetCurrentCultureName;
                    objRssSetingInfo.UserModuleID = UserModuleID;
                    objRssSetingInfo.AddedOn = DateTime.Now;
                    objRssSetingInfo.UpdatedOn = DateTime.Now;
                    objRssSetingInfo.AddedBy = GetUsername;
                    objRssSetingInfo.UpdatedBy = GetUsername;

                    #region "Save Logic"
                    RSSReaderSettingValueController con = new RSSReaderSettingValueController();
                    //for 1                    
                    objRssSetingInfo.RSSReaderSettingValueID = URLID;
                    objRssSetingInfo.SettingValue = txtRssURL.Text.Trim();
                    con.SaveRssSettings(objRssSetingInfo);

                    //for 2                    
                    objRssSetingInfo.RSSReaderSettingValueID = MaxNumberofPostsID;
                    objRssSetingInfo.SettingValue = txtMaxNumberofPosts.Text.Trim();
                    con.SaveRssSettings(objRssSetingInfo);

                    //for 3                    
                    objRssSetingInfo.RSSReaderSettingValueID = MaxDescriptionsLengthID;
                    objRssSetingInfo.SettingValue = txtMaxDescriptionsLength.Text.Trim();
                    con.SaveRssSettings(objRssSetingInfo);

                    //for 4                    
                    objRssSetingInfo.RSSReaderSettingValueID = LastEdndentID;
                    objRssSetingInfo.SettingValue = txtLastEdndent.Text.Trim();
                    con.SaveRssSettings(objRssSetingInfo);

                    //for 5                    
                    objRssSetingInfo.RSSReaderSettingValueID = DisplayTitleID;
                    objRssSetingInfo.SettingValue = txtDisplayTitle.Text.Trim();
                    con.SaveRssSettings(objRssSetingInfo); 
                    #endregion

                    ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/SageRssReader/ModuleLocalText", "SettingSavedSuccessfully"), "", SageMessageType.Success);

                }
            }
            else
            {
                //Show message
                ShowMessage(SageMessageTitle.Notification.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/SageRssReader/ModuleLocalText", "PleaseFillSettingValues"), "", SageMessageType.Error);
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void ReLoad()
    {
        try
        {
            if (!IsPostBack)
            {
                SetPageLoadData();
                LoadAllSettings();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void SetPageLoadData()
    {       
        hdnUserModuleID.Value = SageUserModuleID;
    }

    private void LoadAllSettings()
    {
        try
        {
            RSSReaderSettingValueController con = new RSSReaderSettingValueController();
            List<RSSReaderSettingValueInfo> objSettings = con.GetAllRssSettings(GetPortalID, Int32.Parse(SageUserModuleID), GetCurrentCultureName);
            if (objSettings != null)
            {
                foreach (RSSReaderSettingValueInfo rsSeting in objSettings)
                {
                    switch (rsSeting.SettingKey)
                    {
                        case "DisplayTitle":
                            txtDisplayTitle.Text = rsSeting.SettingValue;
                            hdnDisplayTitleID.Value = rsSeting.RSSReaderSettingValueID.ToString();
                            break;
                        case "LastEdndent":
                            txtLastEdndent.Text = rsSeting.SettingValue;
                            hdnLastEdndentID.Value = rsSeting.RSSReaderSettingValueID.ToString();
                            break;
                        case "MaxNumberofPosts":
                            txtMaxNumberofPosts.Text = rsSeting.SettingValue;
                            hdnMaxNumberofPostsID.Value = rsSeting.RSSReaderSettingValueID.ToString();
                            break;
                        case "MaxDescriptionsLength":
                            txtMaxDescriptionsLength.Text = rsSeting.SettingValue;
                            hdnMaxDescriptionsLengthID.Value = rsSeting.RSSReaderSettingValueID.ToString();
                            break;
                        case "RssURL":
                            txtRssURL.Text = rsSeting.SettingValue;
                            hdnRssURLID.Value = rsSeting.RSSReaderSettingValueID.ToString();
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

    }
    
}
