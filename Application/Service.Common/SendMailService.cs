using Application.IService.Common;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Common
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfiguration _configuration;
        public SendMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendMailAsync(string email, string subject, string message)
        {
            try
            {
                var _email = _configuration["EmailSetting:Email"];
                var _epass = _configuration["EmailSetting:Password"];
                var _dispName = _configuration["EmailSetting:DisplayName"];
                var mailMessage = new MimeMessage();
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = message;
                mailMessage.From.Add(new MailboxAddress(_dispName, _email));
                mailMessage.To.Add(new MailboxAddress("", email));
                mailMessage.Subject = subject;
                mailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(_email, _epass);
                    client.Send(mailMessage);
                    client.Disconnect(true);
                }
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
