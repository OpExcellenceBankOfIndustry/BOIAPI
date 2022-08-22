using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.Influence
{
    public class FEPRepository : BaseRepository<FEP>, IFEPRepository
    {
        public FEPRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> DoesFEPExist(string fepBVN)
        {
            var matches = _dbContext.FEPs.Any(x => x.FepBvn == fepBVN);
            return Task.FromResult(matches);
        }

        public async Task<FEP> GetFEPByBvn(string fepBVN)
        {
            var matches = await _dbContext.FEPs.FirstOrDefaultAsync(x => x.FepBvn == fepBVN);
            return matches;
        }
    }
}
