using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Identity;
using BOI.BOIApplications.Domain.Entities;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
    {
        private readonly IJWTCredentialRepository _iJWTCredentialRepository;
        private readonly IMapper _mapper;

        public AuthenticateUserValidator(IJWTCredentialRepository iJWTCredentialRepository, IMapper mapper)
        {
            _iJWTCredentialRepository = iJWTCredentialRepository;
            _mapper = mapper;

            RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Channel)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e)
            .MustAsync(DoesUsersExist)
            .WithMessage("User does not exist based on the supplied record.");

        }

        private async Task<bool> DoesUsersExist(AuthenticateUserCommand e, CancellationToken token)
        {
            return await _iJWTCredentialRepository.DoesUserExist(_mapper.Map<JWTCredential>(e));
        }
    }
}
