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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SageFrame.Web;
using SageFrame.Search;
using SageFrame.SageFrameClass;
using SageFrame.Web.Common.SEO;
using SageFrame.Framework;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using SageFrame.Common.CommonFunction;

public partial class Modules_SageSearch_ctl_SageSearchResult : BaseAdministrationUserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["SageDtv"] = null;
                AddImageUrl();
            }
            SageSearchBySearchWord();
        }
        catch
        {
        }
    }

    private void AddImageUrl()
    {
        imbFilter.ImageUrl = GetTemplateImageUrl("imgfilter.png", true);
    }

    private void SageSearchBySearchWord()
    {
        try
        {
            if (Request.QueryString["searchword"] != null && Request.QueryString["searchword"].ToString() != string.Empty)
            {
                string searchword = Request.QueryString["searchword"].ToString();
                if (!HTMLHelper.IsValidSearchWord(searchword))
                {
                    lblSearchKeyword.Text = "";
                    gdvList.DataSource = null;
                    gdvList.DataBind();
                }
                else
                {
                    lblSearchKeyword.Text = searchword;
                    SageFrameSearch stb = new SageFrameSearch();
                    searchword = stb.AddQuotesForSQLSearch(searchword);
                    GetSearchResultFromDataBase(searchword);
                }
            }
        }
        catch
        {
        }
    }

    private void BindSearchResult()
    {
        try
        {
            if (Session["SageDtv"] != null)
            {
                DataTable dt = (DataTable)Session["SageDtv"];
                DataView dtv = new DataView(dt);
                gdvList.DataSource = dtv;
                gdvList.DataBind();
            }
        }
        catch
        {
        }
    }

    private void GetSearchResultFromDataBase(string searchword)
    {
        try
        {
            if (Session["SageDtv"] == null)
            {
                SageFrameConfig pagebase = new SageFrameConfig();
                bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
                SageFrameSearch SFS = new SageFrameSearch();
                DataSet ds = SFS.SageSearchBySearchWord(searchword, GetUsername, GetCurrentCultureName, IsUseFriendlyUrls, GetPortalID);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    DataTable dt = ds.Tables[0];//Result
                    DataView dtv = new DataView(dt);
                    Session["SageDtv"] = ds;
                    DataTable dtSections = ds.Tables[1];//For Sections
                    BindOrderingSection();
                    BindResultSections(dtSections);
                    DataTable dtTime = ds.Tables[2];//Time of Execution in millisecond                
                    gdvList.DataSource = dtv;
                    gdvList.DataBind();
                    

                }
            }
            //else
            //{
            //    BindOrderingSection();                
            //    FilterSerchResult();                
            //}
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    protected void imbFilter_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            FilterSerchResult();
        }
        catch
        {
        }
    }

    private void FilterSerchResult()
    {
        try
        {
            if (Session["SageDtv"] != null)
            {
                DataSet ds = (DataSet)Session["SageDtv"];

                DataTable dt = ds.Tables[0];//Result
                DataView dtv = new DataView(dt);
                Session["SageDtv"] = ds;
                DataTable dtSections = ds.Tables[1];//For Sections
                //BindOrderingSection();
                //BindResultSections(dtSections);
                DataTable dtTime = ds.Tables[2];//Time of Execution in millisecond
                string strSelectedSection = string.Empty;
                for (int i = 0; i < cblResultSection.Items.Count; i++)
                {
                    if (cblResultSection.Items[i].Selected == true)
                    {
                        strSelectedSection += "'" + cblResultSection.Items[i].Value + "',";
                    }
                }
                if (strSelectedSection != string.Empty && strSelectedSection.Contains(","))
                {
                    strSelectedSection = strSelectedSection.Remove(strSelectedSection.LastIndexOf(","));
                    strSelectedSection = "(" + strSelectedSection + ")";
                    dtv.RowFilter = "ResultSection IN  " + strSelectedSection;
                }
                string SortCondition = string.Empty;
                SortCondition = rblOrdering.SelectedItem.Value;
                if (SortCondition != string.Empty)
                {
                    if (SortCondition == "0")
                    {
                        SortCondition = "LasUpdated DESC";
                    }
                    else if (SortCondition == "1")
                    {
                        SortCondition = "LasUpdated ASC";
                    }
                    else if (SortCondition == "2")
                    {
                        SortCondition = "ResultTitle ASC";
                    }
                    else if (SortCondition == "3")
                    {
                        SortCondition = "ResultTitle DESC";
                    }
                    dtv.Sort = SortCondition;
                }
                gdvList.DataSource = dtv;
                gdvList.DataBind();

            }
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void BindOrderingSection()
    {
        try
        {
            rblOrdering.DataSource = SageFrameLists.SearchOrderingTypes();
            rblOrdering.DataTextField = "Value";
            rblOrdering.DataValueField = "Key";
            rblOrdering.DataBind();
            if (rblOrdering.Items.Count > 0)
            {
                rblOrdering.SelectedIndex = 0;
            }
        }
        catch
        {
        }
    }

    private void BindResultSections(DataTable dt)
    {
        try
        {
            cblResultSection.DataSource = dt;
            cblResultSection.DataTextField = "ResultSection";
            cblResultSection.DataValueField = "ResultSection";
            cblResultSection.DataBind();
        }
        catch
        {
        }
    }

    public string FormatResult(string strResult)
    {        
        strResult = RemoveUnwantedHTMLTAG(strResult);
        if (strResult.Length > 300)
        {
           strResult = strResult.Remove(300);
        }
        strResult = HigLishtResult(strResult);
        return strResult;
    }

    public string RemoveUnwantedHTMLTAG(string stringWithHTML)
    {
        try
        {
            return Regex.Replace(stringWithHTML, @"<(.|\n)*?>", string.Empty);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string HigLishtResult(string strResult)
    {
        string searchword = string.Empty;
        if (Request.QueryString["searchword"] != null && Request.QueryString["searchword"].ToString() != string.Empty)
        {
            searchword = Request.QueryString["searchword"].ToString();
        }
        string strKey = searchword;
        if (strKey != string.Empty && strKey.Length > 0 && strKey.Contains(" "))
        {
            string[] arrColl = strKey.Split(" ".ToCharArray());
            for (int i = 0; i < arrColl.Length; i++)
            {
                strResult = ResultHighliter(strResult, arrColl[i].ToString());
            }
        }
        else
        {
            strResult = ResultHighliter(strResult, strKey);
        }
        return strResult;
    }

    private string ResultHighliter(string strResult, string key)
    {
        try
        {
            if (strResult.ToLower().Contains(key.ToLower()))
            {
                strResult = Replace(strResult, key, "<strong>" + key + "</strong>", StringComparison.InvariantCultureIgnoreCase);
            }            
        }
        catch
        {
        }
        return strResult;
    }

    public string Replace(string original, string oldValue, string newValue, StringComparison comparisionType)
    {
        if (oldValue == null)
            throw new ArgumentNullException("oldValue");
        if (newValue == null)
            throw new ArgumentNullException("newValue");

        var result = original;

        if (oldValue != newValue)
        {
            int index = -1;
            int lastIndex = 0;

            var buffer = new StringBuilder();

            while ((index = original.IndexOf(oldValue, index + 1, comparisionType)) >= 0)
            {
                buffer.Append(original, lastIndex, index - lastIndex);
                string tempValue = original.Remove(index + oldValue.Length);
                tempValue = tempValue.Remove(0, tempValue.LastIndexOf(oldValue, StringComparison.CurrentCultureIgnoreCase));
                buffer.Append("<strong>" + tempValue + "</strong>");
                lastIndex = index + oldValue.Length;
            }
            buffer.Append(original, lastIndex, original.Length - lastIndex);
            result = buffer.ToString();
        }
        return result;
    }

    protected void gdvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvList.PageIndex = e.NewPageIndex;
            FilterSerchResult();
        }
        catch
        {
        }
    }   

    protected void ddlGridPager_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int PageSize = Int32.Parse(ddlGridPager.SelectedValue);
            if (PageSize != 0)
            {
                gdvList.PageSize = PageSize;
                gdvList.AllowPaging = true;
            }
            else
            {
                gdvList.AllowPaging = false;

            }
            FilterSerchResult();
        }
        catch
        {
        }
    }

           
   
}
