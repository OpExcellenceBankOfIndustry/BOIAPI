using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs
{
    internal class FEPCommandHandler : IRequestHandler<FEPCommand, FEPCommandResponse>
    {
        private readonly IFEPRepository _fEPRepository;
        private readonly IMapper _mapper;

        public FEPCommandHandler(IFEPRepository fEPRepository, IMapper mapper)
        {
            _fEPRepository = fEPRepository;
            _mapper = mapper;
        }
        public async Task<FEPCommandResponse> Handle(FEPCommand request, CancellationToken cancellationToken)
        {
            var validator = new FEPValidator(_fEPRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var insertFEP = await _fEPRepository.AddAsync(_mapper.Map<FEP>(request));

            return new FEPCommandResponse
            {
                Message = "New Financially exposed persons added",
                Success = true,
                FEPCommandViewModel = _mapper.Map<FEPCommandViewModel>(insertFEP),
            };
        }
    }
}
