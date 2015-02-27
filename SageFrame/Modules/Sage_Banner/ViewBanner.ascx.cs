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
using SageFrame.SageBannner.SettingInfo;
using SageFrame.Web.Utilities;
using SageFrame.SageBannner.Controller;

public partial class Modules_Sage_Banner_ViewBanner : BaseAdministrationUserControl
{
    #region Variables
    public string Auto_Direction = "";
    public bool Auto_Slide;
    public bool Caption;
    public int DisplaySlideQty;
    public bool InfiniteLoop;
    public bool NumericPager;
    public bool EnableControl = false;
    public int Pause_Time;
    public bool RandomStart;
    public int Speed;
    public string BannerId = "";
    public string TransitionMode = "";
    public int UserModuleId;
    public int PortalId;
    public string SageURL = "";
    #endregion


    
    protected void Page_Load(object sender, EventArgs e)
    {
        SageURL = string.Format("{0}{1}", Request.ApplicationPath == "/" ? "" : Request.ApplicationPath, SageURL);
        UserModuleId = Int32.Parse(SageUserModuleID);
        PortalId = GetPortalID;
        string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "globalVariables", " var SageBannerServicePath='" + ResolveUrl(modulePath) + "';", true);
        IncludeJS();
        IncludeCss();

        EnableControl = true;
        GetBannerSetting();

    }


    private void GetBannerSetting()
    {
        SageBannerSettingInfo obj = GetSageBannerSettingList(GetPortalID, Int32.Parse(SageUserModuleID));
        Auto_Slide = obj.Auto_Slide;
        Caption = obj.Caption;
        InfiniteLoop = obj.InfiniteLoop;
        NumericPager = obj.NumericPager;
        Pause_Time = obj.Pause_Time;
        RandomStart = obj.RandomStart;
        EnableControl = obj.EnableControl;
        Speed = obj.Speed;
        TransitionMode = obj.TransitionMode;
        BannerId = obj.BannerToUse;
    }


    private void IncludeCss()
    {
        IncludeCss("Sage_Banner", "/Modules/Sage_Banner/css/bx_styles.css", "/Modules/Sage_Banner/css/Module.css");        
    }


    private void IncludeJS()
    {
        IncludeJs("SageBanner",false,"/Modules/Sage_Banner/js/JSFullSageBanner.js");
       // IncludeJs("SageBanner", "/Modules/Sage_Banner/js/jquery.easing.1.3.js");
        IncludeJs("SageBanner",false,"/Modules/Sage_Banner/js/jquery.bxSlider.js");        
    }


    public SageBannerSettingInfo GetSageBannerSettingList(int PortalID, int UserModuleID)
    {
        try
        {
            SageBannerController objc = new SageBannerController();
            return objc.GetSageBannerSettingList(PortalID, UserModuleID);
        }
        catch(Exception ex)
        {
            throw ex;
        }
      
    }


}
