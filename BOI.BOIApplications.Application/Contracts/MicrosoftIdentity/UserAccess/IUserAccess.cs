using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login;
using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess
{
    public interface IUserAccess
    {
        Task<UserLoginDetailViewModel> Login(LoginViewModel model);
        Task<ForgetPasswordViewModel> ForgetPassword(ForgetPasswordViewModel model);
        Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model);
    }
}
