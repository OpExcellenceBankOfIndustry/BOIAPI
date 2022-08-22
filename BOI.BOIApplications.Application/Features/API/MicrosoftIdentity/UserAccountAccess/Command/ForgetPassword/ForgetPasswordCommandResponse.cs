using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword
{
    public class ForgetPasswordCommandResponse : BaseResponse
    {
        public ForgetPasswordCommandResponse() : base() { }
        public ForgetPasswordViewModel ForgetPasswordViewModel { get; set; }
    }
}
