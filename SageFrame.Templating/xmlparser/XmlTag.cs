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
#endregion

namespace SageFrame.Templating.xmlparser
{
    public class XmlTag
    {
        public int Index { get; set; }
        public string TagName { get; set; }
        public string CompleteTag { get; set; }
        public string TagFormat { get; set; }
        public XmlTagTypes TagType { get; set; }
        public List<LayoutAttribute> LSTAttributes { get; set; }
        public List<XmlTag> LSTChildNodes { get; set; }
        public string InnerHtml { get; set; }
        public int ChildNodeCount { get; set; }
        public int AttributeCount { get; set; }
        public string AttributeString { get; set; }
        public List<string> LSTPages { get; set; }
        public string PresetName { get; set; }
        public string[] PositionsArr { get; set; }
        public string[] PchArr { get; set; }
        public string Placeholders { get; set; }
        public int OuterWrapLevel { get; set; }
        public int InnerWrapLevel { get; set; }
        public XmlTag() { }

        public XmlTag(string _CompleteTag)
        {
            this.CompleteTag = _CompleteTag;
        }
    }
}
