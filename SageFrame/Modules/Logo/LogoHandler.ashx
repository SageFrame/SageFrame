<%@ WebHandler Language="C#" Class="LogoHandler" %>

using System;
using System.Web;
using System.IO;

public class LogoHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        Random rnd = new Random();
        string retMsg = string.Empty;
        Int32 retStatus = 1;
        string strFileName = Path.GetFileName(context.Request.Files[0].FileName);
        string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
        strFileName = strFileName.Substring(0, strFileName.Length - strExtension.Length);
        strFileName = strFileName + '_' + rnd.Next(111111, 999999).ToString() + strExtension;
        int strSize = HttpContext.Current.Request.Files[0].ContentLength;
        string strBaseLocation = HttpContext.Current.Server.MapPath("~/Modules/Logo/image/");

        if (!Directory.Exists(strBaseLocation))
        {
            Directory.CreateDirectory(strBaseLocation);
        }

        string strSaveLocation = strBaseLocation + strFileName;
        HttpContext.Current.Request.Files[0].SaveAs(strSaveLocation);
        retMsg = "Modules/Logo/image/" + strFileName;
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write("({ 'Status': '" + retStatus + "','Message': '" + retMsg + "' })");
        HttpContext.Current.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}