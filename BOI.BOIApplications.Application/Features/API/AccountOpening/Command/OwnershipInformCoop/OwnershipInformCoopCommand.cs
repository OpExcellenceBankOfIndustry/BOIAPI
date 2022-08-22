using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop
{
    public class OwnershipInformCoopCommand : IRequest<OwnershipInformCoopCommandResponse>
    {
        //public List<OwnershipInformCoopViewModel> _request { get; set; }
        //public ownershipinformcoopcommand(list<ownershipinformcoopviewmodel> request)
        //{
        //    _request = request;
        //}
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RefNumber { get; set; }
        public string? NameOfShareholdingCompany { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? PercentageOwnership { get; set; }
        public string? State { get; set; }
        public string? LGA { get; set; }
        public string? TownCity { get; set; }

        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ContactPersonName { get; set; }
        public IFormFile? CertificateOfIncorporationRegistration { get; set; }
    }
}
