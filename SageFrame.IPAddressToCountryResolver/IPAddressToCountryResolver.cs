#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Net;
#endregion

namespace SageFrame.Framework
{
    public class IPAddressToCountryResolver
    {
        public IPAddressToCountryResolver()
        {
        }

        public bool GetCountry(string userHostIpAddress, out string countryName)
        {
            bool result = false;
            countryName = string.Empty;

            if (string.IsNullOrEmpty(userHostIpAddress))
                return false;

            IPAddress ipAddress;
            userHostIpAddress = GetIP4Address(userHostIpAddress);
                if (IPAddress.TryParse(userHostIpAddress, out ipAddress))
                {
                    countryName = ipAddress.Country();

                    result = true;
                }
           

            return result;
        }

        public static string GetIP4Address(string ipaddress)
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(ipaddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }
    }

}
