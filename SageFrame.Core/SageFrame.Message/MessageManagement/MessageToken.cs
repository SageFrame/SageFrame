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
using System.Collections.Specialized;
using System.Linq;
using System.Xml;
using System.Web;
using System.Data;
using SageFrame.Message;
using System.Web.Security;
using SageFrame.Web;
using SageFrame.UserManagement;


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
            MessageManagementInfo objInfo = MessageManagementController.GetUserFirstName(username, PortalID);
            return objInfo.FirstName;
        }

        public static string GetUserLastName(string username, Int32 PortalID)
        {
            MessageManagementInfo objInfo = MessageManagementController.GetUserLastName(username, PortalID);
            return objInfo.LastName;
        }

        public static string GetUserEmail(string username, Int32 PortalID)
        {
            MessageManagementInfo objInfo = MessageManagementController.GetUserEmail(username, PortalID);
            return objInfo.Email;
        }

        public static string GetUserActivationCode(string username, Int32 PortalID)
        {
         
            MessageManagementInfo objInfo = MessageManagementController.GetUserActivationCode(username, PortalID);
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
