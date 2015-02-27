<%@ WebHandler Language="C#" Class="DownloadHandler" %>

using System;
using System.Web;
using System.IO;
using SageFrame.Web;
using System.Collections.Generic;
using System.Web.Security;
using SageFrame.FileManager;

public class DownloadHandler : IHttpHandler {



    public void ProcessRequest(HttpContext context)
    {        
        int FileID = int.Parse(context.Request.QueryString["FileID"].ToString());
        int FolderID = int.Parse(context.Request.QueryString["FolderID"].ToString());

        string filepath = string.Empty;
        List<ATTFile> lstFile = new List<ATTFile>();
        
          List<ATTFile> fileDetails=new List<ATTFile>();
           fileDetails.Add(FileManagerController.GetFileDetails(FileID));
           lstFile=FolderID==0?fileDetails:FileManagerController.GetFiles(FolderID);
        
        int index = lstFile.FindIndex(
                delegate(ATTFile obj)
                {
                    return (obj.FileId == FileID);
                }
            );
        
        if (index > -1)       {          
       
        switch (lstFile[index].StorageLocation)
        {
            case 0:
                filepath = lstFile[index].Folder;
                filepath += "/" + lstFile[index].FileName;
                DownloadFile(context, filepath);
                break;
            case 1:
                filepath = lstFile[index].Folder;
                filepath += "/" + lstFile[index].FileName;               
                DownloadSecureFile(context,filepath);               
                break;
            case 2:
                DownloadFileFromDatabase(context, lstFile[index].Content, lstFile[index].FileName);
                break;
        }
        }   

           
       
    }
    public static string GetAbsolutePath(string filepath)
    {
        return (FileManagerHelper.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filepath)));
    }

    public void DownloadFile(HttpContext context,string filepath)
    {
        
        FileInfo file = new FileInfo(GetAbsolutePath(filepath));
        string actualFileName = file.Name.Substring(0, file.Name.LastIndexOf("."));
        if (file.Exists)
        {
            context.Response.ClearContent();
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name.Replace(' ', '_'));
            context.Response.ContentType = FileManagerHelper.ReturnExtension(Path.GetExtension(file.Name));
            context.Response.TransmitFile(file.FullName);
            context.Response.End();
        }
    }
    public void DownloadSecureFile(HttpContext context, string filepath)
    {

        FileInfo file = new FileInfo(GetAbsolutePath(filepath + ".resources"));
       
        if (file.Exists)
        {
            context.Response.ClearContent();
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name.Replace(' ', '_').Replace(".resources",""));
            context.Response.ContentType = FileManagerHelper.ReturnExtension(Path.GetExtension(filepath));
            context.Response.TransmitFile(file.FullName);
            context.Response.End();
        }
    }

    public void DownloadFileFromDatabase(HttpContext context,byte[] fileData,string fileName)
    {
            context.Response.ClearContent();
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" +fileName);
            BinaryWriter bw = new BinaryWriter(context.Response.OutputStream);
            bw.Write(fileData);
            bw.Close();
            context.Response.ContentType = FileManagerHelper.ReturnExtension(Path.GetExtension(fileName));
            context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}