using AutoMapper;
using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection;
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

                var mappedRequest = _mapper.Map<CorporateCustomerAccountCreation>(corporateAccountDetails);
                //Default values are assigned below, note that they should be changed before go live
                mappedRequest.channelId = 121;
                mappedRequest.serviceChannelCode = "STC029";
                mappedRequest.serviceId = 121;
                mappedRequest.transmissionTime = 00;
                mappedRequest.businessUnitCodeId = -99;
                mappedRequest.customerCategory = "COR";
                mappedRequest.addressCountryId = 121;
                mappedRequest.addressPropertyTypeId = "PT102";
                mappedRequest.addressTypeCd = "AT103";
                mappedRequest.addressTypeId = 15;
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

                mappedRequest.parentObjectCode = "Customer";
                mappedRequest.screenTypeCode = "Custom";
                mappedRequest.subTypeId = 722;
                mappedRequest.industryCd = "SIC014";
                mappedRequest.industryId = 734;
                mappedRequest.locale = "en-GB";
                mappedRequest.mainBusinessUnitCd = 001;
                mappedRequest.mainBusinessUnitId = -99;
                mappedRequest.nationalityCd = "N101";
                mappedRequest.nationalityId = 532;
                mappedRequest.operationCurrencyCd = "NGN";
                mappedRequest.operationCurrencyId = 732;
                mappedRequest.primaryAddress = true;
                mappedRequest.primaryRelationshipOfficerCd = "NEPTUNE";
                mappedRequest.propertyTypeCd = "PT107";
                mappedRequest.residentCountryCd = "NGN";
                mappedRequest.residentFlag = true;
                mappedRequest.serviceLevel = 400;
                mappedRequest.serviceLevelId = 164;
                mappedRequest.sourceOfFundCd = "SF002";
                mappedRequest.sourceOfFundId = 352;
                mappedRequest.status = "A";
                mappedRequest.strDate = DateTime.Now.Date.ToString("DD-MM-yyyy");
                mappedRequest.strFromDate = DateTime.Now.AddYears(4).ToString("dd-MM-yyyy");
                mappedRequest.submitFlag = true;
               

                var response = await _rubikonBonitaRepository.CreateCustomerAccount(mappedRequest);
                if (response != null)
                {
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
                mappedRequest.transmissionTime = 00;
                mappedRequest.customerCategory = "PER";
                mappedRequest.employmentFlag = "E";
                mappedRequest.addressCountryId = 882;
                mappedRequest.addressPropertyTypeId = "462";
                mappedRequest.addressTypeCd = "AT107";
                mappedRequest.addressTypeId = 133;
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
                mappedRequest.parentObjectCode = "Customer";
                mappedRequest.screenTypeCode = "Statutory";
                mappedRequest.fieldIdArray = "242";
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
                        identityNumber = DateTime.UtcNow.Ticks.ToString().Substring(11), identityType = "IT106", 
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
                        identityNumber = DateTime.UtcNow.Ticks.ToString().Substring(11), 
                        identityType = "BVN", 
                        identityTypeId = 492, 
                        strIssueDate = "", 
                        strExpiryDate = "", 
                        verifiedFlag = true
                    }
                };

                mappedRequest.customerSegmentCd = "CS107";
                mappedRequest.customerTypeCd = "CT100";
                mappedRequest.industryCd = "SIC014";
                mappedRequest.industryId = 734;
                mappedRequest.locale = "en-GB";
                mappedRequest.mainBusinessUnitCd = 001;
                mappedRequest.mainBusinessUnitId = -99;
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
                mappedRequest.employmentFlag = "false";
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

                var response = await _rubikonBonitaRepository.CreateCustomerAccount(mappedRequest);
                if (response != null)
                {
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
                var response = await _rubikonBonitaRepository.ExecuteActionOnCustomerAccount<LinkPersonalCustomerToCorporateRequest, LinkPersonalCustomerToCorporateResponse>(accountLinkingDetails);
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
