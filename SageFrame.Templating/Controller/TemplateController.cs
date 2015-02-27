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
#endregion

namespace SageFrame.Templating
{
    public class TemplateController
    {
        public static void ActivateTemplate(string TemplateName, int PortalID)
        {
            try
            {
                TemplateDataProvider.ActivateTemplate(TemplateName, PortalID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static TemplateInfo GetActiveTemplate(int PortalID)
        {
            try
            {
                return (TemplateDataProvider.GetActiveTemplate(PortalID));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static void UpdActivateTemplate(string TemplateName, string conn)
        {
            try
            {
                TemplateDataProvider.UpdActivateTemplate(TemplateName, conn);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static SettingInfo GetSettingByKey(SettingInfo objSetting)
        {
            try
            {
                return (TemplateDataProvider.GetSettingByKey(objSetting));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<TemplateInfo> GetPortalTemplates()
        {
            return TemplateDataProvider.GetPortalTemplates();
        }
    }
}
