using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Persistence.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence.ServiceRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BOIDbContext _boiDbContext;

        public AuthRepository(BOIDbContext boiDbContext)
        {
            _boiDbContext = boiDbContext;
        }

        public async Task<JWTCredential> GetJWTUser(AuthenticateRequest authenticateRequest)
        {
            var user = await _boiDbContext.JWTCredentials.Where(x => x.UserName.ToLower() == authenticateRequest.EmailOrUserName.ToLower() && x.Password == authenticateRequest.Password).FirstOrDefaultAsync();
            
            if (user == null) return null;
            return user;
        }
    }
}
