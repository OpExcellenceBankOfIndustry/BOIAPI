using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetAllFEPs
{
    public class GetAllFEPQueryHandler : IRequestHandler<GetAllFEPQuery, GetAllFEPQueryResponse>
    {
        private readonly IFEPRepository _fEPRepository;
        private readonly IMapper _mapper;

        public GetAllFEPQueryHandler(IFEPRepository fEPRepository, IMapper mapper)
        {
            _fEPRepository = fEPRepository;
            _mapper = mapper;
        }

        public async Task<GetAllFEPQueryResponse> Handle(GetAllFEPQuery request, CancellationToken cancellationToken)
        {
            var allFeps = await _fEPRepository.ListAllAsync();
            return new GetAllFEPQueryResponse
            {
                Message = "Successful",
                Success = true,
                FEPQueryViewModel = _mapper.Map<List<GetAllFEPQueryViewModel>>(allFeps)
            };
        }
    }
}
