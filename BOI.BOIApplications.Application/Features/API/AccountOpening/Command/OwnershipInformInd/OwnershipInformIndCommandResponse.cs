using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd
{

    public class OwnershipInformIndCommandResponse : BaseResponse
    {
        public OwnershipInformIndCommandResponse() : base() { }
        public OwnershipInformIndViewModel OwnershipInformIndViewModel { get; set; }
    }
}
