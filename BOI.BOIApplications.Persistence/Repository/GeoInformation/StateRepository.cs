using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence.Repository.GeoInformation
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<List<State>> GetAllStates()
        {
            try
            {
                var state = await _dbContext.States.Select(x => new State() { id = x.id, name = x.name.Trim() }).OrderBy(e => e.id).ToListAsync();
                return state;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<State> GetStatesWithLGAs2(int stateID)
        {
            return await _dbContext.States.Include(x => x.LocalGovtArea).FirstOrDefaultAsync(x => x.id == stateID);
        }
        public async Task<List<LGA>> GetStatesWithLGAs(int stateID)
        {
            var dt = await _dbContext.LocalGovtArea.Where(x => x.StateId == stateID).OrderBy(e => e.name).ToListAsync();
            return dt;
            //return await _dbContext.LocalGovtArea.Select(x => new LGA() { id = x.id, name = x.name.Trim() }).Where(x => x.StateId == stateID).OrderBy(e => e.name).ToListAsync();

        }

        public Task<bool> DoesStateExist(int stateId)
        {
            var matches = _dbContext.States.Any(x => x.id == stateId);
            return Task.FromResult(matches);
        }
    }
}
