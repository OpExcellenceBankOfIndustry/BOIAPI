using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword
{
    public class ChangePasswordCommandResponse : BaseResponse
    {
        public ChangePasswordCommandResponse() : base() { }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }
}
