using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.SEOExtension
{
    public class RobotsController
    {

        public static List<RobotsInfo> GetRobots(int PortalID)
        {
            try
            {
                return (RobotsDataProvider.GetRobots(PortalID));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SaveRobotsPage(int PortalID, string UserAgent, string PagePath)
        {
            try
            {
                 RobotsDataProvider.SaveRobotsPage(PortalID, UserAgent, PagePath);
            }
            catch (Exception )
            {
                
                throw ;
            }
            
        }
        public static List<RobotsInfo> GenerateRobots(string UserAgent)
        {
            try
            {
                return (RobotsDataProvider.GenerateRobots(UserAgent));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteExistingRobots(int PortalID)
        {
            try
            {
                RobotsDataProvider.DeleteExistingRobots(PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    
    }
}
