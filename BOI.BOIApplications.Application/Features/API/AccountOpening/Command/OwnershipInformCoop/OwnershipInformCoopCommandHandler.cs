using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop
{
    public class OwnershipInformCoopCommandHandler : IRequestHandler<OwnershipInformCoopCommand, OwnershipInformCoopCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public OwnershipInformCoopCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }

        public async Task<OwnershipInformCoopCommandResponse> Handle(OwnershipInformCoopCommand request, CancellationToken cancellationToken)
        {
           // var request = command._request;
            var validator = new OwnershipInformCoopValidators();           
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var sRequest = _mapper.Map<OwnershipInformCoopViewModel>(request);
            var res = await _accOpeningRepo.AddOwnershipInformCoop(sRequest);
            if (res == "Ownership Information Cooperate not saved successfully")
            {
                return new OwnershipInformCoopCommandResponse
                {
                    Message = "Ownership Information Cooperate not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new OwnershipInformCoopCommandResponse
                {
                    Message = "Ownership Information Cooperate saved successfully",
                    Success = true,
                };
            }
        }
    }
}
