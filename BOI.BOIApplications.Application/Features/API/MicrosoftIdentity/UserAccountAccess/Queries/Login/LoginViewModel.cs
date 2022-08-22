using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login
{
    public class LoginViewModel
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool DefaultPassword { get; set; }
        public string ErrorMessage { set; get; }
    }
}
