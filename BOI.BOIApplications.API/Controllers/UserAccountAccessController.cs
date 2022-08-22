using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserAccountAccessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAccountAccessController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Authenticate")]
        public async Task<ActionResult<LoginQueryResponse>> Authenticate([FromBody] LoginQuery model)
        {
            var response = await _mediator.Send(model);
            if (!response.Success) return BadRequest(response);            
            return Ok(response);
        }
        [HttpPost("ForgetPassword")]
        public async Task<ActionResult<ForgetPasswordCommandResponse>> ForgetPassword([FromBody] ForgetPasswordCommand model)
        {
            var response = await _mediator.Send(model);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<ChangePasswordCommandResponse>> ChangePassword([FromBody] ChangePasswordCommand model)
        {
            var response = await _mediator.Send(model);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        
    }
}
