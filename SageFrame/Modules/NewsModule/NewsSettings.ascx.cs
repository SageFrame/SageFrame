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
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SageFrame.News;
using SageFrame.Web;
using SageFrame.SageFrameClass;

namespace SageFrame.Modules.NewsModule
{
    public partial class NewsSettings : BaseAdministrationUserControl
    {
        NewsDataContext dbNewsSetting = new NewsDataContext(SystemSetting.SageFrameConnectionString);
        public Int32 usermoduleIDControl = 0;
        System.Nullable<Int32> _newsSettingValueID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                usermoduleIDControl = Int32.Parse(SageUserModuleID);
                if (!Page.IsPostBack)
                {
                    AddImageUrl();
                    LoadNewsSettingtoControl();
                    LoadCategorySettingtoControl();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void AddImageUrl()
        {
            imbSaveCategorySetting.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbSaveNewsSetting.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
        }

        private void LoadCategorySettingtoControl()
        {
            try
            {
                lstNewsCategoryLists.Items.Clear();
                BindNewsCategoryList();
                var News = dbNewsSetting.sp_NewsSettingGetAll(usermoduleIDControl, GetPortalID);

                //DataTable dtNews = comm.LINQToDataTable(News);
                //for (int i = 0; i < dtNews.Rows.Count; i++)
                //{
                //    switch (dtNews.Rows[i]["SettingKey"].ToString())
                //    {
                //        case "MaxCategoryCount":
                //            txtMaxNumberOfCategory.Text = dtNews.Rows[i]["SettingValue"].ToString();
                //            break;
                //        case "CategoryImageSizeKB":
                //            txtIconSize.Text = dtNews.Rows[i]["SettingValue"].ToString();
                //            break;
                //    }
                //}

                foreach (sp_NewsSettingGetAllResult setting in News)
                {
                    switch (setting.SettingKey)
                    {
                        case "CategoryToShow":
                            string[] dbCategoryToShow = null;                            
                            string defaultCategoryToShow = setting.SettingValue.ToString();
                            char[] seperators = { ',' };
                            if (defaultCategoryToShow.Contains(seperators[0].ToString()))
                            {
                                dbCategoryToShow = defaultCategoryToShow.Split(seperators);
                            }
                            else
                            {
                                dbCategoryToShow = new string[] { defaultCategoryToShow };
                            }
                            for (int j = 0; j < dbCategoryToShow.Length; j++)
                            {
                                for (int i = 0; i < lstNewsCategoryLists.Items.Count; i++)
                                {
                                    if (lstNewsCategoryLists.Items[i].Value == dbCategoryToShow[j].ToString() && !lstNewsCategoryLists.Items[i].Selected)
                                    {
                                        lstNewsCategoryLists.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                            break;
                        case "MaxCategoryCount":
                            txtMaxNumberOfCategory.Text = setting.SettingValue.ToString();
                            break;
                        case "CategoryImageSizeKB":
                            txtIconSize.Text = setting.SettingValue.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindNewsCategoryList()
        {
            try
            {
                lstNewsCategoryLists.DataSource = dbNewsSetting.sp_NewsCategory(GetPortalID, true);
                lstNewsCategoryLists.DataTextField = "NewsCategory";
                lstNewsCategoryLists.DataValueField = "NewsCategoryID";
                lstNewsCategoryLists.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void BindDefaultSorting()
        {
            try
            {
                ddlDefaultSorting.DataSource = SageFrameLists.NewsSorting();
                ddlDefaultSorting.DataTextField = "Value";
                ddlDefaultSorting.DataValueField = "Key";
                ddlDefaultSorting.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        private void BindDateFormat()
        {
            try
            {
               
                ddlDateFormat.DataSource = SageFrameLists.DateFormat();
                ddlDateFormat.DataTextField = "Value";
                ddlDateFormat.DataValueField = "Key";
                ddlDateFormat.DataBind();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }        

        private void LoadNewsSettingtoControl()
        {
            try
            {
                ddlDefaultSorting.Items.Clear();
                BindDefaultSorting();
                ddlDateFormat.Items.Clear();
                BindDateFormat();
                var News = dbNewsSetting.sp_NewsSettingGetAll(usermoduleIDControl, GetPortalID);
                foreach (sp_NewsSettingGetAllResult setting in News)
                {
                    switch (setting.SettingKey)
                    {
                        case "NewsModuleTitle":
                            txtNewsModuleTitle.Text = setting.SettingValue.ToString();
                            break;
                        case "NewsDefaultSorting":
                            ddlDefaultSorting.SelectedIndex = ddlDefaultSorting.Items.IndexOf(ddlDefaultSorting.Items.FindByValue(setting.SettingValue.ToString()));
                            break;
                        case "NewsDateFormat":
                            ddlDateFormat.SelectedIndex = ddlDateFormat.Items.IndexOf(ddlDateFormat.Items.FindByValue(setting.SettingValue.ToString()));
                            break;
                        case "NewsCount":
                            txtNumberOfNews.Text = setting.SettingValue.ToString();
                            break;
                        case "MoreNewsText":
                            txtMoreNewsText.Text = setting.SettingValue.ToString();
                            break;                        
                        case "MoreNewsPageName":
                            txtMoreNewsPageName.Text = setting.SettingValue.ToString();
                            break;                        
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbSaveCategorySetting_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string values = string.Empty;
                for (int i = 0; i < lstNewsCategoryLists.Items.Count; i++)
                {
                    if (lstNewsCategoryLists.Items[i].Selected)
                        // append values with commas
                        values += lstNewsCategoryLists.Items[i].Value + ",";
                }
                if (values != string.Empty)
                {
                    values = values.Remove(values.LastIndexOf(","));
                    SaveSetting("CategoryToShow", values);
                }

                SaveSetting("MaxCategoryCount", txtMaxNumberOfCategory.Text);
                SaveSetting("CategoryImageSizeKB", txtIconSize.Text);
               // ShowMessage(SageMessageTitle.Information.ToString(), "Category Setting Saved Successfully.", "", SageMessageType.Success);
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "CategorySettingSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbSaveNewsSetting_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SaveSetting("NewsModuleTitle", txtNewsModuleTitle.Text);
                SaveSetting("NewsDefaultSorting", ddlDefaultSorting.SelectedValue);
                SaveSetting("NewsDateFormat", ddlDateFormat.SelectedValue);
                SaveSetting("NewsCount", txtNumberOfNews.Text);
                SaveSetting("MoreNewsText", txtMoreNewsText.Text);
                SaveSetting("MoreNewsPageName", txtMoreNewsPageName.Text);
               // ShowMessage(SageMessageTitle.Information.ToString(), "News Setting Saved Successfully.", "", SageMessageType.Success);
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("NewsModule", "NewsSettingSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void SaveSetting(string key, string value)
        {
            dbNewsSetting.sp_NewsSettingUpdate(ref _newsSettingValueID, usermoduleIDControl, key, value, true, GetPortalID, GetUsername, GetUsername);
        }
    }
}