using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform
{
    public class CompanyInformCommand : IRequest<CompanyInformCommandResponse>
    {
        public long UserId { get; set; }
        //public string? UserIdString { get; }
        public string? UserEmail { get; set; }
        [JsonIgnore]
        //public string? RefNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyShortName { get; set; }
        public string? CompanyType { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Landmark { get; set; }
        public string? State { get; set; }
        public string? LGA { get; set; }
        public string? TownCity { get; set; }

        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? CompanyOwnsBusinessPremises { get; set; }
        //public string? ProofOfCompanyAddress { get; set; }
        public IFormFile ProofOfCompanyAddress { get; set; }
    }
}
