using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetAllPeps
{
    public class GetAllPEPQueryHandler : IRequestHandler<GetAllPepQuery, GetAllPEPQueryResponse>
    {
        private readonly IPEPRepository _pEPRepository;
        private readonly IMapper _mapper;

        public GetAllPEPQueryHandler(IPEPRepository pEPRepository, IMapper mapper)
        {
            _pEPRepository = pEPRepository;
            _mapper = mapper;
        }
        public async Task<GetAllPEPQueryResponse> Handle(GetAllPepQuery request, CancellationToken cancellationToken)
        {
            var allpeps = await _pEPRepository.ListAllAsync();
            return new GetAllPEPQueryResponse
            {
                Message = "Successful",
                Success = true,
                AllPEPs = _mapper.Map<List<GetAllPEPQueryViewModel>>(allpeps)
            };
        }
    }
}
