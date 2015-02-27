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
using System.Data;
using SageFrame.Web.Utilities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;
using SageFrame.Common.CommonFunction;
namespace SageFrame.Search
{
    public class SageFrameSearch
    {
        public SageFrameSearch()
        {

        }

        public void AddUpdateSageFrameSearchSetting(SageFrameSearchSettingInfo objSearchSettingInfo, int PortalID, string CultureName, string AddedBy)
        {            
            
            try
            {
                string SettingKeys = string.Empty;
                string SettingValues = string.Empty;
                //Pre pare Key value for the save;
                SettingKeys = "SearchButtonType#SearchButtonText#SearchButtonImage#SearchResultPerPage#SearchResultPageName#MaxSearchChracterAllowedWithSpace";
                SettingValues = objSearchSettingInfo.SearchButtonType.ToString() + "#" + objSearchSettingInfo.SearchButtonText + "#" +
                    objSearchSettingInfo.SearchButtonImage + "#" + objSearchSettingInfo.SearchResultPerPage.ToString() + 
                    "#" + objSearchSettingInfo.SearchResultPageName +
                    "#" + objSearchSettingInfo.MaxSearchChracterAllowedWithSpace.ToString();

                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingKeys", SettingKeys));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingValues", SettingValues));

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@CultureName", CultureName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@AddedBy", AddedBy));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_SageFrameSearchSettingValueAddUpdate", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SageFrameSearchProcedureDelete(int SageFrameSearchProcedureID, string DeletedBy)
        {
            try
            {                
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SageFrameSearchProcedureID", SageFrameSearchProcedureID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@DeletedBy", DeletedBy));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_SageFrameSearchProcedureDelete", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void SageFrameSearchProcedureAddUpdate(SageFrameSearchProcedureInfo objInfo, int PortalID, string AddedBy)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SageFrameSearchProcedureID", objInfo.SageFrameSearchProcedureID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SageFrameSearchTitle", objInfo.SageFrameSearchTitle));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SageFrameSearchProcedureName", objInfo.SageFrameSearchProcedureName.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SageFrameSearchProcedureExecuteAs", objInfo.SageFrameSearchProcedureExecuteAs));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@IsActive", objInfo.IsActive.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@AddedOn", objInfo.AddedOn.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@AddedBy", AddedBy));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_SageFrameSearchProcedureAddUpdate", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public static bool SearchPageExists(int PortalID,string PageName)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();

                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PageName", PageName));
             
                SQLHandler sagesql = new SQLHandler();
                int count = 0;
                count=sagesql.ExecuteAsScalar<int>("usp_SearchResultPageExists", ParaMeterCollection);
                return count > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SageFrameSearchSettingInfo LoadSearchSettings(int PortalID, string CultureName)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@CultureName", CultureName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID.ToString()));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_SageFrameSearchSettingValueGet", ParaMeterCollection);
                SageFrameSearchSettingInfo objSearchSettingInfo = new SageFrameSearchSettingInfo();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strKey = dt.Rows[i]["SettingKey"].ToString();
                        switch (strKey)
                        {
                            case "SearchButtonType":
                                if (dt.Rows[i]["SettingValue"].ToString() != string.Empty)
                                {
                                    objSearchSettingInfo.SearchButtonType = Int32.Parse(dt.Rows[i]["SettingValue"].ToString());
                                }
                                break;
                            case "SearchButtonText":
                                objSearchSettingInfo.SearchButtonText = dt.Rows[i]["SettingValue"].ToString();
                                break;
                            case "SearchButtonImage":
                                objSearchSettingInfo.SearchButtonImage = dt.Rows[i]["SettingValue"].ToString();
                                break;
                            case "SearchResultPerPage":
                                if (dt.Rows[i]["SettingValue"].ToString() != string.Empty)
                                {
                                    objSearchSettingInfo.SearchResultPerPage = Int32.Parse(dt.Rows[i]["SettingValue"].ToString());
                                }
                                break;
                            case "SearchResultPageName":
                                objSearchSettingInfo.SearchResultPageName = dt.Rows[i]["SettingValue"].ToString();
                                break;
                            case "MaxSearchChracterAllowedWithSpace":
                                if (dt.Rows[i]["SettingValue"].ToString() != string.Empty)
                                {
                                    objSearchSettingInfo.MaxSearchChracterAllowedWithSpace = Int32.Parse(dt.Rows[i]["SettingValue"].ToString());
                                }
                                break;
                        }
                    }
                }
                return objSearchSettingInfo;
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable ListSageSerchProcedures(int PortalID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID.ToString()));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_SageFrameSearchProcedureList", ParaMeterCollection);
                return ds.Tables[0];                

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public DataSet SageSearchBySearchWord(string Searchword, string SearchBy, string CultureName, bool IsUseFriendlyUrls, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Searchword", Searchword));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@CultureName", CultureName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@IsUseFriendlyUrls", IsUseFriendlyUrls.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SearchBy", SearchBy));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID.ToString()));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_SageSearchBySearchKey", ParaMeterCollection);
                return ds;

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public SageFrameSearchProcedureInfo SageFrameSearchProcedureGet(string SageFrameSearchProcedureID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();                              
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SageFrameSearchProcedureID", SageFrameSearchProcedureID));
                SQLHandler sagesql = new SQLHandler();
                SageFrameSearchProcedureInfo objSpIno = sagesql.ExecuteAsObject<SageFrameSearchProcedureInfo>("dbo.sp_SageFrameSearchProcedureGet", ParaMeterCollection);
                return objSpIno;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string AddQuotesForSQLSearch(string InputString)
        {
            string ReturnString = string.Empty;
            try
            {
               ReturnString = InputString.Trim();
                // Remove white space from beginning and end.
                if (InputString.Contains("'"))
                {
                    ReturnString = string.Empty;
                    string[] arrColl = InputString.Split("'".ToCharArray());
                    for (int i = 0; i < arrColl.Length; i++)
                    {
                        if (arrColl[i].ToString().Trim() != string.Empty)
                        {
                            if (i != arrColl.Length - 1)
                            {
                                ReturnString += arrColl[i].ToString() + "''";
                            }
                            else
                            {
                                ReturnString += arrColl[i].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ReturnString = "Exception caught: " + e.ToString();
            }
            return ReturnString;
        }

        public bool CheckIgnorWords(string SearchString)
        {
            string IgnorWords = string.Empty;
            IgnorWords = "^ , ; : [] ] [ {} () } { ) ( _ = < > . + - \\ / \" \"\" ' ! % * @~ @# @& &? & # ? about 1 after 2 all also 3 an 4 and 5 another 6 any 7 are 8 as 9 at 0 be $ because been before being between both but by came can come could did do each for from get got has had he have her here him himself his how if in into is it like make many me might more most much must my never now of on only or other our out over said same see should since some still such take than that the their them then there these they this those through to too under up very was way we well were what where which while who with would you your a b c d e f g h i j k l m n o p q r s t u v w x y z";
            SearchString = RemoveSpcalSymbol(SearchString);
            if (IgnorWords.Contains(SearchString) || SearchString.Trim() == "" || !HTMLHelper.IsValidSearchWord(SearchString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string RemoveSpcalSymbol(string SearchString)
        {
            SearchString = SearchString.Replace("\"", "");
            SearchString = SearchString.Replace("@", "");
            SearchString = SearchString.Replace("?", "");
            SearchString = SearchString.Replace(":", "");
            SearchString = SearchString.Replace(";", "");
            SearchString = SearchString.Replace("_", "");
            SearchString = SearchString.Replace("=", "");
            SearchString = SearchString.Replace("<", "");
            SearchString = SearchString.Replace(">", "");
            SearchString = SearchString.Replace("[", "");
            SearchString = SearchString.Replace("]", "");
            SearchString = SearchString.Replace("{", "");
            SearchString = SearchString.Replace("}", "");
            SearchString = SearchString.Replace("!", "");
            SearchString = SearchString.Replace("#", "");
            SearchString = SearchString.Replace(",", "");
            SearchString = SearchString.Replace("-", "");
            SearchString = SearchString.Replace(".", "");
            SearchString = SearchString.Replace("^", "");
            SearchString = SearchString.Replace("(", "");
            SearchString = SearchString.Replace(")", "");
            SearchString = SearchString.Replace("/", "");
            SearchString = SearchString.Replace("~", "");
            SearchString = SearchString.Replace("|", "");
            SearchString = SearchString.Replace("$", "");
            SearchString = SearchString.Replace("%", "");
            SearchString = SearchString.Replace("&", "");
            SearchString = SearchString.Replace("*", "");
            SearchString = SearchString.Replace("and", "");

            return SearchString;
        }
    }
    
}
