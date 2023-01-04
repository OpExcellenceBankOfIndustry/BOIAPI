using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using System.Reflection;

namespace BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI
{
    public interface IRubikonBonitaRepository
    {
        Task<object> FetchPersonalCustomerInquiryResult(string nationalId);
        Task<object> FetchCorporateCustomerInquiryResult(string rcNumber);
        Task<object> CreateCustomerAccount<T>(T corporateAccountDetails, string endpointType);
        Task<object> ExecuteActionOnCustomerAccount<T, U>(string accountLinkingDetails, string endpointType);
    }
}
