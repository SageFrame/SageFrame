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
using System.Text;
using System.Data;
using System.Collections;
namespace SageFrame.Modules.NewsModule
{

    public partial class News : BaseAdministrationUserControl
    {
        
        public Int32 usermoduleID = 0;
        CommonFunction comm = new CommonFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            usermoduleID = Int32.Parse(SageUserModuleID);
            IncludeCss("NewsModule", "/Modules/NewsModule/css/module.css");
            if (!Page.IsPostBack)
            {
                //AddImageUrls();
                BindNews();
            }

        }

        //private void AddImageUrls()
        //{
        //    imgltr.ImageUrl = GetTemplateImageUrl("lt-r.gif", true);
        //    imbrtr.ImageUrl = GetTemplateImageUrl("rt-r.gif", true);
        //    imblbr.ImageUrl = GetTemplateImageUrl("lb-r.gif", true);
        //    imbrbr.ImageUrl = GetTemplateImageUrl("rb-r.gif", true);
        //}

        private void BindNews()
        {
            try
            {
                NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
                HiddenField hdnMoreNewsText = new HiddenField();
                var newSetting = db.sp_NewsSettingGetAll(usermoduleID, GetPortalID);
                foreach (sp_NewsSettingGetAllResult setting in newSetting)
                {
                    switch (setting.SettingKey)
                    {                       
                        case "MoreNewsText":
                            hdnMoreNewsText.Value = setting.SettingValue.Trim();
                            break;
                    }
                }

                StringBuilder strContent = new StringBuilder();
                var news = db.sp_NewsList(usermoduleID, GetPortalID);
                DataTable dt = comm.LINQToDataTable(news);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HiddenField hdfNewsID = new HiddenField();
                    hdfNewsID.Value = dt.Rows[i]["NewsID"].ToString();
                    //strContent.Append("<div class=\"cssClassnews\">");
                    strContent.Append("<div class=\"sfNewsitem\">");
                    strContent.Append("<h3><a href='" + SetNewsUrl(hdfNewsID.Value) + "'>" + dt.Rows[i]["NewsTitle"].ToString() + "</a></h3>");
                    strContent.Append("<span class='sfNewsdate'>" + ReadNewsDateFormatSetting(DateTime.Parse(dt.Rows[i]["NewsDate"].ToString())) + "</span>");
                    strContent.Append("<p>" + ReadMoreContent(dt.Rows[i]["NewsShortDescription"].ToString()) + "</p>");
                    strContent.Append("</div>");
                }
                strContent.Append("<a class='sfBtn' href='" + SetNewsUrl(string.Empty) + "'>" + hdnMoreNewsText.Value + "</a>");
                lblNews.Text = strContent.ToString();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private string ReadNewsDateFormatSetting(DateTime NewsDate)
        {
            NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
            string newsDateFormat = string.Empty;
            var News = db.sp_NewsSettingGetAll(usermoduleID, GetPortalID);
            foreach (sp_NewsSettingGetAllResult setting in News)
            {
                switch (setting.SettingKey)
                {
                    case "NewsDateFormat":
                        newsDateFormat = setting.SettingValue;
                        newsDateFormat = NewsDate.ToString(newsDateFormat);
                        break;
                }
            }
            return newsDateFormat;
        }

        private string ReadMoreContent(string newsShortDescription)
        {
            string trimContent = newsShortDescription;
            int sizeOfField = 70;
            //char[] paddingChar = { '.' };
            if (newsShortDescription.Length >= sizeOfField)
            {
                newsShortDescription = newsShortDescription.Substring(0, sizeOfField);
                trimContent = newsShortDescription + "...";
            }
            return trimContent;
        }

        private string SetNewsUrl(string newsID)
        {
            string NewsUrl = string.Empty;
            SageFrameConfig pagebase = new SageFrameConfig();
            bool IsUseFriendlyUrls = pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseFriendlyUrls);
            ArrayList arrColl = new ArrayList();
            arrColl.Add(Request.RawUrl);
            HttpContext.Current.Session["requrl"] = arrColl;

            if (newsID == string.Empty)
            {
                string st = Request.RawUrl;
                if (!IsUseFriendlyUrls)
                {
                    NewsUrl = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + GetPageName());
                }
                else
                {
                    if (GetPortalID > 1)
                    {
                        NewsUrl = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + GetPageName() + ".aspx");
                    }
                    else
                    {
                        NewsUrl = ResolveUrl("~/" + GetPageName() + ".aspx");
                    }

                }
            }
            else
            {
                if (!IsUseFriendlyUrls)
                {
                    NewsUrl = ResolveUrl("~/Default.aspx?ptlid=" + GetPortalID + "&ptSEO=" + GetPortalSEOName + "&pgnm=" + GetPageName() + "&newscode=" + newsID);
                }
                else
                {
                    if (GetPortalID > 1)
                    {
                        NewsUrl = ResolveUrl("~/portal/" + GetPortalSEOName + "/" + GetPageName() + ".aspx?newscode=" + newsID);
                    }
                    else
                    {
                        NewsUrl = ResolveUrl("~/" + GetPageName() + ".aspx?newscode=" + newsID);
                    }
                }
            }
            return NewsUrl;
        }

        private String GetPageName()
        {
            NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
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
    }
}