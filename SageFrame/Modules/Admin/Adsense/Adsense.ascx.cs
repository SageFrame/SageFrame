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
using SageFrame.Framework;
using SageFrame.GoogleAdsense;
using SFE.GoogleAdUnit;

namespace SageFrame.Modules.Admin.Adsense
{
    public partial class Adsense : BaseAdministrationUserControl
    {
        
        int _userModuleCount = 0;
        SageFrameConfig pb = new SageFrameConfig();
        protected void Page_Init(object sender, EventArgs e)
        {
            hdnUserModuleID.Value = SageUserModuleID;
            AdsenseDisplay.AffiliateId = pb.GetSettingsByKey(SageFrameSettingKeys.PortalGoogleAdSenseID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    
                    _userModuleCount = GoogleAdsenseController.CountAdSense(Int32.Parse(hdnUserModuleID.Value), GetPortalID);
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
                if (_userModuleCount > 0)
                {
                    BindAdsControl();
                }
                else if (_userModuleCount == 0)
                {
                    BindDefaultAdsControl();
                }
                else
                {
                    AdsenseDisplay.Visible = false;
                }
            }
        }

        private void BindDefaultAdsControl()
        {
            try
            {
                AdsenseDisplay.Visible = true;
                AdsenseDisplay.ChannelId = pb.GetSettingsByKey(SageFrameSettingKeys.PortalGoogleAdsenseChannelID);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindAdsControl()
        {
            try
            {
                AdsenseDisplay.Visible = true;
                List<GoogleAdsenseInfo> adsenseSetting = GoogleAdsenseController.GetAdSenseSettingsByUserModuleID(Int32.Parse(hdnUserModuleID.Value), GetPortalID);
                foreach (GoogleAdsenseInfo adsContent in adsenseSetting)
                {
                    switch (adsContent.SettingName)
                    {
                        case "AdsenseUnitFormat":
                            AdsenseDisplay.AdUnitFormat = (AdUnitFormat)Enum.Parse(typeof(AdUnitFormat), adsContent.SettingValue, true);
                            break;
                        case "AdsenseUnitType":
                            AdsenseDisplay.AdUnitType = (AdUnitType)Enum.Parse(typeof(AdUnitType), adsContent.SettingValue, true);
                            break;
                        case "AdsenseChannelID":
                            AdsenseDisplay.ChannelId = adsContent.SettingValue;
                            break;
                        case "AdsenseBorderColor":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.BorderColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseBackColor":

                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseLinkColor":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.LinkColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseTextColor":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.TextColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseURLColor":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.UrlColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseAnotherURL":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.AnotherUrl = adsContent.SettingValue.Trim();
                            }
                            break;
                        case "AdsenseSolidFillColor":
                            if (adsContent.SettingValue.Trim() != "")
                            {
                                AdsenseDisplay.SolidFillColor = System.Drawing.ColorTranslator.FromHtml("#" + adsContent.SettingValue.Trim());
                            }
                            break;
                        case "AdsenseAlternateAds":
                            if (adsContent.SettingValue.Trim() != "" && adsContent.SettingValue.Trim() != "-1")
                            {
                                AdsenseDisplay.AlternateAdType = (AlternateAdTypes)Enum.Parse(typeof(AlternateAdTypes), adsContent.SettingValue, true);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
    }
}