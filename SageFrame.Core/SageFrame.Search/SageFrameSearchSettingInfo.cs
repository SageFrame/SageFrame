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

namespace SageFrame.Search
{
    public enum SageFrameSearchButtonType
    {
        Button,
        Image,
        Link
    }

    public class SageFrameSearchSettingInfo
    {
        private int _SearchButtonType = 0;/* 0 For Button 1 For Image 2 For Link*/
        private string _SearchButtonText = "Search";
        private string _SearchButtonImage = "imbSageSearch.png";
        private int _SearchResultPerPage = 10;
        private string _SearchResultPageName = "SageSearchResult";
        private int _MaxSearchChracterAllowedWithSpace = 200;
        public SageFrameSearchSettingInfo()
        {

        }
        public SageFrameSearchSettingInfo(int searchButtonType, string searchButtonText, string searchButtonImage, int searchResultPerPage, string searchResultPageName, int maxSearchChracterAllowedWithSpace)
        {
            this.SearchButtonType = searchButtonType;
            this.SearchButtonText = searchButtonText;
            this.SearchButtonImage = searchButtonImage;
            this.SearchResultPerPage = searchResultPerPage;
            this.SearchResultPageName = searchResultPageName;
            this.MaxSearchChracterAllowedWithSpace = maxSearchChracterAllowedWithSpace;
        }

        public int SearchButtonType
        {
            get { return _SearchButtonType; }
            set { _SearchButtonType = value; }
        }
        public string SearchButtonText
        {
            get { return _SearchButtonText; }
            set { _SearchButtonText = value; }
        }
        public string SearchButtonImage
        {
            get { return _SearchButtonImage; }
            set { _SearchButtonImage = value; }
        }
        public int SearchResultPerPage
        {
            get { return _SearchResultPerPage; }
            set { _SearchResultPerPage = value; }
        }

        public string SearchResultPageName
        {
            get { return _SearchResultPageName; }
            set { _SearchResultPageName = value; }
        }
        public int MaxSearchChracterAllowedWithSpace
        {
            get { return _MaxSearchChracterAllowedWithSpace; }
            set { _MaxSearchChracterAllowedWithSpace = value; }
        }
    }
}
