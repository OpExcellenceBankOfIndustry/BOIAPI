using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN
{
    public class GetIndividualWatchListsByBVNQuery : IRequest<GetIndividualWatchListsByBVNResponse>, ICacheableMediatrQuery
    {
        public string? IndividualBvn { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"GetIndividualWatchListsBy{IndividualBvn}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
