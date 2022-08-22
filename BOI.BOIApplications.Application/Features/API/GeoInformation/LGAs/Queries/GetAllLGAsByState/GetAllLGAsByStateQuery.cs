using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState
{
    public class GetAllLGAsByStateQuery : IRequest<GetAllLGAsByStateQueryResponse>, ICacheableMediatrQuery
    {
        public int StateId { get; set; }
        public bool BypassCache { get; set; }

        public string CacheKey => $"GetAllLGAsKeyByID{StateId}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
