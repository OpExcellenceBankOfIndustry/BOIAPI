using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence.InterfaceRepository
{
    public interface IAuthRepository
    {
        Task<JWTCredential> GetJWTUser(AuthenticateRequest authenticateRequest);
    }
}
