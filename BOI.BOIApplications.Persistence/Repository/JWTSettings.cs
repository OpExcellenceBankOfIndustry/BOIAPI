using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence.Repository
{
    public class JWTSettings
    {
        public string? ValidAudience { get; set; }
        public string? ValidIssuer { get; set; }
        public string? Secret { get; set; }
        public int expiryTime { get; set; }
    }
}
