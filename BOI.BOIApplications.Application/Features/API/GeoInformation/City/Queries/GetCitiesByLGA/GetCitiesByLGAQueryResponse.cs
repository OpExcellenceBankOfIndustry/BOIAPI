using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA
{
    public class GetCitiesByLGAQueryResponse
    {
        public string? LGAName { get; set; }
        public List<GetCitiesByLGAQueryViewModel> AllCities { get; set; }

    }
}
