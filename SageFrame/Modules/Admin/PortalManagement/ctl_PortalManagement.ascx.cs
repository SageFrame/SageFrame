using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.PortalSetting;
using System.Web.UI.HtmlControls;
using SageFrame.Framework;
using SageFrame.Web;
using SageFrame.Utilities;
using System.IO;
using System.Collections;
using SageFrame.Shared;
using SageFrame.SageFrameClass;
using SageFrame.Message;
using SageFrame.SageFrameClass.MessageManagement;
using SageFrame.Modules;
//using SageFrame.Core.SageFrame.Modules;
using SageFrame.Templating;
using SageFrame.PortalManagement;

namespace SageFrame.Modules.Admin.PortalManagement
{
    public partial class ctl_PortalManagement : BaseAdministrationUserControl
    {
        SageFrameConfig pagebase = new SageFrameConfig();
        bool IsUseFriendlyUrls = true;
        string appPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
                appPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
                if (!IsPostBack)
                {
                    AddImageUrls();
                    BindPortal();
                    PanelVisibility(false, true);
                    imbBtnSaveChanges.Attributes.Add("onclick", "javascript:return confirm('" + GetSageMessage("PortalModules", "AreYouSureToSaveChanges") + "')");
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        private void AddImageUrls()
        {
            imgCancelList.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imgCancel.ImageUrl = GetTemplateImageUrl("imgcancel.png", true);
            imgAdd.ImageUrl = GetTemplateImageUrl("imgadd.png", true);
            imgSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbBtnSaveChanges.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
        }
        private void BindPortal()
        {
            gdvPortal.DataSource = PortalController.GetPortalList();
            gdvPortal.DataBind();
        }
        private void PanelVisibility(bool VisiblePortal, bool VisiblePortalList)
        {
            pnlPortal.Visible = VisiblePortal;
            pnlPortalList.Visible = VisiblePortalList;
            if (hdnPortalID.Value == "0")
            {
                TabContainerManagePortal.Tabs[1].Visible = false;
            }
            else
            {
                TabContainerManagePortal.Tabs[1].Visible = true;
            }
        }
        private void ClearForm()
        {
            txtPortalName.Text = "";
        }
        protected void imgAdd_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearForm();
                hdnPortalID.Value = "0";
                PanelVisibility(true, false);                
                
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                if (txtPortalName.Text.Trim() != "")
                {
                    SaveProtal();                   
                    BindPortalSetting();
                    HttpContext.Current.Cache.Remove("Portals");
                    BindPortal();
                    PanelVisibility(false, true);
                    HttpContext.Current.Cache.Remove("SageSetting");
                    SageFrameConfig sf = new SageFrameConfig();
                    sf.ResetSettingKeys(int.Parse(this.hdnPortalID.Value.ToString()));
                }
                else
                {
                    lblPortalNameError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }

        }

