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
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using SageFrame.Web;
using SageFrame.RolesManagement;
using SageFrame.UserManagement;
using SageFrame.Security.Entities;
using SageFrame.Security.Crypto;
using SageFrame.Security.Helpers;
using SageFrame.Security.Providers;
using SageFrame.Security;
using System.Text.RegularExpressions;
using SageFrame.Security.Enums;
using SageFrame.UserProfile;
using System.IO;

namespace SageFrame.Modules.Admin.UserManagement
{


    public partial class ctl_ManageUser : BaseAdministrationUserControl
    {

        MembershipController m = new MembershipController();
        RoleController role = new RoleController();
        public int Flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IncludeJs("UserManagement",false, "/js/jquery.pstrength-min.1.2.js");
            IncludeJs("UserManagementValidation", "/js/jquery.validate.js");
            imgProfileEdit.Visible = false;
            try
            {
                if (!IsPostBack)
                {
                    aceSearchText.CompletionSetCount = GetPortalID;
                    BindRolesInListBox(lstAvailableRoles);
                    BindUsers(string.Empty);
                    PanelVisibility(false, true, false);
                    pnlSettings.Visible = false;
                    BindRolesInDropDown(ddlSearchRole);
                    AddImageUrls();


                }
                

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void AddImageUrls()
        {
            imgBack.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imgUserInfoSave.ImageUrl = GetTemplateImageUrl("imgupdate.png", true);
            imgManageRoleSave.ImageUrl = GetTemplateImageUrl("imgupdate.png", true);
            imgSearch.ImageUrl = GetTemplateImageUrl("imgpreview.png", true);
            imgAddUser.ImageUrl = GetTemplateImageUrl("imgadduser.png", true);
            imbBackinfo.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imgBtnDeleteSelected.ImageUrl = GetTemplateImageUrl("imgdelete.png", true);
            imgBtnSaveChanges.ImageUrl = GetTemplateImageUrl("imgupdate.png", true);
            imbCreateUser.ImageUrl = GetTemplateImageUrl("btnadduser1.png", true);
            imgBtnSettings.ImageUrl = GetTemplateImageUrl("settings.png", true);
            btnSaveSetting.ImageUrl = GetAdminImageUrl("btnsave.png", true);
            btnCancel.ImageUrl = GetAdminImageUrl("imgcancel.png", true);
            btnDeleteProfilePic.ImageUrl = GetAdminImageUrl("imgdelete.png", true);


        }

        private void PanelVisibility(bool VisibleUserPanel, bool VisibleUserListPanel, bool VisibleManageUserPanel)
        {
            pnlUser.Visible = VisibleUserPanel;
            pnlUserList.Visible = VisibleUserListPanel;
            pnlManageUser.Visible = VisibleManageUserPanel;
        }

        private DataTable GetAllRoles()
        {
            DataTable dtRole = new DataTable();
            dtRole.Columns.Add("RoleID");
            dtRole.Columns.Add("RoleName");
            dtRole.AcceptChanges();
            List<RolesManagementInfo> objRoles = RolesManagementController.PortalRoleList(GetPortalID, false, GetUsername);
            foreach (RolesManagementInfo role in objRoles)
            {
                string roleName = role.RoleName;
                if (SystemSetting.SYSTEM_ROLES.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                {
                    DataRow dr = dtRole.NewRow();
                    dr["RoleID"] = role.RoleId;
                    dr["RoleName"] = roleName;
                    dtRole.Rows.Add(dr);
                }
                else
                {
                    string rolePrefix = GetPortalSEOName + "_";
                    roleName = roleName.Replace(rolePrefix, "");
                    DataRow dr = dtRole.NewRow();
                    dr["RoleID"] = role.RoleId;
                    dr["RoleName"] = roleName;
                    dtRole.Rows.Add(dr);
                }
            }
            return dtRole;
        }

        private void BindRolesInListBox(ListBox lst)
        {
            DataTable dtRoles = GetAllRoles();
            lst.DataSource = dtRoles;
            lst.DataTextField = "RoleName";
            lst.DataValueField = "RoleName";
            lst.DataBind();
            lst.Items.RemoveAt(0);
        }

        private void BindRolesInDropDown(DropDownList ddl)
        {
            DataTable dtRoles = GetAllRoles();
            ddl.DataSource = dtRoles;
            ddl.DataTextField = "RoleName";
            ddl.DataValueField = "RoleID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("<Not Specified >", ""));
        }
        private void BindUsers(string searchText)
        {
            ViewState.Clear();
            string RoleID = ddlSearchRole.SelectedValue.ToString();
            if (Flag == 0)
            {
                MembershipController m = new MembershipController();
                List<UserInfo> lstUsers = m.SearchUsers(RoleID, searchText.Trim(), GetPortalID, GetUsername).UserList;
                gdvUser.DataSource = (lstUsers);
                gdvUser.DataBind();
                ViewState["UserList"] = lstUsers;
            }
            if (Flag == 1)
            {

                List<UserInfo> lstUsers = m.SearchUsers(RoleID, searchText.Trim(), GetPortalID, GetUsername).UserList;
                if (txtTo.Text != "" && txtFrom.Text == "")
                {
                    List<UserInfo> filteredUsers = lstUsers.FindAll(delegate(UserInfo objUserInfo)
                    {
                        return objUserInfo.AddedOn <= DateTime.Parse(txtTo.Text);
                    });
                    gdvUser.DataSource = (filteredUsers);
                    gdvUser.DataBind();
                    ViewState["UserList"] = filteredUsers;
                }
                if (txtFrom.Text != "" && txtTo.Text == "")
                {

                    List<UserInfo> filteredUsers = lstUsers.FindAll(delegate(UserInfo objUserInfo)
                    {
                        return objUserInfo.AddedOn >= DateTime.Parse(txtFrom.Text);
                    });
                    gdvUser.DataSource = (filteredUsers);
                    gdvUser.DataBind();
                    ViewState["UserList"] = filteredUsers;

                }
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    if (DateTime.Parse(txtFrom.Text) < DateTime.Parse(txtTo.Text))
                    {

                        List<UserInfo> filteredUsers = lstUsers.FindAll(delegate(UserInfo objUserInfo)
                        {
                            return objUserInfo.AddedOn >= DateTime.Parse(txtFrom.Text) && objUserInfo.AddedOn <= DateTime.Parse(txtTo.Text);
                        });
                        gdvUser.DataSource = (filteredUsers);
                        gdvUser.DataBind();
                        ViewState["UserList"] = filteredUsers;
                    }
                    else
                    {
                        ShowMessage("", GetSageMessage("UserManagement", "FromIsLowerThanTo"), "", SageMessageType.Error);
                    }
                }

            }
        }

        private List<UserInfo> ReorderUserList(List<UserInfo> lstUsers)
        {
            List<UserInfo> lstNewUsers = new List<UserInfo>();
            foreach (UserInfo user in lstUsers)
            {
                if (Regex.Replace(user.UserName.ToLower(), @"\s", "") == "superuser")
                {
                    lstNewUsers.Insert(0, user);
                }
                else
                {

                    lstNewUsers.Add(user);
                }
            }
            return lstNewUsers;
        }

        private void CheckForSuperuser(ref List<UserInfo> lstUsers)
        {
            foreach (UserInfo obj in lstUsers)
            {
                if (obj.UserName.ToLower().Equals("superuser"))
                {
                    lstUsers.Remove(obj);
                }
            }
        }

        protected void imgAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                PanelVisibility(true, false, false);
                ClearForm();
                lstAvailableRoles.SelectedIndex = lstAvailableRoles.Items.IndexOf(lstAvailableRoles.Items.FindByValue("Registered User"));


            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }



