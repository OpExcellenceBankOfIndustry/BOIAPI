using AutoMapper;
using BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetAllCities;
using BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA;
using BOI.BOIApplications.Application.Features.API.GeoInformation.Countries.Queries.GetAllCountries;
using BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAs;
using BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState;
using BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetAllStates;
using BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Profiles.API.GeoInformation
{
    internal class GeoInfoMappingProfiles : Profile
    {
        public GeoInfoMappingProfiles()
        {
            CreateMap<Country, GetAllCountriesVM>()
            .ReverseMap();

            CreateMap<State, GetAllStatesVM>()
            .ReverseMap();            
            
            CreateMap<State, GetStatesByCountryVM>()
            .ReverseMap();            
            
            CreateMap<LGA, GetAllLGAsVM>()
            .ReverseMap();            
            
            CreateMap<LGA, GetAllLGAsByStateVM>()
            .ReverseMap();

            CreateMap<City, GetAllCitiesQueryViewModel>()
           .ReverseMap();

            CreateMap<City, GetCitiesByLGAQueryViewModel>()
            .ReverseMap();
        }
    }
}
