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
