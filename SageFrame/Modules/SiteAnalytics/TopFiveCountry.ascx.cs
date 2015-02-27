using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using DashBoardControl.Info;
using DashBoardControl;
using SageFrame.Framework;

public partial class Modules_SiteAnalytics_TopFiveCountry : BaseAdministrationUserControl
{
    public string topCountry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        IncludeJs("SiteAnalytics", "/Modules/SiteAnalytics/pjs/jquery.jqplot.min.js");
        IncludeJs("SiteAnalytics", "/Modules/SiteAnalytics/pjs/excanvas.min.js");
        IncludeJs("SiteAnalytics", "/Modules/SiteAnalytics/pjs/jqplot.pieRenderer.min.js");
        IncludeCss("SiteAnalytics", "/Modules/SiteAnalytics/css/jquery.jqplot.css");
        GetTopFiveCountryName();
        hyLnkSiteAnalytics.NavigateUrl = GetHostURL() + "/Admin/Site-Analytics" + SageFrameSettingKeys.PageExtension;
    }

    public void GetTopFiveCountryName()
    {
        string startDate = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0, 0)).ToShortDateString();
        string endDate = DateTime.Now.ToShortDateString();
        List<DashBoardSettingInfo> lstTopVisitedCountry = DashBoardController.GetTopFiveVisitedCountry(startDate, endDate);
        string CountryName;
        IPAddressToCountryResolver objIP = new IPAddressToCountryResolver();
        List<string> topCountryArray = new List<string>();
        int totalVisitors = 0;
        foreach (DashBoardSettingInfo obj in lstTopVisitedCountry)
        {
            objIP.GetCountry(obj.Country, out CountryName);
            if (CountryName == null)
            {
                obj.Country = obj.Country;
            }
            else
            {
                obj.Country = CountryName;
            }
            topCountryArray.Add(obj.Country);
            topCountryArray.Add(obj.VisitTime);
            totalVisitors += Int16.Parse(obj.VisitTime);
        }
        topCountry = string.Join(",", topCountryArray.ToArray());
        ltrTotal.Text = "<label>Total Visitors:  " + totalVisitors + "</label>";
    }
}
