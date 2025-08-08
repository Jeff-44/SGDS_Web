using Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly EmailSettings _options;
        public MailKitEmailSender(IOptions<EmailSettings> options)
        {
            _options = options.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new MimeMessage();
            msg.From.Add(MailboxAddress.Parse(_options.From));
            msg.To.Add(MailboxAddress.Parse(email));
            msg.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = htmlMessage };
            msg.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            
            var secure = _options.UseStartTls
                ? SecureSocketOptions.StartTls
                : SecureSocketOptions.SslOnConnect;

            await smtp.ConnectAsync(_options.Host, _options.Port, secure);
            await smtp.AuthenticateAsync(_options.Username, _options.Password);
            await smtp.SendAsync(msg);
            await smtp.DisconnectAsync(true);
        }
    }
}
