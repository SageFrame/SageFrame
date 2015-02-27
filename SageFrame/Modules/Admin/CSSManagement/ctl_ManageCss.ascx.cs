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
using System.IO;
using SageFrame.Web;
using SageFrame.Framework;
using System.Collections;

namespace SageFrame.Modules.Admin.CSSManagement
{
    public partial class ctl_ManageCss : BaseAdministrationUserControl
    {
        SageFrameConfig pb = new SageFrameConfig();
        private static string path = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    AddImageUrls();
                    path = Server.MapPath("~/Templates/" + pb.GetSettingsByKey(SageFrameSettingKeys.PortalCssTemplate) + "/css");
                    BindCSSFile();
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }
        private void BindCSSFile()
        {
           
           try
           {

               string[] files = Directory.GetFiles(path);
               ArrayList arrColl = new ArrayList();
               if (files.Length > 0)
               {
                   foreach (string str in files)
                   {
                       string tempstr = str.Remove(0, str.LastIndexOf("\\") + 1);
                       if (tempstr.Length > 4)
                       {
                           if (tempstr.Substring(tempstr.Length - 4).ToLower() == ".css")
                           {
                               arrColl.Add(tempstr);
                           }
                       }
                   }
               }

               ddlCssFileList.DataSource = arrColl;
               ddlCssFileList.DataBind();
               ddlCssFileList.Items.Insert(0, new ListItem("--Select--", "-1"));
           }
           catch (Exception ex)
           {
               ProcessException(ex);
           } 

        }
        private void AddImageUrls()
        {
            imbSave.ImageUrl = GetTemplateImageUrl("imgsave.png", true);
            imbRefresh.ImageUrl = GetTemplateImageUrl("imgrefresh.png", true);
        }
        protected void imbSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SaveCssContent(path + "\\" + ddlCssFileList.SelectedValue);
                ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("CSSManagement", "CSSIsSavedSuccessfully"), "", SageMessageType.Success);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LoadCSSContent(path + "\\" + ddlCssFileList.SelectedValue);
            }
            catch(Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void ddlCssFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCssFileList.SelectedValue != "-1" && ddlCssFileList.SelectedIndex != -1)
            {
                LoadCSSContent(path + "\\" + ddlCssFileList.SelectedValue);
            }
        }

        private void LoadCSSContent(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            txtFileContent.Text = sr.ReadToEnd();
            sr.Close();
            file.Close();

        }

        private void SaveCssContent(string filePath)
        {
            File.Delete(filePath);
            FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(txtFileContent.Text);
            sw.Close();
            file.Close();
        }
    }
}