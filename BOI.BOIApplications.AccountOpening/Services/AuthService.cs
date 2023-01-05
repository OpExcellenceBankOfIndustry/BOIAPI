using BOI.BOIApplications.AccountOpening.Interfaces;
using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Persistence.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<JWTCredential> AuthenticateAsync(AuthenticateRequest authenticateRequest)
        {
            var user = await _authRepository.GetJWTUser(authenticateRequest);

            if (user == null) return null;

            user.Role = user.Channel;
            user.Password = null;
            return user;
        }
    }
}
