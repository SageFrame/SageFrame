#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SageFrame.Web;
using SageFrame.Web.Utilities;
using System.Collections;

#endregion


/// <summary>
/// Summary description for SessionLog
/// </summary>
namespace SageFrame.Web
{
    [Serializable]
    public class SessionLog
    {
        public SessionLog()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SessionTrackerUpdateUsername(SessionTracker sessionTracker, string GetUsername, string GetPortalID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionTrackerID", sessionTracker.SessionTrackerID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@UserName", GetUsername));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_SessionTrackerUpdateUsername", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void StoreSessionTrackerAdd(SessionTracker sessionTracker, int StoreID, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SessionTrackerID", int.Parse(sessionTracker.SessionTrackerID)));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@StoreID", StoreID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("[usp_Aspx_StoreSessionAdd]", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SessionLogStart(SessionTracker tracker)
        {
            try
            {
                string hostAddress = tracker.SessionUserHostAddress.ToString();
                string userAgent = tracker.SessionUserAgent != null ? tracker.SessionUserAgent.ToString() : string.Empty;
                string browser = tracker.Browser;
                //string crawler = tracker.Browser.Crawler != null ? tracker.Browser.Crawler.ToString() : string.Empty;
                string crawler = tracker.Crawler.ToString();
                string sessionUrl = tracker.SessionURL != null ? tracker.SessionURL.ToString() : string.Empty;
                //string visitCount = tracker.VisitCount != null ? tracker.VisitCount.ToString() : string.Empty;
                string visitCount = tracker.VisitCount.ToString();
                string referrer = tracker.OriginalReferrer != null ? tracker.OriginalReferrer.ToString() : string.Empty;
                string orgUrl = tracker.OriginalURL != null ? tracker.OriginalURL.ToString() : string.Empty;
                string username = tracker.Username != null ? tracker.Username.ToString() : string.Empty;
                string portalID = tracker.PortalID != null ? tracker.PortalID.ToString() : string.Empty;
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionUserHostAddress", hostAddress));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionUserAgent", userAgent));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionBrowser", browser));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionCrawler", crawler));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionURL", sessionUrl));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionVisitCount", visitCount));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionOriginalReferrer", referrer));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionOriginalURL", orgUrl));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@UserName", username));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", portalID));
                SQLHandler sagesql = new SQLHandler();
                int insertedID = sagesql.ExecuteNonQuery("dbo.sp_SessionTrackerAdd", ParaMeterCollection, "@InsertedID");
                tracker.SessionTrackerID = insertedID.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SessionLogEnd(SessionTracker tracker)
        {
            try
            {
                //string hostAddress = tracker.SessionUserHostAddress.ToString();
                //string userAgent = tracker.SessionUserAgent != null ? tracker.SessionUserAgent.ToString() : string.Empty;
                //string browser = tracker.Browser.Browser != null ? tracker.Browser.Browser.ToString() : string.Empty;
                //string crawler = tracker.Browser.Crawler != null ? tracker.Browser.Crawler.ToString() : string.Empty;
                //string sessionUrl = tracker.SessionURL != null ? tracker.SessionURL.ToString() : string.Empty;
                //string visitCount = tracker.VisitCount != null ? tracker.VisitCount.ToString() : string.Empty;
                //string referrer = tracker.OriginalReferrer != null ? tracker.OriginalReferrer.ToString() : string.Empty;
                //string orgUrl = tracker.OriginalURL != null ? tracker.OriginalURL.ToString() : string.Empty;
                //string username = tracker.Username != null ? tracker.Username.ToString() : string.Empty;
                //string portalID = tracker.PortalID != null ? tracker.PortalID.ToString() : string.Empty;
                //List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionUserHostAddress", hostAddress));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionUserAgent", userAgent));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionBrowser", browser));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionCrawler", crawler));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionURL", sessionUrl));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionVisitCount", visitCount));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionOriginalReferrer", referrer));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionOriginalURL", orgUrl));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@UserName", username));
                //ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", portalID));
                //SQLHandler sagesql = new SQLHandler();
                //int insertedID = sagesql.ExecuteNonQuery("dbo.sp_SessionTrackerAdd", ParaMeterCollection, "@InsertedID");
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SessionTrackerID", tracker.SessionTrackerID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", tracker.PortalID.ToString()));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_SessionTrackerUpdateEND", ParaMeterCollection);
                if (bool.Parse(tracker.InsertSessionTrackerPages))
                {
                    if ((tracker.Pages != null))
                    {
                        ArrayList pages = tracker.Pages;
                        string body = string.Empty;
                        DateTime FirstTime = Convert.ToDateTime("00:00:00");
                        DateTime PreviousTime = Convert.ToDateTime("00:00:00");
                        TimeSpan ElapsedTime;
                        bool first = true;
                        string lastPage = null;
                        foreach (SessionTrackerPage pti in pages)
                        {
                            if (first)
                            {
                                FirstTime = pti.Time;
                                first = false;
                                ElapsedTime = new TimeSpan(0, 0, 0);
                            }
                            else
                            {
                                ElapsedTime = PreviousTime.Subtract(FirstTime);
                            }

                            List<KeyValuePair<string, string>> ParaMeterCollection1 = new List<KeyValuePair<string, string>>();
                            ParaMeterCollection1.Add(new KeyValuePair<string, string>("@SessionTrackerID", tracker.SessionTrackerID.ToString()));
                            ParaMeterCollection1.Add(new KeyValuePair<string, string>("@SessionTrackerPage", pti.PageName));
                            ParaMeterCollection1.Add(new KeyValuePair<string, string>("@SessionTrackerTime", ElapsedTime.ToString().Substring(0, 8)));
                            int insertedPageID = sagesql.ExecuteNonQuery("dbo.sp_SessionTrackerPageAdd", ParaMeterCollection1, "@InsertedID");
                            lastPage = pti.PageName;
                            PreviousTime = pti.Time;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}