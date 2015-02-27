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

namespace SageFrame.Application
{
    public enum ReleaseMode
    {

        None,
        Alpha,
        Beta,
        RC,
        Stable,
    }

    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyStatusAttribute : System.Attribute
    {
        private ReleaseMode _releaseMode;

        public AssemblyStatusAttribute(ReleaseMode releaseMode)
        {
            _releaseMode = releaseMode;
        }

        public ReleaseMode Status
        {
            get
            {
                return _releaseMode;
            }
        }
    }
}
