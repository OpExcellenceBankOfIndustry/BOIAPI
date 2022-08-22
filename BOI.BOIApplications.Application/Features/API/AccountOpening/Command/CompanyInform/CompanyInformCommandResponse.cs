using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform
{
    public class CompanyInformCommandResponse : BaseResponse
    {
        public CompanyInformCommandResponse() : base() { }
        public string? RefNumber { get; set; }
        public CompanyInformViewModel CompanyInformViewModel { get; set; }
    }
}
