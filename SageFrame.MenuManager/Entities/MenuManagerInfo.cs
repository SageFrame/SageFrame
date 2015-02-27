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
using System.Text;

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
