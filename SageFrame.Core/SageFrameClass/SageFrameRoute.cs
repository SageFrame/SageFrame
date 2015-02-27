#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

#endregion


namespace SageFrame
{
    public interface SageFrameRoute : IHttpHandler
    {
        string PagePath { get; set; }
        string PortalSEOName { get; set; }
        string UserModuleID { get; set; }
        string ControlType { get; set; }
		string ControlMode { get; set; }
        string Key { get; set; }
        string Param { get; set; }
    }
}
