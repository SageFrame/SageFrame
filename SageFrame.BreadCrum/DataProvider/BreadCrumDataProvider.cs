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
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.BreadCrum
{
    public class BreadCrumDataProvider
    {

        public static BreadCrumInfo GetBreadCrumb(string SEOName, int PortalID, int MenuId)
        {
            try
            {

                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SEOName", SEOName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                if (MenuId != 0)
                {
                    ParaMeterCollection.Add(new KeyValuePair<string, object>("@MenuID", MenuId));
                    SQLHandler SQLH = new SQLHandler();
                    SQLH.ExecuteNonQuery("[dbo].[usp_BreadCrumbGetFromMenuItem]", ParaMeterCollection);
                    return SQLH.ExecuteAsObject<BreadCrumInfo>("usp_BreadCrumbMenuItemPath");
                }
                else
                {
                    SQLHandler SQLH = new SQLHandler();
                    return SQLH.ExecuteAsObject<BreadCrumInfo>("usp_BreadCrumbGetFromPageName", ParaMeterCollection);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
