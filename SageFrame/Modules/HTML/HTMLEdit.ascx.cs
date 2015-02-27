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
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.HTMLText;
using System.Web.Security;
using System.Collections;
using SageFrame.Web.Utilities;

namespace SageFrame.Modules.HTML
{
    public partial class HTMLEdit : BaseAdministrationUserControl
    {
        System.Nullable<Int32> _newHTMLContentID = 0;
        protected void Page_Init(object sender, EventArgs e)
        {
            hdnUserModuleID.Value = SageUserModuleID;            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int portalid = GetPortalID;
                if (!IsPostBack)
                {
                    AddImageUrls();                  
                    string strCommentErrorMSG = GetSageMessage("HTML", "PleaseWriteComments");
                    imbAdd.Attributes.Add("onclick", string.Format("return ValidateHTMLComments('{0}','{1}','{2}');", txtComment.ClientID, lblErrorMessage.ClientID, strCommentErrorMSG));
                    
                }
                BindEditor();
               
               
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

      

        private void AddImageUrls()
        {
            imbAddComment.Visible = false;
            lblAddComment.Visible = false;
            imbAdd.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbBack.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);

        }

        private void HideAll()
        {
            try
            {   
                divViewWrapper.Visible = false;
                divEditWrapper.Visible = false;               
                divEditComment.Visible = false;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        
        private void BindContent()
        {
            try
            {
                HTMLController _html = new HTMLController();
                HTMLContentInfo contentInfo = _html.GetHTMLContent(GetPortalID, Int32.Parse(hdnUserModuleID.Value), GetCurrentCultureName);

                if (contentInfo != null)
                {
                    hdfHTMLTextID.Value = contentInfo.HtmlTextID.ToString();
                    ltrContent.Text = contentInfo.Content.ToString();
                    if (contentInfo.IsActive == true)
                    {
                        divViewWrapper.Visible = true;

                        if (HTMLController.IsAuthenticatedToEdit(hdnUserModuleID.Value,GetUsername,GetPortalID) && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                        {
                            divEditContent.Visible = true;
                        }
                        else
                        {
                            divEditContent.Visible = false;
                        }

                        if (IsAuthenticatedForComment() && contentInfo.IsAllowedToComment == true && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                        {
                            divAddComment.Visible = true;
                            divViewComment.Visible = true;
                            if (!IsPostBack)
                            {
                                BindComment();
                            }
                        }                     
                        else
                        {
                            divAddComment.Visible = false;
                            divViewComment.Visible = true;
                            divEditComment.Visible = false;
                            if (!IsPostBack)
                            {
                                BindComment();
                            }
                        }
                    }
                    else
                    {
                        HideAll();
                        divAddComment.Visible = false;
                        divViewComment.Visible = false;
                        divEditComment.Visible = false;
                        if (HTMLController.IsAuthenticatedToEdit(hdnUserModuleID.Value, GetUsername, GetPortalID) && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                        {
                            divViewWrapper.Visible = true;
                            divEditContent.Visible = true;
                        }  
                    }
                }
                else if (contentInfo == null && Request.QueryString["ManageReturnUrl"] != null && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                {
                    HideAll();
                    divEditWrapper.Visible = true;
                    divAddComment.Visible = false;
                    divViewComment.Visible = false;
                    BindEditor();
                }
                else
                {
                    if (HTMLController.IsAuthenticatedToEdit(hdnUserModuleID.Value, GetUsername, GetPortalID) && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                    {
                        HideAll();
                        divViewWrapper.Visible = true;
                        divEditContent.Visible = true;
                        divAddComment.Visible = false;
                        divViewComment.Visible = false;
                    }
                    else
                    {
                        HideAll();
                        divEditContent.Visible = false;
                        divAddComment.Visible = false;
                        divViewComment.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }           
        }       

        private void BindComment()
        {
            HTMLController objHtml = new HTMLController();
            try
            {
                SQLHandler Sq = new SQLHandler();
                if (IsSuperUser() && GetUsername != SystemSetting.SYSTEM_USER_NOTALLOW_HTMLCOMMENT[0])
                {     
                    //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", hdfHTMLTextID.Value));

                    //List<HTMLContentInfo> ml = Sq.ExecuteAsList<HTMLContentInfo>("dbo.sp_HtmlCommentGetAllByHTMLTextID", ParaMeterCollection);
                   

                    List<HTMLContentInfo> ml = objHtml.BindCommentForSuperUser(GetPortalID, hdfHTMLTextID.Value);
                    if (ml != null)
                    {
                        gdvHTMLList.DataSource = ml;
                        gdvHTMLList.DataBind();
                        if (gdvHTMLList.Rows.Count > 0)
                        {
                            //Setting comment Count
                            Label lblCommentCount = gdvHTMLList.HeaderRow.FindControl("lblCommentCount") as Label;
                            if (lblCommentCount != null)
                            {
                                lblCommentCount.Text = gdvHTMLList.Rows.Count.ToString();
                            }
                            gdvHTMLList.Columns[gdvHTMLList.Columns.Count - 1].Visible = true;
                            gdvHTMLList.Columns[gdvHTMLList.Columns.Count - 2].Visible = true;

                            rowApprove.Visible = true;
                            rowIsActive.Visible = true;
                        }
                    }
                }
                else
                {
                    //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", hdfHTMLTextID.Value));
                    //List<HTMLContentInfo> nl = Sq.ExecuteAsList<HTMLContentInfo>("dbo.sp_HtmlActiveCommentGetByHTMLTextID", ParaMeterCollection);
                    List<HTMLContentInfo> nl = objHtml.BindCommentForOthers(GetPortalID, hdfHTMLTextID.Value);

                    if (nl != null)
                    {
                        gdvHTMLList.DataSource = nl;
                        gdvHTMLList.DataBind();
                        if (gdvHTMLList.Rows.Count > 0)
                        {
                            //Setting comment Count
                            Label lblCommentCount = gdvHTMLList.HeaderRow.FindControl("lblCommentCount") as Label;
                            if (lblCommentCount != null)
                            {
                                lblCommentCount.Text = gdvHTMLList.Rows.Count.ToString();
                            }
                            divViewComment.Style.Add("display", "block");
                            gdvHTMLList.Columns[gdvHTMLList.Columns.Count - 1].Visible = false;
                            gdvHTMLList.Columns[gdvHTMLList.Columns.Count - 2].Visible = false;
                        }

                        rowApprove.Visible = false;
                        rowIsActive.Visible = false;
                    }
                }
            } 
            catch (Exception ex)
            {
                ProcessException(ex);
            }    
        }

        private bool IsSuperUser()
        {
            bool flag = false;
            string[] allowRoles = SystemSetting.SYSTEM_SUPER_ROLES;
            for (int i = 0; i < allowRoles.Length; i++)
            {
                if (Roles.IsUserInRole(GetUsername, allowRoles[i]))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private bool IsAuthenticatedForComment()
        {
            bool isAllow = false;
            string[] allowRoles = SystemSetting.SYSTEM_ROLES_ALLOW_HTMLCOMMENT; //SYSTEM_SUPER_ROLES;
            for (int i = 0; i < allowRoles.Length; i++)
            {
                if (Roles.IsUserInRole(GetUsername, allowRoles[i]))
                {
                    isAllow = true;
                    break;
                }
            }
            return isAllow;
        }

        private void imbEdit_Click()
        {
            try
            {
                HideAll();
                divEditWrapper.Visible = true;
                //divViewComment.Visible = true;                 
                BindEditor();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        
        }
                
    
        private void BindEditor()
        {
            try
            {
                HTMLController _html = new HTMLController();
                HTMLContentInfo objHtmlInfo = _html.GetHTMLContent(GetPortalID, Int32.Parse(hdnUserModuleID.Value), GetCurrentCultureName);
                if (objHtmlInfo != null)
                 {
                     txtBody.Text = objHtmlInfo.Content;
                     chkPublish.Checked = bool.Parse(objHtmlInfo.IsActive.ToString());
                     chkAllowComment.Checked = bool.Parse(objHtmlInfo.IsAllowedToComment.ToString());
                     ViewState["EditHtmlTextID"] = objHtmlInfo.HtmlTextID;
                     divEditWrapper.Visible = true;     
                 }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                HTMLController objHtml = new HTMLController();
               
                    ArrayList arrColl = null;
                    arrColl = IsContentValid(txtBody.Text.ToString());
                  
                        SQLHandler sq = new SQLHandler();
                        string HTMLBodyText = arrColl[1].ToString().Trim();
                        if (ViewState["EditHtmlTextID"] != null)
                        {
                            //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", hdnUserModuleID.Value));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", HTMLBodyText));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", GetCurrentCultureName));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAllowedToComment", chkAllowComment.Checked));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", chkPublish.Checked));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", true));

                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedOn", DateTime.Now));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", GetUsername));
                            //sq.ExecuteNonQuery("dbo.sp_HtmlTextUpdate", ParaMeterCollection);

                            objHtml.HtmlTextUpdate(hdnUserModuleID.Value, HTMLBodyText, GetCurrentCultureName, chkAllowComment.Checked, chkPublish.Checked, true, DateTime.Now, GetPortalID, GetUsername);
                            //AfterSaveContent();
                            ViewState["EditHtmlTextID"] = null;
                            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("HTML", "HTMLContentIsUpdatedSuccessfully"), "", SageMessageType.Success);
                        }
                        else
                        {
                            //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", hdnUserModuleID.Value));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", HTMLBodyText));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", GetCurrentCultureName));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAllowedToComment", chkAllowComment.Checked));                            
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", true));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", chkPublish.Checked));

                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedOn", DateTime.Now));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                            //ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", GetUsername));
                            //sq.ExecuteNonQuery("dbo.sp_HtmlTextAdd", ParaMeterCollection, "@HTMLTextID");
                            objHtml.HtmlTextAdd(hdnUserModuleID.Value, HTMLBodyText, GetCurrentCultureName, chkAllowComment.Checked, true, chkPublish.Checked, DateTime.Now, GetPortalID, GetUsername);
                            //AfterSaveContent();
                            if (_newHTMLContentID != 0)
                            {
                                ShowMessage("", GetSageMessage("HTML", "HTMLContentIsAddedSuccessfully"), "", SageMessageType.Success);
                            }
                        }
                        BindComment();
                
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
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

        protected void AfterSaveContent()
        {
            try
            {
                HideAll();       
                Response.Redirect(Request.Url.OriginalString);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbAddComment_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                HideAll();

                divViewWrapper.Visible = true;
                divViewComment.Visible = false;
                divEditComment.Visible = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbAdd_Click(object sender, ImageClickEventArgs e)
        {
            HTMLController objHtml = new HTMLController();
            try
            {
                SQLHandler sq = new SQLHandler();

                
                if (Session["EditCommentID"] != null)
                {
                    //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", Session["EditCommentID"]));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@Comment", txtComment.Text));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsApproved", chkApprove.Checked));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", chkIsActive.Checked));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", true));

                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedOn", DateTime.Now));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", GetUsername));
                    //sq.ExecuteNonQuery("dbo.sp_HtmlCommentUpdate", ParaMeterCollection);
                    objHtml.HtmlCommentUpdate(Session["EditCommentID"], txtComment.Text, chkApprove.Checked, chkApprove.Checked, true, DateTime.Now, GetPortalID, GetUsername);

                    ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("HTML", "CommentIsUpdatedSuccessfully"), "", SageMessageType.Success);
                }
                else
                {
                    //objHtml.HtmlCommentAdd(hdfHTMLTextID.Value, txtComment.Text, chkApprove.Checked, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername);
                    objHtml.HtmlCommentAdd(hdfHTMLTextID.Value, txtComment.Text, chkApprove.Checked, chkIsActive.Checked, DateTime.Now, GetPortalID, GetUsername);
                    //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", hdfHTMLTextID.Value));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@Comment", txtComment.Text));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsApproved", chkApprove.Checked));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", chkIsActive.Checked));

                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedOn", DateTime.Now));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                    //ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", GetUsername));
                    //sq.ExecuteNonQuery("dbo.sp_HtmlCommentAdd", ParaMeterCollection, "@HTMLCommentID");

                    if (chkApprove.Checked && chkIsActive.Checked)
                    {
                        ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("HTML", "CommentIsAddedSuccessfully"), "", SageMessageType.Success);
                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("HTML", "CommentWillBeAddedAfterApproved"), "", SageMessageType.Alert);
                    }
                }

                HideAll();
                BindComment();

                divViewWrapper.Visible = true;
                divViewComment.Visible = true;

                ClearComment();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void ClearComment()
        {
            Session["EditCommentID"] = null;
            txtComment.Text = "";
            chkApprove.Checked = false;
            chkIsActive.Checked = false;

        }

        protected void gdvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gdvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName.ToString())
                {
                    case "Edit":
                        int EditID = Int32.Parse(e.CommandArgument.ToString());
                        Edit(EditID);
                        break;
                    case "Delete":
                        int DeleteID = Int32.Parse(e.CommandArgument.ToString());
                        Delete(DeleteID);
                        break;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void Edit(int EditID)
        {
            HTMLController objHtml = new HTMLController();
            try
            {
                SQLHandler sq = new SQLHandler();
                //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", EditID));
                //HTMLContentInfo CommentInfo= sq.ExecuteAsObject<HTMLContentInfo>("dbo.sp_HtmlCommentGetByHTMLCommentID", ParaMeterCollection);
                HTMLContentInfo CommentInfo = objHtml.HtmlCommentGetByHTMLCommentID(GetPortalID, EditID);

                if (CommentInfo != null)
                {
                    txtComment.Text = CommentInfo.Comment;
                    chkApprove.Checked = (bool)CommentInfo.IsApproved;
                    chkIsActive.Checked = (bool)CommentInfo.IsActive;
                    Session["EditCommentID"] = EditID;
                    HideAll();                   
                    divViewWrapper.Visible = true;
                    divEditComment.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void Delete(int DeleteID)
        {
            try
            {
                //SQLHandler sq = new SQLHandler();
                //List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                //ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", DeleteID));
                //ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", GetPortalID));
                //ParaMeterCollection.Add(new KeyValuePair<string, object>("@DeletedBy", GetUsername));
                //sq.ExecuteNonQuery("dbo.sp_HTMLCommentDeleteByCommentID", ParaMeterCollection);
                HTMLController objHtml = new HTMLController();
                objHtml.HTMLCommentDeleteByCommentID(DeleteID, GetPortalID, GetUsername);
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("HTML", "CommentIsDeletedSuccessfully"), "", SageMessageType.Success);
                BindComment();
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
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("imgDelete");
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("HTML", "AreYouSureToDelete") + "')");
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


        protected void imbBack_Click(object sender, ImageClickEventArgs e)
        {
            HideAll();
            divViewWrapper.Visible = true;
            divViewComment.Visible = true;
            ClearComment();
        }

        protected void gdvHTMLList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCustomizeEditor_Click(object sender, EventArgs e)
        {
            btnCustomizeEditor.Visible = false;
            btnDefault.Visible = true;
            HideAll();
            divEditWrapper.Visible = true;
        }

        protected void btnDefault_Click(object sender, EventArgs e)
        {
            btnCustomizeEditor.Visible = true;
            btnDefault.Visible = false;
            HideAll();
            divEditWrapper.Visible = true;
        }
    }
}