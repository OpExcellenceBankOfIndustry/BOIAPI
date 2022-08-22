using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.GeoInformation
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Country> GetCountryWithStates(int countryId)
        {
            return await _dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(x => x.id == countryId);
        }

        public Task<bool> DoesCountryExist(int countryId)
        {
            var matches = _dbContext.Countries.Any(x => x.id == countryId);
            return Task.FromResult(matches);
        }
    }
}
