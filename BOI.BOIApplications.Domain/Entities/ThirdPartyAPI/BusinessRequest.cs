using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class BusinessRequestCAC
    {
        public string? registrationNumber { get; set; }
        public string? countryCode { get; set; }
        public bool isConsent { get; set; }
    }


    public class BusinessRequestTIN
    {
        public string? type { get; set; }
        public string? value { get; set; }
        public bool isConsent { get; set; }
    }
}
