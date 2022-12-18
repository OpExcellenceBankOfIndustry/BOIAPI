using AutoMapper;
using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Application.Utility;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.X509;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Reflection;
using BOI.BOIApplications.Application.Contracts.Persistence.ErrorMessage;
using Newtonsoft.Json.Linq;
using BOI.BOIApplications.AccountOpening.Services.AccountOpening;
using Microsoft.Extensions.Logging;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;

namespace BOI.BOIApplications.AccountOpening.Services.RubikonBonitaIntegration
{
    public class RubikonBonitaRepository : IRubikonBonitaRepository
    {
        private readonly ILogger<RubikonBonitaRepository> _logger;
        private readonly IRestClient _client;
        private readonly IErrorMessageRepository _errorMessageRepository;
        private readonly IConfiguration _configuration;
        private readonly RubikonBonitaIntegrationAPISettings _rubikonBonitaIntegrationAPISettings;

        public RubikonBonitaRepository(IRestClient client, 
            IOptions<RubikonBonitaIntegrationAPISettings> options, 
            IConfiguration configuration,
            IErrorMessageRepository errorMessageRepository, ILogger<RubikonBonitaRepository> logger)
        {
             _logger = logger;
            _client = client;
            _configuration = configuration;
            _errorMessageRepository = errorMessageRepository;
            _rubikonBonitaIntegrationAPISettings = options.Value;
        }
        public async Task<object> FetchCustomerDetails(string customerNumber)
        {
            try
            {
                if (customerNumber != null)
                {
                    _logger.LogInformation("<========================Start Fetch Customer Details ===========================>");
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = customerNumber;
                    var getCustomerDetailsEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["GetCustomerDetails"];
                    var feedback = await ExecuteNeptuneThirdPartyAPI<GetCustomerDetailsResponse>(req, getCustomerDetailsEndpoint);
                    if (feedback != null)
                    {
                        _logger.LogInformation("<========================End Fetch Customer Details===========================>");
                        return feedback;
                    }
                }
                _logger.LogInformation("<========================End Fetch Customer Details===========================>");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fetch Customer Detail Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> FetchPersonalCustomerInquiryResult(string nationalId)
        {
            try
            {
                if (nationalId != null)
                {
                    _logger.LogInformation("<========================Start Fetch Personal Customer Inquiry Result ===========================>");
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = nationalId;
                    var personalCustomerEnquiryEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["PersonalCustomerInquiry"];
                    var feedback = await ExecuteNeptuneThirdPartyAPI<PersonalCustomerInquiryResponse>(req, personalCustomerEnquiryEndpoint);
                    if (feedback != null)
                        _logger.LogInformation("<========================End Fetch Personal Customer Inquiry Result===========================>");
                    return feedback;
                }
                _logger.LogInformation("<========================End Fetch Personal Customer Inquiry Result===========================>");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fetch Personal Customer Inquiry Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> FetchCorporateCustomerInquiryResult(string rcNumber)
        {
            try
            {
                if (rcNumber != null)
                {
                    _logger.LogInformation("<========================Start Fetch Corporate Customer Inquiry Result ===========================>");
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = rcNumber;
                    var corporateCustomerEnquiryEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["CorporateCustomerInquiry"];
                    var feedback = await ExecuteNeptuneThirdPartyAPI<CorporateCustomerInquiryResponse>(req, corporateCustomerEnquiryEndpoint);
                    if (feedback != null)
                        _logger.LogInformation("<========================End Fetch Corporate Customer Inquiry Result===========================>");
                    return feedback;
                }
                _logger.LogInformation("<========================End Fetch Corporate Customer Inquiry Result===========================>");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fetch Corporate Customer Inquiry Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> CreateCustomerAccount<T>(T accountCreationDetails)
        {
            try
            {
                _logger.LogInformation("<========================Start Create Customer Account Result===========================>");
                var customerAccountCreationEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints[accountCreationDetails.GetType().Name];
                var feedback = await ExecuteNeptuneThirdPartyAccountCreationAPI<T>(accountCreationDetails, customerAccountCreationEndpoint);
                if (feedback != null)
                {
                    _logger.LogInformation("<========================End Create Customer Account Result===========================>");
                    return feedback;
                }
                    
                _logger.LogInformation("<========================End Create Customer Account Result===========================>");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Customer Account Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> ExecuteActionOnCustomerAccount<T, U>(T requestDetails)
        {
            try
            {
                _logger.LogInformation("<========================Start Execute Action On Customer Account===========================>");
                var rawXml = _rubikonBonitaIntegrationAPISettings.RequestBody[requestDetails.GetType().Name];
                var endpoint = _rubikonBonitaIntegrationAPISettings.Endpoints[requestDetails.GetType().Name];

                var argXmlBody = DataManipulation.SerializeObjectToXml(requestDetails);

                rawXml = HttpUtility.HtmlDecode(rawXml);

                string propertyName = _rubikonBonitaIntegrationAPISettings.RequestParameterKeyword;

                string parameterDataType = requestDetails.GetType().Name.ToString();

                rawXml = rawXml.Replace(propertyName, argXmlBody.ToString(), true, null);

                rawXml = rawXml.Replace(parameterDataType, propertyName, true, null);

                var feedback = await ExecuteNeptuneThirdPartyAccountLinkingAPI<U>(endpoint, rawXml);

                if (feedback != null)
                {
                    _logger.LogInformation("<========================End Execute Action On Customer Account===========================>");
                    return feedback;
                }
                _logger.LogInformation("<========================End Execute Action On Customer Account===========================>");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Execute Action On Customer Account Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> ExecuteNeptuneThirdPartyAPI<T>(BonitaRubikonAPIRequest thirdPartyRequest, string endPoint)
        {
            try
            {
                _logger.LogInformation("<========================Start Execute Neptune ThirdParty API===========================>");
                endPoint = endPoint.Replace(thirdPartyRequest.GetType().GetProperties().First().Name, thirdPartyRequest.identificationNumber, true, null);
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.GET);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content) && response.Content.Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    var responseObject = response.Content;

                    if (!DataManipulation.IsJson(responseObject))
                    {
                        responseObject = DataManipulation.SerializeXmlStringToJson<T>(responseObject, "return");
                    }
                    else
                    {
                        responseObject = DataManipulation.SerializeJsonStringToObject<T>(responseObject);
                    }
                    _logger.LogInformation("<========================End Execute Neptune ThirdParty API===========================>");
                    return responseObject;
                }
                else
                {
                    _logger.LogInformation("<========================End Execute Neptune ThirdParty API===========================>");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Execute Neptune ThirdParty API Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> ExecuteNeptuneThirdPartyAccountCreationAPI<T>(T thirdPartyRequest, string endPoint)
        {
            try
            {
                _logger.LogInformation("<========================Start Execute Neptune ThirdParty Account Creation API===========================>");
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.POST);

                var jsonString = DataManipulation.SerializeObjectToJson(thirdPartyRequest);

                var xmlResult = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString, "arg0");

                var argXmlBody = xmlResult.InnerXml;

                string rawXml = _rubikonBonitaIntegrationAPISettings.RequestBody["AccountCreationRequestBody"];

                rawXml = HttpUtility.HtmlDecode(rawXml);

                string propertyName = _rubikonBonitaIntegrationAPISettings.RequestParameterKeyword;

                string parameterDataType = thirdPartyRequest.GetType().Name.ToString();

                rawXml = rawXml.Replace(propertyName, argXmlBody.ToString(), true, null);

                rawXml = rawXml.Replace(parameterDataType, propertyName, true, null);

                request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

                IRestResponse response = await _client.ExecuteAsync(request);

                string? responseObject = null;

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content) && response.Content.Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    responseObject = response.Content;

                    if (!DataManipulation.IsJson(responseObject))
                    {
                        responseObject = DataManipulation.SerializeXmlStringToJson<CustomerCreationResponse>(responseObject, "return");
                    }
                    else
                    {
                        responseObject = DataManipulation.SerializeJsonStringToObject<T>(responseObject);
                    }
                }
                else if (response.Content.Contains("errorCode"))
                {
                    responseObject = DataManipulation.SerializeXmlStringToJson<ErrorCodeResponse>(response.Content, "errorCode");

                    var connectionString = _configuration.GetConnectionString("OracleDb");

                    JObject obj = JObject.Parse(responseObject);
                    string errorCode = (string)obj["errorCode"];

                    var errorDescription = _errorMessageRepository.GetErrorMessages(errorCode, _configuration.GetConnectionString("OracleDb"));

                    responseObject = DataManipulation.SerializeObjectToJson(errorDescription.Result);
                }
                _logger.LogInformation("<========================End Execute Neptune ThirdParty Account Creation API===========================>");
                return responseObject;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Execute Neptune ThirdParty Account Creation API Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<object> ExecuteNeptuneThirdPartyAccountLinkingAPI<T>(string endPoint, string rawXml)
        {
            try
            {
                _logger.LogInformation("<========================Start Execute Neptune ThirdParty Account Linking API===========================>");
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.POST);                

                request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content) && response.Content.Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    var responseObject = response.Content;

                    if (!DataManipulation.IsJson(responseObject))
                    {
                        responseObject = DataManipulation.SerializeXmlStringToJson<T>(responseObject, "return");
                    }
                    else
                    {
                        responseObject = DataManipulation.SerializeJsonStringToObject<T>(responseObject);
                    }
                    _logger.LogInformation("<========================End Execute Neptune ThirdParty Account Linking API===========================>");
                    return responseObject;
                }
                else
                {
                    _logger.LogInformation("<========================End Execute Neptune ThirdParty Account Linking API===========================>");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Execute Neptune ThirdParty Account Linking API Exception: {ex.Message}");
                throw;
            }
        }
    }
}
