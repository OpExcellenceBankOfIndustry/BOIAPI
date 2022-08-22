using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.GeoInformation
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<City>> GetAllCities()
        {
            return await _dbContext.City.ToListAsync();
        }
        public async Task<LGA> GetCitiesByLGAId2(int LGAId)
        {
            return await _dbContext.LocalGovtArea.Include(x => x.City).FirstOrDefaultAsync(x => x.id == LGAId);
        }

        public async Task<List<City>> GetCitiesByLGAId(int LGAId)
        {
            var dt = await _dbContext.City.Where(x => x.LGAId == LGAId).OrderBy(e => e.name).ToListAsync();
            return dt;
            //return await _dbContext.City.Select(x => new City() { id = x.id, name = x.name.Trim() }).Where(x => x.LGAId == LGAId).OrderBy(e => e.name).ToListAsync();

        }
        public Task<bool> DoesCityExist(int cityId)
        {
            var matches = _dbContext.City.Any(x => x.id == cityId);
            return Task.FromResult(matches);
        }
    }

}
