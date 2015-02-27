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
using SageFrame.News;
using System.IO;

namespace SageFrame.Modules.NewsModule
{
    public partial class NewsEdit : BaseAdministrationUserControl
    {
        NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
        public Int32 usermoduleID = 0;
        public Int32 usermoduleIDControl = 0;
        System.Nullable<Int32> _newNewsCategoryID = 0;
        System.Nullable<Int32> _newCategoryCount = 0;
        System.Nullable<Int32> _totalNewsCategoryCount = 0;
        System.Nullable<Int32> _ImageID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                usermoduleID = Int32.Parse(SageUserModuleID);
                usermoduleIDControl = Int32.Parse(SageUserModuleID);
                if (!Page.IsPostBack)
                {
                    AddImageUrls();
                    PopulateCategory(ddlCategory, false);
                    PopulateNewsType();
                    BindNewsGrid();
                    BindNewsCategories();
                    PanelVisibility1(false, true);
                    PanelVisibility2(true, false, false);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void PanelVisibility1(bool AddNews, bool NewsInGrid)
        {
            pnlAddNews.Visible = AddNews;
            pnlNewsInGrid.Visible = NewsInGrid;            
        }

        private void PanelVisibility2(bool ManageNewsCategory, bool AddNewsCategory, bool NewsCategoryID)
        {
            pnlManageNewsCategory.Visible = ManageNewsCategory;
            pnlAddNewsCategory.Visible = AddNewsCategory;
            rowNewsCategoryID.Visible = NewsCategoryID;
        }

        private void AddImageUrls()
        {
            imbUpdateNews.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbNewsCalender.ImageUrl =  GetTemplateImageUrl("imgcalendar.png", true);
            imbAddNews.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
            imbNewsCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);

            imbAddNewsCategory.ImageUrl = GetTemplateImageUrl("imgadd.png", true);            
            imbUpdate.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
        }

        private void PopulateNewsType()
        {
            var LINQ = db.sp_NewsType(GetPortalID);
            ddlNewsType.DataSource = LINQ;
            ddlNewsType.DataValueField = "NewsTypeID";
            ddlNewsType.DataTextField = "NewsType";
            ddlNewsType.DataBind();
            ddlNewsType.Items.Insert(0, new ListItem("--Select NewsType--", "-1"));
        }

        private void PopulateCategory(DropDownList ddlCategory, bool ShowAll)
        {
            try
            {
                var LINQ = db.sp_NewsCategory(GetPortalID, null);
                ddlCategory.DataSource = LINQ;
                ddlCategory.DataValueField = "NewsCategoryID";
                ddlCategory.DataTextField = "NewsCategory";
                ddlCategory.DataBind();
                if (ShowAll == true)
                {
                    ddlCategory.Items.Insert(0, new ListItem("All News Category", "-1"));
                }
                else
                {
                    ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "-1"));
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvManageNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvManageNews.PageIndex = e.NewPageIndex;
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
        }

