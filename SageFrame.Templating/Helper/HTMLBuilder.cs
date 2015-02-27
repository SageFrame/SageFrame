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
using System.Text.RegularExpressions;
using System.Web;
#endregion

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
            string path = HttpContext.Current.Server.MapPath("~/") + "//Modules//LayoutManager//Sections//" + htmlfile;
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
