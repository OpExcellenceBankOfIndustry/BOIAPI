using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ConfirmEmailCommandResponse>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public ConfirmEmailCommandHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task<ConfirmEmailCommandResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var validator = new ConfirmEmailValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);


            var user = _mapper.Map<ConfirmEmailViewModel>(request);
            var res = await _userManager.ConfirmEmail(user.email,user.code);
            if (!res)
            {
                return new ConfirmEmailCommandResponse
                {
                    Message = "User Email Confirmation Failed",
                    Success = false,
                };
            }
            return new ConfirmEmailCommandResponse
            {
                Message = "Successful Email Confirmation",
                Success = true,
            };
        }
    }
}
