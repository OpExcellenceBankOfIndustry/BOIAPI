using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails
{
    public class UserDetailCommandResponse : BaseResponse
    {
        public UserDetailCommandResponse(): base(){}

        public UserDetailViewModelRes UserDetailViewModelRes { get; set; }
    }
}
