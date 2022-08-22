using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform
{
    public class RegulatoryInformCommandResponse : BaseResponse
    {
        public RegulatoryInformCommandResponse() : base() { }
        public RegulatoryInformViewModel RegulatoryInformViewModel { get; set; }
    }
}
