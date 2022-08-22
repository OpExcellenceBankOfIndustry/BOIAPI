using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, GetAllCountriesQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetAllCountriesQueryHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        public async Task<GetAllCountriesQueryResponse> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countryLists = await _countryRepository.ListAllAsync();
            if (countryLists == null)
            {
                throw new NotFoundException("No Country lists available", "GetAllCountries");
            }

            return new GetAllCountriesQueryResponse
            {
                AllCountries = _mapper.Map<List<GetAllCountriesVM>>(countryLists)
            };
        }
    }
}
