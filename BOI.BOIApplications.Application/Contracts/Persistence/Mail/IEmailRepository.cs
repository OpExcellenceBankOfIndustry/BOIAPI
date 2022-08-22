using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Mail
{
    public interface IEmailRepository : IAsyncRepository<Email>
    {
        Task<List<Email>> GetPendingEnquedEmail();
    }
}
