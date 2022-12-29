using AutoMapper;
using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using BaseResponse = BOI.BOIApplications.Domain.Entities.BaseResponse;

namespace BOI.BOIApplications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RubikonBonitaIntegrationAPIController : Controller
    {
        private readonly IRubikonBonitaRepository _rubikonBonitaRepository;
        private readonly IMapper _mapper;
        public static CustomerNumber? customerNumber;

        public RubikonBonitaIntegrationAPIController(IRubikonBonitaRepository rubikonBonitaRepository, IMapper mapper)
        {
            _rubikonBonitaRepository = rubikonBonitaRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// An endpoint for Personal Customer Inquiry based off of the National Identification Number
        /// </summary>
        /// <param name="nationalIdentificationNumber"></param>
        /// <returns></returns>
        [HttpGet("/api/RubikonBonitaIntegrationAPI/PersonalCustomerInquiry/{nationalIdentificationNumber}", Name = "PersonalCustomerInquiry")]
        public async Task<ActionResult<PersonalCustomerInquiryResponse>> PersonalCustomerInquiry(string nationalIdentificationNumber)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(nationalIdentificationNumber))
            {
                var response = await _rubikonBonitaRepository.FetchPersonalCustomerInquiryResult(nationalIdentificationNumber);
                if (response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new BaseResponse { Success = true, Message = "Customer already exist. Kindly proceed to credit application" });
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Customer does not exist" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "The Value National Identification Number is Null or Empty" });
        }

        /// <summary>
        /// An endpoint for Corporate Customer Inquiry based off of the RC Number
        /// </summary>
        /// <param name="rcNumber"></param>
        /// <returns></returns>
        [HttpGet("/api/RubikonBonitaIntegrationAPI/CorporateCustomerInquiry/{rcNumber}", Name = "CorporateCustomerInquiry")]
        public async Task<ActionResult<CorporateCustomerInquiryResponse>> CorporateCustomerInquiry(string rcNumber)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(rcNumber))
            {
                var response = await _rubikonBonitaRepository.FetchCorporateCustomerInquiryResult(rcNumber);
                if (response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new BaseResponse { Success = true, Message = "Customer already exist. Kindly proceed to credit application" });
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Customer does not exist" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "The Value Registration Number is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Create Corporate Customer Account
        /// </summary>
        /// <param name="corporateAccountDetails"></param>
        /// <returns></returns>
        [HttpPost("/api/RubikonBonitaIntegrationAPI/CreateCorporateCustomerAccount", Name = "CreateCorporateAccount")]
        public async Task<ActionResult<CustomerCreationResponse>> CreateCorporateAccount(CreateCompanyInformation corporateAccountDetails)
            {

            if (ModelState.IsValid)
            {               
                CorporateCustomerAccountCreation corporateCustomerAccountCreation = new CorporateCustomerAccountCreation();
                var mappedRequest = _mapper.Map(corporateAccountDetails, corporateCustomerAccountCreation);
                //Default values are assigned below, note that they should be changed before go live
                mappedRequest.channelId = 121;
                mappedRequest.serviceChannelCode = "STC029";
                mappedRequest.serviceId = 121;
                mappedRequest.transmissionTime = "00";
                mappedRequest.businessUnitCodeId = "-99";
                mappedRequest.customerCategory = "COR";
                mappedRequest.addressCountryId = 682;
                mappedRequest.addressPropertyTypeId = "422";
                mappedRequest.addressTypeCd = "AT100";
                mappedRequest.addressTypeId = 11;
                mappedRequest.contactsList = new List<ContactsList> {
                    new ContactsList {
                        contactDetails = corporateAccountDetails.PhoneNumber,
                        contactMode ="CM100",
                        contactModeCategoryCode = "CM100",
                        contactModeTypeId = 206,
                        status = "A"
                    },
                    new ContactsList {
                        contactDetails = corporateAccountDetails.Email,
                        contactMode ="CM101",
                        contactModeCategoryCode = "CM101",
                        contactModeTypeId = 201,
                        status = "A"
                    }
                };
                mappedRequest.countryId = 682;
                mappedRequest.countryOfBirthCd = "NGA";
                mappedRequest.countryOfBirthId = 682;
                mappedRequest.countryOfResidenceId = 682;
                mappedRequest.custCountryCd = "NGA";
                mappedRequest.customerSegmentCd = "CS107";
                mappedRequest.customerTypeCd = "CT912";
                mappedRequest.identificationsList = new IdentificationsList {
                    cityOfIssue = "Abuja",
                    countryOfIssue ="NGA",
                    countryOfIssueId = 682,
                    identityType = "IT108",
                    identityTypeId = 315,
                    strIssueDate = corporateAccountDetails.DateofIncorporation,
                    verifiedFlag = true
                };

                mappedRequest.parentObjectCode = "CUSTOMER";
                mappedRequest.screenTypeCode = "CUSTOM";
                mappedRequest.subTypeId = 722;
                mappedRequest.industryCd = "SIC014";
                mappedRequest.industryId = 734;
                mappedRequest.locale = "en-US";
                mappedRequest.mainBusinessUnitCd = "001";
                mappedRequest.mainBusinessUnitId = "-99";
                mappedRequest.nationalityCd = "N101";
                mappedRequest.nationalityId = 532;
                mappedRequest.operationCurrencyCd = "NGN";
                mappedRequest.operationCurrencyId = 732;
                mappedRequest.primaryAddress = true;
                mappedRequest.primaryRelationshipOfficerCd = "NEPTUNE";
                mappedRequest.propertyTypeCd = "PT107";
                mappedRequest.residentCountryCd = "NGA";
                mappedRequest.residentFlag = true;
                mappedRequest.serviceLevel = 400;
                mappedRequest.serviceLevelId = 164;
                mappedRequest.sourceOfFundCd = "SF002";
                mappedRequest.sourceOfFundId = 352;
                mappedRequest.status = "A";
                mappedRequest.strDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
                mappedRequest.strFromDate = DateTime.Now.AddYears(4).ToString("dd/MM/yyyy");
                mappedRequest.submitFlag = true;

                if (corporateAccountDetails.Title.Equals("MR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T100";
                    mappedRequest.titleId = 211;

                }
                else if (corporateAccountDetails.Title.Equals("DOCTOR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T106";
                    mappedRequest.titleId = 213;
                }
                else if (corporateAccountDetails.Title.Equals("PROFESSOR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T107";
                    mappedRequest.titleId = 217;
                }
                else if (corporateAccountDetails.Title.Equals("MRS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T101";
                    mappedRequest.titleId = 212;
                }
                else if (corporateAccountDetails.Title.Equals("MISS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T102";
                    mappedRequest.titleId = 221;
                }
                else if (corporateAccountDetails.Title.Equals("CHIEF", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T113";
                    mappedRequest.titleId = 336;
                }
                else
                {
                    mappedRequest.titleCd = "T114";
                    mappedRequest.titleId = 347;
                }

                if (corporateAccountDetails.CompanyBOIDiscover.Equals("RADIO", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 251;                   
                }
                else if(corporateAccountDetails.CompanyBOIDiscover.Equals("FRIEND", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 252;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("REFERRALS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 252;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("NEWSPAPER", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 353;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("TELEVISION", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 354;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("FACEBOOK", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("INSTAGRAM", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("INTERNET", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (corporateAccountDetails.CompanyBOIDiscover.Equals("TWITTER", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }

                StringBuilder createCorporateCustomerPayload = new StringBuilder();
                createCorporateCustomerPayload.Append("<soapenv:Envelope  \txmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                createCorporateCustomerPayload.Append("<soap:Header  \txmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                createCorporateCustomerPayload.Append("</soap:Header>");
                createCorporateCustomerPayload.Append("<soapenv:Body>");
                createCorporateCustomerPayload.Append("<cus:createCustomer  \txmlns:cus=\"http://customer.server.ws.supernova.neptunesoftware.com/\">");
                createCorporateCustomerPayload.Append("<arg0>");
                createCorporateCustomerPayload.Append("<!--DEFAULT VALUES:-->");
                createCorporateCustomerPayload.Append($"<channelId>{mappedRequest.channelId}</channelId>");
                createCorporateCustomerPayload.Append($"<serviceChannelCode>{mappedRequest.serviceChannelCode}</serviceChannelCode>");
                createCorporateCustomerPayload.Append($"<serviceId>{mappedRequest.serviceId}</serviceId>");
                createCorporateCustomerPayload.Append($"<transmissionTime>{mappedRequest.transmissionTime}</transmissionTime>");
                createCorporateCustomerPayload.Append($"<businessUnitCodeId>{mappedRequest.businessUnitCodeId}</businessUnitCodeId>");
                createCorporateCustomerPayload.Append("<!--BASIC INFO:-->");
                createCorporateCustomerPayload.Append($"<custShortName>{mappedRequest.firstName}</custShortName>");
                createCorporateCustomerPayload.Append($"<customerCategory>{mappedRequest.customerCategory}</customerCategory>");
                createCorporateCustomerPayload.Append($"<customerName>{mappedRequest.customerName}</customerName>");
                createCorporateCustomerPayload.Append($"<firstName>{mappedRequest.firstName}</firstName>");
                createCorporateCustomerPayload.Append("<!--ADDRESS DETAIL:-->");
                createCorporateCustomerPayload.Append($"<addressCity>{mappedRequest.addressCity}</addressCity>");
                createCorporateCustomerPayload.Append($"<addressCountryId>{mappedRequest.addressCountryId}</addressCountryId>");
                createCorporateCustomerPayload.Append($"<addressLine1>{mappedRequest.addressLine1}</addressLine1>");
                createCorporateCustomerPayload.Append("<addressLine2></addressLine2>");
                createCorporateCustomerPayload.Append($"<addressPropertyTypeId>{mappedRequest.addressPropertyTypeId}</addressPropertyTypeId>");
                createCorporateCustomerPayload.Append($"<addressState>{mappedRequest.addressState}</addressState>");
                createCorporateCustomerPayload.Append($"<addressTypeCd>{mappedRequest.addressTypeCd}</addressTypeCd>");
                createCorporateCustomerPayload.Append($"<addressTypeId>{mappedRequest.addressTypeId}</addressTypeId>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>{corporateAccountDetails.PhoneNumber}</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM100</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM100</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append($"<contactModeTypeId>206</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>{corporateAccountDetails.Email}</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM101</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM101</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append($"<contactModeTypeId>201</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>234</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM104</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM104</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append("<contactModeTypeId>204</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>{corporateAccountDetails.Email}</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM108</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM108</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append($"<contactModeTypeId>322</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>{corporateAccountDetails.Email}</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM108</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM109</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append($"<contactModeTypeId>323</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<contactsList>");
                createCorporateCustomerPayload.Append($"<contactDetails>{corporateAccountDetails.Email}</contactDetails>");
                createCorporateCustomerPayload.Append($"<contactMode>CM108</contactMode>");
                createCorporateCustomerPayload.Append($"<contactModeCategoryCode>CM102</contactModeCategoryCode>");
                createCorporateCustomerPayload.Append($"<contactModeTypeId>301</contactModeTypeId>");
                createCorporateCustomerPayload.Append($"<status>A</status>");
                createCorporateCustomerPayload.Append("</contactsList>");
                createCorporateCustomerPayload.Append("<!--COUNTRY:-->");
                createCorporateCustomerPayload.Append($"<countryId>{mappedRequest.countryId}</countryId>");
                createCorporateCustomerPayload.Append($"<countryOfBirthCd>{mappedRequest.countryOfBirthCd}</countryOfBirthCd>");
                createCorporateCustomerPayload.Append($"<countryOfBirthId>{mappedRequest.countryOfBirthId}</countryOfBirthId>");
                createCorporateCustomerPayload.Append($"<countryOfResidenceId>{mappedRequest.countryOfResidenceId}</countryOfResidenceId>");
                createCorporateCustomerPayload.Append($"<custCountryCd>{mappedRequest.custCountryCd}</custCountryCd>");
                createCorporateCustomerPayload.Append("<!--CUSTOMER TYPE INFO:-->");
                createCorporateCustomerPayload.Append($"<customerSegmentCd>{mappedRequest.customerSegmentCd}</customerSegmentCd>");
                createCorporateCustomerPayload.Append($"<customerTypeCd>{mappedRequest.customerTypeCd}</customerTypeCd>");
                createCorporateCustomerPayload.Append("<!--IDENTIFICATION INFO:-->");
                createCorporateCustomerPayload.Append("<identificationsList>");
                createCorporateCustomerPayload.Append($"<cityOfIssue>{mappedRequest.identificationsList.cityOfIssue}</cityOfIssue>");
                createCorporateCustomerPayload.Append($"<countryOfIssue>{mappedRequest.identificationsList.countryOfIssue}</countryOfIssue>");
                createCorporateCustomerPayload.Append($"<countryOfIssueId>{mappedRequest.identificationsList.countryOfIssueId}</countryOfIssueId>");
                createCorporateCustomerPayload.Append($"<identityNumber>{mappedRequest.registrationNumber}</identityNumber>");
                createCorporateCustomerPayload.Append($"<identityType>{mappedRequest.identificationsList.identityType}</identityType>");
                createCorporateCustomerPayload.Append($"<identityTypeId>{mappedRequest.identificationsList.identityTypeId}</identityTypeId>");
                createCorporateCustomerPayload.Append($"<strIssueDate>{mappedRequest.identificationsList.strIssueDate}</strIssueDate>");
                createCorporateCustomerPayload.Append($"<strExpiryDate>10/10/2029</strExpiryDate>");
                createCorporateCustomerPayload.Append($"<verifiedFlag>{mappedRequest.identificationsList.verifiedFlag}</verifiedFlag>");
                createCorporateCustomerPayload.Append("</identificationsList>");
                createCorporateCustomerPayload.Append($"<parentObjectCode>{mappedRequest.parentObjectCode}</parentObjectCode>");
                createCorporateCustomerPayload.Append($"<screenTypeCode>{mappedRequest.screenTypeCode}</screenTypeCode>");
                createCorporateCustomerPayload.Append($"<subTypeId>{mappedRequest.subTypeId}</subTypeId>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>52</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.LineOfBusiness}</fieldValueArr>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>54</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.BusinessCategory}</fieldValueArr>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>55</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.TotalAssetValue}</fieldValueArr>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>56</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.strRegistrationDate}</fieldValueArr>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>59</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.AuthorisedShareCapital}</fieldValueArr>");
                createCorporateCustomerPayload.Append($"<fieldIdArray>60</fieldIdArray>");
                createCorporateCustomerPayload.Append($"<fieldValueArr>{mappedRequest.PaidShareCapital}</fieldValueArr>");
                createCorporateCustomerPayload.Append("<!--OTHERS-->");
                createCorporateCustomerPayload.Append($"<industryCd>{mappedRequest.industryCd}</industryCd>");
                createCorporateCustomerPayload.Append($"<industryId>{mappedRequest.industryId}</industryId>");
                createCorporateCustomerPayload.Append($"<locale>{mappedRequest.locale}</locale>");
                createCorporateCustomerPayload.Append($"<mainBusinessUnitCd>{mappedRequest.mainBusinessUnitCd}</mainBusinessUnitCd>");
                createCorporateCustomerPayload.Append($"<mainBusinessUnitId>{mappedRequest.mainBusinessUnitId}</mainBusinessUnitId>");
                createCorporateCustomerPayload.Append("<!-- <marketingCampaignCd>MC112</marketingCampaignCd>-->");
                createCorporateCustomerPayload.Append($"<marketingCampaignId>{mappedRequest.marketingCampaignId}</marketingCampaignId>");
                createCorporateCustomerPayload.Append($"<nationalityCd>{mappedRequest.nationalityCd}</nationalityCd>");
                createCorporateCustomerPayload.Append($"<nationalityId>{mappedRequest.nationalityId}</nationalityId>");
                createCorporateCustomerPayload.Append($"<openingReasonCode>AO003</openingReasonCode>");
                createCorporateCustomerPayload.Append($"<openingReasonId>683</openingReasonId>");
                createCorporateCustomerPayload.Append($"<operationCurrencyCd>{mappedRequest.operationCurrencyCd}</operationCurrencyCd>");
                createCorporateCustomerPayload.Append($"<operationCurrencyId>{mappedRequest.operationCurrencyId}</operationCurrencyId>");
                createCorporateCustomerPayload.Append($"<primaryAddress>{mappedRequest.primaryAddress}</primaryAddress>");
                createCorporateCustomerPayload.Append($"<primaryRelationshipOfficerCd>{mappedRequest.primaryRelationshipOfficerCd}</primaryRelationshipOfficerCd>");
                createCorporateCustomerPayload.Append($"<propertyTypeCd>{mappedRequest.propertyTypeCd}</propertyTypeCd>");
                createCorporateCustomerPayload.Append("<!--  <relationshipOfficerOneId>871</relationshipOfficerOneId>-->");
                createCorporateCustomerPayload.Append($"<residentCountryCd>{mappedRequest.residentCountryCd}</residentCountryCd>");
                createCorporateCustomerPayload.Append($"<residentFlag>{mappedRequest.residentFlag}</residentFlag>");
                createCorporateCustomerPayload.Append($"<riskCode>RC100</riskCode>");
                createCorporateCustomerPayload.Append($"<riskCountryCd>NGA</riskCountryCd>");
                createCorporateCustomerPayload.Append($"<riskId>651</riskId>");
                createCorporateCustomerPayload.Append($"<serviceLevel>{mappedRequest.serviceLevel}</serviceLevel>");
                createCorporateCustomerPayload.Append($"<serviceLevelId>{mappedRequest.serviceLevelId}</serviceLevelId>");
                createCorporateCustomerPayload.Append($"<sourceOfFundCd>{mappedRequest.sourceOfFundCd}</sourceOfFundCd>");
                createCorporateCustomerPayload.Append($"<sourceOfFundId>{mappedRequest.sourceOfFundId}</sourceOfFundId>");
                createCorporateCustomerPayload.Append($"<status>{mappedRequest.status}</status>");
                createCorporateCustomerPayload.Append($"<strDate>{mappedRequest.strDate}</strDate>");
                createCorporateCustomerPayload.Append($"<strFromDate>{mappedRequest.strFromDate}</strFromDate>");
                createCorporateCustomerPayload.Append("<!--<startDateMm>05</startDateMm>-->");
                createCorporateCustomerPayload.Append("<!--<startDateYyyy>2022</startDateYyyy>-->");
                createCorporateCustomerPayload.Append($"<submitFlag>{mappedRequest.submitFlag}</submitFlag>");
                createCorporateCustomerPayload.Append($"<taxIdentificationNo>{mappedRequest.taxIdentificationNo}</taxIdentificationNo>");
                createCorporateCustomerPayload.Append($"<titleCd>{mappedRequest.titleCd}</titleCd>");
                createCorporateCustomerPayload.Append($"<titleId>{mappedRequest.titleId}</titleId>");
                createCorporateCustomerPayload.Append($"<organisationName>{mappedRequest.organisationName}</organisationName>");
                createCorporateCustomerPayload.Append($"<registrationNumber>{mappedRequest.registrationNumber}</registrationNumber>");
                createCorporateCustomerPayload.Append($"<strRegistrationDate>{mappedRequest.strRegistrationDate}</strRegistrationDate>");
                createCorporateCustomerPayload.Append("</arg0>");
                createCorporateCustomerPayload.Append("</cus:createCustomer>");
                createCorporateCustomerPayload.Append("</soapenv:Body>");
                createCorporateCustomerPayload.Append("\t</soapenv:Envelope>");

                string endPointType = "CorporateCustomerAccountCreation";
                CustomerCreationResponse response = (CustomerCreationResponse)await _rubikonBonitaRepository.CreateCustomerAccount(createCorporateCustomerPayload, mappedRequest.GetType().Name.ToString());
                if (response != null)
                {
                    customerNumber.CorporateCustomerNumber = response._return.customerNumber;
                    SubmitCustomerRequest submitCustomerRequest = new SubmitCustomerRequest { customerNo = response._return.customerNumber };
                    LinkPersonalCustomerToCorporateRequest linkPersonalCustomerToCorporateRequest = new LinkPersonalCustomerToCorporateRequest { corporateCustNo = customerNumber.CorporateCustomerNumber, personalCustNo = customerNumber.PersonalCustomerNumber };
                    var linkPersonalCustomer = await LinkPersonalCustomerToCorporateCustomer(linkPersonalCustomerToCorporateRequest);

                    var activateCustomer = await SubmitCustomerDetails(submitCustomerRequest);
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "Unable to create account. Please try again later." });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Please check the details for null or empty entry" });
        }

        /// <summary>
        /// An endpoint to Create Personal Customer Account
        /// </summary>
        /// <param name="personalAccountDetails"></param>
        /// <returns></returns>
        [HttpPost("/api/RubikonBonitaIntegrationAPI/CreatePersonalCustomerAaccount", Name = "CreatePersonalAccount")]
        public async Task<ActionResult<CustomerCreationResponse>> CreatePersonalAccount(AOIndividualShareholder personalAccountDetails)
        {
            if (ModelState.IsValid)
            {

                var mappedRequest = _mapper.Map<PersonalCustomerAccountCreation>(personalAccountDetails);
                //Default values are assigned below, note that they should be changed before go live
                mappedRequest.channelId = 121;
                mappedRequest.serviceChannelCode = "STC029";
                mappedRequest.serviceId = 121;
                mappedRequest.transmissionTime = "00";
                mappedRequest.businessUnitCodeId = "-99";
                mappedRequest.customerCategory = "PER";
                mappedRequest.employmentFlag = "E";
                mappedRequest.addressCountryId = 682;
                mappedRequest.addressPropertyTypeId = "422";
                mappedRequest.addressTypeCd = "AT100";
                mappedRequest.addressTypeId = 11;
                mappedRequest.contactsList = new List<ContactsList> {
                    new ContactsList { 
                        contactDetails = personalAccountDetails.PhoneNumber, 
                        contactMode ="CM100", 
                        contactModeCategoryCode = "CM100", 
                        contactModeTypeId = 206,
                        status = "A"
                    },
                    new ContactsList {
                        contactDetails = personalAccountDetails.Email,
                        contactMode ="CM101",
                        contactModeCategoryCode = "CM101",
                        contactModeTypeId = 201,
                        status = "A"
                    }
                };
                mappedRequest.parentObjectCode = "CUSTOMER";
                mappedRequest.screenTypeCode = "STATUTORY";
                mappedRequest.fieldIdArray = "242";
                mappedRequest.fieldValueArr = "15929";
                mappedRequest.countryId = 682;
                mappedRequest.countryOfBirthCd = "NGA";
                mappedRequest.countryOfBirthId = 682;
                mappedRequest.countryOfResidenceId = 682;
                mappedRequest.custCountryCd = "NGA";
                mappedRequest.identificationsList = new List<PersonalIdentificationList> {
                    new PersonalIdentificationList { 
                        cityOfIssue = "Abuja", 
                        countryOfIssue ="NGA", 
                        countryOfIssueId = 682, 
                        customerName = $"{personalAccountDetails.FirstName} {personalAccountDetails.FirstName}",         
                        identityNumber = DateTime.UtcNow.Ticks.ToString().Substring(0, 10),
                        identityType = "IT106", 
                        identityTypeId = 311, 
                        strIssueDate = "", 
                        strExpiryDate = "", 
                        verifiedFlag = true
                    },
                    new PersonalIdentificationList { 
                        cityOfIssue = "Abuja", 
                        countryOfIssue ="NGA", 
                        countryOfIssueId = 682, 
                        customerName = $"{personalAccountDetails.FirstName} {personalAccountDetails.FirstName}",         
                        identityNumber = DateTime.UtcNow.Ticks.ToString().Substring(0, 10), 
                        identityType = "BVN", 
                        identityTypeId = 492, 
                        strIssueDate = "", 
                        strExpiryDate = "", 
                        verifiedFlag = true
                    }
                };

                mappedRequest.customerSegmentCd = "CS107";
                mappedRequest.customerTypeCd = "CT100";
                mappedRequest.cityOfIssue = "LAGOS";
                mappedRequest.countryOfIssue = "NGA";
                mappedRequest.countryOfIssueId = "682";
                mappedRequest.industryCd = "SIC014";
                mappedRequest.industryId = 734;
                mappedRequest.locale = "en-US";
                mappedRequest.mainBusinessUnitCd = "001";
                mappedRequest.mainBusinessUnitId = "-99";
                mappedRequest.maritalStatus = "S";
                mappedRequest.middleName = "CIE";
                mappedRequest.nationalityCd = "N101";
                mappedRequest.nationalityId = 532;
                mappedRequest.operationCurrencyCd = "NGN";
                mappedRequest.operationCurrencyId = 732;
                mappedRequest.primaryAddress = true;
                mappedRequest.primaryRelationshipOfficerCd = "NEPTUNE";
                mappedRequest.propertyTypeCd = "PT109";
                mappedRequest.residentCountryCd = "NGA";
                mappedRequest.residentFlag = true;
                mappedRequest.serviceLevel = 400;
                mappedRequest.serviceLevelId = 164;
                mappedRequest.sourceOfFundCd = "SF002";
                mappedRequest.sourceOfFundId = 352;
                mappedRequest.status = "A";
                mappedRequest.strDate = DateTime.Now.Date.ToString("DD-MM-yyyy");
                mappedRequest.strFromDate = DateTime.Now.AddYears(4).ToString("dd-MM-yyyy");
                mappedRequest.submitFlag = true;
                if(personalAccountDetails.Title.Equals("MR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T100";
                    mappedRequest.titleId = 211;

                }
                else if (personalAccountDetails.Title.Equals("DOCTOR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T106";
                    mappedRequest.titleId = 213;
                }
                else if (personalAccountDetails.Title.Equals("PROFESSOR", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T107";
                    mappedRequest.titleId = 217;
                }
                else if (personalAccountDetails.Title.Equals("MRS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T101";
                    mappedRequest.titleId = 212;
                }
                else if (personalAccountDetails.Title.Equals("MISS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T102";
                    mappedRequest.titleId = 221;
                }
                else if (personalAccountDetails.Title.Equals("CHIEF", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.titleCd = "T113";
                    mappedRequest.titleId = 336;
                }
                else
                {
                    mappedRequest.titleCd = "T114";
                    mappedRequest.titleId = 347;
                }

                if (personalAccountDetails.CompanyBOIDiscover.Equals("RADIO", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 251;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("FRIEND", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 252;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("REFERRALS", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 252;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("NEWSPAPER", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 353;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("TELEVISION", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 354;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("FACEBOOK", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("INSTAGRAM", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("INTERNET", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }
                else if (personalAccountDetails.CompanyBOIDiscover.Equals("TWITTER", StringComparison.OrdinalIgnoreCase))
                {
                    mappedRequest.marketingCampaignId = 358;
                }

                StringBuilder createPersonalCustomerPayload = new StringBuilder();
                createPersonalCustomerPayload.Append("<soapenv:Envelope  \txmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                createPersonalCustomerPayload.Append("<soap:Header  \txmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                createPersonalCustomerPayload.Append("</soap:Header>");
                createPersonalCustomerPayload.Append("<soapenv:Body>");
                createPersonalCustomerPayload.Append("<cus:createCustomer  \txmlns:cus=\"http://customer.server.ws.supernova.neptunesoftware.com/\">");
                createPersonalCustomerPayload.Append("<arg0>");
                createPersonalCustomerPayload.Append("<!--DEFAULT VALUES:-->");
                createPersonalCustomerPayload.Append($"<channelId>{mappedRequest.channelId}</channelId>");
                createPersonalCustomerPayload.Append($"<serviceChannelCode>{mappedRequest.serviceChannelCode}</serviceChannelCode>");
                createPersonalCustomerPayload.Append($"<serviceId>{mappedRequest.serviceId}</serviceId>");
                createPersonalCustomerPayload.Append($"<transmissionTime>{mappedRequest.transmissionTime}</transmissionTime>");
                createPersonalCustomerPayload.Append($"<businessUnitCodeId>{mappedRequest.businessUnitCodeId}</businessUnitCodeId>");
                createPersonalCustomerPayload.Append("<!--BASIC INFO:-->");
                createPersonalCustomerPayload.Append($"<custShortName>{mappedRequest.firstName}</custShortName>");
                createPersonalCustomerPayload.Append($"<customerCategory>{mappedRequest.customerCategory}</customerCategory>");
                createPersonalCustomerPayload.Append($"<customerName>{mappedRequest.customerName}</customerName>");
                createPersonalCustomerPayload.Append($"<employmentFlag>{mappedRequest.employmentFlag}</employmentFlag>");
                createPersonalCustomerPayload.Append($"<firstName>{mappedRequest.firstName}</firstName>");
                createPersonalCustomerPayload.Append($"<lastName>{mappedRequest.lastName}</lastName>");
                createPersonalCustomerPayload.Append($"<fathersName>{mappedRequest.fathersName}</fathersName>");
                createPersonalCustomerPayload.Append($"<nationalIdNumber>{mappedRequest.nationalIdNumber}</nationalIdNumber>");
                createPersonalCustomerPayload.Append($"<gender>{mappedRequest.gender}</gender>");
                createPersonalCustomerPayload.Append("<!--ADDRESS DETAIL:-->");
                createPersonalCustomerPayload.Append($"<addressCity>{mappedRequest.addressCity}</addressCity>");
                createPersonalCustomerPayload.Append($"<addressCountryId>{mappedRequest.addressCountryId}</addressCountryId>");
                createPersonalCustomerPayload.Append($"<addressLine1>{mappedRequest.addressLine1}</addressLine1>");
                createPersonalCustomerPayload.Append($"<addressLine2>{mappedRequest.addressLine2}</addressLine2>");
                createPersonalCustomerPayload.Append($"<addressPropertyTypeId>{mappedRequest.addressPropertyTypeId}</addressPropertyTypeId>");
                createPersonalCustomerPayload.Append($"<addressState>{mappedRequest.addressState}</addressState>");
                createPersonalCustomerPayload.Append($"<addressTypeCd>{mappedRequest.addressTypeCd}</addressTypeCd>");
                createPersonalCustomerPayload.Append($"<addressTypeId>{mappedRequest.addressTypeId}</addressTypeId>");
                createPersonalCustomerPayload.Append("<contactsList>");
                createPersonalCustomerPayload.Append($"<contactDetails>{personalAccountDetails.Email}</contactDetails>");
                createPersonalCustomerPayload.Append("<contactMode>CM101</contactMode>");
                createPersonalCustomerPayload.Append("<contactModeCategoryCode>CM101</contactModeCategoryCode>");
                createPersonalCustomerPayload.Append("<contactModeTypeId>201</contactModeTypeId>");
                createPersonalCustomerPayload.Append($"<customerShortName>{mappedRequest.firstName}</customerShortName>");
                createPersonalCustomerPayload.Append("<status>A</status>");
                createPersonalCustomerPayload.Append("</contactsList>");
                createPersonalCustomerPayload.Append("<contactsList>");
                createPersonalCustomerPayload.Append($"<contactDetails>{personalAccountDetails.PhoneNumber}</contactDetails>");
                createPersonalCustomerPayload.Append("<contactMode>CM100</contactMode>");
                createPersonalCustomerPayload.Append("<contactModeCategoryCode>CM100</contactModeCategoryCode>");
                createPersonalCustomerPayload.Append("<contactModeTypeId>206</contactModeTypeId>");
                createPersonalCustomerPayload.Append($"<customerShortName>{mappedRequest.firstName}</customerShortName>");
                createPersonalCustomerPayload.Append("<status>A</status>");
                createPersonalCustomerPayload.Append("</contactsList>");
                createPersonalCustomerPayload.Append("<!--STATUTORY INFO:-->");
                createPersonalCustomerPayload.Append($"<parentObjectCode>{mappedRequest.parentObjectCode}</parentObjectCode>");
                createPersonalCustomerPayload.Append($"<screenTypeCode>{mappedRequest.screenTypeCode}</screenTypeCode>");
                createPersonalCustomerPayload.Append($"<subTypeId></subTypeId>");
                createPersonalCustomerPayload.Append($"<fieldIdArray>{mappedRequest.fieldIdArray}</fieldIdArray>");
                createPersonalCustomerPayload.Append($"<fieldValueArr>{mappedRequest.fieldValueArr}</fieldValueArr>");
                createPersonalCustomerPayload.Append("<!--COUNTRY:-->");
                createPersonalCustomerPayload.Append($"<countryId>{mappedRequest.countryId}</countryId>");
                createPersonalCustomerPayload.Append($"<countryOfBirthCd>{mappedRequest.countryOfBirthCd}</countryOfBirthCd>");
                createPersonalCustomerPayload.Append($"<countryOfBirthId>{mappedRequest.countryOfBirthId}</countryOfBirthId>");
                createPersonalCustomerPayload.Append($"<countryOfResidenceId>{mappedRequest.countryOfResidenceId}</countryOfResidenceId>");
                createPersonalCustomerPayload.Append($"<custCountryCd>{mappedRequest.custCountryCd}</custCountryCd>");
                createPersonalCustomerPayload.Append("<!--CUSTOMER TYPE INFO:-->");
                createPersonalCustomerPayload.Append($"<customerSegmentCd>{mappedRequest.customerSegmentCd}</customerSegmentCd>");
                createPersonalCustomerPayload.Append($"<customerTypeCd>{mappedRequest.customerTypeCd}</customerTypeCd>");
                createPersonalCustomerPayload.Append("<!--IDENTIFICATION INFO:-->");
                createPersonalCustomerPayload.Append("<!--national id:-->");
                createPersonalCustomerPayload.Append("<identificationsList>");
                createPersonalCustomerPayload.Append("<!-- <binaryImage></binaryImage> -->");
                createPersonalCustomerPayload.Append($"<cityOfIssue>{mappedRequest.cityOfIssue}</cityOfIssue>");
                createPersonalCustomerPayload.Append($"<countryOfIssue>{mappedRequest.countryOfIssue}</countryOfIssue>");
                createPersonalCustomerPayload.Append($"<countryOfIssueId>{mappedRequest.countryOfIssueId}</countryOfIssueId>");
                createPersonalCustomerPayload.Append($"<customerName>{personalAccountDetails.FirstName + " " + personalAccountDetails.Surname}</customerName>");
                createPersonalCustomerPayload.Append($"<identityNumber>{DateTime.UtcNow.Ticks.ToString().Substring(0, 10)}</identityNumber>");
                createPersonalCustomerPayload.Append("<identityType>IT106</identityType>");
                createPersonalCustomerPayload.Append("<identityTypeId>311</identityTypeId>");
                createPersonalCustomerPayload.Append("<strIssueDate>10/10/2010</strIssueDate>");
                createPersonalCustomerPayload.Append("<strExpiryDate>10/10/2029</strExpiryDate>");
                createPersonalCustomerPayload.Append("<verifiedFlag>true</verifiedFlag>");
                createPersonalCustomerPayload.Append("</identificationsList>");
                createPersonalCustomerPayload.Append(" <!--BVN INFO:-->");
                createPersonalCustomerPayload.Append("<identificationsList>");
                createPersonalCustomerPayload.Append("<!-- <binaryImage></binaryImage> -->");
                createPersonalCustomerPayload.Append($"<cityOfIssue>{mappedRequest.cityOfIssue}</cityOfIssue>");
                createPersonalCustomerPayload.Append($"<countryOfIssue>{mappedRequest.countryOfIssue}</countryOfIssue>");
                createPersonalCustomerPayload.Append($"<countryOfIssueId>{mappedRequest.countryOfIssueId}</countryOfIssueId>");
                createPersonalCustomerPayload.Append($"<customerName>{personalAccountDetails.FirstName + " " + personalAccountDetails.Surname}</customerName>");
                createPersonalCustomerPayload.Append($"<identityNumber>{DateTime.UtcNow.Ticks.ToString().Substring(0, 10)}</identityNumber>");
                createPersonalCustomerPayload.Append("<identityType>BVN</identityType>");
                createPersonalCustomerPayload.Append("<identityTypeId>492</identityTypeId>");
                createPersonalCustomerPayload.Append("<strIssueDate>10/10/2010</strIssueDate>");
                createPersonalCustomerPayload.Append("<!-- <strExpiryDate>10/10/2029</strExpiryDate>>-->");
                createPersonalCustomerPayload.Append("<verifiedFlag>true</verifiedFlag>");
                createPersonalCustomerPayload.Append("</identificationsList>");
                createPersonalCustomerPayload.Append("<!--END IDENTIFICATION INFO:-->");
                createPersonalCustomerPayload.Append("<!--OTHERS-->");
                createPersonalCustomerPayload.Append($"<industryCd>{mappedRequest.industryCd}</industryCd>");
                createPersonalCustomerPayload.Append($"<industryId>{mappedRequest.industryId}</industryId>");
                createPersonalCustomerPayload.Append($"<locale>{mappedRequest.locale}</locale>");
                createPersonalCustomerPayload.Append($"<mainBusinessUnitCd>{mappedRequest.mainBusinessUnitCd}</mainBusinessUnitCd>");
                createPersonalCustomerPayload.Append($"<mainBusinessUnitId>{mappedRequest.mainBusinessUnitId}</mainBusinessUnitId>");
                createPersonalCustomerPayload.Append("<!-- <marketingCampaignCd>MC112</marketingCampaignCd>-->");
                createPersonalCustomerPayload.Append($"<marketingCampaignId>{mappedRequest.marketingCampaignId}</marketingCampaignId>");
                createPersonalCustomerPayload.Append($"<maritalStatus>{mappedRequest.maritalStatus}</maritalStatus>");
                createPersonalCustomerPayload.Append($"<middleName>{mappedRequest.middleName}</middleName>");
                createPersonalCustomerPayload.Append($"<nationalityCd>{mappedRequest.nationalityCd}</nationalityCd>");
                createPersonalCustomerPayload.Append($"<nationalityId>{mappedRequest.nationalityId}</nationalityId>");
                createPersonalCustomerPayload.Append("<noOfDependents>0</noOfDependents>");
                createPersonalCustomerPayload.Append("<openingReasonCode>AO003</openingReasonCode>");
                createPersonalCustomerPayload.Append("<openingReasonId>683</openingReasonId>");
                createPersonalCustomerPayload.Append("<operationCurrencyCd>NGN</operationCurrencyCd>");
                createPersonalCustomerPayload.Append("<operationCurrencyId>732</operationCurrencyId>");
                createPersonalCustomerPayload.Append($"<preferredName>{mappedRequest.firstName}</preferredName>");
                createPersonalCustomerPayload.Append($"<primaryAddress>{mappedRequest.primaryAddress}</primaryAddress>");
                createPersonalCustomerPayload.Append($"<primaryRelationshipOfficerCd>{mappedRequest.primaryRelationshipOfficerCd}</primaryRelationshipOfficerCd>");
                createPersonalCustomerPayload.Append("<propertyTypeCd>PT107</propertyTypeCd>");
                createPersonalCustomerPayload.Append("<!--  <relationshipOfficerOneId>871</relationshipOfficerOneId>-->");
                createPersonalCustomerPayload.Append($"<residentCountryCd>{mappedRequest.residentCountryCd}</residentCountryCd>");
                createPersonalCustomerPayload.Append($"<residentFlag>{mappedRequest.residentFlag}</residentFlag>");
                createPersonalCustomerPayload.Append("<riskCode>RC100</riskCode>");
                createPersonalCustomerPayload.Append("<riskCountryCd>NGA</riskCountryCd>");
                createPersonalCustomerPayload.Append("<riskId>651</riskId>");
                createPersonalCustomerPayload.Append($"<serviceLevel>{mappedRequest.serviceLevel}</serviceLevel>");
                createPersonalCustomerPayload.Append($"<serviceLevelId>{mappedRequest.serviceLevelId}</serviceLevelId>");
                createPersonalCustomerPayload.Append($"<sourceOfFundCd>{mappedRequest.sourceOfFundCd}</sourceOfFundCd>");
                createPersonalCustomerPayload.Append($"<sourceOfFundId>{mappedRequest.sourceOfFundId}</sourceOfFundId>");
                createPersonalCustomerPayload.Append($"<status>{mappedRequest.status}</status>");
                createPersonalCustomerPayload.Append("<strDate>31/05/2022</strDate>");
                createPersonalCustomerPayload.Append("<strFromDate>31/05/2022</strFromDate>");
                createPersonalCustomerPayload.Append("<!--<startDateMm>05</startDateMm>-->");
                createPersonalCustomerPayload.Append("<!--<startDateYyyy>2022</startDateYyyy>-->");
                createPersonalCustomerPayload.Append($"<employmentFlag>{mappedRequest.employmentFlag}</employmentFlag>");
                createPersonalCustomerPayload.Append("<strDateOfBirth>02/05/1935</strDateOfBirth>");
                createPersonalCustomerPayload.Append($"<submitFlag>{mappedRequest.submitFlag}</submitFlag>");
                createPersonalCustomerPayload.Append($"<taxIdentificationNo>{mappedRequest.taxIdentificationNo}</taxIdentificationNo>");
                createPersonalCustomerPayload.Append($"<titleCd>{mappedRequest.titleCd}</titleCd>");
                createPersonalCustomerPayload.Append($"<titleId>{mappedRequest.titleId}</titleId>");
                createPersonalCustomerPayload.Append("</arg0>");
                createPersonalCustomerPayload.Append("</cus:createCustomer>");
                createPersonalCustomerPayload.Append("</soapenv:Body>");
                createPersonalCustomerPayload.Append("\t</soapenv:Envelope>");

                CustomerCreationResponse response = (CustomerCreationResponse)await _rubikonBonitaRepository.CreateCustomerAccount(createPersonalCustomerPayload, mappedRequest.GetType().Name.ToString());
                if (response != null)
                {
                    customerNumber.PersonalCustomerNumber = response._return.customerNumber;
                    SubmitCustomerRequest submitCustomerRequest = new SubmitCustomerRequest { customerNo = response._return.customerNumber };
                    var activateCustomer = await SubmitCustomerDetails(submitCustomerRequest);
                    
                    return Ok(response);
                }
                
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "Unable to create account. Please try again later." });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Please check the details for null or empty entry" });
        }

        /// <summary>
        /// An endpoint to Link Personal Customer to Corporate Customer
        /// </summary>
        /// <param name="accountLinkingDetails"></param>
        /// <returns></returns>
        [HttpPost("/api/RubikonBonitaIntegrationAPI/LinkPersonalCustomerToCorporateCustomer", Name = "LinkPersonalCustomerToCorporateCustomer")]
        public async Task<ActionResult<CustomerCreationResponse>> LinkPersonalCustomerToCorporateCustomer(LinkPersonalCustomerToCorporateRequest accountLinkingDetails)
        {
            if (ModelState.IsValid)
            {
                var mappedRequest = _mapper.Map<LinkPersonalCustomerToCorporateRequest>(accountLinkingDetails);
                mappedRequest.channelId = 121;
                mappedRequest.serviceChannelCode = "BONITA";
                mappedRequest.transmissionTime = "00";
                mappedRequest.businessUnitId = -99;
                mappedRequest.orgPositionId = 398;
                mappedRequest.orgPositionCode = "OP11O";
                mappedRequest.cityCode = "IFT";
                mappedRequest.stateCode = "OSN";
                mappedRequest.countryCode = "NGA";
                //mappedRequest.corporateCustNo = customerNumber.CorporateCustomerNumber;
                //mappedRequest.personalCustNo= customerNumber.PersonalCustomerNumber;


                var response = await _rubikonBonitaRepository.ExecuteActionOnCustomerAccount<LinkPersonalCustomerToCorporateRequest, LinkPersonalCustomerToCorporateResponse>(mappedRequest);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Unable to link account. Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Please check the details for null or empty entry" });
        }

        /// <summary>
        /// An endpoint to Submit Customer Details
        /// </summary>
        /// <param name="customerDetails"></param>
        /// <returns></returns>
        [HttpPost("/api/RubikonBonitaIntegrationAPI/SubmitCustomerDetails", Name = "SubmitCustomerDetails")]
        public async Task<ActionResult<SubmitAccountResponse>> SubmitCustomerDetails(SubmitCustomerRequest customerDetails)
        {
            if (ModelState.IsValid)
            {
                customerDetails.channelId = 121;
                customerDetails.serviceChannelCode = "STC053";
                customerDetails.serviceId = 121;
                customerDetails.transmissionTime = "00";

                var response = await _rubikonBonitaRepository.ExecuteActionOnCustomerAccount<SubmitCustomerRequest, SubmitAccountResponse>(customerDetails);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Unable to submit account. Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Please check the details for null or empty entry" });
        }
    }
}
