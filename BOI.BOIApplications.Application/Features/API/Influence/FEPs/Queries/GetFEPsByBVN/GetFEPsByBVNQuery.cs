using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN
{
    public class GetFepsByBvnQuery : IRequest<GetFEPsByBVNQueryResponse>, ICacheableMediatrQuery
    {
        public string? FepBvn { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"GetAllFEPsKeyBy{FepBvn}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
