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
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.RolesManagement;
using SageFrame.Security;
using SageFrame.Security.Entities;
using SageFrame.Security.Helpers;

namespace SageFrame.Modules.Admin.UserManagement
{
    public partial class ctl_ManageRoles : BaseAdministrationUserControl
    {
        //RolesManagementDataContext dbRoles = new RolesManagementDataContext(SystemSetting.SageFrameConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlRole.Visible = false;
                    pnlRoles.Visible = true;
                    BindRoles();
                    AddImageUrls();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(SystemSetting.SYSTEM_ROLES.Contains(e.Row.Cells[0].Text, StringComparer.OrdinalIgnoreCase))
                {
                    ImageButton btnDelete = (ImageButton)e.Row.FindControl("imbDelete");
                    btnDelete.Visible = false;
                }
                else
                {
                    ImageButton btnDelete = (ImageButton)e.Row.FindControl("imbDelete");
                    btnDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("UserManagement", "AreYouSureToDelete") + "')");
                }

            }
        }

        private void AddDeleteCommandFieldInGrid()
        {
            CommandField field = new CommandField();
            field.ButtonType = ButtonType.Image;
            field.DeleteImageUrl = GetTemplateImageUrl("imgdelete.png", true);
            field.ShowDeleteButton = true;
            field.ShowHeader = false;
            gdvRoles.Columns.Add(field);
            gdvRoles.DataBind();
        }

        private void AddImageUrls()
        {
            imgAdd.ImageUrl = GetTemplateImageUrl("imgSave.png", true);
            imgCancel.ImageUrl = GetTemplateImageUrl("imgCancel.png", true);
            imbAddNewRole.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
        }

        protected void imgAdd_Click(object sender, EventArgs e)
        {
            try
            {
                    string rolePrefix = GetPortalSEOName + "_";
                    RoleInfo objRole = new RoleInfo();
                    objRole.ApplicationName =Membership.ApplicationName;
                    objRole.RoleName = txtRole.Text;
                    objRole.PortalID = GetPortalID;
                    objRole.IsActive = 1;
                    objRole.AddedOn = DateTime.Now;
                    objRole.AddedBy = GetUsername;

                    if (txtRole.Text.ToLower().Equals("superuser"))
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("UserManagement", "ThisRoleAlreadyExists"), "", SageMessageType.Error);

                    }
                    else
                    {
                        RoleController r = new RoleController();
                        RoleCreationStatus status = new RoleCreationStatus();
                        r.CreateRole(objRole, out status);
                        if (status == RoleCreationStatus.DUPLICATE_ROLE)
                        {
                            ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("UserManagement", "ThisRoleAlreadyExists"), "", SageMessageType.Error);

                        }
                        else if (status == RoleCreationStatus.SUCCESS)
                        {
                            BindRoles();
                            pnlRole.Visible = false;
                            pnlRoles.Visible = true;
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("UserManagement", "RoleSavedSuccessfully"), "", SageMessageType.Success);
                        }

                    }

                   
               
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            try
            {
                pnlRole.Visible = false;
                pnlRoles.Visible = true;
            }
            catch(Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        private void DeleteRole(string role,string roleid)
        {
            try
            {
                if (SystemSetting.SYSTEM_ROLES.Contains(role, StringComparer.OrdinalIgnoreCase))
                {
                   ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("UserManagement", "ThisIsSystemRoleAndCannotBeDeleted"), "", SageMessageType.Alert);
                }
                else
                {
                    Guid RoleID = new Guid(roleid);                  
                    RoleController roleObj = new RoleController();
                    roleObj.DeleteRole(RoleID, GetPortalID);
                    
                    BindRoles();
                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("UserManagement", "RoleIsDeletedSuccessfully"), "", SageMessageType.Success);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("UserManagement", "RoleCannnotBeDeleted"), "", SageMessageType.Error);
            }
        }

        private void BindRoles()
        {
            try
            {
                DataTable dtRoles = new DataTable();
                dtRoles.Columns.Add("Role");
                dtRoles.Columns.Add("RoleID");
                dtRoles.AcceptChanges();

                //var roles = dbRoles.sp_PortalRoleList(GetPortalID,true,GetUsername);
                List<RolesManagementInfo> objRoles = RolesManagementController.PortalRoleList(GetPortalID, true, GetUsername);

                foreach (RolesManagementInfo role in objRoles)
                {
                    string roleName = role.RoleName;
                    if (SystemSetting.SYSTEM_ROLES.Contains(roleName, StringComparer.OrdinalIgnoreCase))
                    {
                        DataRow dr = dtRoles.NewRow();
                        dr["Role"] = roleName;
                        dr["RoleID"] = role.RoleId;
                        dtRoles.Rows.Add(dr);
                    }
                    else
                    {
                        string rolePrefix = GetPortalSEOName + "_";
                        roleName = roleName.Replace(rolePrefix, "");
                        DataRow dr = dtRoles.NewRow();
                        dr["Role"] = roleName;
                        dr["RoleID"] = role.RoleId;
                        dtRoles.Rows.Add(dr);
                    }
                }
                gdvRoles.DataSource = dtRoles;
                gdvRoles.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbAddNewRole_Click(object sender, EventArgs e)
        {
            try
            {
                txtRole.Text = "";
                pnlRole.Visible = true;
                pnlRoles.Visible = false;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string RoleID = gdvRoles.DataKeys[int.Parse(e.CommandArgument.ToString())]["RoleID"].ToString();
                string Role = gdvRoles.DataKeys[int.Parse(e.CommandArgument.ToString())]["Role"].ToString();
                switch (e.CommandName.ToString())
                {
                    case "Delete":
                        DeleteRole(Role,RoleID);                        
                        break;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
    }
}