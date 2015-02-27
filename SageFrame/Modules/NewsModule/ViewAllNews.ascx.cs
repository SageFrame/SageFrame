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
using SageFrame.Web;
using SageFrame.News;
using SageFrame.Framework;
using System.Collections;

namespace SageFrame.Modules.NewsModule
{
    public partial class ViewAllNews : BaseAdministrationUserControl
    {
        NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
        public Int32 usermoduleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                usermoduleID = Int32.Parse(SageUserModuleID);
                if (!IsPostBack)
                {
                    HideAll();
                    AddImageUrls();                    
                    if (Request.QueryString["newscode"] != null)
                    {
                        var news = db.sp_NewsGetbyNewsID(int.Parse(Request.QueryString["newscode"].ToString()), GetPortalID).SingleOrDefault();
                        ltrNewsLong.Text = news.NewsLongDescription;
                        lblNewsTitle.Text = news.NewsTitle;
                        lblNewsDate1.Text = news.NewsDate.ToString();
                        pnlDetailNews.Visible = true;
                        ViewState["tracker"] = null;
                    }
                    else
                    {
                        PopulateNewsCatList();
                        BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
                        pnlMoreNews.Visible = true;
                    }
                    
                }
                if (Request.QueryString["newsparam"] != null)
                {
                    var news = db.sp_NewsGetbyNewsID(int.Parse(Request.QueryString["newsparam"].ToString()), GetPortalID).SingleOrDefault();
                    ltrNewsLong.Text = news.NewsLongDescription;
                    lblNewsTitle.Text = news.NewsTitle;
                    lblNewsDate1.Text = news.NewsDate.ToString();
                    HideAll();
                    pnlDetailNews.Visible = true;
                    if (ViewState["tracker"] == null && HttpContext.Current.Session["requrl"] != null)
                    {
                        ArrayList arrColl = (ArrayList)HttpContext.Current.Session["requrl"];
                        arrColl.Add(Request.UrlReferrer.ToString());
                        HttpContext.Current.Session["requrl"] = arrColl;
                        ViewState["tracker"] = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void PopulateNewsCatList()
        {
            try
            {
                var LINQ = db.sp_NewsCategory(GetPortalID, true);
                ddlNewsCatList.DataSource = LINQ;
                ddlNewsCatList.DataValueField = "NewsCategoryID";
                ddlNewsCatList.DataTextField = "NewsCategory";
                ddlNewsCatList.DataBind();
                ddlNewsCatList.Items.Insert(0, new ListItem("All News Category", "-1"));
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindGrid(int newsCategoryID)
        {
            var LINQ = db.sp_NewsView(GetPortalID, newsCategoryID, true);
            gdvAllNews.DataSource = LINQ;
            gdvAllNews.DataBind();
        }

        private void HideAll()
        {
            pnlMoreNews.Visible = false;
            pnlDetailNews.Visible = false;
        }

        private void AddImageUrls()
        {
            imgCancel.ImageUrl = GetTemplateImageUrl("imgback.png", true);
            imbBack.ImageUrl = GetTemplateImageUrl("imgback.png", true);
        }

        protected void gdvAllNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }        

        private string SetNewsUrl(string newsID)
        {
            string NewsUrl = string.Empty;
            string url = string.Empty;
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
            if (IsUseFriendlyUrls)
            {
                if (GetPortalID > 1)
                {
                    NewsUrl = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + GetPageName() + ".aspx?newsparam=" + newsID);
                }
                else
                {
                    NewsUrl = ResolveUrl("~/" + GetPageName() + ".aspx?newsparam=" + newsID);
                }
            }
            else
            {
                NewsUrl = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + GetPageName() + "&newsparam=" + newsID);
            }
            return NewsUrl;            
        }        

        private String GetPageName()
        {
            string pageName = string.Empty;
            var News = db.sp_NewsSettingGetAll(usermoduleID, GetPortalID);
            foreach (sp_NewsSettingGetAllResult setting in News)
            {
                switch (setting.SettingKey)
                {
                    case "MoreNewsPageName":
                        pageName = setting.SettingValue;
                        break;
                }
            }
            return pageName;
        }

        protected void gdvAllNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gdvAllNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gdvAllNews_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gdvAllNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void imbBack_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Session["requrl"] != null)
            {
                ArrayList arrColl = (ArrayList)HttpContext.Current.Session["requrl"];
                string rtnURL = arrColl[arrColl.Count - 1].ToString();
                arrColl.RemoveAt(arrColl.Count - 1);
                HttpContext.Current.Session["requrl"] = arrColl;
                HttpContext.Current.Response.Redirect(rtnURL);
            }
          
            
        }

        protected void gdvAllNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfNewsID = e.Row.FindControl("hdfNewsID") as HiddenField;
                HyperLink hlnknewsInDetails = e.Row.FindControl("hlnknewsInDetails") as HyperLink;
                string strURL = SetNewsUrl(hdfNewsID.Value);
                hlnknewsInDetails.NavigateUrl = Page.ResolveUrl(strURL);
            }
        }

        void lnkNewsInDetails_Command(object sender, CommandEventArgs e)
        {
            LinkButton lnkNewsInDetails = (LinkButton)sender;
            Response.Redirect(lnkNewsInDetails.CommandArgument.ToString());
        }

        void lnkNewsInDetails_Click(object sender, EventArgs e)
        {
            
            LinkButton lnkNewsInDetails = (LinkButton)sender;
            Response.Redirect(lnkNewsInDetails.CommandArgument.ToString());
        }

        protected void gdvAllNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAllNews.PageIndex = e.NewPageIndex;
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
        }
        protected void ddlNewsCatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(Int32.Parse(ddlNewsCatList.SelectedItem.Value));
        }
}
}