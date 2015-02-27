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
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Net.Mail;
using SageFrame.Web;


namespace SageFrame.SageFrameClass.MessageManagement
{
    public class MailHelper
    {

        public static void SendMailNoAttachment(string From, string sendTo, string Subject, string Body, string CC,
                                                string BCC)
        {
            SendEMail(From, sendTo, Subject, Body, CC, BCC);
        }

     
        public static void SendMailOneAttachment(string From, string sendTo, string Subject, string Body,
                                                 string AttachmentFile, string CC, string BCC)
        {
            SendEMail(From, sendTo, Subject, Body, AttachmentFile, CC, BCC);
        }

        
        public static void SendMailMultipleAttachments(string From, string sendTo, string Subject, string Body,
                                                       ArrayList AttachmentFiles, string CC, string BCC)
        {
            SendEMail(From, sendTo, Subject, Body, AttachmentFiles, CC, BCC);
        }

         public static void SendEMail(string From, string sendTo, string Subject, string Body, string CC, string BCC)
        {
            ArrayList AttachmentFiles;
            AttachmentFiles = null;
            SendEMail(From, sendTo, Subject, Body, AttachmentFiles, CC, BCC);
        }

        public static void SendEMail(string From, string sendTo, string Subject, string Body, string AttachmentFile,
                                     string CC, string BCC)
        {
            ArrayList AttachmentFiles = new ArrayList();

            if (AttachmentFile != null && AttachmentFile.Length != 0)
            {
                AttachmentFiles.Add(AttachmentFile);
            }

            else
            {
                AttachmentFiles = null;
            }
            SendEMail(From, sendTo, Subject, Body, AttachmentFiles, CC, BCC);
        }

        public static void SendEMail(string From, string sendTo, string Subject, string Body, ArrayList AttachmentFiles,
                                     string CC, string BCC)
        {
            SendEMail(From, sendTo, Subject, Body, AttachmentFiles, CC, BCC, true);
        }

        public static void SendEMail(string From, string sendTo, string Subject, string Body, ArrayList AttachmentFiles, string CC, string BCC, bool IsHtmlFormat)
        {
            SageFrameConfig sfConfig = new SageFrameConfig();           
            string ServerPort = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SMTPServer);
            string SMTPAuthentication = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SMTPAuthentication);
            string SMTPEnableSSL = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SMTPEnableSSL);
            string SMTPPassword = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SMTPPassword);
            string SMTPUsername = sfConfig.GetSettingsByKey(SageFrameSettingKeys.SMTPUsername);
            string[] SMTPServer = ServerPort.Split(':');
            try
            {
                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(sendTo);
                myMessage.From = new MailAddress(From);
                myMessage.Subject = Subject;
                myMessage.Body = Body;
                myMessage.IsBodyHtml = true;

                if (CC.Length != 0) 
                    myMessage.CC.Add(CC);

                if (BCC.Length != 0) 
                    myMessage.Bcc.Add(BCC);

                if (AttachmentFiles != null)
                {
                    foreach (string x in AttachmentFiles)
                    {
                        if (File.Exists(x)) myMessage.Attachments.Add(new Attachment(x));
                    }
                }
                SmtpClient smtp = new SmtpClient();
                if (SMTPAuthentication == "1")
                {
                    if (SMTPUsername.Length > 0 && SMTPPassword.Length > 0)
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(SMTPUsername, SMTPPassword);
                    }
                }
                smtp.EnableSsl = bool.Parse(SMTPEnableSSL.ToString());
                if (SMTPServer.Length > 0)
                {
                    if (SMTPServer[0].Length != 0)
                    {
                        smtp.Host = SMTPServer[0];
                        if (SMTPServer.Length == 2)
                        {
                            smtp.Port = int.Parse(SMTPServer[1]);
                        }
                        else
                        {
                            smtp.Port = 25;
                        }
                        smtp.Send(myMessage);
                    }
                    else
                    {
                        throw new Exception("SMTP Host must be provided");
                    }
                }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FormatEmail(string email)
        {
            string user = email.Substring(0, email.IndexOf('@'));
            string dom = email.Substring(email.IndexOf('@') + 1);
            return "<script language=\"javascript\">var name = \"" + user + "\"; var domain = \"" + dom + "\"; document.write('<a href=\"mailto:' + name + String.fromCharCode(64) + domain + '\">' + name + String.fromCharCode(64) + domain + '</a>')</script><noscript>" + user + " at " + dom + "</noscript>";
        }
    }
}