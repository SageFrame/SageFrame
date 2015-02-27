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

namespace SageFrame.Templating
{
    public class BlockParser
    {
        public static int Mode = 0;
        public static string ProcessPlaceholder(XmlTag placeholder, List<CustomWrapper> lstWrapper, int _Mode)
        {
            Mode = _Mode;
            ///1.Check for outer wrappers(skipping for now)
            ///2.Check for the wrapper="inner,3" attribute, Split the positions and inline styles according to width and mode attribute
            StringBuilder sb = new StringBuilder();
            foreach (XmlTag pch in placeholder.LSTChildNodes)
            {
                string[] positions = pch.InnerHtml.Split(',');
                int mode = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.MODE) == "" ? 0 : 1;
                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.Type == "placeholder" && Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower().Equals(start.Start))
                    {
                        string style = string.Format("sfBlockwrap {0}", start.Class);
                        int depth = start.Depth;
                        for (int i = 1; i <= depth; i++)
                        {
                            if (i == 1)
                            {
                                style = start.Depth > 1 ? string.Format("sfBlockwrap sfWrap{0}{1}", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class)) : string.Format("sfBlockwrap sfWrap{0}{1} clearfix", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class)); ;
                                sb.Append("<div class='" + style + "'>");
                            }
                            else
                            {
                                style = start.Depth == i ? string.Format("sfBlockwrap sf{0}{1} clearfix", i - 1, start.Class == "" ? "" : string.Format(" {0}", start.Class)) : string.Format("sfBlockwrap sf{0}{1}", i - 1, start.Class == "" ? "" : string.Format(" {0}", start.Class));
                                sb.Append("<div class='" + style + "'>");
                            }
                        }
                    }
                }

                List<int> wrapperdepth = new List<int>();
                sb.Append(GenerateBlockWrappers(pch, ref wrapperdepth));

                switch (mode)
                {
                    case 0:
                        sb.Append(ParseNormalBlocks(pch, lstWrapper));
                        break;
                    case 1:
                        sb.Append(ParseFixedBlocks(pch, lstWrapper));
                        break;
                }

                sb.Append(HtmlBuilder.GenerateBlockWrappersEnd(wrapperdepth));
                foreach (CustomWrapper start in lstWrapper)
                {
                    string pchName = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower();
                    if (start.Type == "placeholder" && pchName.Equals(start.End))
                    {

                        for (int i = 1; i <= start.Depth; i++)
                        {
                            sb.Append("</div>");
                        }
                    }
                }
            }
            return sb.ToString();
        }
        public static string ParseFixedBlocks(XmlTag placeholder, List<CustomWrapper> lstWrapper)
        {
            StringBuilder sb = new StringBuilder();
            string positions = placeholder.InnerHtml;
            string[] positionsAr = positions.Split(',');
            double spotWidth = 100 / positionsAr.Length;
            string width = spotWidth.ToString() + "%";
            string minheight = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT, "200px");

            if (positionsAr.Length > 1)
            {
                sb.Append(Mode == 2 ? "<div class='sfMoreblocks clearfix'>" : "<div class='sfMoreblocks sfCurve clearfix'>");
            }
            for (int i = 0; i < positionsAr.Length; i++)
            {
                string adjustedWidth = width;
                if (positionsAr.Length % 2 != 0 && i == positionsAr.Length - 1)
                {
                    adjustedWidth = string.Format("{0}%",(int.Parse(width.Replace("%","")) + 1).ToString());
                }
                string style = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.CLASS);
                if (i == 0)
                {
                    style += " sfFirst";
                }
                if (i == positionsAr.Length - 1)
                {
                    style += " sfLast";
                }
                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.Type == "position")
                    {
                        List<KeyValue> lstWidths = new List<KeyValue>();
                        int totalwidth = Calculator.CalculateWrapperWidth(positionsAr, positionsAr, start.LSTPositions.ToArray(), "fixed", out lstWidths);
                        if (start.Start.ToLower() == positionsAr[i])
                        {
                            string wrapperwidth = string.Format("{0}%", (totalwidth).ToString());
                            for (int j = 1; j <= start.Depth; j++)
                            {
                                if (j == 1)
                                {
                                    string wrapstyle = start.Depth > 1 ? string.Format("sfWrap sfInnerwrap{0}{1}", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class)) : string.Format("sfWrap sfInnerwrap{0}{1} clearfix", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class));
                                    sb.Append("<div style='float:left;width:" + wrapperwidth + "' class='" + wrapstyle + "'>");
                                }
                                else
                                {
                                    string multiplewrappers = start.Depth == j ? string.Format("sfWrap {0} sf{1} clearfix", start.Class == "" ? "" : string.Format(" {0}", start.Class), j - 1) : string.Format("sfWrap {0} sf{1}", start.Class == "" ? "" : string.Format(" {0}", start.Class), j - 1);
                                    sb.Append("<div class='" + multiplewrappers + "'>");
                                }
                            }

                        }
                        if (start.LSTPositions.Contains(positionsAr[i]))
                        {
                            int fixedWidth=Calculator.CalculatePostWrapWidth(positionsAr, positionsAr[i], totalwidth, "fixed", lstWidths);
                           
                            adjustedWidth = string.Format("{0}%", fixedWidth.ToString());
                        }
                    }
                }

                string customStyle = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT) == "" ? string.Format("float:left;width:{0}", adjustedWidth) : string.Format("float:left;width:{0};min-height:{1}px", adjustedWidth, Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT));
                if (customStyle != "")
                {
                    string styleClass = string.Format("class='sfFixed{0}'", i + 1);
                    sb.Append("<div " + styleClass + " style='" + customStyle + "'>");
                }
                sb.Append(Mode==2?"<div class='sfWrapper'>":"<div class='sfWrapper sfCurve'>");
                sb.Append(HtmlBuilder.AddPlaceholder(positionsAr[i], Mode));
                sb.Append("</div>");
                if (customStyle != "")
                    sb.Append("</div>");

                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.End.ToLower() == positionsAr[i] && start.Type == "position")
                    {
                        for (int j = 1; j <= start.Depth; j++)
                        {
                            sb.Append("</div>");
                        }
                    }
                }

            }
            if (positionsAr.Length > 1)
            {
                sb.Append("</div>");
            }

            return sb.ToString();
        }
        static string ParseNormalBlocks(XmlTag placeholder, List<CustomWrapper> lstWrapper)
        {

            StringBuilder sb = new StringBuilder();
            string positions = placeholder.InnerHtml;
            string[] positionsAr = positions.Split(',');
            bool fullWidth = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH) == "" ? true : false;
            string[] arrWidth = (Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH) == "" ? "100" : Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH)).Split(',');
            if (positionsAr.Length > 1)
            {
                sb.Append(Mode == 2 ? "<div class='sfMoreblocks clearfix'>" : "<div class='sfMoreblocks sfCurve clearfix'>");
            }
            for (int i = 0; i < positionsAr.Length; i++)
            {
                string style = "";
                if (!fullWidth)
                {
                    if (arrWidth.Length > i)
                    {
                        style += arrWidth[i] == "100" ? "float:left" : string.Format("width:{0}%;float:left", arrWidth[i]);
                    }
                    else if (i == arrWidth.Length)
                    {
                        var remaining = Calculator.GetRemainingWidth(arrWidth);
                        int finalWidth = remaining == 0 ? 100 : remaining;
                        style += finalWidth == 100 ? "float:left" : string.Format("width:{0}%;float:left", finalWidth);

                    }
                }
                else
                {
                    style += "";
                }

                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.Type == "position")
                    {
                        List<KeyValue> lstWidths = new List<KeyValue>();
                        int wrapperwidth = Calculator.CalculateWrapperWidth(positionsAr, arrWidth, start.LSTPositions.ToArray(), "normal", out lstWidths);

                        if (start.Start.ToLower() == positionsAr[i])
                        {
                            string divwidth = string.Format("{0}%", (wrapperwidth).ToString());
                            for (int j = 1; j <= start.Depth; j++)
                            {
                                if (j == 1)
                                {
                                    string wrapstyle = start.Depth > 1 ? string.Format("sfWrap sfInnerwrap{0}{1}", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class)) : string.Format("sfWrap sfInnerwrap{0}{1} clearfix", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class));
                                    string floatstyle = divwidth == "100%" ? string.Format("width:{0}", divwidth) : string.Format("width:{0};float:left", divwidth);
                                    sb.Append("<div style='" + floatstyle + "' class='" + wrapstyle + "'>");
                                }
                                else
                                {
                                    string multiplewrappers = start.Depth == j ? string.Format("sfWrap {0} sf{1} clearfix", start.Class, j) : string.Format("sfWrap {0} sf{1}", start.Class == "" ? "" : string.Format(" {0}", start.Class), j);
                                    string floatstyle = divwidth == "100%" ? string.Format("width:{0}", divwidth) : string.Format("width:{0};float:left", divwidth);
                                    sb.Append("<div style='" + floatstyle + "' class='" + multiplewrappers + "'>");
                                }
                            }
                        }
                        if (start.LSTPositions.Contains(positionsAr[i]))
                        {
                            int width = Calculator.CalculatePostWrapWidth(start.LSTPositions.ToArray(), positionsAr[i], wrapperwidth, "normal", lstWidths);
                            style = Mode == 0 ? string.Format("width:{0}%;float:left", width) : width == 100 ? "float:left" : string.Format("width:{0}%;float:left", width);

                        }
                    }

                }
                string customStyle = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT) == "" ? string.Format("{0}", style) : string.Format("{0};min-height:{1}px", style, Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT));
                if (customStyle != "")
                {
                    string id = string.Format("sf{0}", Utils.UppercaseFirst(positionsAr[i]));
                    sb.Append("<div id=" + id + " style='" + customStyle + "'>");
                }
                sb.Append(Mode == 2 ? "<div class='sfWrapper'>" : "<div class='sfWrapper sfCurve'>");
                //sb.Append(positionsAr[i]);
                sb.Append(HtmlBuilder.AddPlaceholder(positionsAr[i], Mode));
                sb.Append("</div>");
                if (customStyle != "")
                    sb.Append("</div>");

                if (arrWidth.Length == i)
                {
                    //sb.Append("<div class='clearfix'></div>");
                }
                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.End.ToLower() == positionsAr[i] && start.Type == "position")
                    {
                        for (int j = 1; j <= start.Depth; j++)
                        {
                            sb.Append("</div>");
                        }
                    }
                }
            }
            if (positionsAr.Length > 1)
            {
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        static string ParseNormalLeftRightBlocks(XmlTag placeholder, List<CustomWrapper> lstWrapper)
        {

            StringBuilder sb = new StringBuilder();
            string positions = placeholder.InnerHtml;
            string[] positionsAr = positions.Split(',');
            bool fullWidth = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH) == "" ? true : false;
            string[] arrWidth = (Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH) == "" ? "100" : Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.WIDTH)).Split(',');
            if (positionsAr.Length > 1)
            {
                sb.Append(Mode == 2 ? "<div class='sfMoreblocks clearfix'>" : "<div class='sfMoreblocks sfCurve clearfix'>");
            }
            for (int i = 0; i < positionsAr.Length; i++)
            {
                string style = "";               
                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.Type == "position")
                    {
                        List<KeyValue> lstWidths = new List<KeyValue>();
                        int wrapperwidth = Calculator.CalculateWrapperWidth(positionsAr, arrWidth, start.LSTPositions.ToArray(), "normal", out lstWidths);

                        if (start.Start.ToLower() == positionsAr[i])
                        {
                            string divwidth = string.Format("{0}%", (wrapperwidth).ToString());
                            for (int j = 1; j <= start.Depth; j++)
                            {
                                if (j == 1)
                                {
                                    string wrapstyle = start.Depth > 1 ? string.Format("sfWrap sfInnerwrap{0}{1}", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class)) : string.Format("sfWrap sfInnerwrap{0}{1} clearfix", start.Index, start.Class == "" ? "" : string.Format(" {0}", start.Class));
                                    string floatstyle = divwidth == "100%" ? string.Format("width:{0}", divwidth) : string.Format("width:{0};float:left", divwidth);
                                    sb.Append("<div style='" + floatstyle + "' class='" + wrapstyle + "'>");
                                }
                                else
                                {
                                    string multiplewrappers = start.Depth == j ? string.Format("sfWrap {0} sf{1} clearfix", start.Class, j) : string.Format("sfWrap {0} sf{1}", start.Class == "" ? "" : string.Format(" {0}", start.Class), j);
                                    string floatstyle = divwidth == "100%" ? string.Format("width:{0}", divwidth) : string.Format("width:{0};float:left", divwidth);
                                    sb.Append("<div style='" + floatstyle + "' class='" + multiplewrappers + "'>");
                                }
                            }
                        }
                        if (start.LSTPositions.Contains(positionsAr[i]))
                        {
                            int width = Calculator.CalculatePostWrapWidth(start.LSTPositions.ToArray(), positionsAr[i], wrapperwidth, "normal", lstWidths);
                            style = Mode == 0 ? string.Format("width:{0}%;float:left", width) : width == 100 ? "float:left" : string.Format("width:{0}%;float:left", width);

                        }
                    }

                }
                string customStyle = Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT) == "" ? string.Format("{0}", style) : string.Format("{0};min-height:{1}px", style, Utils.GetAttributeValueByName(placeholder, XmlAttributeTypes.MINHEIGHT));
                if (customStyle != "")
                {
                    string id = string.Format("sf{0}", Utils.UppercaseFirst(positionsAr[i]));
                    sb.Append("<div id=" + id + " style='" + customStyle + "'>");
                }
                sb.Append(Mode == 2 ? "<div class='sfWrapper'>" : "<div class='sfWrapper sfCurve'>");
                //sb.Append(positionsAr[i]);
                sb.Append(HtmlBuilder.AddPlaceholder(positionsAr[i], Mode));
                sb.Append("</div>");
                if (customStyle != "")
                    sb.Append("</div>");

                if (arrWidth.Length == i)
                {
                    //sb.Append("<div class='clearfix'></div>");
                }
                foreach (CustomWrapper start in lstWrapper)
                {
                    if (start.End.ToLower() == positionsAr[i] && start.Type == "position")
                    {
                        for (int j = 1; j <= start.Depth; j++)
                        {
                            sb.Append("</div>");
                        }
                    }
                }
            }
            if (positionsAr.Length > 1)
            {
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        public static string ProcessMiddlePlaceholders(Placeholders placeholder, XmlTag middleblock, List<CustomWrapper> lstWrapper, int _Mode)
        {
            Mode = _Mode;
            StringBuilder sb = new StringBuilder();
            bool isAvailable = false;
            foreach (XmlTag pch in middleblock.LSTChildNodes)
            {
                if (Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower() == placeholder.ToString().ToLower())
                {
                    foreach (CustomWrapper start in lstWrapper)
                    {
                        if (start.Type == "placeholder" && Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower().Equals(start.Start))
                        {
                            string style = "";
                            for (int i = 1; i <= start.Depth; i++)
                            {
                                if (i == 1)
                                {
                                    style = start.Depth > 1 ? string.Format("sfBlockwrap {0}", start.Class) : string.Format("sfBlockwrap {0} clearfix", start.Class);
                                    sb.Append("<div class='" + style + "'>");
                                }
                                else
                                {
                                    style = start.Depth == i ? string.Format("sfBlockwrap {0} sf{1} clearfix", start.Class, i) : string.Format("sfBlockwrap {0} sf{1}", start.Class, i);
                                    sb.Append("<div class='" + style + "'>");
                                }
                            }

                        }
                    }

                    string[] positions = pch.InnerHtml.Split(',');
                    int mode = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.MODE) == "" ? 0 : 1;
                    string wrapperclass =placeholder.ToString().ToLower().Equals("fulltopspan")||placeholder.ToString().ToLower().Equals("fullbottomspan")?string.Format("sf{0} clearfix", Utils.UppercaseFirst(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME)))
                                            :string.Format("sf{0}", Utils.UppercaseFirst(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME)));
                    wrapperclass = string.Format("{0} {1}",wrapperclass,Utils.GetAttributeValueByName(pch, XmlAttributeTypes.CLASS));
                    sb.Append("<div class='" + wrapperclass + "'>");
                    switch (mode)
                    {
                        case 0:
                            sb.Append(ParseNormalBlocks(pch, lstWrapper));
                            break;
                        case 1:
                            sb.Append(ParseFixedBlocks(pch, lstWrapper));
                            break;
                    }
                    sb.Append("</div>");
                    foreach (CustomWrapper start in lstWrapper)
                    {
                        string pchName = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower();
                        if (start.Type == "placeholder" && pchName.Equals(start.End))
                        {
                            for (int i = 1; i <= start.Depth; i++)
                            {
                                sb.Append("</div>");
                            }
                        }
                    }
                    isAvailable = true;
                }

            }
            if (!isAvailable)
            {
                sb.Append(Mode == 2 ? "<div class='" + placeholder.ToString().ToLower() + "'><div class='sfWrapper'>" : "<div class='" + placeholder.ToString().ToLower() + "'><div class='sfWrapper sfCurve'>");
                sb.Append(HtmlBuilder.AddPlaceholder(placeholder.ToString().ToLower(), Mode));
                sb.Append("</div></div>");
            }

            return sb.ToString();
        }
        public static string GenerateBlockWrappers(XmlTag pch, ref List<int> wrapperdepth)
        {
            StringBuilder sb = new StringBuilder();
            int wrapinner = int.Parse(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.WRAPINNER, "1"));
            int wrapouter = int.Parse(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.WRAPOUTER, "1"));
            string customclass = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.CLASS);
            wrapperdepth.Add(wrapouter);
            wrapperdepth.Add(wrapinner);
            if (wrapouter != 0)
            {
                for (int i = 1; i <= wrapouter; i++)
                {
                    if (i == 1)
                    {
                        string wrapperclass = wrapouter > 1 ? "sfOuterwrapper" : "sfOuterwrapper clearfix";
                        wrapperclass = customclass != "" ? string.Format("{0} {1}", wrapperclass, customclass) : wrapperclass;
                        sb.Append(string.Format("<div id='sf{0}' class='{1}'>", Utils.UppercaseFirst(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME)), wrapperclass));
                    }
                    else
                    {
                        string wrapperclass = wrapouter == i ? string.Format("sfOuterwrapper{0} clearfix", i - 1) : string.Format("sfOuterwrapper{0}", i - 1);
                        wrapperclass = customclass != "" ? string.Format("{0} {1}", wrapperclass, customclass) : wrapperclass;
                        sb.Append(string.Format("<div class='{0}'>", wrapperclass));
                    }

                }
            }
            else if (wrapouter == 0)
            {
                sb.Append(string.Format("<div id='sf{0}'>", Utils.UppercaseFirst(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME))));
            }
            if (wrapinner != 0)
            {
                for (int i = 1; i <= wrapinner; i++)
                {
                    if (i == 1)
                    {
                        string wrapperclass = wrapinner > 1 ? "sfInnerwrapper" : "sfInnerwrapper clearfix";
                        sb.Append(string.Format("<div class='{0}'>", wrapperclass));
                    }
                    else
                    {
                        string wrapperclass = wrapinner == i ? string.Format("sfInnerwrapper{0} clearfix", i - 1) : string.Format("sfInnerwrapper{0}", i - 1);
                        sb.Append(string.Format("<div class='{0}'>", wrapperclass));
                    }

                }
            }



            return sb.ToString();
        }
        public static string ProcessLeftRightPlaceholders(Placeholders placeholder, XmlTag middleblock, List<CustomWrapper> lstWrapper, int _Mode,string Width)
        {
            Mode = _Mode;
            StringBuilder sb = new StringBuilder();
            bool isAvailable = false;
            foreach (XmlTag pch in middleblock.LSTChildNodes)
            {
                if (Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower() == placeholder.ToString().ToLower())
                {
                    foreach (CustomWrapper start in lstWrapper)
                    {
                        if (start.Type == "placeholder" && Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower().Equals(start.Start))
                        {
                            string style = "";
                            for (int i = 1; i <= start.Depth; i++)
                            {
                                if (i == 1)
                                {
                                    style = start.Depth > 1 ? string.Format("sfBlockwrap {0}", start.Class) : string.Format("sfBlockwrap {0} clearfix", start.Class);
                                    sb.Append("<div class='" + style + "'>");
                                }
                                else
                                {
                                    style = start.Depth == i ? string.Format("sfBlockwrap {0} sf{1} clearfix", start.Class, i) : string.Format("sfBlockwrap {0} sf{1}", start.Class, i);
                                    sb.Append("<div class='" + style + "'>");
                                }
                            }

                        }
                    }

                    string[] positions = pch.InnerHtml.Split(',');
                    int mode = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.MODE) == "" ? 0 : 1;
                    string wrapperclass = string.Format("sf{0} clearfix", Utils.UppercaseFirst(Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME)));                                            
                    wrapperclass = string.Format("{0} {1}", wrapperclass, Utils.GetAttributeValueByName(pch, XmlAttributeTypes.CLASS));
                    string colwidth = string.Format("class='{0}' style='width:{1}'",wrapperclass,Width);
                    sb.Append("<div "+colwidth+">");
                    switch (mode)
                    {
                        case 0:
                            sb.Append(ParseNormalLeftRightBlocks(pch, lstWrapper));
                            break;
                        case 1:
                            sb.Append(ParseFixedBlocks(pch, lstWrapper));
                            break;
                    }
                    sb.Append("</div>");
                    foreach (CustomWrapper start in lstWrapper)
                    {
                        string pchName = Utils.GetAttributeValueByName(pch, XmlAttributeTypes.NAME).ToLower();
                        if (start.Type == "placeholder" && pchName.Equals(start.End))
                        {
                            for (int i = 1; i <= start.Depth; i++)
                            {
                                sb.Append("</div>");
                            }
                        }
                    }
                    isAvailable = true;
                }

            }
            if (!isAvailable)
            {
                sb.Append(Mode == 2 ? "<div class='" + placeholder.ToString().ToLower() + "'><div class='sfWrapper'>" : "<div class='" + placeholder.ToString().ToLower() + "'><div class='sfWrapper sfCurve'>");
                sb.Append(HtmlBuilder.AddPlaceholder(placeholder.ToString().ToLower(), Mode));
                sb.Append("</div></div>");
            }

            return sb.ToString();
        }

    }
}
