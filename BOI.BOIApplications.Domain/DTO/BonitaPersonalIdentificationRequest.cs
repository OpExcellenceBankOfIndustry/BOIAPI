using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class BonitaPersonalIdentificationRequest : PersonalIdentificationRequest
    {
        public string? Type { get; set; }
    }
}
