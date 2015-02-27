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
    public class CoreJs
    {
        /// <summary>
        /// Get the list of Core js files to be included by default
        /// </summary>
        /// <param name="IsAdmin">Include only those files required for the admin mode i.e. the dashboard</param>
        /// <param name="IsUserLoggedIn">Scipts required for the top sticky bar and the edit buttons and popup</param>
        /// <returns>List of scripts to be included</returns>
        public static List<CssScriptInfo> GetList(bool IsAdmin, bool IsUserLoggedIn)
        {
            List<CssScriptInfo> lstJS = new List<CssScriptInfo>{                
                                                    new CssScriptInfo("Core","jquery-1.4.4.js","/js/",0,false),
                                                    new CssScriptInfo("Core", "jquery-ui-1.8.14.custom.min.js", "/js/jquery-ui-1.8.14.custom/js/", 0, false),
                                                    new CssScriptInfo("Core","sageframecore.js","/js/SageFrameCorejs/",0,false),
                                                    new CssScriptInfo("Core","JSON2.js","/js/",0,true),
                                                    new CssScriptInfo("Core", "superfish.js", "/js/", 0,false)
                                                  
 
            };
            if (IsAdmin && IsUserLoggedIn)
            {
                //lstJS.Add(new CssScriptInfo("Core", "jquery-ui-1.8.14.custom.min.js", "/js/jquery-ui-1.8.14.custom/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.tooltip.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.uniform.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "dashboardjs.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "sidebar_accordian.js", "/Administrator/Templates/Default/js/", 1, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.jcarousel.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.qtip-1.0.0-rc3.js", "/Administrator/Templates/Default/js/", 1, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.dialogextend.js", "/js/", 1, true));


            }
            else if (!IsAdmin && IsUserLoggedIn)
            {
                //lstJS.Add(new CssScriptInfo("Core", "jquery-ui-1.8.14.custom.min.js", "/js/jquery-ui-1.8.14.custom/js/", 0,false));
                lstJS.Add(new CssScriptInfo("Core", "max-z-index.js", "/Administrator/Templates/Default/js/", 1));
                lstJS.Add(new CssScriptInfo("Core", "jquery.tooltip.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "dashboardjs.js", "/Administrator/Templates/Default/js/", 0, false));
                lstJS.Add(new CssScriptInfo("Core", "jquery.dialogextend.js", "/js/", 1, true));

            }
            else
            {
                lstJS.Add(new CssScriptInfo("Core", "jquery.dialogextend.js", "/js/", 1, true));
            }

            return lstJS;
        }


        public static List<CssScriptInfo> GetTemplateJs(string TemplateName)
        {
            string templatePath = TemplateName.ToLower().Equals("default") ? Utils.GetTemplatePath_Default(TemplateName) : Utils.GetTemplatePath(TemplateName);
            string templatePath_rel = TemplateName.ToLower().Equals("default") ? "/Core/Template/js/" : string.Format("/Templates/{0}/js/", TemplateName);
            string templateJsPath = string.Format("{0}/js", templatePath);
            List<CssScriptInfo> lstJs = new List<CssScriptInfo>();
            if (Directory.Exists(templateJsPath))
            {
                DirectoryInfo dirJs = new DirectoryInfo(templateJsPath);
                foreach (FileInfo js in dirJs.GetFiles())
                {
                    if (js.Extension.Equals("js") || js.Extension.Equals(".js"))
                    {
                        lstJs.Add(new CssScriptInfo("TemplateJs", js.Name, templatePath_rel, 1));
                    }
                }
            }
            lstJs.Sort(
                delegate(CssScriptInfo f1, CssScriptInfo f2)
                {
                    return f1.FileName.CompareTo(f2.FileName);
                }
            );
            return lstJs;

        }
    }
}
