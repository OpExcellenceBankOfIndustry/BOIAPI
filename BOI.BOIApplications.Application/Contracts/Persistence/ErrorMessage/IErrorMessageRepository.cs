using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;

namespace BOI.BOIApplications.Application.Contracts.Persistence.ErrorMessage
{
    public interface IErrorMessageRepository
    {
        Task<ErrorCodeDescriptionTable> GetErrorMessages(string errorCode, string connectionString);
    }
}