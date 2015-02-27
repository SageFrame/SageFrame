#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region  "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
#endregion

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

        public static XmlNodeList GetXMLNodes(XmlDocument doc, string selectednode)
        {
            XmlNodeList xnLst = doc.SelectNodes(selectednode);
            return xnLst;
        }

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
