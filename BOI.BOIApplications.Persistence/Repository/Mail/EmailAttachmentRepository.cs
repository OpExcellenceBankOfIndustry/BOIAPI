using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Persistence.Repository.Mail
{
    public class EmailAttachmentRepository : BaseRepository<EmailAttachment>, IEmailAttachmentRepository
    {
        public EmailAttachmentRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }
    }
}
