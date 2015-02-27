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
using System.Data.SqlClient;
using System.Data;

namespace SageFrame.Security.Helpers
{
    public class SageFrameSQLHelper:SQLHandler
    {
        public SageFrameSQLHelper():base()
        {
        }

        public List<KeyValuePair<int, string>> ExecuteNonQueryWithMultipleOutput(string StroredProcedureName, List<KeyValuePair<string, object>> InputParamColl, List<KeyValuePair<string, object>> OutPutParamColl)
        {
            SqlConnection SQLConn = new SqlConnection(base.connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                foreach (KeyValuePair<string,object> kvp in InputParamColl)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }

                foreach (KeyValuePair<string, object> kvp in OutPutParamColl)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    sqlParaMeter.Direction = ParameterDirection.InputOutput;
                    sqlParaMeter.Size = 256;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }               
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                List<KeyValuePair<int, string>> lstRetValues = new List<KeyValuePair<int, string>>();
                for (int i = 0; i < OutPutParamColl.Count; i++)
                {
                    lstRetValues.Add(new KeyValuePair<int, string>(i, SQLCmd.Parameters[InputParamColl.Count+i].Value.ToString()));
                }
                return lstRetValues;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }
        
    }
}
