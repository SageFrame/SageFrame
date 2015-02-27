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
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
namespace SageFrame.Web
{
    public class SessionTracker
    {
        private string _sessionTrackerID;
        private HttpContext _context;
        private System.DateTime _expires;
        private string _visitCount;
        private string _userHostAddress;
        private string _userAgent;
        private string _originalReferrer;
        private string _originalURL;
        private string _sessionReferrer;
        private string _sessionURL;
        private string _portalID;
        private string _username;
        private HttpBrowserCapabilities _browser;
        private ArrayList _pages = new ArrayList();
        private string _insertSessionTrackerPages;

        public SessionTracker()
        {
            try
            {
                _context = HttpContext.Current;
                _expires = DateTime.Now.AddYears(1);
                IncrementVisitCount();
                _userHostAddress = _context.Request.UserHostAddress.ToString();
                if (_context.Request.UserAgent != null)
                {
                    _userAgent = _context.Request.UserAgent.ToString();
                }

                if ((_context.Request.UrlReferrer != null))
                {
                    SetOriginalReferrer(_context.Request.UrlReferrer.ToString());
                    _sessionReferrer = _context.Request.UrlReferrer.ToString();
                }

                if ((_context.Request.Url != null))
                {
                    SetOriginalURL(_context.Request.Url.ToString());
                    _sessionURL = _context.Request.Url.ToString();
                }
                _browser = _context.Request.Browser;
            }
            catch
            {
            }

        }


        public void AddPage(string pageName)
        {
            SessionTrackerPage pti = new SessionTrackerPage();
            pti.PageName = pageName;
            pti.Time = DateTime.Now;

            _pages.Add(pti);
        }

        public void IncrementVisitCount()
        {
            const string KEY = "VisitCount";

            if ((_context.Request.Cookies.Get(KEY) == null))
            {
                _visitCount = "1";
            }
            else
            {
                _visitCount = (int.Parse(_context.Request.Cookies.Get(KEY).Value.ToString()) + 1).ToString();
            }

            addCookie(KEY, _visitCount);
        }

        public void SetOriginalReferrer(string val)
        {
            const string KEY = "OriginalReferrer";

            if ((_context.Request.Cookies.Get(KEY) != null))
            {
                _originalReferrer = _context.Request.Cookies.Get(KEY).Value;
            }
            else
            {
                addCookie(KEY, val);
                _originalReferrer = val;
            }
        }

        public void SetOriginalURL(string val)
        {
            const string KEY = "OriginalURL";
            if ((_context.Request.Cookies.Get(KEY) != null))
            {
                _originalURL = _context.Request.Cookies.Get(KEY).Value;
            }
            else
            {
                addCookie(KEY, val);
                _originalURL = val;
            }
        }

        private void addCookie(string key, string value)
        {
            HttpCookie cookie = default(HttpCookie);
            cookie = new HttpCookie(key, value);
            cookie.Expires = _expires;
            _context.Response.Cookies.Set(cookie);
        }


        #region "Properties"

        public string SessionTrackerID
        {
            get { return _sessionTrackerID; }
            set { _sessionTrackerID = value; }
        }
        public int VisitCount
        {
            get { return int.Parse(_visitCount); }
        }

        public string OriginalReferrer
        {
            get { return _originalReferrer; }
        }

        public string OriginalURL
        {
            get { return _originalURL; }
        }

        public string SessionReferrer
        {
            get { return _sessionReferrer; }
        }

        public string SessionURL
        {
            get { return _sessionURL; }
        }

        public string SessionUserHostAddress
        {
            get { return _userHostAddress; }
        }

        public string SessionUserAgent
        {
            get { return _userAgent; }
        }

        public ArrayList Pages
        {
            get { return _pages; }
        }

        public HttpBrowserCapabilities Browser
        {
            get { return _browser; }
        }

        public string PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string InsertSessionTrackerPages
        {
            get { return _insertSessionTrackerPages; }
            set { _insertSessionTrackerPages = value; }
        }
        #endregion
    }
}
