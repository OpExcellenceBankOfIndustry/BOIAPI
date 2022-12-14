using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class CustomerCreationReturn
    {
        public string customerId { get; set; }
        public string customerNumber { get; set; }
        public string status { get; set; }
    }

    public class CustomerCreationResponse
    {
        [JsonProperty(PropertyName = "return")]
        public CustomerCreationReturn _return { get; set; }

    }
}
