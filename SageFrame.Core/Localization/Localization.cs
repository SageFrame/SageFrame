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
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace SageFrame.Localization
{
    public class Localization
    {
        public Localization()
        {
        }

        public static string ApplicationResourceDirectory
        {
            get
            {
                return "~/XMLMessage";
            }
        }

        public static string SystemLocale
        {
            get
            {
                return "en-US";
            }
        }
        public static string TimezonesFile
        {
            get
            {
                return (ApplicationResourceDirectory + "/TimeZones.xml");
            }
        }
        public static NameValueCollection GetTimeZones(string language)
        {
            string cacheKey = ("sageframe-" + (language + "-timezones"));
            NameValueCollection timeZones= new NameValueCollection();
            string filePath = HttpContext.Current.Server.MapPath("~/XMLMessage/TimeZones." +language + ".xml");
            if ((File.Exists(filePath) == false))
            {
                filePath = HttpContext.Current.Server.MapPath("~/XMLMessage/TimeZones.en-US.xml");
            }
            try
            {
                XmlDocument d = new XmlDocument();
                d.Load(filePath);
                foreach (XmlNode n in d.SelectSingleNode("root").ChildNodes)
                {
                    if ((n.NodeType != XmlNodeType.Comment))
                    {
                        timeZones.Add(n.Attributes["name"].Value, n.Attributes["key"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return timeZones;
        }
    }
}
