#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
#endregion

namespace SageFrame.Templating.xmlparser
{
    public class XmlParser
    {
        public List<XmlTag> GetXmlTags(string xmlFile, string startParseNode)
        {
            List<XmlTag> lstSectionNodes = new List<XmlTag>();
            XmlDocument doc = XmlHelper.LoadXMLDocument(xmlFile);
            XmlNodeList sectionList = doc.SelectNodes(startParseNode);
            foreach (XmlNode section in sectionList)
            {
                XmlTag tag = new XmlTag();
                tag.TagName = section.Name;
                tag.TagType = GetXmlTagType(section);
                tag.ChildNodeCount = GetChildNodeCount(section);
                tag.AttributeCount = GetAttributeCount(section);
                tag.LSTAttributes = GetAttributesCollection(section);
                tag.LSTChildNodes = section.ChildNodes.Count > 0 ? GetChildNodeCollection(section) : new List<XmlTag>();
                tag.CompleteTag = BuildCompleteTag(tag);
                tag.PchArr = GetPlaceholders(section);
                tag.Placeholders = string.Join(",", tag.PchArr);
                if (ValidateTagType(tag))
                {
                    lstSectionNodes.Add(tag);
                }
            }
            //doc.Save(xmlFile);
            return lstSectionNodes;
        }

        public List<string> GetLayoutPositions(string xmlFile, string startParseNode)
        {
            XmlDocument doc = XmlHelper.LoadXMLDocument(xmlFile);
            XmlNodeList sectionList = doc.SelectNodes(startParseNode);
            List<string> lstPositions = new List<string>();
            foreach (XmlNode section in sectionList)
            {
                foreach (string pos in GetPositions(section))
                {
                    lstPositions.Add(pos);
                }
            }
            doc.Save(xmlFile);
            return lstPositions;
        }

        public XmlTagTypes GetXmlTagType(XmlNode xmlNode)
        {
            XmlTagTypes tagType = new XmlTagTypes();
            switch (xmlNode.Name)
            {
                case "layout":
                    tagType = XmlTagTypes.Layout;
                    break;
                case "section":
                    tagType = XmlTagTypes.Section;
                    break;
                case "placeholder":
                    tagType = XmlTagTypes.Placeholder;
                    break;
                case "template":
                    tagType = XmlTagTypes.TEMPLATE;
                    break;
                case "name":
                    tagType = XmlTagTypes.NAME;
                    break;
                case "author":
                    tagType = XmlTagTypes.AUTHOR;
                    break;
                case "description":
                    tagType = XmlTagTypes.DESCRIPTION;
                    break;
                case "website":
                    tagType = XmlTagTypes.WEBSITE;
                    break;
                case "wrappers":
                    tagType = XmlTagTypes.WRAPPERS;
                    break;
                case "wrap":
                    tagType = XmlTagTypes.WRAP;
                    break;
                case "sfleft":
                    tagType = XmlTagTypes.SFLEFT;
                    break;
                case "sfmiddle":
                    tagType = XmlTagTypes.SFMIDDLE;
                    break;
                case "sfright":
                    tagType = XmlTagTypes.SFRIGHT;
                    break;

            }
            return tagType;
        }


        public int GetChildNodeCount(XmlNode xmlNode)
        {
            return (xmlNode.ChildNodes.Count);
        }

        public int GetAttributeCount(XmlNode xmlNode)
        {
            return (xmlNode.Attributes.Count);
        }

        public List<LayoutAttribute> GetAttributesCollection(XmlNode xn)
        {
            List<LayoutAttribute> lstXmlAttr = new List<LayoutAttribute>();
            int attrCount = xn.Attributes.Count;
            while (attrCount > 0)
            {
                attrCount--;
                LayoutAttribute xa = new LayoutAttribute();
                xa.Name = Utils.CleanString(xn.Attributes[attrCount].Name);
                xa.Value = Utils.CleanString(xn.Attributes[attrCount].Value);
                xa.Type = GetXmlAttributeType(xa);
                lstXmlAttr.Add(xa);

            }
            return lstXmlAttr;
        }
        public string[] GetPlaceholders(XmlNode node)
        {
            List<string> lstPch = new List<string>();

            List<XmlTag> lstChildNodes = new List<XmlTag>();
            string childNode = "";
            if (node.ChildNodes.Count > 0)
            {
                childNode = node.ChildNodes[0].Name;
            }
            XmlNodeList xnList = node.SelectNodes(childNode);

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (node.ChildNodes[i].Attributes["name"] != null)
                    lstPch.Add(node.ChildNodes[i].Attributes["name"].Value);

            }
            return lstPch.ToArray();
        }

