#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using SageFrame.Setting;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
//using AjaxControlToolkit;

#endregion

/// <summary>
/// Summary description for PictureManager
/// </summary>
/// 
namespace SageFrame.Web
{
    public static class PictureManager
    {
        public static string GetImagePathWithFileName(int imageType, string prefix, string localImagePath)
        {
            string SavePath = string.Empty;
            string localFilename = string.Empty;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = "img";
            }
            localFilename = prefix;
            switch (imageType)
            {
                case 1:
                    SavePath = Path.Combine(PictureManager.LocalMediumThumbImagePath, localFilename);
                    break;
                case 2:
                    SavePath = Path.Combine(localImagePath, localFilename);
                    break;
                case 3:
                    SavePath = Path.Combine(localImagePath, localFilename);
                    break;
            }

            return SavePath;
        }

        public static string GetFileName(string prefix)
        {
            string strFileName = string.Empty;
            strFileName = prefix + "_" + DateTime.Now.ToString().Replace(" ","").Replace("/","").Replace(":","");            
            return strFileName;
        }

        public static string SaveImage(FileUpload Fu, string prefix, string localImagePath)
        {
            if (!Directory.Exists(localImagePath))
                Directory.CreateDirectory(localImagePath);
            string strImage = string.Empty;
            string SavePath = string.Empty;
            //SavePath = GetImagePathWithFileName(3, prefix, localImagePath);
            SavePath = localImagePath;            
            SavePath += '\\' + prefix;
            Fu.SaveAs(SavePath);
            Fu.FileContent.Dispose();
            strImage = SavePath;
            //Fu.PostedFile.ContentLength
            return strImage;
        }

        public static void CreateThmnail(string strImage, int TargetSize, string SavePath)
        {
            Bitmap b = new Bitmap(strImage);
            Size newSize = CalculateDimensions(b.Size, TargetSize);
            System.Drawing.Image image = System.Drawing.Image.FromFile(strImage);
            if (newSize.Width < 1)
                newSize.Width = 1;
            if (newSize.Height < 1)
                newSize.Height = 1;
            b.Dispose();
            var newWidth = (int)(newSize.Width);
            var newHeight = (int)(newSize.Height);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(SavePath, image.RawFormat);
        }


        public static Size CalculateDimensions(Size OriginalSize, int TargetSize)
        {
            Size newSize = new Size();
            if (OriginalSize.Height > OriginalSize.Width) // portrait 
            {
                newSize.Width = (int)(OriginalSize.Width * (float)(TargetSize / (float)OriginalSize.Height));
                newSize.Height = TargetSize;
            }
            else // landscape or square
            {
                newSize.Height = (int)(OriginalSize.Height * (float)(TargetSize / (float)OriginalSize.Width));
                newSize.Width = TargetSize;
            }
            return newSize;
        }

