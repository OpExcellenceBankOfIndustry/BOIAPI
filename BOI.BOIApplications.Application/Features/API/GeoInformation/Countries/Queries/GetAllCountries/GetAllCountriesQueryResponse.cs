using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQueryResponse
    {
        public List<GetAllCountriesVM>? AllCountries { get; set; }
    }
}
