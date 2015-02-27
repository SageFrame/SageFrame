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
using System.Web.Hosting;
using SageFrame.UserProfile;
using System.IO;

public partial class Modules_UserProfile : BaseAdministrationUserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeJs("UserManagementValidation", "/js/jquery.validate.js");
        tblEditProfile.Visible = false;
        tblViewProfile.Visible = true;
        divSaveProfile.Visible = false;
        sfUserProfile.Visible = false;
        divUserInfo.Visible = true;
        LoadUserDetails();
        if (!IsPostBack)
        {
            btnDeleteProfilePic.ImageUrl = GetAdminImageUrl("imgdelete.png", true);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            UserProfileInfo objinfo = new UserProfileInfo();
            string filename = "";          
            string thumbTarget = Server.MapPath("~/Modules/Admin/UserManagement/UserPic");           
            if (!Directory.Exists(thumbTarget))
            {
                Directory.CreateDirectory(thumbTarget);
            }  
            System.Drawing.Image.GetThumbnailImageAbort thumbnailImageAbortDelegate = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            if (fuImage.HasFile)
            {
                double fs = fuImage.PostedFile.ContentLength / (1024 * 1024);
                if (fs > 3)
                {
                    ShowHideProfile();
                    ShowMessage("", GetSageMessage("UserManagement", "ImageTooLarge"), "", SageMessageType.Alert);
                    return;
                }
                else
                {
                    filename = fuImage.PostedFile.FileName.Substring(fuImage.PostedFile.FileName.LastIndexOf("\\") + 1);
                    imgUser.ImageUrl = "~/Modules/Admin/UserManagement/UserPic/" + filename;                   
                    using (System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(fuImage.PostedFile.InputStream))
                    {
                        using (System.Drawing.Image thumbnail = originalImage.GetThumbnailImage(200, 150, thumbnailImageAbortDelegate, IntPtr.Zero))
                        {
                            thumbnail.Save(System.IO.Path.Combine(thumbTarget, fuImage.FileName));
                        }
                    }
                }
            }

            if (filename == "")
            {
                if (Session["Image"] != null)
                {
                    filename = Session["Image"].ToString();
                }
                btnDeleteProfilePic.Visible = false;
            }
            else
            {
                btnDeleteProfilePic.Visible = true;
            }
            objinfo.Image = filename;
            objinfo.UserName = GetUsername;
            objinfo.FirstName = txtFName.Text;
            objinfo.LastName = txtLName.Text;
            objinfo.FullName = txtFullName.Text;
            objinfo.Location = txtLocation.Text;
            objinfo.AboutYou = txtAboutYou.Text;
            objinfo.Email = txtEmail1.Text + ',' + txtEmail2.Text + ',' + txtEmail3.Text;
            objinfo.ResPhone = txtResPhone.Text;
            objinfo.MobilePhone = txtMobile.Text;
            objinfo.Others = txtOthers.Text;
            objinfo.AddedOn = DateTime.Now;
            objinfo.AddedBy = GetUsername;
            objinfo.UpdatedOn = DateTime.Now;
            objinfo.PortalID = GetPortalID;
            objinfo.UpdatedBy = GetUsername;
            UserProfileController.AddUpdateProfile(objinfo);
            LoadUserDetails();
            //ShowHideProfile();
            divUserInfo.Visible = true;
            tblEditProfile.Visible = false;
            //LoadUserDetails();
            tblViewProfile.Visible = true;
            imgProfileEdit.Visible = false;
            imgProfileView.Visible = true;
            btnDeleteProfilePic.Visible = false;
            divEditprofile.Visible = true;
            sfUserProfile.Visible = false;
            Session["Image"] = null;  
            ShowMessage("", GetSageMessage("UserManagement", "UserProfileSavedSuccessfully"), "", SageMessageType.Success);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public bool ThumbnailCallback()
    {
        return false;
    }



    public void GetUserDetails()
    {
        try
        {
            UserProfileInfo objinfo = new UserProfileInfo();
            objinfo = UserProfileController.GetProfile(GetUsername, GetPortalID);
            string UserImage = Server.MapPath("~/Modules/Admin/UserManagement/UserPic/");           
            if (!Directory.Exists(UserImage))
            {
                Directory.CreateDirectory(UserImage);
            }
            if (objinfo != null)
            {
                string[] Emails = objinfo.Email.Split(',');
                if (objinfo.Image != "")
                {
                    imgUser.ImageUrl = "~/Modules/Admin/UserManagement/UserPic/" + objinfo.Image;
                    imgUser.Visible = true;
                    imgProfileEdit.Visible = true;
                    btnDeleteProfilePic.Visible = true;
                    Session["Image"] = objinfo.Image;
                }
                else
                {
                    imgUser.Visible = false;
                    imgProfileEdit.Visible = false;
                }
                lblDisplayUserName.Text = objinfo.UserName;
                txtFName.Text = objinfo.FirstName;
                txtLName.Text = objinfo.LastName;
                txtFullName.Text = objinfo.FullName;
                txtLocation.Text = objinfo.Location;
                txtAboutYou.Text = objinfo.AboutYou;
                txtEmail1.Text = Emails[0];
                if (Emails.Length == 2)
                {
                    txtEmail2.Text = Emails[1];
                }
                if (Emails.Length == 3)
                {
                    txtEmail2.Text = Emails[1];
                    txtEmail3.Text = Emails[2];
                }
                txtResPhone.Text = objinfo.ResPhone;
                txtMobile.Text = objinfo.Mobile;
                txtOthers.Text = objinfo.Others;
            }
        }

        catch (Exception)
        {

            throw;
        }
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
           
            ShowHideProfile();

        }
        catch (Exception)
        {

            throw;
        }
    }
    public void LoadUserDetails()
    {
        try
        {
            UserProfileInfo objinfo = new UserProfileInfo();
            objinfo = UserProfileController.GetProfile(GetUsername, GetPortalID);
            if (objinfo != null)
            {
                string[] Emails = objinfo.Email.Split(',');
                if (objinfo.Image != "")
                {
                    imgViewImage.ImageUrl = "~/Modules/Admin/UserManagement/UserPic/" + objinfo.Image;
                    imgViewImage.Visible = true;
                    imgProfileEdit.Visible = true;
                }
                else
                {
                    imgProfileEdit.Visible = false;
                    imgViewImage.Visible = false;
                }
                lblViewUserName.Text = objinfo.UserName;
                lblViewFirstName.Text = objinfo.FirstName;
                lblViewLastName.Text = objinfo.LastName;
                if (objinfo.FullName != "")
                {
                    lblviewFullName.Text = objinfo.FullName;
                    trviewFullName.Visible = true;
                }
                else { trviewFullName.Visible = false; }
                if (objinfo.Location != "")
                {
                    lblViewLocation.Text = objinfo.Location;
                    trViewLocation.Visible = true;
                }
                else { trViewLocation.Visible = false; }
                string AboutYou = objinfo.AboutYou.Replace("\r\n", "<br>");
                if (AboutYou != "")
                {
                    lblViewAboutYou.Text = AboutYou;
                    trViewAboutYou.Visible = true;
                }
                else { trViewAboutYou.Visible = false; }
                if (Emails.Length != 0)
                {
                    lblViewEmail1.Text = Emails[0];
                    lblViewEmail2.Text = Emails.Length == 3 ? Emails[1] : "";
                    lblViewEmail3.Text = Emails.Length == 3 ? Emails[2] : "";
                    trViewEmail.Visible = true;
                }
                else { trViewEmail.Visible = false; }
                if (objinfo.ResPhone != "")
                {
                    lblViewResPhone.Text = objinfo.ResPhone;
                    trViewResPhone.Visible = true;
                }
                else { trViewResPhone.Visible = false; }
                if (objinfo.Mobile != "")
                {
                    lblViewMobile.Text = objinfo.Mobile;
                    trViewMobile.Visible = true;
                }
                else { trViewMobile.Visible = false; }
                if (objinfo.Others != "")
                {
                    lblViewOthers.Text = objinfo.Others;
                    trViewOthers.Visible = true;
                }
                else { trViewOthers.Visible = false; }
            }

        }

        catch (Exception)
        {

            throw;
        }
    }
    public void ShowHideProfile()
    {
        try
        {           
            sfUserProfile.Visible = true;
            tblEditProfile.Visible = true;
            //imgProfileEdit.Visible = true;
            tblViewProfile.Visible = false;
            imgProfileView.Visible = false;
            imgViewImage.Visible = false;
            divSaveProfile.Visible = true;
            divEditprofile.Visible = false;
            divUserInfo.Visible = false;
            GetUserDetails();
            
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnCancelProfile_Click(object sender, EventArgs e)
    {
        divUserInfo.Visible = true;
        tblEditProfile.Visible = false;
        LoadUserDetails();
        tblViewProfile.Visible = true;
        imgProfileEdit.Visible = false;
        imgProfileView.Visible = true;
        btnDeleteProfilePic.Visible = false;
        divEditprofile.Visible = true;
        sfUserProfile.Visible = false;
        
    }
    protected void txtOthers_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnDeleteProfilePic_Click(object sender, EventArgs e)
    {
        try
        {
            UserProfileInfo objinfo = new UserProfileInfo();
            objinfo = UserProfileController.GetProfile(GetUsername, GetPortalID);
            if (objinfo.Image != "")
            {
                string imagePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory) + "UserPic/" + objinfo.Image;
                string path = Server.MapPath(imagePath);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            UserProfileController.DeleteProfilePic(GetUsername, GetPortalID);
            ShowHideProfile();
            GetUserDetails();
            LoadUserDetails();
            Session["Image"] = null;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
