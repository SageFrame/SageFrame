
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
using SageFrame.Templating.xmlparser;
using System.IO;

namespace SageFrame.Templating
{
    public class LayoutHelper
    {
        public static void CreateLayoutControls(string TemplateName, PresetInfo PresetObj)
        {            
            string templatePath = TemplateName.ToLower().Equals("default") ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string presetPath = TemplateName.ToLower().Equals("default") ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
            ModulePaneGenerator mg = new ModulePaneGenerator();
            string filePath = templatePath + "/layouts/" + PresetObj.ActiveLayout.Replace(".xml", "") + ".xml";
            XmlParser parser = new XmlParser();
            try
            {
                List<XmlTag> lstXmlTag = parser.GetXmlTags(filePath, "layout/section");
                List<XmlTag> lstWrappers = parser.GetXmlTags(filePath, "layout/wrappers");

                string html = mg.GenerateHTML(lstXmlTag, lstWrappers, 2);
                string controlclass = Path.GetFileNameWithoutExtension(filePath);
                string controlname = string.Format("{0}.ascx", controlclass);
                if (!File.Exists(templatePath + "/" + controlname))
                {
                    FileStream fs = null;
                    using (fs = File.Create(templatePath + "/" + controlname))
                    {

                    }

                }
                else
                {
                    File.Delete(templatePath + "/" + controlname);
                    FileStream fs = null;
                    using (fs = File.Create(templatePath + "/" + controlname))
                    {

                    }
                }

                using (StreamWriter sw = new StreamWriter(templatePath + "/" + controlname))
                {
                    sw.Write("<%@ Control Language=\"C#\" ClassName=" + controlclass + " %>");
                    sw.Write(html);
                }


            }
            catch (Exception)
            {

                throw;
            }  


        }

        public static void CreateHandheldLayoutControls(string TemplateName)
        {


            string templatePath = TemplateName.ToLower().Equals("default") ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string presetPath = TemplateName.ToLower().Equals("default") ? Utils.GetPresetPath_DefaultTemplate(TemplateName) : Utils.GetPresetPath(TemplateName);
            ModulePaneGenerator mg = new ModulePaneGenerator();
            string filePath = templatePath + "/layouts/handheld.xml";
            XmlParser parser = new XmlParser();
            try
            {
                List<XmlTag> lstXmlTag = parser.GetXmlTags(filePath, "layout/section");
                List<XmlTag> lstWrappers = parser.GetXmlTags(filePath, "layout/wrappers");

                string html = mg.GenerateHTML(lstXmlTag, lstWrappers, 2);
                string controlclass = Path.GetFileNameWithoutExtension(filePath);
                string controlname = string.Format("{0}.ascx", controlclass);
                if (!File.Exists(templatePath + "/" + controlname))
                {
                    FileStream fs = null;
                    using (fs = File.Create(templatePath + "/" + controlname))
                    {

                    }

                }
                else
                {
                    File.Delete(templatePath + "/" + controlname);
                    FileStream fs = null;
                    using (fs = File.Create(templatePath + "/" + controlname))
                    {

                    }
                }

                using (StreamWriter sw = new StreamWriter(templatePath + "/" + controlname))
                {
                    sw.Write("<%@ Control Language=\"C#\" ClassName=" + controlclass + " %>");
                    sw.Write(html);
                }


            }
            catch (Exception)
            {

                throw;
            }


        }
    
    }
}
