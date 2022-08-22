using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ChangePasswordCommandResponse>
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
       
        public string NewPassword { get; set; }
       
        public string ConfirmPassword { get; set; }
    }
}
