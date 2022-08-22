using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Comamnd.AddPEPs
{
    public class AddPEPCommandHandler : IRequestHandler<AddPEPCommand, AddPEPCommandResponse>
    {
        private readonly IPEPRepository _pEPRepository;
        private readonly IMapper _mapper;

        public AddPEPCommandHandler(IPEPRepository pEPRepository, IMapper mapper)
        {
            _pEPRepository = pEPRepository;
            _mapper = mapper;
        }

        public async Task<AddPEPCommandResponse> Handle(AddPEPCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddPEPValidator(_pEPRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var insertPEP = await _pEPRepository.AddAsync(_mapper.Map<PEP>(request));

            return new AddPEPCommandResponse
            {
                Message = "Politically exposed person successfully added",
                Success = true,
                AddPEPCommandViewModel = _mapper.Map<AddPEPCommandViewModel>(insertPEP)
            };
        }
    }
}
