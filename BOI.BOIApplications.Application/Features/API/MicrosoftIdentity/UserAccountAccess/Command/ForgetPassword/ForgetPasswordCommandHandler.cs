using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword
{
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, ForgetPasswordCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAccess _userAccess;

        public ForgetPasswordCommandHandler(IMapper mapper, IUserAccess userAccess)
        {
            _mapper = mapper;
            _userAccess = userAccess;
        }
        public async Task<ForgetPasswordCommandResponse> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ForgetPasswordValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);


            var user = _mapper.Map<ForgetPasswordViewModel>(request);
            var res = await _userAccess.ForgetPassword(user);

            if (res.ErrorMessage == "User Login Failed")
            {
                return new ForgetPasswordCommandResponse
                {
                    Message = "UserName or Password InCorrect",
                    Success = false,
                    ForgetPasswordViewModel = res
                };
            }
            return new ForgetPasswordCommandResponse
            {
                Message = "Password Reset Successfully",
                Success = true,
                ForgetPasswordViewModel = res
            };
        }
    }
    }

