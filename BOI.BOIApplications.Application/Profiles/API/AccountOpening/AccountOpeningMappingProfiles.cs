using AutoMapper;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Profiles.API.AccountOpening
{
    public class AccountOpeningMappingProfiles : Profile
    {
        public AccountOpeningMappingProfiles()
        {   //User details
            CreateMap<UserLoginDetailViewModel, UserDetail>().ReverseMap();
            CreateMap<UserDetail, UserLoginDetailViewModel>().ReverseMap();

            //CompanyInformation
            CreateMap<AOCompanyInformation, CompanyInformCommand>().ReverseMap();
            CreateMap<AOCompanyInformation, CompanyInformViewModel>().ReverseMap();
            CreateMap<CompanyInformViewModel, CompanyInformCommand>().ReverseMap();
            CreateMap<CompanyInformViewModel, AOCompanyInformation>().ReverseMap();
            CreateMap<CompanyInformCommand, CompanyInformViewModel>().ReverseMap();

            //RegulatoryInformation
            CreateMap<AORegulatoryInformation, RegulatoryInformCommand>().ReverseMap();
            CreateMap<AORegulatoryInformation, RegulatoryInformViewModel>().ReverseMap();
            CreateMap<RegulatoryInformViewModel, RegulatoryInformCommand>().ReverseMap();
            CreateMap<RegulatoryInformViewModel, AORegulatoryInformation>().ReverseMap();
            CreateMap<RegulatoryInformCommand, RegulatoryInformViewModel>().ReverseMap();

            //RelatedPartyInform
            CreateMap<AORelatedPartyInformation, RelatedPartyInformCommand>().ReverseMap();
            CreateMap<AORelatedPartyInformation, RelatedPartyInformViewModel>().ReverseMap();
            CreateMap<RelatedPartyInformViewModel, RelatedPartyInformCommand>().ReverseMap();
            CreateMap<RelatedPartyInformViewModel, AORelatedPartyInformation>().ReverseMap();
            CreateMap<RelatedPartyInformCommand, RelatedPartyInformViewModel>().ReverseMap();

            //AccountDetailsOfOwner
            CreateMap<AOAccountDetailsOfOwner, AccountDetailsOfOwnerCommand>().ReverseMap();
            CreateMap<AOAccountDetailsOfOwner, AccountDetailsOfOwnerViewModel>().ReverseMap();
            CreateMap<AccountDetailsOfOwnerViewModel, AccountDetailsOfOwnerCommand>().ReverseMap();
            CreateMap<AccountDetailsOfOwnerViewModel, AOAccountDetailsOfOwner>().ReverseMap();
            CreateMap<AccountDetailsOfOwnerCommand, AccountDetailsOfOwnerViewModel>().ReverseMap();

            //DetailsOfNextOfKin
            CreateMap<AODetailsOfNextOfKin, DetailsOfNextOfKinCommand>().ReverseMap();
            CreateMap<AODetailsOfNextOfKin, DetailsOfNextOfKinViewModel>().ReverseMap();
            CreateMap<DetailsOfNextOfKinViewModel, DetailsOfNextOfKinCommand>().ReverseMap();
            CreateMap<DetailsOfNextOfKinViewModel, AODetailsOfNextOfKin>().ReverseMap();
            CreateMap<DetailsOfNextOfKinCommand, DetailsOfNextOfKinViewModel>().ReverseMap();

            //SoleProprietorship
            CreateMap<AOSoleProprietorship, SoleProprietorshipCommand>().ReverseMap();
            CreateMap<AOSoleProprietorship, SoleProprietorshipViewModel>().ReverseMap();
            CreateMap<SoleProprietorshipViewModel, SoleProprietorshipCommand>().ReverseMap();
            CreateMap<SoleProprietorshipViewModel, AOSoleProprietorship>().ReverseMap();
            CreateMap<SoleProprietorshipCommand, SoleProprietorshipViewModel>().ReverseMap();

            //OwnershipInformCoop
            CreateMap<AOOwnershipInformationCooperate, OwnershipInformCoopCommand>().ReverseMap();
            CreateMap<AOOwnershipInformationCooperate, OwnershipInformCoopViewModel>().ReverseMap();
            CreateMap<OwnershipInformCoopViewModel, OwnershipInformCoopCommand>().ReverseMap();
            CreateMap<OwnershipInformCoopViewModel, AOOwnershipInformationCooperate>().ReverseMap();
            CreateMap<OwnershipInformCoopCommand, OwnershipInformCoopViewModel>().ReverseMap();

            //OwnershipInformInd
            CreateMap<AOOwnershipInformationIndividual, OwnershipInformIndCommand>().ReverseMap();
            CreateMap<AOOwnershipInformationIndividual, OwnershipInformIndViewModel>().ReverseMap();
            CreateMap<OwnershipInformIndViewModel, OwnershipInformIndCommand>().ReverseMap();
            CreateMap<OwnershipInformIndViewModel, AOOwnershipInformationIndividual>().ReverseMap();
            CreateMap<OwnershipInformIndCommand, OwnershipInformIndViewModel>().ReverseMap();

            //ThirdPartyMapping
            CreateMap<GeneralRequest, ThirdPartyAPIRequest>().ReverseMap();
            CreateMap<ThirdPartyAPIRequest, GeneralRequest>().ReverseMap();
            
            CreateMap<GeneralResponse, CustomerBVNResponse>().ReverseMap();
            CreateMap<CustomerBVNResponse, GeneralResponse>().ReverseMap();

            CreateMap<GeneralResponse, CustomerNINResponse>().ReverseMap();
            CreateMap<CustomerNINResponse, GeneralResponse>().ReverseMap();

            CreateMap<GeneralResponse, CustomerPVCResponse>().ReverseMap();
            CreateMap<CustomerPVCResponse, GeneralResponse>().ReverseMap();

            CreateMap<GeneralResponse, CustomerDriversLicenseResponse>().ReverseMap();
            CreateMap<CustomerDriversLicenseResponse, GeneralResponse>().ReverseMap();

            CreateMap<GeneralResponse, CustomerINTLPassportResponse>().ReverseMap();
            CreateMap<CustomerINTLPassportResponse, GeneralResponse>().ReverseMap();

            CreateMap<BusinessResponseBase, BusinessCACResponse>().ReverseMap();
            CreateMap<BusinessCACResponse, BusinessResponseBase>().ReverseMap();

            CreateMap<BusinessResponseBase, BusinessTINResponse>().ReverseMap();
            CreateMap<BusinessTINResponse, BusinessResponseBase>().ReverseMap();
        }
    }
}
