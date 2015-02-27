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

namespace SageFrame.ModuleControls
{
    public class ModuleControlDataProvider
    {
        public static int GetModuleID(int UserModuleID)
        {
            SQLHandler Objsql = new SQLHandler();
           try
           {
               List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
               ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
               SQLHandler sqlh = new SQLHandler();
               int ModuleID = 0;
               ModuleID = sqlh.ExecuteAsScalar<int>("[dbo].[usp_ModuleControlGetModuleIdFromUserModuleId]", ParaMeterCollection);
               return ModuleID;
           }
           catch(Exception ex)
           {
               throw ex;
           
           }
        }
       
        public static string GetModuleName(int UserModuleID)
        {
            SQLHandler Objsql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                SQLHandler sqlh = new SQLHandler();
                string ModuleName = "";
                ModuleName = sqlh.ExecuteAsScalar<string>("[dbo].[usp_ModuleControlGetModuleNameFromUserModuleId]", ParaMeterCollection);
                return ModuleName;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static List<ModuleControlInfo> GetControlType(int ModuleDefID)
        {
            List<ModuleControlInfo> lstControl = new List<ModuleControlInfo>();
            string StoredProcedureName = "[dbo].[usp_ModuleControlGetControlTypeFromModuleID]";
            SQLHandler sqlh = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@ModuleDefID", ModuleDefID));
            
            try
            {
                lstControl = sqlh.ExecuteAsList<ModuleControlInfo>(StoredProcedureName, ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstControl;
        }

    }
}
