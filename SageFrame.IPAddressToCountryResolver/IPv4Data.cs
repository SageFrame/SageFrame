#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Runtime.CompilerServices;
#endregion

namespace SageFrame.Framework
{
    internal class IPv4Data
    {
        public long Assigned
        {

            get;
            set;
        }

        public string Country
        {

            get;
            set;
        }

        public long IpFrom
        {
            get;
            set;
        }

        public long IpTo
        {
            get;
            set;
        }

        public string Iso3166ThreeLetterCode
        {
            get;
            set;
        }

        public string Iso3166TwoLetterCode
        {
            get;
            set;
        }

        public string Registry
        {
            get;
            set;
        }
    }
}

