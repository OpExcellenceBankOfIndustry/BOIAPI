using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd
{
    public class OwnershipInformIndCommandHandler : IRequestHandler<OwnershipInformIndCommand, OwnershipInformIndCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public OwnershipInformIndCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }

        public async Task<OwnershipInformIndCommandResponse> Handle(OwnershipInformIndCommand request, CancellationToken cancellationToken)
        {
            var validator = new OwnershipInformIndValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);
            var sRequest = _mapper.Map<OwnershipInformIndViewModel>(request);
            var res = await _accOpeningRepo.AddOwnershipInformInd(sRequest);
            if (res == "Ownership Information Individual not saved successfully")
            {
                return new OwnershipInformIndCommandResponse
                {
                    Message = "Ownership Information Individual not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new OwnershipInformIndCommandResponse
                {
                    Message = "Ownership Information Individual saved successfully",
                    Success = true,
                };
            }
        }
    }
}
