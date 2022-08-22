using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Influence
{
    public interface IIndividualWatchListRepository : IAsyncRepository<IndividualWatchList>
    {
        Task<IndividualWatchList> GetIndividualByBvn(string individualBvn);

        Task<bool> DoesIndividualExist(string individualBvn);
    }
}
