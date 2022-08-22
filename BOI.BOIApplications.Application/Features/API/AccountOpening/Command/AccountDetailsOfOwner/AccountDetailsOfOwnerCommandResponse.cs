using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner
{
    public class AccountDetailsOfOwnerCommandResponse : BaseResponse
    {
        public AccountDetailsOfOwnerCommandResponse() : base() { }
        public AccountDetailsOfOwnerViewModel AccountDetailsOfOwnerViewModel { get; set; }
    }
}
