using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Identity
{
    public interface IJWTCredentialRepository : IAsyncRepository<JWTCredential>
    {
        Task<bool> DoesUserExist(JWTCredential credential);
    }
}
