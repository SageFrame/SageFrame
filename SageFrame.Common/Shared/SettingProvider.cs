#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using SageFrame.Web.Utilities;
using SageFrame.Web;
#endregion

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
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@UserName", Username));
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
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@UserName", Username));
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
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", userName));
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


        //Change portal
        public void ChangePortal(int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("dbo.usp_ChangePortal", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public KeyValue GetSettingValueByIndividualKey(string settingKey, int portalID)
        {
            KeyValue value = new KeyValue();
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", settingKey));
                SQLHandler sagesql = new SQLHandler();
                value = sagesql.ExecuteAsObject<KeyValue>("dbo.usp_GetSettingValueByIndividualKey", ParaMeterCollection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return value;
        }

        public DataSet GetAllSettings(string portalID, string settingType)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", portalID));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@SettingType", settingType));
                DataSet dataset = new DataSet();
                SQLHandler sagesql = new SQLHandler();                
                dataset = sagesql.ExecuteAsDataSet("dbo.usp_GetAllSettings", ParaMeterCollection);
                return dataset;
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
}
