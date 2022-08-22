using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetAllCities
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, GetAllCitiesQueryResponse>
    {
        
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public GetAllCitiesQueryHandler(IMapper mapper,ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        public async Task<GetAllCitiesQueryResponse> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var cityLists = await _cityRepository.ListAllAsync();
            if (cityLists == null)
            {
                throw new NotFoundException("No City lists available", "GetAllCities");
            }

            return new GetAllCitiesQueryResponse
            {
                AllCities = _mapper.Map<List<GetAllCitiesQueryViewModel>>(cityLists)
            };
        }
    }
}
