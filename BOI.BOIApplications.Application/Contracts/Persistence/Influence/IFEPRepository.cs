using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Influence
{
    public interface IFEPRepository : IAsyncRepository<FEP>
    {
        Task<bool> DoesFEPExist(string fepBVN);

        Task<FEP> GetFEPByBvn(string fepBVN);
    }
}