        public string[] GetPositions(XmlNode node)
        {
            List<string> lstPch = new List<string>();

            List<XmlTag> lstChildNodes = new List<XmlTag>();
            string childNode = "";
            if (node.ChildNodes.Count > 0)
            {
                childNode = node.ChildNodes[0].Name;
            }
            XmlNodeList xnList = node.SelectNodes(childNode);

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                foreach (string pos in node.ChildNodes[i].InnerText.Split(','))
                {
                    lstPch.Add(pos);
                }

            }
            return lstPch.ToArray();
        }

        public List<XmlTag> GetChildNodeCollection(XmlNode node)
        {
            List<XmlTag> lstChildNodes = new List<XmlTag>();
            string childNode = "";
            if (node.ChildNodes.Count > 0)
            {
                childNode = node.ChildNodes[0].Name;
            }
            XmlNodeList xnList = node.SelectNodes(childNode);

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlTag tag = new XmlTag();
                tag.TagName = node.ChildNodes[i].Name;
                tag.TagType = GetXmlTagType(node.ChildNodes[i]);
                tag.InnerHtml = Utils.CleanString(node.ChildNodes[i].InnerText);
                tag.AttributeCount = GetAttributeCount(node.ChildNodes[i]);
                tag.LSTAttributes = GetAttributesCollection(node.ChildNodes[i]);
                tag.PositionsArr = tag.InnerHtml.Split(',');
                tag.CompleteTag = BuildCompleteTag(tag);
                if (ValidateTagType(tag))
                {
                    lstChildNodes.Add(tag);
                }

            }

            return lstChildNodes;
        }



        public string BuildCompleteTag(XmlTag tag)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetStartTag(tag));
            sb.Append(GetEndTag(tag));
            return sb.ToString();

        }

        public string GetStartTag(XmlTag tag)
        {
            bool hasAttribute = tag.LSTAttributes.Count > 0 ? true : false;
            StringBuilder sb = new StringBuilder();
            if (hasAttribute)
            {
                sb.Append("<");
                sb.Append(Utils.CleanString(tag.TagName));
                sb.Append(GetAttributeString(tag.LSTAttributes));
                sb.Append(">");
            }
            else
            {
                sb.Append("<");
                sb.Append(Utils.CleanString(tag.TagName));
                sb.Append(">");
            }
            return sb.ToString();
        }

        public string GetEndTag(XmlTag tag)
        {
            return ("</" + tag.TagName + ">");
        }

        public string GetAttributeString(List<LayoutAttribute> lstAttr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");
            foreach (LayoutAttribute attr in lstAttr)
            {
                sb.Append(attr.Name);
                sb.Append("=");
                sb.Append("'" + attr.Value + "'");
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public bool ValidateTagType(XmlTag tag)
        {
            bool exists;
            exists = Enum.IsDefined(typeof(XmlTagTypes), tag.TagType);
            return exists;

        }

        public XmlAttributeTypes GetXmlAttributeType(LayoutAttribute xmlAttribute)
        {
            XmlAttributeTypes attrTypes = new XmlAttributeTypes();
            switch (xmlAttribute.Name)
            {
                case "name":
                    attrTypes = XmlAttributeTypes.NAME;
                    break;
                case "style":
                    attrTypes = XmlAttributeTypes.STYLE;
                    break;
                case "width":
                    attrTypes = XmlAttributeTypes.WIDTH;
                    break;
                case "type":
                    attrTypes = XmlAttributeTypes.TYPE;
                    break;
                case "wrapinner":
                    attrTypes = XmlAttributeTypes.WRAPINNER;
                    break;
                case "wrapouter":
                    attrTypes = XmlAttributeTypes.WRAPOUTER;
                    break;
                case "custom":
                    attrTypes = XmlAttributeTypes.CUSTOM;
                    break;
                case "mode":
                    attrTypes = XmlAttributeTypes.MODE;
                    break;
                case "class":
                    attrTypes = XmlAttributeTypes.CLASS;
                    break;
                case "depth":
                    attrTypes = XmlAttributeTypes.DEPTH;
                    break;
                case "layout":
                    attrTypes = XmlAttributeTypes.LAYOUT;
                    break;
            }
            return attrTypes;
        }

    }
}
