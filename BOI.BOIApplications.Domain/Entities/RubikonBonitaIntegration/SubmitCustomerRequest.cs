using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class SubmitCustomerRequest
    {
        public int channelId { get; set; }
        public string serviceChannelCode { get; set; }
        public int serviceId { get; set; }
        public string transmissionTime { get; set; }
        public string customerNo { get; set; }
    }
}
