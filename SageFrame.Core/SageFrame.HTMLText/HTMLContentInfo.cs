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

namespace SageFrame.HTMLText
{
    public class HTMLContentInfo
    {
        public int HTMLCommentID { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public string ApprovedBy { get; set; }

        private int UserModuleID { get; set; }
        private string CultureName { get; set; }       

		
		
        #region "Private Members"
        int _htmlTextID;
        string _content;
        bool _isActive;
        bool _isAllowedToComment;
        #endregion

        #region "Public Properties"
        public int HtmlTextID
        {
            get { return _htmlTextID; }
            set { _htmlTextID = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public bool IsAllowedToComment
        {
            get { return _isAllowedToComment; }
            set { _isAllowedToComment = value; }
        }

        #endregion

        #region Constructor
        public HTMLContentInfo()
        {
        }

        public HTMLContentInfo(int htmlTextID, string content, bool isActive, bool isAllowedToComment)
        {
            this.HtmlTextID = htmlTextID;
            this.Content = content;
            this.IsActive = isActive;
            this.IsAllowedToComment = isAllowedToComment;
        } 
        #endregion

       
    }
}
