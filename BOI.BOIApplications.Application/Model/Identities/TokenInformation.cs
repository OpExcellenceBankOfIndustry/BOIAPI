using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Model.Identities
{
    public class TokenInformation
    {
        public string BearerToken { get; set; }
        public DateTimeOffset ExpiryPeriod { get; set; }
    }
}
