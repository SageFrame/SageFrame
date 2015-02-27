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
        private int _MaxResultCharacterAllowedWithSpace = 200;
        public SageFrameSearchSettingInfo()
        {

        }
        public SageFrameSearchSettingInfo(int searchButtonType, string searchButtonText, string searchButtonImage, int searchResultPerPage, string searchResultPageName, int maxSearchChracterAllowedWithSpace, int maxResultCharacterAllowedWithSpace)
        {
            this.SearchButtonType = searchButtonType;
            this.SearchButtonText = searchButtonText;
            this.SearchButtonImage = searchButtonImage;
            this.SearchResultPerPage = searchResultPerPage;
            this.SearchResultPageName = searchResultPageName;
            this.MaxSearchChracterAllowedWithSpace = maxSearchChracterAllowedWithSpace;
            this.MaxResultChracterAllowedWithSpace = maxResultCharacterAllowedWithSpace;
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
        public int MaxResultChracterAllowedWithSpace
        {
            get { return _MaxResultCharacterAllowedWithSpace; }
            set { _MaxResultCharacterAllowedWithSpace = value; }
        }
    }
}
