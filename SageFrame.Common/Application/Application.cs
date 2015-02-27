/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Net;
using System.Text;
using SageFrame.Web;
using Microsoft.Win32;
using System.Globalization;

namespace SageFrame.Application
{
    public class Application
    {
        private static ReleaseMode _status = ReleaseMode.None;

        private System.Version _NETFrameworkVersion = System.Environment.Version;
        private string _ApplicationPath = string.Empty;
        private string _ApplicationMapPath = string.Empty;        

        public Application()
        {
            NETFrameworkIISVersion = GetNETFrameworkVersion();
            _ApplicationPath = System.Web.HttpContext.Current.Request.ApplicationPath;

            _ApplicationMapPath = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, (System.AppDomain.CurrentDomain.BaseDirectory.Length - 1));
            _ApplicationMapPath = ApplicationMapPath.Replace("/", "\\");
             
        }
        public static string CurrentDotNetVersion()
        {
            RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
            string[] version_names = installed_versions.GetSubKeyNames();
            //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
            decimal Framework = Convert.ToDecimal(version_names[version_names.Length - 1].Remove(0, 1), CultureInfo.InvariantCulture);
            int SP = Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1]).GetValue("SP", 0));
            return Framework.ToString();
        }

        public System.Version NETFrameworkIISVersion
        {
            get
            {
                return _NETFrameworkVersion;
            }
            set
            {
                _NETFrameworkVersion = value;
            }
        }

        public string ApplicationPath
        {
            get
            {
                return _ApplicationPath;
            }
            set
            {
                _ApplicationPath = value;
            }
        }

        public string ApplicationMapPath
        {
            get
            {
                return _ApplicationMapPath;
            }
            set
            {
                _ApplicationMapPath = value;
            }
        }

        public string Company
        {
            get
            {
                return "BrainDigit Pty.";
            }
        }

        public string Description
        {
            get
            {
                return "SageFrame Community Edition";
            }
        }

        public string HelpUrl
        {
            get
            {
                return "http://www.sageframe.com/default.aspx";
            }
        }

        public string LegalCopyright
        {
            get
            {
                return ("SageFrame� is copyright 2010-"
                            + (DateTime.Today.ToString("yyyy") + " by SageFrame Corporation"));
            }
        }

        public string Name
        {
            get
            {
                return "SFECORP.CE";
            }
        }

        public string SKU
        {
            get
            {
                return "SFE";
            }
        }

        public ReleaseMode Status
        {
            get
            {
                if ((_status == ReleaseMode.None))
                {
                    Assembly assy = System.Reflection.Assembly.GetExecutingAssembly();
                    if (Attribute.IsDefined(assy, typeof(AssemblyStatusAttribute)))
                    {
                        Attribute attr = Attribute.GetCustomAttribute(assy, typeof(AssemblyStatusAttribute));
                        if (attr != null)
                        {
                            _status = ((AssemblyStatusAttribute)(attr)).Status;
                        }
                    }
                }
                return _status;
            }
        }

        public string Title
        {
            get
            {
                return "SageFrame";
            }
        }

        public string Trademark
        {
            get
            {
                return "SageFrame,SFE";
            }
        }

        public string Type
        {
            get
            {
                return "Framework";
            }
        }

        public string UpgradeUrl
        {
            get
            {
                return "http://update.sageframe.com";
            }
        }

        public string Url
        {
            get
            {
                return "http://www.sageframe.com";
            }
        }

        public System.Version Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;// .GetName.Version;
            }
        }

        public string DataProvider
        {
            get { return "SqlDataProvider"; }
        }

        public string FormatVersion(System.Version version, bool includeBuild)
        {
            string strVersion = (version.Major.ToString("00") + ("." + (version.Minor.ToString("00") + ("." + version.Build.ToString("00")))));
            if (includeBuild)
            {
                strVersion = (strVersion + (" (" + (version.Revision.ToString() + ")")));
            }
            return strVersion;
        }

        private static System.Version GetNETFrameworkVersion()
        {
            string version = System.Environment.Version.ToString(2);
            // Try and load a 3.0 Assembly
            System.Reflection.Assembly assembly;
            try
            {
                assembly = AppDomain.CurrentDomain.Load("System.Runtime.Serialization, Version=3.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089");
                version = "3.0";
            }
            catch
            {
            }
            // Try and load a 3.5 Assembly
            try
            {
                assembly = AppDomain.CurrentDomain.Load("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089");
                version = "3.5";
            }
            catch
            {
            }
            // Try and load a 4.0 Assembly
            try
            {
                assembly = AppDomain.CurrentDomain.Load("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089");
                version = "4.0";
            }
            catch
            {
            }
            return new System.Version(version);
        }

        public string ServerIPAddress
        {
            get 
            {
                IPAddress[] IPList = Dns.GetHostEntry(DNSName).AddressList;
                StringBuilder strIpAddress = new StringBuilder();
                string strTemp = string.Empty;
                if (IPList.Length > 0)
                {
                    foreach (IPAddress ip in IPList)
                    {
                        strIpAddress.Append(ip.ToString() + ", ");
                    }
                    strTemp = strIpAddress.ToString();
                    if (strTemp.Contains(","))
                        strTemp = strTemp.Remove(strTemp.LastIndexOf(","));
                }
                return strTemp;
            }
        }

        public string DNSName
        {
            get
            {
                return Dns.GetHostName();
            }
        }        
    }
}
