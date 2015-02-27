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
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using SageFrame.Web.Common.SEO;
using SageFrame.Web;
using SageFrame.RssReader;

public partial class Modules_LatestBlog_ctl_RSSReader : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IncludeCss("SageRssReader", "/Modules/SageRssReader/css/module.css");
        }
        GetDataFromServer();
    }

    private void GetDataFromServer()
    {
        try
        {
            string LastEdndent = "....";
            int MaxNumberofPosts = 30;
            int MaxDescriptions = 500;
            string strBlogURL = string.Empty;

            RSSReaderSettingValueController con = new RSSReaderSettingValueController();
            List<RSSReaderSettingValueInfo> objSettings = con.GetAllRssSettings(GetPortalID, Int32.Parse(SageUserModuleID), GetCurrentCultureName);
            if (objSettings != null)
            {
                int i = 0;
                foreach (RSSReaderSettingValueInfo rsSeting in objSettings)
                {
                    switch (rsSeting.SettingKey)
                    {
                        case "DisplayTitle":
                            litTitle.Text = rsSeting.SettingValue;
                            break;
                        case "LastEdndent":
                            LastEdndent = rsSeting.SettingValue;
                            break;
                        case "MaxNumberofPosts":
                            if (rsSeting.SettingValue != string.Empty)
                            {
                                MaxNumberofPosts = Int32.Parse(rsSeting.SettingValue);
                            }
                            break;
                        case "MaxDescriptionsLength":
                            if (rsSeting.SettingValue != string.Empty)
                            {
                                MaxDescriptions = Int32.Parse(rsSeting.SettingValue);
                            }
                            break;
                        case "RssURL":
                            strBlogURL = rsSeting.SettingValue;
                            break;
                    }
                    i++;
                    if (i > 5)
                    {
                        break;
                    }
                }
            }

            string strRssContent = ProcessRSSItem(strBlogURL, MaxNumberofPosts, MaxDescriptions, LastEdndent);
            litBlogContnent.Text = strRssContent;
        }
        catch (Exception ex)
        {
            ProcessException(ex);
        }
    }

    private void LoadSettings()
    {
        
    }


    /// <summary>
    /// For Given URL Create the reqest and format the result in predefind format
    /// </summary>
    /// <param name="rssURL"></param>
    /// <param name="MaxNumberofPosts"></param>
    /// <param name="MaxDescLength"></param>
    /// <param name="LastEdndent"></param>
    /// <returns></returns>
    public string ProcessRSSItem(string rssURL, int MaxNumberofPosts, int MaxDescLength, string LastEdndent)
    {

        try
        {
            WebRequest myRequest = WebRequest.Create(rssURL);
            WebResponse myResponse = myRequest.GetResponse();
            Stream rssStream = myResponse.GetResponseStream();

            #region "Holding Response in XML Data"

            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);
            XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
            string title = "";
            string link = "";
            string description = "";

            #endregion

            StringBuilder strB = new StringBuilder();

            #region "Setting Counter"

            int loopCounter = MaxNumberofPosts;
            if (MaxNumberofPosts > rssItems.Count)
            {
                loopCounter = rssItems.Count;
            }

            #endregion

            #region "Formating Data"

            for (int i = 0; i < loopCounter; i++)
            {
                XmlNode rssDetail;
                rssDetail = rssItems.Item(i).SelectSingleNode("title");
                if (rssDetail != null)
                {
                    title = rssDetail.InnerText;
                }
                else
                {
                    title = "";
                }
                rssDetail = rssItems.Item(i).SelectSingleNode("link");
                if (rssDetail != null)
                {
                    link = rssDetail.InnerText;
                }
                else
                {
                    link = "";
                }
                rssDetail = rssItems.Item(i).SelectSingleNode("description");
                if (rssDetail != null)
                {
                    description = rssDetail.InnerText;
                }
                else
                {
                    description = "";
                }
                strB.Append("<div class=\"sfRsscontent\"><p><h3>");
                strB.Append("<a href='" + link + "' target='new'>" + title + "</a>");
                strB.Append("</h3>");
                string strTemp = RemoveUnwantedHTMLTags(description);
                if (strTemp.Length > MaxDescLength)
                {
                    strTemp = strTemp.Remove(MaxDescLength);
                    strTemp += LastEdndent;
                }
                else
                {
                    strTemp += LastEdndent;
                }
                strB.Append(strTemp + "<p></div>");

            }

            #endregion
            return strB.ToString();
        }
        catch (Exception e)
        {
            throw e;
        }

    }

    /// <summary>
    /// Remove all html tags from given string and return plain string
    /// </summary>
    /// <param name="HTMLString"></param>
    /// <returns></returns>
    private string RemoveUnwantedHTMLTags(string HTMLString)
    {
        try
        {
            SEOHelper seoHelper = new SEOHelper();
            return seoHelper.RemoveUnwantedHTMLTAG(HTMLString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
