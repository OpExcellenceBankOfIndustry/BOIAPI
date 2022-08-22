using BOI.BOIApplications.Application.Model.Mail;

namespace BOI.BOIApplications.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailRequest email);
    }
}
