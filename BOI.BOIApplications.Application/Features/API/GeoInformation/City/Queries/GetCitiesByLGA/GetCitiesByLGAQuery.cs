using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA
{
    public class GetCitiesByLGAQuery : IRequest<GetCitiesByLGAQueryResponse>, ICacheableMediatrQuery
    {
        public int LGAId { get; set; }
        //public int CityId { get; set; }
        //public string? CityName { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public bool BypassCache { get; set; }

        public string CacheKey => $"GetAllCitiesKeyByID{LGAId}";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
