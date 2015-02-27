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
    public class HTMLDataProvider
    {
        public HTMLDataProvider()
        {
        }

        public void HTMLCommentDeleteByCommentID(int HTMLCommentID, int PortalID, string DeletedBy)
        {
            try
            {
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", HTMLCommentID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@DeletedBy", DeletedBy));
                SQLHandler sq = new SQLHandler();
                sq.ExecuteNonQuery("dbo.sp_HtmlCommentDeleteByCommentID", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", HTMLCommentID));
                SQLHandler sq = new SQLHandler();
                return sq.ExecuteAsObject<HTMLContentInfo>("dbo.sp_HtmlCommentGetByHTMLCommentID", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", HTMLTextID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Comment", Comment));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsApproved", IsApproved));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
                SQLHandler sq = new SQLHandler();
                sq.ExecuteNonQuery("dbo.sp_HtmlCommentAdd", ParaMeterCollection, "@HTMLCommentID");
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLCommentID", HTMLCommentID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Comment", Comment));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsApproved", IsApproved));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", IsModified));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                SQLHandler sq = new SQLHandler();
                sq.ExecuteNonQuery("dbo.sp_HtmlCommentUpdate", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PermissionKey", "EDIT"));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", Username));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                SQLHandler sagesql = new SQLHandler();
                return sagesql.ExecuteAsScalar<bool>("sp_CheckUserModulePermissionByPermissionKeyADO", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UsermoduleID", UsermoduleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", CultureName));
                SQLHandler sagesql = new SQLHandler();
                HTMLContentInfo objHtmlInfo = sagesql.ExecuteAsObject<HTMLContentInfo>("dbo.sp_HtmlTextGetByPortalAndUserModule", ParaMeterCollection);
                return objHtmlInfo;
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", HTMLTextID));
                SQLHandler Sq = new SQLHandler();
                List<HTMLContentInfo> ml = Sq.ExecuteAsList<HTMLContentInfo>("dbo.sp_HtmlCommentGetAllByHTMLTextID", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@HTMLTextID", HTMLTextID));
                SQLHandler Sq = new SQLHandler();
                List<HTMLContentInfo> ml = Sq.ExecuteAsList<HTMLContentInfo>("dbo.sp_HtmlActiveCommentGetByHTMLTextID", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UsermoduleID", UsermoduleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", CultureName));
                SQLHandler Sq = new SQLHandler();
                return Sq.ExecuteAsObject<HTMLContentInfo>("dbo.sp_HtmlTextGetByPortalAndUserModule", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", Content));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", CultureName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAllowedToComment", IsAllowedToComment));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", IsModified));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedOn", UpdatedOn));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UpdatedBy", UpdatedBy));
                SQLHandler Sq = new SQLHandler();
                Sq.ExecuteNonQuery("dbo.sp_HtmlTextUpdate", ParaMeterCollection);
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
                List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", UserModuleID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@Content", Content));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@CultureName", CultureName));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsAllowedToComment", IsAllowedToComment));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsModified", IsModified));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@IsActive", IsActive));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedOn", AddedOn));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", PortalID));
                ParaMeterCollection.Add(new KeyValuePair<string, object>("@AddedBy", AddedBy));
                SQLHandler Sq = new SQLHandler();
                return Sq.ExecuteNonQueryAsGivenType<int>("dbo.sp_HtmlTextAdd", ParaMeterCollection, "@HTMLTextID");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool IsAuthenticatedToEdit(string usermoduleid, string username, int portalid)
        {
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PermissionKey", "EDIT"));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserModuleID", Int32.Parse(usermoduleid)));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@UserName", username));
            ParaMeterCollection.Add(new KeyValuePair<string, object>("@PortalID", portalid));
            SQLHandler sagesql = new SQLHandler();
            return sagesql.ExecuteAsScalar<bool>("sp_CheckUserModulePermissionByPermissionKeyADO", ParaMeterCollection);
        }
    }
}