        protected void gdvManageNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("imbDelete");
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("NewsModule", "AreYouSureToDelete") + "')");

            }

        }

        protected void gdvManageNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gdvManageNews_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void gdvManageNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = int.Parse(e.CommandArgument.ToString());
            hdfNewsID.Value = Id.ToString();
            if (hdfNewsID.Value != "")
            {
                switch (e.CommandName)
                {
                    case "Edit":
                        EditNewsbyNewsID(Id);
                        PanelVisibility1(true, false);
                        break;
                    case "Delete":
                        try
                        {
                            db.sp_NewsDeletebyNewsID(Id, GetPortalID, GetUsername);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsIsDeletedSuccessfully"), "", SageMessageType.Success);
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex);
                        }
                        break;
                }
            }
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
        }

        private void EditNewsbyNewsID(int ID)
        {
            try
            {
                var LINQ = db.sp_NewsAllbyNewsID(ID).SingleOrDefault();
                if (LINQ != null)
                {
                    ddlNewsType.SelectedIndex = ddlNewsType.Items.IndexOf(ddlNewsType.Items.FindByValue(LINQ.NewsTypeID.ToString()));
                    ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(LINQ.NewsCategoryID.ToString()));
                    txtNewsTitle.Text = LINQ.NewsTitle;
                    txtNewsShortDescription.Text = LINQ.NewsShortDescription;
                    txtLongDesc.Value = LINQ.NewsLongDescription;
                    if (LINQ.NewsDate != null)
                    {
                        txtNewsDate.Text = CommonHelper.ShortTimeReturn(LINQ.NewsDate);
                    }
                    chkIsActive.Checked = bool.Parse(LINQ.IsActive.ToString());
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }


        protected void gdvManageNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gdvManageNews_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void imbUpdateNews_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                if (ddlNewsType.SelectedIndex != 0 && ddlCategory.SelectedIndex != 0)
                {
                    string _newsTitle = txtNewsTitle.Text;
                    string _newShortdescription = txtNewsShortDescription.Text;
                    string _newsLongdescription = System.Text.RegularExpressions.Regex.Replace(txtLongDesc.Value, "<br/>$", "");
                    _newsLongdescription = System.Text.RegularExpressions.Regex.Replace(txtLongDesc.Value, "^&nbsp;", "");

                    DateTime _newsDate = DateTime.Now;
                    if (txtNewsDate.Text != "")
                    {
                        _newsDate = DateTime.Parse(txtNewsDate.Text);
                    }

                    if (hdfNewsID.Value != "")
                    {
                        try
                        {
                            int _newsId = Int32.Parse(hdfNewsID.Value);                            
                            int _newstypeId = int.Parse(ddlNewsType.SelectedValue);
                            int _newscategoryId = int.Parse(ddlCategory.SelectedValue);
                            db.sp_NewsUpdatebyNewsID(_newsId, _newstypeId, _newscategoryId, _newsTitle, _newShortdescription, _newsLongdescription, _newsDate, chkIsActive.Checked, true, GetPortalID, GetUsername);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsIsUpdatedSuccessfully"), "", SageMessageType.Success);
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex);
                        }
                    }
                    else if (hdfNewsID.Value == "")
                    {

                        try
                        {
                            db.sp_NewsAddFromCategory(Int32.Parse(ddlNewsType.SelectedValue), Int32.Parse(ddlCategory.SelectedValue), _newsTitle, _newShortdescription, _newsLongdescription, _newsDate, chkIsActive.Checked, DateTime.Now, GetPortalID);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsIsAddedSuccessfully"), "", SageMessageType.Success);
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex);
                        }
                    }
                    BindNewsGrid();
                }
                else
                {
                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsModule", "PleaseSelectBothTheNewsTypeAndCatgoryName"), "", SageMessageType.Error);
                }
            }
        }

        private void ClearForm()
        {
            ddlNewsType.ClearSelection();
            ddlCategory.ClearSelection();
            ddlNewsType.SelectedIndex = ddlNewsType.Items.IndexOf(ddlNewsType.Items.FindByValue("-1"));
            ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue("-1"));
            txtNewsTitle.Text = "";
            txtNewsShortDescription.Text = "";
            txtLongDesc.Value = "";
            txtNewsDate.Text = "";
            chkIsActive.Checked = true;
        }

        private void BindNewsGrid()
        {
            PopulateCategory(ddlNewsCatList, true);
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
            PanelVisibility1(false, true);
            hdfNewsID.Value = "";
        }

        private void BindGrid(int newsCategoryID)
        {
            var LINQ = db.sp_NewsView(GetPortalID, newsCategoryID, null);
            gdvManageNews.DataSource = LINQ;
            gdvManageNews.DataBind();
        }

        protected void imbAddNews_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
            PanelVisibility1(true, false);
        }

        protected void imbNewsCancel_Click(object sender, ImageClickEventArgs e)
        {
            BindNewsGrid();
        }

        protected void cvFckLong_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((txtLongDesc.Value == "&nbsp;") || (txtLongDesc.Value == "<br />") || (txtLongDesc.Value.Length == 0))
            {
                cvLong.ErrorMessage = GetSageMessage("NewsModule", "PleaseEnterSomeContent");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void imbAddNewsCategory_Click(object sender, ImageClickEventArgs e)
        {
            PanelVisibility2(false, true, false);
            ClearCategoryForm();
            lblUpdate.Text = GetSageMessage("NewsModule", "Save");
        }

        private void ClearCategoryForm()
        {
            txtCategoryName.Text = "";
            txtCategoryDescription.Text = "";
            fluNewsCategory.Dispose();
            chkPublish.Checked = true;
            hdfNewsCategoryID.Value = "";
        }

        protected void imbUpdate_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                bool isActive = false;
                if (chkPublish.Checked == true)
                {
                    isActive = true;
                }
                db.sp_NewsCategoryCount(GetPortalID, "NewsCategory", ref _totalNewsCategoryCount);

                if (hdfNewsCategoryID.Value != "")
                {
                    if (_totalNewsCategoryCount <= GetNewsCategoryCountSetting())
                    {
                        SaveNewsCategory(isActive);
                    }
                }
                else if (hdfNewsCategoryID.Value == "")
                {
                    if (_totalNewsCategoryCount < GetNewsCategoryCountSetting())
                    {
                        SaveNewsCategory(isActive);
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsModule", "LimitForCategory") + " " + GetNewsCategoryCountSetting(), "", SageMessageType.Error);
                    }
                }
                PopulateCategory(ddlCategory, false);
                PopulateCategory(ddlNewsCatList, true);
                BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
            }
        }

        protected void SaveNewsCategory(bool isActive)
        {
            string error = string.Empty;

            string strLargeImagePath = string.Empty;
            string strMediumImagePath = string.Empty;
            string strSmallImagePath = string.Empty;
            string strImageExtension = string.Empty;
            if (fluNewsCategory.HasFile)
            {
                string path = HttpContext.Current.Server.MapPath("~/");
                string largeImagePath = "Modules\\NewsModule\\NewsCategoryImage";
                string savedPathLarge = Path.Combine(path, largeImagePath);
                string mediumImagePath = "Modules\\NewsModule\\NewsCategoryImage\\MediumBannerImage";
                string savedPathMedium = Path.Combine(path, mediumImagePath);
                string smallImagePath = "Modules\\NewsModule\\NewsCategoryImage\\SmallBannerImage";
                string savedPathSmall = Path.Combine(path, smallImagePath);

                char[] separator = new char[] { '.' };
                string[] fileNames = fluNewsCategory.FileName.Split(separator);
                string fileName = fileNames[0];
                string extension = string.Empty;
                if (fileNames.Length > 1)
                {
                    extension = fileNames[fileNames.Length - 1];
                }
                if (PictureManager.IsValidIconContentType(extension) && fluNewsCategory.PostedFile.ContentLength <= GetCatImageSizeSetting())
                {
                    fileName = PictureManager.GetFileName(fileName);
                    strLargeImagePath = PictureManager.SaveImage(fluNewsCategory, fileName + "." + extension, savedPathLarge);
                    strMediumImagePath = PictureManager.CreateMediumThumnail(strLargeImagePath, GetPortalID, fileName + "." + extension, savedPathMedium, 200);
                    strSmallImagePath = PictureManager.CreateSmallThumnail(strLargeImagePath, GetPortalID, fileName + "." + extension, savedPathSmall, 150);

                    if (hdfNewsCategoryID.Value == "")
                    {
                        db.sp_NewsCheckUniqueNewsCategoryName(0, txtCategoryName.Text.Trim(), false, ref _newCategoryCount);

                        if (_newCategoryCount == 0)
                        {
                            // Add
                            try
                            {
                                db.sp_NewsCategoryImageAdd(extension, "Modules\\NewsModule\\NewsCategoryImage\\" + fileName, "Modules\\NewsModule\\NewsCategoryImage\\MediumBannerImage\\" + fileName, "Modules\\NewsModule\\NewsCategoryImage\\SmallBannerImage\\" + fileName, isActive, GetPortalID, GetUsername, ref _ImageID);
                                db.sp_NewsCategoryAdd(ref _newNewsCategoryID, txtCategoryName.Text.Trim(),
                                        txtCategoryDescription.Text.Trim(), _ImageID, isActive, DateTime.Now, GetPortalID, GetUsername);
                                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsCategoryIsAddedSuccessfully"), "", SageMessageType.Success);
                                ImgNewsCategory.Visible = true;
                                ImgNewsCategory.ImageUrl = strSmallImagePath;
                            }
                            catch (Exception ex)
                            {
                                ProcessException(ex);
                                error += ex.Message;
                            }
                        }
                        else
                        {
                            ShowMessage(SageMessageTitle.Notification.ToString(), txtCategoryName.Text.Trim() +" "+  GetSageMessage("NewsModule", "NameAlreadyExist"), "", SageMessageType.Error);
                            error += "Name already Exist";
                        }
                    }
                    else if (hdfNewsCategoryID.Value != "")
                    {
                        db.sp_NewsCheckUniqueNewsCategoryName(Int32.Parse(hdfNewsCategoryID.Value), txtCategoryName.Text.Trim(), true, ref _newCategoryCount);
                        if (_newCategoryCount == 0)
                        {
                            // Update
                            try
                            {
                                var folderPaths = db.sp_NewsCategoryImageFoldersGet(Int32.Parse(hdfNewsCategoryID.Value), GetPortalID);
                                foreach (sp_NewsCategoryImageFoldersGetResult imageFolders in folderPaths)
                                {
                                    string largeImage = path + imageFolders.LargeImagePath + "." + imageFolders.ImageExtension;
                                    DeleteImageFiles(largeImage);
                                    string mediumImage = path + imageFolders.MediumImagePath + "." + imageFolders.ImageExtension;
                                    DeleteImageFiles(mediumImage);
                                    string smallImage = path + imageFolders.SmallImagePath + "." + imageFolders.ImageExtension;
                                    DeleteImageFiles(smallImage);  
                                }

                                db.sp_NewsCategoryImageUpdate(Int32.Parse(hdfNewsCategoryID.Value), extension, "Modules\\NewsModule\\NewsCategoryImage\\" + fileName, "Modules\\NewsModule\\NewsCategoryImage\\MediumBannerImage\\" + fileName, "Modules\\NewsModule\\NewsCategoryImage\\SmallBannerImage\\" + fileName, isActive, GetPortalID, GetUsername, ref _ImageID);
                                db.sp_NewsCategoryUpdate(Int32.Parse(hdfNewsCategoryID.Value), txtCategoryName.Text.Trim(),
                                        txtCategoryDescription.Text.Trim(), _ImageID, isActive, true, DateTime.Now, GetPortalID, GetUsername);
                                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsCategoryIsUpdatedSuccessfully"), "", SageMessageType.Success);
                                ImgNewsCategory.Visible = true;
                                ImgNewsCategory.ImageUrl = strSmallImagePath;
                            }
                            catch (Exception ex)
                            {
                                ProcessException(ex);
                                error += ex.Message;
                            }
                        }
                        else
                        {
                            ShowMessage(SageMessageTitle.Notification.ToString(), txtCategoryName.Text.Trim() + " " + GetSageMessage("NewsModule", "NameAlreadyExists"), "", SageMessageType.Error);
                            error += "Name already Exist";
                        }
                    }
                }
                else
                {
                    lblError.Text = "";
                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsModule", "InvalidImageFileOrFileLength"), "", SageMessageType.Error);
                }
            }
            else//If No Image is uploaded
            {
                if (hdfNewsCategoryID.Value != "")
                {
                    db.sp_NewsCheckUniqueNewsCategoryName(Int32.Parse(hdfNewsCategoryID.Value), txtCategoryName.Text.Trim(), true, ref _newCategoryCount);
                    if (_newCategoryCount == 0)
                    {
                        try
                        {
                            db.sp_NewsCategoryUpdate(Int32.Parse(hdfNewsCategoryID.Value), txtCategoryName.Text.Trim(),
                                    txtCategoryDescription.Text.Trim(), null, isActive, true, DateTime.Now, GetPortalID, GetUsername);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsCategoryIsUpdatedSuccessfully"), "", SageMessageType.Success);
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex);
                            error += ex.Message;
                        }
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), txtCategoryName.Text.Trim() + " " + GetSageMessage("NewsModule", "NameExistAlready"), "", SageMessageType.Error);
                        error += "Name already Exist";
                    }
                }
                else if (hdfNewsCategoryID.Value == "")
                {
                    db.sp_NewsCheckUniqueNewsCategoryName(0, txtCategoryName.Text.Trim(), false, ref _newCategoryCount);

                    if (_newCategoryCount == 0)
                    {
                        // Add
                        try
                        {
                            db.sp_NewsCategoryAdd(ref _newNewsCategoryID, txtCategoryName.Text.Trim(),
                                    txtCategoryDescription.Text.Trim(), _ImageID, isActive, DateTime.Now, GetPortalID, GetUsername);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsCategoryIsAgainAddedSuccessfully"), "", SageMessageType.Success);
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex);
                            error += ex.Message;
                        }
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("NewsModule", "NameAlreadyExistAgain"), "", SageMessageType.Error);
                        error += "Name already Exist";
                    }
                }
            }
            if (error == string.Empty)
            {
                ClearCategoryForm();
                PanelVisibility2(true, false, false);
                BindNewsCategories();
            }
        }

        private void DeleteImageFiles(string imagePath)
        {
            FileInfo imgInfo = new FileInfo(imagePath);
            if (imgInfo != null)
            {
                imgInfo.Delete();
            }
        }

        private int GetNewsCategoryCountSetting()
        {
            int categoryCount = 0;
                var News = db.sp_NewsSettingGetAll(usermoduleIDControl, GetPortalID);
                foreach (sp_NewsSettingGetAllResult setting in News)
                {
                    switch (setting.SettingKey)
                    {
                        case "MaxCategoryCount":
                            categoryCount = int.Parse(setting.SettingValue.ToString());
                            break;
                    }
                }
                return categoryCount;              
        }

        private int GetCatImageSizeSetting()
        {
            int imageSize = 50 * 1024;
            try
            {
                var News = db.sp_NewsSettingGetAll(usermoduleIDControl, GetPortalID);
                foreach (sp_NewsSettingGetAllResult setting in News)
                {
                    switch (setting.SettingKey)
                    {
                        case "CategoryImageSizeKB":
                            imageSize = int.Parse(setting.SettingValue.ToString()) * 1024;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            return imageSize;
        }

        private void BindNewsCategories()
        {
            gdvManageNewsCategory.DataSource = db.sp_NewsCategory(GetPortalID, null);
            gdvManageNewsCategory.DataBind();
        }

        protected void gdvManageNewsCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int newsCategoryId = Int32.Parse(e.CommandArgument.ToString());
                hdfNewsCategoryID.Value = newsCategoryId.ToString();
                if (hdfNewsCategoryID.Value != "")
                {
                    switch (e.CommandName)
                    {
                        case "Edit":
                            lblNewsCatID.Text = hdfNewsCategoryID.Value;
                            PanelVisibility2(false, true, true);
                            ImgNewsCategory.ImageUrl = "";
                            var NewsCatDetails = db.sp_NewsCategoryByNewsCategoryID(Int32.Parse(hdfNewsCategoryID.Value), GetPortalID).SingleOrDefault();
                            txtCategoryName.Text = NewsCatDetails.NewsCategory;
                            txtCategoryDescription.Text = NewsCatDetails.NewsCategoryDescription;
                            //fluNewsCategory.Dispose();
                            if (NewsCatDetails.SmallImagePath != null)
                            {
                                ImgNewsCategory.ImageUrl = ReturnImageURL(NewsCatDetails.SmallImagePath, NewsCatDetails.ImageExtension);
                            }
                            if (ImgNewsCategory.ImageUrl.Trim() != "")
                            {
                                ImgNewsCategory.Visible = true;
                            }
                            else
                            {
                                ImgNewsCategory.Visible = false;
                            }
                            chkPublish.Checked = bool.Parse(NewsCatDetails.IsActive.ToString());
                            break;

                        case "Delete":
                            db.sp_NewsCategoryDelete(Int32.Parse(hdfNewsCategoryID.Value), GetPortalID, GetUsername);
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsCategoryIsDeletedSuccessfully"), "", SageMessageType.Success);
                            break;
                    }
                    BindNewsCategories();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public string ReturnImageURL(string location, string extension)
        {
            if (location != "" && extension != "")
            {
                location = location.Replace("\\", "/");
                return (this.Page.ResolveUrl("~/") + location + "." + extension);
            }
            else
            {
                return "";
            }
        }

        protected void gdvManageNewsCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvManageNewsCategory.PageIndex = e.NewPageIndex;
            BindNewsCategories();
        }

        protected void gdvManageNewsCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gdvManageNewsCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gdvManageNewsCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gdvManageNewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdvManageNewsCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("imbDeleteNewsCategory");
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("NewsModule", "AreYouSureYouWantToDelete") + "')");
                Image imgIcon = e.Row.FindControl("imgIcon") as Image;
                string ImageUrl = imgIcon.ImageUrl;
                if (ImageUrl != "")
                {
                    imgIcon.Visible = true;
                }
                else
                {
                    imgIcon.Visible = false;
                }
            }
        }

        protected void imbCancel_Click(object sender, ImageClickEventArgs e)
        {
            PanelVisibility2(true, false, false);
        }

        protected void ddlNewsCatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
        }
}
}