        public static System.Drawing.Image ScaleByPercent(string strImage, double dblImgHt, double dblImgWd)
        {
            Bitmap imgRetPhoto = null;
            double dblWdRatio, dblHtRatio;

            try
            {
                imgRetPhoto = new Bitmap(strImage);
                if (imgRetPhoto.Height > Convert.ToInt32(dblImgHt) || imgRetPhoto.Width > Convert.ToInt32(dblImgWd))
                {
                    if (imgRetPhoto.Height > dblImgHt)
                    {
                        dblHtRatio = dblImgHt / Convert.ToDouble(imgRetPhoto.Height);
                        dblWdRatio = Convert.ToDouble(imgRetPhoto.Width) * dblHtRatio;
                        imgRetPhoto = new Bitmap(imgRetPhoto, Convert.ToInt32(dblWdRatio), Convert.ToInt32(dblImgHt));
                        imgRetPhoto.SetResolution(imgRetPhoto.HorizontalResolution, imgRetPhoto.VerticalResolution);
                    }

                    if (imgRetPhoto.Width > dblImgWd)
                    {
                        dblWdRatio = dblImgWd / Convert.ToDouble(imgRetPhoto.Width);
                        dblHtRatio = Convert.ToDouble(imgRetPhoto.Height) * dblWdRatio;
                        imgRetPhoto = new Bitmap(imgRetPhoto, Convert.ToInt32(dblImgWd), Convert.ToInt32(dblHtRatio));
                        imgRetPhoto.SetResolution(imgRetPhoto.HorizontalResolution, imgRetPhoto.VerticalResolution);
                    }
                    return imgRetPhoto;
                }
                else
                    return imgRetPhoto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool IsValidIconContentType(string extension)
        {
            // array of allowed file type extensions
            string[] validFileExtensions = { "jpg", "jpeg", "jpe", "gif", "bmp", "png", "swf", "ico" };
            var flag = false;
            // loop over the valid file extensions to compare them with uploaded file
            for (var index = 0; index < validFileExtensions.Length; index++)
            {
                if (extension.ToLower() == validFileExtensions[index].ToString().ToLower())
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Check the image Extension if it is valid to upload
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool ValidImageExtension(string fileName)
        {
            return Regex.IsMatch(fileName.ToLower(), @"^.*\.(jpg|gif|jpeg|swf|ico|png|bmp)$");
        }

        public static bool ValidFileExtension(string fileName)
        {
            return Regex.IsMatch(fileName.ToLower(), @"^.*\.(css|html|xml|ascx|js|config)$");
        }

        public static bool IsValidIImageTypeWitMime(string extension)
        {
            // array of allowed file type extensions
            string[] validFileExtensions = { "image/jpg", "image/jpeg", "image/jpe", "image/gif", "image/png" };
            var flag = false;
            // loop over the valid file extensions to compare them with uploaded file
            for (var index = 0; index < validFileExtensions.Length; index++)
            {
                if (extension.ToLower() == validFileExtensions[index].ToString().ToLower())
                {
                    flag = true;
                }
            }
            return flag;
        }


        public static bool IsVAlidImageContentType(string imagePath)
        {
            // extract and store the file extension into another variable
            // array of allowed file type extensions
            string[] validFileExtensions = { "jpg", "jpeg", "jpe", "gif", "bmp", "png", "swf", "ico" };
            var flag = false;
            //String fileExtension = imagePath.Substring(imagePath.Length - 3, 3);
            if (imagePath.Contains("."))
            {
                String fileExtension = imagePath.Substring(imagePath.LastIndexOf(".") + 1);               
                // loop over the valid file extensions to compare them with uploaded file
                for (var index = 0; index < validFileExtensions.Length; index++)
                {
                    if (fileExtension.ToLower() == validFileExtensions[index].ToString().ToLower())
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Gets a local thumb image path
        /// </summary>
        /// 
        public static string LocalMediumThumbImagePath
        {
            get
            {
                string path = HttpContext.Current.Request.PhysicalApplicationPath + "bdimages\\mediumthumb";
                return path;
            }
        }
        public static string LocalSmallThumbImagePath
        {
            get
            {
                string path = HttpContext.Current.Request.PhysicalApplicationPath + "bdimages\\Smallthumbs";
                return path;
            }
        }

        /// <summary>
        /// Gets the local image path
        /// </summary>
        public static string LocalImagePath
        {
            get
            {
                string path = HttpContext.Current.Request.PhysicalApplicationPath + "bdimages";
                return path;
            }
            set
            {
                string path = value;                

            }
        }

        public static string CreateMediumThumnail(string strImage, int PortalID, string prefix, string localImagePath, int imageSize)
        {
            if (!Directory.Exists(localImagePath))
                Directory.CreateDirectory(localImagePath);
            string SavePath = string.Empty;
            //SavePath = GetImagePathWithFileName(1, prefix, localImagePath);
            SavePath = localImagePath;
            SavePath += strImage.Substring(strImage.LastIndexOf("\\"));
            //int imageSize = 200;
            CreateThmnail(strImage, imageSize, SavePath);
            return SavePath;
        }

        public static string CreateSmallThumnail(string strImage, int PortalID, string prefix, string localImagePath, int imageSize)
        {
            if (!Directory.Exists(localImagePath))
                Directory.CreateDirectory(localImagePath);
            string SavePath = string.Empty;
            //SavePath = GetImagePathWithFileName(2, prefix, localImagePath);
            SavePath = localImagePath;
            SavePath += strImage.Substring(strImage.LastIndexOf("\\"));
            //int imageSize = 125;
            CreateThmnail(strImage, imageSize, SavePath);
            return SavePath;
        }
        [Obsolete("Not in Use In SageFrame2.1")]
        public static string CreateCategoryMediumThumnail(string strImage, int PortalID, string prefix, string localImagePath)
        {
            string SavePath = string.Empty;
            SavePath = GetImagePathWithFileName(1, prefix, localImagePath);
            SavePath += strImage.Substring(strImage.LastIndexOf("."));
            //int imageSidge = Int32.Parse(dbSetting.sp_SettingPortalBySettingID((int)SettingKey.Media_Category_Medium_ThumbnailImageSize, PortalID).SingleOrDefault().Value);
            //CreateThmnail(strImage, imageSidge, SavePath);
            return SavePath;
        }

        [Obsolete("Not in Use In SageFrame2.1")]
        public static string CreateCategorySmallThumnail(string strImage, int PortalID, string prefix, string localImagePath)
        {
            string SavePath = string.Empty;
            SavePath = GetImagePathWithFileName(2, prefix, localImagePath);
            SavePath += strImage.Substring(strImage.LastIndexOf("."));
            //int imageSidge = Int32.Parse(dbSetting.sp_SettingPortalBySettingID((int)SettingKey.Media_Category_Small_ThumbnailImageSize, PortalID).SingleOrDefault().Value);
            //CreateThmnail(strImage, imageSidge, SavePath);
            return SavePath;
        }
    }
}
