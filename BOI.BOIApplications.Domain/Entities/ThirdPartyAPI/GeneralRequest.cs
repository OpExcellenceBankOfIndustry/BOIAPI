using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class GeneralRequest
    {
        public string? id { get; set; }
        public string? lastName { get; set; }
        public bool isSubjectConsent { get; set; }

    }

    public class GeneralRequestPVC
    {
        public string? id { get; set; }
        //public Metadata? metadata { get; set; }
        public bool isSubjectConsent { get; set; }
       
    }

    public class Metadata
    {
        public string? requestId { get; set; }
    }
}
