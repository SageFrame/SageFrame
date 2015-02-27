#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace SageFrame.Web
{
    public class SageFrameStringKeyValue
    {
        string _Key = string.Empty;
        string _Value = string.Empty;

        public SageFrameStringKeyValue()
        {
        }

        public SageFrameStringKeyValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key
        {
            set { _Key = value; }
            get { return _Key; }
        }

        public string Value
        {
            set { _Value = value; }
            get { return _Value; }
        }
    }

    public class SageFrameIntKeyValue
    {
        int _Key = 0;
        string _Value = string.Empty;

        public SageFrameIntKeyValue()
        {
        }

        public SageFrameIntKeyValue(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int Key
        {
            set { _Key = value; }
            get { return _Key; }
        }

        public string Value
        {
            set { _Value = value; }
            get { return _Value; }
        }
    } 
}
