using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword
{
    public class ForgetPasswordCommand : IRequest<ForgetPasswordCommandResponse>
    {
        public string Email { get; set; }
    }
}
