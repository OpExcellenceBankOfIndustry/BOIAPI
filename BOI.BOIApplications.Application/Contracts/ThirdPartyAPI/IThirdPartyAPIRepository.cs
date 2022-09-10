using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;

namespace BOI.BOIApplications.Application.Contracts.ThirdPartyAPI
{
    public interface IThirdPartyAPIRepository
    {
        Task<CustomerBVNResponse> FetchCustomerBVN(string BVN);
        Task<CustomerNINResponse> FetchCustomerNIN(string NIN);
        Task<CustomerPVCResponse> FetchCustomerPVC(string PVC);
        Task<CustomerDriversLicenseResponse> FetchCustomerNDL(string NDL);
        Task<CustomerINTLPassportResponse> FetchCustomerINP(string INP, string lastName);
        Task<BusinessCACResponse> FetchBusinessCAC(string CAC);
        Task<BusinessTINResponse> FetchBusinessTIN(string TIN);
    }
}
