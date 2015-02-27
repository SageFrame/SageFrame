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
using SageFrame.Search;
using SageFrame.SageFrameClass;

public partial class Modules_SageSearch_ctl_SageSearchSetting : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AddImageUrls();
                BindSearchButtonType();
                LoadSearchSettings();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void BindSearchButtonType()
    {
        try
        {
            //rdblSearchButtonType
            rdblSearchButtonType.DataSource = SageFrameLists.SearchButtonTypes();
            rdblSearchButtonType.DataTextField = "Value";
            rdblSearchButtonType.DataValueField = "Key";
            rdblSearchButtonType.DataBind();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void LoadSearchSettings()
    {
        try
        {
            SageFrameSearch con = new SageFrameSearch();
            SageFrameSearchSettingInfo objSearchSettingInfo = con.LoadSearchSettings(GetPortalID, GetCurrentCultureName);
            if (objSearchSettingInfo != null)
            {
                rdblSearchButtonType.SelectedIndex = rdblSearchButtonType.Items.IndexOf(rdblSearchButtonType.Items.FindByValue(objSearchSettingInfo.SearchButtonType.ToString()));
                txtSearchButtonText.Text = objSearchSettingInfo.SearchButtonText;
                txtSearchButtonImage.Text = objSearchSettingInfo.SearchButtonImage;
                txtSearchResultPerPage.Text = objSearchSettingInfo.SearchResultPerPage.ToString();
                txtSearchResultPageName.Text = objSearchSettingInfo.SearchResultPageName;
                txtMaxSearchChracterAllowedWithSpace.Text = objSearchSettingInfo.MaxSearchChracterAllowedWithSpace.ToString();
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void SaveSearchSettings()
    {
        try
        {
            if (txtSearchResultPageName.Text.Trim() != string.Empty && txtSearchResultPerPage.Text.Trim() != string.Empty && txtMaxSearchChracterAllowedWithSpace.Text.Trim() != string.Empty)
            {
                SageFrameSearchSettingInfo objSearchSettingInfo = new SageFrameSearchSettingInfo();
                objSearchSettingInfo.SearchButtonType = Int32.Parse(rdblSearchButtonType.SelectedValue);
                objSearchSettingInfo.SearchButtonText = txtSearchButtonText.Text;
                objSearchSettingInfo.SearchButtonImage = txtSearchButtonImage.Text.Trim();
                objSearchSettingInfo.SearchResultPageName = txtSearchResultPageName.Text.Trim();
                objSearchSettingInfo.SearchResultPerPage = Int32.Parse(txtSearchResultPerPage.Text.Trim());
                objSearchSettingInfo.MaxSearchChracterAllowedWithSpace = Int32.Parse(txtMaxSearchChracterAllowedWithSpace.Text.Trim());
                SageFrameSearch con = new SageFrameSearch();
                con.AddUpdateSageFrameSearchSetting(objSearchSettingInfo, GetPortalID, GetCurrentCultureName, GetUsername);
                ShowMessage("", GetSageMessage("SageFrameSearch", "SearchSettingSavedSuccessfully"), "", SageMessageType.Success);
            }
            else
            {
                ShowMessage("", GetSageMessage("SageFrameSearch", "BlankValueNotAllowed"), "", SageMessageType.Alert);
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
        txtSearchResultPerPage.Attributes.Add("OnKeydown", "return NumberKey(event)");
        txtMaxSearchChracterAllowedWithSpace.Attributes.Add("OnKeydown", "return NumberKey(event)");
    }

    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        SaveSearchSettings();
        //After Saving load again settings
        LoadSearchSettings();
    }

    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        LoadSearchSettings();
    }
}
