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
using SageFrame.Common;
using SageFrame.Templating;
using System.IO;

namespace SageFrame.Core
{
    public class CoreCss
    {
        public static List<CssScriptInfo> GetTemplateCss(string TemplateName)
        {
            string templatePath = TemplateName.ToLower().Equals("default") ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string templatePath_rel = TemplateName.ToLower().Equals("default") ? "/Core/Template/css/" : string.Format("/Templates/{0}/css/", TemplateName);
            string templateJsPath = string.Format("{0}/css", templatePath);
            List<CssScriptInfo> lstCss = new List<CssScriptInfo>();
            if (Directory.Exists(templateJsPath))
            {
                DirectoryInfo dirCss = new DirectoryInfo(templateJsPath);
                foreach (FileInfo css in dirCss.GetFiles())
                {
                    if (css.Extension.Equals("css") || css.Extension.Equals(".css") && !Path.GetFileNameWithoutExtension(css.Name.ToLower()).Equals("template") )
                    {
                        lstCss.Add(new CssScriptInfo("TemplateCss", css.Name, templatePath_rel, 1));
                    }
                }
            }
            lstCss.Sort(
                delegate(CssScriptInfo f1, CssScriptInfo f2)
                {
                    return f1.FileName.CompareTo(f2.FileName);
                }
            );

            return lstCss;

        }
    }
}
