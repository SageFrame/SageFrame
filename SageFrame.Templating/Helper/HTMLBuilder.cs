
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
using System.IO;
using System.Text.RegularExpressions;

namespace SageFrame.Templating
{
    public class HTMLBuilder:IHTMLBuilder
    {
        public string GenerateOuterWrappers(){
            return (GetHTMLContent("OuterWrappers.htm","outerwrapper"));
        }

        public string GenerateDefaultSectionWrappers()
        {
            return "";
        }

        public string GenerateBlockWrappers(string placeholder)
        {
            string html = "";
            switch (placeholder)
            {
                case "admin":
                    html = GetHTMLContent("admin.htm", placeholder);
                    break;
                case "header":
                    html = GetHTMLContent("header.htm",placeholder);
                    break;
                case "HeaderLeftPane":
                    html = GetHTMLContent("headerleft.htm", placeholder);
                    break;
                case "HeaderCenterPane":
                    html = GetHTMLContent("headercenter.htm", placeholder);
                    break;
                case "HeaderRightPane":
                    html = GetHTMLContent("headerright.htm", placeholder);
                    break;
                case "top":
                    html = GetHTMLContent("top.htm", placeholder);
                    break;
                case "TopPane":
                    html = GetHTMLContent("toppane.htm", placeholder);
                    break;
                case "body":
                    html = GetHTMLContent("body.htm", placeholder);
                    break;
                case "LeftPane":
                    html = GetHTMLContent("masterleft.htm", placeholder);
                    break;
                case "ContentPane":
                    html = GetHTMLContent("mastercenter.htm", placeholder);
                    break;
                case "RightPane":
                    html = GetHTMLContent("masterright.htm", placeholder);
                    break;
                case "bottom":
                    html = GetHTMLContent("bottom.htm", placeholder);
                    break;                
                case "BottomPane":
                    html = GetHTMLContent("bottompane.htm", placeholder);
                    break;
                case "footer":
                    html = GetHTMLContent("footer.htm", placeholder);
                    break;
                case "FooterLeftPane":
                    html = GetHTMLContent("footerleft.htm", placeholder);
                    break;
                case "FooterCenterPane":
                    html = GetHTMLContent("footercenter.htm", placeholder);
                    break;
                case "FooterRightPane":
                    html = GetHTMLContent("footerright.htm", placeholder);
                    break;
            }
            return html;
        }

        public string GetHTMLContent(string htmlfile,string placeholder)
        {
            string path = "E://DotNetProjects//sftemplating//SageFrame//Modules//LayoutManager//Sections//" + htmlfile;
            string html = "";
            using (StreamReader rdr = new StreamReader(path))
            {
                html = rdr.ReadToEnd();
                PutPlaceHolders(htmlfile.Replace(".htm", "").ToLower(),ref html,placeholder);
            }
            return html;
        }

        public void PutPlaceHolders(string name, ref string html,string placeholder)
        {
            string id = placeholder;
            int index = html.IndexOf("[[pch]]");
            if (index > -1)
            {
                html=html.Remove(index, 7);                
                html=html.Insert(index, String.Format(@"<asp:PlaceHolder runat='server' ID='{0}'></asp:PlaceHolder>",id));
            }
        }

        public string ReadHTML(string htmlfile)
        {
           
            string html = "";
            using (StreamReader rdr = new StreamReader(htmlfile))
            {
                html = rdr.ReadToEnd();               
            }
            return html;
        }

    }
}
