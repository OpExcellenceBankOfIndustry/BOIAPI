using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Influence
{
    public interface ICorporateWatchListRepository : IAsyncRepository<CorporateWatchList>
    {
        Task<bool> DoesCompanyExist(string companyRegistrationNumber);

        Task<CorporateWatchList> GetCompanyByRegistrationNumber(string companyRegistrationNumber);
    }
}
