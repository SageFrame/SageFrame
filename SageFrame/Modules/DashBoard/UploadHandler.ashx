<%@ WebHandler Language="C#" Class="UploadHandler" %>
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Web;
using System.IO;


public class UploadHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        bool isValidFile = false;
        string validExtension = string.Empty;
        string retFilePath = string.Empty;
        string retMsg = "fail";
        string strTempfolder = "Modules/Dashboard/Icons/Temp/";
        string strBaseLocation = "Modules/Dashboard/Icons/";
        string filename = string.Empty;
        HttpRequest Request = HttpContext.Current.Request;
        string[] allowExtensions = new string[] { "jpg", "doc", "JPEG", "gif", "bmp" };

        if (Request.Files != null)
        {
            HttpFileCollection files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.ContentLength > 0)
                {
                    if (validExtension.Length > 0)
                    {
                        if (IsValidExtension(allowExtensions, GetExtension(file.FileName)))
                        {
                            isValidFile = true;
                            retMsg = "Valid file Extension";
                        }
                        else
                        {
                            retMsg = "Not valid file Extension";
                        }
                    }
                    else
                    {
                        isValidFile = true;
                    }
                    if (isValidFile)
                    {
                        filename = System.IO.Path.GetFileName(file.FileName.Replace(" ", "_"));
                        retFilePath = strBaseLocation;
                        strTempfolder = HttpContext.Current.Server.MapPath("~/" + strTempfolder);
                        strBaseLocation = HttpContext.Current.Server.MapPath("~/" + strBaseLocation);
                        string srcRoot = strTempfolder + filename;
                        string desRoot = strBaseLocation + filename;
                        if (Directory.Exists(strTempfolder))
                        {
                            Directory.Delete(strTempfolder, true);
                        }
                        if (!Directory.Exists(strTempfolder))
                        {
                            Directory.CreateDirectory(strTempfolder);
                        }
                        if (!Directory.Exists(strBaseLocation))
                        {
                            Directory.CreateDirectory(strBaseLocation);
                        }

                        string filePath = strTempfolder + filename;
                        retFilePath = retFilePath + filename;
                        file.SaveAs(filePath);

                        retMsg = "filePath=" + retFilePath;
                        SageFrame.Web.PictureManager.CreateThmnail(srcRoot, 25, desRoot);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(retMsg);

                    }
                }

            }
        }
    }
   
    
    private string GetExtension(string fileName)
    {
        int index = fileName.LastIndexOf('.') ;
        string ext = fileName.Substring(index + 1, (fileName.Length - index)-1);
        return ext;
    }

    public bool IsValidExtension(string[] array,string ext) {
    
      bool found =false;    
    foreach (string s in array)    
    {
        if (s.Equals(ext))        
        {            
            found =true;            
            break;        
        }    
    } 
        return found; 
    
    }
    private bool callback()
    {
        return true;
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
    
  
 }   