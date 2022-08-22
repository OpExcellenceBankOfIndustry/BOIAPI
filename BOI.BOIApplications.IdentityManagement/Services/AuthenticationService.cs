using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.JWT;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Application.Model.Identities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BOI.BOIApplications.IdentityManagement.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public Task<TokenInformation> GetTokenInformation(string userName)
        {
            var expiryPeriod = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTime);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Username", userName.Trim().ToString()),
                }),
                Expires = expiryPeriod,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return Task.FromResult(new TokenInformation
            {
                BearerToken = token,
                ExpiryPeriod = expiryPeriod
            });

        }

    }
}
