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
using System.IO;
using SageFrame.Templating.xmlparser;
using System.Web;
using System.Text.RegularExpressions;
using SageFrame.Web;
#endregion

namespace SageFrame.Templating
{
    public class Utils
    {
        public static bool ValidateThumbImage(FileInfo file)
        {
            bool isValid = false;
            if (file.Extension == ".png" || file.Extension == ".jpg" || file.Extension == ".gif")
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool IsValidTag(XmlTag tag)
        {
            return (Enum.IsDefined(typeof(XmlTagTypes), tag.TagName.ToUpper()));
        }

        public static string GetTemplateInfoFilePath(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.TemplateDirectory + TemplateName + TemplateConstants.TemplateInfo));
        }

        public static string GetTemplateInfoFilePath_Default(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.DefaultTemplateDir + "Template" + TemplateConstants.TemplateInfo));
        }

        public static string GetTemplatePath(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.TemplateDirectory + TemplateName));
        }

        public static string GetTemplatePath_Default(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.DefaultTemplateDir + "Template"));
        }

        public static string GetThemePath(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.TemplateDirectory + TemplateName + TemplateConstants.ThemeDirectory));
        }

        public static string GetThemePath_Default(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.DefaultTemplateDir + "Template" + TemplateConstants.ThemeDirectory));
        }

        public static string GetAdminTemplatePath()
        {
            return (GetAbsolutePath("Administrator/Templates/"));
        }

        public static string GetPresetPath(string TemplateName)
        {
            return (GetAbsolutePath(TemplateConstants.TemplateDirectory + TemplateName));
        }

        public static string GetPresetPath_DefaultTemplate(string TemplateName)
        {
            return (GetAbsolutePath(string.Format("{0}Template", TemplateConstants.DefaultTemplateDir)));
        }

        public static string ReplaceBackSlash(string filepath)
        {
            if (filepath != null)
            {
                filepath = filepath.Replace("\\", "/");
            }
            return filepath;
        }

        public static string GetAbsolutePath(string filepath)
        {
            return (Utils.ReplaceBackSlash(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath.ToString(), filepath)));
        }

        public static bool CompareStrings(object string1, object string2)
        {
            return (string1.ToString().ToLower().Equals(string2.ToString().ToLower()));
        }

        public static bool CompareStrings(string string1, string string2)
        {
            return (string1.ToString().ToLower().Equals(string2.ToString().ToLower()));
        }

        public static bool CompareStrings(string string1, object string2)
        {
            return (string1.ToString().ToLower().Equals(string2.ToString().ToLower()));
        }

        public static bool CompareStrings(object string1, string string2)
        {
            return (string1.ToString().ToLower().Equals(string2.ToString().ToLower()));
        }

        public static string ExtractNumbers(string expr)
        {
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(expr, "[^\\d]"));
        }

        public static void DeleteDirectory(string target_dir)
        {
            if (Directory.Exists(target_dir))
            {
                string[] files = Directory.GetFiles(target_dir);
                string[] dirs = Directory.GetDirectories(target_dir);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }

                Directory.Delete(target_dir, true);
            }
        }

        public static void DeleteFile(string target_file)
        {
            if (File.Exists(target_file))
            {
                File.Delete(target_file);
            }
        }

        public static string GetFileNameWithExtension(string filename, string ext)
        {

            if (Path.HasExtension(filename))
            {
                filename = Path.GetFileNameWithoutExtension(filename);
                filename = string.Format("{0}{1}{2}", filename, ".", ext);
            }
            else
            {
                filename = string.Format("{0}{1}{2}", filename, ".", ext);
            }
            return filename;
        }

        public static bool ContainsXmlHeader(string xml)
        {

            return (xml.Contains("<?xml"));

        }

        public static string GetAttributeValueByName(XmlTag tag, XmlAttributeTypes _type)
        {
            string value = string.Empty;
            string name = _type.ToString();
            LayoutAttribute attr = new LayoutAttribute();
            attr = tag.LSTAttributes.Find(
                delegate(LayoutAttribute attObj)
                {
                    return (Utils.CompareStrings(attObj.Name, name));
                }
                );
            return attr == null ? "" : attr.Value;
        }

        public static string GetAttributeValueByName(XmlTag tag, XmlAttributeTypes _type, string defaultValue)
        {
            string value = string.Empty;
            string name = _type.ToString();
            LayoutAttribute attr = new LayoutAttribute();
            attr = tag.LSTAttributes.Find(
                delegate(LayoutAttribute attObj)
                {
                    return (Utils.CompareStrings(attObj.Name, name));
                }
                );
            return attr == null ? defaultValue : attr.Value;
        }

        public static string GetTagInnerHtml(Placeholders pch, XmlTag middleBlock)
        {
            XmlTag currentTag = new XmlTag();
            currentTag = middleBlock.LSTChildNodes.Find(
                delegate(XmlTag tag)
                {
                    return (Utils.CompareStrings(Utils.GetAttributeValueByName(tag, XmlAttributeTypes.NAME), pch));
                }
                );
            return currentTag.InnerHtml;
        }
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string BuildURL(string item, string appPath, string PortalSEOName, int PortalID)
        {
            SageFrameConfig objsfConfig = new SageFrameConfig();
            string portalchange = !objsfConfig.IsParent ? string.Format("/portal/{0}", PortalSEOName) : "";
            string url = string.Empty;
            if (item == "/Admin" + SageFrameSettingKeys.PageExtension)
            {
                url = string.Format("{0}{1}/Admin{2}", appPath, portalchange, item);
            }
            else
            {
                url = string.Format("{0}{1}{2}", appPath, portalchange, item);
            }

            return url;
        }

        public static string GetSEOName(string str, string replacer)
        {
            return str.Replace(" ", "-");
        }

        public static string FormatHtmlOutput(string content)
        {
            string pattern1 = "</div>";
            MatchCollection collection1 = Regex.Matches(content, pattern1, RegexOptions.IgnoreCase);
            List<string> matchListClosingDiv = new List<string>();
            foreach (Match tmpmatch in collection1)
            {
                if (!matchListClosingDiv.Contains(tmpmatch.Value))
                    matchListClosingDiv.Add(tmpmatch.Value);
            }

            int i = 0;
            foreach (string match in matchListClosingDiv)
            {
                string elementPattern = string.Format("{0}\n{1}", GetIndentTabs(i), match);
                content = Regex.Replace(content, match, elementPattern);
                i++;
            }

            string pattern = "\\<div\\s*[^>]*\\>";
            MatchCollection collection = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);

            List<string> matchList = new List<string>();
            foreach (Match tmpmatch in collection)
            {
                if (!matchList.Contains(tmpmatch.Value))
                    matchList.Add(tmpmatch.Value);
            }

            foreach (string match in matchList)
            {
                string elementPattern = match + "\n";
                content = Regex.Replace(content, match, elementPattern);
            }
            return content;

        }

        public static string GetIndentTabs(int tabCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tabCount; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public static string CleanFilePath(string illegal)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            illegal = r.Replace(illegal, "");
            return illegal;
        }

        public static bool FilePathHasInvalidChars(string path)
        {

            return (path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        public static string CleanString(string value)
        {
            value = Regex.Replace(value, "\\s+", "");
            return value.ToLower();
        }

        public static string GetSeoName(string value)
        {
            return (value.Replace("", "-"));
        }

        public static string FallbackLayout()
        {
            string xml = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.Append(@"<layout name=""layout_all"">");
            sb.Append(@"<section name=""sfHeader"">");
            sb.Append(@"<placeholder name=""headertop"">headertop</placeholder>");
            sb.Append(@"<placeholder name=""banner"">banner</placeholder>");
            sb.Append(@"<placeholder name=""navigation"">navigation</placeholder>");
            sb.Append(@"<placeholder name=""spotlight"" mode=""fixed"">pos1,pos2,pos3</placeholder>");
            sb.Append(@"</section>");
            sb.Append(@"<section name=""sfContent"" colwidth=""20"">");
            sb.Append(@"<placeholder name=""fulltopspan"">FullTopSpan</placeholder>");
            sb.Append(@"<placeholder name=""lefttop"" class=""sftest"">LeftTop</placeholder>");
            sb.Append(@"<placeholder name=""leftA"" class=""leftaclass"">LeftA</placeholder>");
            sb.Append(@"<placeholder name=""leftB"">LeftB</placeholder>");
            sb.Append(@"<placeholder name=""leftbottom"">LeftBottom</placeholder>");
            sb.Append(@"<placeholder name=""righttop"">RightTop</placeholder>");
            sb.Append(@"<placeholder name=""rightA"">RightA</placeholder>");
            sb.Append(@"<placeholder name=""rightB"">RightB</placeholder>");
            sb.Append(@"<placeholder name=""rightbottom"">RightBottom</placeholder>");
            sb.Append(@"<placeholder name=""middletop"">MiddleTop</placeholder>");
            sb.Append(@"<placeholder name=""middlebottom"">MiddleBottom</placeholder>");
            sb.Append(@"<placeholder name=""middlemaintop"">MiddleMainTop</placeholder>");
            sb.Append(@"<placeholder name=""MiddleMainBottom"">MiddleMainBottom</placeholder>");
            sb.Append(@"<placeholder name=""middlemaincurrent"">middlemaincurrent</placeholder>");
            sb.Append(@"<placeholder name=""fullbottomspan"">FullBottomSpan</placeholder>");
            sb.Append(@"</section>");
            sb.Append(@"<section name=""sfFooter"">");
            sb.Append(@"<placeholder name=""footer"">footer</placeholder>");
            sb.Append(@"</section>");
            sb.Append(@"<wrappers>");
            sb.Append(@"<wrap type=""placeholder"" class=""testblock"" depth=""3"">middle,right</wrap>");
            sb.Append(@"</wrappers>");
            sb.Append(@"</layout>");
            xml = sb.ToString();
            return xml;
        }
    }
}
