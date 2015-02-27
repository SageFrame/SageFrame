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

namespace SageFrame.ErrorLog
{
   public class ErrorLogDataProvider
   {
       public static void ClearLog(int PortalID)
       {
           string sp = "[dbo].[sp_LogClear]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }

       public static void DeleteLogByLogID(int ID, int PortalID, string UserName)
       {

           string sp = "[dbo].[sp_LogDeleteByLogID]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
               ParamCollInput.Add(new KeyValuePair<string, object>("@LogID", ID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@DeletedBy", UserName));
               sagesql.ExecuteNonQuery(sp, ParamCollInput);
           }
           catch (Exception)
           {

               throw;
           }
       }
      
       public static int InsertLog(int logTypeID, int severity, string message, string exception, string clientIPAddress, string pageURL, bool isActive, int portalID, string addedBy)
       {
           string sp = "[dbo].[sp_LogInsert]";
           SQLHandler sagesql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
              
               ParamCollInput.Add(new KeyValuePair<string, object>("@LogTypeID", logTypeID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Severity", severity));
               ParamCollInput.Add(new KeyValuePair<string, object>("@Message", message));

               ParamCollInput.Add(new KeyValuePair<string, object>("@Exception", exception));
               ParamCollInput.Add(new KeyValuePair<string, object>("@ClientIPAddress", clientIPAddress));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PageURL", pageURL));
               ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", isActive));
               ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", portalID));
               ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", addedBy));

               return sagesql.ExecuteNonQuery(sp, ParamCollInput, "@LogID");


           }
           catch (Exception)
           {

               throw;
           }

       }
   }
}
