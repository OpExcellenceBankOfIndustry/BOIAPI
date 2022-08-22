using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetAllCities
{
    public class GetAllCitiesQueryResponse
    {
        public List<GetAllCitiesQueryViewModel> AllCities { get; set; }
    }
}
