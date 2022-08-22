using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship
{
    public class SoleProprietorshipCommandHandler : IRequestHandler<SoleProprietorshipCommand, SoleProprietorshipCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public SoleProprietorshipCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }
        public async Task<SoleProprietorshipCommandResponse> Handle(SoleProprietorshipCommand request, CancellationToken cancellationToken)
        {
            var validator = new SoleProprietorshipValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);
            var sRequest = _mapper.Map<SoleProprietorshipViewModel>(request);
            var res = await _accOpeningRepo.AddSoleProprietorship(sRequest);
            if (res == "Sole Proprietorship not saved successfully")
            {
                return new SoleProprietorshipCommandResponse
                {
                    Message = "Sole Proprietorship not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new SoleProprietorshipCommandResponse
                {
                    Message = "Sole Proprietorship saved successfully",
                    Success = true,
                };
            }
        }
    }
}
