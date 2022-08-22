using BOI.BOIApplications.Application.Features.API.Identity.Authentication.Command;
using MediatR;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// An endpoint to generate Jwt token Based on credentials Supplied
        /// </summary>
        /// <param name="authenticateUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AuthenticateUserCommandResponse>> AuthenticateUser(AuthenticateUserCommand authenticateUser)
        {
            var response = await _mediator.Send(authenticateUser);
            return Ok(response);
        }
    }
}
