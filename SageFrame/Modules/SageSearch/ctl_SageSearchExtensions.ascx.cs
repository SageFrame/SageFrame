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
using SageFrame.Web.Common.SEO;
using System.Data;

public partial class Modules_SageSearch_ctl_SageSearchExtensions : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddImageUrls();
            BindGrid();
            frmWrapper.Visible = false;
            gdvWrapper.Visible = true;
            actionWrapper.Visible = true;
        }
    }

    private void AddImageUrls()
    {
        imbAddNew.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
        imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
        imbCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
    }

    private void BindGrid()
    {
        try
        {
            SageFrameSearch SFH = new SageFrameSearch();
            DataTable dt = SFH.ListSageSerchProcedures(GetPortalID);
            gdvList.DataSource = dt;
            gdvList.DataBind();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void EditByID(int ID)
    {
        SageFrameSearch SFH = new SageFrameSearch();
        SageFrameSearchProcedureInfo objInfo = SFH.SageFrameSearchProcedureGet(ID.ToString());
        if (objInfo != null)
        {
            txtSageFrameSearchTitle.Text = objInfo.SageFrameSearchTitle;
            txtSageFrameSearchProcedureName.Text = objInfo.SageFrameSearchProcedureName;
            txtSageFrameSearchProcedureExecuteAs.Text = objInfo.SageFrameSearchProcedureExecuteAs;
            frmWrapper.Visible = true;
            gdvWrapper.Visible = false;
            actionWrapper.Visible = false;
            Session["EditID"] = ID;
        }
    }

    private void DelteByID(int ID)
    {
        SageFrameSearch SFH = new SageFrameSearch();
        SFH.SageFrameSearchProcedureDelete(ID, GetUsername);
        BindGrid();
        ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("SageFrameSearch", "SearchExtensionDeltedSuccessfully"), "", SageMessageType.Success);
    }

    protected void gdvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvList.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Edit":
                    EditByID(ID);
                    break;
                case "Delete":
                    DelteByID(ID);
                    break;
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    protected void gdvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDelete = (ImageButton)e.Row.FindControl("imbDelete");
            btnDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("SageFrameSearch", "AreYouSureToDeletThisExtension") + "')");

        }
    }
    protected void gdvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void imbSave_Click(object sender, ImageClickEventArgs e)
    {
        SaveExtension();
    }
    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        ClearForm();
        
    }

    private void SaveExtension()
    {
        try
        {
            int SageFrameSearchProcedureID = 0;
            if (Session["EditID"] != null)
            {
                //Update
                SageFrameSearchProcedureID = Int32.Parse(Session["EditID"].ToString());
            }
            SageFrameSearchProcedureInfo objInfo = new SageFrameSearchProcedureInfo();
            objInfo.AddedBy = GetUsername;
            objInfo.AddedOn = DateTime.Now;
            objInfo.DeletedBy = GetUsername;
            objInfo.DeletedOn = DateTime.Now;
            objInfo.IsActive = true;
            objInfo.IsDeleted = false;
            objInfo.IsModified = false;
            objInfo.PortalID = GetPortalID;
            objInfo.SageFrameSearchProcedureExecuteAs = txtSageFrameSearchProcedureExecuteAs.Text.Trim();
            objInfo.SageFrameSearchProcedureID = SageFrameSearchProcedureID;
            objInfo.SageFrameSearchProcedureName = txtSageFrameSearchProcedureName.Text.Trim();
            objInfo.SageFrameSearchTitle = txtSageFrameSearchTitle.Text.Trim();
            objInfo.UpdatedBy = GetUsername;
            objInfo.UpdatedOn = DateTime.Now;
            SageFrameSearch SFH = new SageFrameSearch();
            SFH.SageFrameSearchProcedureAddUpdate(objInfo, GetPortalID, GetUsername);
            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("SageFrameSearch", "SearchExtensionSavedSuccessfully"), "", SageMessageType.Success);
            ClearForm();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void ClearForm()
    {
        try
        {
            txtSageFrameSearchTitle.Text = "";
            txtSageFrameSearchProcedureName.Text = "";
            txtSageFrameSearchProcedureExecuteAs.Text = "dbo";
            Session["EditID"] = null;
            frmWrapper.Visible = false;
            gdvWrapper.Visible = true;
            actionWrapper.Visible = true;
            BindGrid();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }
    protected void imbAddNew_Click(object sender, ImageClickEventArgs e)
    {
        ClearForm();
        frmWrapper.Visible = true;
        gdvWrapper.Visible = false;
        actionWrapper.Visible = false;
    }
}
