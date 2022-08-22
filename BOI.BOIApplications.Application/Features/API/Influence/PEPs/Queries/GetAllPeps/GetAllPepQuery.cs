using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetAllPeps
{
    public class GetAllPepQuery : IRequest<GetAllPEPQueryResponse>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllPEPsKey";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
