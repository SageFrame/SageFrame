/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.BreadCrum.Controller
{
    public class BreadCrumbController
    {
        public List< BreadCrumInfo> GetBreadCrumb(string SEOName, int PortalID, int MenuId, string CultureCode)
        {
            try
            {
                BreadCrumDataProvider dp = new BreadCrumDataProvider();
                return (dp.GetBreadCrumb(SEOName, PortalID, MenuId, CultureCode));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
