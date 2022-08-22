using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities
{
    public class UserLoginDetailViewModel : UserDetail
    {
        public string? JwtToken { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
