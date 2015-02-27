#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
#endregion

namespace SageFrame.Framework
{
    public static class IPAddressExtensions
    {
        private static IList<IPv4Data> _dataList;
        private static object _syncObject = new object();

        public static DateTimeOffset? AssignedDateTime(this IPAddress ipAddress)
        {
            IPv4Data data = GetIPv4Data(ipAddress);
            if (data == null)
            {
                return null;
            }
            DateTimeOffset offset = new DateTimeOffset(0x7b2, 1, 1, 0, 0, 0, 0, new TimeSpan(0, 0, 0));
            return new DateTimeOffset?(offset.AddSeconds((double)data.Assigned));
        }

        public static string Country(this IPAddress ipAddress)
        {
            IPv4Data data = GetIPv4Data(ipAddress);
            if (data != null)
            {
                return data.Country;
            }
            return null;
        }

        private static IPv4Data GetIPv4Data(IPAddress ipAddress)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException("ipAddress");
            }
            if (ipAddress.AddressFamily != AddressFamily.InterNetwork)
            {
                throw new ArgumentException("Only Internet Protocol version 4 (IPv4) addresses are accepted.");
            }
            if (DataList == null)
            {
                throw new InvalidOperationException("Internet Protocol (IPv4) address list was not successfully loaded into memory. Unable to process your request.");
            }
            byte[] addressBytes = ipAddress.GetAddressBytes();
            long ipAddressLong = (long)((((long)(addressBytes[3] + (addressBytes[2] * 0x100L))) + ((addressBytes[1] * 0x100L) * ((long)0x100L))) + (((addressBytes[0] * 0x100L) * ((long)0x100L)) * ((long)0x100L)));
            return DataList.Where<IPv4Data>(delegate(IPv4Data d)
            {
                return ((d.IpFrom <= ipAddressLong) && (d.IpTo >= ipAddressLong));
            }).SingleOrDefault<IPv4Data>();
        }

        public static string Iso3166ThreeLetterCode(this IPAddress ipAddress)
        {
            IPv4Data data = GetIPv4Data(ipAddress);
            if (data != null)
            {
                return data.Iso3166ThreeLetterCode;
            }
            return null;
        }

        public static string Iso3166TwoLetterCode(this IPAddress ipAddress)
        {
            IPv4Data data = GetIPv4Data(ipAddress);
            if (data != null)
            {
                return data.Iso3166TwoLetterCode;
            }
            return null;
        }

        private static IList<IPv4Data> ReadInCSVFile()
        {
            IList<IPv4Data> list = null;
            //string[] aa = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //SageFrame.IPAddressToCountryResolver.data.csv.gz
            //using (GZipStream stream = new GZipStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("SageFrame.IPAddressToCountryResolver.WorldDomination.Net.Data.csv.gz"), CompressionMode.Decompress))
            using (GZipStream stream = new GZipStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("SageFrame.IPAddressToCountryResolver.data.csv.gz"), CompressionMode.Decompress))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(str) && !str.StartsWith("#", StringComparison.OrdinalIgnoreCase))
                        {
                            long num;
                            long num2;
                            long num3;
                            string[] strArray = str.Replace("\"", string.Empty).Split(new char[] { ',' });
                            if ((((strArray != null) && (strArray.Length == 7)) && (long.TryParse(strArray[0], out num) && long.TryParse(strArray[1], out num2))) && long.TryParse(strArray[3], out num3))
                            {
                                if (list == null)
                                {
                                    list = new List<IPv4Data>();
                                }
                                IPv4Data item = new IPv4Data();
                                item.IpFrom = num;
                                item.IpTo = num2;
                                item.Registry = strArray[2];
                                item.Assigned = num3;
                                item.Iso3166TwoLetterCode = strArray[4];
                                item.Iso3166ThreeLetterCode = strArray[5];
                                item.Country = strArray[6];
                                list.Add(item);
                            }
                        }
                    }
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                return list;
            }
            return null;
        }

        public static string Registry(this IPAddress ipAddress)
        {
            IPv4Data data = GetIPv4Data(ipAddress);
            if (data != null)
            {
                return data.Registry;
            }
            return null;
        }

        private static IList<IPv4Data> DataList
        {
            get
            {
                if (_dataList == null)
                {
                    lock (_syncObject)
                    {
                        if (_dataList == null)
                        {
                            _dataList = ReadInCSVFile();
                        }
                    }
                }
                return _dataList;
            }
        }
    }
}

