using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Web.Utilities;

namespace SageFrame.CDN
{
    public class CDNProvider
    {
        public void SaveLinks(List<CDNInfo> objInfo)
        {
            SQLHandler sagesql = new SQLHandler();
            string sp = "[dbo].[usp_CDNSaveLink]";
            foreach (CDNInfo cdn in objInfo)
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@URL", cdn.URL));
                ParamCollInput.Add(new KeyValuePair<string, object>("@IsJS", cdn.IsJS));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URLOrder", cdn.URLOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", cdn.PortalID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@Mode", cdn.Mode));
                try
                {
                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        public List<CDNInfo> GetCDNLinks(int PortalID)
        {
            SQLHandler sagesql = new SQLHandler();
            string sp = "[dbo].[usp_CDNGetLink]";
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                return sagesql.ExecuteAsList<CDNInfo>(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void SaveOrder(List<CDNInfo> objOrder)
        {
            SQLHandler sagesql = new SQLHandler();
            string sp = "[dbo].[usp_CDNSaveOrder]";
            foreach (CDNInfo cdn in objOrder)
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@URLID", cdn.URLID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@URLOrder", cdn.URLOrder));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", cdn.PortalID));
                try
                {
                    sagesql.ExecuteNonQuery(sp, ParamCollInput);

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public void DeleteURL(int UrlID, int PortalID)
        {
            SQLHandler sagesql = new SQLHandler();
            string sp = "[dbo].[usp_CDNDeleteLink]";
            try
            {
                List<KeyValuePair<string, object>> ParamCollInput = new List<KeyValuePair<string, object>>();
                ParamCollInput.Add(new KeyValuePair<string, object>("@UrlID", UrlID));
                ParamCollInput.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                sagesql.ExecuteNonQuery(sp, ParamCollInput);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
