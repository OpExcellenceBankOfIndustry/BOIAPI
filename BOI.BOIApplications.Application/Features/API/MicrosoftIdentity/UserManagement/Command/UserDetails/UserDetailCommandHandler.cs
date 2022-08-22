using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails
{
    public class UserDetailCommandHandler : IRequestHandler<UserDetailCommand, UserDetailCommandResponse>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserDetailCommandHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<UserDetailCommandResponse> Handle(UserDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserDetailValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

           
            var user = _mapper.Map<UserDetailViewModel>(request);
            var res = await _userManager.UserRegistration(user);
            var res2 = _mapper.Map<UserDetailViewModelRes>(res);
            if (res.ModelMessage == "User Creation Failed")
            {
                return new UserDetailCommandResponse
                {
                    Message = "User Registration Failed",
                    Success = false,
                    UserDetailViewModelRes = res2
                };
            }
            else if (res.ModelMessage == "Password and ConfirmPassword must be the same.")
            {
                return new UserDetailCommandResponse
                {
                    Message = "Password and ConfirmPassword must be the same.",
                    Success = false,
                    UserDetailViewModelRes = res2
                };
            }
            return new UserDetailCommandResponse
            {
                Message = "User Registered successfully",
                Success = true,
                UserDetailViewModelRes = res2
            };
        }
    }
}
