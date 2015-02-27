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
namespace SageFrame.SageBannner.Info
{
    public class SageBannerInfo
    {
        //public SageBannerInfo();
       // public SageBannerInfo(int bannerID, int userModuleID, string imagePath, string caption, string linkToImage, string bannerName, string bannerdescription, int portalID, string hTMLBodyText, int imageID, string navigationImage, string readButtonText, string readMorePage, string description, string pageName);

        public string BannerDescription { get; set; }
        public int BannerID { get; set; }
        public string BannerName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string HTMLBodyText { get; set; }
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
        public string LinkToImage { get; set; }
        public string NavigationImage { get; set; }
        public string PageName { get; set; }
        public int PortalID { get; set; }
        public string ReadButtonText { get; set; }
        public string ReadMorePage { get; set; }
        public int UserModuleID { get; set; }
        public string TabPath { get; set; }
    }
}
