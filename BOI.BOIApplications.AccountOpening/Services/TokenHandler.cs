using BOI.BOIApplications.AccountOpening.Interfaces;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly JWTSettings _jwtSettings;

        public TokenHandler(IOptions<JWTSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public async Task<string> CreateTokenAsync(JWTCredential jwtCredential)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, jwtCredential.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, jwtCredential.Channel));

            claims.Add(new Claim(ClaimTypes.Role, jwtCredential.Role));

            //If multiple then loop into roles of users
            //jwtCredential.Role.ForEach (role) =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //});

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryTime),
                signingCredentials: credentials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
