using BOI.BOIApplications.AccountOpening.Interfaces;
using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOI.SecureApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IAuthService _authService;

        public AuthenticationController(ITokenHandler tokenHandler, IAuthService authService)
        {
            _tokenHandler = tokenHandler;
            _authService = authService;
        }

        [HttpPost]
        [Route("Authenticate")]

        public async Task<IActionResult> AuthenticateAsync( [FromBody]AuthenticateRequest authenticateRequest)
        {
            if (authenticateRequest == null || !ModelState.IsValid || string.IsNullOrEmpty(authenticateRequest.EmailOrUserName) || string.IsNullOrEmpty(authenticateRequest.Password))
            {
                string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));               
                return StatusCode(StatusCodes.Status404NotFound, new BaseResponse { Success = false, Message = messages + " Invalid Login details, Please check the detail and try again" });
            }

            var user = await _authService.AuthenticateAsync(authenticateRequest);

            if(user != null)
            {
                //Generate JWT Token
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Incorrect Username Or Password.");
        }
    }
}