        private void SaveTemplate()
        {            
           CreateNewTemplateFolder(txtPortalName.Text); 

        }
        public void CreateNewTemplateFolder(string TemplateName)
        {
            try
            {
                string completePath = Server.MapPath(appPath + "/Templates/" + TemplateName);
                string path = HttpContext.Current.Server.MapPath(appPath);

                DirectoryInfo SrcDir = new DirectoryInfo(path + "/Core/Blank/");
                DirectoryInfo DisDir = new DirectoryInfo(path + "/Templates/" + TemplateName);
                CopyDirectory(SrcDir, DisDir);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
       
       
       
        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name));
            }
            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);

                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
       

        public class Foldername
        {
            public string Existfolder { get; set; }

            public Foldername() { }
        }


        private void BindPortalSetting()
        {
            Hashtable hst = new Hashtable();
            SettingProvider sep = new SettingProvider();
            DataTable dt = sep.GetSettingsByPortal(GetPortalID.ToString(), string.Empty); //GetSettingsByPortal();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hst.Add(dt.Rows[i]["SettingKey"].ToString(), dt.Rows[i]["SettingValue"].ToString());
                }
            }
            HttpContext.Current.Cache.Insert("SageSetting", hst);
        }


        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PanelVisibility(false, true);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvPortal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnPortalID = (HiddenField)e.Row.FindControl("hdnPortalID");
                    HiddenField hdnSEOName = (HiddenField)e.Row.FindControl("hdnSEOName");
                    HiddenField hdnIsParent = (HiddenField)e.Row.FindControl("hdnIsParent");
                    HyperLink hypPortalPreview = (HyperLink)e.Row.FindControl("hypPortalPreview");
                    Label lblDefaultPage = (Label)e.Row.FindControl("lblDefaultPage");
                    hypPortalPreview.Text = "Preview";
                    if (IsUseFriendlyUrls)
                    {
                        if (hdnIsParent.Value.ToLower() != "true")
                        {
                            hypPortalPreview.NavigateUrl = ResolveUrl("~/portal/" + hdnSEOName.Value.ToLower() + "/" + lblDefaultPage.Text + ".aspx");
                        }
                        else
                        {
                            hypPortalPreview.NavigateUrl = ResolveUrl("~/" + lblDefaultPage.Text + ".aspx");
                        }
                    }
                    else
                    {
                        hypPortalPreview.NavigateUrl = ResolveUrl("~/Default.aspx?ptlid=" + hdnPortalID.Value + "&ptSEO=" + hdnSEOName.Value.ToLower() + "&pgnm=" + lblDefaultPage.Text);
                    }
                    ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                    HtmlInputCheckBox chkBoxIsParentItem = (HtmlInputCheckBox)e.Row.FindControl("chkBoxIsParentItem");
                    if (hdnIsParent != null && chkBoxIsParentItem != null)
                    {
                        chkBoxIsParentItem.Checked = bool.Parse(hdnIsParent.Value);
                    }
                    if (bool.Parse(hdnIsParent.Value) || Int32.Parse(hdnPortalID.Value) == GetPortalID)
                    {
                        imgDelete.Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvPortal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
               
                //int portalID = Int32.Parse(e.CommandArgument.ToString());
                int rowIndex =  Int32.Parse(e.CommandArgument.ToString());
                int portalID = int.Parse(gdvPortal.DataKeys[rowIndex]["PortalID"].ToString());
                string PortalName = gdvPortal.DataKeys[rowIndex]["Name"].ToString();

                if (e.CommandName == "EditPortal")
                {
                    gdvPortalModulesLists.PageIndex = 0;
                    EditPortal(portalID);
                    PanelVisibility(true, false);
                    //TabContainerManagePortal.Tabs[2].Visible = false;
                    hdnPortalIndex.Value = portalID.ToString();
                    
                }
                else if (e.CommandName == "DeletePortal")
                {
                    DeletePortal(portalID);
                    HttpContext.Current.Cache.Remove("Portals");
                    BindPortal();
                    PanelVisibility(false, true);
                    string target_dir = Utils.GetTemplatePath(PortalName);
                    if(Directory.Exists(target_dir))
                    Utils.DeleteDirectory(target_dir);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
         

        private void EditPortal(Int32 portalID)
        {
            PortalInfo portal = PortalController.GetPortalByPortalID(portalID, GetUsername);
            txtPortalName.Enabled = portal.Name.Equals("Default") ? false : true;

            txtPortalName.Text = portal.Name;
            hdnPortalID.Value = portalID.ToString();
            BindPortalModulesListsGrid(Int32.Parse(hdnPortalID.Value));
        }

        private void DeletePortal(Int32 portalID)
        {
            PortalInfo objInfo = PortalController.GetPortalByPortalID(portalID, GetUsername);
            txtPortalName.Text = objInfo.Name;
            PortalController.DeletePortal(portalID, GetUsername);
            ShowMessage("", GetSageMessage("PortalSettings", "PortalDeleteSuccessfully"), "", SageMessageType.Success);
        }

        private void SaveProtal()
        {
            bool status = false;
            foreach (GridViewRow row in gdvPortal.Rows)
            {
                LinkButton lnkPortal = row.FindControl("lnkUsername") as LinkButton;
                if (gdvPortal.DataKeys[row.RowIndex]["PortalID"].ToString() != hdnPortalIndex.Value)
                {
                    if (lnkPortal.Text.ToLower().Equals(txtPortalName.Text.ToLower()))
                    {
                        status = true;
                    }
                }
            }
            if (!(string.IsNullOrEmpty(txtPortalName.Text)))
            {
                if (!status)
                {
                    if (Int32.Parse(hdnPortalID.Value) > 0)
                    {
                        PortalController.UpdatePortal(Int32.Parse(hdnPortalID.Value), txtPortalName.Text, false, GetUsername);

                    }
                    else
                    {
                        PortalMgrController.AddPortal(txtPortalName.Text, false, GetUsername,txtPortalName.Text);                        
                        SaveTemplate();

                    }
                    ShowMessage("", GetSageMessage("PortalSettings", "PortalSaveSuccessfully"), "", SageMessageType.Success);
                }
                else
                {
                    ShowMessage("", GetSageMessage("PortalSettings", "PortalAlreadyExists"), "", SageMessageType.Alert);
                }
            }
        }

        private void BindPortalModulesListsGrid(int PortalID)
        {

            gdvPortalModulesLists.DataSource = PortalController.GetPortalModulesByPortalID(PortalID, GetUsername);
            gdvPortalModulesLists.DataBind();
           // gdvPortalModulesLists.PageIndex = 0;
        }

        protected void gdvPortalModulesLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gdvPortalModulesLists.PageIndex = e.NewPageIndex;
            BindPortalModulesListsGrid(Int32.Parse(hdnPortalID.Value));
            //TabContainerManagePortal.Tabs[0].Visible = false;
        }


        //protected void gdvPortalModulesLists_OnPageIndexChanged(object sender, GridViewPageEventArgs e)
        //{
        //    gdvPortalModulesLists.PageIndex = 0;
        //    BindPortalModulesListsGrid(Int32.Parse(hdnPortalID.Value));
        //    TabContainerManagePortal.Tabs[2].Visible = false;
        //}


       
        protected void gdvPortalModulesLists_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive");
                HiddenField hdnIsAdmin = (HiddenField)e.Row.FindControl("hdnIsAdmin");

                HtmlInputCheckBox chkIsActiveItem = (HtmlInputCheckBox)e.Row.FindControl("chkBoxIsActiveItem");
                chkIsActiveItem.Attributes.Add("onclick", "javascript:Check(this,'cssCheckBoxIsActiveHeader','" + gdvPortalModulesLists.ClientID + "','cssCheckBoxIsActiveItem');");
                chkIsActiveItem.Checked = bool.Parse(hdnIsActive.Value);
                if (bool.Parse(hdnIsAdmin.Value))
                {
                    chkIsActiveItem.Disabled = true;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                HtmlInputCheckBox chkIsActiveHeader = (HtmlInputCheckBox)e.Row.FindControl("chkBoxIsActiveHeader");
                chkIsActiveHeader.Attributes.Add("onclick", "javascript:SelectAllCheckboxesSpecific(this,'" + gdvPortalModulesLists.ClientID + "','cssCheckBoxIsActiveItem');");
            }
        }

        protected void gdvPortalModulesLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gdvPortalModulesLists_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gdvPortalModulesLists_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gdvPortalModulesLists_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void imbBtnSaveChanges_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string seletedModulesID = string.Empty;
                string IsActive = string.Empty;
                int SelectedPortalID = Int32.Parse(hdnPortalID.Value);

                for (int i = 0; i < gdvPortalModulesLists.Rows.Count; i++)
                {
                    HtmlInputCheckBox chkBoxItem = (HtmlInputCheckBox)gdvPortalModulesLists.Rows[i].FindControl("chkBoxIsActiveItem");
                    HiddenField hdnModuleID = (HiddenField)gdvPortalModulesLists.Rows[i].FindControl("hdnModuleID");
                    seletedModulesID = seletedModulesID + hdnModuleID.Value.Trim() + ",";
                    IsActive = IsActive + (chkBoxItem.Checked ? "1" : "0") + ",";
                }
                if (seletedModulesID.Length > 1 && IsActive.Length > 0)
                {
                    seletedModulesID = seletedModulesID.Substring(0, seletedModulesID.Length - 1);
                    IsActive = IsActive.Substring(0, IsActive.Length - 1);
                    PortalController.UpdatePortalModules(seletedModulesID, IsActive, SelectedPortalID, GetUsername);
                    ShowMessage("", GetSageMessage("PortalModules", "SelectedChangesAreSavedSuccessfully"), "", SageMessageType.Success);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        

    }
}