using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN
{
    public class GetFEPsByBVNQueryHandler : IRequestHandler<GetFepsByBvnQuery, GetFEPsByBVNQueryResponse>
    {
        private readonly IFEPRepository _fEPRepository;
        private readonly IMapper _mapper;

        public GetFEPsByBVNQueryHandler(IFEPRepository fEPRepository, IMapper mapper)
        {
            _fEPRepository = fEPRepository;
            _mapper = mapper;
        }
        public async Task<GetFEPsByBVNQueryResponse> Handle(GetFepsByBvnQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFEPsByBVNValidator(_fEPRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var fepByBvn = await _fEPRepository.GetFEPByBvn(request.FepBvn);

            return new GetFEPsByBVNQueryResponse
            {
                Message = "Successful",
                Success = true,
                GetFEPsByBVNQueryViewModel = _mapper.Map<GetFEPsByBVNQueryViewModel>(fepByBvn)
            };
        }
    }
}
