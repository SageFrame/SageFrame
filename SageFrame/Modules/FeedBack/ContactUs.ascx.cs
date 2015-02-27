/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2010 by SageFrame
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
using SageFrame.FeedBack;
using System.Data;
using AjaxControlToolkit;
using System.Collections;
using SageFrame.SageFrameClass.MessageManagement;
using System.IO;
using SageFrame.Framework;
using SageFrame.Core.ListManagement;


namespace SageFrame.Modules.FeedBack
{
    public partial class ContactUs : BaseAdministrationUserControl
    {
        
        SageFrameConfig pagebase = new SageFrameConfig();

        protected void Page_Init(object sender, EventArgs e)
        {
            
            if (pnlFormView.Controls.Count == 1)
            {
                FormGenerator();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IncludeCss("FeedBack", "/Modules/FeedBack/css/module.css");
            if (!Page.IsPostBack)
            {
                AddImageUrls();
                //  FillFormData();
            }
        }

        private void AddImageUrls()
        {
            //imbSend.ImageUrl = GetTemplateImageUrl("imgsend.png", true);
        }

        private void FormGenerator()
        {

            if (pnlFormView.Controls.Count == 1)
            {                
                DataTable dt = ListManagementController.FeedbackItemGet(GetPortalID, GetCurrentCultureName);
                if (dt != null && dt.Rows.Count > 0)
                {

                    string ParentKey = string.Empty;
                    string parentKey = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl hmpr = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        hmpr.Attributes.Add("class", "sfContactfield");
                        bool IsActive = bool.Parse(dt.Rows[i]["IsActive"].ToString());

                        string FeedbackItem = dt.Rows[i]["FeedbackItem"].ToString();
                        int FeedbackItemID = Int32.Parse(dt.Rows[i]["FeedbackItemID"].ToString());


                        if (IsActive)
                        {
                            if ((dt.Rows[i]["FeedbackItem"].ToString() == "FormTitle"))
                            {
                                ContactInformation.InnerHtml += "<h2>" + dt.Rows[i]["FieldCaption"].ToString() + "</h2>";
                                ContactInformation.Visible = true;
                            }
                            else if (dt.Rows[i]["FeedbackItem"].ToString() == "FormInfo")
                            {
                                string strTemp = dt.Rows[i]["FieldCaption"].ToString();
                                strTemp = strTemp.Replace("\r", "<br />");
                                ContactInformation.InnerHtml += strTemp;
                                ContactInformation.Visible = true;
                            }
                            else if ((dt.Rows[i]["FeedbackItem"].ToString() == "FormTitle" || dt.Rows[i]["FeedbackItem"].ToString() == "FormInfo") && IsActive == false)
                            {
                                ContactInformation.Visible = false;
                            }
                            else
                            {
                                Label lblFormLabel = new Label();
                                lblFormLabel.ID = "lblFormLabel_" + FeedbackItemID;
                                lblFormLabel.Text = dt.Rows[i]["FieldCaption"].ToString();
                                lblFormLabel.ToolTip = dt.Rows[i]["FieldCaption"].ToString();
                                lblFormLabel.CssClass = "sfFormlabel";
                                lblFormLabel.EnableViewState = true;
                                System.Web.UI.HtmlControls.HtmlGenericControl plabel = new System.Web.UI.HtmlControls.HtmlGenericControl("p");
                                plabel.Controls.Add(lblFormLabel);
                                hmpr.Controls.Add(plabel);
                            }


                        }
                        System.Web.UI.HtmlControls.HtmlGenericControl pInput = new System.Web.UI.HtmlControls.HtmlGenericControl("p");
                        pInput.Attributes.Add("class", "sfForminput");
                        int FeedbackItemID1 = Int32.Parse(dt.Rows[i]["FeedbackItemID"].ToString());
                        if (dt.Rows[i]["FeedbackItem"].ToString() == "Attachment")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    FileUpload FluForm = new FileUpload();
                                    FluForm.ID = "FluForm_" + FeedbackItemID;                                   
                                    FluForm.EnableViewState = true;
                                    pInput.Controls.Add(FluForm);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);

                                }
                            }

                        }

                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Message")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    pInput.Attributes.Add("class", "sfForminput");
                                    TextBox FormMessage = new TextBox();
                                    FormMessage.ID = "FormMessage_" + FeedbackItemID;
                                    FormMessage.CssClass = "sfTextarea";
                                    FormMessage.EnableViewState = true;
                                    FormMessage.TextMode = TextBoxMode.MultiLine;
                                    FormMessage.Rows = 5;                                    
                                    RequiredFieldValidator rfvmessage = new RequiredFieldValidator();
                                    rfvmessage.ID = i.ToString();
                                    rfvmessage.ControlToValidate = FormMessage.ID;
                                    rfvmessage.CssClass = "sfError";
                                    rfvmessage.ValidationGroup = "Feedback";
                                    rfvmessage.ErrorMessage = "*";
                                    rfvmessage.Display = ValidatorDisplay.Dynamic;
                                    rfvmessage.EnableViewState = true;
                                    pInput.Controls.Add(FormMessage);
                                    pInput.Controls.Add(rfvmessage);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }

                            }


                        }

                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "PermanentCountry" || dt.Rows[i]["FeedbackItem"].ToString() == "TemporaryCountry")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    DropDownList ddlPermanentandTemporaryCountry = new DropDownList();
                                    ddlPermanentandTemporaryCountry.ID ="ddlPermanentandTemporaryCountry_"+ FeedbackItemID;
                                    ddlPermanentandTemporaryCountry.CssClass = "sfListmenu";
                                    ddlPermanentandTemporaryCountry.EnableViewState = true;
                                    ddlPermanentandTemporaryCountry.SelectedIndexChanged += new EventHandler(cddl_SelectedIndexChanged);
                                    
                                    List<ListManagementInfo> linqPermanentCountry = ListManagementController.GetListEntrybyNameAndID("Country", -1, GetCurrentCultureName);
                                    ddlPermanentandTemporaryCountry.DataSource = linqPermanentCountry;
                                    ddlPermanentandTemporaryCountry.DataValueField = "Value";
                                    ddlPermanentandTemporaryCountry.DataTextField = "Text";
                                    ddlPermanentandTemporaryCountry.DataBind();
                                    if (ddlPermanentandTemporaryCountry.Items.Count > 0)
                                    {
                                        ddlPermanentandTemporaryCountry.SelectedIndex = 0;
                                        ParentKey = "Country." + ddlPermanentandTemporaryCountry.SelectedItem.Value;
                                        ddlPermanentandTemporaryCountry.AutoPostBack = true;
                                    }
                                    pInput.Controls.Add(ddlPermanentandTemporaryCountry);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }

                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "PermanentState")
                        {
                            if (IsActive)
                            {
                                try
                                {

                                    DropDownList ddlPermanentState = new DropDownList();
                                    ddlPermanentState.ID ="ddlPermanentState_"+ FeedbackItem;
                                    ddlPermanentState.CssClass = "sfListmenu";
                                    ddlPermanentState.EnableViewState = true;
                                    ddlPermanentState.AutoPostBack = true;
                                    
                                    string listName = "Region";
                                    List<ListManagementInfo> linqPermanentState = ListManagementController.GetListEntriesByNameParentKeyAndPortalID(listName, ParentKey, -1, GetCurrentCultureName);
                                    ddlPermanentState.DataSource = linqPermanentState;
                                    ddlPermanentState.DataValueField = "Value";
                                    ddlPermanentState.DataTextField = "Text";
                                    ddlPermanentState.DataBind();
                                    if (ddlPermanentState.Items.Count > 0)
                                    {
                                        ddlPermanentState.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        hmpr.Visible = false;
                                    }
                                    pInput.Controls.Add(ddlPermanentState);
                                    hmpr.Controls.Add(pInput);
                                    ViewState["VCddlPermanentState"] = ddlPermanentState.ID;
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }



                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "TemporaryState")
                        {
                            if (IsActive)
                            {
                                try
                                {

                                    DropDownList ddlTemporaryState = new DropDownList();
                                    ddlTemporaryState.ID ="ddlTemporaryState_"+ FeedbackItemID;
                                    ddlTemporaryState.CssClass = "sfListmenu";
                                    ddlTemporaryState.EnableViewState = true;
                                    ddlTemporaryState.AutoPostBack = true;
                                    
                                    string listName = "Region";
                                    List<ListManagementInfo> linqPermanentState = ListManagementController.GetListEntriesByNameParentKeyAndPortalID(listName, ParentKey, -1, GetCurrentCultureName);
                                    ddlTemporaryState.DataSource = linqPermanentState;
                                    ddlTemporaryState.DataValueField = "Value";
                                    ddlTemporaryState.DataTextField = "Text";
                                    ddlTemporaryState.DataBind();
                                    if (ddlTemporaryState.Items.Count > 0)
                                    {
                                        ddlTemporaryState.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        hmpr.Visible = false;
                                    }
                                    pInput.Controls.Add(ddlTemporaryState);
                                    hmpr.Controls.Add(pInput);
                                    ViewState["VCddlTemporaryState"] = ddlTemporaryState.ID;
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }

                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Email1" || dt.Rows[i]["FeedbackItem"].ToString() == "Email2")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    TextBox txtemail = new TextBox();
                                    txtemail.ID ="txtemail_"+ FeedbackItemID;
                                    txtemail.CssClass = "sfInputbox";
                                    txtemail.EnableViewState = true;
                                    

                                    RequiredFieldValidator rfvEmail = new RequiredFieldValidator();
                                    rfvEmail.ID = "rfvEmail_" + i.ToString();
                                    rfvEmail.ControlToValidate = txtemail.ID;
                                    rfvEmail.CssClass = "sfError";
                                    rfvEmail.ValidationGroup = "Feedback";
                                    rfvEmail.ErrorMessage = "*";
                                    rfvEmail.EnableViewState = true;
                                    rfvEmail.Display = ValidatorDisplay.Dynamic;

                                    RegularExpressionValidator revemail = new RegularExpressionValidator();
                                    revemail.ID = "revEmail_" + i.ToString();
                                    revemail.ControlToValidate = txtemail.ID;
                                    revemail.CssClass = "sfError";
                                    revemail.ValidationGroup = "Feedback";
                                    revemail.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                                    revemail.ErrorMessage = "*";
                                    revemail.EnableViewState = true;
                                    revemail.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(txtemail);
                                    pInput.Controls.Add(rfvEmail);
                                    pInput.Controls.Add(revemail);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }
                        }

                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Mobile")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    TextBox txtmobile = new TextBox();
                                    txtmobile.ID ="txtmobile_"+ FeedbackItemID;
                                    txtmobile.CssClass = "sfInputbox";
                                    txtmobile.EnableViewState = true;
                                    RegularExpressionValidator revmobile = new RegularExpressionValidator();
                                    revmobile.ID = i.ToString();
                                    revmobile.ControlToValidate = txtmobile.ID;
                                    revmobile.CssClass = "sfError";
                                    revmobile.ValidationGroup = "Feedback";
                                    revmobile.ValidationExpression = @"^\d{10,20}";
                                    revmobile.ErrorMessage = "*";
                                    revmobile.EnableViewState = true;
                                    revmobile.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(txtmobile);
                                    pInput.Controls.Add(revmobile);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }

                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Phone1" || dt.Rows[i]["FeedbackItem"].ToString() == "Phone2")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    TextBox txtphone = new TextBox();
                                    txtphone.ID = "txtphone_" + FeedbackItemID;
                                    txtphone.CssClass = "sfInputbox";
                                    txtphone.EnableViewState = true;
                                    RegularExpressionValidator revphone = new RegularExpressionValidator();
                                    revphone.ID = i.ToString();
                                    revphone.ControlToValidate = txtphone.ID;
                                    revphone.CssClass = "sfError";
                                    revphone.ValidationGroup = "Feedback";
                                    revphone.ValidationExpression = @"^\d{7,12}";
                                    revphone.ErrorMessage = "*";
                                    revphone.EnableViewState = true;
                                    revphone.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(txtphone);
                                    pInput.Controls.Add(revphone);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }
                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Website")
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    TextBox txtwebsite = new TextBox();
                                    txtwebsite.ID = "txtwebsite_" + FeedbackItemID;
                                    txtwebsite.CssClass = "sfInputbox";
                                    RegularExpressionValidator revwebsite = new RegularExpressionValidator();
                                    revwebsite.ID = i.ToString();
                                    revwebsite.ControlToValidate = txtwebsite.ID;
                                    revwebsite.CssClass = "cssClassNormalRed";
                                    revwebsite.ValidationGroup = "Feedback";
                                    revwebsite.ValidationExpression = @"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$";
                                    revwebsite.ErrorMessage = "*";
                                    revwebsite.EnableViewState = true;
                                    revwebsite.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(txtwebsite);
                                    pInput.Controls.Add(revwebsite);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }

                            }
                        }
                        else if (dt.Rows[i]["FeedbackItem"].ToString() == "Name")
                        {

                            if (IsActive)
                            {
                                try
                                {
                                    TextBox FormTextBox = new TextBox();
                                    FormTextBox.ID ="FormTextBox_"+ FeedbackItemID;
                                    FormTextBox.CssClass = "sfInputbox";
                                    FormTextBox.EnableViewState = true;
                                    RequiredFieldValidator rfvName = new RequiredFieldValidator();
                                    rfvName.ID = i.ToString();
                                    rfvName.ControlToValidate = FormTextBox.ID;
                                    rfvName.CssClass = "sfError";
                                    rfvName.ValidationGroup = "Feedback";
                                    rfvName.ErrorMessage = "*";
                                    rfvName.EnableViewState = true;
                                    rfvName.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(FormTextBox);
                                    pInput.Controls.Add(rfvName);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }

                        }
                        else if ((dt.Rows[i]["FeedbackItem"].ToString() != "FormTitle" && dt.Rows[i]["FeedbackItem"].ToString() != "FormInfo"))
                        {
                            if (IsActive)
                            {
                                try
                                {
                                    TextBox FormTextBox = new TextBox();
                                    FormTextBox.ID ="FormTextBox_"+ FeedbackItemID;
                                    FormTextBox.CssClass = "sfInputbox";
                                    FormTextBox.EnableViewState = true;
                                    RequiredFieldValidator rfv = new RequiredFieldValidator();
                                    rfv.ID = i.ToString();
                                    rfv.ControlToValidate = FormTextBox.ID;
                                    rfv.CssClass = "sfError";
                                    rfv.ValidationGroup = "Feedback";
                                    rfv.ErrorMessage = "*";
                                    rfv.EnableViewState = true;
                                    rfv.Display = ValidatorDisplay.Dynamic;
                                    pInput.Controls.Add(FormTextBox);
                                    pInput.Controls.Add(rfv);
                                    hmpr.Controls.Add(pInput);
                                }
                                catch (Exception ex)
                                {
                                    ProcessException(ex);
                                }
                            }
                        }
                        if (hmpr.HasControls())
                        {
                            pnlFormView.Controls.Add(hmpr);
                        }
                    }
                }
            }
        }

        protected void cddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                string listName = "Region";
                string parentKey = "Country." + ddl.SelectedItem.Value;
                
                List<ListManagementInfo> listDetail = ListManagementController.GetListEntriesByNameParentKeyAndPortalID(listName, parentKey, -1, GetCurrentCultureName);
                if (ddl.ID.StartsWith("P"))
                {

                    if (ViewState["VCddlPermanentState"] != null)
                    {

                        string strID = ViewState["VCddlPermanentState"].ToString();

                        DropDownList sddl = (DropDownList)this.FindControl(strID);
                        if (sddl != null)
                        {
                            sddl.DataSource = listDetail;
                            sddl.DataTextField = "Text";
                            sddl.DataValueField = "Value";
                            sddl.DataBind();
                            if (sddl.Items.Count > 0)
                            {
                                sddl.Parent.Parent.Visible = true;
                            }
                            else
                            {
                                sddl.Parent.Parent.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    if (ViewState["VCddlTemporaryState"] != null)
                    {
                        string strID = ViewState["VCddlPermanentState"].ToString();
                        DropDownList sddl = (DropDownList)this.FindControl(strID);
                        if (sddl != null)
                        {
                            sddl.DataSource = listDetail;
                            sddl.DataTextField = "Text";
                            sddl.DataValueField = "Value";
                            sddl.DataBind();
                            if (sddl.Items.Count > 0)
                            {
                                sddl.Parent.Parent.Visible = true;
                            }
                            else
                            {
                                sddl.Parent.Parent.Visible = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        string _FormTitle = string.Empty;
        string _FormInformation = string.Empty;
        string _Name = string.Empty;
        string _PermanentCity = string.Empty;
        string _PermanentZipCode = string.Empty;
        string _PermanentPostCode = string.Empty;
        string _PermanentAddress = string.Empty;
        string _TemporaryCity = string.Empty;
        string _TemporaryZipCode = string.Empty;
        string _TemporaryPostalCode = string.Empty;
        string _TemporaryAddress = string.Empty;
        string _Email1 = string.Empty;
        string _Email2 = string.Empty;
        string _Phone1 = string.Empty;
        string _Phone2 = string.Empty;
        string _Mobile = string.Empty;
        string _Company = string.Empty;
        string _Website = string.Empty;
        string _Message = string.Empty;
        string _PermanentCountry = string.Empty;
        string _PermanentState = string.Empty;
        string _TemporaryCountry = string.Empty;
        string _TemporaryState = string.Empty;
        string _Attachment = string.Empty;
        public void GetTextboxData(string FormKey, string FormValue)
        {
            switch (FormKey)
            {
                case "FormTitle":
                    _FormTitle = FormValue;
                    break;
                case "FormInfo":
                    _FormInformation = FormValue;
                    break;
                case "Name":
                    _Name = FormValue;
                    break;
                case "PermanentCity":
                    _PermanentCity = FormValue;
                    break;
                case "PermanentZipCode":
                    _PermanentZipCode = FormValue;
                    break;
                case "PermanentPostCode":
                    _PermanentPostCode = FormValue;
                    break;
                case "PermanentAddress":
                    _PermanentAddress = FormValue;
                    break;
                case "TemporaryCity":
                    _TemporaryCity = FormValue;
                    break;
                case "TemporaryZipCode":
                    _TemporaryZipCode = FormValue;
                    break;
                case "TemporaryPostalCode":
                    _TemporaryPostalCode = FormValue;
                    break;
                case "TemporaryAddress":
                    _TemporaryAddress = FormValue;
                    break;
                case "Email1":
                    _Email1 = FormValue;
                    break;
                case "Email2":
                    _Email2 = FormValue;
                    break;
                case "Phone1":
                    _Phone1 = FormValue;
                    break;
                case "Phone2":
                    _Phone2 = FormValue;
                    break;
                case "Mobile":
                    _Mobile = FormValue;
                    break;
                case "Company":
                    _Company = FormValue;
                    break;
                case "Website":
                    _Website = FormValue;
                    break;
                case "Message":
                    _Message = FormValue;
                    break;
                case "PermanentCountry":
                    _PermanentCountry = FormValue;
                    break;
                case "PermanentState":
                    _PermanentState = FormValue;
                    break;
                case "TemporaryCountry":
                    _TemporaryCountry = FormValue;
                    break;
                case "TemporaryState":
                    _TemporaryState = FormValue;
                    break;
                case "Attachment":
                    _Attachment = FormValue;
                    break;
            }


        }

        private void GetFormDataRecursive(Control controls)
        {
            foreach (Control cont in controls.Controls)
            {
                //TextBox
                #region For TextBox
                if (cont.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)cont;
                    if (txt != null)
                    {
                        string conID = txt.ID;
                        GetTextboxData(txt.ID, txt.Text.Trim());
                    }
                }
                #endregion

                //DropDownList
                #region DropDown
                if (cont.GetType() == typeof(DropDownList))
                {
                    DropDownList ddl = (DropDownList)cont;
                    if (ddl != null && ddl.Items.Count > 0)
                    {
                        string conID = ddl.ID;
                        GetTextboxData(ddl.ID, ddl.SelectedItem.Text);
                        // ddl.SelectedIndex = 0;
                    }
                }
                #endregion

                //FileUpload
                #region FileUpload
                if (cont.GetType() == typeof(FileUpload))
                {
                    FileUpload flufileupload = (FileUpload)cont;
                    if (flufileupload != null)
                    {
                        string extension = string.Empty;
                        string conID = flufileupload.ID;
                        if (flufileupload.HasFile)
                        {
                            if (System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".txt" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".doc" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".docx" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".bmp" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".gif")
                            {
                                string path = HttpContext.Current.Server.MapPath("~/");
                                string temPath = "Modules\\FeedBack\\FeedbackFormApplication\\";
                                string savepath = Path.Combine(path, temPath);
                                if (!Directory.Exists(savepath))
                                    Directory.CreateDirectory(savepath);
                                flufileupload.SaveAs(savepath + flufileupload.FileName);
                                GetTextboxData(flufileupload.ID, flufileupload.FileName);
                            }
                            else
                            {
                                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("FeedBack", "PleaseUploadTheValidFile"), "", SageMessageType.Alert);
                            }
                        }
                    }
                }
                #endregion

                if (cont.HasControls())
                {
                    GetFormDataRecursive(cont);
                }
            }
        }
        private void GetFormData()
        {

            #region GETCONTROLVALUE

            foreach (Control cont in pnlFormView.Controls)
            {
                //TextBox
                #region For TextBox
                if (cont.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)cont;
                    if (txt != null)
                    {
                        string conID = txt.ID;
                        GetTextboxData(txt.ID, txt.Text.Trim());
                    }
                }
                #endregion

                //DropDownList
                #region DropDown
                if (cont.GetType() == typeof(DropDownList))
                {
                    DropDownList ddl = (DropDownList)cont;
                    if (ddl != null && ddl.Items.Count > 0)
                    {
                        string conID = ddl.ID;
                        GetTextboxData(ddl.ID, ddl.SelectedItem.Text);
                        // ddl.SelectedIndex = 0;
                    }
                }
                #endregion

                //FileUpload
                #region FileUpload
                if (cont.GetType() == typeof(FileUpload))
                {
                    FileUpload flufileupload = (FileUpload)cont;
                    if (flufileupload != null)
                    {
                        string extension = string.Empty;
                        string conID = flufileupload.ID;
                        if (flufileupload.HasFile)
                        {
                            if (System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".txt" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".doc" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".docx" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".bmp" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(flufileupload.FileName).ToLower() == ".gif")
                            {
                                string path = HttpContext.Current.Server.MapPath("~/");
                                string temPath = "Modules\\FeedBack\\FeedbackFormApplication\\";
                                string savepath = Path.Combine(path, temPath);
                                if (!Directory.Exists(savepath))
                                    Directory.CreateDirectory(savepath);
                                flufileupload.SaveAs(savepath + flufileupload.FileName);
                                GetTextboxData(flufileupload.ID, flufileupload.FileName);
                            }
                            else
                            {
                                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("FeedBack", "PleaseUploadTheValidFile"), "", SageMessageType.Alert);
                            }
                        }
                    }
                }
                #endregion

                if (cont.HasControls())
                {
                    GetFormDataRecursive(cont);
                }
            }
            #endregion

            string  LINQMailSetting = ListManagementController.GetFeedbackSettingValueList(GetPortalID);
            if (LINQMailSetting == "1")
            {
                try
                {
                    string emailSuperAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserEmail);
                    string emailSiteAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
                    MailHelper.SendMailOneAttachment(_Email1, emailSiteAdmin, string.Empty, _Message, _Attachment, string.Empty, emailSuperAdmin);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "MailIsSendSuccessfully"), "", SageMessageType.Success);

                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }

            if (LINQMailSetting == "2")
            {
                try
                {

                    ListManagementController.FeedbackFormAdd(_FormTitle, _FormInformation, _Name, _PermanentCountry, _PermanentState,
                        _PermanentCity, _PermanentZipCode, _PermanentPostCode, _PermanentAddress, _TemporaryCountry,
                        _TemporaryState, _TemporaryCity, _TemporaryZipCode, _TemporaryPostalCode,
                        _TemporaryAddress, _Email1, _Email2, _Phone1, _Phone2, _Mobile,
                        _Company, _Website, _Message, _Attachment, true, DateTime.Now, GetPortalID, GetUsername);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "InformationSavedSuccessfully"), "", SageMessageType.Success);


                }

                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }

            if (LINQMailSetting == "3")
            {
                try
                {

                    string emailSuperAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SuperUserEmail);
                    string emailSiteAdmin = pagebase.GetSettingsByKey(SageFrameSettingKeys.SiteAdminEmailAddress);
                    MailHelper.SendMailOneAttachment(_Email1, emailSiteAdmin, string.Empty, _Message, _Attachment, string.Empty, emailSuperAdmin);
                    ListManagementController.FeedbackFormAdd(_FormTitle, _FormInformation, _Name, _PermanentCountry, _PermanentState,
                        _PermanentCity, _PermanentZipCode, _PermanentPostCode, _PermanentAddress, _TemporaryCountry,
                        _TemporaryState, _TemporaryCity, _TemporaryZipCode, _TemporaryPostalCode,
                        _TemporaryAddress, _Email1, _Email2, _Phone1, _Phone2, _Mobile, _Company,
                        _Website, _Message, _Attachment, true, DateTime.Now, GetPortalID, GetUsername);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "MailIsSendAndSavedSuccessfully"), "", SageMessageType.Success);

                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }

            }

            clearformdata();

        }

        private void clearFormDataRecursive(Control controls)
        {
            foreach (Control cont in controls.Controls)
            {
                #region "Clear Section"
                //TextBox
                if (cont.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)cont;
                    if (txt != null)
                    {
                        txt.Text = "";
                    }
                }
                //DropDownList
                if (cont.GetType() == typeof(DropDownList))
                {
                    DropDownList ddl = (DropDownList)cont;
                    if (ddl != null)
                    {
                        if (ddl.Items.Count > 0)
                        {
                            ddl.SelectedIndex = 0;
                        }
                    }
                }

                if (cont.HasControls())
                {
                    clearFormDataRecursive(cont);
                }
                #endregion
            }
        }
        private void clearformdata()
        {
            foreach (Control cont in pnlFormView.Controls)
            {
                #region "Clear Section"
                //TextBox
                if (cont.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)cont;
                    if (txt != null)
                    {
                        txt.Text = "";
                    }
                }
                //DropDownList
                if (cont.GetType() == typeof(DropDownList))
                {
                    DropDownList ddl = (DropDownList)cont;
                    if (ddl != null)
                    {
                        if (ddl.Items.Count > 0)
                        {
                            ddl.SelectedIndex = 0;
                        }
                    }
                }

                if (cont.HasControls())
                {
                    clearFormDataRecursive(cont);
                }
                #endregion
            }
        }

        private void FillFormData()
        {
            try
            {
                #region


                Hashtable htfeedback = new Hashtable();
                DataTable LinqFormFill = ListManagementController.FeedbackItemGet(GetPortalID, GetCurrentCultureName);

                if (LinqFormFill != null)
                {
                    foreach (DataRow objResult in LinqFormFill.Rows)
                    {
                        htfeedback.Add(objResult["FeedbackItemID"].ToString(), objResult["FeedbackItem"].ToString());

                    }
                }

                if (htfeedback.Count > 0)
                {
                    #region

                    foreach (Control cont in pnlFormView.Controls)
                    {
                        if (cont.GetType() == typeof(Table))
                        {
                            foreach (Control pnlCon1 in cont.Controls)
                            {
                                if (pnlCon1.GetType() == typeof(TableRow))
                                {
                                    foreach (Control pnlCon2 in pnlCon1.Controls)
                                    {
                                        if (pnlCon2.GetType() == typeof(TableCell))
                                        {
                                            foreach (Control pnlCon3 in pnlCon2.Controls)
                                            {
                                                #region "Data Sections"


                                                //DropDownList
                                                if (pnlCon3.GetType() == typeof(DropDownList))
                                                {
                                                    DropDownList ddl = (DropDownList)pnlCon3;
                                                    if (ddl != null)
                                                    {
                                                        string strStateddlID = string.Empty;

                                                        if (ViewState["ddlState"] != null)
                                                        {
                                                            strStateddlID = ViewState["ddlState"].ToString();
                                                        }
                                                        string conID = ddl.ID;
                                                        if (strStateddlID != conID)
                                                        {
                                                            if (ViewState["ddlCountry"] != null)
                                                            {
                                                                DropDownList ccddl = (DropDownList)this.FindControl(ViewState["ddlCountry"].ToString());
                                                            }
                                                        }
                                                        string IDColl = conID;

                                                        if (IDColl.Length > 0)
                                                        {
                                                            string Key = IDColl[1].ToString();
                                                            if (htfeedback.ContainsKey(Key))
                                                            {
                                                                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(htfeedback[Key].ToString()));
                                                            }
                                                        }

                                                    }
                                                }

                                                #endregion

                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    #endregion

                }
                else
                {
                    //Clear Form Data.


                    foreach (Control cont in pnlFormView.Controls)
                    {
                        if (cont.GetType() == typeof(Table))
                        {
                            foreach (Control pnlCon1 in cont.Controls)
                            {
                                if (pnlCon1.GetType() == typeof(TableRow))
                                {
                                    foreach (Control pnlCon2 in pnlCon1.Controls)
                                    {
                                        if (pnlCon2.GetType() == typeof(TableCell))
                                        {
                                            foreach (Control pnlCon3 in pnlCon2.Controls)
                                            {
                                                #region "Data Sections For Clear"
                                                //TextBox
                                                if (pnlCon3.GetType() == typeof(TextBox))
                                                {
                                                    TextBox txt = (TextBox)pnlCon3;
                                                    if (txt != null)
                                                    {
                                                        string conID = txt.ID;
                                                        //string[] IDColl = conID.Split("_".ToCharArray());
                                                        //if (IDColl.Length > 0)
                                                        //{
                                                        //    string Key = IDColl[1].ToString();
                                                        //    txt.Text = "";
                                                        //}
                                                        txt.Text = "";
                                                    }
                                                }
                                                //DropDownList
                                                if (pnlCon3.GetType() == typeof(DropDownList))
                                                {
                                                    DropDownList ddl = (DropDownList)pnlCon3;
                                                    if (ddl != null)
                                                    {
                                                        string conID = ddl.ID;
                                                        // string[] IDColl = conID.Split("_".ToCharArray());
                                                        string IDColl = conID;
                                                        if (IDColl.Length > 0)
                                                        {
                                                            string Key = IDColl[1].ToString();
                                                            if (ddl.Items.Count > 0)
                                                            {
                                                                ddl.SelectedIndex = 0;
                                                            }
                                                        }
                                                        ddl.SelectedIndex = 0;
                                                    }
                                                }

                                                #endregion


                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                #endregion

                }
                //#endregion

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            GetFormData();
        }
    }
}
