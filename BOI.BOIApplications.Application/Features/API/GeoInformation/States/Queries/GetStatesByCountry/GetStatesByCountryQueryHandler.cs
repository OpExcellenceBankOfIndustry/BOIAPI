using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry
{
    public class GetStatesByCountryQueryHandler : IRequestHandler<GetStatesByCountryQuery, GetStatesByCountryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetStatesByCountryQueryHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<GetStatesByCountryQueryResponse> Handle(GetStatesByCountryQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetStatesByCountryQueryValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var countryStatesLists = await _countryRepository.GetCountryWithStates(request.CountryId);
            if (!countryStatesLists.States.Any())
            {
                throw new NotFoundException("No state lists for Country id supplied", $"{request.CountryId}");
            }


            return new GetStatesByCountryQueryResponse
            {
                CountryName = countryStatesLists.name,
                AllStates = _mapper.Map<List<GetStatesByCountryVM>>(countryStatesLists.States)
            };
        }
    }
}
