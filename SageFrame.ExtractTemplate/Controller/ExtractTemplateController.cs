#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
#endregion

namespace SageFrame.ExtractTemplate
{
    public class ExtractTemplateController
    {

        public List<TemplatePermission> GetTemplatePermission(string userModuleID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            return objDataProvider.GetTemplatePermission(userModuleID);
        }
        public List<ExtractInfo> GetTemplateDetails(string paneName, int portalID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            return objDataProvider.GetTemplateDetails(paneName, portalID);
        }

        public DataSet MakeHtmlDataSet(string HtmlUserModuleID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            return objDataProvider.MakeHtmlDataSet(HtmlUserModuleID);
        }
        //Insert  Template 

        public void InsertTemplate(List<ExtractPageInfo> lstPageList, List<TemplateMenuAll> objTemplateMenuall, int portalID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            objDataProvider.InsertTemplate(lstPageList, objTemplateMenuall, portalID);
        }

        public List<PagePermission> GetPagePermission(string pageID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            return objDataProvider.GetPagePermission(pageID);
        }

        public DataSet GetMenuDetail(int portalID, string menuUserModuleID)
        {
            ExtractTemplateDataProvider objDataProvider = new ExtractTemplateDataProvider();
            return objDataProvider.GetMenuDetail(portalID, menuUserModuleID);
        }
    }
}
