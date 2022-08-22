using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command
{
    public class AuthenticateUserCommandResponse : BaseResponse
    {
        public AuthenticateUserCommandResponse() : base()
        {

        }

        public AuthenticateUserViewModel AuthenticateUserViewModel { get; set; }
    }
}
