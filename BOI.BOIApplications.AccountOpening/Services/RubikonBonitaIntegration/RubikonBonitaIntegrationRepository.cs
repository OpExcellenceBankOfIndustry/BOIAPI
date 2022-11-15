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

namespace BOI.BOIApplications.AccountOpening.Services.RubikonBonitaIntegration
{
    public class RubikonBonitaRepository : IRubikonBonitaRepository
    {

        private readonly IRestClient _client;
        private readonly IErrorMessageRepository _errorMessageRepository;
        private readonly IConfiguration _configuration;
        private readonly RubikonBonitaIntegrationAPISettings _rubikonBonitaIntegrationAPISettings;

        public RubikonBonitaRepository(IRestClient client, 
            IOptions<RubikonBonitaIntegrationAPISettings> options, 
            IConfiguration configuration,
            IErrorMessageRepository errorMessageRepository)
        {
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
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = customerNumber;
                    var getCustomerDetailsEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["GetCustomerDetails"];
                    var feedback = await ExcuteNeptuneThirdPartyAPI<GetCustomerDetailsResponse>(req, getCustomerDetailsEndpoint);
                    if (feedback != null)
                    {
                        return feedback;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> FetchPersonalCustomerInquiryResult(string nationalId)
        {
            try
            {
                if (nationalId != null)
                {
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = nationalId;
                    var personalCustomerEnquiryEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["PersonalCustomerInquiry"];
                    var feedback = await ExcuteNeptuneThirdPartyAPI<PersonalCustomerInquiryResponse>(req, personalCustomerEnquiryEndpoint);
                    if (feedback != null)
                        return feedback;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> FetchCorporateCustomerInquiryResult(string rcNumber)
        {
            try
            {
                if (rcNumber != null)
                {
                    var req = new BonitaRubikonAPIRequest();
                    req.identificationNumber = rcNumber;
                    var corporateCustomerEnquiryEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints["CorporateCustomerInquiry"];
                    var feedback = await ExcuteNeptuneThirdPartyAPI<CorporateCustomerInquiryResponse>(req, corporateCustomerEnquiryEndpoint);
                    if (feedback != null)
                        return feedback;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> CreateCustomerAccount<T>(T accountCreationDetails)
        {
            try
            {
                var customerAccountCreationEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints[accountCreationDetails.GetType().Name];
                var feedback = await ExcuteNeptuneThirdPartyAccountCreationAPI<T>(accountCreationDetails, customerAccountCreationEndpoint);
                if (feedback != null)
                    return feedback;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> ExecuteActionOnCustomerAccount<T, U>(T requestDetails)
        {
            try
            {
                var rawXml = _rubikonBonitaIntegrationAPISettings.RequestBody[requestDetails.GetType().Name];
                var endpoint = _rubikonBonitaIntegrationAPISettings.Endpoints[requestDetails.GetType().Name];

                var argXmlBody = DataManipulation.SerializeObjectToXml(requestDetails);

                rawXml = HttpUtility.HtmlDecode(rawXml);

                string propertyName = _rubikonBonitaIntegrationAPISettings.RequestParameterKeyword;

                string parameterDataType = requestDetails.GetType().Name.ToString();

                rawXml = rawXml.Replace(propertyName, argXmlBody.ToString(), true, null);

                rawXml = rawXml.Replace(parameterDataType, propertyName, true, null);

                var feedback = await ExcuteNeptuneThirdPartyAccountLinkingAPI<U>(endpoint, rawXml);

                if (feedback != null)
                    return feedback;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> ExcuteNeptuneThirdPartyAPI<T>(BonitaRubikonAPIRequest thirdPartyRequest, string endPoint)
        {
            try
            {
                endPoint = endPoint.Replace(thirdPartyRequest.GetType().GetProperties().First().Name, thirdPartyRequest.identificationNumber, true, null);
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.GET);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var responeObject = response.Content;

                    if (!DataManipulation.IsJson(responeObject))
                    {
                        responeObject = DataManipulation.SerializeXmlStringToJson<T>(responeObject, "return");
                    }
                    else
                    {
                        responeObject = DataManipulation.SerializeJsonStringToObject<T>(responeObject);
                    }

                    return responeObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> ExcuteNeptuneThirdPartyAccountCreationAPI<T>(T thirdPartyRequest, string endPoint)
        {
            try
            {
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

                string? responeObject = null;

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    responeObject = response.Content;

                    if (!DataManipulation.IsJson(responeObject))
                    {
                        responeObject = DataManipulation.SerializeXmlStringToJson<CustomerCreationResponse>(responeObject, "return");
                    }
                    else
                    {
                        responeObject = DataManipulation.SerializeJsonStringToObject<T>(responeObject);
                    }
                }
                else if (response.Content.Contains("errorCode"))
                {
                    responeObject = DataManipulation.SerializeXmlStringToJson<ErrorCodeResponse>(response.Content, "errorCode");

                    var connectionString = _configuration.GetConnectionString("OracleDb");

                    JObject obj = JObject.Parse(responeObject);
                    string errorCode = (string)obj["errorCode"];

                    var errorDescription = _errorMessageRepository.GetErrorMessages(errorCode, _configuration.GetConnectionString("OracleDb"));

                    responeObject = DataManipulation.SerializeObjectToJson(errorDescription.Result);
                }

                return responeObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object> ExcuteNeptuneThirdPartyAccountLinkingAPI<T>(string endPoint, string rawXml)
        {
            try
            {
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.POST);                

                request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var responeObject = response.Content;

                    if (!DataManipulation.IsJson(responeObject))
                    {
                        responeObject = DataManipulation.SerializeXmlStringToJson<T>(responeObject, "return");
                    }
                    else
                    {
                        responeObject = DataManipulation.SerializeJsonStringToObject<T>(responeObject);
                    }

                    return responeObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
