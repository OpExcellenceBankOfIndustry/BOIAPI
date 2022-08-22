using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOI.BOIApplications.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDetailCommandResponse>> Register([FromBody] UserDetailCommand userDetail)
        {
            var response = await _mediator.Send(userDetail);
            if(!response.Success) return BadRequest(response);
            return Ok(response);
           
        }

        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<ConfirmEmailCommandResponse>> ConfirmEmail(string email,  string code)
        {
            var userDetail = new ConfirmEmailCommand { email = email, code = code };
            var response = await _mediator.Send(userDetail);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
    }


}
