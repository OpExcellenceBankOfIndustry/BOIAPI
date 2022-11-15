using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class LinkPersonalCustomerToCorporateReturn
    {
        public int errorCode { get; set; }
        public bool offlineMode { get; set; }
        public bool offlineable { get; set; }
        public bool successFlag { get; set; }
        public bool workflowRequired { get; set; }
        public string customerId { get; set; }
    }

    public class LinkPersonalCustomerToCorporateResponse
    {
        [JsonProperty(PropertyName = "return")]
        public LinkPersonalCustomerToCorporateReturn _return { get; set; }
    }
}
