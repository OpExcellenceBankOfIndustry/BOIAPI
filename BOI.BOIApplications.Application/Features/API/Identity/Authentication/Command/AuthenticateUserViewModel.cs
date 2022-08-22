using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command
{
    public class AuthenticateUserViewModel
    {
        public string BearerToken { get; set; }
        public DateTimeOffset ExpiryPeriod { get; set; }
    }
}
