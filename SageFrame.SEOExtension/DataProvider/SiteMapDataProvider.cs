using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;
using System.Data.SqlClient;
using System.Xml;

namespace SageFrame.SEOExtension
{
   public class SiteMapDataProvider
    {
       

       public static List<SiteMapInfo> GetSiteMap(string prefix, bool IsActive, bool IsDeleted, int PortalID, string Username, bool IsVisible, bool IsRequiredPage)
       {
           //"---", 1, 0, 1, 'superuser', 1, 0
           List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@prefix", prefix));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsDeleted", IsDeleted));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", Username));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsVisible", IsVisible));
           ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsRequiredPage", IsRequiredPage));

           try
           {
               SQLHandler Objsql = new SQLHandler();
               SqlDataReader reader;
               reader = Objsql.ExecuteAsDataReader("[dbo].[sp_PageGetByCustomPrefix]", ParaMeterCollection);
               List<SiteMapInfo> lstSetting = new List<SiteMapInfo>();


               while (reader.Read())
               {
                   //lstSetting.Add(new SiteMapInfo(reader["PageID"].ToString(), reader["PageName"].ToString(), reader["TabPath"].ToString(), reader["SEOName"].ToString(), reader["LevelPageName"].ToString(), reader["Description"].ToString(), Convert.ToDateTime(reader["UpdatedOn"]), Convert.ToDateTime(reader["AddedOn"])));

                   SiteMapInfo obj = new SiteMapInfo();
                   obj.PageID = reader["PageID"].ToString();
                   obj.PageName = reader["PageName"].ToString();
                   obj.TabPath = reader["TabPath"].ToString();
                   obj.SEOName = reader["SEOName"].ToString();
                   obj.LevelPageName = reader["LevelPageName"].ToString();
                   obj.Description= reader["Description"].ToString();
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

       }

    }
}
