using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SageFrame.Web;

public partial class Modules_Counter_CounterSetting : BaseAdministrationUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet tmpDs = new DataSet();
            //tmpDs.ReadXml(Server.MapPath("~/Modules/counter.xml"));

            //int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());

            //hits += 1;

            tmpDs.Tables[0].Rows[0]["hits"] = 0.ToString();

            tmpDs.WriteXml(Server.MapPath("~/Modules/Counter/counter.xml"));
        }
        catch
        {
            btnClear.Text = "Not Cleared";
        }
    }
}