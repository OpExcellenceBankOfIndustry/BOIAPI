using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetAllFEPs
{
    public class GetAllFEPQuery : IRequest<GetAllFEPQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllFEPsKey";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
