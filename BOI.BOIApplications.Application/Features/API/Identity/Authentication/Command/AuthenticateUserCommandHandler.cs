using AutoMapper;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.JWT;
using BOI.BOIApplications.Application.Contracts.Persistence.Identity;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResponse>
    {
        private readonly IJWTCredentialRepository _iJWTCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _iauthenticationService;

        public AuthenticateUserCommandHandler(IJWTCredentialRepository iJWTCredentialRepository, IMapper mapper,
            IAuthenticationService iauthenticationService)
        {
            _iJWTCredentialRepository = iJWTCredentialRepository;
            _mapper = mapper;
            _iauthenticationService = iauthenticationService;
        }

        public async Task<AuthenticateUserCommandResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthenticateUserValidator(_iJWTCredentialRepository, _mapper);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var token = await _iauthenticationService.GetTokenInformation(request.UserName);

            return new AuthenticateUserCommandResponse
            {
                Message = "Success",
                Success = true,
                AuthenticateUserViewModel = _mapper.Map<AuthenticateUserViewModel>(token)
            };
        }
    }
}
