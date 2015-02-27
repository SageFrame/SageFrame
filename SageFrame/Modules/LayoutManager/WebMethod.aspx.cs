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
using System.Web.Script.Services;
using System.Web.Services;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using SageFrame.Templating;
using SageFrame.Templating.xmlparser;
using SageFrame.FileManager;
using SageFrame.Common;
using SageFrame.Pages;


[ScriptService]
public partial class Modules_LayoutManager_WebMethod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string ReadXML(string filePath, string TemplateName)
    {
        try
        {
            string templatePath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string fileName = Path.GetFileName(filePath);
            filePath = filePath.ToLower().Equals("core") ? string.Format("{0}/Layouts/standard/All.xml", Utils.GetTemplatePath_Default("Default")) : string.Format("{0}/layouts/{1}.xml", templatePath, filePath);

            DataSet ds = new DataSet();
            ds.ReadXml(filePath);
            string s = ds.GetXml();
            return s;
        }
        catch (Exception)
        {

            return "Couldn't Read the XML file. Make sure it is a valid xml";
        }

    }

    [WebMethod]
    public static List<KeyValue> GetThemes(string TemplateName)
    {
        string themePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetThemePath_Default(TemplateName) : Utils.GetThemePath(TemplateName);
        DirectoryInfo dir = new DirectoryInfo(themePath);
        List<KeyValue> lstThemes = new List<KeyValue>();
        if (dir.Exists)
        {
            foreach (DirectoryInfo theme in dir.GetDirectories())
            {
                lstThemes.Add(new KeyValue(theme.Name, theme.FullName));
            }
        }
        return lstThemes;
    }

    [WebMethod]
    public static List<KeyValue> LoadPresets(string TemplateName)
    {
        string themePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        DirectoryInfo dir = new DirectoryInfo(themePath);
        List<KeyValue> lstPresets = new List<KeyValue>();
        if (dir.Exists)
        {
            foreach (FileInfo preset in dir.GetFiles("*.xml"))
            {
                if (!Utils.CompareStrings(preset.Name, TemplateConstants.PagePresetFile))
                {
                    lstPresets.Add(new KeyValue(preset.Name, preset.FullName));
                }
            }
        }
        return lstPresets;

    }
    [WebMethod]
    public static List<PresetInfo> LoadActivePresets(string TemplateName)
    {
        string presetPath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        List<PresetInfo> lstActivePresets = new List<PresetInfo>();
        string pagepreset = presetPath + "/" + TemplateConstants.PagePresetFile;
        if (File.Exists(pagepreset))
        {

            lstActivePresets = PresetHelper.ParsePreset(pagepreset, "pagepresets/page");
        }
        else
        {
            lstActivePresets.Add(PresetInfo.GetPresetPages("default", "*"));

        }
        return lstActivePresets;
    }

    [WebMethod]
    public static PresetInfo GetPresetDetails(string TemplateName,int PortalID)
    {
        string presetPath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        presetPath += "/" + "pagepreset.xml";
        PresetInfo objPreset = new PresetInfo();
        try
        {
             objPreset=PresetHelper.LoadPresetDetails(presetPath);

             List<PageEntity> lstMenu = PageController.GetMenuFront(PortalID, false);
             foreach (PageEntity obj in lstMenu)
             {
                 obj.ChildCount = lstMenu.Count(
                     delegate(PageEntity objMenu)
                     {
                         return (objMenu.ParentID == obj.PageID);
                     }
                     );
             }
             List<string> lstPages = new List<string>();
             List<KeyValue> lstLayout = new List<KeyValue>();
             foreach (KeyValue kvp in objPreset.lstLayouts)
             {
                 string[] arrPage = kvp.Value.Split(',');
                 List<string> lstNewPage=new List<string>();
                 foreach (string page in arrPage)
                 {
                     bool exists = lstMenu.Exists(
                            delegate(PageEntity obj)
                            {
                                return obj.PageName == page;
                            }
                         );
                     if (exists || page.ToLower() == "all")
                     {
                         lstNewPage.Add(page);                         
                     }
                 }
                 if (lstNewPage.Count > 0)
                 {
                     lstLayout.Add(new KeyValue(kvp.Key, string.Join(",", lstNewPage.ToArray())));
                 }
             }
             objPreset.lstLayouts = lstLayout;
             PresetHelper.WritePreset(presetPath, objPreset);

             return objPreset;
        }
        catch (Exception)
        {

            throw;
        }

    }

    [WebMethod]
    public static int SavePreset(string TemplateName, string ActiveTheme,string ActiveWidth,List<PresetKeyValue> lstLayouts)
    {
        List<KeyValue> lstLyts = new List<KeyValue>();
      
        foreach (PresetKeyValue kvp in lstLayouts)
        {
            lstLyts.Add(new KeyValue(kvp.Key, kvp.Value));           

        }
        PresetInfo PresetObj = new PresetInfo();
        PresetObj.ActiveTheme = ActiveTheme;
        PresetObj.ActiveWidth = ActiveWidth;
        PresetObj.lstLayouts = lstLyts;
        string presetPath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        string pagepreset = presetPath + "/" + TemplateConstants.PagePresetFile;
        presetPath += "/" + "pagepreset.xml";
        int presetstatus = 0;
        try
        {
            PresetHelper.WritePreset(presetPath, PresetObj);

            return presetstatus;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static void CreateLayoutControls(string TemplateName, string filePath)
    {

        string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string presetPath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        ModulePaneGenerator mg = new ModulePaneGenerator();
        XmlParser parser = new XmlParser();
        try
        {
            List<XmlTag> lstXmlTag = parser.GetXmlTags(filePath, "layout/section");
            List<XmlTag> lstWrappers = parser.GetXmlTags(filePath, "layout/wrappers");

            string html = mg.GenerateHTML(lstXmlTag, lstWrappers, 2);
            //html = Utils.FormatHtmlOutput(html);
            string controlclass = Path.GetFileNameWithoutExtension(filePath);
            string controlname = string.Format("{0}.ascx", controlclass);
            if (!File.Exists(templatePath + "/" + controlname))
            {
                FileStream fs = null;
                using (fs = File.Create(templatePath + "/" + controlname))
                {

                }

            }
            else
            {
                File.Delete(templatePath + "/" + controlname);
                FileStream fs = null;
                using (fs = File.Create(templatePath + "/" + controlname))
                {

                }
            }

            using (StreamWriter sw = new StreamWriter(templatePath + "/" + controlname))
            {
                sw.Write("<%@ Control Language=\"C#\" ClassName=" + controlclass + " %>");
                sw.Write(Environment.NewLine);
                sw.Write(html);
            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    [WebMethod]
    public static List<KeyValue> LoadLayout(string TemplateName)
    {
        string filePath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        DirectoryInfo dir = new DirectoryInfo(filePath + "/layouts");
        List<KeyValue> lstLayouts = new List<KeyValue>();
        foreach (FileInfo layout in dir.GetFiles())
        {
            lstLayouts.Add(new KeyValue(Path.GetFileNameWithoutExtension(layout.Name), layout.FullName));
        }
        lstLayouts.Insert(0, new KeyValue("Core", "Core"));
        return lstLayouts;
    }

    [WebMethod]
    public static List<SectionInfo> LoadBlockTypes()
    {
        DirectoryInfo dir = new DirectoryInfo("E://DotNetProjects//sftemplating//SageFrame//Modules//LayoutManager//Sections");
        List<SectionInfo> lstSections = new List<SectionInfo>();
        foreach (FileInfo file in dir.GetFiles())
        {
            SectionInfo obj = new SectionInfo();
            obj.SectionName = file.Name;
            lstSections.Add(obj);
        }
        return lstSections;
    }

    [WebMethod]
    public static string ReadBlockHTML(string fileName)
    {
        HTMLBuilder hb = new HTMLBuilder();
        fileName = "E://DotNetProjects//sftemplating" + fileName;
        string html = hb.ReadHTML(fileName);
        return html;


    }

    [WebMethod]
    public static List<TemplateInfo> GetTemplateList(int PortalID)
    {
        string templates = Utils.GetAbsolutePath(TemplateConstants.TemplateDirectory);
        DirectoryInfo dir = new DirectoryInfo(templates);
        List<TemplateInfo> lstTemplates = new List<TemplateInfo>();
        string activeTemplate = TemplateController.GetActiveTemplate(PortalID).TemplateName;
        if (activeTemplate.Length < 1) { activeTemplate = "Default"; }
        foreach (DirectoryInfo temp in dir.GetDirectories())
        {
            TemplateInfo tempObj = new TemplateInfo(temp.Name, temp.FullName, GetThumbPath(temp.FullName, temp.Name, TemplateConstants.TemplateDirectory), false, false);
            if (temp.Name.ToLower().Replace(' ', '_').Equals(activeTemplate.ToLower()))
            {
                tempObj.IsActive = true;
            }
            lstTemplates.Add(tempObj);
        }
        bool IsDefaultActive = activeTemplate.ToLower().Equals("default") ? true : false;
        lstTemplates.Insert(0, new TemplateInfo("Default", "/Core/Template/", GetThumbPath(HttpContext.Current.Server.MapPath("~/Core/Template/"), "Template", "Core/"), IsDefaultActive, true));
        List<TemplateInfo> lstFinalTemplates = new List<TemplateInfo>();
        List<TemplateInfo> lstAppliedTemplates=new List<TemplateInfo>();
        try
        {
            lstAppliedTemplates= TemplateController.GetPortalTemplates();

        }
        catch (Exception)
        {
            
            throw;
        }
        foreach (TemplateInfo template in lstTemplates)
        {

            bool status = false;
            foreach (TemplateInfo templt in lstAppliedTemplates)
            {
                if (template.TemplateName.ToLower() == templt.TemplateName.ToLower() && templt.PortalID!=PortalID)
                {
                    status = true;
                    break;
                }

            }
            if (!status)
                template.IsApplied = false;
            else
                template.IsApplied = true;

        }


        return lstTemplates;
    }


    public static string GetThumbPath(string TemplatePath, string TemplateName, string RootFolder)
    {
        string thumbpath = HttpContext.Current.Request.ApplicationPath == "/" ? TemplateConstants.NoImagePath + TemplateConstants.NoImageImag : HttpContext.Current.Request.ApplicationPath + TemplateConstants.NoImagePath + TemplateConstants.NoImageImag;
        if (Directory.Exists(TemplatePath + TemplateConstants.ThumbPath))
        {
            DirectoryInfo dir = new DirectoryInfo(TemplatePath + TemplateConstants.ThumbPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (Utils.ValidateThumbImage(file))
                {
                    thumbpath = string.Format("{0}/{1}{2}{3}/{4}", HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath, RootFolder, TemplateName, TemplateConstants.ThumbPath, file.Name);
                    break;
                }
            }
        }
        return thumbpath;
    }


    [WebMethod]
    public static void ActivateTemplate(string TemplateName, int PortalID)
    {
        HttpContext.Current.Cache.Remove("SageFrameCss");
        HttpContext.Current.Cache.Remove("SageFrameJs");
        string optimized_path = HttpContext.Current.Server.MapPath(SageFrameConstants.OptimizedResourcePath);
        IOHelper.DeleteDirectoryFiles(optimized_path, ".js,.css");
        if (File.Exists(HttpContext.Current.Server.MapPath(SageFrameConstants.OptimizedCssMap)))
        {
            DeleteNodes(HttpContext.Current.Server.MapPath(SageFrameConstants.OptimizedCssMap), "resourcemaps/resourcemap");
        }
        if (File.Exists(HttpContext.Current.Server.MapPath(SageFrameConstants.OptimizedJsMap)))
        {
            DeleteNodes(HttpContext.Current.Server.MapPath(SageFrameConstants.OptimizedJsMap), "resourcemap/resourcemap");
        }

        TemplateController.ActivateTemplate(TemplateName, PortalID);
    }
    public static void DeleteNodes(string target_path, string nodeName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(target_path);
        XmlNode node = doc.SelectSingleNode("resourcemaps");
        node.RemoveAll();
        //XmlNodeList nodeList = node.ChildNodes;
        //var mapCount = nodeList.Count;
        //for (int i = 0; i < mapCount; i++)
        //{
        //    nodeList[i].ParentNode.RemoveChild(nodeList[i]);
        //}            
        doc.Save(target_path);
    }

    [WebMethod]
    public static TemplateInfo GetBasicSettings(string TemplateName)
    {
        XmlParser _parser = new XmlParser();
        string filePath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetTemplateInfoFilePath_Default(TemplateName) : Utils.GetTemplateInfoFilePath(TemplateName);
        TemplateInfo objTemp = new TemplateInfo();
        if (File.Exists(filePath))
        {
            List<XmlTag> lstTags = _parser.GetXmlTags(filePath, "template");
            objTemp = TemplateHelper.CreateTemplateObject(lstTags);
        }
        else
        {
            objTemp = TemplateHelper.CreateEmptyTemplateObject();
        }
        return objTemp;

    }

    [WebMethod]
    public static string GenerateWireFrame(string FilePath, string TemplateName)
    {
        try
        {
            List<XmlTag> lstXmlTags = new List<XmlTag>();
            XmlParser parser = new XmlParser();
            string templatePath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string filePath = FilePath.ToLower().Equals("core") ? string.Format("{0}/Layouts/standard/All.xml", Utils.GetTemplatePath_Default("Default")) : string.Format("{0}/layouts/{1}.xml", templatePath, FilePath);

            lstXmlTags = parser.GetXmlTags(filePath, "layout/section");
            List<XmlTag> lstWrappers = parser.GetXmlTags(filePath, "layout/wrappers");
            ModulePaneGenerator wg = new ModulePaneGenerator();
            return (wg.GenerateHTML(lstXmlTags, lstWrappers, 0));
        }
        catch (Exception)
        {

            return ("<div class='sfMessage sfErrormsg'>Invalid XML document</div>");
        }

    }

    [WebMethod]
    public static int UpdateLayout(string FilePath, string Xml, string TemplateName)
    {
        int status = 0;
        TemplateName = TemplateName.Trim();
        if (!Utils.ContainsXmlHeader(Xml))
        {
            Xml = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>{0}", Xml);
        }
        if (Decide.IsXmlInputValid(Xml))
        {
            string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            //string filePath = string.Format("{0}/layouts/{1}.xml",templatePath,FilePath);
            string filePath = FilePath.ToLower().Equals("core") ? string.Format("{0}/Layouts/standard/All.xml", Utils.GetTemplatePath_Default("Default")) : string.Format("{0}/layouts/{1}.xml", templatePath, FilePath);

            using (StreamWriter sw = new StreamWriter(filePath))
            {

                sw.Write(Xml);

            }
            CreateLayoutControls(TemplateName, filePath);
        }
        else
        {
            status = 1;
        }
        return status;

    }
    [WebMethod]
    public static int CreateLayout(string FilePath, string Xml, string TemplateName)
    {
        string templatePath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string filePath = templatePath + "/layouts/" + Utils.GetFileNameWithExtension(FilePath, "xml");
        int status = 0;
        try
        {
            if (Decide.IsXmlInputValid(Xml))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    if (!Utils.ContainsXmlHeader(Xml))
                    {
                        sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    }
                    sw.Write(Xml);
                }
                CreateLayoutControls(TemplateName.Trim(), filePath);
            }
            else
            {
                status = 1;
            }
            return status;

        }
        catch (Exception)
        {

            throw;
        }


    }


    [WebMethod]
    public static List<FileEntity> GetFiles(string TemplateName, string FolderPath)
    {
        string filePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        filePath = FolderPath != "" ? filePath + "/" + FolderPath : filePath;
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
    [WebMethod]
    public static string ReadFiles(string TemplateName, string FilePath)
    {
        XmlParser _parser = new XmlParser();
        string filePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        filePath = FilePath != "" ? filePath + "/" + FilePath : filePath;
        string html = XmlHelper.GetXMLString(filePath);
        return html;
    }

    [WebMethod]
    public static void DeleteTemplate(string TemplateName)
    {
        try
        {
            string target_dir = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            Utils.DeleteDirectory(target_dir);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        

    }
    [WebMethod]
    public static void DeleteTheme(string TemplateName, string ThemeName)
    {
        string target_dir = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string theme_dir = target_dir + "/Themes/" + ThemeName;
        Utils.DeleteDirectory(theme_dir);

    }
    [WebMethod]
    public static List<KeyValue> GetPreviewImages(string TemplateName)
    {
        string target_dir = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string imagePath = target_dir + "/screenshots/";
        List<KeyValue> lstImages = new List<KeyValue>();
        DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            string ext=Path.GetExtension(file.Name);
            if(ext==".jpg" || ext==".png" || ext==".gif")
            lstImages.Add(new KeyValue(file.Name, file.FullName));
        }
        return lstImages;
    }

    [WebMethod]
    public static void DeletePreset(string TemplateName, string Preset)
    {
        string presetPath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        string pagepreset = presetPath + "/" + TemplateConstants.PagePresetFile;
        string target_dir = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplateInfoFilePath_Default(TemplateName) : Utils.GetTemplateInfoFilePath(TemplateName);
        string preset_dir = target_dir + "/presets/" + Preset;
        Utils.DeleteFile(preset_dir);
        PresetHelper.DeletePresetFromPresetPages(Preset, pagepreset);
    }
    [WebMethod]
    public static void DeleteLayout(string TemplateName, string Layout)
    {
        TemplateName = Utils.CleanString(TemplateName);
        string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        string fileName = Path.GetFileName(Layout);
        Layout = string.Format("{0}/layouts/{1}.xml", templatePath, Layout);
        string controlfile = string.Format("{0}/{1}.ascx", templatePath, Path.GetFileNameWithoutExtension(Layout));
        Utils.DeleteFile(controlfile);
        Utils.DeleteFile(Layout);

    }

    [WebMethod]
    public static void CreateTemplate(string filepath, string FolderName)
    {
        try
        {
            if (filepath == "") filepath = "~/";
            string completePath = HttpContext.Current.Server.MapPath(filepath + "/Templates/" + FolderName);
            string path = HttpContext.Current.Server.MapPath(filepath);

            DirectoryInfo SrcDir = new DirectoryInfo(path + "/Core/Blank/");
            DirectoryInfo DisDir = new DirectoryInfo(path + "/Templates/" + FolderName);
            CopyDirectory(SrcDir, DisDir);

        }
        catch (Exception e)
        {

            throw e;
        }
    }

    [WebMethod]
    static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
    {
        if (!destination.Exists)
        {
            destination.Create();
        }

        FileInfo[] files = source.GetFiles();
        foreach (FileInfo file in files)
        {
            file.CopyTo(Path.Combine(destination.FullName, file.Name));
        }
        // Process subdirectories.
        DirectoryInfo[] dirs = source.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            // Get destination directory.
            string destinationDir = Path.Combine(destination.FullName, dir.Name);

            // Call CopyDirectory() recursively.
            CopyDirectory(dir, new DirectoryInfo(destinationDir));
        }
    }

   
    [WebMethod]
    public static Foldername CheckExistingTemplate(string filepath,string FolderName)
    {
        string fname = string.Empty;
        string TempFolder = HttpContext.Current.Server.MapPath(filepath + "/Templates/");
        DirectoryInfo dInfo = new DirectoryInfo(TempFolder);       
        Foldername info = new Foldername();
        foreach (DirectoryInfo obj in dInfo.GetDirectories())
        {         
            if (obj.Name.ToLower() == FolderName.ToLower())
            {
                info.Existfolder = obj.Name.ToLower();                
            }           
        }
        return (info) ;   
    }

   
    public class Foldername

    {
        public string Existfolder { get; set; }

        public Foldername() { }
    }

}
