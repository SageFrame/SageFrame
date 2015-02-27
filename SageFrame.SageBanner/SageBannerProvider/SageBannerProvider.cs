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
using SageFrame.SageBannner.Controller;
using SageFrame.SageBannner.Info;
using SageFrame.Web.Utilities;
using System.Data;
using System.Data.SqlClient;
using SageFrame.Web;
using SageFrame.SageBannner.SettingInfo;

namespace SageFrame.SageBannner.Provider
{
    public class SageBannerProvider
    {
        public void SaveBannerContent(SageBannerInfo obj)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Caption", obj.Caption));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImagePath", obj.ImagePath));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ReadMorePage", obj.ReadMorePage));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@LinkToImage", obj.LinkToImage));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", obj.UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@BannerID", obj.BannerID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageID", obj.ImageID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ReadButtonText", obj.ReadButtonText));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@NavigationImage", obj.NavigationImage));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Description", obj.Description));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", obj.PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("usp_SageBannerSaveBannerContent", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void SaveBannerInformation(SageBannerInfo objB)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@BannerName", objB.BannerName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@BannerDescription", objB.BannerDescription));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", objB.UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", objB.PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("usp_SageBannerSaveBannerInformation", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static List<SageBannerInfo> LoadBannerImagesOnGrid(int BannerID,int UserModuleID,int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@BannerID", BannerID));
                Parameter.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                return sqlH.ExecuteAsList<SageBannerInfo>("[usp_SageBannerLoadBannerImagesOnGrid]", Parameter);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<SageBannerInfo> LoadHTMLContentOnGrid(int BannerID,int UserModuleID,int PortalID )
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@BannerID", BannerID));
                Parameter.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                return sqlH.ExecuteAsList<SageBannerInfo>("[usp_SageBannerLoadBannerHTMLContentOnGrid]",Parameter);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<SageBannerInfo> LoadBannerListOnGrid(int PortalID, int UserModuleID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                Parameter.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                SQLHandler sqlH = new SQLHandler();
                return sqlH.ExecuteAsList<SageBannerInfo>("[usp_SageBannerLoadBannerListOnGrid]", Parameter);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public static List<SageBannerInfo> LoadBannerOnDropDown(int UserModuleID, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sqlH = new SQLHandler();
                SqlDataReader Reader;
                Reader = sqlH.ExecuteAsDataReader("usp_SageBannerGetAllBanner", Parameter);
                List<SageBannerInfo> BannerListForDropDown = new List<SageBannerInfo>();
                while (Reader.Read())
                {
                    SageBannerInfo obj = new SageBannerInfo();
                    obj.BannerID = Convert.ToInt32(Reader["BannerID"]);
                    obj.BannerName = Convert.ToString(Reader["BannerName"]);
                    BannerListForDropDown.Add(obj);
                }
                return BannerListForDropDown;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void SaveBannerSetting(string Key, string value, int usermoduleid, string Addedby, string Updatedby, int PortalID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingKey", Key));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@SettingValue", value));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@usermoduleid", usermoduleid));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Addedby", Addedby));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Updatedby", Updatedby));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                sagesql.ExecuteNonQuery("[usp_SageBannerSaveBannerSetting]", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static List<SageBannerInfo> GetAllPagesOfSageFrame(int PortalID)
        {
            List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
            Parameter.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
            List<SageBannerInfo> obj = new List<SageBannerInfo>();
            SQLHandler sqlH = new SQLHandler();
            obj = sqlH.ExecuteAsList<SageBannerInfo>("[usp_SageBannerGetAllPagesOfSageFrame]", Parameter);
            return obj;

        }

        public SageBannerSettingInfo GetSageBannerSettingList(int PortalID, int UserModuleID)
        {
            try
            {
                SageBannerSettingInfo Getsettin = new SageBannerSettingInfo();
                List<KeyValuePair<string, object>> paramCol = new List<KeyValuePair<string, object>>();
                paramCol.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                paramCol.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                SQLHandler sageSQL = new SQLHandler();
                Getsettin = sageSQL.ExecuteAsObject<SageBannerSettingInfo>("[dbo].[usp_SageBannerGetBannerSetting]", paramCol);
                return Getsettin;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<SageBannerInfo> GetBannerImages(int BannerID, int UserModuleID, int PortalID)
        {
            try
            {
                List<SageBannerInfo> GetBannerImage = new List<SageBannerInfo>();
                List<KeyValuePair<string, object>> paramCol = new List<KeyValuePair<string, object>>();
                paramCol.Add(new KeyValuePair<string, object>("@BannerID", BannerID));
                paramCol.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                paramCol.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sageSQL = new SQLHandler();
                GetBannerImage = sageSQL.ExecuteAsList<SageBannerInfo>("[dbo].[usp_SageBannerGetBannerImages]", paramCol);
                return GetBannerImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SageBannerInfo GetImageInformationByID(int ImageID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageID", ImageID));
                SQLHandler SQLH = new SQLHandler();
                return SQLH.ExecuteAsObject<SageBannerInfo>("[dbo].[usp_SageBannerGetImageInformationByID]", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SageBannerInfo GetHTMLContentForEditByID(int ImageID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageID", ImageID));
                SQLHandler SQLH = new SQLHandler();
                return SQLH.ExecuteAsObject<SageBannerInfo>("[dbo].[usp_SageBannerGetHTMLContentForEditByID]", ParaMeterCollection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteBannerContentByID(int ImageId)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageId", ImageId));
                SQLHandler SQLH = new SQLHandler();
                SQLH.ExecuteNonQuery("[usp_SageBannerDeleteBannerContentByID]", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteBannerAndItsContentByBannerID(int BannerID)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@BannerID", BannerID));
                SQLHandler SQLH = new SQLHandler();
                SQLH.ExecuteNonQuery("[usp_SageBannerDeleteBannerAndItsContentByBannerID]", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteHTMLContentByID(int ImageId)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@ImageId", ImageId));
                SQLHandler SQLH = new SQLHandler();
                SQLH.ExecuteNonQuery("[usp_SageBannerDeleteHTMLContentByID]", ParaMeterCollection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetFileName(int ImageId)
        {
            try
            {
                List<KeyValuePair<string,object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@ImageId", ImageId));
                SQLHandler sqlH = new SQLHandler();
                return sqlH.ExecuteAsScalar<string>("usp_SageBannerGetFileName", Parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SortImageList(int ImageId, bool MoveUp)
        {
            try
            {
                List<KeyValuePair<string, object>> Parameter = new List<KeyValuePair<string, object>>();
                Parameter.Add(new KeyValuePair<string, object>("@ImageId", ImageId));
                Parameter.Add(new KeyValuePair<string, object>("@MoveUp", MoveUp));
                SQLHandler SQLH = new SQLHandler();
                SQLH.ExecuteNonQuery("[usp_SageBannerBannerSortOrderUpdate]", Parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
