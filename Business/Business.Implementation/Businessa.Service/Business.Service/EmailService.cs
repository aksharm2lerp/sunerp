using Business.Entities;
using Business.Entities.Setting;
using Business.Interface;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web.Helpers;

namespace Business.Service
{
    public class EmailService : IEmailService
    {
        //private readonly MailSettingMetadata _mailSettings;
        //public EmailService(IOptions<MailSettingMetadata> mailSettings)
        //{
        //    _mailSettings = mailSettings.Value;
        //}
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        /// <summary>
        /// This method is used to send email to single receipiant.
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <param name="isTemplateBody"></param>
        /// <returns></returns>
        public bool SendEmail(MailRequestMetadata mailRequest, bool isTemplateBody = false)
        {
            bool sendEmail = false;
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            string success = smtp.Send(email);
            smtp.Disconnect(true);
            if (!string.IsNullOrEmpty(success))
            {
                sendEmail = true;
            }
            return sendEmail;
        }

        /* public bool SendEmail(MailRequestMetadata mailRequest)
         {
             bool sendEmail = false;
             var email = new MimeMessage();
             email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
             email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
             email.Subject = mailRequest.Subject;
             var builder = new BodyBuilder();
             if (mailRequest.Attachments != null)
             {
                 byte[] fileBytes;
                 foreach (var file in mailRequest.Attachments)
                 {
                     if (file.Length > 0)
                     {
                         using (var ms = new MemoryStream())
                         {
                             file.CopyTo(ms);
                             fileBytes = ms.ToArray();
                         }
                         builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                     }
                 }
             }
             if (mailRequest.Content != null)
             {
                 builder.Attachments.Add("MeetingRequest.pdf", mailRequest.Content, ContentType.Parse("application/pdf"));
             }
             builder.HtmlBody = mailRequest.Body;
             email.Body = builder.ToMessageBody();
             using var smtp = new MailKit.Net.Smtp.SmtpClient();
             smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
             smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
             string success = smtp.Send(email);
             smtp.Disconnect(true);
             if (!string.IsNullOrEmpty(success))
             {
                 sendEmail = true;
             }
             return sendEmail;
         }*/
        /// <summary>
        /// This method is used to send email to multiple receipients.
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        public bool SendEmail(MailRequest mailRequest)
        {
            try
            {
                bool sendEmail = false;
                var email = new MimeMessage();
                //if (mailRequest.ToEmail.Contains(",") == true)
                //{
                //    mailRequest.ToEmail = mailRequest.ToEmail.Replace(",", ";");
                //}

                //if (mailRequest.ToEmail.Contains(";") == true)
                //{
                //    IEnumerable<MailAddress> mailAddresses = mailRequest.ToEmail.Split(";").Select(i => new MailAddress(i));
                //    foreach (var address in mailAddresses)
                //    { 
                //        email.To.Add(MailboxAddress.Parse(address.ToString()));
                //    }
                //}
                //else
                //{
                //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                //}

                if (!string.IsNullOrEmpty(mailRequest.ToEmail))
                {
                    EmailAssigntoObject(email, mailRequest.ToEmail, "TO");
                }

                if (!string.IsNullOrEmpty(mailRequest.CCEmail))
                {
                    EmailAssigntoObject(email, mailRequest.CCEmail, "CC");
                }

                if (!string.IsNullOrEmpty(mailRequest.BCCEmail))
                {
                    EmailAssigntoObject(email, mailRequest.BCCEmail, "BCC");
                }

                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                //if (mailRequest.Content != null)
                //{
                //    builder.Attachments.Add("MeetingRequest.pdf", mailRequest.Content, ContentType.Parse("application/pdf"));
                //}
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail.ToString());

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                string success = smtp.Send(email);
                smtp.Disconnect(true);
                if (!string.IsNullOrEmpty(success))
                {
                    sendEmail = true;
                }
                return sendEmail;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public MimeMessage EmailAssigntoObject(MimeMessage mm, string emails , string sendType)
        {
            if (emails.Contains(";") == true)
            {

                emails = emails.Replace(",", ";");
                IEnumerable<MailAddress> mailAddresses = emails.Split(";").Select(i => new MailAddress(i));
                foreach (var address in mailAddresses)
                {
                    if (sendType == "CC")
                    {
                        mm.Cc.Add(MailboxAddress.Parse(address.ToString()));
                    }
                    else if (sendType == "BCC")
                    {
                        mm.Bcc.Add(MailboxAddress.Parse(address.ToString()));
                    }
                    else if(sendType == "TO")
                    {
                        mm.To.Add(MailboxAddress.Parse(address.ToString()));
                    }
                }
            }
            else
            {
                if (sendType == "CC")
                {
                    mm.Cc.Add(MailboxAddress.Parse(emails));
                }
                else if (sendType == "BCC")
                {
                    mm.Bcc.Add(MailboxAddress.Parse(emails));
                }
                else if (sendType == "TO")
                {
                    mm.To.Add(MailboxAddress.Parse(emails));
                } 
            }

            return mm;
        }
    }
}