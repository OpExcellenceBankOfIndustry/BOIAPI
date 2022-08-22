using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetAllIndividualWatchLists
{
    public class GetAllIndividualWatchListsQuery : IRequest<GetAllIndividualWatchListsQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllIndividualWatchListsKey";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
