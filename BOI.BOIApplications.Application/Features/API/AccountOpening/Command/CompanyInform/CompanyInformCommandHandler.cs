using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform
{
    public class CompanyInformCommandHandler : IRequestHandler<CompanyInformCommand, CompanyInformCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public CompanyInformCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }
        public async Task<CompanyInformCommandResponse> Handle(CompanyInformCommand request, CancellationToken cancellationToken)
        {
            var validator = new CompanyInformValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);
            var sRequest = _mapper.Map<CompanyInformViewModel>(request);
            var res = await _accOpeningRepo.AddCompanyInform(sRequest);
            return res;           
        }
    }
}
