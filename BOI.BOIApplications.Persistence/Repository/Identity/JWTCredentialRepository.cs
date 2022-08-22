using BOI.BOIApplications.Application.Contracts.Persistence.Identity;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Persistence.Repository.Identity
{
    public class JWTCredentialRepository : BaseRepository<JWTCredential>, IJWTCredentialRepository
    {
        public JWTCredentialRepository(BOIDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> DoesUserExist(JWTCredential credential)
        {
            var matches = _dbContext.JWTCredentials.Any(x => x.UserName.ToLower() == credential.UserName.ToLower() && 
                           x.Password == credential.Password);
            return Task.FromResult(matches);
        }
    }
}
