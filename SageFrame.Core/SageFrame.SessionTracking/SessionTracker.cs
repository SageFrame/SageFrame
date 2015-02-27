#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;

#endregion

namespace SageFrame.Web
{
    [Serializable]
    public class SessionTracker
    {
        private string _browser = string.Empty;
        private string _crawler = string.Empty;
        private ArrayList _pages = new ArrayList();
        private string _sessionTrackerID;
        private DateTime _expires;
        private string _visitCount;
        private string _userHostAddress;
        private string _userAgent;
        private string _originalReferrer;
        private string _originalURL;
        private string _sessionReferrer;
        private string _sessionURL;
        private string _portalID;
        private string _username;
        private string _insertSessionTrackerPages;

        public string SessionTrackerID
        {
            get
            {
                return this._sessionTrackerID;
            }
            set
            {
                this._sessionTrackerID = value;
            }
        }

        public int VisitCount
        {
            get
            {
                return int.Parse(this._visitCount);
            }
        }

        public string OriginalReferrer
        {
            get
            {
                return this._originalReferrer;
            }
        }

        public string OriginalURL
        {
            get
            {
                return this._originalURL;
            }
        }

        public string SessionReferrer
        {
            get
            {
                return this._sessionReferrer;
            }
        }

        public string SessionURL
        {
            get
            {
                return this._sessionURL;
            }
        }

        public string SessionUserHostAddress
        {
            get
            {
                return this._userHostAddress;
            }
        }

        public string SessionUserAgent
        {
            get
            {
                return this._userAgent;
            }
        }

        public ArrayList Pages
        {
            get
            {
                return this._pages;
            }
        }

        public string Browser
        {
            get
            {
                return this._browser;
            }
        }

        public string Crawler
        {
            get
            {
                return this._crawler;
            }
        }

        public string PortalID
        {
            get
            {
                return this._portalID;
            }
            set
            {
                this._portalID = value;
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string InsertSessionTrackerPages
        {
            get
            {
                return this._insertSessionTrackerPages;
            }
            set
            {
                this._insertSessionTrackerPages = value;
            }
        }

        public SessionTracker()
        {
            try
            {
                this._expires = DateTime.Now.AddYears(1);
                this.IncrementVisitCount();
                this._userHostAddress = ((object)HttpContext.Current.Request.UserHostAddress).ToString();
                if (HttpContext.Current.Request.UserAgent != null)
                    this._userAgent = ((object)HttpContext.Current.Request.UserAgent).ToString();
                if (HttpContext.Current.Request.UrlReferrer != (Uri)null)
                {
                    this.SetOriginalReferrer(HttpContext.Current.Request.UrlReferrer.ToString());
                    this._sessionReferrer = HttpContext.Current.Request.UrlReferrer.ToString();
                }
                if (HttpContext.Current.Request.Url != (Uri)null)
                {
                    this.SetOriginalURL(HttpContext.Current.Request.Url.ToString());
                    this._sessionURL = HttpContext.Current.Request.Url.ToString();
                }
                this._browser = HttpContext.Current.Request.Browser.Browser != null ? ((object)HttpContext.Current.Request.Browser.Browser).ToString() : string.Empty;
                this._crawler = HttpContext.Current.Request.Browser.Crawler.ToString();
            }
            catch
            {
            }
        }

        public void AddPage(string pageName)
        {
            this._pages.Add((object)new SessionTrackerPage()
            {
                PageName = pageName,
                Time = DateTime.Now
            });
        }

        public void IncrementVisitCount()
        {
            this._visitCount = HttpContext.Current.Request.Cookies.Get("VisitCount") != null ? (int.Parse(((object)HttpContext.Current.Request.Cookies.Get("VisitCount").Value).ToString()) + 1).ToString() : "1";
            this.addCookie("VisitCount", this._visitCount);
        }

        public void SetOriginalReferrer(string val)
        {
            if (HttpContext.Current.Request.Cookies.Get("OriginalReferrer") != null)
            {
                this._originalReferrer = HttpContext.Current.Request.Cookies.Get("OriginalReferrer").Value;
            }
            else
            {
                this.addCookie("OriginalReferrer", val);
                this._originalReferrer = val;
            }
        }

        public void SetOriginalURL(string val)
        {
            if (HttpContext.Current.Request.Cookies.Get("OriginalURL") != null)
            {
                this._originalURL = HttpContext.Current.Request.Cookies.Get("OriginalURL").Value;
            }
            else
            {
                this.addCookie("OriginalURL", val);
                this._originalURL = val;
            }
        }

        private void addCookie(string key, string value)
        {
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(key, value)
            {
                Expires = this._expires
            });
        }
    }
}
