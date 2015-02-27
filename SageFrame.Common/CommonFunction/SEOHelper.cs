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
using System.Web.UI.HtmlControls;
using SageFrame.Setting;
using System.Text;
using System.Text.RegularExpressions;
using SageFrame.Common.SageFrame.Setting;
//using System.Web.HttpServerUtility;
//using System.Web.HttpUtility;
/// <summary>
/// Summary description for SEOHelper
/// </summary>
/// 
namespace SageFrame.Web.Common.SEO
{
    public class SEOHelper
    {
        static SettingDataContext dbSetting = new SettingDataContext(SystemSetting.SageFrameConnectionString);
        public SEOHelper()
        {
            //
            // TODO: Add constructor logic here
            //
            
        }

        /// <summary>
        /// Renders page meta tag
        /// </summary>
        /// <param name="page">Page instance</param>
        /// <param name="name">Meta name</param>
        /// <param name="content">Content</param>
        /// <param name="OverwriteExisting">Overwrite existing content if exists</param>
        public static void RenderMetaTag(Page page, string name, string content, bool OverwriteExisting)
        {
            if (page == null || page.Header == null)
                return;

            if (content == null)
                content = string.Empty;

            foreach (Control control in page.Header.Controls)
                if (control is HtmlMeta)
                {
                    HtmlMeta meta = (HtmlMeta)control;
                    if (meta.Name.ToLower().Equals(name.ToLower()) && !string.IsNullOrEmpty(content))
                    {
                        if (OverwriteExisting)
                            meta.Content = content;
                        else
                        {
                            if (String.IsNullOrEmpty(meta.Content))
                                meta.Content = content;
                        }
                    }
                }
        }

        public static void RenderCSSPath(Page page, string name, string cssFilePath, bool OverwriteExisting)
        {
            if (page == null || page.Header == null)
                return;

            if (cssFilePath == null)
                cssFilePath = string.Empty;
            HtmlLink link = (HtmlLink)page.FindControl(name);
            //foreach (Control control in page.Header.Controls)
            //    if (control is HtmlLink)
            //    {
            //        HtmlLink link = (HtmlLink)control; 
            if (link != null)
            {
                if (link.ID.ToLower().Equals(name.ToLower()) && !string.IsNullOrEmpty(cssFilePath))
                {
                    if (OverwriteExisting)
                        link.Href = cssFilePath;
                    else
                    {
                        if (String.IsNullOrEmpty(link.Href))
                            link.Href = cssFilePath;
                    }
                    //    }
                }
            }
        }

        

        /// <summary>
        /// Renders page title
        /// </summary>
        /// <param name="page">Page instance</param>
        /// <param name="title">Page title</param>
        /// <param name="OverwriteExisting">Overwrite existing content if exists</param>
        public static void RenderTitle(Page page, string title, bool OverwriteExisting, int PortalID)
        {
            //bool includeStoreNameInTitle = SettingManager.GetSettingValueBoolean("SEO.IncludeStoreNameInTitle");
            bool includeStoreNameInTitle = bool.Parse(dbSetting.sp_SettingPortalBySettingID((int)SettingKey.SEO_IncludeStoreNameInTitle, PortalID).SingleOrDefault().Value);
            RenderTitle(page, title, includeStoreNameInTitle, OverwriteExisting, PortalID);
        }

        /// <summary>
        /// Renders page title
        /// </summary>
        /// <param name="page">Page instance</param>
        /// <param name="title">Page title</param>
        /// <param name="IncludeStoreNameInTitle">Include store name in title</param>
        /// <param name="OverwriteExisting">Overwrite existing content if exists</param>
        public static void RenderTitle(Page page, string title, bool IncludeStoreNameInTitle, bool OverwriteExisting, int PortalID)
        {
            if (page == null || page.Header == null)
                return;

            if (IncludeStoreNameInTitle)
                title = dbSetting.sp_SettingPortalBySettingID((int)SettingKey.Common_StoreName, PortalID).SingleOrDefault().Value + ". " + title;

            if (String.IsNullOrEmpty(title))
                return;

            if (OverwriteExisting)
                page.Title = HttpUtility.HtmlEncode(title);
            else
            {
                if (String.IsNullOrEmpty(page.Title))
                    page.Title = HttpUtility.HtmlEncode(title);
            }
        }

        /// <summary>
        /// Renders an RSS link to the page
        /// </summary>
        /// <param name="page">Page instance</param>
        /// <param name="title">RSS Title</param>
        /// <param name="href">Path to the RSS feed</param>
        public static void RenderHeaderRSSLink(Page page, string title, string href)
        {
            if (page == null || page.Header == null)
                return;

            HtmlGenericControl link = new HtmlGenericControl("LINK");
            link.Attributes.Add("rel", "alternate");
            link.Attributes.Add("type", "application/rss+xml");
            link.Attributes.Add("title", title);
            link.Attributes.Add("href", href);
            page.Header.Controls.Add(link);
        }

        /// <summary>
        /// Get SE name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public static string GetSEName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return string.Empty;
            string OKChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
            name = name.Trim().ToLowerInvariant();
            StringBuilder sb = new StringBuilder();
            foreach (char c in name.ToCharArray())
                if (OKChars.Contains(c.ToString()))
                    sb.Append(c);
            string name2 = sb.ToString();
            name2 = name2.Replace(" ", "-");
            while (name2.Contains("--"))
                name2 = name2.Replace("--", "-");
            while (name2.Contains("__"))
                name2 = name2.Replace("__", "_");
            return HttpContext.Current.Server.UrlEncode(name2);
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
    }
}
