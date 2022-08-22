using AutoMapper;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login;
using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Profiles.API.MicrosoftIdentity.UserAccess
{
    public class UserAccessMappingProfiles : Profile
    {
        public UserAccessMappingProfiles()
        {
            CreateMap<LoginQuery, Login>().ReverseMap();
            CreateMap<Login, LoginViewModel>().ReverseMap();
            CreateMap<LoginQuery, LoginViewModel>().ReverseMap();

            CreateMap<ForgetPasswordCommand, ForgetPasswordViewModel>().ReverseMap();
            CreateMap<ChangePasswordCommand, ChangePasswordViewModel>().ReverseMap();

        }
    }
}
