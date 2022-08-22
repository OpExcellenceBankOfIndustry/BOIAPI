using AutoMapper;
using BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command;
using BOI.BOIApplications.Application.Model.Identities;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Profiles.API.Authentication
{
    public class AuthenticationMappingProfiles : Profile
    {
        public AuthenticationMappingProfiles()
        {

            CreateMap<JWTCredential, AuthenticateUserCommand>()
                .ReverseMap();

            CreateMap<AuthenticateUserViewModel, TokenInformation>()
                .ReverseMap();
        }
    }
}
