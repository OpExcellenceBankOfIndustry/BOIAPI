using AutoMapper;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails;
using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Profiles.API.MicrosoftIdentity.UserManager
{
    public class UserDetailMappingProfiles : Profile
    {
        public UserDetailMappingProfiles()
        {
            CreateMap<UserDetailCommand, UserDetail>().ReverseMap();
            CreateMap<UserDetail, UserDetailViewModel>().ReverseMap();
            CreateMap<UserDetailCommand, UserDetailViewModel>().ReverseMap();
            CreateMap<UserDetailViewModel, UserDetailViewModelRes>().ReverseMap();

            CreateMap<ConfirmEmailViewModel, ConfirmEmailCommand>().ReverseMap();
            CreateMap<ConfirmEmailCommand, ConfirmEmailViewModel>().ReverseMap();
        }
    }
}
