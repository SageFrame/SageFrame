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

namespace SageFrame.Common.Shared
{
    public class EncodingHelper
    {
        /// <summary>
        /// Base 64 encoding/decoding
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }
        public static string Decode(string str)
        {
            byte[] decbuff = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }
        /// <summary>
        /// UTF-8 Encoding/decoding
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        
        public static string Encodeutf8(string str)
        {
            return(HttpContext.Current.Server.HtmlEncode(str));
        }
        public static string Decodeutf8(string str)
        {
            return (HttpContext.Current.Server.HtmlDecode(str));
        }

    }
}
