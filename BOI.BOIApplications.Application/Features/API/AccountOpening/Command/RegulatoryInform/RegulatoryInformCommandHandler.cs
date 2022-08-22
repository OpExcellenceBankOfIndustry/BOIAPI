using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform
{
    public class RegulatoryInformCommandHandler : IRequestHandler<RegulatoryInformCommand, RegulatoryInformCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;
        public RegulatoryInformCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;

        }

        public async Task<RegulatoryInformCommandResponse> Handle(RegulatoryInformCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegulatoryInformValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);
            var sRequest = _mapper.Map<RegulatoryInformViewModel>(request);
            var res = await _accOpeningRepo.AddRegulatoryInform(sRequest);
            if (res == "Regulatory Information not saved successfully")
            {
                return new RegulatoryInformCommandResponse
                {
                    Message = "Regulatory Information not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new RegulatoryInformCommandResponse
                {
                    Message = "Regulatory Information saved successfully",
                    Success = true,
                };
            }
        }
    }
}
