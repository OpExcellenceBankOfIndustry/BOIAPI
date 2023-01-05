using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(JWTCredential jwtCredential);
    }
}
