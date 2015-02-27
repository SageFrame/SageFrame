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
using SageFrame.Templating.xmlparser;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Linq;
#endregion


namespace SageFrame.Templating
{
    public class Decide
    {
        public static bool HasBlock(Placeholders pch, XmlTag middleBlock)
        {
            bool status = false;
            status = middleBlock.LSTChildNodes.Exists(
                delegate(XmlTag tag)
                {
                    return (Utils.CompareStrings(Utils.GetAttributeValueByName(tag, XmlAttributeTypes.NAME), pch));
                }
                );
            return status;
        }

        public static bool IsSpotLight(XmlTag placeholder)
        {
            string pchName = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.NAME);
            bool status = false;
            if (Utils.CompareStrings(pchName, "spotlight"))
            {
                status = true;
            }
            return status;
        }

        public static bool IsCustomBlockDefined(XmlTag placeholder)
        {

            string activeTemplate = HttpContext.Current.Session["SageFrame.ActiveTemplate"] != null ? HttpContext.Current.Session["SageFrame.ActiveTemplate"].ToString() : "Default";
            string pchName = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.NAME);
            string FilePath = HttpContext.Current.Server.MapPath("~/") + "//" + activeTemplate + "//sections";
            bool status = false;
            if (Directory.Exists(FilePath))
            {
                DirectoryInfo dir = new DirectoryInfo(FilePath);
                foreach (FileInfo file in dir.GetFiles("*.htm"))
                {
                    if (Utils.CompareStrings(Path.GetFileNameWithoutExtension(file.Name), pchName))
                    {
                        status = true;
                        break;
                    }
                }
            }
            return status;
        }

        public static bool Contains(string[] positionArr, string[] wrapArray)
        {
            bool Contains = false;
            foreach (string wrap in wrapArray)
            {
                if (positionArr.Contains(wrap))
                {
                    Contains = true;
                    break;
                }
            }
            return Contains;
        }

        public static bool IsTemplateDefault(string TemplateName)
        {
            return TemplateName.ToLower().Equals("default");
        }

        public static bool IsXmlInputValid(string xml)
        {
            try
            {
                xml = xml.Replace(Environment.NewLine,"");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
      
        public static int LeftBlockMode(XmlTag middleBlock)
        {
            int status = 0;
            if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 1;
            }
            else if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && !Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status=2;
            }
            else if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 3;
            }
            else if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && !Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 4;
            }
            else if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 5;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 6;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && !Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 7;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 8;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && !Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 10;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 9;
            }
            else if (Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && !Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 11;
            }
            else if (!Decide.HasBlock(Placeholders.LEFTTOP, middleBlock) && Decide.HasBlock(Placeholders.LEFTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.LEFTA, middleBlock) && Decide.HasBlock(Placeholders.LEFTB, middleBlock))
            {
                status = 12;
            }
            return status;

        }

        public static int RightBlockMode(XmlTag middleBlock)
        {
            int status = 0;
            if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 1;
            }
            else if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 2;
            }
            else if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 3;
            }
            else if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 4;
            }
            else if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 5;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 6;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 7;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 8;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 10;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 9;
            }
            else if (Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && !Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 11;
            }
            else if (!Decide.HasBlock(Placeholders.RIGHTTOP, middleBlock) && Decide.HasBlock(Placeholders.RIGHTBOTTOM, middleBlock) && Decide.HasBlock(Placeholders.RIGHTA, middleBlock) && Decide.HasBlock(Placeholders.RIGHTB, middleBlock))
            {
                status = 12;
            }
            return status;

        }


    }
}
