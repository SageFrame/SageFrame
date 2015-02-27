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
using System.Collections;
using SageFrame.Templating.xmlparser;
using System.IO;
using System.Web;

namespace SageFrame.Templating
{
    public class WireFrameHelper
    {
        public static List<CustomWrapper> lstWrapper = new List<CustomWrapper>();
        public static int _Mode = 0;
        public static TemplateInfo CreateTemplateObject(List<XmlTag> lstXml)
        {
            TemplateInfo objTemp = new TemplateInfo();
            List<XmlTag> lstDetails = lstXml[0].LSTChildNodes;
            foreach (XmlTag tag in lstDetails)
            {
                if (Utils.IsValidTag(tag))
                {
                    switch (tag.TagType)
                    {
                        case XmlTagTypes.NAME:
                            objTemp.TemplateName = tag.InnerHtml;
                            break;
                        case XmlTagTypes.AUTHOR:
                            objTemp.Author = tag.InnerHtml;
                            break;
                        case XmlTagTypes.DESCRIPTION:
                            objTemp.Description = tag.InnerHtml;
                            break;
                        case XmlTagTypes.WEBSITE:
                            objTemp.Website = tag.InnerHtml;
                            break;

                    }
                }
            }
            return objTemp;
        }

        public static TemplateInfo CreateEmptyTemplateObject()
        {
            TemplateInfo tempObj = new TemplateInfo();
            tempObj.TemplateName = "N/A";
            tempObj.Author = "N/A";
            tempObj.Description = "N/A";
            tempObj.Website = "N/A";
            return tempObj;
        }

        public static XmlTag GetLeftTag()
        {
            return (TagBuilder(XmlTagTypes.Placeholder.ToString().ToLower(), XmlTagTypes.Placeholder, XmlAttributeTypes.NAME, XmlAttributeTypes.NAME.ToString().ToLower(), "leftA", ""));
        }

        public static XmlTag TagBuilder(string tagName, XmlTagTypes type, XmlAttributeTypes attType, string attName, string attValue, string innerHTML)
        {
            XmlTag tag = new XmlTag();
            tag.TagType = type;
            tag.TagName = tagName;
            tag.LSTAttributes = AddAttributes(attName, attValue, attType);
            tag.InnerHtml = innerHTML;
            return tag;
        }

        public static List<LayoutAttribute> AddAttributes(string attName, string attValue, XmlAttributeTypes attType)
        {
            List<LayoutAttribute> lstAttributes = new List<LayoutAttribute>();
            lstAttributes.Add(new LayoutAttribute(attName, attValue, attType));
            return lstAttributes;
        }

       

       

       

        
       

       



       

    
      


       
       

       

      
       
       
       

      

        
       

      
        
      

       


    }
}
