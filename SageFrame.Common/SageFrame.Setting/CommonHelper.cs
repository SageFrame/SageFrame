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
using System.Data;
using System.Data.Linq;
using SageFrame.Setting;
using System.Xml;
using System.Text;
using SageFrame.Common.SageFrame.Setting;
/// <summary>
/// Summary description for CommonHelper
/// </summary>
/// 
namespace SageFrame.Web
{
    public static class CommonHelper
    {      
        public static SettingDataContext dbSetting = new SettingDataContext(SystemSetting.SageFrameConnectionString);
        public static string ServerVariables(string Name)
        {
            string tmpS = String.Empty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables[Name] != null)
                {

                    tmpS = HttpContext.Current.Request.ServerVariables[Name].ToString();

                }
            }
            catch
            {
                tmpS = String.Empty;
            }
            return tmpS;
        }

        public static void EnsureSSL(bool isSecureConnect, string redirectPath)
        {
            if (!HttpContext.Current.Request.IsSecureConnection)
            {
                if (!HttpContext.Current.Request.Url.IsLoopback) //Don't check when in development mode (i.e. localhost)
                {
                    ReloadCurrentPage(isSecureConnect, redirectPath);
                }
            }
        }

        public static void ReloadCurrentPage(bool UseSSL, string redirectPath)
        {
            string result = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_HOST"] != null)
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            }
            result = "http://" + result;
            if (!result.EndsWith("/"))
            {
                result += "/";
            }

            if (UseSSL)
            {
                result = result.Replace("http:", "https:");
                result = result.Replace("www.www", "www");
            }

            if (result.EndsWith("/"))
            {
                result = result.Substring(0, result.Length - 1);
            }
            string URL = result + HttpContext.Current.Request.RawUrl;
            HttpContext.Current.Response.Redirect(URL);
        }

        public static string GetStoreHost(bool UseSSL,int PortalID)
        {
            string result = "http://" + ServerVariables("HTTP_HOST");
            if (!result.EndsWith("/"))
                result += "/";

            if (UseSSL)
            {
                string str = dbSetting.sp_SettingPortalBySettingID((int)SettingKey.Common_SharedSSL, PortalID).SingleOrDefault().Value;
                if (!String.IsNullOrEmpty(str))
                {
                    result = str;
                }
                else
                {
                    result = result.Replace("http:/", "https:/");
                    result = result.Replace("www.www", "www");
                }
            }

            if (!result.EndsWith("/"))
                result += "/";

            return result;
        }

        public static string GetStoreLocation(bool UseSSL, int PortalID)
        {
            string result = GetStoreHost(UseSSL, PortalID);
            if (result.EndsWith("/"))
                result = result.Substring(0, result.Length - 1);
            result = result + HttpContext.Current.Request.ApplicationPath;
            if (!result.EndsWith("/"))
                result += "/";

            return result;
        }

        public static string GetStoreAdminLocation(bool UseSSL, int PortalID)
        {
            string result = GetStoreLocation(UseSSL, PortalID);
            result += "Administration/";

            return result;
        }

        public static string QueryString(string Name)
        {
            string result = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[Name] != null)
                result = HttpContext.Current.Request.QueryString[Name].ToString();
            return result;
        }

        public static int QueryStringInt(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            int result;
            Int32.TryParse(resultStr, out result);
            return result;
        }

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <returns></returns>
        public static string GetThisPageURL(bool includeQueryString, int PortalID)
        {
            string URL = string.Empty;
            if (HttpContext.Current == null)
                return URL;

            if (includeQueryString)
            {
                string storeHost = GetStoreHost(false, PortalID);
                if (storeHost.EndsWith("/"))
                    storeHost = storeHost.Substring(0, storeHost.Length - 1);
                URL = storeHost + HttpContext.Current.Request.RawUrl;
            }
            else
            {
                URL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
            }
            return URL;
        }

        public static string GetCurrentVersion(int PortalID)
        {
            return dbSetting.sp_SettingPortalBySettingID((int)SettingKey.Common_CurrentVersion, PortalID).SingleOrDefault().Value;
        }

        public static void WriteResponseXML(string xml, string Filename)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                ((XmlDeclaration)document.FirstChild).Encoding = "utf-8";
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "utf-8";
                response.ContentType = "text/xml";
                response.AddHeader("content-disposition", string.Format("attachment; filename={0}", Filename));
                response.BinaryWrite(Encoding.UTF8.GetBytes(document.InnerXml));
                response.End();
            }
        }

        public static DateTime AvailableStartDateTime = DateTime.Parse("01/01/2000");
        public static DateTime AvailableEndDateTime = DateTime.Parse("01/01/2099");

        public static string FormatLargeString(string str)
        {
            if (str.Length > 100)
            {
                str = str.Remove(100);
            }
            return str;
        }

        public static string Country = "Country";
        public static string Region = "Region";
        public static string City = "Region";
        public static string DefaultPage = "Default.aspx";
        public static string LogInPage = "Login.aspx";
        public static string SelectedCountryName = "United States";

        public static bool GetSettingValueBoolean(int SettingID,int PortalID)
        {
            return bool.Parse(dbSetting.sp_SettingPortalBySettingID(SettingID, PortalID).SingleOrDefault().Value);
        }

        public static string GetSettingValue(int SettingID, int PortalID)
        {
            return dbSetting.sp_SettingPortalBySettingID(SettingID, PortalID).SingleOrDefault().Value;
        }

        public static string ShortTimeReturn(System.Nullable<DateTime> ndate)
        {
            string retStr = string.Empty;
            if (ndate != null)
            {
                retStr = DateTime.Parse(ndate.ToString()).ToShortDateString();
            }
            return retStr;
        }

        public static bool Contains(string[] arrColl, string parentString)
        {
            bool status=false;
            foreach (string word in arrColl)
            {
                status = parentString.Contains(word) ? true : false;               
            }
            return status;
        }
    }
}
