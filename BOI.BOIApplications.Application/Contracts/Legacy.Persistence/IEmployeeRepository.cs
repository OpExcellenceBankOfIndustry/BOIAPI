using BOI.BOIApplications.Legacy.Domain.Entites;

namespace BOI.BOIApplications.Application.Contracts.Legacy.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Boiemployee>
    {
        Task<bool> DoesEmployeeExist(string staffid);
    }
}
