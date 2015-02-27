using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.FileManager;
using System.IO;

public partial class Modules_FileManager_js_Script : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dir;

        HttpContext c = HttpContext.Current;
        if(c!=null)
        {
            List<Folder> lstRootFolders = FileManagerController.GetActiveRootFolders();
        if (c.Request.Form["dir"] == null || c.Request.Form["dir"].Length <= 0)
            dir = "/";
        else
            dir = c.Server.UrlDecode(c.Request.Form["dir"]);

        string rootPath = c.Request.PhysicalApplicationPath.ToString(); 

        
        c.Response.Write("<ul class=\"jqueryFileTree\" style=\"display: none;\">\n");
       
        if (dir.Equals("/"))
        {
            foreach (Folder folder in lstRootFolders)
            {

                if (Directory.Exists(Path.Combine(rootPath,folder.FolderPath)))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(folder.FolderPath);                  
                    switch (folder.StorageLocation)
                    {
                        case 0:
                            Response.Write("\t<li class=\"directory collapsed\"><a id=" + folder.FolderId + " href=\"#\" rel=\"" + folder.FolderPath + "/\">" + dirInfo.Name + "</a></li>\n");
                            break;
                        case 1:
                            Response.Write("\t<li class=\"locked collapsed\"><a id=" + folder.FolderId + " href=\"#\" rel=\"" + folder.FolderPath + "/\">" + dirInfo.Name + "</a></li>\n");
                            break;
                        case 2:
                            Response.Write("\t<li class=\"database collapsed\"><a id=" + folder.FolderId + " href=\"#\" rel=\"" + folder.FolderPath + "/\">" + dirInfo.Name + "</a></li>\n");
                            break;
                    }
                }

            }
        }
        else 
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FileManagerHelper.ReplaceBackSlash(Path.Combine(rootPath,dir)));
            List<Folder> lstFolders = new List<Folder>();
            if (!CacheHelper.Get("FileManagerFolders", out lstFolders))
            {
                lstFolders = FileManagerController.GetFolders();
                CacheHelper.Add(lstFolders, "FileManagerFolders");
            }      
            

            foreach (System.IO.DirectoryInfo di_child in di.GetDirectories())
            {
                string fullPath = di_child.FullName.Replace('\\', '/');
                int index = lstFolders.FindIndex(
                    delegate(Folder obj)
                    {
                        return (FileManagerHelper.ReplaceBackSlash(Path.Combine(rootPath,obj.FolderPath)) == fullPath);
                    }
                    );

                if (index > -1)
                {
                    switch (lstFolders[index].StorageLocation)
                    {
                        case 0:
                            c.Response.Write("\t<li class=\"directory collapsed sfChild\"><a id=" + lstFolders[index].FolderId + " href=\"#\" rel=\"" + dir + di_child.Name + "/\">" + di_child.Name + "</a></li>\n");
                            break;
                        case 1:
                            c.Response.Write("\t<li class=\"locked collapsed\"><a id=" + lstFolders[index].FolderId + " href=\"#\" rel=\"" + dir + di_child.Name + "/\">" + di_child.Name + "</a></li>\n");
                            break;
                        case 2:
                            c.Response.Write("\t<li class=\"database collapsed\"><a id=" + lstFolders[index].FolderId + " href=\"#\" rel=\"" + dir + di_child.Name + "/\">" + di_child.Name + "</a></li>\n");
                            break;
                    }
                }
            }
          
        }
       
        c.Response.Write("</ul>");
		}
		
    
    }
}
