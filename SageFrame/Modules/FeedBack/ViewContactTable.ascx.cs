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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.FeedBack;
using SageFrame.Web;
using SageFrame.Framework;
using System.Data;
using SageFrame.Web.Utilities;

namespace SageFrame.Modules.FeedBack
{
    public partial class ViewContactTable : BaseAdministrationUserControl
    {
        FeedBackDataContext dbViewContactTable = new FeedBackDataContext(SystemSetting.SageFrameConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);

            }
        }

        
        int BindCounter = 0;
        protected void gdvContactUs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ViewState["FeedBackdt"] != null)
                {
                    int pageIndex = gdvContactUs.PageIndex;
                    int pageSize = gdvContactUs.PageSize;
                    int rowIndex = e.Row.RowIndex;
                    BindCounter = BuildRowNumber(pageIndex, pageSize, rowIndex);
                    DataTable dt = (DataTable)ViewState["FeedBackdt"];
                    HiddenField hdnFID = e.Row.FindControl("hdnFID") as HiddenField;
                    Panel pnlCon = e.Row.FindControl("pnlCon") as Panel;
                    if (hdnFID != null && pnlCon != null)
                    {
                        int FeedBackID = Int32.Parse(hdnFID.Value);
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i != 0)
                            {
                                System.Web.UI.HtmlControls.HtmlGenericControl mdiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                                Label mlbl = new Label();
                                mlbl.Text = dt.Rows[BindCounter][i].ToString();
                                mdiv.Controls.Add(mlbl);
                                pnlCon.Controls.Add(mdiv);
                            }
                        }
                    }
                    //BindCounter++;
                }
            }
        }

        private int BuildRowNumber(int pageIndex, int pageSize , int rowIndex)
        {
            int ReturnValue = 0;
            if (pageIndex == 0)
            {
                ReturnValue = rowIndex;
            }
            else
            {
                ReturnValue = (pageIndex * pageSize) + rowIndex;
            }
            return ReturnValue;
        }

        protected void gdvContactUs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        protected void gdvContactUs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public DataSet GetSettingsByPortalAndSettingType(string PortalID, string Username)
        {
            try
            {
                List<KeyValuePair<string, string>> ParaMeterCollection = new List<KeyValuePair<string, string>>();
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, string>("@Username", Username));
                DataSet ds = new DataSet();
                SQLHandler sagesql = new SQLHandler();
                ds = sagesql.ExecuteAsDataSet("dbo.sp_FeedbackGetList", ParaMeterCollection);
                return ds;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetSettingsByPortal(string PortalID, string Username)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = GetSettingsByPortalAndSettingType(PortalID, Username);
                if (ds != null && ds.Tables != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];

                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BindGrid()
        {
            try
            {

                DataSet ds = GetSettingsByPortalAndSettingType(GetPortalID.ToString(), GetUsername);
                if (ds != null && ds.Tables != null && ds.Tables[0] != null)
                {
                    DataTable dt = ds.Tables[0];
                    ViewState["FeedBackdt"] = dt;
                    gdvContactUs.DataSource = dt;
                    gdvContactUs.DataBind();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void gdvContactUs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Delete":
                    try
                    {
                        dbViewContactTable.sp_FeedbackDeletebyFeedbackID(Id, GetPortalID, GetUsername);
                        ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("FeedBack", "RecordDeletedSuccessfully"), "", SageMessageType.Success);
                        BindGrid();
                    }

                    catch (Exception ex)
                    {
                        ProcessException(ex);
                    }

                    break;
            }
        }

        protected void gdvContactUs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gdvContactUs.PageIndex = e.NewPageIndex;
            BindGrid();

        }

       
    }
}