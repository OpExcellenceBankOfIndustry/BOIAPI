using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login
{
    public class LoginQuery : IRequest<LoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
   
}
