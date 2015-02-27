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
using SageFrame.Web.Utilities;
using System.Data.SqlClient;
using System.Xml;
#endregion

namespace SageFrame.SEOExtension
{
   public class SiteMapDataProvider
    {
       

       public static List<SiteMapInfo> GetSiteMap(string prefix, bool IsActive, bool IsDeleted, int PortalID, string Username, bool IsVisible, bool IsRequiredPage)
       {

           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@prefix", prefix));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", Username));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsVisible", IsVisible));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsRequiredPage", IsRequiredPage));
           SqlDataReader reader = null;
           try
           {
               SQLHandler Objsql = new SQLHandler();

               reader = Objsql.ExecuteAsDataReader("[dbo].[sp_PageGetByCustomPrefix]", ParaMeterCollection);
               List<SiteMapInfo> lstSetting = new List<SiteMapInfo>();


               while (reader.Read())
               {


                   SiteMapInfo obj = new SiteMapInfo();
                   obj.PageID = reader["PageID"].ToString();
                   obj.PageName = reader["PageName"].ToString();
                   obj.TabPath = reader["TabPath"].ToString();
                   obj.SEOName = reader["SEOName"].ToString();
                   obj.LevelPageName = reader["LevelPageName"].ToString();
                   obj.Description = reader["Description"].ToString();
                   if (reader["UpdatedOn"].ToString() == string.Empty)
                   {
                       obj.UpdatedOn = DateTime.Parse(reader["AddedOn"].ToString());
                   }
                   else
                   {
                       obj.UpdatedOn = DateTime.Parse(reader["UpdatedOn"].ToString());
                   }
                   obj.AddedOn = DateTime.Parse(reader["AddedOn"].ToString());

                   lstSetting.Add(obj);
               }
               return lstSetting;
           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               if (reader != null)
               {
                   reader.Close();
               }
           }

       }

    }
}
