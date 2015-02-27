using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SageFrame.Web;
using SageFrame.Templating;
using System.IO;
using System.Collections.Generic;
using RegisterModule;

public partial class Modules_LayoutManager_LayoutManager :BaseAdministrationUserControl
{
    public string appPath = "";
    public string UnexpectedEOF = "Unexpected EOF";
    public int PortalID = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeJs("LayoutManager", false, "/js/jquery.easy-confirm-dialog.js");
        IncludeJs("LayoutManager", "/Modules/LayoutManager/js/LayoutManager.js");
        IncludeJs("LayoutManager",false,"/js/jquery.dialogextend.js","/Editors/ckeditor/ckeditor.js", "/Editors/ckeditor/adapters/jquery.js");        
        IncludeJs("LayoutManager",false,"/Modules/LayoutManager/CodeMirror/codemirror.js");
        IncludeJs("LayoutManager", "/Modules/LayoutManager/CodeMirror/xml.js");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/codemirror.css");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/default.css");
        IncludeCss("LayoutManager", "/Modules/LayoutManager/CodeMirror/docs.css");

        IncludeCss("LayoutManager", "/Modules/LayoutManager/css/module.css");
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        PortalID = GetPortalID;
       
        if (!IsPostBack)
        {
            

            string modulePath = ResolveUrl(this.AppRelativeTemplateSourceDirectory);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "FileManagerGlobalVariable1", " var LayoutManagerPath='" + ResolveUrl(modulePath) + "';", true);
            
           
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (fupUploadTemp.HasFile && fupUploadTemp.PostedFile.FileName != string.Empty)
            {
                string fileName = fupUploadTemp.PostedFile.FileName;
                string cntType = fupUploadTemp.PostedFile.ContentType;
                if (fileName.Substring(fileName.Length - 3, 3).ToLower() == "zip")
                {
                    string path = HttpContext.Current.Server.MapPath("~/");
                    string temPath = SageFrame.Core.RegisterModule.Common.TemporaryFolder;
                    string destPath = Path.Combine(path, temPath);
                    string downloadPath = SageFrame.Core.RegisterModule.Common.TemporaryTemplateFolder;
                    string downloadDestPath = Path.Combine(path, downloadPath);
                    string templateName = ParseFileNameWithoutPath(fileName.Substring(0, fileName.Length - 4));
                    string templateFolderPath = path + "Templates\\" + templateName;
                    if (!Directory.Exists(templateFolderPath))
                    {
                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);

                        string filePath = destPath + "\\" + fupUploadTemp.FileName;
                        fupUploadTemp.SaveAs(filePath);
                        string ExtractedPath = string.Empty;
                        ZipUtil.UnZipFiles(filePath, destPath, ref ExtractedPath, SageFrame.Core.RegisterModule.Common.Password, SageFrame.Core.RegisterModule.Common.RemoveZipFile);
                        string[] dirs = Directory.GetDirectories(ExtractedPath);

                        if (!Directory.Exists(downloadDestPath))
                            Directory.CreateDirectory(downloadDestPath);
                        fupUploadTemp.SaveAs(downloadDestPath + "\\" + fupUploadTemp.FileName);

                        Directory.Move(ExtractedPath, templateFolderPath);
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("TemplateManagement", "TemplateInstallSuccessfully"), "", SageMessageType.Success);

                    }
                    else
                    {
                        ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("TemplateManagement", "TemplateAlreadyInstall"), "", SageMessageType.Error);
                    }
                }
                else
                {
                    ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("TemplateManagement", "InvalidTemplateZip"), "", SageMessageType.Alert);
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Equals(UnexpectedEOF, StringComparison.OrdinalIgnoreCase))
            {
                ShowMessage(SageMessageTitle.Notification.ToString(), GetSageMessage("TemplateManagement", "ZipFileIsCorrupt"), "", SageMessageType.Alert);

            }
            else
            {
                ProcessException(ex);
            }

        }

    }

    private string ParseFileNameWithoutPath(string path)
    {
        if (path != null && path != string.Empty)
        {
            char seperator = '\\';
            string[] file = path.Split(seperator);
            return file[file.Length - 1];
        }
        return string.Empty;
    }

   

   

   

   
}
