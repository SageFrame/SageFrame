using System;
using System.Collections.Generic;
using System.Text;
using DashBoardControl.Info;

namespace DashBoardControl
{
    public class DashBoardController
    {
      public static void AddDashBoardSetting(List<DashBoardSettingInfo> lstDashBoardSetting)
        {
           try
           {
             DashBoardDataProvider.AddDashBoardSetting(lstDashBoardSetting);
           }
           catch (Exception)
           {

               throw;
           }
       }
       public static List<DashBoardSettingInfo> GetDashBoardSetting(int UserModuleID, int PortalID)
        {
           try
           {
               return (DashBoardDataProvider.GetDashBoardSetting(UserModuleID, PortalID));
           }
           catch (Exception)
           {
               
               throw;
           }
       }

     

        public static List<DashBoardSettingInfo> ListDashBoardSettingForView(int UserModuleID, int PortalID)
        {
           try
           {
               return (DashBoardDataProvider.ListDashBoardSettingForView(UserModuleID, PortalID));
           }
           catch (Exception)
           {

               throw;
           }
       }

        public static int GetMonthlyVisit()
        {
            try
            {
                 return (DashBoardDataProvider.GetMonthlyVisit());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<DashBoardSettingInfo> GetDailyVisit(string StartDate, string EndDate)
        {
            try
            {
              return  DashBoardDataProvider.GetDailyVisit(StartDate, EndDate);
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public static List<DashBoardSettingInfo> GetRefSite(string StartDate, string EndDate, int pageNo, int range)
        {
            try
            {
                return DashBoardDataProvider.GetRefSite(StartDate, EndDate,pageNo,range);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        #region Report

        public static List<DashBoardSettingInfo> GetTopVisitedPage_Report(string StartDate, string EndDate)
        {
            try
            {
                return DashBoardDataProvider.GetTopVisitedPage_Report(StartDate, EndDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static List<DashBoardSettingInfo> GetTopBrowser_Report(string StartDate, string EndDate)
        {
            try
            {
                return DashBoardDataProvider.GetTopBrowser_Report(StartDate, EndDate);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<DashBoardSettingInfo> GetTopVisitedCountry_Report(string StartDate, string EndDate)
        {
            try
            {
                return DashBoardDataProvider.GetTopVisitedCountry_Report(StartDate, EndDate);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<DashBoardSettingInfo> GetRefSite_Report(string StartDate, string EndDate)
        {
            try
            {
                return DashBoardDataProvider.GetRefSite_Report(StartDate, EndDate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public static List<DashBoardSettingInfo> GetSearchPage(string StartDate, string EndDate)
        {
            try 
            {
                return DashBoardDataProvider.GetSearchPage(StartDate, EndDate);
            }

            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static List<DashBoardSettingInfo> GetTopFiveVisitedCountry(string StartDate, string EndDate)
        {

            try
            {
                return DashBoardDataProvider.GetTopFiveVisitedCountry(StartDate, EndDate);
            }

            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }

    
}
