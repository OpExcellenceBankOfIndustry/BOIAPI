using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class PersonalIdentificationResponse
    {
        public bool Matched { get; set; }
        public string? Message { get; set; }
    }
}
