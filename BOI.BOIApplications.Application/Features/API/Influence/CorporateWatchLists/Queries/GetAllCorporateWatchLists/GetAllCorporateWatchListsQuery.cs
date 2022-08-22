using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetAllCorporateWatchLists
{
    public class GetAllCorporateWatchListsQuery : IRequest<GetAllCorporateWatchListsQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllCoporateWatchListsKey";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
