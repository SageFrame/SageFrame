#region "Copyright"

/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/

#endregion

#region "References"

using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Net.Mail;
using SageFrame.Web;

#endregion



namespace SageFrame.SageFrameClass.MessageManagement
{
    public class MailHelper
    {
        public static void SendMultipleEmail(string From, string sendTo, string Subject, string Body)
        {
            SageFrameConfig sfConfig = new SageFrameConfig();
            string ServerPort = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPServer);
            string SMTPAuthentication = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPAuthentication);
            string SMTPEnableSSL = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPEnableSSL);
            string SMTPPassword = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPPassword);
            string SMTPUsername = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPUsername);
            string[] SMTPServer = ServerPort.Split(':');
            try
            {
                MailMessage myMessage = new MailMessage();
                foreach (string emailTo in sendTo.Split(','))
                {
                    myMessage.To.Add(new MailAddress(emailTo));
                }
                myMessage.From = new MailAddress(From);
                myMessage.Subject = Subject;
                myMessage.Body = Body;
                myMessage.IsBodyHtml = true;

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
        public static void SendMultipleEmail(string From, string sendTo, string Subject, string Body, string Identifiers, string pageName)
        {
            SageFrameConfig sfConfig = new SageFrameConfig();
            string ServerPort = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPServer);
            string SMTPAuthentication = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPAuthentication);
            string SMTPEnableSSL = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPEnableSSL);
            string SMTPPassword = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPPassword);
            string SMTPUsername = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPUsername);
            string[] SMTPServer = ServerPort.Split(':');
            try
            {
                MailMessage myMessage = new MailMessage();
                List<string> lstTo = new List<string>();
                List<string> lstidentity = new List<string>();
                foreach (string emailTo in sendTo.Split(','))
                {
                    lstTo.Add(emailTo);
                    myMessage.To.Add(new MailAddress(emailTo));
                }
                foreach (string identity in Identifiers.Split(','))
                {
                    lstidentity.Add(identity);
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
                        int length = lstidentity.Count;
                        for (int j = 0; j < length; j++)
                        {
                            try
                            {
                                myMessage.From = new MailAddress(From);
                                myMessage.To.Add(lstTo[j]);
                                myMessage.Subject = Subject;
                                myMessage.Body = Body + "<br/><br/>if you want to unsubscribe click the link below <br/> " + pageName + "?id=" + lstidentity[j];
                                myMessage.IsBodyHtml = true;
                                smtp.Send(myMessage);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
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
            string ServerPort = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPServer);
            string SMTPAuthentication = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPAuthentication);
            string SMTPEnableSSL = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPEnableSSL);
            string SMTPPassword = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPPassword);
            string SMTPUsername = sfConfig.GetSettingValueByIndividualKey(SageFrameSettingKeys.SMTPUsername);
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