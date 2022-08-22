using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetAllStates
{
    public class GetAllStatesQuery : IRequest<GetAllStatesQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllStatesKeyBy";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
