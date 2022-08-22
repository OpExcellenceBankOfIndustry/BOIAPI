using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin
{
    public class DetailsOfNextOfKinCommandHandler : IRequestHandler<DetailsOfNextOfKinCommand, DetailsOfNextOfKinCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public DetailsOfNextOfKinCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }

        public async Task<DetailsOfNextOfKinCommandResponse> Handle(DetailsOfNextOfKinCommand command, CancellationToken cancellationToken)
        {
            var request = command._request;
            var validator = new DetailsOfNextOfKinValidators();

            foreach (var item in request)
            {
                var validationResult = await validator.ValidateAsync(item, cancellationToken);
                if (validationResult.Errors.Count > 0)
                    throw new CustomValidationException(validationResult);

            }
            //var sRequest = _mapper.Map<DetailsOfNextOfKinViewModel>(request);
            var res = await _accOpeningRepo.AddDetailsOfNextOfKin(request);
            if (res == "Details Of Next Of Kin not saved successfully")
            {
                return new DetailsOfNextOfKinCommandResponse
                {
                    Message = "Details Of Next Of Kin not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new DetailsOfNextOfKinCommandResponse
                {
                    Message = "Details Of Next Of Kin saved successfully",
                    Success = true,
                };
            }
        }
    }
}
