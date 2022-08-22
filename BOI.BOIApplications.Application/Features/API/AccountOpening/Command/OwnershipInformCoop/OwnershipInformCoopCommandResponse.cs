using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop
{

    public class OwnershipInformCoopCommandResponse : BaseResponse
    {
        public OwnershipInformCoopCommandResponse() : base() { }
        public OwnershipInformCoopViewModel OwnershipInformCoopViewModel { get; set; }
    }
}
