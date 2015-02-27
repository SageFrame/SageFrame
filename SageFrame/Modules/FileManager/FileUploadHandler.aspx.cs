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
using System.IO;
using SageFrame.FileManager;
using SageFrame.Framework;

public partial class Modules_FileManager_FileUploadHandler : System.Web.UI.Page
{
    FileManagerBase fb=new FileManagerBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strFileName = Path.GetFileName(HttpContext.Current.Request.Files[0].FileName);
        string strExtension = Path.GetExtension(HttpContext.Current.Request.Files[0].FileName).ToLower() == "resources"
                                  ? Path.GetExtension(HttpContext.Current.Request.Files[0].FileName.Replace("resources","")).ToLower()
                                  : Path.GetExtension(HttpContext.Current.Request.Files[0].FileName).ToLower();
        
        string url = Request.Url.ToString();
        int folderId = int.Parse(Session["FolderID"].ToString());       
        string strBaseLocation = "";

        if(Session["Path"]!=null)
            strBaseLocation = Session["Path"].ToString();

        string absolutePath = GetAbsolutePath(strBaseLocation);
        if (!Directory.Exists(absolutePath))
        {
            Directory.CreateDirectory(absolutePath);
        }
       
        try
        {
            string strSaveLocation = absolutePath + strFileName;
            List<Folder> lstFolder = FileManagerController.GetFolders();
            int saveMode = 0;///the standard mode
            ///check the folder file system to decide what to do with the file  i.e. the saving mode of file
            int index = lstFolder.FindIndex(
                delegate(Folder fObj)
                {
                    return (fObj.FolderId == folderId);
                }
                );
            if (index > -1)
            {
                saveMode = lstFolder[index].StorageLocation;
            }
            switch (saveMode)
            {
                case 0:
                    if (!File.Exists(strSaveLocation))
                    {
                        HttpContext.Current.Request.Files[0].SaveAs(strSaveLocation);
                        File.SetAttributes(strSaveLocation, FileAttributes.Archive);
                        AddFileToDatabase(strFileName, strExtension, strBaseLocation, folderId, false, saveMode);
                    }
                    break;
                case 1:
                    if (!File.Exists(strSaveLocation))
                    {
                        HttpContext.Current.Request.Files[0].SaveAs(strSaveLocation + ".resources");
                        File.SetAttributes(strSaveLocation + ".resources", FileAttributes.Archive);
                        AddFileToDatabase(strFileName, strExtension, strBaseLocation, folderId, false, saveMode);
                    }
                    break;
                case 2:
                    if (!File.Exists(strSaveLocation))
                    {
                        HttpContext.Current.Request.Files[0].SaveAs(strSaveLocation);
                        AddFileToDatabase(strFileName, strExtension, strBaseLocation, folderId, true, saveMode);
                    }
                    break;
            }
            CacheHelper.Clear("FileManagerFileList");
          
        }
        catch (Exception ex)
        {
            fb.ProcessException(ex);
        }
    }
    public void AddFileToDatabase(string fileName, string extension, string folder, int folderId,bool isDatabase,int saveMode)
    {
        string newFileName = fileName;
        if (saveMode == 1)
        {
            newFileName = fileName + ".resources";
        }
        FileInfo file = new FileInfo(GetAbsolutePath(folder+newFileName));
        ATTFile obj = new ATTFile();
        obj.PortalId = fb.GetPortalID;
        obj.UniqueId = Guid.NewGuid();
        obj.VersionGuid = Guid.NewGuid();
        obj.FileName = fileName;
        obj.Extension = extension;
        obj.Size = int.Parse(file.Length.ToString());
        obj.ContentType = FileManagerHelper.ReturnExtension(extension);
        obj.Folder = folder;
        obj.FolderId = folderId;
        obj.IsActive = 1;
        obj.StorageLocation = saveMode;
        obj.AddedBy = fb.GetUsername;
        if(isDatabase)
        {
            byte[] _fileContent = FileManagerHelper.FileToByteArray(GetAbsolutePath(folder+fileName));
            obj.Content = _fileContent;
        }
            try
            {
                FileManagerController.AddFile(obj);
                if (saveMode == 2)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }
      
        }
    public static string GetAbsolutePath(string filepath)
    {
        return(FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filepath)));
    }
    
    
}
