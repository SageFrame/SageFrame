#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Web;

#endregion


/// <summary>
/// Summary description for SageFrameEnums
/// </summary>
/// 
namespace SageFrame.Web
{
    public class SageFrameEnums
    {
        public SageFrameEnums()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public enum ECTDataTypes
        {
            Integer = 1,
            Decimal = 2,
            String = 3
        }

        public enum ErrorType
        {
            Unknown,
            CustomerError,
            MailError,
            OrderError,
            AdministrationArea,
            CommonError,
            ShippingErrror,
            TaxError,
            WCF,
            WebService,
            PageMethod
        }

        public enum ViewPermissionType
        {
            View = 0,
            Edit = 1
        }

        

        public enum ControlType
        {
            View = 1,
            Edit = 2,
            Setting = 3
        }


    }

    public enum SageMessageType
    {
        Success,
        Error,
        Alert
    }

    public enum SageMessageTitle
    {
        Information,
        Notification,
        Exception
    }   

}

namespace SageFrame.Modules.Admin.PortalSettings
{
    public enum SettingType
    {
        SiteAdmin,
        SuperUser
    }
}