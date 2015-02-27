using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using SageFrame.Web;
using System.Web;
using SageFrame.News;
namespace SageFrame.News
{
    public class NewsRss : BaseUserControl
    {
        public void GetRSS(int userModuleID, string URL, int TotalCount)
        {
            
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/xml";

            XmlTextWriter RssWriter = new XmlTextWriter(HttpContext.Current.Response.OutputStream, Encoding.UTF8);

            RssWriter.WriteStartDocument();
            RssWriter.WriteStartElement("rss");
            RssWriter.WriteAttributeString("version", "2.0");
            RssWriter.WriteStartElement("channel");
            RssWriter.WriteElementString("title", "SageFrame News");
            RssWriter.WriteElementString("link", "http://www.sageframe.com");
            RssWriter.WriteElementString("description", "Latest News Published on sageframe.com.");
            RssWriter.WriteElementString("copyright", "Copyright 2010 sageframe.com. All rights reserved.");

            //Connect database to get the data
            RSSForNews(userModuleID, URL, RssWriter, TotalCount);

            RssWriter.WriteEndElement();
            RssWriter.WriteEndElement();
            RssWriter.WriteEndDocument();
            RssWriter.Flush();
            RssWriter.Close();
            HttpContext.Current.Response.End();

        }

        private void RSSForNews(int UserModuleID, string URL, XmlTextWriter RssWriter, int TotalCount)
        { 

            
            NewsDataContext db = new NewsDataContext(SystemSetting.SageFrameConnectionString);
            var Newslist = db.sp_NewsRSSList(UserModuleID, GetPortalID,TotalCount);

            foreach (sp_NewsRSSListResult News in Newslist)
            {
                //Build Item tags with the data from database

                RssWriter.WriteStartElement("item");

                RssWriter.WriteElementString("title", News.NewsTitle + Environment.NewLine);

               // RssWriter.WriteElementString("Short Description", News.NewsShortDescription + Environment.NewLine);
                RssWriter.WriteElementString("description", News.NewsLongDescription + Environment.NewLine);

                if (URL.Contains("?"))
                {
                    RssWriter.WriteElementString("link", URL + "&NewsID=" + News.NewsID);

                }
                else
                {
                    RssWriter.WriteElementString("link", URL + "?NewsID=" + News.NewsID);

                }

                RssWriter.WriteElementString("pubDate", News.NewsDate.ToString());
             //   RssWriter.WriteElementString("Added By", News.AddedBy);

                RssWriter.WriteEndElement();
            }
        }

    }
}
