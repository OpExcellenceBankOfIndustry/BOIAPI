using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN
{
    public class GetPEPByBVNQueryHandler : IRequestHandler<GetPEPByBVNQuery, GetPEPByBVNQueryResponse>
    {
        private readonly IPEPRepository _pEPRepository;
        private readonly IMapper _mapper;

        public GetPEPByBVNQueryHandler(IPEPRepository pEPRepository, IMapper mapper)
        {
            _pEPRepository = pEPRepository;
            _mapper = mapper;
        }

        public async Task<GetPEPByBVNQueryResponse> Handle(GetPEPByBVNQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPEPByBVNValidator(_pEPRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var pepByBvn = await _pEPRepository.GetPEPByBvn(request.PepBvn);

            return new GetPEPByBVNQueryResponse
            {
                Message = "Successful",
                Success = true,
                GetPEPByBVNQueryViewModel = _mapper.Map<GetPEPByBVNQueryViewModel>(pepByBvn)
            };
        }
    }
}
