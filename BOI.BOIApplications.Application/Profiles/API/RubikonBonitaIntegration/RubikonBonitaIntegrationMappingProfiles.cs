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
            //CreatePersonalAccount
            CreateMap<AOIndividualShareholder, PersonalCustomerAccountCreation>()
                .ForMember(
                    dest => dest.firstName,
                    opt => opt.MapFrom(src => src.FirstName.Trim()))
                .ForMember(
                    dest => dest.lastName,
                    opt => opt.MapFrom(src => src.Surname.Trim()))
                .ForMember(
                    dest => dest.customerName,
                    opt => opt.MapFrom(src => $"{src.FirstName.Trim()} {src.Surname.Trim()}"))
                .ForMember(
                    dest => dest.fathersName,
                    opt => opt.MapFrom(src => src.Surname.Trim()))
                .ForMember(
                    dest => dest.nationalIdNumber,
                    opt => opt.MapFrom(src => src.NIN))
                .ForMember(
                    dest => dest.gender,
                    opt => opt.MapFrom(src => src.Gender.Trim()))
                .ForMember(
                    dest => dest.addressCity,
                    opt => opt.MapFrom(src => src.LGA.Trim()))
                .ForMember(
                    dest => dest.addressLine1,
                    opt => opt.MapFrom(src => src.Address.Trim()))
                .ForMember(
                    dest => dest.addressState,
                    opt => opt.MapFrom(src => src.StakeholderState.Trim()))
                .ForMember(
                    dest => dest.maritalStatus,
                    opt => opt.MapFrom(src => src.MaritalStatus.Trim()))
                .ForMember(
                    dest => dest.middleName,
                    opt => opt.MapFrom(src => src.OtherName.Trim()))
                .ForMember(
                    dest => dest.strDateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(
                    dest => dest.preferredName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.middleName,
                    opt => opt.MapFrom(src => src.Title.Trim()))
                .ForMember(
                    dest => dest.taxIdentificationNo,
                    opt => opt.MapFrom(src => src.TIN));

            //CreateCorporateAccount
            CreateMap<CreateCompanyInformation, CorporateCustomerAccountCreation>()
                .ForMember(
                    dest => dest.custShortName,
                    opt => opt.MapFrom(src => src.ShortName.Trim()))
                .ForMember(
                    dest => dest.customerName,
                    opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(
                    dest => dest.firstName,
                    opt => opt.MapFrom(src => src.ShortName.Trim()))
                .ForMember(
                    dest => dest.addressCity,
                    opt => opt.MapFrom(src => src.LGA.Trim()))
                .ForMember(
                    dest => dest.addressLine1,
                    opt => opt.MapFrom(src => src.Address.Trim()))
                .ForMember(
                    dest => dest.addressState,
                    opt => opt.MapFrom(src => src.CompanyState.Trim()))
                .ForMember(
                    dest => dest.strDate,
                    opt => opt.MapFrom(src => src.BusinessDate.Trim()))
                .ForMember(
                    dest => dest.strFromDate,
                    opt => opt.MapFrom(src => src.BusinessDate.Trim()))
                .ForMember(
                    dest => dest.taxIdentificationNo,
                    opt => opt.MapFrom(src => src.TIN))
                .ForMember(
                    dest => dest.organisationName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.registrationNumber,
                    opt => opt.MapFrom(src => src.RegNum.Trim()))
                .ForMember(
                    dest => dest.strRegistrationDate,
                    opt => opt.MapFrom(src => src.DateofIncorporation.Trim()))
                .ForMember(
                    dest => dest.TotalAssetValue,
                    opt => opt.MapFrom(src => src.TotalAssetValue))
                .ForMember(
                    dest => dest.AuthorisedShareCapital,
                    opt => opt.MapFrom(src => src.AuthorisedShareCapital))
                .ForMember(
                    dest => dest.PaidShareCapital,
                    opt => opt.MapFrom(src => src.PaidShareCapital))
                .ForMember(
                    dest => dest.LineOfBusiness,
                    opt => opt.MapFrom(src => src.LineOfBusiness.Trim()))
                .ForMember(
                    dest => dest.BusinessCategory,
                    opt => opt.MapFrom(src => src.BusinessCategory.Trim()));

            //LinkCustomerAccountToCorporateAccount
            CreateMap<CreateCompanyInformation, LinkPersonalCustomerToCorporateRequest>()
                .ForMember(
                    dest => dest.addressLine1,
                    opt => opt.MapFrom(src => src.Address.Trim()))
                .ForMember(
                    dest => dest.shareholdingOwnershipPercentage,
                    opt => opt.MapFrom(src => src.PercentOwnership))
                .ForMember(
                    dest => dest.businessPhoneNo,
                    opt => opt.MapFrom(src => src.PhoneNumber.Trim()))
                .ForMember(
                    dest => dest.businessEmailAddr,
                    opt => opt.MapFrom(src => src.Email.Trim()));
        }
       
    }
}
