using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs
{
    public class FEPCommandResponse : BaseResponse
    {
        public FEPCommandResponse() : base()
        {

        }

        public FEPCommandViewModel FEPCommandViewModel { get; set; }
    }
}
