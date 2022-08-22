using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence.Repository.Influence
{
    public class CorporateWatchListRepository : BaseRepository<CorporateWatchList>, ICorporateWatchListRepository
    {
        public CorporateWatchListRepository(BOIDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> DoesCompanyExist(string companyRegistrationNumber)
        {
            var matches = _dbContext.CorporateWatchLists.Any(x => x.CompanyRegistrationNumber == companyRegistrationNumber);
            return Task.FromResult(matches);
        }

        public async Task<CorporateWatchList> GetCompanyByRegistrationNumber(string companyRegistrationNumber)
        {
            var matches = await _dbContext.CorporateWatchLists.FirstOrDefaultAsync(x => x.CompanyRegistrationNumber == companyRegistrationNumber);
            return matches;
        }
    }
}
