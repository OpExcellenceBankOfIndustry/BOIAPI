using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd;

namespace BOI.BOIApplications.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AccountOpeningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountOpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }



        /// <summary>
        /// An endpoint to add Company Information
        /// </summary>
        /// <param name="companyInformCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/CompanyInform")]
        public async Task<ActionResult<CompanyInformCommandResponse>> PostCompanyInform([FromForm]CompanyInformCommand companyInformCommand)
        {
            var response = await _mediator.Send(companyInformCommand);
            return Ok(response);
        }


        /// <summary>
        /// An endpoint to add Regulatory Information
        /// </summary>
        /// <param name="regulatoryInformCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/RegulatoryInform")]
        public async Task<ActionResult<RegulatoryInformCommandResponse>> PostRegulatoryInform([FromForm]RegulatoryInformCommand regulatoryInformCommand)
        {
            DateTime dateTime = DateTime.Now;
            var response = await _mediator.Send(regulatoryInformCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Related Party Information
        /// </summary>
        /// <param name="relatedPartyInformCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/RelatedPartyInform")]
        public async Task<ActionResult<RelatedPartyInformCommandResponse>> PostRelatedPartyInform(RelatedPartyInformCommand relatedPartyInformCommand)
        {
            var response = await _mediator.Send(relatedPartyInformCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Account Details of Owner Information
        /// </summary>
        /// <param name="accountDetailsOfOwnerCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/AccountDetailsOfOwner")]
        public async Task<ActionResult<AccountDetailsOfOwnerCommandResponse>> PostAccountDetailsOfOwner(List<AccountDetailsOfOwnerViewModel> accountDetailsOfOwnerCommand)
        {
            var response = await _mediator.Send(new AccountDetailsOfOwnerCommand(accountDetailsOfOwnerCommand));
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Details of Next Of Kin Information
        /// </summary>
        /// <param name="detailsOfNextOfKinCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/DetailsOfNextOfKin")]
        public async Task<ActionResult<DetailsOfNextOfKinCommandResponse>> PostDetailsOfNextOfKin(List<DetailsOfNextOfKinViewModel> detailsOfNextOfKinCommand)
        {
            var response = await _mediator.Send(new DetailsOfNextOfKinCommand(detailsOfNextOfKinCommand));
            //var response = await _mediator.Send(detailsOfNextOfKinCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Sole Proprietorship Information
        /// </summary>
        /// <param name="soleProprietorshipCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/SoleProprietorship")]
        public async Task<ActionResult<SoleProprietorshipCommandResponse>> PostSoleProprietorship([FromForm] SoleProprietorshipCommand soleProprietorshipCommand)
        {
            var response = await _mediator.Send(soleProprietorshipCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Cooperate Ownership Information
        /// </summary>
        /// <param name="ownershipInformCoopCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/OwnershipInformCoop")]
        public async Task<ActionResult<OwnershipInformCoopCommandResponse>> PostOwnershipInformCoop([FromForm] OwnershipInformCoopCommand ownershipInformCoopCommand)
        {
            var response = await _mediator.Send(ownershipInformCoopCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to add Individual Ownership Information
        /// </summary>
        /// <param name="ownershipInformIndCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/accountOpening/OwnershipInformInd")]
        public async Task<ActionResult<OwnershipInformIndCommandResponse>> PostOwnershipInformInd([FromForm]OwnershipInformIndCommand ownershipInformIndCommand)
        {
            var response = await _mediator.Send(ownershipInformIndCommand);
            return Ok(response);
        }
    }
}
