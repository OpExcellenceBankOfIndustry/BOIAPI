using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Persistence.Repository.GeoInformation
{
    public class LGARepository : BaseRepository<LGA>, ILGARepository
    {
        public LGARepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

    }
}
