#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data.SqlClient;

#endregion


namespace SageFrame.ErrorLog
{
    public class ErrorLogController
    {
        public void ClearLog(int PortalID)
        {
            try
            {
                ErrorLogDataProvider objProvider = new ErrorLogDataProvider();
                objProvider.ClearLog(PortalID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteLogByLogID(int ID, int PortalID, string UserName)
        {
            try
            {
                ErrorLogDataProvider objProvider = new ErrorLogDataProvider();
                objProvider.DeleteLogByLogID(ID, PortalID, UserName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertLog(int logTypeID, int severity, string message, string exception, string clientIPAddress, string pageURL, bool isActive, int portalID, string addedBy)
        {
            try
            {
                ErrorLogDataProvider objProvider = new ErrorLogDataProvider();
                return objProvider.InsertLog(logTypeID, severity, message, exception, clientIPAddress, pageURL, isActive, portalID, addedBy);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
