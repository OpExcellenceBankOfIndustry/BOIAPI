using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class RubikonBonitaIntegrationAPISettings
    {
        public string? BaseURL { get; set; }
        public Dictionary<string,string>? Endpoints { get; set; }
        public Dictionary<string,string>? RequestBody { get; set; }
        public string? AccountCreationRequestBody { get; set; }
        public string? RequestParameterKeyword { get; set; }
        public string? SubmitCustomerRequestBody { get;set; }
        public string? LinkPersonalAndCorporateRequestBody { get;set; }
    }
}
