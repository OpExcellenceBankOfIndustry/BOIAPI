using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg
{
    public class GetCorporateWatchListByCompanyRegQuery : IRequest<GetCorporateWatchListByCompanyRegQueryResponse>, ICacheableMediatrQuery
    {
        public string? CompanyRegistrationNumber { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"GetCorporateWatchListBy{CompanyRegistrationNumber}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
