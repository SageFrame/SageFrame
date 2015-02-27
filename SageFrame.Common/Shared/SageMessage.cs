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
using System.Xml;
using System.Globalization;
using System.IO;
using SageFrame.Common;
using SageFrame.Common.CommonFunction;

namespace SageFrame.Web
{
    public static class SageMessage
    {
        public static string SageMenuLocalization(string portalName,string CurrentCultureName, string MenuKey, string MenuAttribute)
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/"+portalName+"Menu." + CurrentCultureName + ".xml");
            if (!File.Exists(xmlPath))
                xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/" + portalName + "Menu.xml");

            doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;
            if (root.SelectSingleNode(HTMLHelper.StripTagsCharArray(MenuKey)) != null && root.SelectSingleNode(HTMLHelper.StripTagsCharArray(MenuKey)).SelectSingleNode(MenuAttribute) != null)
            {
                return root.SelectSingleNode(MenuKey).SelectSingleNode(MenuAttribute).ChildNodes[0].Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ProcessSageMessage(string CurrentCultureName, string ModuleName, string MessageNode)
        {
            return ProvideSageMessage(CurrentCultureName, ModuleName, MessageNode);
        }

        public static string ProvideSageMessage(string CurrentCultureName, string ModuleName, string MessageNode)
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXML." + CurrentCultureName + ".xml");
            if (!File.Exists(xmlPath))
                xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXML.xml");

            doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;
            return root.SelectSingleNode(ModuleName).SelectSingleNode(MessageNode).ChildNodes[0].Value;
        }

        public static string ListSageText(string CurrentCultureName, string ModuleName, string MessageNode)
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXMLList." + CurrentCultureName + ".xml");
            if (!File.Exists(xmlPath))
                xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXMLList.xml");

             doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;
            return root.SelectSingleNode(ModuleName).SelectSingleNode(MessageNode).ChildNodes[0].Value;
        }

        public static List<SageFrameStringKeyValue> ListSageModuleName(string CurrentCultureName, string ModuleName)
        {
            
            List<SageFrameStringKeyValue> modulePanes = new List<SageFrameStringKeyValue>();
            XmlDocument doc = new XmlDocument();
            string xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXMLList." + CurrentCultureName + ".xml");
            if (!File.Exists(xmlPath))
                xmlPath = HttpContext.Current.Server.MapPath("~/XMLMessage/SageXMLList.en-US.xml");

            doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;
            for (int i = 0; i < root.SelectSingleNode(ModuleName).ChildNodes.Count; i++)
            {
                modulePanes.Add(new SageFrameStringKeyValue(root.SelectSingleNode(ModuleName).ChildNodes[i].Name, root.SelectSingleNode(ModuleName).ChildNodes[i].InnerText));
            }
            return modulePanes;
        }
        
        public static string GetSageModuleLocalMessageByVertualPath(string VertualPath, string MessageNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string CurrentCultureName = CultureInfo.CurrentCulture.Name;                           
                doc.Load(HttpContext.Current.Server.MapPath("~/" + VertualPath + "/SageModuleLocalText." + CurrentCultureName + ".xml"));
                if (doc != null)
                {
                    XmlNode root = doc.DocumentElement;
                    return root.SelectSingleNode(MessageNode).ChildNodes[0].Value;
                }
                else
                {
                    doc.Load(HttpContext.Current.Server.MapPath("~/" + VertualPath + "/SageModuleLocalText." + "en-US" + ".xml"));
                    if (doc != null)
                    {
                        XmlNode root = doc.DocumentElement;
                        return root.SelectSingleNode(MessageNode).ChildNodes[0].Value;
                    }
                    else
                    {
                        doc.Load(HttpContext.Current.Server.MapPath("~/" + VertualPath + "/SageModuleLocalText.xml"));
                        if (doc != null)
                        {
                            XmlNode root = doc.DocumentElement;
                            return root.SelectSingleNode(MessageNode).ChildNodes[0].Value;
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }

        }

        public static string GetSageModuleLocalMessageByFullPathwithFileName(string FullPathwithFileName, string MessageNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();                
                doc.Load(FullPathwithFileName);
                if (doc != null)
                {
                    XmlNode root = doc.DocumentElement;
                    return root.SelectSingleNode(MessageNode).ChildNodes[0].Value;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }

        }
    }
}
