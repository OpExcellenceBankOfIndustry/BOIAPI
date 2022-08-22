using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails
{
   
    public class UserDetailCommand :  IRequest<UserDetailCommandResponse>
    {

        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string? BusinessName { get; set; }
        public string? RCNumber { get; set; }
        public string? BusinessType { get; set; }
        public string? BusinessLocation { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
