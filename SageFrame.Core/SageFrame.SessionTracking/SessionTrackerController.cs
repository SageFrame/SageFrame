#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using SageFrame.Web;
using SageFrame.Common; 

#endregion

namespace SageFrame.Web
{
    public class SessionTrackerController
    {
        public SessionTrackerController()
        {
        }

        public void SetSessionTrackerValues(string portalID, string userName)
        {
            SessionTracker sessionTracker = (SessionTracker)HttpContext.Current.Session[SessionKeys.Tracker];
            if (string.IsNullOrEmpty(sessionTracker.PortalID))
            {
                sessionTracker.PortalID = portalID;
                sessionTracker.Username = userName;
                SageFrameConfig sfConfig = new SageFrameConfig();
                sessionTracker.InsertSessionTrackerPages = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.InsertSessionTrackingPages);
                SageFrame.Web.SessionLog SLog = new SageFrame.Web.SessionLog();
                SLog.SessionTrackerUpdateUsername(sessionTracker, userName, portalID);
                HttpContext.Current.Session[SessionKeys.Tracker] = sessionTracker;
                TemplateValidation objValidation = new TemplateValidation();
                objValidation.Validate();

            }
        }
    }
}
