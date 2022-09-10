using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class ThirdPartyAPISettings
    {
        public string? token { get; set; }
        public string? BaseURL { get; set; }
        public Dictionary<string,string>? Endpoints { get; set; }

        public string? LoanPortalBaseURL { get; set; }
        public Dictionary<string, string>? LoanPortalEndpoints { get; set; }

        public string? EncryptionKey { get; set; }
        public int TokenExpirationTime { get; set; }
    }
}
