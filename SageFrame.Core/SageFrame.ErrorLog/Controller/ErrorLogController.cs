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
using System.Web;
using System.Data.SqlClient;

namespace SageFrame.ErrorLog
{
    public class ErrorLogController
    {
        public static void ClearLog(int PortalID)
        {
            try
            {
                ErrorLogDataProvider.ClearLog(PortalID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void DeleteLogByLogID(int ID, int PortalID, string UserName)
        {
            try
            {
                ErrorLogDataProvider.DeleteLogByLogID(ID, PortalID, UserName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int InsertLog(int logTypeID, int severity, string message, string exception, string clientIPAddress, string pageURL, bool isActive, int portalID, string addedBy)
        {
            try
            {
               return  ErrorLogDataProvider.InsertLog(logTypeID, severity, message, exception, clientIPAddress, pageURL, isActive, portalID, addedBy);
            }
            //catch (SqlException sqex)
            //{
            //    HttpContext.Current.Response.Redirect("~/DatabaseError.htm");
            //    throw sqex;

            //}
            catch (Exception)
            {

                throw;
            }
        }

    }
}
