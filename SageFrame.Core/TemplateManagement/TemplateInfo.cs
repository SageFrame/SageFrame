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
