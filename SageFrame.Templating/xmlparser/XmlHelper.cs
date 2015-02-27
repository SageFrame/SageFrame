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
using System.IO;

namespace SageFrame.Templating.xmlparser
{
    public class XmlHelper
    {
        public static XmlDocument LoadXMLDocument(string filePath)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
               
                reader.WhitespaceHandling = WhitespaceHandling.None;               
                //Load the file into the XmlDocument
                xmlDoc.Load(reader);
                //Close off the connection to the file.
                reader.Close();
                //Add and item representing the document to the listbox
            
            }
            catch (Exception)
            {

                reader.Close();
            }
            return xmlDoc;
        }

        public static XmlNodeList GetXMLNodes(XmlDocument doc,string selectednode)
        {
            XmlNodeList xnLst=doc.SelectNodes(selectednode);
            return xnLst;
        }
        //public static XmlNodeList GetChildNodes(XmlNode xmlNode)
        //{
        //    XmlNodeList xnLst=xmlNode.SelectNodes();
        //    return xnLst;
        //}
        public static string GetXMLString(string filePath)
        {
           
            StreamReader sr = null;
            string xml = null;
            try
            {
                sr = new StreamReader(filePath);
                xml = sr.ReadToEnd();
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr = null;
                }
            }
            return xml;
        }

       
        

    }
}
