using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.Influence
{
    public class PEPRepository : BaseRepository<PEP>, IPEPRepository
    {
        public PEPRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> DoesPEPExist(string pepBVN)
        {
            var matches = _dbContext.PEPs.Any(x => x.PepBvn == pepBVN);
            return Task.FromResult(matches);
        }

        public async Task<PEP> GetPEPByBvn(string pepBVN)
        {
            var matches = await _dbContext.PEPs.FirstOrDefaultAsync(x => x.PepBvn == pepBVN);
            return matches;
        }
    }
}
