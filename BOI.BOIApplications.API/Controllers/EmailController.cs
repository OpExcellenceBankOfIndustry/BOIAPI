using BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOI.BOIApplications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// An endpoint to Enqueue email which would be senyt later on
        /// </summary>
        /// <param name="enqueueEmail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EnqueueEmailCommandResponse>> EnqueueEmail(EnqueueEmailCommand enqueueEmail)
        {
            var response = await _mediator.Send(enqueueEmail);
            return Ok(response);
        }
    }
}
