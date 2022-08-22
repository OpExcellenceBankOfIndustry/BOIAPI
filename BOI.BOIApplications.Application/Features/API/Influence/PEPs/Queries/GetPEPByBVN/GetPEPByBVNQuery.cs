using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN
{
    public class GetPEPByBVNQuery : IRequest<GetPEPByBVNQueryResponse>
    {
        public string? PepBvn { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"GetAllPEPsKeyBy{PepBvn}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
