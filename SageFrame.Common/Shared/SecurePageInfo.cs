#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
#endregion


namespace SageFrame.Common
{
    [DataContract]
    [Serializable]
    public class SecurePageInfo
    {
        public SecurePageInfo()
        {
        }
        private string _SecurePageName;
        private bool _IsSecure;
        [DataMember]
        public string SecurePageName
        {
            get
            {
                return this._SecurePageName;
            }
            set
            {
                if ((this._SecurePageName != value))
                {
                    this._SecurePageName = value;
                }
            }
        }
        [DataMember]
        public bool IsSecure
        {
            get
            {
                return this._IsSecure;
            }
            set
            {
                if ((this._IsSecure != value))
                {
                    this._IsSecure = value;
                }
            }
        }
    }
}
