using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAs
{
    public class GetAllLGAsQuery : IRequest<GetAllLGAsQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllStatesKeyBy";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
