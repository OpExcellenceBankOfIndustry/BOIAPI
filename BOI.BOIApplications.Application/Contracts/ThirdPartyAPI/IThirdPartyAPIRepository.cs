using BOI.BOIApplications.Domain.DTO;
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
        Task<PersonalIdentificationResponse> FetchCustomerBVN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNIN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerPVC(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNDL(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerINP(PersonalIdentificationRequest request);
        Task<BusinessCACResponse> FetchBusinessCAC(string CAC);
        Task<BusinessTINResponse> FetchBusinessTIN(string TIN);
    }
}
