using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry
{
    public class GetStatesByCountryQuery : IRequest<GetStatesByCountryQueryResponse>, ICacheableMediatrQuery
    {
        public int CountryId { get; set; }
        public bool BypassCache { get; set; }

        public string CacheKey => $"GetAllCountriesKeyByID{CountryId}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
