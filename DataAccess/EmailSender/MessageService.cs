using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EmailSender
{
    public class MessageService : IMessageService
    {
        private readonly IHostingEnvironment _env;
        public MessageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public  async Task SendEmail(string FromName, 
            string FromEmailAddress, 
            string ToName, 
            string ToEmailAddress, 
            string Subject,
            string Message, 
            params Attachment[] Attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(FromName, FromEmailAddress));
            email.To.Add(new MailboxAddress(ToName, ToEmailAddress));
            email.Subject = Subject;

            //Getting the path wwwroot
            var webRoot = _env.WebRootPath;
            //Getting the template html in the fold Templates
            var pathToFile = _env.WebRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "emailPayTemplate.html";

            var Body = new BodyBuilder();
            //Reading template and put it into Body.HtmlBody
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                Body.HtmlBody = SourceReader.ReadToEnd();

            }
            //Getting the information and replaced at the template
            Body.HtmlBody = string.Format(Body.HtmlBody, ToEmailAddress, Message);

            
             foreach ( var attachment in Attachments )
            {
                using (var stream = await attachment.ContetToSend())
                {
                    Body.Attachments.Add(attachment.FileName, stream);
                }
            }
             //Getting Body and put it into email to send
            email.Body = Body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("outlook.office365.com", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("renato-carvalho-dos@hotmail.com", "38811985").ConfigureAwait(false);

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
