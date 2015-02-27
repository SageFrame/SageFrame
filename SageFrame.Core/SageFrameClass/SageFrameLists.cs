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
using System.Web;
using System.Collections;
using System.Globalization;
using SageFrame.Web;

namespace SageFrame.SageFrameClass
{
    public static class SageFrameLists
    {
        
        public static List<SageFrameStringKeyValue> menuPagePosition()
        {
            //SageUserControl SU = new SageUserControl();
            //SU.GetSageMessage("PortalSettings", "PortalSettingIsSavedSuccessfully");
            
            List<SageFrameStringKeyValue> menuPosition = new List<SageFrameStringKeyValue>();
            menuPosition.Add(new SageFrameStringKeyValue("Before", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Before")));
            menuPosition.Add(new SageFrameStringKeyValue("After", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "After")));
            menuPosition.Add(new SageFrameStringKeyValue("Add to End", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "AddtoEnd")));
            return menuPosition;
        }

        public static List<SageFrameStringKeyValue> urlTypeName()
        {
            List<SageFrameStringKeyValue> urlType = new List<SageFrameStringKeyValue>();
            urlType.Add(new SageFrameStringKeyValue("None", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "None")));
            urlType.Add(new SageFrameStringKeyValue("URL ( A Link To An External Resource )", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "URLALinkToAnExternalResource")));            
            return urlType;
        }

        public static List<SageFrameIntKeyValue> DataTypes()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();

            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "String")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Integer")));
            arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Decimal")));
            arrColl.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateTime")));            
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> SMTPAuthntication()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();
            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Anonymous")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Basic")));
            //arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NTLM")));           
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> UserRegistrationTypes()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();
            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "None")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Private")));
            arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Public")));
            arrColl.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Verified")));
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> SearchEngines()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();
            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Google")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Yahoo")));
            arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Microsoft")));            
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> YESNO()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();
            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "No")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Yes")));           
            return arrColl;
        }


        //public static ArrayList urlTypeName()
        //{
        //    ArrayList urlType = new ArrayList();
        //    urlType.Clear();
        //    urlType.Add("None");
        //    urlType.Add("URL ( A Link To An External Resource )");
        //    //urlType.Add("Page ( A Page On Your Site )");
        //    //urlType.Add("File ( A File On Your Site )");
        //    return urlType;

        //}

        public static List<SageFrameStringKeyValue> ModulePanes()
        {
            //List<SageFrameStringKeyValue> modulePanes = new List<SageFrameStringKeyValue>();
            //modulePanes.Add(new SageFrameStringKeyValue("TopPane", "TopPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("LeftPane", "LeftPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("ContentPane", "ContentPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("RightPane", "RightPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("BottomPane", "BottomPane"));
            List<SageFrameStringKeyValue> modulePanes = SageMessage.ListSageModuleName(CultureInfo.CurrentCulture.Name, "ModulesPanes");
            return modulePanes;
        }
        public static List<SageFrameStringKeyValue> UserStatisticShortBy()
        {
            //List<SageFrameStringKeyValue> modulePanes = new List<SageFrameStringKeyValue>();
            //modulePanes.Add(new SageFrameStringKeyValue("TopPane", "TopPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("LeftPane", "LeftPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("ContentPane", "ContentPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("RightPane", "RightPane"));
            //modulePanes.Add(new SageFrameStringKeyValue("BottomPane", "BottomPane"));
            List<SageFrameStringKeyValue> modulePanes = SageMessage.ListSageModuleName(CultureInfo.CurrentCulture.Name, "UserStatisticShortBy");
            return modulePanes;
        }
        //public static ArrayList ModulePanes()
        //{
        //    ArrayList modulePanes = new ArrayList();
        //    modulePanes.Clear();
        //    modulePanes.Add("TopPane");
        //    modulePanes.Add("LeftPane");
        //    modulePanes.Add("ContentPane");
        //    modulePanes.Add("RightPane");
        //    modulePanes.Add("BottomPane");
        //    return modulePanes;
        //}

        //public static ArrayList PostionType()
        //{
        //    ArrayList postionType = new ArrayList();
        //    postionType.Clear();
        //    postionType.Add("Top");
        //    postionType.Add("Above");
        //    postionType.Add("Below");
        //    //postionType.Add("Bottom");
        //    return postionType;
        //}        

        public static List<SageFrameStringKeyValue> PositionType()
        {
            List<SageFrameStringKeyValue> positionType = new List<SageFrameStringKeyValue>();
            positionType.Add(new SageFrameStringKeyValue("Top", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Top")));
            positionType.Add(new SageFrameStringKeyValue("Above", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Above")));
            positionType.Add(new SageFrameStringKeyValue("Below", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Below")));
            positionType.Add(new SageFrameStringKeyValue("Bottom", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Bottom")));
            return positionType;
        }

        public static List<SageFrameIntKeyValue> ControlType()
        {
            List<SageFrameIntKeyValue> controlType = new List<SageFrameIntKeyValue>();
            controlType.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "View")));
            controlType.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Edit")));
            controlType.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Setting")));
            controlType.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Admin")));
            return controlType;
        }

        public static List<SageFrameIntKeyValue> WeekDays()
        {
            List<SageFrameIntKeyValue> controlType = new List<SageFrameIntKeyValue>();
            controlType.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Sunday")));
            controlType.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Monday")));
            controlType.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Tuesday")));
            controlType.Add(new SageFrameIntKeyValue(4, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Wednesday")));
            controlType.Add(new SageFrameIntKeyValue(5, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Thursday")));
            controlType.Add(new SageFrameIntKeyValue(6, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Friday")));
            controlType.Add(new SageFrameIntKeyValue(7, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Saturday")));
            return controlType;
        }

        public static ArrayList VersionType()
        {
            ArrayList arrColl = new ArrayList();
            for (int i = 0; i < 100; i++)
            {
                if (i < 10)
                {
                    arrColl.Add("0" + i);
                }
                else
                {
                    arrColl.Add(i);
                }
            }
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> FAQsSorting()
        {
            List<SageFrameIntKeyValue> FAQsSorting = new List<SageFrameIntKeyValue>();
            FAQsSorting.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateNew")));
            FAQsSorting.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateOld")));
            FAQsSorting.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "PopularityHigh")));
            FAQsSorting.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "PopularityLow")));
            return FAQsSorting;
        }

        public static List<SageFrameStringKeyValue> FAQsTokenLists()
        {
            List<SageFrameStringKeyValue> FAQsTokenLists = new List<SageFrameStringKeyValue>();
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[QUESTION]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "QUESTION")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[ANSWER]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "ANSWER")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[USER]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "USER")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[VIEWCOUNT]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "VIEWCOUNT")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[CATEGORYNAME]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "CATEGORYNAME")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[CATEGORYDESC]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "CATEGORYDESC")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[DATECREATED]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DATECREATED")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[DATEMODIFIED]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DATEMODIFIED")));
            FAQsTokenLists.Add(new SageFrameStringKeyValue("[INDEX]", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "INDEX")));
            return FAQsTokenLists;
        }

        public static List<SageFrameStringKeyValue> NewsSorting()
        {
            List<SageFrameStringKeyValue> NewsSorting = new List<SageFrameStringKeyValue>();
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateNew")));
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Asc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateOld")));
            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameDescending")));
            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Asc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameAscending")));
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Desc, NewsTitle Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateNewNameDescending")));
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Desc, NewsTitle Asc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateNewNameAscending")));
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Asc, NewsTitle Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateOldNameDescending")));
            NewsSorting.Add(new SageFrameStringKeyValue("AddedOn Asc, NewsTitle Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "DateOldNameAscending")));

            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Desc, AddedOn Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameDescendingDateNew")));
            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Desc, AddedOn Asc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameDescendingDateOld")));
            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Asc, AddedOn Desc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameAscendingDateNew")));
            NewsSorting.Add(new SageFrameStringKeyValue("NewsTitle Asc, AddedOn Asc", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NameAscendingDateOld"))); 
            return NewsSorting;
        }

        public static List<SageFrameStringKeyValue> DateFormat()
        {
            List<SageFrameStringKeyValue> DateFormat = new List<SageFrameStringKeyValue>();
            DateFormat.Add(new SageFrameStringKeyValue("d", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Shortdatepattern")));
            DateFormat.Add(new SageFrameStringKeyValue("D", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Longdatepattern")));
            DateFormat.Add(new SageFrameStringKeyValue("f", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Fulldatetimepatternshorttime")));
            DateFormat.Add(new SageFrameStringKeyValue("F", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Fulldatetimepatternlongtime")));
            DateFormat.Add(new SageFrameStringKeyValue("g", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Generaldatetimepatternshorttime")));
            DateFormat.Add(new SageFrameStringKeyValue("G", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Generaldatetimepatternlongtime")));
            DateFormat.Add(new SageFrameStringKeyValue("M", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Monthdaypattern")));
            //DateFormat.Add(new SageFrameStringKeyValue("R", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "RFC1123pattern")));
            DateFormat.Add(new SageFrameStringKeyValue("t", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Shorttimepattern")));
            DateFormat.Add(new SageFrameStringKeyValue("T", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Longtimepattern")));
            DateFormat.Add(new SageFrameStringKeyValue("U", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Universalfulldatetimepattern")));
            DateFormat.Add(new SageFrameStringKeyValue("Y", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Yearmonthpattern")));

            DateFormat.Add(new SageFrameStringKeyValue("yyyy-MM-dd", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Year-Month-Day")));
            DateFormat.Add(new SageFrameStringKeyValue("dd-MM-yyyy", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Day-Month-Year")));
            DateFormat.Add(new SageFrameStringKeyValue("MMMM dd, yyyy (dddd)", SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "MonthNameDayYearDayName")));

            return DateFormat;
        }

        public static List<SageFrameStringKeyValue> InstallationType()
        {
            List<SageFrameStringKeyValue> InstallationType = new List<SageFrameStringKeyValue>();
            InstallationType.Add(new SageFrameStringKeyValue("Custom", "<b>Custom</b> - The 'Custom' installation method provides you with the ability to completely customise your SageFrame installation. Select this option if you wish to control which optional components get installed."));
            //InstallationType.Add(new SageFrameStringKeyValue("Typical", "<b>Typical</b>  - The 'Typical' installation method makes some 'typical' choices for you."));
            InstallationType.Add(new SageFrameStringKeyValue("Auto", "<b>Auto</b> - The 'Auto' installation method bypasses the Wizard completely and uses the legacy Auto-Install procedure."));
            return InstallationType;
        }

        public static List<SageFrameStringKeyValue> DatabaseType()
        {
            List<SageFrameStringKeyValue> DatabaseType = new List<SageFrameStringKeyValue>();
            //DatabaseType.Add(new SageFrameStringKeyValue("SQLFile", "SQLServerXPress"));
            DatabaseType.Add(new SageFrameStringKeyValue("SQLDatabase", "SQLServer"));
            return DatabaseType;
        }

        public static List<SageFrameIntKeyValue> SubscriptionDisplayType()
        {
            List<SageFrameIntKeyValue> SubscriptionDisplayType = new List<SageFrameIntKeyValue>();
            SubscriptionDisplayType.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Simple")));
            SubscriptionDisplayType.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Modalbox")));
            return SubscriptionDisplayType;
        }        
		
		public static List<SageFrameIntKeyValue> SearchButtonTypes()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();

            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Button")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Image")));
            arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "Link")));            
            return arrColl;
        }

        public static List<SageFrameIntKeyValue> SearchOrderingTypes()
        {
            List<SageFrameIntKeyValue> arrColl = new List<SageFrameIntKeyValue>();

            arrColl.Add(new SageFrameIntKeyValue(0, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "NewFirst")));
            arrColl.Add(new SageFrameIntKeyValue(1, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "OldFirst")));
            arrColl.Add(new SageFrameIntKeyValue(2, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "AlphaBaticallyASC")));
            arrColl.Add(new SageFrameIntKeyValue(3, SageMessage.ListSageText(CultureInfo.CurrentCulture.Name, "SageFrameLists", "AlphaBaticallyDESC")));
            return arrColl;
        }
    }

    
}