        private string GetListBoxText(ListBox lstBox)
        {
            string selectedRoles = string.Empty;
            foreach (ListItem li in lstBox.Items)
            {
                string roleName = li.Text;
                if (SystemSetting.SYSTEM_ROLES.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                {
                    selectedRoles += roleName + ",";
                }
                else
                {

                    selectedRoles += roleName + ",";
                }
            }
            if (selectedRoles.Length > 0)
            {
                selectedRoles = selectedRoles.Substring(0, selectedRoles.Length - 1);
            }
            return selectedRoles;
        }

        private string SelectedRoles()
        {
            string selectedRoles = string.Empty;
            foreach (ListItem li in lstAvailableRoles.Items)
            {
                if (li.Selected == true)
                {
                    string roleName = li.Text;
                    if (SystemSetting.SYSTEM_ROLES.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                    {
                        selectedRoles += roleName + ",";
                    }
                    else
                    {
                        string rolePrefix = GetPortalSEOName + "_";
                        selectedRoles += rolePrefix + roleName + ",";
                    }
                }
            }
            if (selectedRoles.Length > 0)
            {
                selectedRoles = selectedRoles.Substring(0, selectedRoles.Length - 1);
            }
            return selectedRoles;
        }

        private void ClearForm()
        {
            txtUserName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRetypePassword.Text = "";
            txtSecurityQuestion.Text = "";
            txtSecurityAnswer.Text = "";
        }



        protected void imbFinish_Click(object sender, EventArgs e)
        {
            try
            {
                BindUsers(string.Empty);
                PanelVisibility(false, true, false);

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        public void GetSageUserInfo(string EditUserName)
        {
            try
            {
                UserInfo sageUser = m.GetUserDetails(GetPortalID, EditUserName);
                string[] Emails = sageUser.Email.Split(',');
                txtManageEmail.Text = Emails[0];
                txtManageFirstName.Text = sageUser.FirstName;
                txtManageLastName.Text = sageUser.LastName;
                txtManageUsername.Text = sageUser.UserName;
                chkIsActive.Checked = sageUser.IsApproved == true ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gdvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (!e.CommandName.Equals("Page"))
                {
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    if (gdvUser.PageIndex > 0)
                    {
                        rowIndex = int.Parse(e.CommandArgument.ToString()) - (gdvUser.PageSize * gdvUser.PageIndex);
                    }

                    hdnEditUsername.Value = gdvUser.DataKeys[rowIndex]["Username"].ToString();
                    hdnEditUserID.Value = gdvUser.DataKeys[rowIndex]["UserId"].ToString();
                    if (e.CommandName == "EditUser")
                    {
                        string username = gdvUser.DataKeys[rowIndex]["Username"].ToString();
                        string[] userRoles = Roles.GetRolesForUser(username);

                        UserInfo sageUser = m.GetUserDetails(GetPortalID, hdnEditUsername.Value);
                        hdnCurrentEmail.Value = sageUser.Email;
                        txtManageEmail.Text = sageUser.Email;
                        txtManageFirstName.Text = sageUser.FirstName;
                        txtManageLastName.Text = sageUser.LastName;
                        txtManageUsername.Text = sageUser.UserName;
                        chkIsActive.Checked = sageUser.IsApproved == true ? true : false;

                        if (SystemSetting.SYSTEM_USERS.Contains(hdnEditUsername.Value) || hdnEditUsername.Value == GetUsername)
                        {

                            chkIsActive.Enabled = false;
                            chkIsActive.Attributes.Add("class", "disabledClass");
                            tabUserRoles.Visible = false;
                        }
                        else
                        {
                            tabUserRoles.Visible = true;
                        }
                        txtCreatedDate.Text = sageUser.CreatedDate.ToShortDateString();
                        txtLastActivity.Text = sageUser.LastActivityDate.ToShortDateString();
                        txtLastLoginDate.Text = sageUser.LastLoginDate.ToShortDateString();
                        txtLastPasswordChanged.Text = sageUser.LastPasswordChangeDate.ToShortDateString();

                        if (!sageUser.IsApproved)
                        {
                            txtLastActivity.Text = "N/A";
                            txtLastLoginDate.Text = "N/A";
                            txtLastPasswordChanged.Text = "N/A";
                        }
                        lstSelectedRoles.Items.Clear();
                        lstUnselectedRoles.Items.Clear();



                        List<RolesManagementInfo> objRoles = RolesManagementController.PortalRoleList(GetPortalID, false, GetUsername);
                        foreach (RolesManagementInfo role in objRoles)
                        {
                            string roleName = role.RoleName;
                            if (roleName != "Super User")
                           {
                                if (SystemSetting.SYSTEM_ROLES.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                                {
                                    if (userRoles.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                                    {
                                        lstSelectedRoles.Items.Add(new ListItem(roleName, roleName));
                                    }
                                    else
                                    {
                                        lstUnselectedRoles.Items.Add(new ListItem(roleName, roleName));
                                    }
                                }
                                else
                                {
                                    if (userRoles.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                                    {
                                        string rolePrefix = GetPortalSEOName + "_";
                                        roleName = roleName.Replace(rolePrefix, "");
                                        lstSelectedRoles.Items.Add(new ListItem(roleName, roleName));
                                    }
                                    else
                                    {
                                        string rolePrefix = GetPortalSEOName + "_";
                                        roleName = roleName.Replace(rolePrefix, "");
                                        lstUnselectedRoles.Items.Add(new ListItem(roleName, roleName));
                                    }
                                }
                            }
                        }
                        if (userRoles.Contains("Super User"))
                        {
                            btnAddAllRole.Enabled = false;
                            btnAddRole.Enabled = false;
                            btnRemoveAllRole.Enabled = false;
                            btnRemoveRole.Enabled = false;
                            lstUnselectedRoles.Enabled = false;
                            lstSelectedRoles.Enabled = false;
                        }
                        PanelVisibility(false, false, true);
                        LoadUserProfileData();
                        //userProfile1.EditUserName = hdnEditUsername.Value;



                    }
                    else if (e.CommandName == "DeleteUser")
                    {
                        if (hdnEditUsername.Value != "")
                        {

                            UserInfo user = new UserInfo(hdnEditUsername.Value, GetPortalID, Membership.ApplicationName, GetUsername);
                            m.DeleteUser(user);
                            ShowMessage("", GetSageMessage("UserManagement", "UserDeletedSuccessfully"), "", SageMessageType.Success);
                            BindUsers(string.Empty);
                        }
                        else
                        {
                            ShowMessage("", GetSageMessage("UserManagement", "SelectDeleteButtonOnceAgain"), "", SageMessageType.Alert);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public void LoadUserProfileData()
        {
            tblEditProfile.Visible = false;
            tblViewProfile.Visible = true;
            LoadUserDetails();
        }

        protected void imgUserInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnEditUsername.Value != "")
                {
                    if (txtManageFirstName.Text != "" && txtManageLastName.Text != "" && txtManageEmail.Text != "")
                    {
                        MembershipUser member = Membership.GetUser(hdnEditUsername.Value);
                        member.Email = txtManageEmail.Text;

                        if (!EmailAddressExists(txtManageEmail.Text, m.RequireUniqueEmail))
                        {
                            UserInfo user = new UserInfo(Membership.ApplicationName, hdnEditUsername.Value, new Guid(hdnEditUserID.Value), txtManageFirstName.Text, txtManageLastName.Text, txtManageEmail.Text, GetPortalID, chkIsActive.Checked, GetUsername);

                            UserUpdateStatus status = new UserUpdateStatus();
                            m.UpdateUser(user, out status);
                            if (status == UserUpdateStatus.DUPLICATE_EMAIL_NOT_ALLOWED)
                            {
                                ShowMessage("", GetSageMessage("UserManagement", "EmailAddressAlreadyIsInUse"), "", SageMessageType.Alert);

                            }
                            else if (status == UserUpdateStatus.USER_UPDATE_SUCCESSFUL)
                            {
                                BindUsers(string.Empty);
                                ShowMessage("",
                                            GetSageMessage("UserManagement", "UserInformationSaveSuccessfully"), "",
                                            SageMessageType.Success);
                                LoadUserDetails();


                            }

                        }
                        else
                        {

                            ShowMessage("", GetSageMessage("UserManagement", "EmailAddressAlreadyIsInUse"), "", SageMessageType.Alert);

                        }
                    }
                    else
                    {
                        ShowMessage("", GetSageMessage("UserManagement", "PleaseEnterTheRequiredFields"), "", SageMessageType.Alert);
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected bool EmailAddressExists(string email, bool AllowDuplicateEmail)
        {
            bool status = false;
            Guid UserID = new Guid(hdnEditUserID.Value);
            if (!AllowDuplicateEmail)
            {
                SageFrameUserCollection userColl = m.GetAllUsers();
                status = userColl.UserList.Exists(
                            delegate(UserInfo obj)
                            {
                                return (obj.Email == email && obj.UserID != UserID);
                            }
                        );
            }
            return status;
        }

        protected void imgManageRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                string unselectedRoles = GetListBoxText(lstUnselectedRoles);
                string selectedRoles = GetListBoxText(lstSelectedRoles);
                if (hdnEditUsername.Value != "")
                {
                    string userRoles = role.GetRoleNames(hdnEditUsername.Value, GetPortalID);
                    string[] arrRoles = userRoles.Split(',');
                    UserInfo user = new UserInfo(Membership.ApplicationName, new Guid(hdnEditUserID.Value), userRoles, GetPortalID);
                    if (arrRoles.Length > 0 && selectedRoles.Length > 0)
                    {
                        role.ChangeUserInRoles(Membership.ApplicationName, new Guid(hdnEditUserID.Value), userRoles, selectedRoles, GetPortalID);
                        ShowMessage("", GetSageMessage("UserManagement", "UserRolesUpdatedSuccessfully"), "", SageMessageType.Success);

                    }

                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                ShowMessage("", GetSageMessage("UserManagement", "UnknownErrorOccur"), "", SageMessageType.Error);
            }
        }

        protected void btnManagePasswordSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text != "" && txtRetypeNewPassword.Text != "" && txtNewPassword.Text == txtRetypeNewPassword.Text && hdnEditUsername.Value != "")
                {
                    if (txtNewPassword.Text.Length >= 4)
                    {
                        MembershipUser member = Membership.GetUser(hdnEditUsername.Value);
                        string Password, PasswordSalt;
                        PasswordHelper.EnforcePasswordSecurity(m.PasswordFormat, txtNewPassword.Text, out Password, out PasswordSalt);
                        UserInfo user = new UserInfo(new Guid(hdnEditUserID.Value), Password, PasswordSalt, m.PasswordFormat);
                        m.ChangePassword(user);
                        ShowMessage("", GetSageMessage("UserManagement", "UserPasswordChangedSuccessfully"), "", SageMessageType.Success);
                    }
                    else
                    {
                        ShowMessage("", GetSageMessage("UserManagement", "PasswordLength"), "", SageMessageType.Alert);
                    }
                }
                else
                {
                    ShowMessage("", GetSageMessage("UserManagement", "PleaseEnterTheRequiredField"), "", SageMessageType.Alert);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void btnAddAllRole_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstUnselectedRoles.Items)
            {
                lstSelectedRoles.Items.Add(li);
            }
            lstUnselectedRoles.Items.Clear();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstUnselectedRoles.SelectedIndex != -1)
                {
                    int[] selectedIndexs = lstUnselectedRoles.GetSelectedIndices();
                    for (int i = selectedIndexs.Length - 1; i >= 0; i--)
                    {
                        lstSelectedRoles.Items.Add(lstUnselectedRoles.Items[selectedIndexs[i]]);
                        lstUnselectedRoles.Items.Remove(lstUnselectedRoles.Items[selectedIndexs[i]]);
                    }
                    lstUnselectedRoles.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void btnRemoveRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelectedRoles.SelectedIndex != -1)
                {
                    int[] selectedIndexs = lstSelectedRoles.GetSelectedIndices();
                    for (int i = selectedIndexs.Length - 1; i >= 0; i--)
                    {
                        if (lstSelectedRoles.Items.Count > 1)
                        {

                            lstUnselectedRoles.Items.Add(lstSelectedRoles.Items[selectedIndexs[i]]);
                            lstSelectedRoles.Items.Remove(lstSelectedRoles.Items[selectedIndexs[i]]);

                        }
                    }
                    lstSelectedRoles.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void btnRemoveAllRole_Click(object sender, EventArgs e)
        {
            try
            {
                int Count = lstSelectedRoles.Items.Count;
                List<string> remRoles = new List<string>();
                for (int i = 0; i < Count; i++)
                {
                    if (lstSelectedRoles.Items[i].Text.ToLower() != "super user")
                    {
                        lstUnselectedRoles.Items.Add(lstSelectedRoles.Items[i]);
                        remRoles.Add(lstSelectedRoles.Items[i].Text);

                    }
                }
                foreach (string remRole in remRoles)
                {
                    lstSelectedRoles.Items.Remove(remRole);
                }

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgBack_Click(object sender, EventArgs e)
        {
            try
            {
                PanelVisibility(false, true, false);
                BindUsers(string.Empty);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindUsers(txtSearchText.Text);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFrom.Text != "" || txtTo.Text != "")
                {
                    Flag = 1;
                }
                BindUsers(txtSearchText.Text);
                this.rbFilterMode.SelectedIndex = 0;
                ClearSearch();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        public void ClearSearch()
        {
            txtSearchText.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
        }

        protected void gdvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnIsActive = (HiddenField) e.Row.FindControl("hdnIsActive");
                ImageButton imgDelete = (ImageButton) e.Row.FindControl("imgDelete");
                LinkButton lnkUsername = (LinkButton) e.Row.FindControl("lnkUsername");
                ImageButton imgEdit = (ImageButton) e.Row.FindControl("imgEdit");

                HtmlInputCheckBox chkItem = (HtmlInputCheckBox) e.Row.FindControl("chkBoxItem");
                chkItem.Attributes.Add("onclick",
                                       "javascript:Check(this,'cssCheckBoxHeader','" + gdvUser.ClientID +
                                       "','cssCheckBoxItem');");
                HtmlInputCheckBox chkIsActiveItem = (HtmlInputCheckBox) e.Row.FindControl("chkBoxIsActiveItem");
                chkIsActiveItem.Attributes.Add("onclick",
                                               "javascript:Check(this,'cssCheckBoxIsActiveHeader','" + gdvUser.ClientID +
                                               "','cssCheckBoxIsActiveItem');");
                chkIsActiveItem.Checked = bool.Parse(hdnIsActive.Value);

                if (lnkUsername.Text.ToLower() == GetUsername.ToLower())
                {
                    imgDelete.Visible = false;
                    chkIsActiveItem.Disabled = true;
                    chkItem.Disabled = true;
                    chkItem.Attributes.Add("class", "disabledClass");
                    chkIsActiveItem.Attributes.Add("class", "disabledClass");
                }
                else if (GetUsername.ToLower() == "superuser" && lnkUsername.Text.ToLower() == "superuser")
                {
                    lnkUsername.Enabled = true;
                    imgEdit.Visible = true;
                    imgDelete.Visible = false;
                    chkIsActiveItem.Disabled = true;
                    chkItem.Disabled = true;
                    chkItem.Attributes.Add("class", "disabledClass");
                    chkIsActiveItem.Attributes.Add("class", "disabledClass");
                }
                else
                {
                    string[] userRoles = Roles.GetRolesForUser(lnkUsername.Text);
                    foreach (var userRole in userRoles)
                    {
                        if (userRole.ToLower() == SystemSetting.SUPER_ROLE[0].ToLower())
                        {
                            lnkUsername.Enabled = false;
                            imgEdit.Visible = false;
                            imgDelete.Visible = false;
                            chkIsActiveItem.Disabled = true;
                            chkItem.Disabled = true;
                            chkItem.Attributes.Add("class", "disabledClass");
                            chkIsActiveItem.Attributes.Add("class", "disabledClass");
                        }
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                HtmlInputCheckBox chkHeader = (HtmlInputCheckBox)e.Row.FindControl("chkBoxHeader");
                chkHeader.Attributes.Add("onclick",
                                         "javascript:SelectAllCheckboxesSpecific(this,'" + gdvUser.ClientID +
                                         "','cssCheckBoxItem');");
                HtmlInputCheckBox chkIsActiveHeader = (HtmlInputCheckBox)e.Row.FindControl("chkBoxIsActiveHeader");
                chkIsActiveHeader.Attributes.Add("onclick",
                                                 "javascript:SelectAllCheckboxesSpecific(this,'" + gdvUser.ClientID +
                                                 "','cssCheckBoxIsActiveItem');");
            }
        }

        protected void imgBtnDeleteSelected_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string seletedUsername = string.Empty;
                for (int i = 0; i < gdvUser.Rows.Count; i++)
                {
                    HtmlInputCheckBox chkBoxItem = (HtmlInputCheckBox)gdvUser.Rows[i].FindControl("chkBoxItem");
                    if (chkBoxItem.Checked == true)
                    {
                        LinkButton lnkUsername = (LinkButton)gdvUser.Rows[i].FindControl("lnkUsername");
                        if (!SystemSetting.SYSTEM_USERS.Contains(lnkUsername.Text.Trim()))
                        {
                            seletedUsername = seletedUsername + lnkUsername.Text.Trim() + ",";
                        }

                    }
                }
                if (seletedUsername.Length > 1)
                {
                    seletedUsername = seletedUsername.Substring(0, seletedUsername.Length - 1);
                    UserManagementProvider.DeleteSelectedUser(seletedUsername, GetPortalID, GetUsername);
                    BindUsers(string.Empty);
                    ShowMessage("", GetSageMessage("UserManagement", "SelectedUsersAreDeletedSuccessfully"), "", SageMessageType.Success);
                }

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgBtnSaveChanges_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string seletedUsername = string.Empty;
                string IsActive = string.Empty;
                for (int i = 0; i < gdvUser.Rows.Count; i++)
                {
                    HtmlInputCheckBox chkBoxItem = (HtmlInputCheckBox)gdvUser.Rows[i].FindControl("chkBoxIsActiveItem");
                    LinkButton lnkUsername = (LinkButton)gdvUser.Rows[i].FindControl("lnkUsername");
                    seletedUsername = seletedUsername + lnkUsername.Text.Trim() + ",";
                    IsActive = IsActive + (chkBoxItem.Checked ? "1" : "0") + ",";
                }
                if (seletedUsername.Length > 1 && IsActive.Length > 0)
                {
                    seletedUsername = seletedUsername.Substring(0, seletedUsername.Length - 1);
                    IsActive = IsActive.Substring(0, IsActive.Length - 1);
                    UserManagementProvider.UpdateUsersChanges(seletedUsername, IsActive, GetPortalID, GetUsername);
                    ShowMessage("", GetSageMessage("UserManagement", "SelectedChangesAreSavedSuccessfully"), "", SageMessageType.Success);
                    BindUsers(string.Empty);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void ddlSearchRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindUsers(string.Empty);
                this.rbFilterMode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ProcessCancelRequest(Request.RawUrl);
        }

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvUser.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue.ToString());
            if (ViewState["FilteredUser"] != null)
            {
                gdvUser.DataSource = ViewState["FilteredUser"];
            }
            else
            {
                gdvUser.DataSource = ViewState["UserList"];
            }
            gdvUser.DataBind();
            //BindUsers(txtSearchText.Text);
        }

        protected void gdvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvUser.PageIndex = e.NewPageIndex;
            if (ViewState["FilteredUser"] != null)
            {
                gdvUser.DataSource = ViewState["FilteredUser"];
            }
            else
            {
                gdvUser.DataSource = ViewState["UserList"];
            }
            gdvUser.DataBind();
            //ViewState.Clear();
           // BindUsers(txtSearchText.Text);
        }
        protected void imbCreateUser_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (txtUserName.Text != "" && txtSecurityQuestion.Text != "" && txtSecurityAnswer.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtEmail.Text != "")
                {
                    if (lstAvailableRoles.SelectedIndex > -1)
                    {
                        if (txtPassword.Text.Length >= 4)
                        {
                            UserInfo objUser = new UserInfo();
                            objUser.ApplicationName = Membership.ApplicationName;
                            objUser.FirstName = txtFirstName.Text;
                            objUser.UserName = txtUserName.Text;
                            objUser.LastName = txtLastName.Text;
                            string Password, PasswordSalt;
                            PasswordHelper.EnforcePasswordSecurity(m.PasswordFormat, txtPassword.Text, out Password, out PasswordSalt);
                            objUser.Password = Password;
                            objUser.PasswordSalt = PasswordSalt;
                            objUser.Email = txtEmail.Text;
                            objUser.SecurityQuestion = txtSecurityQuestion.Text;
                            objUser.SecurityAnswer = txtSecurityAnswer.Text;
                            objUser.IsApproved = true;
                            objUser.CurrentTimeUtc = DateTime.Now;
                            objUser.CreatedDate = DateTime.Now;
                            objUser.UniqueEmail = 0;
                            objUser.PasswordFormat = m.PasswordFormat;
                            objUser.PortalID = GetPortalID;
                            objUser.AddedOn = DateTime.Now;
                            objUser.AddedBy = GetUsername;
                            objUser.UserID = Guid.NewGuid();
                            objUser.RoleNames = GetSelectedRoleNameString();

                            UserCreationStatus status = new UserCreationStatus();
                            try
                            {
                                MembershipDataProvider.CreatePortalUser(objUser, out status, UserCreationMode.CREATE);

                                if (status == UserCreationStatus.DUPLICATE_USER)
                                {
                                    ShowMessage("", GetSageMessage("UserManagement", "NameAlreadyExists"), "", SageMessageType.Alert);

                                }
                                else if (status == UserCreationStatus.DUPLICATE_EMAIL)
                                {
                                    ShowMessage("", GetSageMessage("UserManagement", "EmailAddressAlreadyIsInUse"), "", SageMessageType.Alert);

                                }
                                else if (status == UserCreationStatus.SUCCESS)
                                {
                                    PanelVisibility(false, true, false);
                                    BindUsers(string.Empty);
                                    ShowMessage("", GetSageMessage("UserManagement", "UserCreatedSuccessfully"), "", SageMessageType.Success);


                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            ShowMessage("", GetSageMessage("UserManagement", "PasswordLength"), "", SageMessageType.Alert);
                        }
                    }
                    else
                    {
                        ShowMessage("", GetSageMessage("UserManagement", "PleaseSelectRole"), "", SageMessageType.Alert);

                    }
                }
                else
                {
                    ShowMessage("", GetSageMessage("UserManagement", "PleaseEnterAllRequiredFields"), "", SageMessageType.Alert);
                }


            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private string GetSelectedRoleNameString()
        {
            List<string> roleList = new List<string>();
            foreach (ListItem li in lstAvailableRoles.Items)
            {
                if (li.Selected == true)
                {
                    roleList.Add(li.Text);
                }
            }

            return (String.Join(",", roleList.ToArray()));
        }

        protected void imgBtnSettings_Click(object sender, ImageClickEventArgs e)
        {
            PanelVisibility(false, false, false);
            pnlSettings.Visible = true;
            LoadSettings();
        }
        private void LoadSettings()
        {
            foreach (SettingInfo obj in MembershipDataProvider.GetSettings())
            {
                switch (obj.SettingKey)
                {
                    case "DUPLICATE_USERS_ACROSS_PORTALS":
                        chkEnableDupNames.Checked = obj.SettingValue.Equals("1") ? true : false;
                        break;
                    case "DUPLICATE_ROLES_ACROSS_PORTALS":
                        chkEnableDupRole.Checked = obj.SettingValue.Equals("1") ? true : false;
                        break;
                    case "SELECTED_PASSWORD_FORMAT":
                        SetPasswordFormat(int.Parse(obj.SettingValue));
                        break;
                    case "DUPLICATE_EMAIL_ALLOWED":
                        chkEnableDupEmail.Checked = obj.SettingValue.Equals("1") ? true : false;
                        break;
                    case "ENABLE_CAPTCHA":
                        chkEnableCaptcha.Checked = obj.SettingValue.Equals("1") ? true : false;
                        break;




                }
            }

        }
        protected void btnSaveSetting_Click(object sender, EventArgs e)
        {
            List<SettingInfo> lstSettings = new List<SettingInfo>();
            SettingInfo dupUsers = new SettingInfo();
            dupUsers.SettingKey = SettingsEnum.DUPLICATE_USERS_ACROSS_PORTALS.ToString();
            dupUsers.SettingValue = chkEnableDupNames.Checked ? "1" : "0";
            SettingInfo dupRoles = new SettingInfo();
            dupRoles.SettingKey = SettingsEnum.DUPLICATE_ROLES_ACROSS_PORTALS.ToString();
            dupRoles.SettingValue = chkEnableDupRole.Checked ? "1" : "0";
            SettingInfo passwordFormat = new SettingInfo();
            passwordFormat.SettingKey = SettingsEnum.SELECTED_PASSWORD_FORMAT.ToString();
            passwordFormat.SettingValue = GetPasswordFormat().ToString();
            SettingInfo dupEmail = new SettingInfo();
            dupEmail.SettingKey = SettingsEnum.DUPLICATE_EMAIL_ALLOWED.ToString();
            dupEmail.SettingValue = chkEnableDupEmail.Checked ? "1" : "0";
            SettingInfo enableCaptcha = new SettingInfo();
            enableCaptcha.SettingKey = SettingsEnum.ENABLE_CAPTCHA.ToString();
            enableCaptcha.SettingValue = chkEnableCaptcha.Checked ? "1" : "0";
            lstSettings.Add(dupUsers);
            lstSettings.Add(dupRoles);
            lstSettings.Add(passwordFormat);
            lstSettings.Add(dupEmail);
            lstSettings.Add(enableCaptcha);

            try
            {
                MembershipDataProvider.SaveSettings(lstSettings);
                ShowMessage("", GetSageMessage("UserManagement", "SettingSavedSuccessfully"), "", SageMessageType.Success);


            }
            catch (Exception)
            {
                throw;
            }
        }
        private int GetPasswordFormat()
        {
            int pwdFormat = (int)SettingsEnum.DEFAULT_PASSWORD_FORMAT;

            pwdFormat = int.Parse(rdbLst.SelectedValue.ToString());
            if (pwdFormat == 3)
            {
                pwdFormat = 3;
            }
            return pwdFormat;

        }
        private void SetPasswordFormat(int PasswordFormat)
        {
            if (PasswordFormat < 3)
            {
                rdbLst.SelectedIndex = PasswordFormat - 1;
            }
            else
            {
                rdbLst.SelectedIndex = 1;
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            PanelVisibility(false, true, false);

        }

        protected void rbFilterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUserGrid(int.Parse(rbFilterMode.SelectedValue.ToString()));
        }

        protected void FilterUserGrid(int FilterMode)
        {
            List<UserInfo> lstUsers = (List<UserInfo>)ViewState["UserList"];
            List<UserInfo> lstNew = new List<UserInfo>();
            switch (FilterMode)
            {
                case 0:
   
                    gdvUser.DataSource = ReorderUserList(lstUsers);
                    gdvUser.DataBind();
                    ViewState["FilteredUser"] = lstUsers;
                    break;
                case 1:

                    foreach (UserInfo user in lstUsers)
                    {
                        if (user.IsActive)
                        {
                            lstNew.Add(user);
                        }
                    }
                    gdvUser.DataSource = ReorderUserList(lstNew);
                    gdvUser.DataBind();
                    ViewState["FilteredUser"] = lstNew;

                    break;
                case 2:
                    foreach (UserInfo user in lstUsers)
                    {
                        if (!user.IsActive)
                        {
                            lstNew.Add(user);
                        }
                    }
                    gdvUser.DataSource = ReorderUserList(lstNew);
                    gdvUser.DataBind();
                    ViewState["FilteredUser"] = lstNew;
                    break;
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
                    if (Session["UserImage"] != null)
                    {
                        filename = Session["UserImage"].ToString();
                    }
                    btnDeleteProfilePic.Visible = false;
                }
                else
                {
                    btnDeleteProfilePic.Visible = true;
                }
                objinfo.Image = filename;
                objinfo.UserName = hdnEditUsername.Value;
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
                GetSageUserInfo(hdnEditUsername.Value);
                tblEditProfile.Visible = false;
                //LoadUserDetails();
                tblViewProfile.Visible = true;
                imgProfileEdit.Visible = false;
                imgProfileView.Visible = true;
                btnDeleteProfilePic.Visible = false;
                //ShowHideProfile();
                //btnDeleteProfilePic.Visible = true;
                Session["UserImage"] = null;
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("UserManagement", "UserProfileSavedSuccessfully"), "", SageMessageType.Success);
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
                objinfo = UserProfileController.GetProfile(hdnEditUsername.Value, GetPortalID);
                if (objinfo != null)
                {
                    string[] Emails = objinfo.Email.Split(',');
                    if (objinfo.Image != "")
                    {
                        imgUser.ImageUrl = "~/Modules/Admin/UserManagement/UserPic/" + objinfo.Image;
                        imgUser.Visible = true;
                        btnDeleteProfilePic.Visible = true;
                        Session["UserImage"] = objinfo.Image;
                        imgProfileEdit.Visible = true;
                    }
                    else
                    {
                        imgUser.Visible = false;
                        btnDeleteProfilePic.Visible = false;
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
                        txtEmail2.Text =  Emails[1] ;
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
        public void ShowHideProfile()
        {
            try
            {
                tblEditProfile.Visible = true;
                //imgProfileEdit.Visible = true;
                tblViewProfile.Visible = false;
                imgProfileView.Visible = false;
                GetUserDetails();
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
                objinfo = UserProfileController.GetProfile(hdnEditUsername.Value, GetPortalID);
                if (objinfo != null)
                {
                    string[] Emails = objinfo.Email.Split(',');
                    if (objinfo.Image != "")
                    {
                        imgViewImage.ImageUrl = "~/Modules/Admin/UserManagement/UserPic/" + objinfo.Image;
                        imgViewImage.Visible = true;
                    }
                    else
                    {
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
        protected void btnCancelProfile_Click(object sender, EventArgs e)
        {
            tblEditProfile.Visible = false;
            LoadUserDetails();
            tblViewProfile.Visible = true;
            imgProfileEdit.Visible = false;
            imgProfileView.Visible = true;
            btnDeleteProfilePic.Visible = false;


        }
        protected void btnDeleteProfilePic_Click(object sender, EventArgs e)
        {
            try
            {
                UserProfileInfo objinfo = new UserProfileInfo();
                objinfo = UserProfileController.GetProfile(hdnEditUsername.Value, GetPortalID);
                if (objinfo.Image != "")
                {
                    string imagePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory) + "UserPic/" + objinfo.Image;
                    string path = Server.MapPath(imagePath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                UserProfileController.DeleteProfilePic(hdnEditUsername.Value, GetPortalID);
                GetUserDetails();
                LoadUserDetails();
                Session["UserImage"] = null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void txtOthers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}