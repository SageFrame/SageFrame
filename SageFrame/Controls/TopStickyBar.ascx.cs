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
using SageFrame.Common;
using SageFrame.Security;

public partial class Controls_TopStickyBar : BaseAdministrationUserControl
{
    public string appPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
       
        if (!IsPostBack)
        {
            BindThemes();
            BindLayouts();
            BindValues();

            hlnkDashboard.Visible = false;
            SageFrameConfig conf = new SageFrameConfig();
            string ExistingPortalShowProfileLink = conf.GetSettingsByKey(SageFrameSettingKeys.PortalShowProfileLink);
            if (ExistingPortalShowProfileLink == "1")
            {
                lnkAccount.NavigateUrl = GetProfileLink();
            }
            else
            {
                lnkAccount.Visible = false;
            }

        }
       
         RoleController _role = new RoleController();
        string[] roles = _role.GetRoleNames(GetUsername, GetPortalID).ToLower().Split(',');
        if (roles.Contains(SystemSetting.SUPER_ROLE[0].ToLower()) || roles.Contains(SystemSetting.SITEADMIN.ToLower()))
        {
            hlnkDashboard.Visible = true;
            hlnkDashboard.NavigateUrl = GetPortalAdminPage();
            cpanel.Visible = true;
        }
        else
        {
            cpanel.Visible = false;
        }

    }
   

    public void BindValues()
    {
        PresetInfo preset = GetPresetDetails;
        if (preset.ActiveTheme == "")
        {
            preset.ActiveTheme = "default";
        }
        ddlThemes.Items.FindByText(preset.ActiveTheme.ToLower()).Selected = true;
        if (preset.ActiveWidth == "")
        {
            preset.ActiveWidth = "Wide";
        }       
        ddlScreen.Items.FindByText(preset.ActiveWidth.ToLower()).Selected = true;
        string activeLayout = string.Empty;
        string pageName = Request.Url.ToString();
        SageFrameConfig sfConfig = new SageFrameConfig();
        pageName = Path.GetFileNameWithoutExtension(pageName);
        pageName = pageName.ToLower().Equals("default") ? sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) : pageName;   
        foreach(KeyValue kvp in preset.lstLayouts)
        {
            string[] arrLayouts = kvp.Value.Split(',');
            if(arrLayouts.Contains(pageName))
            {
                activeLayout = kvp.Key;
            }
        }
        if (activeLayout != "")
        {
            ddlLayout.Items.FindByText(string.Format("{0}.ascx", activeLayout.ToLower())).Selected = true;
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Cache.Remove("SageFrameCss");
        HttpContext.Current.Cache.Remove("SageFrameJs");
        string optimized_path = Server.MapPath(SageFrameConstants.OptimizedResourcePath);
        IOHelper.DeleteDirectoryFiles(optimized_path, ".js,.css");
        if (File.Exists(Server.MapPath(SageFrameConstants.OptimizedCssMap)))
        {
            XmlHelper.DeleteNodes(Server.MapPath(SageFrameConstants.OptimizedCssMap), "resourcemaps/resourcemap");
        }
        if (File.Exists(Server.MapPath(SageFrameConstants.OptimizedJsMap)))
        {
            XmlHelper.DeleteNodes(Server.MapPath(SageFrameConstants.OptimizedJsMap), "resourcemap/resourcemap");
        }

        PresetInfo preset = new PresetInfo();
        preset = GetPresetDetails;
        preset.ActiveTheme = ddlThemes.SelectedItem.ToString();
        preset.ActiveWidth = ddlScreen.SelectedItem.ToString();
        preset.ActiveLayout = Path.GetFileNameWithoutExtension(ddlLayout.SelectedItem.ToString());
        List<KeyValue> lstLayouts = preset.lstLayouts;

        string pageName = Request.Url.ToString();
        SageFrameConfig sfConfig = new SageFrameConfig();
        pageName = Path.GetFileNameWithoutExtension(pageName);
        pageName = pageName.ToLower().Equals("default") ? sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalDefaultPage) : pageName;   

     
        bool isNewLayout = false;
        foreach (KeyValue kvp in lstLayouts)
        {
            string[] pages = kvp.Value.Split(',');
            if (pages.Count() == 1 && pages.Contains(pageName))
            {
                kvp.Key = preset.ActiveLayout;
            }
            else if (pages.Count() > 1 && pages.Contains(pageName))
            {
                isNewLayout = true;
                List<string> lstnewpage=new List<string>();
                foreach (string page in pages)
                {
                    if (page.ToLower() != pageName.ToLower())
                    {
                        lstnewpage.Add(page);
                    }
                }
                kvp.Value = lstnewpage.ToString();
            }
        }
        if (isNewLayout)
        {
            lstLayouts.Add(new KeyValue(preset.ActiveLayout, pageName));
        }
        preset.lstLayouts = lstLayouts;
        string presetPath = Decide.IsTemplateDefault(TemplateName.Trim()) ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
        string pagepreset = presetPath + "/" + TemplateConstants.PagePresetFile;
        presetPath += "/" + "pagepreset.xml";

        PresetHelper.WritePreset(presetPath, preset);
        Response.Redirect(Request.Url.OriginalString);
    }

    public string GetPortalAdminPage()
    {
        string sageNavigateUrl = string.Empty;
        SageFrameConfig sfConfig = new SageFrameConfig();        
            if (GetPortalID > 1)
            {
                sageNavigateUrl = ResolveUrl(string.Format("~/portal/{0}/Admin/Admin.aspx",GetPortalSEOName));
            }
            else
            {
                sageNavigateUrl = ResolveUrl("~/Admin/Admin.aspx");
            }

            return sageNavigateUrl;
        

      
    }
    private string GetProfileLink()
    {
        string profileURL = "";
        SageFrameConfig sfConfig = new SageFrameConfig();

        string profilepage = sfConfig.GetSettingsByKey(SageFrameSettingKeys.PortalUserProfilePage);
        profilepage = profilepage.ToLower().Equals("user-profile") ? string.Format("/sf/{0}",profilepage) : string.Format("/{0}",profilepage);
            if (GetPortalID > 1)
            {
                profileURL = ResolveUrl("~/portal/" + GetPortalSEOName + profilepage + ".aspx");
            }
            else
            {
                profileURL = ResolveUrl("~"+profilepage+".aspx");
            }
       
        return profileURL;
    }

    public void BindThemes()
    {
        string themePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetThemePath_Default(TemplateName) : Utils.GetThemePath(TemplateName);
        List<KeyValue> lstThemes = new List<KeyValue>();
        if (Directory.Exists(themePath))
        {
            DirectoryInfo dir=new DirectoryInfo(themePath);
            foreach (DirectoryInfo theme in dir.GetDirectories())
            {
                lstThemes.Add(new KeyValue(theme.Name, theme.Name));
            }
        }
        lstThemes.Insert(0, new KeyValue("default", "default"));
        ddlThemes.DataSource = lstThemes;
        ddlThemes.DataTextField = "Key";
        ddlThemes.DataTextField = "Value";
        ddlThemes.DataBind();
    }
    public void BindLayouts()
    {
        string templatePath = Decide.IsTemplateDefault(TemplateName) ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
        List<KeyValue> lstLayouts = new List<KeyValue>();
        if (Directory.Exists(templatePath))
        {
            DirectoryInfo dir = new DirectoryInfo(templatePath);
            foreach (FileInfo layout in dir.GetFiles())
            {
                if (layout.Extension.Contains("ascx"))
                {
                    lstLayouts.Add(new KeyValue(layout.Name.ToLower(), layout.Name.ToLower()));
                }
            }
        }        
        ddlLayout.DataSource = lstLayouts;
        ddlLayout.DataTextField = "Key";
        ddlLayout.DataTextField = "Value";
        ddlLayout.DataBind();
    }
}
