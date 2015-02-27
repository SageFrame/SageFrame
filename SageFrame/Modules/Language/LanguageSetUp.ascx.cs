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
using SageFrame.Web.Utilities;
using SageFrame.Localization;
using System.Web.UI.WebControls;
using SageFrame.Web;
using System.Threading;

public partial class Modules_Language_LanguageSetUp : BaseAdministrationUserControl
{
    public event ImageClickEventHandler CancelButtonClick;
    private string languageMode = "Normal";
    public string appPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Request.ApplicationPath != "/" ? Request.ApplicationPath : "";
        if (!Page.IsPostBack)
        {
            LoadAllCultures();           
            GetFlagImage();            
        }
    }
    public void LoadAllCultures()
    {
        string mode = languageMode == "Native" ? "NativeName" : "LanguageName";
        List<Language> lstAllCultures = LocaleController.GetCultures();
        List<Language> lstAvailableLocales = LocalizationSqlDataProvider.GetAvailableLocales();
        ddlLanguage.DataSource = FilterLocales(lstAllCultures, lstAvailableLocales);
        ddlLanguage.DataTextField = mode;
        ddlLanguage.DataValueField = "LanguageCode";
        ddlLanguage.DataBind();
        

    }
    protected List<Language> FilterLocales(List<Language> lstAllCultures, List<Language> lstAvailableLocales)
    {
        List<Language> lstNotAvailableLocales = new List<Language>();
        foreach (Language objLang in lstAllCultures)
        {
            bool isExist = lstAvailableLocales.Exists(
                    delegate(Language obj)
                    {
                        return (obj.LanguageCode == objLang.LanguageCode);
                    }
                );
            if (!isExist)
                lstNotAvailableLocales.Add(objLang);
        }
        return lstNotAvailableLocales;
    }
    //public void LoadAvailableLocales()
    //{
    //    string mode = languageMode == "Native" ? "NativeName" : "LanguageName";
    //    List<Language> lstAvailableLocales =LocaleController.AddNativeNamesToList(LocalizationSqlDataProvider.GetAvailableLocales());
    //    int index = lstAvailableLocales.FindIndex(delegate(Language obj) { return (obj.LanguageCode == Thread.CurrentThread.CurrentCulture.ToString()); });
    //    if (index > -1)
    //    {
    //        lstAvailableLocales[index].LanguageName += "[Site Default]";

    //    }
    //    ddlFallBack.DataSource = lstAvailableLocales;
    //    ddlFallBack.DataTextField = mode;
    //    ddlFallBack.DataValueField = "LanguageCode";
    //    ddlFallBack.DataBind();
    //    if (index > -1)
    //    {
    //        ddlFallBack.SelectedIndex = index;

    //    }
        
    //}

    protected void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
        CancelButtonClick(sender,e);
    }
    protected void imbUpdate_Click(object sender, ImageClickEventArgs e)
    {
        AddNewLanguage();
    }
    protected void AddNewLanguage()
    {
        Language objLang = new Language();
        objLang.LanguageName = this.ddlLanguage.SelectedItem.ToString();
        objLang.LanguageCode = this.ddlLanguage.SelectedValue.ToString();
        objLang.FallBackLanguage = "English";
        objLang.FallBackLanguageCode = "en-US";
        try
        {
            LocalizationSqlDataProvider.AddLanguage(objLang);
            ShowMessage(SageMessageTitle.Information.ToString(), GetSageMessage("LanguageModule", "LanguageAddedSuccessfully"), "", SageMessageType.Success);
            //LoadAvailableLocales();
            LoadAllCultures();
            GetFlagImage();
        }
        catch (Exception ex)
        {

            ProcessException(ex);
        }
        
    }
   
    protected void GetFlagImage()
    {
        string code = this.ddlLanguage.SelectedValue;
        imgFlagLanguage.ImageUrl = ResolveUrl("~/images/flags/" + code.Substring(code.IndexOf("-") + 1) + ".png");
        
    }
    //protected void GetFlagImageFallback()
    //{
    //   string  code = this.ddlFallBack.SelectedValue;
    //    imgFallback.ImageUrl = ResolveUrl(this.AppRelativeTemplateSourceDirectory + "flags/" + code.Substring(code.IndexOf("-") + 1) + ".png");

    //}
    //protected void ddlFallBack_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetFlagImageFallback();
    //}
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetFlagImage();
    }
    protected void rbLanguageType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rbLanguageType.SelectedIndex)
        {
            case 0:
                LoadAllCultures();
                //LoadAvailableLocales();
                GetFlagImage();
                //GetFlagImageFallback();
                break;
            case 1:
                LoadNativeNames();
                break;
        }
    }

    protected void LoadNativeNames()
    {
        languageMode = "Native";
        LoadAllCultures();
        //LoadAvailableLocales();
        GetFlagImage();
        //GetFlagImageFallback();
    }
  
}
