/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.GoogleAdsense
{
    public class GoogleAdsenseProvider
    {     
        public static int CountAdsenseSettings(int UserModuleID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_AdSenseSettingsCount]";
                SQLHandler sagesql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));


                int UserModuleCount = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@UserModuleCount");
                return UserModuleCount;

            }
            catch (Exception)
            {

                throw;
            }
        }
  
        
        public static List<GoogleAdsenseInfo> GetAdSenseSettingsByUserModuleID(int UserModuleID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_AdSenseSettingsGetByUserModuleID]";
                SQLHandler sagesql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return sagesql.ExecuteAsList<GoogleAdsenseInfo>(sp, ParamCollInput);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    
        
        public static void AddUpdateAdSense(int UserModuleID, string SettingName, string SettingValue, bool IsActive, int PortalID, string UpdatedBy, bool UpdateFlag)
        {
            try
            {
                string sp = "[dbo].[sp_AdSenseAddUpdate]";
                SQLHandler sagesql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingName", SettingName));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingValue", SettingValue));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdateFlag", UpdateFlag));
                sagesql.ExecuteNonQuery(sp, ParamCollInput);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static void DeleteAdSense(int UserModuleID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_AdSenseDelete]";
                SQLHandler sageSql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                sageSql.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public static int CountAdSense(int UserModuleID, int PortalID)
        {
            try
            {
                string sp = "[dbo].[sp_AdSenseCount]";
                SQLHandler sagesql = new SQLHandler();
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));


                int UserModuleCount = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@UserModuleCount");
                return UserModuleCount;

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
