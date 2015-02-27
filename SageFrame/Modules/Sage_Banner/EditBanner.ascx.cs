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
using SageFrame.Web;
using System.Web.UI.WebControls;
using SageFrame.SageBannner.Info;
using System.IO;
using SageFrame.SageBannner.Controller;
using System.Data;
using SageFrame.Common;
using System.Collections;
using SageFrame.Web.Utilities;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Modules_Sage_Banner_EditBanner : BaseAdministrationUserControl
{

    public string swfFileName = "";
    public int UserModuleId;
    public string modulePath = "";
    public int BannerId;



    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeCss();
        IncludeJS();
        try
        {
            modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "globalVariables", " var ImagePath='" + ResolveUrl(modulePath) + "';", true);
        
            if (!IsPostBack)
            {
                LoadBannerListOnGrid(GetPortalID, Int32.Parse(SageUserModuleID));
                ClearImageForm();
               
                LoadSagePage();
            }

            ImageURL();
            UserModuleId = Int32.Parse(SageUserModuleID);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }


    private void ImageURL()
    {

        imbSave.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
        imbSaveBanner.ImageUrl = GetAdminImageUrl("add.png", true);
        imbSaveEditorContent.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
        _cropCommand.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
        imbCancelImageEdit.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
        imbCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
        imgCancelHtmlContent.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);

    }


    private void IncludeJS()
    {
        IncludeJs("SageBanner", "/Modules/Sage_Banner/js/jquery.Jcrop.js");
    }


    private void IncludeCss()
    {
        IncludeCss("SageBanner", "/Modules/Sage_banner/css/jquery.Jcrop.css","/Modules/Sage_Banner/css/Module.css");

    }


    protected void cvFckDescription_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if ((txtBannerDescriptionToBeShown.Text == "&nbsp;") || (txtBannerDescriptionToBeShown.Text == "<br />") || (txtBannerDescriptionToBeShown.Text.Length == 0))
            {
                cvBannerDesc.ErrorMessage = SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "PleaseEnterSomeContent");
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }



    private void LoadSagePage()
    {
        ddlPagesLoad.DataSource = SageBannerController.GetAllPagesOfSageFrame(GetPortalID); ;
        ddlPagesLoad.DataTextField = "PageName";
        ddlPagesLoad.DataValueField = "TabPath";
        ddlPagesLoad.DataBind();

    }



    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            BannerId = Convert.ToInt32(ViewState["EditBannerID"]);
            int ImageID = Convert.ToInt32(Session["EditImageID"]);
            SaveBannerContent(BannerId, ImageID);
            LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
        divbannerImageContainer.Attributes.Add("style", "display:block");
        divEditBannerImage.Attributes.Add("style", "display:none");
        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "BannerSavedsuccesfully"), "", SageMessageType.Success);

    }

    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        divbannerImageContainer.Attributes.Add("style", "display:block");
        divEditBannerImage.Attributes.Add("style", "display:none");
    }


    #region CropBanner

    protected void _cropCommand_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            var x = int.Parse(_xField.Value);

            var y = int.Parse(_yField.Value);

            var width = int.Parse(_widthField.Value);

            var height = int.Parse(_heightField.Value);
            string imageName = Convert.ToString(ViewState["ImageToBeEdit"]);

            using (var photo =
                  System.Drawing.Image.FromFile(Server.MapPath("~/Modules/Sage_Banner/images/OriginalImage/" + imageName)))

            using (var result =
                  new Bitmap(width, height, photo.PixelFormat))
            {

                result.SetResolution(
                        photo.HorizontalResolution,
                        photo.VerticalResolution);



                using (var g = Graphics.FromImage(result))
                {

                    g.InterpolationMode =
                         InterpolationMode.HighQualityBicubic;

                    g.DrawImage(photo,

                         new Rectangle(0, 0, width, height),

                         new Rectangle(x, y, width, height),

                         GraphicsUnit.Pixel);

                    photo.Dispose();

                    result.Save(Server.MapPath("~/Modules/Sage_Banner/images/CroppedImages/" + imageName));


                }

            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
        //LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
        divImageEditor.Attributes.Add("style", "display:none");
        pnlBannercontainer.Attributes.Add("style", "display:block");
        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "ImageEditedSuccesfully"), "", SageMessageType.Success);
        // pnlBannercontainer.Visible = true;
    }


    #endregion


    #region For Image Information
    private void SaveBannerContent(int BannerId, int ImageId)
    {
        try
        {
            SageBannerInfo obj = new SageBannerInfo();

            if (Session["EditImageID"] != null && Session["EditImageID"].ToString() != string.Empty)
            {
                obj.ImageID = Int32.Parse(Session["EditImageID"].ToString());
                if (fuFileUpload.HasFile)
                {
                    obj.ImagePath = fuFileUpload.FileName;
                    obj.NavigationImage = fuFileUpload.FileName;

                }
                else
                {
                    obj.ImagePath = Convert.ToString(Session["ImageName"]);
                    obj.NavigationImage = Convert.ToString(Session["ImageName"]);
                }

            }
            else
            {
                obj.ImageID = 0;
                obj.ImagePath = fuFileUpload.FileName;
                obj.NavigationImage = fuFileUpload.FileName;
            }

            obj.Caption = "";

            if (rdbReadMorePageType.SelectedItem.Text == "Page")
            {

                obj.ReadMorePage = ddlPagesLoad.SelectedValue.ToString();
                obj.LinkToImage = string.Empty;

            }
            if (rdbReadMorePageType.SelectedItem.Text == "WebUrl")
            {
               
                obj.LinkToImage = txtWebUrl.Text;
                obj.ReadMorePage = string.Empty;
            }
            obj.UserModuleID = Int32.Parse(SageUserModuleID);
            obj.BannerID = BannerId;
            obj.ImageID = ImageId;
            obj.ReadButtonText = txtReadButtonText.Text;
            obj.Description = txtBannerDescriptionToBeShown.Text.Trim();
            obj.PortalID = GetPortalID;


            string swfExt = System.IO.Path.GetExtension(fuFileUpload.PostedFile.FileName);
            if (swfExt == ".swf")
            {
                if (fuFileUpload.FileContent.Length > 0)
                {
                    string Path = GetUplaodImagePhysicalPath();
                    DirectoryInfo dirUploadImage = new DirectoryInfo(Path);
                    if (dirUploadImage.Exists == false)
                    {
                        dirUploadImage.Create();
                    }
                    string fileUrl = Path + fuFileUpload.PostedFile.FileName;
                    fuFileUpload.PostedFile.SaveAs(fileUrl);
                    swfFileName = "Modules/Sage_Banner/images/" + fuFileUpload.PostedFile.FileName;
                }

            }
            else
            {
                string target = Server.MapPath("~/Modules/Sage_Banner/images/OriginalImage");
                string CropImageTarget = Server.MapPath("~/Modules/Sage_banner/images/CroppedImages");
                string thumbTarget = Server.MapPath("~/Modules/Sage_Banner/images/ThumbNail");
                System.Drawing.Image.GetThumbnailImageAbort thumbnailImageAbortDelegate = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                if (fuFileUpload.HasFile)
                {
                    fuFileUpload.SaveAs(System.IO.Path.Combine(target, fuFileUpload.FileName));
                    fuFileUpload.SaveAs(System.IO.Path.Combine(CropImageTarget, fuFileUpload.FileName));
                    using (System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(fuFileUpload.PostedFile.InputStream))
                    {
                        using (System.Drawing.Image thumbnail = originalImage.GetThumbnailImage(80, 80, thumbnailImageAbortDelegate, IntPtr.Zero))
                        {
                            thumbnail.Save(System.IO.Path.Combine(thumbTarget, fuFileUpload.FileName));
                        }
                    }
                }




            }
            SageBannerController objcont = new SageBannerController();
            objcont.SaveBannerContent(obj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "BannerSavedsuccesfully"), "", SageMessageType.Success);
        Session["ImageName"] = null;
        Session["EditImageID"] = null;
    }


    string GetUplaodImagePhysicalPath()
    {
        return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "Modules\\Sage_Banner\\images\\";
    }


    # endregion

    #region For clear all form
    private void ClearImageForm()
    {
        txtCaption.Text = string.Empty;
        imgEditBannerImageImage.Visible = false;
        txtWebUrl.Text = string.Empty;
        txtReadButtonText.Text = string.Empty;
        txtBannerDescriptionToBeShown.Text = "";
        txtBody.Text = string.Empty;
    }
    #endregion


    #region For banner information


    protected void imbSaveBanner_Click(object sender, ImageClickEventArgs e)
    {
        SaveBannerInformation();

    }


    private void SaveBannerInformation()
    {
        try
        {
            SageBannerInfo obj = new SageBannerInfo();

            obj.BannerName = txtBannerName.Text;
            obj.BannerDescription = txtBannerDescription.Text;
            obj.UserModuleID = Int32.Parse(SageUserModuleID);
            obj.PortalID = GetPortalID;
            SageBannerController objBcon = new SageBannerController();
            objBcon.SaveBannerInformation(obj);
            LoadBannerListOnGrid(GetPortalID, Int32.Parse(SageUserModuleID));
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

    }


    #endregion



    #region Editor Html Content


    protected void imbSaveEditorContent_Click(object sender, ImageClickEventArgs e)
    {
        string target = Server.MapPath("~/Modules/Sage_Banner/images");
        string thumbTarget = Server.MapPath("~/Modules/Sage_Banner/images/ThumbNail");
        System.Drawing.Image.GetThumbnailImageAbort thumbnailImageAbortDelegate = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
        if (fluBannerNavigationImage.HasFile)
        {
            fluBannerNavigationImage.SaveAs(System.IO.Path.Combine(target, fluBannerNavigationImage.FileName));
            using (System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(fluBannerNavigationImage.PostedFile.InputStream))
            {
                using (System.Drawing.Image thumbnail = originalImage.GetThumbnailImage(80, 80, thumbnailImageAbortDelegate, IntPtr.Zero))
                {
                    thumbnail.Save(System.IO.Path.Combine(thumbTarget, fluBannerNavigationImage.FileName));
                }
            }
        }
        int ImageID;
        int Bannerid = Convert.ToInt32(ViewState["EditBannerID"]);
        string NavImagepath = "";
        if (Session["EditHTMLContentID"] != null && Session["EditHTMLContentID"].ToString() != string.Empty)
        {
            ImageID = Int32.Parse(Session["EditHTMLContentID"].ToString());
            NavImagepath = Convert.ToString(Session["NavigationImage"]);
        }
        else
        {
            ImageID = 0;
            NavImagepath = Convert.ToString(fluBannerNavigationImage.FileName);
        }
        try
        {

            ArrayList arrColl = null;
            arrColl = IsContentValid(txtBody.Text.ToString());
            if (arrColl.Count > 0 && arrColl[0].ToString().ToLower().Trim() == "true")
            {
                SQLHandler sq = new SQLHandler();
                string HTMLBodyText = arrColl[1].ToString().Trim();
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@NavigationImage", NavImagepath));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", HTMLBodyText));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Bannerid", Bannerid));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleId", UserModuleId));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageID", ImageID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                sq.ExecuteNonQuery("[usp_SageBannerAddHtmlContentToBanner]", ParaMeterCollection);

            }


        }

        catch (Exception ex)
        {
            ProcessException(ex);
        }
        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "BannerHTMLContentSavedSuccessfully"), "", SageMessageType.Success);

        txtBody.Text = string.Empty;
        Session["EditHTMLContentID"] = null;
        Session["NavigationImage"] = null;
       
        //Session.Clear();
        LoadHTMLContentOnGrid(Bannerid);

    }


    private ArrayList IsContentValid(string str)
    {
        bool isValid = true;
        str = RemoveUnwantedHTMLTAG(str);
        if (str == string.Empty)
            isValid = false;
        ArrayList arrColl = new ArrayList();
        arrColl.Add(isValid);
        arrColl.Add(str);
        return arrColl;
    }


    public string RemoveUnwantedHTMLTAG(string str)
    {
        str = System.Text.RegularExpressions.Regex.Replace(str, "<br/>$", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, "<br />$", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, "^&nbsp;", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, "<form[^>]*>", "");
        str = System.Text.RegularExpressions.Regex.Replace(str, "</form>", "");
        return str;
    }



    #endregion


    #region Gridview


    public void LoadBannerImagesOnGrid(int BannerID, int UserModuleID, int PortalID)
    {

        gdvBannerImages.DataSource = SageBannerController.LoadBannerImagesOnGrid(BannerID, UserModuleID, PortalID);
        gdvBannerImages.DataBind();
        if (gdvBannerImages.Rows.Count > 0)
        {

            if (gdvBannerImages.PageIndex == 0)
            {
                gdvBannerImages.Rows[0].FindControl("imgListUp").Visible = false;

            }
            if (gdvBannerImages.PageIndex == (gdvBannerImages.PageCount - 1))
            {
                gdvBannerImages.Rows[gdvBannerImages.Rows.Count - 1].FindControl("imgListDown").Visible = false;
            }

        }

    }


    protected void gdvBannerImages_PageIndexChanged(object sender, EventArgs e)
    {

    }


    protected void gdvBannerImages_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            int ImageId = Int32.Parse(e.CommandArgument.ToString());
            BannerId = int.Parse(ViewState["EditBannerID"].ToString());
            switch (e.CommandName.ToString())
            {
                case "Edit":
                    BannerEditByImageID(ImageId);
                    break;
                case "Delete":
                    DeleteBannerContentByID(ImageId);
                    break;
                case "Editimage":
                    divImageEditor.Attributes.Add("style", "display:block");
                    pnlBannercontainer.Attributes.Add("style", "display:none");
                   // pnlBannercontainer.Attributes.Add("style", "display:none");
                   //// pnlBannercontainer.Visible = false;
                    EditImageByImageID(ImageId);
                    break;
                case "SortUp":
                    SageBannerController obj = new SageBannerController();
                    obj.SortImageList(ImageId, true);
                    LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("SageBanner", "TheBannerContentIsShiftedUpSuccessfully"), "", SageMessageType.Success);
                    break;
                case "SortDown":
                    SageBannerController objc = new SageBannerController();
                    objc.SortImageList(ImageId, false);
                    LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("SageBanner", "TheBannerContentIsShiftedDownSuccessfully"), "", SageMessageType.Success);
                    break;


            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }


    protected void gdvBannerImages_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    private void EditImageByImageID(int ImageId)
    {
        SageBannerInfo obj = new SageBannerInfo();
        SageBannerController objcnt = new SageBannerController();
        obj = objcnt.GetImageInformationByID(ImageId);
        _imageEditor.ImageUrl = modulePath + "images/OriginalImage/" + obj.ImagePath;
        divImageEditor.Attributes.Add("style","display:block");
        ViewState["ImageToBeEdit"] = obj.ImagePath;

    }


    private void BannerEditByImageID(int ImageId)
    {
        int BannerId = Convert.ToInt32(ViewState["EditBannerID"]);
        SageBannerInfo objEd = new SageBannerInfo();
        SageBannerController objEc = new SageBannerController();
        objEd = objEc.GetImageInformationByID(ImageId);
        txtCaption.Text = objEd.Caption;
        if (objEd.ReadMorePage != null)
        {
            rdbReadMorePageType.SelectedValue = "0";
            ddlPagesLoad.SelectedItem.Value = objEd.ReadMorePage;
        }
        else if (objEd.LinkToImage != null)
        {
            rdbReadMorePageType.SelectedValue = "1";
            txtWebUrl.Text = objEd.LinkToImage;
        }

        txtReadButtonText.Text = objEd.ReadButtonText;
        Session["ImageName"] = objEd.ImagePath;
        imgEditBannerImageImage.ImageUrl = modulePath + "images/CroppedImages/" + objEd.ImagePath;
        txtBannerDescriptionToBeShown.Text = objEd.Description;
        imgEditBannerImageImage.Visible = true;
        divbannerImageContainer.Attributes.Add("style", "display:none");
        divEditBannerImage.Attributes.Add("style", "display:block");
        LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
        Session["EditImageID"] = ImageId;

    }


    private void DeleteBannerContentByID(int ImageId)
    {
        string ImageName = GetFileName(ImageId);
        if (ImageName != string.Empty)
        {
            DeleteImageFromFolder(ImageName);
        }
        SageBannerController obDel = new SageBannerController();

        obDel.DeleteBannerContentByID(ImageId);
        int BannerId = Convert.ToInt32(ViewState["EditBannerID"]);
        LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
        ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "BannerImageDeletedsuccesfully"), "", SageMessageType.Success);


    }


    private string GetFileName(int ImageID)
    {
        SageBannerController OBJC = new SageBannerController();
        return OBJC.GetFileName(ImageID);
    }


    private void DeleteImageFromFolder(string FileName)
    {
        try
        {

            string BannerImagePath = Server.MapPath(modulePath + "images/OriginalImage/") + FileName;
            string ThumbnailBannerImagePath = Server.MapPath(modulePath + "images/ThumbNail/") + FileName;
            string CroppedImages = Server.MapPath(modulePath + "images/CroppedImages/") + FileName;
            if (File.Exists(BannerImagePath))
            {
                File.Delete(BannerImagePath);
            }
            if (File.Exists(ThumbnailBannerImagePath))
            {
                File.Delete(ThumbnailBannerImagePath);
            }
            if (File.Exists(CroppedImages))
            {
                File.Delete(CroppedImages);
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }


    public void LoadHTMLContentOnGrid(int BannerID)
    {

        gdvHTMLContent.DataSource = SageBannerController.LoadHTMLContentOnGrid(BannerID, Int32.Parse(SageUserModuleID), GetPortalID);
        gdvHTMLContent.DataBind();

    }


    #endregion


    #region BannerList Gridview


    public void LoadBannerListOnGrid(int PortalID, int UserModuleID)
    {

        gdvBannerList.DataSource = SageBannerController.LoadBannerListOnGrid(PortalID, UserModuleID);
        gdvBannerList.DataBind();
    }


    #endregion


    protected void gdvBannerImages_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }


    public bool ThumbnailCallback()
    {
        return false;
    }


    protected void gdvBannerImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    #region gdvBannerList


    protected void gdvBannerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        HttpContext.Current.Session["ActiveTabIndex"] = SageBannerTabcontainer.ActiveTabIndex;
        string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
        Int32 BannerID = Int32.Parse(commandArgsAccept[0].ToString());
        if (e.CommandName == "BannerEdit")
        {
            pnlBannerList.Attributes.Add("style", "display:none");
            LoadBannerImagesOnGrid(BannerID, Int32.Parse(SageUserModuleID), GetPortalID);
            LoadHTMLContentOnGrid(BannerID);
            pnlBannercontainer.Attributes.Add("style", "display:block");
            divEditWrapper.Attributes.Add("style", "display:none");
            divEditBannerImage.Attributes.Add("style", "display:none");
            divHtmlBannerContainer.Attributes.Add("style", "display:block");
            ViewState["EditBannerID"] = BannerID;
        }
        if (e.CommandName == "BannerDelete")
        {
            DeleteBannerAndItsContentByBannerID(BannerID);
            LoadBannerListOnGrid(GetPortalID, Int32.Parse(SageUserModuleID));
            ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "DeletedSucessfully"), "", SageMessageType.Success);

        }
    }


    public void DeleteBannerAndItsContentByBannerID(int BannerID)
    {
        SageBannerController objDelBanner = new SageBannerController();
        objDelBanner.DeleteBannerAndItsContentByBannerID(BannerID);
    }


    #endregion


    protected void gdvHTMLContent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ImageId = Int32.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "DeleteHTML")
        {
            DeleteHTMLContentByID(ImageId);
            ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/Sage_Banner/ModuleLocalText", "DeletedSucessfully"), "", SageMessageType.Success);
        }
        if (e.CommandName == "EditHTML")
        {
            EditHTMLContentByID(ImageId);

        }
        Session["EditHTMLContentID"] = ImageId;
    }


    public void DeleteHTMLContentByID(int ImageId)
    {
        SageBannerController objDel = new SageBannerController();
        objDel.DeleteHTMLContentByID(ImageId);
        LoadHTMLContentOnGrid(Convert.ToInt32(ViewState["EditBannerID"]));

    }


    private void EditHTMLContentByID(int ImageId)
    {
        try
        {
            imgEditNavImage.Visible = true;
            SageBannerInfo objEHtmlContent = new SageBannerInfo();
            SageBannerController objHTMl = new SageBannerController();
            objEHtmlContent = objHTMl.GetHTMLContentForEditByID(ImageId);
            txtBody.Text = objEHtmlContent.HTMLBodyText;
            imgEditNavImage.ImageUrl = modulePath + "images/ThumbNail/" + objEHtmlContent.NavigationImage;
            Session["NavigationImage"] = objEHtmlContent.NavigationImage;
            divHtmlBannerContainer.Attributes.Add("style", "display:none");
            divEditWrapper.Attributes.Add("style", "display:block");
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "rcmd", "showEditorInpopup(this);", true);
            int BannerId = Convert.ToInt32(ViewState["EditBannerID"]);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }


    protected void gdvBannerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBannerList.PageIndex = e.NewPageIndex;
        LoadBannerListOnGrid(GetPortalID, Int32.Parse(SageUserModuleID));
    }


    protected void gdvBannerImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gdvBannerImages.PageIndex = e.NewPageIndex;
        LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);

    }


    protected void gdvHTMLContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvHTMLContent.PageIndex = e.NewPageIndex;
        LoadHTMLContentOnGrid(BannerId);

    }


    protected void imbCancelImageEdit_Click(object sender, ImageClickEventArgs e)
    {
        // divImageEditor.Visible = false;
        //pnlBannercontainer.Visible = true;
        //LoadBannerImagesOnGrid(BannerId, Int32.Parse(SageUserModuleID), GetPortalID);
        divImageEditor.Attributes.Add("style", "display:none");
        pnlBannercontainer.Attributes.Add("style", "display:block");
    }

    protected void imgCancelHtmlContent_Click(object sender, ImageClickEventArgs e)
    {
        divHtmlBannerContainer.Attributes.Add("style", "display:block");
        divEditWrapper.Attributes.Add("style", "display:none");
    }

}
