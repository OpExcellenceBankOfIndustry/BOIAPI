using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform
{
    public class RelatedPartyInformCommandHandler : IRequestHandler<RelatedPartyInformCommand, RelatedPartyInformCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public RelatedPartyInformCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }
        public async Task<RelatedPartyInformCommandResponse> Handle(RelatedPartyInformCommand request, CancellationToken cancellationToken)
        {
            var validator = new RelatedPartyInformValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);
            var sRequest = _mapper.Map<RelatedPartyInformViewModel>(request);
            var res = await _accOpeningRepo.AddRelatedPartyInform(sRequest);
            if (res == "Related Party Information not saved successfully")
            {
                return new RelatedPartyInformCommandResponse
                {
                    Message = "Related Party Information not saved successfully",
                    Success = false,
                };
            }
            else
            {
                return new RelatedPartyInformCommandResponse
                {
                    Message = "Related Party Information saved successfully",
                    Success = true,
                };
            }
        }
    }
}
