using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.Influence
{
    public class IndividualWatchListRepository : BaseRepository<IndividualWatchList>, IIndividualWatchListRepository
    {
        public IndividualWatchListRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> DoesIndividualExist(string individualBvn)
        {
            var matches = _dbContext.IndividualWatchLists.Any(x => x.IndividualBvn == individualBvn);
            return Task.FromResult(matches);
        }

        public async Task<IndividualWatchList> GetIndividualByBvn(string individualBvn)
        {
            var matches = await _dbContext.IndividualWatchLists.FirstOrDefaultAsync(x => x.IndividualBvn == individualBvn);
            return matches;
        }
    }
}
