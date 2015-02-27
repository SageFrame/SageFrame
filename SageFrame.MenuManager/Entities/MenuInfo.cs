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

namespace SageFrame.SageMenu
{
    public class MenuInfo
    {
        public int PageID { get; set; }
        public int PageOrder { get; set; }
        public string PageName { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public string LevelPageName { get; set; }
        public int ChildCount { get; set; }
        public string SEOName { get; set; }
        public string TabPath { get; set; }
        public bool IsVisible { get; set; }
        public bool ShowInMenu { get; set; }
        public string IconFile { get; set; }
        public string Title { get; set; }
        public List<MenuInfo> LISTMenu { get; set; }
        public MenuInfo() { }
        public MenuInfo(int _PageID, int _PageOrder, string _PageName, int _ParentID, int _Level,string _LevelPageName,string _SEOName,string _TabPath,bool _IsVisible,bool _ShowInMenu)
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
        public MenuInfo(int _PageID, int _PageOrder, string _PageName, int _ParentID, int _Level, string _LevelPageName, string _SEOName, string _TabPath, bool _IsVisible, bool _ShowInMenu, string _IconFile)
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
            this.IconFile = _IconFile;

        }

        public MenuInfo(int _PageID, int _ParentID, string _PageName, int _Level,string _TabPath)
        {
            this.PageID = _PageID;
            this.ParentID = _ParentID;
            this.PageName = _PageName;
            this.Level = _Level;
            this.TabPath = _TabPath;
        }

        public MenuInfo(int _PageID, string _PageName)
        {
            this.PageID = _PageID;
            this.PageName = _PageName;
        }
    }
}
