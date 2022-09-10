using AutoMapper;
using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Application.Utility;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

namespace BOI.BOIApplications.AccountOpening.Services.RubikonBonitaIntegration
{
    public class RubikonBonitaRepository : IRubikonBonitaRepository
    {

        private readonly IRestClient _client;
        private readonly RubikonBonitaIntegrationAPISettings _rubikonBonitaIntegrationAPISettings;

        public RubikonBonitaRepository(IRestClient client, IOptions<RubikonBonitaIntegrationAPISettings> options)
        {
            _client = client;
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

        public async Task<object> LinkCustomerAccount<T>(T accountLinkingDetails)
        {
            try
            {
                var accountLinkingEndpoint = _rubikonBonitaIntegrationAPISettings.Endpoints[accountLinkingDetails.GetType().Name];
                var feedback = await ExcuteNeptuneThirdPartyAccountLinkingAPI<T>(accountLinkingDetails, accountLinkingEndpoint);
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

                //var argXmlBody = JsonConvert.SerializeXmlNode((thirdPartyRequest);

                var j = DataManipulation.SerializeObjectToJson(thirdPartyRequest);

                var writer = new StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, thirdPartyRequest);
                string xml = writer.ToString();


                var argXmlBody = DataManipulation.SerializeObjectToXml<T>(thirdPartyRequest);

                string rawXml = _rubikonBonitaIntegrationAPISettings.AccountCreationRequestBody;

                rawXml = HttpUtility.HtmlDecode(rawXml);

                string propertyName = _rubikonBonitaIntegrationAPISettings.RequestParameterKeyword;

                string parameterDataType = thirdPartyRequest.GetType().Name.ToString();

                rawXml = rawXml.Replace(propertyName, argXmlBody.ToString(), true, null);

                rawXml = rawXml.Replace(parameterDataType, propertyName, true, null);

                request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var responeObject = response.Content;

                    if (!DataManipulation.IsJson(responeObject))
                    {
                        responeObject = DataManipulation.SerializeXmlStringToJson<CustomerCreationResponse>(responeObject, "return");
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

        public async Task<object> ExcuteNeptuneThirdPartyAccountLinkingAPI<T>(T thirdPartyRequest, string endPoint)
        {
            try
            {
                _client.BaseUrl = new Uri(_rubikonBonitaIntegrationAPISettings.BaseURL);

                RestRequest request = new RestRequest(endPoint, Method.POST);

                var argXmlBody = DataManipulation.SerializeObjectToXml<T>(thirdPartyRequest);

                string rawXml = _rubikonBonitaIntegrationAPISettings.AccountCreationRequestBody;

                rawXml = HttpUtility.HtmlDecode(rawXml);

                string propertyName = _rubikonBonitaIntegrationAPISettings.RequestParameterKeyword;

                string parameterDataType = thirdPartyRequest.GetType().Name.ToString();

                rawXml = rawXml.Replace(propertyName, argXmlBody.ToString(), true, null);

                rawXml = rawXml.Replace(parameterDataType, propertyName, true, null);

                request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var responeObject = response.Content;

                    if (!DataManipulation.IsJson(responeObject))
                    {
                        responeObject = DataManipulation.SerializeXmlStringToJson<CustomerCreationResponse>(responeObject, "return");
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
