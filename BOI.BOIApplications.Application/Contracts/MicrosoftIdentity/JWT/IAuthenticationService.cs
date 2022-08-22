using BOI.BOIApplications.Application.Model.Identities;

namespace BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.JWT
{
    public interface IAuthenticationService
    {
        Task<TokenInformation> GetTokenInformation(string userName);
    }
}
