using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation
{
    public interface ICityRepository : IAsyncRepository<City>
    {
        Task<List<City>> GetAllCities();
        Task<LGA> GetCitiesByLGAId2(int LGAId);
        Task<List<City>> GetCitiesByLGAId(int LGAId);
        Task<bool> DoesCityExist(int cityId);
    }
}
