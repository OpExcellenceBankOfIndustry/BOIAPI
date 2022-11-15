using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;

namespace BOI.BOIApplications.Application.Contracts.ThirdPartyAPI
{
    public interface IThirdPartyAPIRepository
    {
<<<<<<< HEAD
        Task<PersonalIdentificationResponse> FetchCustomerBVN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNIN(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerPVC(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerNDL(PersonalIdentificationRequest request);
        Task<PersonalIdentificationResponse> FetchCustomerINP(PersonalIdentificationRequest request);
        Task<CompanyIdentificationResponse> FetchBusinessCAC(CACIdentificationRequest request);
        Task<CompanyIdentificationResponse> FetchBusinessTIN(TINIdentificationRequest request);
=======
        Task<CustomerBVNResponse> FetchCustomerBVN(string BVN);
        Task<CustomerNINResponse> FetchCustomerNIN(string NIN);
        Task<CustomerPVCResponse> FetchCustomerPVC(string PVC);
        Task<CustomerDriversLicenseResponse> FetchCustomerNDL(string NDL);
        Task<CustomerINTLPassportResponse> FetchCustomerINP(string INP, string lastName);
        Task<BusinessCACResponse> FetchBusinessCAC(string CAC);
        Task<BusinessTINResponse> FetchBusinessTIN(string TIN);
>>>>>>> 0de255f9f77bd7b790e46704e1e0d2f2e43610f9
    }
}
