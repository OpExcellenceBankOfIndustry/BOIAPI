using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery,LoginQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAccess _userAccess;

        public LoginQueryHandler(IMapper mapper,IUserAccess userAccess)
        {
            _mapper = mapper;
            _userAccess = userAccess;
        }

        public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var validator = new LoginValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);


            var user = _mapper.Map<LoginViewModel>(request);
            var res = await _userAccess.Login(user);

            if(res.ErrorMessage == "User Login Failed")
            {
                return new LoginQueryResponse
                {
                    Message = "UserName or Password In Correct",
                    Success = false,
                    UserDetail = res
                };
            }
            return new LoginQueryResponse
            {
                Message = "User Logged In successfully",
                Success = true,
                UserDetail = res
            };
        }
    }
}
