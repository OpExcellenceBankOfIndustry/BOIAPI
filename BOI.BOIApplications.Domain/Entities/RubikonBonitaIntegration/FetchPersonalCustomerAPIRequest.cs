using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class FetchPersonalCustomerAPIRequest
    {
        public string? nationalIdNumber { get; set; }
        public string? channelId { get; set; }
        public string? transmissionTime { get; set; }
    }
}
