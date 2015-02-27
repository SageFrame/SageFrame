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
using System.Data.SqlClient;
using SageFrame.Web.Utilities;

namespace SageFrame.Core.TemplateManagement
{
    public class TemplateDataProvider
    {
        public static List<TemplateInfo> GetTemplateList(int PortalID, string UserName)
        {
            string sp = "[dbo].[sp_TemplateGetList]";
            SQLHandler sagesql = new SQLHandler();

            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", UserName));

            List<TemplateInfo> lstTemplate = new List<TemplateInfo>();
            try
            {
                SqlDataReader reader;
                reader = sagesql.ExecuteAsDataReader(sp, ParamCollInput);
                while (reader.Read())
                {
                    TemplateInfo obj = new TemplateInfo();
                    obj.TemplateID = int.Parse(reader["TemplateID"].ToString());
                    obj.TemplateTitle = reader["TemplateTitle"].ToString();
                    obj.PortalID = int.Parse(reader["PortalID"].ToString());
                    obj.Author = reader["Author"].ToString();
                    obj.AuthorURL = reader["AuthorURL"].ToString();
                    obj.Description = reader["Description"].ToString();
                    lstTemplate.Add(obj);
                }
                reader.Close();
                return lstTemplate;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool AddTemplate(TemplateInfo obj)
        {
            string sp = "[dbo].[sp_TemplateAdd]";
            SQLHandler sagesql = new SQLHandler();

            List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
            ParamCollInput.Add(new KeyValuePair<string, object>("@TemplateTitle", obj.TemplateTitle));
            ParamCollInput.Add(new KeyValuePair<string, object>("@Author",obj.Author));
            ParamCollInput.Add(new KeyValuePair<string, object>("@Description", obj.Description));
            ParamCollInput.Add(new KeyValuePair<string, object>("@AuthorURL", obj.AuthorURL));
            ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
            ParamCollInput.Add(new KeyValuePair<string, object>("@Username", obj.AddedBy));           
            try
            {              
                sagesql.ExecuteNonQuery(sp, ParamCollInput);
                return true;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
