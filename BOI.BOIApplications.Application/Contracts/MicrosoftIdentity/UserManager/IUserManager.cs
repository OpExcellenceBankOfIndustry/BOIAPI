using BOI.BOIApplications.Application.Contracts.Persistence;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager
{
    public interface IUserManager 
    {
        Task<UserDetailViewModel> UserRegistration(UserDetailViewModel userDetail);

        Task<bool> ConfirmEmail(string email, string code);
    }
}
