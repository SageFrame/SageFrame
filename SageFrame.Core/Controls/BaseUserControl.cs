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
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SageFrame.ErrorLog;
using SageFrame.Web;
using SageFrame.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using SageFrame.Web.Common.SEO;
using SageFrame.Web.Utilities;
using System.Collections;
/// <summary>
/// Summary description for BaseUserControl
/// </summary>
/// 
namespace SageFrame.Web
{
    public class BaseUserControl : SageUserControl
    {
        public BaseUserControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected void ProcessException(Exception exc)
        {

            int inID = 0;
            inID = ErrorLogController.InsertLog((int)SageFrame.Web.SageFrameEnums.ErrorType.AdministrationArea, 11, exc.Message, exc.ToString(),
                HttpContext.Current.Request.UserHostAddress, Request.RawUrl, true, GetPortalID, GetUsername);

            SageFrameConfig pagebase = new SageFrameConfig();
            if (pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseCustomErrorMessages))
            {
                ShowMessage(SageMessageTitle.Exception.ToString(), exc.Message, exc.ToString(), SageMessageType.Error);
            }

        }

        public void ProcessCancelRequest(string RedirectUrl)
        {
            try
            {
                
                ProcessCancelRequestBase(RedirectUrl);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public void ProcessSourceControlUrl(string rawUrl, string controlPath, string parameter)
        {
            //try
            //{                
                ProcessSourceControlUrlBase(rawUrl, controlPath, parameter);
            //}
            //catch (Exception ex)
            //{
            //    ProcessException(ex);
            //}
        }
        
    }
}
