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
using System.Text;
using System.Xml;
using System.Web.Hosting;

namespace SageFrame.Localization
{
    public class XMLHelper
    {
        public static XmlWriterSettings GetXmlWriterSettings()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            //settings.ConformanceLevel = conformance;
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            return settings;
        }
         public static PackageInfo GetPackageManifest(string path)
        {
            PackageInfo package = new PackageInfo();           
            XmlDocument doc = new XmlDocument();
                doc.Load(path);   
                XmlNode root = doc.DocumentElement;
                XmlNodeList xnList = doc.SelectNodes("sageframe/packages/package");
                foreach (XmlNode xn in xnList)
                {
                   
                    package.Description = xn["description"].InnerXml.ToString();
                    package.Version = xn.Attributes["version"].InnerText.ToString();
                    package.OwnerName = xn["owner"].ChildNodes[0].InnerXml.ToString();
                    package.Organistaion = xn["owner"].ChildNodes[1].InnerXml.ToString();
                    package.URL = xn["owner"].ChildNodes[2].InnerXml.ToString();
                    package.Email = xn["owner"].ChildNodes[3].InnerXml.ToString();
                    package.ReleaseNotes = xn["releasenotes"].InnerXml.ToString();
                    package.License = xn["license"].InnerXml.ToString();
                }
            
            
            return package;
            
            
        }
    }
}
