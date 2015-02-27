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
