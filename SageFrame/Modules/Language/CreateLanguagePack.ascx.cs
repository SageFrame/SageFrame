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
using System.Web.Configuration;
using System.Reflection;
using SageFrame.Web;
using SageFrame.Core;
using SageFrame.Localization;
using System.Text;
using System.IO;
using System.Threading;


public partial class Localization_CreateLanguagePack : BaseAdministrationUserControl
{
    public event ImageClickEventHandler CancelButtonClick;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetLocale();
            this.txtResourcePackName.Text = "";
            this.lblDownLoadPathLabel.Visible = false;
        }
        this.divModuleDetails.Visible = false;

    }
    public void GetLocale()
    {
        List<string> localeList = new List<string>();
        localeList = GetLocaleList("~/Modules", ".resx", localeList);
        localeList = GetLocaleList("~/Modules", ".xml", localeList);
        localeList = GetLocaleList("~/XMLMessage", ".xml", localeList);

        List<string> localeListWihoutDuplicates = localeList.Distinct().ToList();
        List<Language> lstAllCultures = LocaleController.GetCultures();
        List<Language> lstNewCulture = new List<Language>();
        foreach (string locale in localeListWihoutDuplicates)
        {
            int index = lstAllCultures.FindIndex(delegate(Language obj) { return (obj.LanguageCode == locale); });
            if(index>-1)
                lstNewCulture.Add(lstAllCultures[index]);
        }
        ddlResourceLocale.DataSource = lstNewCulture;
        ddlResourceLocale.DataTextField = "LanguageName";
        ddlResourceLocale.DataValueField = "LanguageCode";
        ddlResourceLocale.DataBind();
    }
    public List<string> GetLocaleList(string filePath, string extension, List<string> localeList)
    {
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Server.MapPath(filePath));
        System.IO.FileInfo[] files = di.GetFiles("*" + extension);
        foreach (System.IO.FileInfo fi in files)
        {
            string code = GetLanguageCode(fi.Name.Replace(extension, ""));
            if (code != "")
                localeList.Add(code);
        }
        return(DirectoryWalkThroughLocalList(di, filePath, extension, localeList));        
    }
    public List<string> DirectoryWalkThroughLocalList(System.IO.DirectoryInfo di, string filePath, string extension, List<string> localeList)
    {
        System.IO.FileInfo[] files = di.GetFiles("*" + extension);
        foreach (System.IO.FileInfo fi in files)
        {
            string code = GetLanguageCode(fi.Name.Replace(extension, ""));
            if (code != "")
                localeList.Add(code);
        }
        foreach (System.IO.DirectoryInfo di_child in di.GetDirectories())
        {
            localeList = DirectoryWalkThroughLocalList(di_child, filePath, extension, localeList);
        }
        return localeList;
    }
    public string GetLanguageCode(string filename)
    {
        bool isAspx = false;
        string langCode = "";
        string aspxString = filename.Substring(filename.LastIndexOf('.') + 1);
        isAspx = aspxString.Equals("aspx") || aspxString.Equals("ascx") || !aspxString.Contains("-") ? true : false;
        if (!isAspx)
           langCode = aspxString;
        return langCode;
    }
    protected void imbCreatePackage_Click(object sender, ImageClickEventArgs e)
    {
        string FullFilePath = "";
        List<FileDetails> selectedFiles = new List<FileDetails>();
        List<FileDetails> selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedFiles, "~/Modules", "*.resx");
        selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedResxFiles, "~/XMLMessage", "*.xml");
        selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedResxFiles, "~/Modules", "*.xml");
        string filepath = Server.MapPath("~/Install/Language");
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
        ///Get the application version
        SageFrame.Application.Application app = new SageFrame.Application.Application();
        app.FormatVersion(app.Version, true);

        StringBuilder fileNameSB = new StringBuilder();
        fileNameSB.Append("ResourcePack.");
        fileNameSB.Append(txtResourcePackName.Text);
        fileNameSB.Append(".");
        fileNameSB.Append(app.Version.ToString());
        fileNameSB.Append(".");
        fileNameSB.Append(ddlResourceLocale.SelectedValue.ToString());
        string fileName = fileNameSB.ToString();

        List<FileDetails> newFileList = new List<FileDetails>();
        switch (rbResourcePackType.SelectedIndex)
        {
            case 0:
                newFileList = GetCoreModuleResources(selectedResxFiles); ;
                break;
            case 1:
                GetSelectedModules(ref newFileList,selectedResxFiles);
                break;
            case 2:
                newFileList = selectedResxFiles;
                break;
        }
        try
        {
            PackageWriterBase.WriteManifest(filepath, "manifest", newFileList, GetPackageInfo());
            PackageWriterBase.WriteZipFile(newFileList, filepath + @"/" + fileName + ".zip", filepath + @"\manifest.sfe", "manifest.sfe");
            FullFilePath = string.Format("{0}/{1}.zip", filepath, fileName);
            ViewState["FilePath"] = FullFilePath;
            if (File.Exists(FullFilePath))
            {
                Response.ClearContent();
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".zip");
                Response.ContentType = "application/octet-stream";
                

                //Response.ClearContent();
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".zip");
                //Response.ContentType = "application/octet-stream";
                //Response.TransmitFile(FullFilePath);
                ////Response.End();
                ////ApplicationInstance.CompleteRequest();
                //ApplicationInstance.CompleteRequest();


                using (Stream input = File.OpenRead(FullFilePath))
                {
                    byte[] buffer = new byte[4096];
                    int count = input.Read(buffer, 0, buffer.Length);
                    while (count > 0)
                    {
                        Response.OutputStream.Write(buffer, 0, count);
                        count = input.Read(buffer, 0, buffer.Length);
                    }
                }
                ShowMessage("", GetSageMessage("LanguageModule", "PackageCreatedSuccessfully"), "", SageMessageType.Success);
                File.Delete(FullFilePath);

                

            }
            if (rbResourcePackType.SelectedIndex == 1)
            {
                divModuleDetails.Visible = true;

            }

        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
        finally
        {
            Response.End();


        }
        
    }
  
    protected void GetSelectedModules(ref List<FileDetails> newFileList, List<FileDetails> selectedResxFiles)
    {
        foreach (RepeaterItem item in rptrModules.Items)
        {
            if (((CheckBox)item.FindControl("chkSelect")).Checked)
            {
                int index = selectedResxFiles.FindIndex(
                    delegate(FileDetails fd)
                    {
                        return (fd.FolderInfo.Contains(((Label)item.FindControl("lblModuleName")).Text));
                    }
                    );
                if (index > -1)
                    newFileList.Add(selectedResxFiles[index]);
            }
        }
    }
    protected List<FileDetails> GetCoreModuleResources(List<FileDetails> lstFullResourceList)
    {
        List<ModuleInfo> lstCoreModules = LocalizationSqlDataProvider.GetCoreModules();
        List<FileDetails> lstCoreModuleResx = new List<FileDetails>();        
        foreach (FileDetails objFD in lstFullResourceList)
        {
            string fileName=objFD.FileName.Substring(0,objFD.FileName.IndexOf("."));
             if (lstCoreModules.Exists(
                delegate(ModuleInfo obj)
                    { 
                        return fileName.Equals(obj.ModuleName);
                    }
                    )
                )
            {
                lstCoreModuleResx.Add(objFD);
            }
        }
        return lstCoreModuleResx;        
    }
    public List<FileDetails> GetSelectedLanguageFiles(string cultureCode, List<FileDetails> localeList, string filePath, string extension)
    {
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Server.MapPath(filePath));
        System.IO.FileInfo[] basefiles = di.GetFiles(extension);
        foreach (System.IO.FileInfo fi in basefiles)
        {
            FileDetails fd = new FileDetails();
            fd.FileName = fi.Name;
            fd.FilePath = fi.FullName;
            fd.FolderInfo = di.Name;
            localeList.Add(fd);
        }
        return(DirectoryWalkThrough(di, localeList, cultureCode, extension, filePath.Replace("~/", "")));
    }

    public List<FileDetails> DirectoryWalkThrough(System.IO.DirectoryInfo di, List<FileDetails> localeList, string cultureCode, string extension, string filePath)
    {
        System.IO.FileInfo[] basefiles = di.GetFiles(extension);
        foreach (System.IO.FileInfo fi in basefiles)
        {
            FileDetails fd = new FileDetails();
            fd.FileName = fi.Name;
            fd.FilePath = fi.FullName;

            int indexStart = fi.FullName.IndexOf(filePath);
            int indexEnd = fi.FullName.LastIndexOf("\\");

            fd.FolderInfo = fi.FullName.Substring(indexStart, indexEnd - indexStart);
            localeList.Add(fd);
        }
        foreach (System.IO.DirectoryInfo di_child in di.GetDirectories())
        {
            localeList = DirectoryWalkThrough(di_child, localeList, cultureCode, extension, filePath);
        }

        List<FileDetails> selectedResxList = new List<FileDetails>();
        foreach (FileDetails obj in localeList)
        {
            if (obj.FileName.Contains(cultureCode))
            {
                selectedResxList.Add(new FileDetails(obj.FileName, obj.FilePath, obj.FolderInfo));
            }
        }
        return selectedResxList;
    }
    public PackageInfo GetPackageInfo()
    {
        PackageInfo package = new PackageInfo();
        package = XMLHelper.GetPackageManifest(Server.MapPath("~/")+"Modules\\Language\\Manifest\\ManifestData.xml");
        package.PackageName = this.txtResourcePackName.Text + "." + "1.0.0.1";
        package.PackageType = "Core";
        package.FriendlyName = this.txtResourcePackName.Text;
        package.OwnerName = GetUsername;        
        package.Version = "1.0.0.1";     
        return package;
    }
    protected void rbResourcePackType_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandlePackageTypeChanges();
    }
    public void HandlePackageTypeChanges()
    {
        switch (rbResourcePackType.SelectedIndex)
        {
            case 0:
                txtResourcePackName.Text = "Core";
                this.lblDownLoadPathLabel.Visible = false;
                this.lnkBtnDownloadPackage.Text = "";
                break;
            case 1:
                divModuleDetails.Visible = true;
                txtResourcePackName.Text = "Module";
                ListAvailableModules();
                this.lblDownLoadPathLabel.Visible = false;
                this.lnkBtnDownloadPackage.Text = "";
                break;
            case 2:
                txtResourcePackName.Text = "Full";
                this.lblDownLoadPathLabel.Visible = false;
                this.lnkBtnDownloadPackage.Text = "";
                break;

        }
    }
    public void ListAvailableModules()
    {
        List<ModuleInfo> lstModules = new List<ModuleInfo>();
        for (int i = 0; i < 10; i++)
        {
            ModuleInfo module = new ModuleInfo();
            module.ModuleName = "Test Module" + i.ToString();
            lstModules.Add(module);
        }

        List<FileDetails> selectedFiles = new List<FileDetails>();
        List<FileDetails> selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedFiles, "~/Modules", "*.resx");
        selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedResxFiles, "~/Modules", "*.xml");
        selectedResxFiles = GetSelectedLanguageFiles(this.ddlResourceLocale.SelectedValue.ToString(), selectedResxFiles, "~/XMLMessage", "*.xml");
        List<Module> ModuleList = new List<Module>();
        foreach (FileDetails fd in selectedResxFiles)
        {
            string modulename = "";
            if (fd.FolderInfo.Contains("Modules\\Admin"))
            {
                modulename = fd.FolderInfo.Replace("Modules\\Admin\\", "");
                int index = modulename.IndexOf("\\");
                modulename = modulename.Substring(0, index);

            }
            else if (fd.FolderInfo.Contains("Modules"))
            {
                modulename = fd.FolderInfo.Replace("Modules\\", "");
                int index = modulename.IndexOf("\\");
                modulename = modulename.Substring(0, index);

            }
            else if (fd.FilePath.Contains("XMLMessage"))
            {
                modulename = "XMLMessage";
            }
            bool isContains = ModuleList.Exists(
                delegate(Module obj)
                {
                    return (obj.ModuleName == modulename);
                }
                );
            if (!isContains && modulename != "")
                ModuleList.Add(new Module(modulename));
        }

        rptrModules.DataSource = ModuleList;
        rptrModules.DataBind();
    }
    public class Module    {
        public string ModuleName { get; set; }
        public string FolderName { get; set; }
        public Module() { }
        public Module(string modulename)
        {
            this.ModuleName = modulename;
        }
    }
    protected void ddlResourceLocale_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandlePackageTypeChanges();
    }
    protected void ClearControls()
    {
        this.ddlResourceLocale.SelectedIndex = 0;
        this.txtResourcePackName.Text = "";
        this.rbResourcePackType.SelectedIndex = 0;
    }
    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        CancelButtonClick(sender, e);
        
    }

    protected void lnkBtnDownloadPackage_Click(object sender, EventArgs e)
    {
        string fileName = ViewState["FilePath"].ToString();

        FileInfo file = new FileInfo(fileName);
        string actualFileName = file.Name.Substring(0, file.Name.LastIndexOf("."));
        if (file.Exists)
        {
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name.Replace(' ', '_'));
            Response.ContentType = "application/zip";
            Response.TransmitFile(file.FullName);
            //Response.End();
        }
    }
}
