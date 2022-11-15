using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class SubmitAccountReturn
    {
        public string status { get; set; }
        public bool offlineMode { get; set; }
        public bool offlineable { get; set; }
        public bool successFlag { get; set; }
        public bool workflowRequired { get; set; }
        public string customerCat { get; set; }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string customerNumber { get; set; }
        public string customerTypeDesc { get; set; }
    }

    public class SubmitAccountResponse
    {
        [JsonProperty(PropertyName = "return")]
        public SubmitAccountReturn _return { get; set; }

    }
}
