using System;
using System.Collections.Generic;
using System.Text;
using SageFrame.Web.Utilities;
using DashBoardControl.Info;
using System.Data.SqlClient;

namespace DashBoardControl
{
    public class DashBoardDataProvider
    {
        public static List<DashBoardSettingInfo> GetTopBrowser(string StartDate, string EndDate, int pageNo, int range)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PageNo", pageNo));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Range", range));   
            
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopBrowser]",ParaMeterCollection);
        }
        public static List<DashBoardSettingInfo> GetTopFiveBrowser(string StartDate, string EndDate)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate",DateTime.Parse(StartDate)));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate",DateTime.Parse( EndDate)));  

            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopFiveBrowser]",ParaMeterCollection);
        }

        public static List<DashBoardSettingInfo> GetTopVisitedPage(string StartDate, string EndDate, int pageNo, int range)
        {
            
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PageNo", pageNo));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Range", range));   
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopVisitedPage]", ParaMeterCollection);
        }

        public static List<DashBoardSettingInfo> GetTopFiveVisitedPage(string StartDate, string EndDate)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));   
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopFivevisitedPage]", ParaMeterCollection);
        }

        public static List<DashBoardSettingInfo> GetTopVisitedCountry(string StartDate, string EndDate, int pageNo, int range)
        {
         
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PageNo", pageNo));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@Range", range));
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopvisitCountry]", ParaMeterCollection);
        }

        public static List<DashBoardSettingInfo> GetTopFiveVisitedCountry(string StartDate, string EndDate)
        {
                        
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopFivevisitCountry]", ParaMeterCollection);
        }



        public static int GetMonthlyVisit()
        {
            
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsScalar<int>("usp_GetMonthlyVisit");
        }
        
        #region Setting

        public static void AddDashBoardSetting(List<DashBoardSettingInfo> lstDashBoardSetting)
        {
            foreach (DashBoardSettingInfo obj in lstDashBoardSetting)
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", obj.UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", obj.SettingKey));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingValue", obj.SettingValue));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", obj.IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", obj.AddedBy));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", obj.AddedBy));

                try
                {
                    SQLHandler Objsql = new SQLHandler();
                    Objsql.ExecuteNonQuery("[dbo].[usp_SiteAnalyticsSettingAddUpdate]", ParaMeterCollection);

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        public static List<DashBoardSettingInfo> GetDashBoardSetting(int UserModuleID, int PortalID)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            SqlDataReader reader = null;
            try
            {
                SQLHandler Objsql = new SQLHandler();

                reader = Objsql.ExecuteAsDataReader("[dbo].[usp_DashBoardGetAll]", ParaMeterCollection);
                List<DashBoardSettingInfo> lstSetting = new List<DashBoardSettingInfo>();
                while (reader.Read())
                {
                    lstSetting.Add(new DashBoardSettingInfo(reader["SettingKey"].ToString(), reader["SettingValue"].ToString()));
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




        public static List<DashBoardSettingInfo> ListDashBoardSettingForView(int UserModuleID, int PortalID)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            SqlDataReader reader = null;
            try
            {
                SQLHandler Objsql = new SQLHandler();

                reader = Objsql.ExecuteAsDataReader("[dbo].[usp_DashBoardSettingsSelect]", ParaMeterCollection);
                List<DashBoardSettingInfo> lstSetting = new List<DashBoardSettingInfo>();
                while (reader.Read())
                {
                    lstSetting.Add(new DashBoardSettingInfo(reader["START_DATE"].ToString(), reader["END_DATE"].ToString(), reader["SELECT_TYPE"].ToString()));
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



        #endregion



        public static List<DashBoardSettingInfo> GetDailyVisit(string StartDate, string EndDate)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
           
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetDailyVisit]", ParaMeterCollection);
        }

        public static List<DashBoardSettingInfo> GetRefSite(string StartDate, string EndDate, int pageNo, int range)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@pageNo", pageNo));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@range", range));

            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetRefPage]", ParaMeterCollection);
        }
        #region Generate Report


        public static List<DashBoardSettingInfo> GetTopVisitedPage_Report(string StartDate, string EndDate)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));

            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetVisitedPage_Report]", ParaMeterCollection);
        }
        public static List<DashBoardSettingInfo> GetTopBrowser_Report(string StartDate, string EndDate)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));


            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetBrowser_Report]", ParaMeterCollection);
        }
        public static List<DashBoardSettingInfo> GetTopVisitedCountry_Report(string StartDate, string EndDate)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetCountry_Report]", ParaMeterCollection);
        }
        public static List<DashBoardSettingInfo> GetRefSite_Report(string StartDate, string EndDate)
        {

            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));

            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetRefPage_Report]", ParaMeterCollection);
        }
        #endregion

        public static List<DashBoardSettingInfo> GetSearchPage(string StartDate, string EndDate)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardStartDate", StartDate));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@DashBoardEndDate", EndDate));
           

            SQLHandler SQLH = new SQLHandler();
            return SQLH.ExecuteAsList<DashBoardSettingInfo>("[dbo].[usp_GetTopvisitedPageSearch]", ParaMeterCollection);
        }
    }
}
