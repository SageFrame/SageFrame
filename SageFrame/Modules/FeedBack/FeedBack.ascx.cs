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
using SageFrame.FeedBack;
using System.Data;
using SageFrame.Web;
using System.Text;
namespace SageFrame.Modules.FeedBack
{
    public partial class FeedBack : BaseAdministrationUserControl
    {
        public Int32 usermoduleIDControl = 0;
        FeedBackDataContext db = new FeedBackDataContext(SystemSetting.SageFrameConnectionString);
        System.Nullable<Int32> _feedBackSettingValueID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                usermoduleIDControl = Int32.Parse(SageUserModuleID);
                if (!Page.IsPostBack)
                {
                    AddImageUrls();
                    BindForm();
                    LoadFeedBackEmailSettingtoControl();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindForm()
        {
            FeedBackDataContext dbFeedBack = new FeedBackDataContext(SystemSetting.SageFrameConnectionString);
            List<sp_FeedbackItemGetResult> LINQ = (List<sp_FeedbackItemGetResult>)dbFeedBack.sp_FeedbackItemGet(GetPortalID, GetCurrentCultureName).ToList();
            foreach (sp_FeedbackItemGetResult FIR in LINQ)
            {
                try
                {
                    if (FIR.FeedbackItem.ToLower() == "FormTitle".ToLower())
                    {
                        chkFormTitle.Checked = (bool)FIR.IsActive;

                        txtFormTitle.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "FormInfo".ToLower())
                    {
                        chkFormInfo.Checked = (bool)FIR.IsActive;
                        txtFormInformation.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Name".ToLower())
                    {
                        chkName.Checked = (bool)FIR.IsActive;
                        txtName.Text = FIR.FieldCaption;
                    }
                    //if (FIR.FeedbackItem.ToLower() == "ISPermanentAddress".ToLower())
                    //{
                    //    chkPermanentAddress.Checked = (bool)FIR.IsActive;
                    //    txtISPermanentAddress.Text = FIR.FieldCaption;
                    //}
                    if (FIR.FeedbackItem.ToLower() == "PermanentCountry".ToLower())
                    {
                        chkPCountry.Checked = (bool)FIR.IsActive;
                        txtPermanentCountry.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "PermanentState".ToLower())
                    {
                        chkPState.Checked = (bool)FIR.IsActive;
                        txtPermanentState.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "PermanentCity".ToLower())
                    {
                        chkPCity.Checked = (bool)FIR.IsActive;
                        txtPermanentCity.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "PermanentZipCode".ToLower())
                    {
                        chkPZC.Checked = (bool)FIR.IsActive;
                        txtPermanentZipCode.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "PermanentPostCode".ToLower())
                    {
                        chkPZC.Checked = (bool)FIR.IsActive;
                        txtPermanentZipCode.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "PermanentAddress".ToLower())
                    {
                        chkPAdd.Checked = (bool)FIR.IsActive;
                        txtPermanentAddress.Text = FIR.FieldCaption;
                    }

                    //if (FIR.FeedbackItem.ToLower() == "ISTemporaryAddress".ToLower())
                    //{
                    //    chkTemporaryAddress.Checked = (bool)FIR.IsActive;
                    //    txtISTemporaryAddress.Text = FIR.FieldCaption;
                    //}
                    if (FIR.FeedbackItem.ToLower() == "TemporaryCountry".ToLower())
                    {

                        chkTCountry.Checked = (bool)FIR.IsActive;
                        txtTemporaryCountry.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "TemporaryState".ToLower())
                    {
                        chkTState.Checked = (bool)FIR.IsActive;
                        txtTemporaryState.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "TemporaryCity".ToLower())
                    {
                        chkTCity.Checked = (bool)FIR.IsActive;
                        txtTemporaryCity.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "TemporaryZipCode".ToLower())
                    {
                        chkTZC.Checked = (bool)FIR.IsActive;
                        txtTemporaryZipCode.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "TemporaryPostalCode".ToLower())
                    {
                        chkTPC.Checked = (bool)FIR.IsActive;
                        txtTemporaryPostalCode.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "TemporaryAddress".ToLower())
                    {
                        chkTAdd.Checked = (bool)FIR.IsActive;
                        txtTemporaryAddress.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Email1".ToLower())
                    {
                        chkEmail1.Checked = (bool)FIR.IsActive;
                        txtEmail1.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Email2".ToLower())
                    {
                        chkEmail2.Checked = (bool)FIR.IsActive;
                        txtEmail2.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Phone1".ToLower())
                    {
                        chkPhone1.Checked = (bool)FIR.IsActive;
                        txtPhone1.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Phone2".ToLower())
                    {
                        chkPhone2.Checked = (bool)FIR.IsActive;
                        txtPhone2.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Mobile".ToLower())
                    {
                        chkMobile.Checked = (bool)FIR.IsActive;
                        txtMobile.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Company".ToLower())
                    {
                        chkCompany.Checked = (bool)FIR.IsActive;
                        txtCompany.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Website".ToLower())
                    {
                        chkWebsite.Checked = (bool)FIR.IsActive;
                        txtWebsite.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Message".ToLower())
                    {
                        chkMessage.Checked = (bool)FIR.IsActive;
                        txtMessage.Text = FIR.FieldCaption;
                    }
                    if (FIR.FeedbackItem.ToLower() == "Attachment".ToLower())
                    {
                        chkAttachment.Checked = (bool)FIR.IsActive;
                        txtAttachment.Text = FIR.FieldCaption;
                    }
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }

        }


        private void AddImageUrls()
        {
            imbSaveContactUsSetting.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbSaveEmailSetting.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
        }

        protected void imbSaveContactUsSetting_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                StringBuilder sbFeedbackItems = new StringBuilder();
                StringBuilder sbFieldCaptions = new StringBuilder();
                StringBuilder sbDisplayOrders = new StringBuilder();
                StringBuilder sbIsActives = new StringBuilder();
                //for form title
                sbFeedbackItems.Append("FormTitle" + "#");
                sbFieldCaptions.Append(txtFormTitle.Text.Trim() + "#");
                sbDisplayOrders.Append(txtFormTitle1.Text.Trim() + "#");
                sbIsActives.Append(chkFormTitle.Checked + "#");

                //for form information
                sbFeedbackItems.Append("FormInfo" + "#");
                sbFieldCaptions.Append(txtFormInformation.Text + "#");
                sbDisplayOrders.Append(txtFormInfo.Text + "#");
                sbIsActives.Append(chkFormInfo.Checked + "#");

                //for name
                sbFeedbackItems.Append("Name" + "#");
                sbFieldCaptions.Append(txtName.Text.Trim() + "#");
                sbDisplayOrders.Append(txtName1.Text.Trim() + "#");
                sbIsActives.Append(chkName.Checked + "#");

                ////for IsPermanentAddress
                //sbFeedbackItems.Append("ISPermanentAddress" + "#");
                //sbFieldCaptions.Append(txtISPermanentAddress.Text.Trim() + "#");
                //sbDisplayOrders.Append(txtPermanentAddress1.Text.Trim() + "#");
                //sbIsActives.Append(chkPermanentAddress.Checked + "#");

                //for permanent country
                sbFeedbackItems.Append("PermanentCountry" + "#");
                sbFieldCaptions.Append(txtPermanentCountry.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentCountry1.Text.Trim() + "#");
                sbIsActives.Append(chkPCountry.Checked + "#");

                //for permanent state
                sbFeedbackItems.Append("PermanentState" + "#");
                sbFieldCaptions.Append(txtPermanentState.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentState1.Text.Trim() + "#");
                sbIsActives.Append(chkPState.Checked + "#");

                //for permanent city
                sbFeedbackItems.Append("PermanentCity" + "#");
                sbFieldCaptions.Append(txtPermanentCity.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentCity1.Text.Trim() + "#");
                sbIsActives.Append(chkPCity.Checked + "#");

                //for permanent zipcode
                sbFeedbackItems.Append("PermanentZipCode" + "#");
                sbFieldCaptions.Append(txtPermanentZipCode.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentZipCode1.Text.Trim() + "#");
                sbIsActives.Append(chkPZC.Checked + "#");

                //for permanent postal code
                sbFeedbackItems.Append("PermanentPostCode" + "#");
                sbFieldCaptions.Append(txtPermanentPostCode.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentPostalCode1.Text.Trim() + "#");
                sbIsActives.Append(chkPPC.Checked + "#");

                //for permanent address
                sbFeedbackItems.Append("PermanentAddress" + "#");
                sbFieldCaptions.Append(txtPermanentAddress.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPermanentAdd.Text.Trim() + "#");
                sbIsActives.Append(chkPAdd.Checked + "#");

                ////for IsTemporaryAddress
                //sbFeedbackItems.Append("ISTemporaryAddress" + "#");
                //sbFieldCaptions.Append(txtISTemporaryAddress.Text.Trim() + "#");
                //sbDisplayOrders.Append(txtTemporaryAddress1.Text.Trim() + "#");
                //sbIsActives.Append(chkTemporaryAddress.Checked + "#");

                //for temporary country
                sbFeedbackItems.Append("TemporaryCountry" + "#");
                sbFieldCaptions.Append(txtTemporaryCountry.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryCountry1.Text.Trim() + "#");
                sbIsActives.Append(chkTCountry.Checked + "#");

                //for temporary state
                sbFeedbackItems.Append("TemporaryState" + "#");
                sbFieldCaptions.Append(txtTemporaryState.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryState1.Text.Trim() + "#");
                sbIsActives.Append(chkTState.Checked + "#");

                //for temporary city
                sbFeedbackItems.Append("TemporaryCity" + "#");
                sbFieldCaptions.Append(txtTemporaryCity.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryCity1.Text.Trim() + "#");
                sbIsActives.Append(chkTCity.Checked + "#");

                //for temporary zipcode
                sbFeedbackItems.Append("TemporaryZipCode" + "#");
                sbFieldCaptions.Append(txtTemporaryZipCode.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryZipCode1.Text.Trim() + "#");
                sbIsActives.Append(chkTZC.Checked + "#");

                //for temporary postal code
                sbFeedbackItems.Append("TemporaryPostCode" + "#");
                sbFieldCaptions.Append(txtTemporaryPostalCode.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryPostalCode1.Text.Trim() + "#");
                sbIsActives.Append(chkTPC.Checked + "#");

                //for temporary address
                sbFeedbackItems.Append("TemporaryAddress" + "#");
                sbFieldCaptions.Append(txtTemporaryAddress.Text.Trim() + "#");
                sbDisplayOrders.Append(txtTemporaryAdd.Text.Trim() + "#");
                sbIsActives.Append(chkTAdd.Checked + "#");

                //for Email1
                sbFeedbackItems.Append("Email1" + "#");
                sbFieldCaptions.Append(txtEmail1.Text.Trim() + "#");
                sbDisplayOrders.Append(txtEmail11.Text.Trim() + "#");
                sbIsActives.Append(chkEmail1.Checked + "#");

                //for Email2
                sbFeedbackItems.Append("Email2" + "#");
                sbFieldCaptions.Append(txtEmail2.Text.Trim() + "#");
                sbDisplayOrders.Append(txtEmaill2.Text.Trim() + "#");
                sbIsActives.Append(chkEmail2.Checked + "#");

                //for Phone1
                sbFeedbackItems.Append("Phone1" + "#");
                sbFieldCaptions.Append(txtPhone1.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPhonee1.Text.Trim() + "#");
                sbIsActives.Append(chkPhone1.Checked + "#");

                //for Phone2
                sbFeedbackItems.Append("Phone2" + "#");
                sbFieldCaptions.Append(txtPhone2.Text.Trim() + "#");
                sbDisplayOrders.Append(txtPhonee2.Text.Trim() + "#");
                sbIsActives.Append(chkPhone2.Checked + "#");

                //for Mobile
                sbFeedbackItems.Append("Mobile" + "#");
                sbFieldCaptions.Append(txtMobile.Text.Trim() + "#");
                sbDisplayOrders.Append(txtMobile1.Text.Trim() + "#");
                sbIsActives.Append(chkMobile.Checked + "#");

                //for Company
                sbFeedbackItems.Append("Company" + "#");
                sbFieldCaptions.Append(txtCompany.Text.Trim() + "#");
                sbDisplayOrders.Append(txtCompany1.Text.Trim() + "#");
                sbIsActives.Append(chkCompany.Checked + "#");

                //for Website
                sbFeedbackItems.Append("Website" + "#");
                sbFieldCaptions.Append(txtWebsite.Text.Trim() + "#");
                sbDisplayOrders.Append(txtWebsite1.Text.Trim() + "#");
                sbIsActives.Append(chkWebsite.Checked + "#");

                //for Message
                sbFeedbackItems.Append("Message" + "#");
                sbFieldCaptions.Append(txtMessage.Text.Trim() + "#");
                sbDisplayOrders.Append(txtMessage1.Text.Trim() + "#");
                sbIsActives.Append(chkMessage.Checked + "#");

                //for Attachment
                sbFeedbackItems.Append("Attachment" + "#");
                sbFieldCaptions.Append(txtAttachment.Text.Trim() + "#");
                sbDisplayOrders.Append(txtAttachment1.Text.Trim() + "#");
                sbIsActives.Append(chkAttachment.Checked + "#");

                string FeedbackItems = sbFeedbackItems.ToString();
                FeedbackItems = FeedbackItems.Remove(FeedbackItems.LastIndexOf("#"));
                string FieldCaptions = sbFieldCaptions.ToString();
                FieldCaptions = FieldCaptions.Remove(FieldCaptions.LastIndexOf("#"));
                string DisplayOrders = sbDisplayOrders.ToString();
                DisplayOrders = DisplayOrders.Remove(DisplayOrders.LastIndexOf("#"));
                string IsActives = sbIsActives.ToString();
                IsActives = IsActives.Remove(IsActives.LastIndexOf("#"));

                db.sp_InsertUpdateFeedbackItems(FeedbackItems, FieldCaptions, DisplayOrders, IsActives,
                    GetUsername, GetCurrentCultureName, GetPortalID);


                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "SettingSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }

        }

        private void LoadFeedBackEmailSettingtoControl()
        {
            try
            {
                FeedBackDataContext dbFeedBack = new FeedBackDataContext(SystemSetting.SageFrameConnectionString);
                var feedBack = dbFeedBack.sp_FeedbackSettingGetAll(usermoduleIDControl, GetPortalID);
                foreach (sp_FeedbackSettingGetAllResult setting in feedBack)
                {
                    switch (setting.SettingKey)
                    {
                        case "FeedBackSetting":
                            rblFeedBackSetting.SelectedValue = setting.SettingValue.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbSaveEmailSetting_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SaveSetting("FeedBackSetting", rblFeedBackSetting.SelectedValue);
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "FeedBackSettingSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void SaveSetting(string key, string value)
        {
            try
            {
                db.sp_FeedbackSettingUpdate(ref _feedBackSettingValueID, usermoduleIDControl, key, value, true, GetPortalID, GetUsername, GetUsername);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }

        }

    }
}