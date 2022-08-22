using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship
{

    public class SoleProprietorshipCommandResponse : BaseResponse
    {
        public SoleProprietorshipCommandResponse() : base() { }
        public SoleProprietorshipViewModel SoleProprietorshipViewModel { get; set; }
    }
}
