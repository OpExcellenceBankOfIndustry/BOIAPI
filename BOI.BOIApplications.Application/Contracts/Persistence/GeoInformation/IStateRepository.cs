using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation
{
    public interface IStateRepository : IAsyncRepository<State>
    {
        Task<List<State>> GetAllStates();
        Task<State> GetStatesWithLGAs2(int stateID);
        Task<List<LGA>> GetStatesWithLGAs(int stateID);
        Task<bool> DoesStateExist(int stateId);

    }
}
