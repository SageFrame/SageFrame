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
using System.Data;
using SageFrame.Localization;
using System.Xml;
using System.IO;
using SageFrame.Web;

public partial class Modules_Language_TimeZoneEditor : BaseAdministrationUserControl
{
    public event ImageClickEventHandler CancelButtonClick;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAvailableLocales();
            BindGrid(Localization.SystemLocale);
            GetFlagImage();
        }
    }
    protected void BindGrid(string language)
    {
        DataSet ds = new DataSet();
        bool isExists = File.Exists(Server.MapPath(ResourceFile(Localization.TimezonesFile, language, true)));
        if (isExists)
        {
            ds.ReadXml(Server.MapPath(ResourceFile(Localization.TimezonesFile, language, isExists)));
            gdvTimeZoneEditor.DataSource = ds;
            gdvTimeZoneEditor.DataBind();
        }
       
    }
    protected void BindAvailableLocales()
    {
        this.ddlAvailableLocales.DataSource = LocalizationSqlDataProvider.GetAvailableLocales();
        this.ddlAvailableLocales.DataTextField = "LanguageName";
        this.ddlAvailableLocales.DataValueField = "LanguageCode";
        this.ddlAvailableLocales.DataBind();
    }
    private string ResourceFile(string filename, string language,bool isExists)
    {
        return(isExists?filename.Substring(0, filename.Length - 4) + "." + language + ".xml":filename);
    }
    protected void imbCancel_Click(object sender, ImageClickEventArgs e) {CancelButtonClick(sender, e);}
    protected void ddlAvailableLocales_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid(this.ddlAvailableLocales.SelectedValue.ToString());
        GetFlagImage();
    }
    protected void imbUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string filename=Localization.TimezonesFile;
        string language=this.ddlAvailableLocales.SelectedValue;
        string destinationFileName=Server.MapPath(filename.Substring(0, filename.Length - 4) + "." + language + ".xml");

        XmlNode node;
        XmlDocument resDoc = new XmlDocument();
        bool isExist = File.Exists(destinationFileName);   
            try
            {                
                resDoc.Load(Server.MapPath(ResourceFile(Localization.TimezonesFile, this.ddlAvailableLocales.SelectedValue, isExist)));
                foreach (GridViewRow row in gdvTimeZoneEditor.Rows)
                {
                    TextBox ctl = (TextBox)row.Cells[0].Controls[1];
                    node = resDoc.SelectSingleNode("//root/timezone[@key='" + row.Cells[1].Text + "']");
                    node.Attributes["name"].Value = ctl.Text;
                }
                switch (isExist)
                {
                    case true:
                        UpdateTimeZoneFile(resDoc);
                        break;
                    default:
                        CreateNewTimeZoneFile(resDoc, destinationFileName);
                        break;
                }

              ShowMessage(SageMessageTitle.Information.ToString(), "TimeZone file is saved successfully!", "", SageMessageType.Success);               
              BindGrid(this.ddlAvailableLocales.SelectedValue);           
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }       
    }
    protected void UpdateTimeZoneFile(XmlDocument resDoc)
    {
        File.SetAttributes(Server.MapPath(ResourceFile(Localization.TimezonesFile, this.ddlAvailableLocales.SelectedValue, true)), FileAttributes.Normal);
        resDoc.Save(Server.MapPath(ResourceFile(Localization.TimezonesFile, this.ddlAvailableLocales.SelectedValue, true)));
    }
    protected void CreateNewTimeZoneFile(XmlDocument resDoc, string fileName)
    {
        File.Copy(Server.MapPath(Localization.TimezonesFile), fileName);
        File.SetAttributes(fileName, FileAttributes.Normal);
        resDoc.Save(fileName);
    }
    protected void GetFlagImage()
    {
        string code=this.ddlAvailableLocales.SelectedValue;
        imgFlag.ImageUrl=ResolveUrl("~/images/flags/"+code.Substring(code.IndexOf("-") + 1)+".png");
    }
}
