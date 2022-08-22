using BOI.BOIApplications.Application.Contracts.Persistence;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.AccountOpening
{
    public interface IAccountOpeningRepository 
    {
        //Task<string> AddCompanyInform(CompanyInformViewModel companyInform);
        Task<CompanyInformCommandResponse> AddCompanyInform(CompanyInformViewModel companyInform);
        Task<string> AddRegulatoryInform(RegulatoryInformViewModel regulatoryInform);

        Task<string> AddRelatedPartyInform(RelatedPartyInformViewModel relatedPartyInform);

        Task<string> AddAccountDetailsOfOwner(List<AccountDetailsOfOwnerViewModel> accountDetailsOfOwner);

        Task<string> AddDetailsOfNextOfKin(List<DetailsOfNextOfKinViewModel> detailsOfNextOfKin);

        Task<string> AddSoleProprietorship(SoleProprietorshipViewModel soleProprietorship);

        Task<string> AddOwnershipInformCoop(OwnershipInformCoopViewModel ownershipInformCoop);
        Task<string> AddOwnershipInformInd(OwnershipInformIndViewModel ownershipInformInd);
    }
}
