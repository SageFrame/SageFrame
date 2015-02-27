using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.Web;
using SageFrame.WorkFlow;
using System.Text;

public partial class Modules_WFContent_WFView : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindContent();
    }
    public void BindContent()
    {
        WFController objController = new WFController();
        ContentInfo objContent = objController.ViewContent(GetPortalID, int.Parse(SageUserModuleID), GetCurrentCultureName);

        if (objContent != null)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<h2>");
            html.Append(objContent.WFName);
            html.Append("</h2>");
            html.Append("<p>");
            html.Append(objContent.Contents);
            html.Append("</p>");
            ltrViewContent.Text = html.ToString();
        }
    }
}
