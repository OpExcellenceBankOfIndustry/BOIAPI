using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command
{
    public class AuthenticateUserCommand : IRequest<AuthenticateUserCommandResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Channel { get; set; }
    }
}
