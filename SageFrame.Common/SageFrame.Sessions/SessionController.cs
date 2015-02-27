#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Text;
using System.Web; 

#endregion

namespace SageFrame.Common
{
    public class SessionController
    {
        public SessionController()
        {
        }

        public void SetSession(string sessionKey, object objSessionValue)
        {
            HttpContext.Current.Session[sessionKey] = objSessionValue;
        }

        public T GetSessionValue<T>(string sessionKey)
        {
            return (T)HttpContext.Current.Session[sessionKey];
        }


    }
}
