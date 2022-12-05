using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using Microsoft.AspNetCore.Mvc;
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

        public RubikonBonitaIntegrationAPIController(IRubikonBonitaRepository rubikonBonitaRepository)
        {
            _rubikonBonitaRepository = rubikonBonitaRepository;
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
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid National Identification Number. Please check the detail and try again" });
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
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid Registration Number. Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "The Value Registration Number is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Create Corporate Customer Account
        /// </summary>
        /// <param name="corporateAccountDetails"></param>
        /// <returns></returns>
        [HttpPost("/api/RubikonBonitaIntegrationAPI/CreateCorporateCustomerAccount", Name = "CreateCorporateAccount")]
        public async Task<ActionResult<CustomerCreationResponse>> CreateCorporateAccount(CorporateCustomerAccountCreationRequest corporateAccountDetails)
            {

            if (ModelState.IsValid)
            {
                var response = await _rubikonBonitaRepository.CreateCustomerAccount(corporateAccountDetails);
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
        public async Task<ActionResult<CustomerCreationResponse>> CreatePersonalAccount(PersonalCustomerAccountCreationRequest personalAccountDetails)
        {
            if (ModelState.IsValid)
            {
                var response = await _rubikonBonitaRepository.CreateCustomerAccount(personalAccountDetails);
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
