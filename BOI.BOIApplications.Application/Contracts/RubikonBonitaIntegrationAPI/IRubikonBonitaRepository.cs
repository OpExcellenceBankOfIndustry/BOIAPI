using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using System.Reflection;

namespace BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI
{
    public interface IRubikonBonitaRepository
    {
        Task<object> FetchCustomerDetails(string customerNumber);
        Task<object> FetchPersonalCustomerInquiryResult(string nationalId);
        Task<object> FetchCorporateCustomerInquiryResult(string rcNumber);
        Task<object> CreateCustomerAccount<T>(T corporateAccountDetails);
        Task<object> ExecuteActionOnCustomerAccount<T, U>(T accountLinkingDetails);
    }
}
