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

#endregion


namespace SageFrame.LogView
{
    public class LogProvider
    {
        public List<LogInfo> GetLogType()
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                return SQLH.ExecuteAsList<LogInfo>("[dbo].[sp_LogType]");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<LogInfo> GetLogView(int PortalID, string LogType)
        {
            try
            {
                SQLHandler SQLH = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@LogType", LogType));
                return SQLH.ExecuteAsList<LogInfo>("[dbo].[sp_LogView]", ParamCollInput);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
