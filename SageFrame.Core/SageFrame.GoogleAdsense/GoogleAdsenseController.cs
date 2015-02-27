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

namespace SageFrame.GoogleAdsense
{
    public class GoogleAdsenseController
    {
        public static int CountAdsenseSettings(int UserModuleID, int PortalID)
        {
            try
            {
                return GoogleAdsenseProvider.CountAdsenseSettings(UserModuleID, PortalID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static List<GoogleAdsenseInfo> GetAdSenseSettingsByUserModuleID(int UserModuleID, int PortalID)
        {
            try
            {
                return GoogleAdsenseProvider.GetAdSenseSettingsByUserModuleID(UserModuleID, PortalID);
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
                GoogleAdsenseProvider.AddUpdateAdSense(UserModuleID, SettingName, SettingValue, IsActive, PortalID, UpdatedBy, UpdateFlag);
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
                GoogleAdsenseProvider.DeleteAdSense(UserModuleID, PortalID);
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
                return GoogleAdsenseProvider.CountAdSense(UserModuleID, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
