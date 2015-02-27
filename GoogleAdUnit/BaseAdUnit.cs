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
using System.Text;
using System.Web.UI;
using System.Drawing;

namespace SFE.GoogleAdUnit
{
    /// <summary>
    /// Base class for AdUnit and LinkUnit controls
    /// </summary>
    public abstract class BaseAdUnit : Control
    {
        #region Class Members
        private String m_strAffiliateId = String.Empty;
        private String m_strChannelId = String.Empty;
        private String m_strTopLabel = String.Empty;
        private String m_strBottomLabel = String.Empty;
        private String m_strAnotherSiteUrl = String.Empty;
        private AlternateAdTypes m_AlternateAdType = AlternateAdTypes.PublicServiceAds;
        private System.Drawing.Color m_BorderColor = Color.AliceBlue;
        private System.Drawing.Color m_BackColor = Color.White;
        private System.Drawing.Color m_LinkColor = Color.Blue;
        private System.Drawing.Color m_TextColor = Color.Black;
        private System.Drawing.Color m_SolidFillColor = Color.Blue;
        private System.Drawing.Color m_UrlColor = Color.Green;
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        public String AffiliateId
        {
            get { return this.m_strAffiliateId; }
            set { this.m_strAffiliateId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ChannelId
        {
            get { return this.m_strChannelId; }
            set { this.m_strChannelId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String AnotherUrl
        {
            get { return this.m_strAnotherSiteUrl; }
            set { this.m_strAnotherSiteUrl = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AlternateAdTypes AlternateAdType
        {
            get { return this.m_AlternateAdType; }
            set { this.m_AlternateAdType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color TextColor
        {
            get { return this.m_TextColor; }
            set { this.m_TextColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color BackColor
        {
            get { return this.m_BackColor; }
            set { this.m_BackColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color BorderColor
        {
            get { return this.m_BorderColor; }
            set { this.m_BorderColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color LinkColor
        {
            get { return this.m_LinkColor; }
            set { this.m_LinkColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color UrlColor
        {
            get { return this.m_UrlColor; }
            set { this.m_UrlColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color SolidFillColor
        {
            get { return this.m_SolidFillColor; }
            set { this.m_SolidFillColor = value; }
        }
        #endregion

        #region Override Methods
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                DesignTimeRender(writer);
            }
            else
            {
                RunTimeRender(writer);
            }
        }
        #endregion

        #region Helper Methods
        protected virtual void DesignTimeRender(System.Web.UI.HtmlTextWriter writer)
        {

        }

        protected void RunTimeRender(System.Web.UI.HtmlTextWriter writer)
        {
            if (null == AffiliateId ||
                String.Empty == AffiliateId)
            {
                throw new ApplicationException("No client id has been specified");
            }

            UnitDimensions obDim = GetUnitDimensions();

            writer.Write("<div id=\"{0}\">", this.ClientID);

            writer.Write("<script type=\"text/javascript\">");
            writer.Write(String.Format("google_ad_client=\"{0}\";", this.AffiliateId));
            switch (this.AlternateAdType)
            {
                case AlternateAdTypes.AnotherUrlAds:
                    writer.Write(String.Format("google_alternate_ad_url=\"{0}\";", this.AnotherUrl));
                    break;
                case AlternateAdTypes.SolidColorFill:
                    writer.Write(String.Format("google_alternate_color=\"{0}\";", DrawingUtil.GetColorHexFormat(this.SolidFillColor, true)));
                    break;
            }
            writer.Write(String.Format("google_ad_width={0};", obDim.WIDTH));
            writer.Write(String.Format("google_ad_height={0};", obDim.HEIGHT));
            writer.Write(String.Format("google_ad_format=\"{0}\";", this.GetAdFormat()));
            writer.Write(String.Format("google_ad_channel=\"{0}\";", this.ChannelId));
            writer.Write(String.Format("google_color_border=\"{0}\";", DrawingUtil.GetColorHexFormat(this.BorderColor, true)));
            writer.Write(String.Format("google_color_bg=\"{0}\";", DrawingUtil.GetColorHexFormat(this.BackColor, true)));
            writer.Write(String.Format("google_color_link=\"{0}\";", DrawingUtil.GetColorHexFormat(this.LinkColor, true)));
            writer.Write(String.Format("google_color_url=\"{0}\";", DrawingUtil.GetColorHexFormat(this.UrlColor, true)));
            writer.Write(String.Format("google_color_text=\"{0}\";", DrawingUtil.GetColorHexFormat(this.TextColor, true)));

            InsertSpecificScript(writer);

            writer.Write("</script>");
            writer.Write("<script type=\"text/javascript\"");
            writer.Write(" src=\"http://pagead2.googlesyndication.com/pagead/show_ads.js\">");
            writer.Write("</script>");

            writer.Write("</div>");
        }

        protected virtual void InsertSpecificScript(System.Web.UI.HtmlTextWriter writer)
        {

        }

        protected virtual String GetAdFormat()
        {
            return String.Empty;
        }

        protected virtual String GetAdType()
        {
            return String.Empty;
        }

        internal virtual UnitDimensions GetUnitDimensions()
        {
            return null;
        }
        #endregion
    }
}
