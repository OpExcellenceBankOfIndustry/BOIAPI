using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class CompanyIdentificationRequest
    {
        public string? idNumber { get; set; }
        public string? CompanyName { get; set; }
        //public DateTimeOffset CompanyRegistrationDate { get; set; }
    }
}
