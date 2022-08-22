using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Mail
{
    public interface IEmailAttachmentRepository : IAsyncRepository<EmailAttachment>
    {
    }
}
