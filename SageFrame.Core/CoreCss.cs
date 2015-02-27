#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageFrame.Common;
using SageFrame.Templating;
using System.IO;

#endregion


namespace SageFrame.Core
{
    [Serializable]
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
                    if (css.Extension.Equals("css") 
                        || css.Extension.Equals(".css") && 
                        (!Path.GetFileNameWithoutExtension(css.Name.ToLower()).Equals("template")
                        && !Path.GetFileNameWithoutExtension(css.Name.ToLower()).Equals("responsive")))
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
