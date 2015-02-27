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
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections;
using SageFrame.Web.Utilities;

#endregion


namespace SageFrame.HTMLText
{
    public class HTMLController
    {
        public HTMLController()
        {
        }

        public void HTMLCommentDeleteByCommentID(int HTMLCommentID, int PortalID, string DeletedBy)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                objProvider.HTMLCommentDeleteByCommentID(HTMLCommentID, PortalID, DeletedBy);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HTMLContentInfo HtmlCommentGetByHTMLCommentID(int PortalID, int HTMLCommentID)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                HTMLContentInfo htmlInfo = objProvider.HtmlCommentGetByHTMLCommentID(PortalID, HTMLCommentID);
                return htmlInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void HtmlCommentAdd(string HTMLTextID, string Comment, bool IsApproved, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                objProvider.HtmlCommentAdd(HTMLTextID, Comment, IsApproved, IsActive, AddedOn, PortalID, AddedBy);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void HtmlCommentUpdate(object HTMLCommentID, string Comment, bool IsApproved, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                objProvider.HtmlCommentUpdate(HTMLCommentID, Comment, IsApproved, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsAuthenticatedToEdit(int UserModuleID, string Username, int PortalID)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                bool IsAuthenticated = objProvider.IsAuthenticatedToEdit(UserModuleID, Username, PortalID);
                return IsAuthenticated;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HTMLContentInfo GetHTMLContent(int PortalID, int UsermoduleID, string CultureName)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                HTMLContentInfo htmlContentInfo = objProvider.GetHTMLContent(PortalID, UsermoduleID, CultureName);
                return htmlContentInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<HTMLContentInfo> BindCommentForSuperUser(int PortalID, string HTMLTextID)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                List<HTMLContentInfo> ml = objProvider.BindCommentForSuperUser(PortalID, HTMLTextID);
                return ml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<HTMLContentInfo> BindCommentForOthers(int PortalID, string HTMLTextID)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                List<HTMLContentInfo> ml = objProvider.BindCommentForOthers(PortalID, HTMLTextID);
                return ml;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HTMLContentInfo HtmlTextGetByPortalAndUserModule(int PortalID, int UsermoduleID, string CultureName)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                HTMLContentInfo objHtmlContent = objProvider.HtmlTextGetByPortalAndUserModule(PortalID, UsermoduleID, CultureName);
                return objHtmlContent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void HtmlTextUpdate(string UserModuleID, string Content, string CultureName, bool IsAllowedToComment, bool IsActive, bool IsModified, DateTime UpdatedOn, int PortalID, string UpdatedBy)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                objProvider.HtmlTextUpdate(UserModuleID, Content, CultureName, IsAllowedToComment, IsActive, IsModified, UpdatedOn, PortalID, UpdatedBy);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int HtmlTextAdd(string UserModuleID, string Content, string CultureName, bool IsAllowedToComment, bool IsModified, bool IsActive, DateTime AddedOn, int PortalID, string AddedBy)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                int htmlTextAdd = objProvider.HtmlTextAdd(UserModuleID, Content, CultureName, IsAllowedToComment, IsModified, IsActive, AddedOn, PortalID, AddedBy);
                return htmlTextAdd;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string RemoveUnwantedHTMLTAG(string str)
        {
            str = System.Text.RegularExpressions.Regex.Replace(str, "<br/>$", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, "^&nbsp;", "");
            //str = System.Text.RegularExpressions.Regex.Replace(str, "/(<form[^\>]*\>)([\s\S]*)(\<\/form\>)/i", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, "<form[^>]*>", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, "</form>", "");
            return str; //Regex.Replace(str, @"<(.|\n)*?>", string.Empty);
        }

        public static bool IsAuthenticatedToEdit(string usermoduleid, string username, int portalid)
        {
            try
            {
                HTMLDataProvider objProvider = new HTMLDataProvider();
                bool IsAunticateToEdit = HTMLDataProvider.IsAuthenticatedToEdit(usermoduleid, username, portalid);
                return IsAunticateToEdit;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
