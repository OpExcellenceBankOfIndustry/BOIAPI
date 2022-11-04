using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class PersonalIdentificationRequest
    {
        public string? idNumber { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public DateTimeOffset dateOfBirth { get; set; }
    }
}
