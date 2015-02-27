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
        /// <summary>
        /// Initializes a new instance SessionController 
        /// </summary>
        public SessionController()
        {
        }
        /// <summary>
        /// Set session value.
        /// </summary>
        /// <param name="sessionKey">sessionKey</param>
        /// <param name="objSessionValue">objSessionValue</param>
        public void SetSession(string sessionKey, object objSessionValue)
        {
            HttpContext.Current.Session[sessionKey] = objSessionValue;
        }
        /// <summary>
        /// Get session value.
        /// </summary>
        /// <typeparam name="T">Type of the object implementing.</typeparam>
        /// <param name="sessionKey">sessionKey</param>
        /// <returns>Session value.</returns>
        public T GetSessionValue<T>(string sessionKey)
        {
            return (T)HttpContext.Current.Session[sessionKey];
        }


    }
}
