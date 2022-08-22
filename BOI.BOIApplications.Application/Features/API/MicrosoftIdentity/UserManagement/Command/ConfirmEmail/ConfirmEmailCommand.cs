using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<ConfirmEmailCommandResponse>
    {
        public string email { get; set; }
        public string code { get; set; }
    }
}
