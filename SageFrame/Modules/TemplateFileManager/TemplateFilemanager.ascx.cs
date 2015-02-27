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
using SageFrame.Templating;
using System.IO;
using System.Collections;
using SageFrame.Templating.xmlparser;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class Modules_TemplateFileManager_TemplateFilemanager : BaseAdministrationUserControl
{

    public string appPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        
        IncludeCss("TemplateFileManager", "/Modules/TemplateFileManager/module.css");
        IncludeJs("LayoutManager", false, "/Modules/LayoutManager/CodeMirror/codemirror.js");
        IncludeJs("LayoutManager", "/Modules/LayoutManager/CodeMirror/xml.js");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/codemirror.css");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/default.css");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/docs.css");
        try
        {
            if (!IsPostBack)
            {
                BindTemplate();
                //if (TemplateName != "")
                //{
                //    ddlTemplateList.Items.FindByText(TemplateName).Selected = true;
                //}
                if (Request.QueryString["tname"] != null)
                {
                    BindFiles(Request.QueryString["tname"].ToString());
                    ddlTemplateList.Items.FindByText(Request.QueryString["tname"].ToString()).Selected = true;
                }
                else
                {
                    BindFiles(ddlTemplateList.SelectedItem.ToString());
                }                
                rptBreadCrum.DataSource = BreadCumlist(ddlTemplateList.SelectedItem.ToString());
                rptBreadCrum.DataBind();

                ViewState["SelFile"] = ddlTemplateList.SelectedItem.ToString();

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    public static List<FileEntity> GetFiles(string TemplateName)
    {
        string filePath = Utils.GetTemplatePath(TemplateName);
        List<FileEntity> lstFiles = new List<FileEntity>();
        if (Directory.Exists(filePath))
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);
            foreach (DirectoryInfo folder in dir.GetDirectories())
            {
                lstFiles.Add(new FileEntity(folder.Name, folder.FullName, "", Path.HasExtension(folder.Name) ? false : true, Size(folder), folder.CreationTime.ToShortDateString()));
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                lstFiles.Add(new FileEntity(file.Name, file.FullName, Path.GetExtension(file.Name), Path.HasExtension(file.Name) ? false : true, file.Length, file.CreationTime.ToShortDateString()));
            }
        }
        return lstFiles;
    }
    public static long Size(DirectoryInfo dirInfo)
    {
        long total = 0;

        foreach (System.IO.FileInfo file in dirInfo.GetFiles())
            total += file.Length;

        foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
            total += Size(dir);

        return total;
    }
    public static List<TemplateInfo> GetTemplateList()
    {
        string templatedir = Utils.GetAbsolutePath(TemplateConstants.TemplateDirectory);
        DirectoryInfo dir = new DirectoryInfo(templatedir);
        List<TemplateInfo> lstTemplates = new List<TemplateInfo>();
        foreach (DirectoryInfo temp in dir.GetDirectories())
        {
            TemplateInfo tempObj = new TemplateInfo(temp.Name);
            lstTemplates.Add(tempObj);
        }
        return lstTemplates;
    }
    public void BindTemplate()
    {
        try
        {

            ddlTemplateList.DataSource = GetTemplateList();
            ddlTemplateList.DataTextField = "TemplateName";
            ddlTemplateList.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    public void BindFiles(string fileName)
    {
        try
        {
            gdvTemplateFileManager.DataSource = GetFiles(fileName);
            gdvTemplateFileManager.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


    protected void ddlTemplateList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            BindFiles(ddlTemplateList.SelectedItem.ToString());
            ViewState["SelFile"] = ddlTemplateList.SelectedItem.ToString();
            ViewState["SelFile1"] = "";
            BuildBreadCrumb();
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    protected void gdvTemplateFileManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            switch (e.CommandName.ToString())
            {
                case "Explore":

                    string FileName = e.CommandArgument.ToString();
                    bool check = false;
                    if (!Path.HasExtension(FileName))
                    {

                        var filename = "";

                        if (ViewState["SelFile"] != null && ViewState["SelFile"].ToString() != "")
                        {
                            check = ViewState["SelFile"].ToString().Contains(FileName) ? true : false;
                        }

                        if (ViewState["SelFile"] != null)
                        {
                            if (check == false)
                            {
                                filename = ViewState["SelFile"].ToString() + "/" + FileName;
                            }
                            else
                            {
                                filename = ViewState["SelFile"].ToString();
                            }
                        }
                        else
                        {

                            filename = ddlTemplateList.SelectedItem.ToString() + "/" + FileName;
                        }

                        BindFiles(filename);
                        ViewState["SelFile"] = "";
                        ViewState["SelFile"] = filename;
                    }
                    else
                    {
                        var filename = "";
                        if (ViewState["SelFile"] != null && ViewState["SelFile"].ToString() != "")
                        {
                            check = ViewState["SelFile"].ToString().Contains(FileName) ? true : false;
                        }

                        if (ViewState["SelFile"] != null)
                        {
                            if (check == false)
                            {
                                if (Path.HasExtension(ViewState["SelFile"].ToString()))
                                {
                                    string file = Path.GetFileName(ViewState["SelFile"].ToString());
                                    filename = ViewState["SelFile"].ToString().Replace(file, "") + FileName;

                                }
                                else
                                {
                                    filename = ViewState["SelFile"].ToString() + "/" + FileName;
                                }
                            }
                            else
                            {
                                filename = ViewState["SelFile"].ToString();
                            }
                        }
                        else
                        {
                            filename = FileName;
                        }

                        ViewState["SelFile"] = filename;
                        if (Path.GetExtension(filename) == ".png" || Path.GetExtension(filename) == ".jpg" || Path.GetExtension(filename) == ".jpeg" || Path.GetExtension(filename) == ".ico")
                        {
                            string AbsPath = Utils.GetTemplatePath(ddlTemplateList.SelectedValue.ToString());

                            string ServerName = Server.MapPath("~/");
                            string imagePath = Request.ApplicationPath + "/Templates/" + filename;

                            imgEditor.ImageUrl = imagePath;
                            imgEditor.AlternateText = "Unable To Find Image";

                            imgEditor.Visible = true;
                            divBreadCrum.Visible = true;
                            divSelectTemplate.Visible = false;
                            divLstFile.Visible = false;
                            divFileUploader.Visible = false;
                            tblCreateFileFolder.Visible = false;
                            txtEditor.Visible = false;
                            btnSave.Visible = false;
                            btnCancel.Visible = true;
                            lblCreate.Visible = false;
                            BindFiles(filename);


                        }
                        else
                        {
                            string filedata = ReadFiles(ddlTemplateList.SelectedItem.ToString(), filename);
                            txtEditor.Text = filedata;
                            divBreadCrum.Visible = true;
                            divSelectTemplate.Visible = false;
                            divLstFile.Visible = false;
                            divFileUploader.Visible = false;
                            tblCreateFileFolder.Visible = false;
                            txtEditor.Visible = true;
                            btnSave.Visible = true;
                            btnCancel.Visible = true;
                            lblCreate.Visible = false;
                            BindFiles(filename);

                        }
                        BuildBreadCrumb();

                    }
                    break;

                case "Delete":
                    string IsDelete = e.CommandArgument.ToString();
                    try
                    {

                        string AbsPath = Utils.GetTemplatePath(ddlTemplateList.SelectedValue.ToString());
                        string DeletePath = string.Empty;
                        string Bindpath = ViewState["SelFile"].ToString();
                        if (ViewState["SelFile"].ToString() != null)
                        {
                            DeletePath = ViewState["SelFile"].ToString() + "/" + IsDelete;
                        }

                        if (AbsPath.Contains(ddlTemplateList.SelectedValue.ToString()))
                        {
                            DeletePath = AbsPath.Replace(ddlTemplateList.SelectedValue.ToString(), "") + DeletePath;
                        }
                        else
                        {
                            DeletePath = AbsPath + DeletePath;
                        }
                        if (!Path.HasExtension(IsDelete))
                        {
                            Directory.Delete(DeletePath, true);
                            BindFiles(Bindpath);
                            ShowMessage("","Folder Deleted Successfully", "", SageMessageType.Success);
                        }
                        else
                        {
                            if (File.Exists(DeletePath))
                            {

                                File.Delete(DeletePath);
                                BindFiles(Bindpath);
                                ShowMessage("", "File Deleted Successfully", "", SageMessageType.Success);


                            }

                        }
                       

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }


                    break;

            }
            BuildBreadCrumb();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BuildBreadCrumb()
    {
        try
        {
            rptBreadCrum.DataSource = BreadCumlist(ViewState["SelFile"].ToString());
            rptBreadCrum.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    protected void gdvTemplateFileManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gdvTemplateFileManager_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void gdvTemplateFileManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvTemplateFileManager_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvTemplateFileManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string currentPath = ViewState["SelFile"].ToString();
        string seprater = "/";
        string bindPath = currentPath.Substring(currentPath.LastIndexOf(seprater)).Replace("/","");
        gdvTemplateFileManager.PageIndex = e.NewPageIndex;
        BindFiles(ViewState["SelFile"].ToString());

    }


    public static string ReadFiles(string TemplateName, string FilePath)
    {
        XmlParser _parser = new XmlParser();
        string filePath = Utils.GetTemplatePath(TemplateName);
        if (filePath.Contains(TemplateName))
        {
            filePath = filePath.Replace(TemplateName, "") + FilePath;
        }
        else
        {
            filePath = filePath + "/" + FilePath;
        }
        string html = GetXMLString(filePath);
        return html;
    }


    public static string GetXMLString(string filePath)
    {

        StreamReader sr = null;
        string xml = null;
        try
        {
            sr = new StreamReader(filePath);
            xml = sr.ReadToEnd();
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
                sr = null;
            }
        }
        return xml;
    }
    public List<string> BreadCumlist(string BreadCrum)
    {
        List<string> bcList = new List<string>();
        bcList.Clear();
        bcList = BreadCrum.Split('/').ToList();
        return bcList;
    }


    protected void rptBreadCrum_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            string File = e.CommandArgument.ToString();
            string FullPath = string.Empty;
            if (ViewState["SelFile"].ToString() != null)
            {
                FullPath = ViewState["SelFile"].ToString();
            }

            if (!Path.HasExtension(File))
            {
                txtEditor.Visible = false;
                txtEditor.Text = string.Empty;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                txtEditor.Text = string.Empty;
                imgEditor.Visible = false;
            }
            string NewBreadCrum = FullPath.Substring(0, FullPath.IndexOf(File) + File.Length);

            ViewState["SelFile"] = NewBreadCrum;

            gdvTemplateFileManager.DataSource = GetFiles(NewBreadCrum);
            gdvTemplateFileManager.DataBind();
            divLstFile.Visible = true;

            rptBreadCrum.DataSource = BreadCumlist(NewBreadCrum);
            rptBreadCrum.DataBind();

            divFileUploader.Visible = true;
            tblCreateFileFolder.Visible = true;
            lblCreate.Visible = true;

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = Utils.GetTemplatePath(ddlTemplateList.SelectedValue.ToString());
            string File = ViewState["SelFile"].ToString();

            if (filePath.Contains(ddlTemplateList.SelectedValue.ToString()))
            {
                File = filePath.Replace(ddlTemplateList.SelectedValue.ToString(), "") + File;
            }
            else
            {
                File = filePath + File;
            }
            System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(File);
            objStreamWriter.Write(txtEditor.Text);
            objStreamWriter.Close();
            Back();

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            string TPath = Utils.GetTemplatePath(ddlTemplateList.SelectedValue.ToString());
            string CreatPath = string.Empty;
            if (ViewState["SelFile"].ToString() != null)
            {
                CreatPath = ViewState["SelFile"].ToString();
            }

            if (TPath.Contains(ddlTemplateList.SelectedValue.ToString()))
            {
                CreatPath = TPath.Replace(ddlTemplateList.SelectedValue.ToString(), "") + CreatPath;
            }
            else
            {
                CreatPath = TPath + CreatPath;
            }

            CreateFileFolder(CreatPath);



        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    public static bool FilePathHasInvalidChars(string path)
    {

        return (path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
    }

    private void CreateFileFolder(string FolderPath)
    {

        try
        {
            if (!Path.HasExtension(FolderPath))
            {


                lblError.Text = string.Empty;

                if (rdbChoice.SelectedValue.ToString() == "0")
                {
                    if (!Directory.Exists(FolderPath + "/" + txtCreate.Text))
                    {
                        Directory.CreateDirectory(FolderPath + "/" + txtCreate.Text);
                    }
                }
                if (rdbChoice.SelectedValue.ToString() == "1")
                {
                    StreamWriter objStreamWriter =
                       new StreamWriter(FolderPath + "/" + txtCreate.Text + "." + ddlExt.SelectedItem.ToString());
                    objStreamWriter.Close();
                }


                gdvTemplateFileManager.DataSource = GetFiles(ViewState["SelFile"].ToString());
                gdvTemplateFileManager.DataBind();
                txtCreate.Text = string.Empty;
            }
            else
            {
                lblError.Text = "It's not a valid path";
            }
        }

        catch (Exception)
        {

            throw;
        }



    }

    public bool CheckExtension(string Extension)
    {
        return (CommonHelper.Contains(SystemSetting.ALLOWED_EXTENSIONS, Extension));

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        try
        {
            string APath = Utils.GetTemplatePath(ddlTemplateList.SelectedValue.ToString());
            string CreatPath = string.Empty;
            string Extension = Path.GetExtension(fupFile.FileName);

            if (ViewState["SelFile"].ToString() != null)
            {
                CreatPath = ViewState["SelFile"].ToString();
            }

            if (APath.Contains(ddlTemplateList.SelectedValue.ToString()))
            {
                CreatPath = APath.Replace(ddlTemplateList.SelectedValue.ToString(), "") + CreatPath;
            }
            else
            {
                CreatPath = APath + CreatPath;
            }
            if (CheckExtension(Extension))
            {
                if (fupFile.PostedFile.ContentType != "")
                {

                    string filename = fupFile.FileName.ToString();
                    fupFile.SaveAs(CreatPath + "/" + filename);
                    lblError.Text = string.Empty;

                }
            }
            if (!CheckExtension(Extension))
            {
                {
                    lblError.Text = "Upload Valid File";
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //protected void btnBack_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        txtEditor.Visible = false;
    //        btnSave.Visible = false;
    //        imgEditor.Visible = false;

    //        divBreadCrum.Visible = true;
    //        divSelectTemplate.Visible = true;
    //        divLstFile.Visible = true;
    //        divFileUploader.Visible = true;
    //        tblCreateFileFolder.Visible = true;

    //        string filename  = ViewState["SelFile"].ToString();
    //        string File = Path.GetFileName(filename);
    //        ViewState["SelFile"] = filename.Replace("/"+File, "");

    //        BuildBreadCrumb();

    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    protected void gdvTemplateFileManager_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = e.Row.Cells[0].FindControl("hlnkFilename") as LinkButton;

            if (Path.HasExtension(lb.Text))
            {
                string ext = Path.GetExtension(lb.Text);
                ext = ext.Substring(1, ext.Length - 1);
                ext = ext.Substring(0, 1).ToUpper() + ext.Substring(1, ext.Length - 1);
                lb.Attributes.Add("class", string.Format("sf{0}", ext));
            }
            else
            {
                lb.Attributes.Add("class", "sfFolder");
            }
        }
    }
    public void Back()
    {
        try
        {
            string backPath = string.Empty;
            string currentPath = ViewState["SelFile"].ToString();
            if (currentPath.Contains("/"))
            {
                string seprater = "/";
                backPath = currentPath.Substring(0, currentPath.LastIndexOf(seprater));
            }
            else
            {
                backPath = currentPath;
            }
            txtEditor.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            imgEditor.Visible = false;


            divSelectTemplate.Visible = true;
            divLstFile.Visible = true;
            divFileUploader.Visible = true;
            tblCreateFileFolder.Visible = true;
            lblCreate.Visible = true;


            ViewState["SelFile"] = backPath;

            gdvTemplateFileManager.PageIndex = 0;
            gdvTemplateFileManager.DataSource = GetFiles(backPath);
            gdvTemplateFileManager.DataBind();


            rptBreadCrum.DataSource = BreadCumlist(backPath);
            rptBreadCrum.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void btnImgBack_Click(object sender, EventArgs e)
    {


        try
        {
            Back();
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Back();
        }
        catch (Exception)
        {

            throw;
        }
    }
}






