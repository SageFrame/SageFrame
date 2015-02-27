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
using Twitter;
using SageFrame.SageFrameClass;
using SageFrame.Modules.Admin.HostSettings;
using SageFrame.Shared;
using SageFrame.Web;
using SageFrame.Localization;
using SageFrame.Framework;
using System.Collections.Specialized;
using SageFrame.Web.Utilities;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

public partial class Modules_Twitter_TwittsViewer : BaseAdministrationUserControl
{
    const string twitterUrl = "https://twitter.com/statuses/user_timeline.xml?screen_name={0}&count={1}";

    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                
                IncludeCss("TwitterDeck", "/Modules/TwitterDeck/css/module.css");
             
                FetchTwitts();
            }
    }

    protected void FetchTwitts()
    {
        try
        {
            string dt = DateTime.Now.ToString();
            TwitterSettingsInfo twtData = new TwitterSettingsInfo();
            TwitterSqlhandler twtSql = new TwitterSqlhandler();
            int userModuleID;
            bool status = int.TryParse(SageUserModuleID, out userModuleID);

            twtData = twtSql.GetTwitterSettingValues(userModuleID, GetPortalID);
            string title = string.Empty;
            title = twtData.Title;
            string screenName = twtData.ScreenName.ToString();
            int count = twtData.Count;
            string twtUrl = string.Format(twitterUrl, screenName, count);

            WebRequest reqTwitts = WebRequest.Create(twtUrl);
            WebResponse twtResp = reqTwitts.GetResponse();
            if (twtResp != null)
            {
                XmlDocument twtXdoc = new XmlDocument();
                twtXdoc.Load(twtResp.GetResponseStream());
                twtResp.Close();
                reqTwitts.Abort();
                XmlElement root = twtXdoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/statuses/status");
                StringBuilder strTwittsViewer = new StringBuilder();

                strTwittsViewer.Append("<h2>" + title + "</h2>");
                foreach (XmlNode node in nodes)
                {
                    DateTime diffDate = DateTime.ParseExact(node["created_at"].InnerText, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture);
                    strTwittsViewer.Append("<p>");
                    strTwittsViewer.Append(ConvertUrlsToLinks(node["text"].InnerText));
                    strTwittsViewer.Append("<span> about ");
                    TimeSpan ts = DateTime.Now - diffDate;
                    if (ts.Days > 0)
                    {
                        strTwittsViewer.Append(ts.Days);
                        strTwittsViewer.Append(" days ago");
                    }
                    else if (ts.Hours > 0)
                    {
                        strTwittsViewer.Append(ts.Hours);
                        strTwittsViewer.Append(" hours ago");
                    }
                    else if (ts.Minutes > 0)
                    {
                        strTwittsViewer.Append(ts.Minutes);
                        strTwittsViewer.Append(" minutes ago");
                    }
                    else
                    {
                        strTwittsViewer.Append(ts.Seconds);
                        strTwittsViewer.Append(" seconds ago");
                    }
                    strTwittsViewer.Append(" via </span>");
                    strTwittsViewer.Append(node["source"].InnerText);
                    strTwittsViewer.Append("</p>");
                }
                ltrlTwitts.Text = strTwittsViewer.ToString();
            }
        }
        catch
        {

        }
    }

    private string ConvertUrlsToLinks(string msg)
    {
        string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
        Regex r = new Regex(regex, RegexOptions.IgnoreCase);
        return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
    }
}
