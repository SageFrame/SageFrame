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

namespace SageFrame.NewLetterSubscriber
{
    public class NewLetterSubscriberProvider

    {
        
        public static int AddNewLetterSubscribers(string Email, string ClientIP, bool IsActive, string AddedBy, DateTime AddedOn, int PortalID)
        {
            string sp = "[dbo].[sp_NewLetterSubscribersAdd]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@Email", Email));
                ParamCollInput.Add(new KeyValuePair<string, object>("@ClientIP", ClientIP));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));

                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));


                int NSID = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@NewLetterSubscribersID");
                return NSID;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int UpdateNewLetterSettings(int UserModuleID, string SettingKey, string SettingValue, bool IsActive, int PortalID, string UpdatedBy, string AddedBy)
        {

            string sp = "[dbo].[sp_NewsLetterSettingsUpdate]";
            SQLHandler sagesql = new SQLHandler();
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingKey", SettingKey));
                ParamCollInput.Add(new KeyValuePair<string, object>("@SettingValue", SettingValue.ToString()));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                ParamCollInput.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));

                int NSV = sagesql.ExecuteNonQueryAsGivenType<int>(sp, ParamCollInput, "@NewsLetterSettingValueID");
                return NSV;


            }
            catch (Exception)
            {

                throw;
            }
        }
 
    }
}
