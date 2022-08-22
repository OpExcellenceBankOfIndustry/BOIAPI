using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class BusinessRequest
    {
        public string? type { get; set; }
        public string? value { get; set; }
        public bool isConsent { get; set; }
    }
}
