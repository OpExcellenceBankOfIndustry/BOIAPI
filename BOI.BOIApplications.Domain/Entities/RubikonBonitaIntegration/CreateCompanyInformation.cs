using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class CreateCompanyInformation
    {
        public string? ShortName { get; set; }
        public string? Name { get; set; }
        public string? LGA { get; set; }
        public string? Address { get; set; }
        public string? CompanyState { get; set; }
        public string? StakeholderState { get; set; }
        public int? PercentOwnership { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? RegNum { get; set; }
        public string? DateofIncorporation { get; set; }
        public string? CompanyBOIDiscover { get; set; }
        public string? BusinessDate { get; set; }
        public long? TIN { get; set; }
        public string? Title { get; set; }
        public string? LineOfBusiness { get; set; }
        public string? BusinessCategory { get; set; }
        public decimal TotalAssetValue { get; set; }
        public decimal AuthorisedShareCapital { get; set; }
        public decimal PaidShareCapital { get; set; }
  
    }
}
