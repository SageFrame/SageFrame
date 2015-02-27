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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;

namespace SFE.GoogleAdUnit
{
    [
        DefaultProperty("AffiliateId"),
        ToolboxData("<{0}:LinkUnit runat=\"server\"></{0}:LinkUnit>")
    ]
    public class LinkUnit : BaseAdUnit
	{
		#region Class Members
		private LinkUnitFormat m_LinkUnitFormat = LinkUnitFormat.H_728x15;
        private LinkAdsPerUnit m_AdsPerUnit = LinkAdsPerUnit.AdCount_4;
		#endregion

		#region Public Properties

 		/// <summary>
		/// 
		/// </summary>
		public LinkUnitFormat LinkUnitFormat
		{
			get { return this.m_LinkUnitFormat; }
			set { this.m_LinkUnitFormat = value; }
		}

        /// <summary>
        /// 
        /// </summary>
        public LinkAdsPerUnit AdsPerUnit
        {
            get { return this.m_AdsPerUnit; }
            set { this.m_AdsPerUnit = value; }
        }

  		#endregion

		#region Helper Methods
		override protected void DesignTimeRender(System.Web.UI.HtmlTextWriter writer)
		{
			StringBuilder strStream = new StringBuilder();

            String strFormat = this.LinkUnitFormat.ToString();

            UnitDimensions obDim = AdUnitGlobals.g_LinkUnitDimensions[this.LinkUnitFormat] as UnitDimensions;
            if (strFormat.StartsWith("H"))
            {
                strStream.AppendFormat(AdUnitGlobals.g_strLinkUnitDesigntimeRender_H.ToString(), obDim.WIDTH, obDim.HEIGHT, DrawingUtil.GetColorHexFormat(this.BorderColor, false), DrawingUtil.GetColorHexFormat(this.TextColor, false), DrawingUtil.GetColorHexFormat(this.BackColor, false), "&nbsp;");
            }
            else
            {
                strStream.AppendFormat(AdUnitGlobals.g_strLinkUnitDesigntimeRender_V.ToString(), obDim.WIDTH, obDim.HEIGHT, DrawingUtil.GetColorHexFormat(this.BorderColor, false), DrawingUtil.GetColorHexFormat(this.TextColor, false), DrawingUtil.GetColorHexFormat(this.BackColor, false), "&nbsp;");
            }
            

			writer.Write(strStream.ToString());
		}
		
        override protected String GetAdFormat()
		{
            String strFormat = String.Empty;
            switch (this.LinkUnitFormat)
			{
                case LinkUnitFormat.H_468x15:
                    return "468x15_0ads_al";
                case LinkUnitFormat.S_200x90:
                    return "120x600_0ads_al";
                case LinkUnitFormat.S_180x90:
                    return "160x600_0ads_al";
                case LinkUnitFormat.S_160x90:
                    return "120x240_0ads_al";
                case LinkUnitFormat.S_120x90:
                    return "125x125_0ads_al";
                case LinkUnitFormat.H_728x15:
				default:
                    return "728x15_0ads_al";
			}

            //switch (this.AdsPerUnit)
            //{
            //    case LinkAdsPerUnit.AdCount_4:
            //        break;
            //    case LinkAdsPerUnit.AdCount_5:
            //        strFormat += "_s";
            //        break;
            //}

            //return strFormat;
		}

        internal override UnitDimensions GetUnitDimensions()
        {
            return AdUnitGlobals.g_LinkUnitDimensions[this.LinkUnitFormat] as UnitDimensions;
        }
		#endregion
	}
}
