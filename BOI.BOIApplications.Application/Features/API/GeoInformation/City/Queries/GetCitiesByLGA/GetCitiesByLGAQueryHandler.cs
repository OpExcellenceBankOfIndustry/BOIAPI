using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA
{
    public class GetCitiesByLGAQueryHandler : IRequestHandler<GetCitiesByLGAQuery, GetCitiesByLGAQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public GetCitiesByLGAQueryHandler(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<GetCitiesByLGAQueryResponse> Handle(GetCitiesByLGAQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCitiesByLGAQueryValidator(_cityRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var countryCitiesLists = await _cityRepository.GetCitiesByLGAId2(request.LGAId);
            if (!countryCitiesLists.City.Any())
            {
                throw new NotFoundException("No City lists for LGA id supplied", $"{request.LGAId}");
            }
            return new GetCitiesByLGAQueryResponse
            {
                LGAName = countryCitiesLists.name,
                AllCities = _mapper.Map<List<GetCitiesByLGAQueryViewModel>>(countryCitiesLists.City)
            };



        }
    }
}
