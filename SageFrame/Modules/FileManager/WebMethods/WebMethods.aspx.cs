using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using SageFrame.Localization;
using System.Data;
using SageFrame.Web.Utilities;
using System.Text;
using System.IO;
using System.Net;
using SageFrame.FileManager;
using RegisterModule;
using System.Collections;
using SageFrame.Web;
using SageFrame.Framework;
using System.Web.Caching;

[ScriptService]
public partial class Modules_FileManager_js_WebMethods : System.Web.UI.Page
{

    public static FileManagerBase fb = new FileManagerBase();
    #region WebMethods
    [WebMethod(true)]
    public static string GetFileList(string filePath, int folderId, int UserID, int IsSort, int UserModuleID, int CurrentPage, int PageSize)
    {

        List<string> lstPermissionKeys = FileMangerDataProvider.GetPermissionKeys(folderId, UserID, UserModuleID, "superuser");
        StringBuilder sb = new StringBuilder();
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(filePath);
        List<Folder> lstFolders = new List<Folder>();

        if (!CacheHelper.Get("FileManagerFolders", out lstFolders))
        {
            lstFolders = FileManagerController.GetFolders();
            CacheHelper.Add(lstFolders, "FileManagerFolders");
        }


        List<ATTFile> lstFiles = new List<ATTFile>();

        List<FileCacheInfo> lstCache = new List<FileCacheInfo>();


        if (!CacheHelper.Get("FileManagerFileList", out lstCache))//if the cache list does not exist,then create on
        {
            try
            {

                lstFiles = FileManagerController.GetFiles(folderId);
                List<FileCacheInfo> lstFCI = new List<FileCacheInfo>();
                FileCacheInfo cacheObj = new FileCacheInfo();
                cacheObj.FolderID = folderId;
                cacheObj.LSTFiles = lstFiles;
                lstFCI.Add(cacheObj);
                CacheHelper.Add(lstFCI, "FileManagerFileList");
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }

        }
        else //if the cache list exists
        {
            int cacheIndex = lstCache.FindIndex(
                    delegate(FileCacheInfo obj)
                    {
                        return (obj.FolderID == folderId);
                    }
                );
            if (cacheIndex > -1)
            {
                lstFiles = lstCache[cacheIndex].LSTFiles;
            }
            else
            {
                try
                {
                    lstFiles = FileManagerController.GetFiles(folderId);
                    List<FileCacheInfo> lstFCI = lstCache;
                    FileCacheInfo cacheObj = new FileCacheInfo();
                    cacheObj.FolderID = folderId;
                    cacheObj.LSTFiles = lstFiles;
                    lstFCI.Add(cacheObj);
                    CacheHelper.Add(lstFCI, "FileManagerFileList");
                }
                catch (Exception ex)
                {

                    fb.ProcessException(ex);
                }
            }
        }


        if (IsSort == 1)
        {
            SortList(ref lstFiles);
        }
        if (lstFiles.Count > 0)
            lstFiles = lstFiles.GetRange(GetStartRange(CurrentPage, PageSize), GetEndRange(CurrentPage, PageSize, lstFiles.Count));

        ///Get the dictionary of images used in buttons
        Dictionary<string, string> dictImages = GetImages();

        sb.Append("<div class='sfGridwrapper'><table  width='100%' cellspacing='0' cellpadding='0' class=\"jqueryFileTree\" id=\"fileList\">\n");
        if (lstFiles.Count > 0)
        {
            sb.Append("<tr><th><span class='selectAll'><input type='checkbox' id='chkSelectAll'/></span></th><th><span class='fileName'>FileName<img src=" + dictImages["Sort"].ToString() + "></span></th><th><span class='fileInfo'>FileInfo</span></th><th class='sfEdit'></th><th class='sfEdit'></th><th class='sfEdit'></th></tr>");
        }
        if (lstFiles.Count == 0)
        {
            sb.Append("<div class='sfEmptyrow'>No Files</div>");
        }
        string downloadPath = FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), GetRelativePath("Modules/FileManager/DownloadHandler.ashx?")));
        string test = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
        string urlPath = GetUrlPath(filePath);
        string absolutePath = FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filePath));

        string ext = "";
        bool IsZip = false;
        bool IsImg = false;

        ///For Users with View and Write Permissions 
        if (((lstPermissionKeys.Contains("BROWSE") && lstPermissionKeys.Contains("VIEW")) && lstPermissionKeys.Contains("EDIT")) || lstPermissionKeys.Contains("EDIT"))
        {
            int index = 0;
            foreach (ATTFile fi in lstFiles)
            {
                if (fi.Extension.Length > 1)
                    ext = fi.Extension.Substring(1).ToLower();
                if (ext == "zip")
                    IsZip = true;
                if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
                    IsImg = true;
                string checkId = "chk_" + fi.FileId;
                if (fi.StorageLocation != (int)StorageLocation.SECURED_DATABASE_SYSTEM)
                {
                    switch (fi.StorageLocation)
                    {
                        case (int)StorageLocation.SECURED_FILE_SYSTEM:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName + ".resources")))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(IsZip, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "edit", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }

                            }
                            break;
                        case (int)StorageLocation.STANDARD:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName)))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(IsZip, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "edit", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }
                            }
                            break;
                    }

                }
                else if (fi.StorageLocation == (int)StorageLocation.SECURED_DATABASE_SYSTEM)
                {
                    try
                    {
                        FileManagerHelper.ConstructHTMLString(IsZip, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "edit", dictImages, index);
                    }
                    catch (Exception ex)
                    {

                        fb.ProcessException(ex);
                    }


                }
                index++;

            }
        }
        ///For users with only browse permission
        else if (((lstPermissionKeys.Contains("BROWSE") && !lstPermissionKeys.Contains("VIEW")) && !lstPermissionKeys.Contains("EDIT")))
        {
            int index = 0;
            foreach (ATTFile fi in lstFiles)
            {
                if (fi.Extension.Length > 1)
                    ext = fi.Extension.Substring(1).ToLower();
                if (ext == "zip")
                    IsZip = true;
                if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
                    IsImg = true;
                string checkId = "chk_" + fi.FileId;

                if (fi.StorageLocation != (int)StorageLocation.SECURED_DATABASE_SYSTEM)
                {
                    switch (fi.StorageLocation)
                    {
                        case (int)StorageLocation.SECURED_FILE_SYSTEM:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName + ".resources")))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "browse", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }
                            }
                            break;
                        case (int)StorageLocation.STANDARD:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName)))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "browse", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }
                            }
                            break;
                    }

                }
                else
                {
                    try
                    {
                        FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "browse", dictImages, index);
                    }
                    catch (Exception ex)
                    {

                        fb.ProcessException(ex);
                    }

                }
                index++;
            }

        }
        else if (((lstPermissionKeys.Contains("VIEW")) && !lstPermissionKeys.Contains("EDIT")))
        {
            int index = 0;
            foreach (ATTFile fi in lstFiles)
            {
                if (fi.Extension.Length > 1)
                    ext = fi.Extension.Substring(1).ToLower();
                if (ext == "zip")
                    IsZip = true;
                if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
                    IsImg = true;
                string checkId = "chk_" + fi.FileId;
                if (fi.StorageLocation != (int)StorageLocation.SECURED_DATABASE_SYSTEM)
                {
                    switch (fi.StorageLocation)
                    {
                        case (int)StorageLocation.SECURED_FILE_SYSTEM:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName + ".resources")))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "view", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }
                            }
                            break;
                        case (int)StorageLocation.STANDARD:
                            if (File.Exists(Path.Combine(absolutePath, fi.FileName)))
                            {
                                try
                                {
                                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "view", dictImages, index);
                                }
                                catch (Exception ex)
                                {

                                    fb.ProcessException(ex);
                                }
                            }
                            break;
                    }

                }
                else
                {
                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(urlPath, fi.FileName), Path.Combine(absolutePath, fi.FileName), downloadPath, checkId, folderId, fi, ref sb, "view", dictImages, index);

                }
                index++;
            }
        }
        sb.Append("</table></div>");
        sb.Append("<div id='divBottomControl'>");
        sb.Append("</div>");


        return sb.ToString();

    }

    [WebMethod(true)]
    public static string SearchFiles(string SearchQuery, int UserModuleID, string UserName, int CurrentPage, int PageSize)
    {

        StringBuilder sb = new StringBuilder();
        List<ATTFile> lstFiles = FileManagerController.SearchFiles(SearchQuery);
        Dictionary<string, string> dictImages = GetImages();

        List<string> lstPermissions = FileManagerController.GetModulePermission(UserModuleID, UserName);
        int UserPermissionKey = lstPermissions.Contains("EDIT") ? 1 : 0;

        if (lstFiles.Count > 0)
            lstFiles = lstFiles.GetRange(GetStartRange(CurrentPage, PageSize), GetEndRange(CurrentPage, PageSize, lstFiles.Count));


        sb.Append("<div class='sfGridwrapper'><table  width='100%' cellspacing='0' cellpadding='0' class=\"jqueryFileTree\" id=\"fileList\">\n");
        if (lstFiles.Count > 0)
        {
            sb.Append("<tr><th><span class='selectAll'><input type='checkbox' id='chkSelectAll'/></span></th><th><span class='fileName'>FileName<img src=" + dictImages["Sort"].ToString() + "></span></th><th><span class='fileInfo'>FileInfo</span></th><th class='sfEdit'></th><th class='sfEdit'></th><th class='sfEdit'></th></tr>");
        }
        if (lstFiles.Count == 0)
        {
            sb.Append("<div class='sfEmptyrow'>No Files</div>");
        }
        string downloadPath = FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), GetRelativePath("Modules/FileManager/DownloadHandler.ashx?")));



        if (UserPermissionKey == 1)
        {
            int index = 0;
            foreach (ATTFile fi in lstFiles)
            {
                string ext = "";
                bool IsZip = false;
                bool IsImg = false;
                if (fi.Extension.Length > 1)
                    ext = fi.Extension.Substring(1).ToLower();
                if (ext == "zip")
                    IsZip = true;
                if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
                    IsImg = true;
                string checkId = "chk_" + fi.FileId;
                try
                {
                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(GetUrlPath(fi.Folder), fi.FileName), Path.Combine(GetAbsolutePath(fi.Folder), fi.FileName), downloadPath, checkId, 0, fi, ref sb, "edit", dictImages, index);

                }
                catch (Exception ex)
                {

                    fb.ProcessException(ex);
                }
                index++;
            }
        }
        else
        {
            int index = 0;
            foreach (ATTFile fi in lstFiles)
            {
                string ext = "";
                bool IsZip = false;
                bool IsImg = false;
                if (fi.Extension.Length > 1)
                    ext = fi.Extension.Substring(1).ToLower();
                if (ext == "zip")
                    IsZip = true;
                if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
                    IsImg = true;
                string checkId = "chk_" + fi.FileId;
                try
                {
                    FileManagerHelper.ConstructHTMLString(false, IsImg, fi.StorageLocation, ext, Path.Combine(GetUrlPath(fi.Folder), fi.FileName), Path.Combine(GetAbsolutePath(fi.Folder), fi.FileName), downloadPath, checkId, 0, fi, ref sb, "view", dictImages, index);
                }
                catch (Exception ex)
                {

                    fb.ProcessException(ex);
                }
                index++;
            }
        }
        sb.Append("</table>");
        sb.Append("<div id='divPagerNav'></div>");
        sb.Append("</div>");


        return sb.ToString();

    }

    [WebMethod()]
    public static string DeleteFile(string filePath, int folderId, int fileId)
    {
        string message = "";
        filePath = GetAbsolutePath(filePath);
        List<Folder> lstFolder = FileManagerController.GetFolders();
        int folderType = 0;
        int index = lstFolder.FindIndex(
                delegate(Folder obj)
                {
                    return (obj.FolderId == folderId);
                }
            );
        if (index > -1)
        {
            folderType = lstFolder[index].StorageLocation;
        }
        if (filePath.EndsWith("/"))
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            if (di.Exists)
            {
                try
                {
                    di.Delete();
                    FileManagerController.DeleteFileFolder(folderId, 0);
                    message = "Folder Deleted Successfully";

                }
                catch (Exception ex)
                {

                    fb.ProcessException(ex);
                    message = "Folder Cannot be deleted";
                }

            }
        }
        else
        {
            if (folderType == (int)StorageLocation.SECURED_FILE_SYSTEM)
            {
                filePath += ".resources";
            }
            if (folderType == (int)StorageLocation.SECURED_DATABASE_SYSTEM)
            {
                FileManagerController.DeleteFileFolder(0, fileId);
                message = "File deleted successfully";
            }
            FileInfo file = new FileInfo(filePath);
            // Checking if file exists
            if (file.Exists)
            {
                ///Reset the file attribute before deleting
                try
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    file.Delete();
                    FileManagerController.DeleteFileFolder(0, fileId);
                    message = "File deleted successfully";
                }
                catch (Exception ex)
                {

                    fb.ProcessException(ex);
                    message = "File could be deleted";
                }


            }
        }
        CacheHelper.Clear("FileManagerFileList");
        CacheHelper.Clear("FileManagerFolders");
        return message;
    }

    [WebMethod]
    public static void DeleteRootFolder(int FolderID)
    {
        FileManagerController.DeleteRootFolder(FolderID);
    }

    [WebMethod]
    public static void CreateFolder(int FolderID, string filePath, string folderName, int fileType)
    {
        string absolutePath = FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filePath));
        DirectoryInfo dir = new DirectoryInfo(absolutePath);
        if (!dir.Exists)
        {
            dir.Create();
            Folder folder = new Folder();
            folder.PortalId = fb.GetPortalID;
            folder.ParentID = FolderID;
            folder.FolderPath = filePath;
            folder.StorageLocation = fileType;
            folder.UniqueId = Guid.NewGuid();
            folder.VersionGuid = Guid.NewGuid();
            folder.IsActive = 1;
            folder.AddedBy = fb.GetUsername;
            try
            {
                FileManagerController.AddFolder(folder);
                CacheHelper.Clear("FileManagerFolders");
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }


        }
    }

    [WebMethod]
    public static void AddRootFolder(string FolderName)
    {
        string absolutePath = FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), FolderName));
        DirectoryInfo dir = new DirectoryInfo(absolutePath);
        if (dir.Exists)
        {
            dir.Create();
            Folder folder = new Folder();
            folder.PortalId = fb.GetPortalID;
            folder.FolderPath = FolderName;
            folder.StorageLocation = 0;
            folder.UniqueId = Guid.NewGuid();
            folder.VersionGuid = Guid.NewGuid();
            folder.IsActive = 1;
            folder.AddedBy = fb.GetUsername;
            FileManagerController.AddRootFolder(folder);
            CacheHelper.Clear("FileManagerFolders");

        }
    }

    [WebMethod]
    public static List<Folder> GetRootFolders()
    {
        return (FileManagerController.GetRootFolders());
    }

    [WebMethod()]
    public static void SetFilePath(string filePath, int folderId)
    {
        HttpContext.Current.Session["Path"] = filePath;
        HttpContext.Current.Session["FolderID"] = folderId;
    }

    [WebMethod()]
    public static void UpdateFile(int fileId, int folderId, string fileName, string filePath, string attrString)
    {

        filePath = GetAbsolutePath(filePath);
        List<Folder> lstFolder = FileManagerController.GetFolders();
        int folderType = 0;
        int index = lstFolder.FindIndex(
                delegate(Folder obj)
                {
                    return (obj.FolderId == folderId);
                }
            );
        if (index > -1)
        {
            folderType = lstFolder[index].StorageLocation;
        }
        string newFileName = fileName;
        if (folderType == 1)
        {
            filePath += ".resources";
            newFileName += ".resources";
        }
        try
        {
            FileInfo file = new FileInfo(filePath);
            /// Checking if file exists
            if (file.Exists)
            {
                ///get the folder path
                filePath = filePath.Substring(0, filePath.LastIndexOf("/") + 1);
                filePath = filePath + newFileName;
                file.MoveTo(filePath);
                FileManagerController.UpdateFile(fileId, fileName);
                FileManagerHelper.SetFileAttributes(filePath, attrString);
                CacheHelper.Clear("FileManagerFileList");

            }
        }
        catch (Exception ex)
        {

            fb.ProcessException(ex);
        }



    }

    [WebMethod()]
    public static void CopyFile(int fileId, string filePath, int folderId, int toFolderId, string fromPath, string toPath)
    {

        string fullFilePath = GetAbsolutePath(filePath);
        string fullFromPath = GetAbsolutePath(fromPath);
        string fullToPath = GetAbsolutePath(toPath);
        List<Folder> lstFolder = FileManagerController.GetFolders();
        int folderType1 = 0;
        int folderType2 = 0;
        int index1 = lstFolder.FindIndex(
                delegate(Folder obj)
                {
                    return (obj.FolderId == folderId);
                }
            );
        if (index1 > -1)
        {
            folderType1 = lstFolder[index1].StorageLocation;
        }

        int index2 = lstFolder.FindIndex(
               delegate(Folder obj)
               {
                   return (obj.FolderId == toFolderId);
               }
           );
        if (index2 > -1)
        {
            folderType2 = lstFolder[index2].StorageLocation;
        }

        string copyKey = folderType1.ToString() + folderType2.ToString();
        try
        {
            switch (copyKey)
            {
                case "00":///normal folder type to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.NORMALTONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "01":///normal to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.NORMALTOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "02":///normal to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.NORMALTODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "10":///secure to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.SECURETONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "11":///secure to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.NORMALTOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "12":///secure to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.SECURETODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "20":///database to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.DATABASETONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "21":///database to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.DATABASETOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "22":///database to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.COPY, (int)TransferMode.DATABASETODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
            }
            CacheHelper.Clear("FileManagerFileList");
        }
        catch (Exception ex)
        {

            fb.ProcessException(ex);
        }


    }

    [WebMethod()]
    public static void MoveFile(int fileId, string filePath, int folderId, int toFolderId, string fromPath, string toPath)
    {
        string fullFilePath = GetAbsolutePath(filePath);
        string fullFromPath = GetAbsolutePath(fromPath);
        string fullToPath = GetAbsolutePath(toPath);

        List<Folder> lstFolder = FileManagerController.GetFolders();
        int folderType1 = 0;
        int folderType2 = 0;
        int index1 = lstFolder.FindIndex(
                delegate(Folder obj)
                {
                    return (obj.FolderId == folderId);
                }
            );
        if (index1 > -1)
        {
            folderType1 = lstFolder[index1].StorageLocation;
        }

        int index2 = lstFolder.FindIndex(
               delegate(Folder obj)
               {
                   return (obj.FolderId == toFolderId);
               }
           );
        if (index2 > -1)
        {
            folderType2 = lstFolder[index2].StorageLocation;
        }

        string moveKey = folderType1.ToString() + folderType2.ToString();
        try
        {
            switch (moveKey)
            {
                case "00":///normal folder type to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.NORMALTONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "01":///normal to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.NORMALTOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "02":///normal to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.SECURETODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "10":///secure to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.SECURETONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "11":///secure to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.SECURETOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "12":///secure to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.SECURETODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "20":///database to normal
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.DATABASETONORMAL, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "21":///database to secure
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.DATABASETOSECURE, fullFilePath, fullFromPath, fullToPath);
                    break;
                case "22":///database to database
                    FileManagerHelper.TransferFile(filePath, fileId, toFolderId, toPath, (int)Action.MOVE, (int)TransferMode.DATABASETODATABASE, fullFilePath, fullFromPath, fullToPath);
                    break;
            }
            CacheHelper.Clear("FileManagerFileList");
        }
        catch (Exception ex)
        {

            fb.ProcessException(ex);
        }


    }

    [WebMethod]
    public static List<Roles> GetAllRoles()
    {
        List<Roles> lstRoles = PermissionHelper.GetAllRoles(1, true, "superuser");
        List<Roles> lstNewRoles = new List<Roles>();
        foreach (Roles r in lstRoles)
        {

            if (Regex.Replace(r.RoleName.ToLower(), @"\s", "") == "superuser")
            {
                lstNewRoles.Insert(0, r);
            }
            else if (Regex.Replace(r.RoleName.ToLower(), @"\s", "") == "siteadmin")
            {
                lstNewRoles.Insert(1, r);
            }
            else
            {

                lstNewRoles.Add(r);
            }

        }
        return lstNewRoles;
    }

    [WebMethod]
    public static void SetFolderPermission(int FolderID, int UserID, int IsActive, string AddedBy, List<Permission> lstPermission)
    {
        FileManagerController.DeleteExistingPermissions(FolderID);
        foreach (Permission objPer in lstPermission)
        {
            try
            {
                if (objPer.UserID != 0)
                {
                    objPer.RoleID = Guid.Empty;
                }
                FileManagerController.SetFolderPermission(FolderID, objPer.PermissionKey, objPer.UserID, objPer.RoleID, IsActive, AddedBy);
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }
        }

    }

    [WebMethod]
    public static List<FolderPermission> GetFolderPermissions(int FolderID)
    {
        return (FileManagerController.GetFolderPermissions(FolderID));
    }

    [WebMethod]
    public static int ValidateUser(string userName)
    {
        int UserID = FileManagerController.GetUserID(userName);
        return UserID;
    }

    [WebMethod]
    public static List<FolderPermission> GetUserListForFolder(int FolderID)
    {
        return (FileManagerController.GetUserListForFolder(FolderID));
    }

    [WebMethod]
    public static string GetPermissionKeys(int FolderID, int UserID, int UserModuleID, string UserName)
    {
        List<string> lstPermission = FileManagerController.GetPermissionKeys(FolderID, UserID, UserModuleID, UserName);
        string keyString = string.Join("-", lstPermission.ToArray());
        return keyString;
    }

    [WebMethod]
    public static string UnzipFiles(string FilePath, int FolderID, int UserModuleID)
    {
        StringBuilder sb = new StringBuilder();
        string absolutePath = GetAbsolutePath(FilePath);
        FileInfo file = new FileInfo(absolutePath);
        string folderName = file.Name;
        string newFolderPath = FileManagerHelper.GetFilePathWithoutExtension(absolutePath);
        DirectoryInfo dir = new DirectoryInfo(newFolderPath);
        if (!dir.Exists)
        {
            string path = "";
            FileManagerHelper.UnZipFiles(absolutePath, newFolderPath, ref path, SageFrame.Core.RegisterModule.Common.Password, false, UserModuleID, fb.GetPortalID);
            Folder folder = new Folder();
            folder.PortalId = fb.GetPortalID;
            folder.ParentID = FolderID;
            folder.FolderPath = FileManagerHelper.ReplaceBackSlash(FileManagerHelper.GetFilePathWithoutExtension(FilePath));
            folder.StorageLocation = 0;
            folder.UniqueId = Guid.NewGuid();
            folder.VersionGuid = Guid.NewGuid();
            folder.IsActive = 1;
            folder.IsRoot = false;
            folder.AddedBy = fb.GetUsername;
            try
            {
                int folderID = FileManagerController.AddFolderReturnFolderID(folder);
                RecurseThroughDirectory(dir, folderID, UserModuleID, ref sb);
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);

            }
       
        }
        CacheHelper.Clear("FileManagerFileList");
        CacheHelper.Clear("FileManagerFolders");
        return sb.ToString();
        
    }



    [WebMethod]
    public static string GetExtensions(int UserModuleID, int PortalID)
    {
        string extension = "";
        SageFrameConfig config = new SageFrameConfig();
        extension = config.GetSettingsByKey(SageFrameSettingKeys.FileExtensions);
        return extension;
    }


    [WebMethod]
    public static void Synchronize(int UserModuleID)
    {
        try
        {
            SynchronizeFiles.UserName = fb.GetUsername;
            SynchronizeFiles.PortalID = fb.GetPortalID;
            SynchronizeFiles.extensions = "jpg,zip,txt,doc,docx,tif,css,js,jpeg,png";
            SynchronizeFiles.absolutePath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();
            SynchronizeFiles.lstFolders = FileManagerController.GetAllFolders();
            SynchronizeFiles.F2DSync();
            SynchronizeFiles.D2FSync();

        }
        catch (Exception ex)
        {
            fb.ProcessException(ex);
        }
        finally
        {
            CacheHelper.Clear("FileManagerFolders");
            CacheHelper.Clear("FileManagerFileList");
        }
    }
    #endregion

    #region pagermethods
    [WebMethod]
    public static int GetCount(int FolderID)
    {
        List<ATTFile> lstFiles = FileManagerController.GetFiles(FolderID);
        return lstFiles.Count;
    }

    [WebMethod(true)]
    public static int GetSearchCount(string SearchQuery, int UserModuleID, string UserName)
    {

        List<ATTFile> lstFiles = FileManagerController.SearchFiles(SearchQuery);
        return lstFiles.Count;
    }

    public static int GetStartRange(int CurrentPage, int PageSize)
    {
        int startIndex = PageSize * (CurrentPage - 1);
        return startIndex;
    }

    public static int GetEndRange(int CurrentPage, int PageSize, int rowCount)
    {
        int endRange = PageSize;
        int startIndex = GetStartRange(CurrentPage, PageSize);
        if (startIndex + PageSize > rowCount)
        {
            endRange = rowCount - startIndex;
        }
        return endRange;
    }
    #endregion

    #region HelperMethods
    public static void SortList(ref List<ATTFile> lstFiles)
    {
        if (HttpContext.Current.Session != null)
            if (HttpContext.Current.Session["SortDir"] == null || (string) HttpContext.Current.Session["SortDir"] == "asc")
            {
                lstFiles.Sort(
                    delegate(ATTFile f1, ATTFile f2)
                        {
                            return f1.FileName.CompareTo(f2.FileName);
                        }

                    );
                HttpContext.Current.Session["SortDir"] = "desc";
            }
            else
            {
                lstFiles.Sort(
                    delegate(ATTFile f1, ATTFile f2)
                        {
                            return f2.FileName.CompareTo(f1.FileName);
                        }

                    );
                HttpContext.Current.Session["SortDir"] = "asc";
            }
    }

    public static Dictionary<string, string> GetImages()
    {
        Dictionary<string, string> dictImageList = new Dictionary<string, string>();

        dictImageList.Add("Delete", GetRelativePath("Modules/FileManager/images/delete.png"));
        dictImageList.Add("Upload", GetRelativePath("/Modules/FileManager/images/btnupload.png"));
        dictImageList.Add("Edit", GetRelativePath("Modules/FileManager/images/edit.png"));
        dictImageList.Add("Preview", GetRelativePath("Modules/FileManager/images/img_preview.png"));
        dictImageList.Add("Extract", GetRelativePath("Modules/FileManager/images/extract.png"));
        dictImageList.Add("Sort", GetRelativePath("Modules/FileManager/images/sort.png"));

        return dictImageList;
    }
    protected static string GetRelativePath(string filePath)
    {
        return (FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.ApplicationPath.ToString(), filePath)));
    }
    public static string RecurseThroughDirectory(DirectoryInfo dir, int folderId, int UserModuleID, ref StringBuilder sb)
    {

        foreach (FileInfo file in dir.GetFiles())
        {
            ATTFile obj = new ATTFile();
            obj.PortalId = fb.GetPortalID;
            obj.UniqueId = Guid.NewGuid();
            obj.VersionGuid = Guid.NewGuid();
            obj.FileName = file.Name;
            obj.Extension = file.Extension;
            obj.Size = int.Parse(file.Length.ToString());
            obj.ContentType = FileManagerHelper.ReturnExtension(file.Extension);
            obj.Folder = FileManagerHelper.ReplaceBackSlash(dir.FullName.Replace(HttpContext.Current.Request.PhysicalApplicationPath, ""));
            obj.FolderId = folderId;
            obj.IsActive = 1;
            obj.StorageLocation = 0;
            obj.AddedBy = fb.GetUsername;

            try
            {

                if (FileManagerHelper.CheckForValidExtensions(UserModuleID, file.Extension.Replace(".",""), fb.GetPortalID))
                {
                    FileManagerController.AddFile(obj);
                    sb.Append("File ").Append("Extraction completed successfully");
                }
                else
                {
                    sb.Append("File ").Append(file.Name).Append(" has invalid extension \n");
                }
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }

        }
        foreach (DirectoryInfo childDir in dir.GetDirectories())
        {
            Folder folder = new Folder();
            folder.PortalId = fb.GetPortalID;
            folder.ParentID = folderId;
            folder.FolderPath = FileManagerHelper.ReplaceBackSlash(childDir.FullName.Replace(HttpContext.Current.Request.PhysicalApplicationPath, ""));
            folder.StorageLocation = 0;
            folder.UniqueId = Guid.NewGuid();
            folder.VersionGuid = Guid.NewGuid();
            folder.IsActive = 1;
            folder.IsRoot = false;
            folder.AddedBy = fb.GetUsername;
            try
            {
                int FolderID = FileManagerController.AddFolderReturnFolderID(folder);
                RecurseThroughDirectory(childDir, FolderID, UserModuleID, ref sb);
            }
            catch (Exception ex)
            {

                fb.ProcessException(ex);
            }


        }
        return sb.ToString();
    }
    public static string GetAbsolutePath(string filepath)
    {
        return (FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filepath)));
    }
    public static string GetUrlPath(string path)
    {
        string relativePathInitial = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath + "/";
        return (FileManagerHelper.ReplaceBackSlash(Path.Combine(relativePathInitial, path)));

    }
    #endregion

    #region Classes and Enums
    public class Permission
    {
        public Guid RoleID { get; set; }
        public string PermissionKey { get; set; }
        public int UserID { get; set; }
        public Permission() { }
    }
    public enum Action
    {
        COPY = 1,
        MOVE = 2
    }
    public enum TransferMode
    {
        NORMALTONORMAL = 1,
        NORMALTOSECURE = 2,
        NORMALTODATABASE = 3,
        SECURETONORMAL = 4,
        SECURETOSECURE = 5,
        SECURETODATABASE = 6,
        DATABASETONORMAL = 7,
        DATABASETOSECURE = 8,
        DATABASETODATABASE = 9
    }
    #endregion

}

