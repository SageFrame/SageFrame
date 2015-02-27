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
using SageFrame.SageBannner.Provider;
using SageFrame.SageBannner.SettingInfo;
using SageFrame.Common;
using SageFrame.Core;
using SageFrame.Web.Utilities;
using SageFrame.SageBannner.Controller;

public partial class Modules_Sage_Banner_SettingBanner : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDownBanner(Int32.Parse(SageUserModuleID), GetPortalID);
            GetSetting();
            imbSaveBannerSetting.ImageUrl = GetTemplateImageUrl("imgSave.png", true);
        }
    }


    private void LoadDropDownBanner(int UserModuleID, int PortalID)
    {
        try
        {
            ddlBannerListToUse.DataSource = SageBannerController.LoadBannerOnDropDown(UserModuleID, PortalID);
            ddlBannerListToUse.DataValueField = "BannerID";
            ddlBannerListToUse.DataTextField = "BannerName";
            ddlBannerListToUse.DataBind();
            ddlBannerListToUse.Items.Insert(0, new ListItem("ChooseBanner", "-1"));
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }


    public void GetSetting()
    {
        SageBannerSettingInfo obj = GetSageBannerSetting(GetPortalID, Int32.Parse(SageUserModuleID));
        chkAutoSlide.Checked = obj.Auto_Slide;
        chkInfiniteLoop.Checked = obj.InfiniteLoop;
        chkNumeric.Checked = obj.NumericPager;
        txtPauseTime.Text = Convert.ToString(obj.Pause_Time);
        txtSpeed.Text = Convert.ToString(obj.Speed);
        ddlTransitionMode.SelectedValue = obj.TransitionMode;
        chkEnableControl.Checked = obj.EnableControl;
        if (obj.TransitionMode == "horizontal")
        {
            ddlTransitionMode.SelectedValue = "0";
        }
        else{
            ddlTransitionMode.SelectedValue = "2";

        }
        ddlBannerListToUse.SelectedValue = obj.BannerToUse;
    }


    protected void imbSaveBannerSetting_Click(object sender, ImageClickEventArgs e)
    {
        if (txtSpeed.Text == null)
        {
            txtSpeed.Text = Convert.ToString(0);
        }


        if (txtPauseTime.Text == null)
        {
            txtPauseTime.Text = Convert.ToString(0);
        }

        try
        {
            SaveBannerSetting("BannerToUse", ddlBannerListToUse.SelectedValue, Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
            SaveBannerSetting("TransitionMode", ddlTransitionMode.SelectedItem.Text, Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
            SaveBannerSetting("InfiniteLoop", Convert.ToString(chkInfiniteLoop.Checked).ToLower(), Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);

            SaveBannerSetting("Speed", txtSpeed.Text, Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);

            SaveBannerSetting("NumericPager", Convert.ToString(chkNumeric.Checked).ToLower(), Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
            SaveBannerSetting("Auto_Slide", Convert.ToString(chkAutoSlide.Checked).ToLower(), Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
            SaveBannerSetting("Pause_Time", txtPauseTime.Text, Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
            SaveBannerSetting("EnableControl", Convert.ToString(chkEnableControl.Checked).ToLower(), Int32.Parse(SageUserModuleID), GetUsername, GetUsername, GetPortalID);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "SettingSavedSucessfully"), "", SageMessageType.Success);



    }


    private void SaveBannerSetting(string Key, string value, int usermoduleid, string Addedby, string Updatedby, int PortalID)
    {
        try
        {
            SageBannerProvider objHelp = new SageBannerProvider();
            objHelp.SaveBannerSetting(Key, value, usermoduleid, Addedby, Updatedby, PortalID);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

    }


    public SageBannerSettingInfo GetSageBannerSetting(int PortalID, int UserModuleID)
    {
        try
        {
            SageBannerController objC = new SageBannerController();
            return objC.GetSageBannerSettingList(PortalID, UserModuleID);

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }


    //protected void ddlTransitionMode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Convert.ToString(ddlTransitionMode.SelectedItem.Text) == "vertical")
    //    {
    //        tdAutoslide.Visible = false;
    //    }
    //    else
    //    {
    //        tdAutoslide.Visible = true;
    //    }
    //}


}
