#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml;
using System.Web;
using System.Data;
using SageFrame.Message;
using System.Web.Security;
using SageFrame.Web;
using SageFrame.UserManagement;

#endregion



namespace SageFrameClass.MessageManagement
{
    public class MessageToken
    {
        public static NameValueCollection GetListOfAllowedTokens()
        {
            NameValueCollection allowedTokens = new NameValueCollection();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("SageFrame\\App_GlobalResources\\MessageToken.xml");
                foreach (XmlNode node in doc.SelectSingleNode("messagetokens").ChildNodes)
                {
                    if ((node.NodeType != XmlNodeType.Comment))
                    {
                        allowedTokens.Add(node.Attributes["value"].Value, node.Attributes["key"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allowedTokens;
        }

       

        public static string ReplaceAllMessageToken(string messageTemplate, string username, Int32 PortalID)
        {
            string[] tokens = GetAllToken(messageTemplate);
            foreach (string token in tokens)
            {
                switch (token)
                {
                    case "%UserFirstName%":
                        string fName = GetUserFirstName(username, PortalID);
                        messageTemplate = messageTemplate.Replace(token, fName);
                        break;
                    case "%UserLastName%":
                        string lName = GetUserLastName(username, PortalID);
                        messageTemplate = messageTemplate.Replace(token, lName);
                        break;
                    case "%UserEmail%":
                        string userEmail = GetUserEmail(username, PortalID);
                        messageTemplate = messageTemplate.Replace(token, userEmail);
                        break;
                    case "%UserActivationCode%":
                        string act = GetUserActivationCode(username, PortalID);
                        act = EncryptionMD5.Encrypt(act);
                        messageTemplate = messageTemplate.Replace(token, act);
                        break;
                    case "%Username%":
                        messageTemplate.Replace(token, username);
                        break;
                }
            }
            return messageTemplate;
        }

        public static string ReplaceAllMessageToken(string messageTemplate, DataTable messageTokenValueDT)
        {
            string messageToken = string.Empty;
            string messateTokenValue = string.Empty;

            for (int i = 0; i < messageTokenValueDT.Columns.Count; i++)
            {
                messageToken = messageTokenValueDT.Columns[i].ColumnName.ToString().Replace('_', '%');
                messateTokenValue = messageTokenValueDT.Rows[0][i].ToString();
                switch (messageToken)
                {
                    case "%UserActivationCode%":
                        messateTokenValue = EncryptionMD5.Encrypt(messateTokenValue);
                        break;
                }
                messageTemplate = messageTemplate.Replace(messageToken, messateTokenValue);
            }
            return messageTemplate;
        }
        public static string ReplaceToken(string template, string token, string value)
        {
            return template.Replace(token, value);
        }

        public static string GetUserFirstName(string username, Int32 PortalID)
        {
            MessageManagementController objController = new MessageManagementController();
            MessageManagementInfo objInfo = objController.GetUserFirstName(username, PortalID);
            return objInfo.FirstName;
        }

        public static string GetUserLastName(string username, Int32 PortalID)
        {
            MessageManagementController objController = new MessageManagementController();
            MessageManagementInfo objInfo = objController.GetUserLastName(username, PortalID);
            return objInfo.LastName;
        }

        public static string GetUserEmail(string username, Int32 PortalID)
        {
            MessageManagementController objController = new MessageManagementController();
            MessageManagementInfo objInfo = objController.GetUserEmail(username, PortalID);
            return objInfo.Email;
        }

        public static string GetUserActivationCode(string username, Int32 PortalID)
        {
            MessageManagementController objController = new MessageManagementController();
            MessageManagementInfo objInfo = objController.GetUserActivationCode(username, PortalID);
            return objInfo.UserId.ToString();

        }

        public static string GetFirstToken(string template)
        {
            int preIndex = template.IndexOf('%', 0);
            int postIndex = template.IndexOf('%', preIndex + 1);
            string token = template.Substring(preIndex, postIndex - preIndex);
            return string.Empty;
        }

        public static string[] GetAllToken(string template)
        {
            List<string> returnValue = new List<string> { };
            int preIndex = template.IndexOf('%', 0);
            int postIndex = template.IndexOf('%', preIndex + 1);
            while (preIndex > -1)
            {

                returnValue.Add(template.Substring(preIndex, (postIndex - preIndex) + 1));
                template = template.Substring(postIndex + 1, (template.Length - postIndex) - 1);
                preIndex = template.IndexOf('%', 0);
                postIndex = template.IndexOf('%', preIndex + 1);
            }
            return returnValue.ToArray();
        }
       
    }
}
