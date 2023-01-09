using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.ThirdPartyAPI
{
    public interface IThirdPartyAPIRepository
    {
        Task<List<BankL>> FetchBankList();
        Task<BankAccountVerificationResponse> BankAccountVerification(BankAccountVerificationRequestView reqt);
        Task<PersonalIdentificationResponse> FetchPersonalIdentification(BonitaPersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerBVN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNIN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerPVC(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNDL(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerINP(PersonalIdentificationRequest request);
        Task<CompanyIdentificationResponse> FetchBusinessCAC(CompanyIdentificationRequest model);
        Task<BusinessTINResponse> FetchBusinessTIN(string TIN);
        //FOR PWC
        Task<BVNIndividualResponse> FetchCustomerBVN(string BVN);
        Task<CACCorporateResponse> FetchBusinessCAC(string CAC);
        
    }
}
