using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Contracts.Persistence.Influence
{
    public interface IPEPRepository : IAsyncRepository<PEP>
    {
        Task<bool> DoesPEPExist(string fepBVN);

        Task<PEP> GetPEPByBvn(string fepBVN);
    }
}
