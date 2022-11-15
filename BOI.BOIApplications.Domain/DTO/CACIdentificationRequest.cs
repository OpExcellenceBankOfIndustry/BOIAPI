using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class CACIdentificationRequest
    {
        public string? CompanyName { get; set; }
        public string? CompanyRegistrationNumber { get; set; }
        public DateTimeOffset CompanyRegistrationDate { get; set; }
    }


    public class CACIdentificationOutRequest
    {
        public string? registrationNumber { get; set; }
        public string? registrationName { get; set; }
        public string? countryCode { get; set; }
        public bool isConsent { get; set; }
    }
}
