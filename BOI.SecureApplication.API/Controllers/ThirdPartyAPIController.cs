using BOI.BOIApplications.Application.Contracts.ThirdPartyAPI;
using BOI.BOIApplications.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOI.SecureApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Authorize(Roles = "PWC")]
        public async Task<IActionResult> CheckCustomerBVN([FromQuery] string BVN)
        {
            if (!string.IsNullOrEmpty(BVN))
            {
                var response = await _thirdPartyAPIRepository.FetchCustomerBVN(BVN);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = "Invalid BVN, Please check the detail and try again" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { Success = false, Message = "The Value BVN is Null or Empty" });
        }

        /// <summary>
        /// An endpoint to Check Business CAC
        /// </summary>
        /// <param name="CAC"></param>
        /// <returns></returns>
        [HttpPost("/api/ThirdPartyAPI/CheckBusinessCAC")]
        [Authorize(Roles = "PWC")]
        public async Task<IActionResult> CheckBusinessCAC([FromQuery] string CAC)
        {

            if (!string.IsNullOrEmpty(CAC))
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
    }
}
