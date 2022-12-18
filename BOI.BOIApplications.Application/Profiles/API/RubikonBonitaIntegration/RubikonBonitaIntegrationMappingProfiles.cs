using AutoMapper;
using BOI.BOIApplications.Application.Model.WorkerService;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using BOI.BOIApplications.Legacy.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Profiles.API.RubikonBonitaIntegration
{
    public class RubikonBonitaIntegrationMappingProfiles :Profile
    {
        public RubikonBonitaIntegrationMappingProfiles()
        {
            //CorporateCustomerInquiry
            CreateMap<PersonalCustomerAccountCreation, AOIndividualShareholder>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.firstName.Trim()))
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.lastName.Trim()))
                .ForMember(
                    dest => dest.NIN,
                    opt => opt.MapFrom(src => src.nationalIdNumber))
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.gender.Trim()))
                .ForMember(
                    dest => dest.LGA,
                    opt => opt.MapFrom(src => src.addressCity.Trim()))
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => src.addressLine1.Trim()))
                .ForMember(
                    dest => dest.StakeholderState,
                    opt => opt.MapFrom(src => src.addressState.Trim()))
                .ForMember(
                    dest => dest.MaritalStatus,
                    opt => opt.MapFrom(src => src.maritalStatus.Trim()))
                .ForMember(
                    dest => dest.OtherName,
                    opt => opt.MapFrom(src => src.middleName.Trim()))
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.strDateOfBirth))
                .ForMember(
                    dest => dest.TIN,
                    opt => opt.MapFrom(src => src.taxIdentificationNo));
        }
       
    }
}
