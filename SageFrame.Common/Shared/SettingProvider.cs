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
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.Shared
{
    public class SettingProvider
    {
        public SettingProvider()
        {
        }

        private DataSet GetSettingsByPortalAndSettingType(string PortalID, string SettingType)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingType", SettingType));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_GetAllSettings", ParaMeterCollection);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAllPortals()
        {
            try
            {
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_GetAllPortals");
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetSettingsByPortal(string PortalID, string SettingType)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = GetSettingsByPortalAndSettingType(PortalID, SettingType);
                if (ds != null && ds.Tables != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveSageSettings(string SettingTypes, string SettingKeys, string SettingValues, string Username, string PortalID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingTypes", SettingTypes));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingKeys", SettingKeys));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingValues", SettingValues));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", Username));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_InsertUpdateSettings", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveSageSetting(string SettingType, string SettingKey, string SettingValue, string Username, string PortalID)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingType", SettingType));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingKey", SettingKey));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingValue", SettingValue));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", Username));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.sp_InsertUpdateSetting", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region "Google Analytics"

        public List<GoogleAnalyticsInfo> GetGoogleAnalyticsActiveOnlyByPortalID(int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                List<GoogleAnalyticsInfo> defaultList = sqlH.ExecuteAsList<GoogleAnalyticsInfo>("dbo.sp_GoogleAnalyticsListActiveOnlyByPortalID", ParaMeterCollection);
                return defaultList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GoogleAnalyticsInfo GetGoogleAnalyticsByPortalID(int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                GoogleAnalyticsInfo defaultList = sqlH.ExecuteAsObject<GoogleAnalyticsInfo>("dbo.sp_GoogleAnalyticsListByPortalID", ParaMeterCollection);
                return defaultList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GoogleAnalyticsAddUpdate(string GoogleJSCode, bool IsActive, int PortalID, string AddedBy)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@GoogleJSCode", GoogleJSCode));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
                SQLHandler sqlH = new SQLHandler();
                sqlH.ExecuteNonQuery("dbo.sp_GoogleAnalyticsAddUpdate", ParaMeterCollection);

            }
            catch (Exception e)
            {
                throw e;
            }
        } 

        #endregion

        public List<SagePortals> PortalGetList()
        {
            try
            {
                SQLHandler sqlH = new SQLHandler();
                List<SagePortals> sagePortals = sqlH.ExecuteAsList<SagePortals>("dbo.sp_PortalGetList");
                return sagePortals;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SageUserRole> RoleListGetByUsername(string userName, int portalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", userName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                SQLHandler sqlH = new SQLHandler();
                List<SageUserRole> sagePortalList = sqlH.ExecuteAsList<SageUserRole>("dbo.sp_RoleGetByUsername", ParaMeterCollection);
                return sagePortalList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CustomerGeneralInfo CustomerIDGetByUsername(string userName, int portalID, int storeID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Username", userName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@StoreID", storeID));
                SQLHandler sqlH = new SQLHandler();
                CustomerGeneralInfo sageCustInfo = sqlH.ExecuteAsObject<CustomerGeneralInfo>("dbo.usp_Aspx_CustomerIDGetByUsername", ParaMeterCollection);
                return sageCustInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class SagePortals
    {

        private int _PortalID;

        private string _Name;

        private string _SEOName;

        private System.Nullable<bool> _IsParent;

        private string _DefaultPage;

        public SagePortals()
        {
        }

        public SagePortals(int portalID, string name, string sEOName, bool isParent, string defaultPage)
        {
            this.PortalID = portalID;
            this.Name = name;
            this.SEOName = sEOName;
            this.IsParent = isParent;
            this.DefaultPage = defaultPage;
        }


        public int PortalID
        {
            get
            {
                return this._PortalID;
            }
            set
            {
                if ((this._PortalID != value))
                {
                    this._PortalID = value;
                }
            }
        }


        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }


        public string SEOName
        {
            get
            {
                return this._SEOName;
            }
            set
            {
                if ((this._SEOName != value))
                {
                    this._SEOName = value;
                }
            }
        }


        public System.Nullable<bool> IsParent
        {
            get
            {
                return this._IsParent;
            }
            set
            {
                if ((this._IsParent != value))
                {
                    this._IsParent = value;
                }
            }
        }


        public string DefaultPage
        {
            get
            {
                return this._DefaultPage;
            }
            set
            {
                if ((this._DefaultPage != value))
                {
                    this._DefaultPage = value;
                }
            }
        }
    }

    public class SageUserRole
    {

        private System.Guid _RoleId;

        public SageUserRole()
        {
        }

        public SageUserRole(System.Guid roleId)
        {
            this.RoleId = roleId;
        }

        public System.Guid RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                if ((this._RoleId != value))
                {
                    this._RoleId = value;
                }
            }
        }
    }

    public class CustomerGeneralInfo
    {
        private int _CustomerID;
        private string _UserName;
        private int _PortalID;
        private int _StoreID;
        private DateTime _AddedOn;

        public CustomerGeneralInfo()
        {
        }

        public int CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                if (this._CustomerID != value)
                {
                    this._CustomerID = value;
                }
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if (this._UserName != value)
                {
                    this._UserName = value;
                }
            }
        }

        public int PortalID
        {
            get
            {
                return this._PortalID;
            }
            set
            {
                if (this._PortalID != value)
                {
                    this._PortalID = value;
                }
            }
        }

        public int StoreID
        {
            get
            {
                return this._StoreID;
            }
            set
            {
                if (this._StoreID != value)
                {
                    this._StoreID = value;
                }
            }
        }

        public DateTime AddedOn
        {
            get
            {
                return this._AddedOn;
            }
            set
            {
                if (this._AddedOn != value)
                {
                    this._AddedOn = value;
                }
            }
        }
    }
}
