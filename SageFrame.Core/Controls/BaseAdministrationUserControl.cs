#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SageFrame.ErrorLog;
using SageFrame.Web;
using SageFrame.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using SageFrame.Web.Common.SEO;
using SageFrame.Web.Utilities;
using System.Collections;

#endregion

/// <summary>
/// Summary description for BaseAdministrationUserControl
/// </summary>
/// 
namespace SageFrame.Web
{
    public partial class BaseAdministrationUserControl : SageUserControl
    {
        #region "Protectected Methods"

        protected void ProcessException(Exception exc)
        {
            int inID = 0;
            ErrorLogController objController = new ErrorLogController();
            inID = objController.InsertLog((int)SageFrame.Web.SageFrameEnums.ErrorType.AdministrationArea, 11, exc.Message, exc.ToString(),
                HttpContext.Current.Request.UserHostAddress, Request.RawUrl, true, GetPortalID, GetUsername);

            SageFrameConfig pagebase = new SageFrameConfig();
            if (pagebase.GetSettingBollByKey(SageFrameSettingKeys.UseCustomErrorMessages))
            {
                ShowMessage(SageMessageTitle.Exception.ToString(), exc.Message, exc.ToString(), SageMessageType.Error);
            }
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// 
        /// </summary>
        public BaseAdministrationUserControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Get Module Control Types
        /// </summary>
        /// <param name="ModuleID">ModuleID</param>
        /// <returns>Module Information, Control Types, Module Package Detail</returns>
        public DataSet GetExtensionSettings(string ModuleID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@ModuleID", ModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_GetExtensionSetting", ParaMeterCollection);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns To The URL If The Process Is Cancel 
        /// </summary>
        /// <param name="RedirectUrl">Redirect URL</param>
        public void ProcessCancelRequest(string RedirectUrl)
        {
            try
            {
                ProcessCancelRequestBase(RedirectUrl);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <param name="controlPath"></param>
        /// <param name="parameter"></param>
        public void ProcessSourceControlUrl(string rawUrl, string controlPath, string parameter)
        {
            ProcessSourceControlUrlBase(rawUrl, controlPath, parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RedirectUrl"></param>
        /// <param name="IsSupress"></param>
        /// <param name="ExtensionMessage"></param>
        public void ProcessCancelRequestBase(string RedirectUrl, bool IsSupress, string ExtensionMessage)
        {
            string strURL = string.Empty;

            if (RedirectUrl.Contains("?"))
            {
                string[] d = RedirectUrl.Split('?');
                strURL = d[0];
            }

            if (strURL.Contains("?"))
            {
                strURL += "&ExtensionMessage=" + ExtensionMessage;
            }
            else if (strURL.Contains("&"))
            {
                strURL += "&ExtensionMessage=" + ExtensionMessage;
            }
            else
            {
                strURL += "?ExtensionMessage=" + ExtensionMessage;
            }

            HttpContext.Current.Response.Redirect(strURL, IsSupress);
        }

        /// <summary>
        /// Splits An Param In An Array
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string[] GetParam(string param)
        {
            string[] stringParam = param.Split('/');
            return stringParam;
        }
        #endregion
    }
}
