using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner
{
    public class AccountDetailsOfOwnerCommandHandler : IRequestHandler<AccountDetailsOfOwnerCommand, AccountDetailsOfOwnerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountOpeningRepository _accOpeningRepo;

        public AccountDetailsOfOwnerCommandHandler(IMapper mapper, IAccountOpeningRepository accOpeningRepo)
        {
            _mapper = mapper;
            _accOpeningRepo = accOpeningRepo;
        }

        public async Task<AccountDetailsOfOwnerCommandResponse> Handle(AccountDetailsOfOwnerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var request = command._request;
                var validator = new AccountDetailsOfOwnerValidators();

                foreach (var item in request)
                {
                    var validationResult = await validator.ValidateAsync(item, cancellationToken);
                    if (validationResult.Errors.Count > 0)
                        throw new CustomValidationException(validationResult);
                }

                // sRequest = _mapper.Map<AccountDetailsOfOwnerViewModel>(request);
                var res = await _accOpeningRepo.AddAccountDetailsOfOwner(request);
                if (res == "Account Details Of Owner not saved successfully")
                {
                    return new AccountDetailsOfOwnerCommandResponse
                    {
                        Message = "Account Details Of Owner not saved successfully",
                        Success = false,
                    };
                }
                else
                {
                    return new AccountDetailsOfOwnerCommandResponse
                    {
                        Message = "Account Details Of Owner saved successfully",
                        Success = true,
                    };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
