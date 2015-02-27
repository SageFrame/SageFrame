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
using System.Data;
using System.Data.SqlClient;
using SageFrame.Web;


namespace SageFrame.Templating
{
    public class TemplateDataProvider
    {
        public static void ActivateTemplate(string TemplateName, int PortalID)
        {
             
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@TemplateName", TemplateName));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", true));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
          
            SQLHandler sagesql = new SQLHandler();
            sagesql.ExecuteNonQuery("usp_sftemplate_activate", ParaMeterCollection);

       
        }

        public static TemplateInfo GetActiveTemplate(int PortalID)
        {   
            SQLHandler sagesql = new SQLHandler();
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            return (sagesql.ExecuteAsObject<TemplateInfo>("usp_sftemplate_GetActiveTemplate",ParaMeterCollection));
        }
        public static List<TemplateInfo> GetPortalTemplates()
        {
            SQLHandler sagesql = new SQLHandler();
            return (sagesql.ExecuteAsList<TemplateInfo>("usp_TemplateGetPortalTemplate"));
        }


        public static void UpdActivateTemplate(string TemplateName, string conn)
        {

            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("usp_sftemplate_updactive", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@TemplateName", TemplateName);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public static SettingInfo GetSettingByKey(SettingInfo objSetting)
        {
            string sp = "[dbo].[usp_DashboardGetSettingByKey]";
            SQLHandler sagesql = new SQLHandler();

            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@SettingKey", objSetting.SettingKey));
            ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", objSetting.UserName));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", objSetting.PortalID));
            try
            {
                return (sagesql.ExecuteAsObject<SettingInfo>(sp, ParamCollInput));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
