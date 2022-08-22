using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation
{
    public interface ICountryRepository : IAsyncRepository<Country>
    {
        Task<Country> GetCountryWithStates(int countryId);
        Task<bool> DoesCountryExist(int countryId);
    }
}
