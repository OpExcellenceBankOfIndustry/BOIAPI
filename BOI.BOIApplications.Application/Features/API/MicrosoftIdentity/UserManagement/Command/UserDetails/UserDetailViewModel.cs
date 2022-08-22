using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails
{
    public class UserDetailViewModel : UserDetail
    {
        public string RoleName { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ModelMessage { set; get; }
        public string ErrorMessage { set; get; }
    }
}
