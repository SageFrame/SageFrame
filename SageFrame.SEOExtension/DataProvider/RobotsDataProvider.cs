using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SageFrame.Web.Utilities;

namespace SageFrame.SEOExtension
{
    public class RobotsDataProvider
    {

        public static List<RobotsInfo> GetRobots(int PortalID)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();

            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));

            try
            {
                SQLHandler Objsql = new SQLHandler();
                SqlDataReader reader;
                reader = Objsql.ExecuteAsDataReader("[dbo].[usp_SeoGetRobots]", ParaMeterCollection);
                List<RobotsInfo> lstRobots = new List<RobotsInfo>();

                while (reader.Read())
                {
                    lstRobots.Add(new RobotsInfo(reader["PageName"].ToString(), reader["TabPath"].ToString(), reader["SEOName"].ToString(), reader["Description"].ToString()));
                }
                return lstRobots;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void DeleteExistingRobots(int PortalID)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            try
            {
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("[dbo].[usp_SeoDeleteExistingRobots]", ParaMeterCollection);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void SaveRobotsPage(int PortalID, string UserAgent, string PagePath)
        {
           
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserAgent", UserAgent));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PagePath", PagePath));
                try
                {
                    SQLHandler sagesql = new SQLHandler();
                    sagesql.ExecuteNonQuery("[dbo].[usp_SeoSaveRobotsPage]", ParaMeterCollection);
                }
                catch (Exception)
                {

                    throw;
                }
        }
        public static List<RobotsInfo> GenerateRobots(string UserAgent)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserAgent", UserAgent));
            try
            {
                SQLHandler Objsql = new SQLHandler();
                SqlDataReader reader;
                reader = Objsql.ExecuteAsDataReader("usp_SeoGenerateRobots", ParaMeterCollection);
                List<RobotsInfo> lstRobots = new List<RobotsInfo>();
                while (reader.Read())
                {
                    lstRobots.Add(new RobotsInfo(int.Parse(reader["PortalID"].ToString()), reader["UserAgent"].ToString(), reader["PagePath"].ToString()));
                }
                return lstRobots;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
