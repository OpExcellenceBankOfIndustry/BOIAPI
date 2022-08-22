using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail
{
    public class ConfirmEmailCommandResponse : BaseResponse
    {
        public ConfirmEmailCommandResponse() : base() { }
        public ConfirmEmailViewModel ConfirmEmailViewModel { get; set; }

    }

}
