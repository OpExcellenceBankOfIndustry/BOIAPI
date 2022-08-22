using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class ThirdPartyAPIRequest
    {
        public string? id { get; set; }
        public bool isSubjectConsent { get; set; }

        //public string lastName { get; set; }
    }

    public class BusinessVerificationServicesRequest
    {
        public string? type { get; set; }
        public string? value { get; set; }
        public bool isConsent { get; set; }
    }
}
