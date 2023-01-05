using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class CACCorporateResponse
    {
        public string? RCNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public string? IndustryType { get; set; }

        public bool isAvailable { get; set; }
        public string? Message { get; set; }
    }
}
