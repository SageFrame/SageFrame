#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SageFrame.Web.Utilities;

#endregion


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
            ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", UserName));

            List<TemplateInfo> lstTemplate = new List<TemplateInfo>();
            SqlDataReader reader = null;
            try
            {

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
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
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
            ParamCollInput.Add(new KeyValuePair<string, object>("@UserName", obj.AddedBy));           
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
