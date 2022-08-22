using AutoMapper;
using BOI.BOIApplications.Application.Model.WorkerService;
using BOI.BOIApplications.Legacy.Domain.Entites;

namespace BOI.BOIApplications.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BonitaProfileCreationTemplate, Boiemployee>()
            .ForMember(
                dest => dest.Employeeid,
                opt => opt.MapFrom(src => src.StaffId.Trim()))
            .ForMember(
                dest => dest.Firstname,
                opt => opt.MapFrom(src => src.FirstName.Trim()))
            .ForMember(
                dest => dest.Middleinitial,
                opt => opt.MapFrom(src => src.MiddleNameInitial.Trim()))
            .ForMember(
                dest => dest.Lastname,
                opt => opt.MapFrom(src => src.LastName.Trim()))
            .ForMember(
                dest => dest.Sortcode,
                opt => opt.MapFrom(src => src.SortCode.Trim()))
            .ReverseMap();
        }
    }
}
