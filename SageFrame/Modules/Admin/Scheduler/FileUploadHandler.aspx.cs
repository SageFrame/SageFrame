#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Hosting;
using SageFrame.Scheduler;
#endregion 

public partial class Modules_Scheduler_FileUploadHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string s = HttpContext.Current.Request.Form["fileUpload"] as string;
        if (!string.IsNullOrEmpty(s))
        {
            string strFileName = Path.GetFileName(HttpContext.Current.Request.Files[0].FileName);
            string strExtension = Path.GetExtension(HttpContext.Current.Request.Files[0].FileName).ToLower();
            string strBaseLocation = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "bin\\"); //HttpContext.Current.Server.MapPath("~/bin/");
            if (!Directory.Exists(strBaseLocation))
            {
                Directory.CreateDirectory(strBaseLocation);
            }
            string strSaveLocation = strBaseLocation + strFileName;
            HttpContext.Current.Request.Files[0].SaveAs(strSaveLocation);
            //strSaveLocation = strSaveLocation.Replace(HttpContext.Current.Server.MapPath("~/"), "");
            //strSaveLocation = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "bin\\"); //strSaveLocation.Replace("\\", "/");
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Write("({ 'Message': '" + strSaveLocation + "' })");
            HttpContext.Current.Response.End();
        }
    }
}
