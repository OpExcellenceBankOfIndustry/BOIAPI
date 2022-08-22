using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState
{
    public class GetAllLGAsByStateQueryHandler : IRequestHandler<GetAllLGAsByStateQuery, GetAllLGAsByStateQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public GetAllLGAsByStateQueryHandler(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<GetAllLGAsByStateQueryResponse> Handle(GetAllLGAsByStateQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllLGAsByStateValidator(_stateRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var statesWithLGAsLists = await _stateRepository.GetStatesWithLGAs2(request.StateId);
            if (!statesWithLGAsLists.LocalGovtArea.Any())
            {
                throw new NotFoundException("No LGA lists for state id supplied", $"{request.StateId}");
            }


            return new GetAllLGAsByStateQueryResponse
            {
                StateName = statesWithLGAsLists.name,
                AllLgas = _mapper.Map<List<GetAllLGAsByStateVM>>(statesWithLGAsLists.LocalGovtArea)
            };
        }
    }
}
