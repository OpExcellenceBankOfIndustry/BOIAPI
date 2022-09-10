using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;

namespace BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI
{
    public interface IRubikonBonitaRepository
    {
        Task<object> FetchCustomerDetails(string customerNumber);
        Task<object> FetchPersonalCustomerInquiryResult(string nationalId);
        Task<object> FetchCorporateCustomerInquiryResult(string rcNumber);
        Task<object> CreateCustomerAccount<T>(T corporateAccountDetails);
        Task<object> LinkCustomerAccount<T>(T accountLinkingDetails);
    }
}
