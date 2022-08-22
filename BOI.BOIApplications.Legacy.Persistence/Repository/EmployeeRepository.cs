using BOI.BOIApplications.Application.Contracts.Legacy.Persistence;
using BOI.BOIApplications.Legacy.Domain.Entites;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Legacy.Persistence.Repository
{
    public class EmployeeRepository : BaseRepository<Boiemployee>, IEmployeeRepository
    {
        public EmployeeRepository(Bonita_bdmContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> DoesEmployeeExist(string staffid)
        {
            var matches = _dbContext.Boiemployees.Any(e => e.Employeeid.ToLower() == staffid.Trim().ToLower());
            return Task.FromResult(matches);
        }
    }
}
