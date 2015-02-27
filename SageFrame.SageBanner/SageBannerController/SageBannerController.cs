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
using SageFrame.SageBannner.Info;
using SageFrame.SageBannner.Provider;
using System.Data;
using System.Data.SqlClient;
using SageFrame.Web;
using SageFrame.Web.Utilities;
using SageFrame.SageBannner.SettingInfo;

namespace SageFrame.SageBannner.Controller
{
    public class SageBannerController
    {

        public void SaveBannerContent(SageBannerInfo obj)
        {
            SageBannerProvider objpro = new SageBannerProvider();
            objpro.SaveBannerContent(obj);

        }


        public void SaveBannerInformation(SageBannerInfo objB)
        {
            SageBannerProvider objBP = new SageBannerProvider();
            objBP.SaveBannerInformation(objB);
        }


        public static List<SageBannerInfo> LoadBannerOnDropDown(int UserModuleID, int PortalID)
        {
            try
            {
                return SageBannerProvider.LoadBannerOnDropDown(UserModuleID, PortalID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<SageBannerInfo> LoadBannerImagesOnGrid(int BannerID, int UserModuleID, int PortalID)
        {
            try
            {
                return SageBannerProvider.LoadBannerImagesOnGrid(BannerID, UserModuleID, PortalID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<SageBannerInfo> LoadHTMLContentOnGrid(int BannerID, int UserModuleID, int PortalID)
        {
            try
            {
                return SageBannerProvider.LoadHTMLContentOnGrid(BannerID, UserModuleID, PortalID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<SageBannerInfo> LoadBannerListOnGrid(int PortalID, int UserModuleID)
        {
            return SageBannerProvider.LoadBannerListOnGrid(PortalID, UserModuleID);
        }


        public SageBannerInfo GetImageInformationByID(int ImageID)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetImageInformationByID(ImageID);
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
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetHTMLContentForEditByID(ImageID);
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
                SageBannerProvider objp = new SageBannerProvider();
                objp.DeleteBannerContentByID(ImageId);

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
                SageBannerProvider objp = new SageBannerProvider();
                objp.DeleteBannerAndItsContentByBannerID(BannerID);
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
                SageBannerProvider objP = new SageBannerProvider();
                objP.DeleteHTMLContentByID(ImageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<SageBannerInfo> GetAllPagesOfSageFrame(int PortalID)
        {
            return SageBannerProvider.GetAllPagesOfSageFrame(PortalID);
        }


        public string GetFileName(int ImageId)
        {

            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetFileName(ImageId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SageBannerSettingInfo GetSageBannerSettingList(int PortalID, int UserModuleID)
        {
            try
            {
                SageBannerProvider objP = new SageBannerProvider();
                return objP.GetSageBannerSettingList(PortalID, UserModuleID);

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
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetBannerImages(BannerID, UserModuleID, PortalID);

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
                SageBannerProvider objp = new SageBannerProvider();
                objp.SortImageList(ImageId,MoveUp);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





    }
}
