using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<GetAllCountriesQueryResponse>, ICacheableMediatrQuery
    {

        public bool BypassCache { get; set; }

        public string CacheKey => "GetAllCountriesKeyBy";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
