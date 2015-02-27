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
using SageFrame.Shared;
using System.Collections;
using System.Web;
using System.Data;
using SageFrame.Web.Utilities;
using System.Web.Security;
using SageFrame.Common;
using System.Data.SqlClient;

namespace SageFrame.Web
{
    public class SageFrameConfig
    {
        public SageFrameConfig()
        {
        }

        public string GetUsername
        {
            get
            {
                try
                {
                    MembershipUser user = Membership.GetUser();
                    if (user != null)
                    {
                        return user.UserName;
                    }
                    else
                    {
                        return "anonymoususer";
                    }
                }
                catch
                {
                    return "anonymoususer";
                }
            }
        }

        public DataSet GetPageSettings(string controlType, string pageID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@ControlType", controlType));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PageID", pageID));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", GetUsername));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_GetPageSetting", ParaMeterCollection);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataSet GetPageSettingsByPageSEOName(string controlType, string pageSEOName, string userName)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@ControlType", controlType));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PageSEOName", pageSEOName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", userName));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.usp_GetPageSettingByPageSEOName", ParaMeterCollection);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<UserModuleInfo> GetPageModules(string controlType, string pageSEOName, string userName)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@ControlType", controlType));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PageSEOName", pageSEOName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", userName));
                List<UserModuleInfo> lstPageModules = new List<UserModuleInfo>();
                SQLHandler sagesql = new SQLHandler();
                lstPageModules = sagesql.ExecuteAsList<UserModuleInfo>("[dbo].[usp_MasterPageGetPageModules]", ParaMeterCollection);
                return lstPageModules;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet GetPageSettingsByPageSEONameForAdmin(string controlType, string pageSEOName, string userName)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();

                ParaMeterCollection.Add(new KeyValuePair<string, string>("@ControlType", controlType));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PageSEOName", pageSEOName));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", GetPortalID.ToString()));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", userName));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("[dbo].[usp_GetPageSettingByPageSEONameForAdmin]", ParaMeterCollection);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       

        public int GetPortalID
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["SageFrame.PortalID"] != null && HttpContext.Current.Session["SageFrame.PortalID"].ToString() != "")
                    {
                        return int.Parse(HttpContext.Current.Session["SageFrame.PortalID"].ToString());
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        public string GetSettingsByKey(string Key)
        {
            try
            {
                string strValue = string.Empty;
                SettingProvider sep = new SettingProvider();
                Hashtable hst = new Hashtable();
                if (HttpContext.Current.Cache["SageSetting"] != null)
                {
                    hst = (Hashtable)HttpContext.Current.Cache["SageSetting"];
                }
                else
                {
                    DataTable dt = sep.GetSettingsByPortal(GetPortalID.ToString(), string.Empty); //GetSettingsByPortal();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            hst.Add(dt.Rows[i]["SettingKey"].ToString(), dt.Rows[i]["SettingValue"].ToString());
                        }
                    }
                }
                //need to be cleared when any key is chnaged
                HttpContext.Current.Cache.Insert("SageSetting", hst);//

                strValue = hst[SettingPortal + "." + Key].ToString();
                return strValue;
            }
            //catch (SqlException sqex)
            //{
            //    HttpContext.Current.Response.Redirect("~/DatabaseError.htm");
            //    throw sqex;

            //}
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ResetSettingKeys(int PortalID)
        {
            SettingProvider sep = new SettingProvider();
            Hashtable hst = new Hashtable();
                DataTable dt = sep.GetSettingsByPortal(PortalID.ToString(), string.Empty);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hst.Add(dt.Rows[i]["SettingKey"].ToString(), dt.Rows[i]["SettingValue"].ToString());
                    }
                }
            //need to be cleared when any key is chnaged
            HttpContext.Current.Cache.Insert("SageSetting", hst);//
        }

        private string SettingPortal
        {
            get
            {
                string strPortalName = "default";
                try
                {
                    if (HttpContext.Current.Session["SageFrame.PortalSEOName"] != null)
                    {
                        strPortalName = HttpContext.Current.Session["SageFrame.PortalSEOName"].ToString();
                    }
                }
                catch
                {
                    strPortalName = "default";
                }
                return strPortalName;
            }
        }

        public int GetSettingIntByKey(string Key)
        {
            try
            {
                return Int32.Parse(GetSettingsByKey(Key));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GetSettingBollByKey(string Key)
        {
            try
            {
                if (!string.IsNullOrEmpty(GetSettingsByKey(Key)))
                {
                    return bool.Parse(GetSettingsByKey(Key));
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
