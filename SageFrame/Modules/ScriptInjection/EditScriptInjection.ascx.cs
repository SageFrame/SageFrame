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
using SageFrame.ScriptInjection.Entity;
using SageFrame.ScriptInjection.Controller;

public partial class Modules_ScriptInjection_EditScriptInjection : BaseAdministrationUserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                IncludeImage();
                loadOngdvScriptTobeEmbed(Int32.Parse(SageUserModuleID));
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

    }


    private void Visibility(bool GridVisible, bool FormVisible)
    {
        grdForm.Visible = GridVisible;
        divScriptForm.Visible = FormVisible;
    }


    private void IncludeImage()
    {
        imbSaveScript.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
        imbScriptInjectCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
        imbSaveCheckedItem.ImageUrl = GetTemplateImageUrl("btnsave.png", true);
    }


    #region Save Script To database


    protected void imbSaveScript_Click(object sender, ImageClickEventArgs e)
    {
        SaveScriptData();
        ClearForm();
    }


    private void SaveScriptData()
    {
        try
        {
            ScriptInjectionInfo obj = new ScriptInjectionInfo();
            if (Session["ScriptId"] != null && Session["ScriptId"].ToString() != string.Empty)
            {
                obj.ScriptID = Int32.Parse(Session["ScriptId"].ToString());
                Session.Contents.Remove("ScriptId");
            }
            else
            {
                obj.ScriptID = 0;
            }

            if (txtScriptName.Text != string.Empty && txtScriptDescription.Text != string.Empty && txtScriptContent.Text != string.Empty)
            {
                string Ext = System.IO.Path.GetExtension(txtScriptName.Text);
                if (Ext == ".html")
                {
                    obj.ScriptName = txtScriptName.Text;
                }
                else
                {
                    obj.ScriptName = txtScriptName.Text + ".html";
                }
                obj.ScriptToBeEmbed = txtScriptContent.Text;
                obj.ScriptDescription = txtScriptDescription.Text;
                obj.UserModuleID = Int32.Parse(SageUserModuleID);
                obj.PortalID = GetPortalID;
                obj.IsVisible = true;
            }

            if (txtScriptName.Text != string.Empty && txtScriptDescription.Text != string.Empty && txtScriptContent.Text != string.Empty)
            {
                ScriptInjectionController objC = new ScriptInjectionController();
                objC.SaveScriptData(obj);
                ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/ScriptInjection/ModuleLocalText", "SavedSucessfully"), "", SageMessageType.Success);
                divScriptContainer.Attributes.Add("style", "display:block");
                divScriptForm.Attributes.Add("style", "display:none");
                loadOngdvScriptTobeEmbed(Int32.Parse(SageUserModuleID));
            }
            else
            {
                ShowMessage(SageMessageTitle.Information.ToString(), SageMessage.GetSageModuleLocalMessageByVertualPath("Modules/ScriptInjection/ModuleLocalText", "PleaseFillTheFormFirst"), "", SageMessageType.Success);
                divScriptContainer.Attributes.Add("style", "display:none");
                divScriptForm.Attributes.Add("style", "display:block");
            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }


    }


    protected void imbScriptInjectCancel_Click(object sender, ImageClickEventArgs e)
    {
        divScriptContainer.Attributes.Add("style", "display:block");
        divScriptForm.Attributes.Add("style", "display:none");
    }


    #endregion


    private void ClearForm()
    {
        txtScriptDescription.Text = string.Empty;
        txtScriptName.Text = string.Empty;
        txtScriptContent.Text = string.Empty;

    }


    #region gdvScriptTobeEmbed region


    private void loadOngdvScriptTobeEmbed(int UserModuleID)
    {
        try
        {
            gdvScriptTobeEmbed.DataSource = ScriptInjectionController.gdvScriptTobeEmbed(UserModuleID);
            gdvScriptTobeEmbed.DataBind();
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }

    }


    protected void gdvScriptTobeEmbed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgBtn = e.Row.FindControl("imgDeleteScript") as ImageButton;
            if (imgBtn != null)
            {
                imgBtn.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure to delete?')");
            }
        }

    }


    protected void gdvScriptTobeEmbed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ScriptId = Int32.Parse(e.CommandArgument.ToString());
        switch (e.CommandName.ToString())
        {
            case "EditSCript":
                EditScript(ScriptId);
                break;
            case "DeleteScript":
                DeleteScript(ScriptId);
                break;
        }

    }


    private void EditScript(int ScriptId)
    {
        try
        {
            divScriptContainer.Attributes.Add("style", "display:none");
            divScriptForm.Attributes.Add("style", "display:block");
            ScriptInjectionController objC = new ScriptInjectionController();
            ScriptInjectionInfo objInf = new ScriptInjectionInfo();
            objInf = objC.GetSCriptToBeEdit(ScriptId);
            txtScriptContent.Text = objInf.ScriptToBeEmbed;
            txtScriptName.Text = objInf.ScriptName;
            txtScriptDescription.Text = objInf.ScriptDescription;
            Session["ScriptId"] = ScriptId;
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }


    private void DeleteScript(int ScriptId)
    {
        try
        {
            ScriptInjectionController objC = new ScriptInjectionController();
            objC.DeleteScriptByID(ScriptId);
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
        loadOngdvScriptTobeEmbed(Int32.Parse(SageUserModuleID));

    }


    protected void gdvScriptTobeEmbed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvScriptTobeEmbed.PageIndex = e.NewPageIndex;
        loadOngdvScriptTobeEmbed(Int32.Parse(SageUserModuleID));

    }


    #endregion


    protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        gdvScriptTobeEmbed.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue.ToString());
        loadOngdvScriptTobeEmbed(Int32.Parse(SageUserModuleID));

    }


    protected void imbSaveCheckedItem_Click(object sender, ImageClickEventArgs e)
    {

        foreach (GridViewRow grdRow in gdvScriptTobeEmbed.Rows)
        {

            int ScriptID = 0;
            HiddenField hdfscriptID = grdRow.FindControl("hdfScriptID") as HiddenField;
            ScriptID = Convert.ToInt32(hdfscriptID.Value);
            bool isVisible = ((CheckBox)grdRow.FindControl("chkHideShowScript")).Checked;
            ScriptInjectionController objC = new ScriptInjectionController();
            objC.SaveHideShowScript(ScriptID, isVisible);
        }
    }
}
