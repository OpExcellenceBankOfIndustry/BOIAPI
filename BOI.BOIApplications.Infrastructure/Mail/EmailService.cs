using BOI.BOIApplications.Application.Contracts.Infrastructure;
using BOI.BOIApplications.Application.Helpers.Mail;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Application.Model.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigurationSettings _mailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailConfigurationSettings> options, ILogger<EmailService> logger)
        {
            _mailSettings = options.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(EmailRequest email)
        {
            var message = await email.RecieverEmailAddresses();
            message.From.Add(new MailboxAddress(_mailSettings.BankName, _mailSettings.EmailFrom));
            message.Subject = email.Subject;

            message.Body = email.IsHtml
                ? new TextPart("html") { Text = email.Message }
                : new TextPart("plain") { Text = email.Message };

            var builder = new BodyBuilder();

            if (email.IsHtml)
            {
                builder.HtmlBody = email.Message;
            }
            else
            {
                builder.TextBody = email.Message;
            }

            if (email.HasAttachment)
            {
                foreach (var emailattachement in email.EmailAttachmentsRequest)
                {
                    builder.Attachments.Add(emailattachement.FileName, emailattachement.Attachment);
                }
            }

            message.Body = builder.ToMessageBody();
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _logger.LogInformation("About to call smtp server", "");

            var client = new SmtpClient();
            //client.CheckCertificateRevocation = false;
            client.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.None);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(_mailSettings.SmtpUser,_mailSettings.SmtpPassword);

            await client.SendAsync(message);
            client.Disconnect(true);
            _logger.LogInformation("after calling smtp server", "");

            return true;
        }
    }
}
