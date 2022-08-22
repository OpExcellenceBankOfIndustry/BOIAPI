using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin
{


    public class DetailsOfNextOfKinCommandResponse : BaseResponse
    {
        public DetailsOfNextOfKinCommandResponse() : base() { }
        public DetailsOfNextOfKinViewModel DetailsOfNextOfKinViewModel { get; set; }
    }
}
