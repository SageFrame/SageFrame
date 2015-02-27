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

namespace SageFrame.Core.TemplateManagement
{
    public class TemplateInfo
    {
        public int TemplateID { get; set; }
        public string TemplateTitle { get; set; }
        public int PortalID { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string AuthorURL { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string ThumbNail { get; set; }        

        public TemplateInfo() { }

        public TemplateInfo(string _TemplateTitle, string _Author, string _Description,string _AuthorURL, int _PortalID, string _AddedBy)
        {
            this.TemplateTitle = _TemplateTitle;
            this.Author = _Author;
            this.Description = _Description;
            this.AuthorURL = _AuthorURL;
            this.PortalID = _PortalID;
            this.AddedBy = _AddedBy;
        }
    }
}
