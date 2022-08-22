using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform
{
    public class RelatedPartyInformCommandResponse : BaseResponse
    {
        public RelatedPartyInformCommandResponse() : base() { }
        public RelatedPartyInformViewModel RelatedPartyInformViewModel { get; set; }
    }
}
