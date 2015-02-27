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


namespace SageFrame.Core.TemplateManagement
{
    public class TemplateController
    {
        public static List<TemplateInfo> GetTemplateList(int PortalID, string UserName)
        {
            try
            {
                return (TemplateDataProvider.GetTemplateList(PortalID, UserName));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool AddTemplate(TemplateInfo obj)
        {
            try
            {
                return (TemplateDataProvider.AddTemplate(obj));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
