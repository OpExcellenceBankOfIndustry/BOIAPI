using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetAllStates
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, GetAllStatesQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public GetAllStatesQueryHandler(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<GetAllStatesQueryResponse> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            var stateLists = await _stateRepository.GetAllStates();
            if (stateLists == null)
            {
                throw new NotFoundException("No state lists available", "GetAllStates");
            }

            return new GetAllStatesQueryResponse
            {
                AllStates = _mapper.Map<List<GetAllStatesVM>>(stateLists)
            };
        }
    }
}
