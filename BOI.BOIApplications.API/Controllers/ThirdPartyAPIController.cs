using BOI.BOIApplications.Application.Contracts.ThirdPartyAPI;
using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOI.BOIApplications.API.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class ThirdPartyAPIController : ControllerBase
    {
        private readonly IThirdPartyAPIRepository _thirdPartyAPIRepository;

        public ThirdPartyAPIController(IThirdPartyAPIRepository thirdPartyAPIRepository)
        {
            _thirdPartyAPIRepository = thirdPartyAPIRepository;
        }

       
        /// <summary>
        /// An endpoint to Check Customer BVN
        /// </summary>
        /// <param name="BVN"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckCustomerBVN")]
        public async Task<IActionResult> CheckCustomerBVN([FromBody] PersonalIdentificationRequest model)
        {
            if(ModelState.IsValid && model != null)
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerBVN(model);
                if(response != null)
                {                   
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid BVN, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value BVN is Null or Empty" });
        }
        /// <summary>
        /// An endpoint to Check Customer NIN
        /// </summary>
        /// <param name="NIN"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckCustomerNIN")]
        public async Task<ActionResult<CustomerNINResponse>> CheckCustomerNIN([FromBody] PersonalIdentificationRequest model)
        {
          
            if (ModelState.IsValid && model != null)
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerNIN(model);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid NIN, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value NIN is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Check Customer PVC
        /// </summary>
        /// <param name="PVC"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckCustomerPVC")]
        public async Task<ActionResult<CustomerPVCResponse>> CheckCustomerPVC([FromBody] PersonalIdentificationRequest model)
        {
            
            if (ModelState.IsValid && model != null)
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerPVC(model);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid PVC, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value PVC is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Check Customer INP
        /// </summary>
        /// <param name="INP"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckCustomerINP")]
        public async Task<ActionResult<CustomerINTLPassportResponse>> CheckCustomerINP([FromBody] PersonalIdentificationRequest model)
        {
            
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.idNumber) && !string.IsNullOrWhiteSpace(model.lastName))
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerINP(model);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid International passport Number, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value International passport Number or LastName is Null or Empty" });
        }
        /// <summary>
        /// An endpoint to Check Customer NDL
        /// </summary>
        /// <param name="NDL"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckCustomerNDL")]
        public async Task<ActionResult<CustomerNINResponse>> CheckCustomerNDL([FromBody] PersonalIdentificationRequest model)
        {
           
            if (ModelState.IsValid && model != null)
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerNDL(model);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid NDL, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value NDL is Null or Empty" });
        }


        /// <summary>
        /// An endpoint to Check Business CAC
        /// </summary>
        /// <param name="CAC"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckBusinessCAC")]
        public async Task<ActionResult<BusinessCACResponse>> CheckBusinessCAC([FromForm] string CAC)
        {
            
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(CAC))
            {
                var response = await _thirdPartyAPIRepository.FetchBusinessCAC(CAC);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid CAC, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value CAC is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Check Business TIN
        /// </summary>
        /// <param name="TIN"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckBusinessTIN")]
        public async Task<ActionResult<BusinessTINResponse>> CheckBusinessTIN([FromForm] string TIN)
        {
           
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(TIN))
            {
                var response = await _thirdPartyAPIRepository.FetchBusinessTIN(TIN);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid TIN, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value TIN is Null or Empty" });
        }
    }
}
