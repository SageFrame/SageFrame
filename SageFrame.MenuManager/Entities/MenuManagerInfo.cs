#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace SageFrame.MenuManager
{
   public class MenuManagerInfo
    {
        public int MenuID { get; set; }
        public int MenuItemID { get; set; }
        public string MenuName { get; set; }
        public bool IsDefault { get; set; }
       

        public string MenuTypeStyle { get; set; }
        public string MenuHeaderText { get; set; }
        public bool ShowImage { get; set; }
        public bool Showtext { get; set; }



        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public int PortalID { get; set; }
        public int UserModuleID { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }
        public string DisplayMode { get; set; }
        public string TopMenuSubType { get; set; }
        public string SubTitleLevel { get; set; }
        public string SelectedMenu { get; set; }

        public int PageID { get; set; }
        public string MenuType { get; set; }
        public int PageOrder { get; set; }
        public string PageName { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public string LevelPageName { get; set; }
        public int ChildCount { get; set; }
        public string SEOName { get; set; }
        public string TabPath { get; set; }
        public string SubText { get; set; }
       
        public bool IsVisible { get; set; }
        public bool ShowInMenu { get; set; }

        public string LinkType { get; set; }
        public string Title { get; set; }
        public string LinkURL { get; set; }
        public string ImageIcon { get; set; }
        public string Caption { get; set; }
        public string HtmlContent { get; set; }
        public string MenuLevel { get; set; }
        public string MenuOrder { get; set; }
        public string Mode { get; set; }
        public string URL { get; set; }
        public bool PreservePageOrder { get; set; }
        public int MainParent { get; set; }

        public string SideMenuType { get; set; }

        public string CultureCode { get; set; }

        public MenuManagerInfo() { }

        public MenuManagerInfo(int _PageID, int _PageOrder, string _PageName, int _ParentID, int _Level, string _LevelPageName, string _SEOName, string _TabPath, bool _IsVisible, bool _ShowInMenu)
        {
            this.PageID = _PageID;
            this.PageOrder = _PageOrder;
            this.PageName = _PageName;
            this.ParentID = _ParentID;
            this.Level = _Level;
            this.LevelPageName = _LevelPageName;
            this.SEOName = _SEOName;
            this.TabPath = _TabPath;
            this.IsVisible = _IsVisible;
            this.ShowInMenu = _ShowInMenu;
        }

        //SiteMap
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime AddedOn { get; set; }
        public string ChangeFreq { get; set; }


    }
}
