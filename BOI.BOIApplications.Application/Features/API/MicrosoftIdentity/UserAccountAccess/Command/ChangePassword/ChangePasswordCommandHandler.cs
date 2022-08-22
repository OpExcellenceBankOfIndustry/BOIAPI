using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
    {
        private readonly IMapper _mapper;
        private IUserAccess _userAccess;

        public ChangePasswordCommandHandler(IMapper mapper, IUserAccess userAccess)
        {
            _mapper = mapper;
            _userAccess = userAccess;
        }
        public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangePasswordValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);


            var user = _mapper.Map<ChangePasswordViewModel>(request);
            var res = await _userAccess.ChangePassword(user);

            if (res.Message == "Unable to Reset User's Password")
            {
                return new ChangePasswordCommandResponse
                {
                    Message = res.Message,
                    Success = false,
                    ChangePasswordViewModel = res
                };
            }else if (res.Message == "Password and ConfirmPassword must be the same.")
            {
                return new ChangePasswordCommandResponse
                {
                    Message = res.Message,
                    Success = false,
                    ChangePasswordViewModel = res
                };
            }
            else if(res.Message == "Old and New Password cannot be the same.")
            {
                return new ChangePasswordCommandResponse
                {
                    Message = res.Message,
                    Success = false,
                    ChangePasswordViewModel = res
                };
            }
            return new ChangePasswordCommandResponse
            {
                Message = "Password Changed successfully",
                Success = true,
                ChangePasswordViewModel = res
            };
        }
    }
}
