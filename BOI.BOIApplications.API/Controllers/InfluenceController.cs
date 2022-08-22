using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetAllCorporateWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetAllFEPs;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetAllIndividualWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Comamnd.AddPEPs;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetAllPeps;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN;
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
    public class InfluenceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InfluenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// An endpoint to get All Financially exposed persons
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Influence/Feps", Name = "GetAllFEPs")]
        public async Task<ActionResult<GetAllFEPQueryResponse>> GetAllFEPs()
        {
            var getAllFEPsQuery = new GetAllFEPQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllFEPsQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get A Financialy exposed person by BVN
        /// </summary>
        /// <param name="fepBvn"></param>
        /// <returns></returns>
        [HttpGet("/api/Influence/Feps/{fepBvn}", Name = "GetFepsByBvn")]
        public async Task<ActionResult<GetFEPsByBVNQueryResponse>> GetFepsByBvn(string fepBvn)
        {
            var getFepsByBvnQuery = new GetFepsByBvnQuery() { FepBvn = fepBvn, BypassCache = false };
            var response = await _mediator.Send(getFepsByBvnQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint add Financially exposed person
        /// </summary>
        /// <param name="fepCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/Influence/Feps", Name = "AddFEP")]
        public async Task<ActionResult<FEPCommandResponse>> AddFEP(FEPCommand fepCommand)
        {
            var response = await _mediator.Send(fepCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint add Politically exposed person
        /// </summary>
        /// <param name="pepCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/Influence/Peps", Name = "AddPEP")]
        public async Task<ActionResult<AddPEPCommandResponse>> AddPEP(AddPEPCommand pepCommand)
        {
            var response = await _mediator.Send(pepCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Politically exposed persons
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Influence/Peps", Name = "GetAllPEPs")]
        public async Task<ActionResult<GetAllPEPQueryResponse>> GetAllPEPs()
        {
            var getAllPEPsQuery = new GetAllPepQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllPEPsQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get A politicallyu exposed person by BVN
        /// </summary>
        /// <param name="pepBvn"></param>
        /// <returns></returns>
        [HttpGet("/api/Influence/Peps/{pepBvn}", Name = "GetPepsByBvn")]
        public async Task<ActionResult<GetPEPByBVNQueryResponse>> GetpepsByBvn(string pepBvn)
        {
            var getpepsByBvnQuery = new GetPEPByBVNQuery() { PepBvn = pepBvn, BypassCache = false };
            var response = await _mediator.Send(getpepsByBvnQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint add new companies to corporate watch list 
        /// </summary>
        /// <param name="corporateWatchListsCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/Influence/CorporateWatchLists", Name = "AddCorporateWatchLists")]
        public async Task<ActionResult<AddCorporateWatchListsCommandResponse>> AddCorporateWatchLists(AddCorporateWatchListsCommand corporateWatchListsCommand)
        {
            var response = await _mediator.Send(corporateWatchListsCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All companies added to corporate watch list 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Influence/CorporateWatchLists", Name = "GetAllCorporateWatchLists")]
        public async Task<ActionResult<GetAllCorporateWatchListsQueryResponse>> GetAllCorporateWatchLists()
        {
            var getAllFEPsQuery = new GetAllCorporateWatchListsQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllFEPsQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get a companies added to corporate watch list based on registration number supplied
        /// </summary>
        /// <param name="companyRegistrationNumber"></param>
        /// <returns></returns>
        [HttpGet("/api/Influence/CorporateWatchLists/{companyRegistrationNumber}", 
            Name = "GetCorporateWatchListsBycompanyRegistrationNumber")]
        public async Task<ActionResult<GetCorporateWatchListByCompanyRegQueryResponse>> GetCorporateWatchListsBycompanyRegistrationNumber(string companyRegistrationNumber)
        {
            var getCorporateWatchListByCompanyRegQuery = new GetCorporateWatchListByCompanyRegQuery() 
            {
                CompanyRegistrationNumber = companyRegistrationNumber,
                BypassCache = false 
            };
            var response = await _mediator.Send(getCorporateWatchListByCompanyRegQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint add new Individuals to individual watch list 
        /// </summary>
        /// <param name="individualWatchListCommand"></param>
        /// <returns></returns>
        [HttpPost("/api/Influence/IndividualWatchLists", Name = "AddIndividualWatchLists")]
        public async Task<ActionResult<AddIndividualWatchListCommandResponse>> AddIndividualWatchLists(AddIndividualWatchListCommand individualWatchListCommand)
        {
            var response = await _mediator.Send(individualWatchListCommand);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get all individuals added to individual watch list 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/Influence/IndividualWatchLists", Name = "GetAllIndividualWatchLists")]
        public async Task<ActionResult<GetAllIndividualWatchListsQueryResponse>> GetAllIndividualWatchLists()
        {
            var getAllIndividualWatchListsQuery = new GetAllIndividualWatchListsQuery() { BypassCache = false };
            var response = await _mediator.Send(getAllIndividualWatchListsQuery);
            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get a companies added to corporate watch list based on registration number supplied
        /// </summary>
        /// <param name="individualBvn"></param>
        /// <returns></returns>
        [HttpGet("/api/Influence/IndividualWatchLists/{individualBvn}",
            Name = "GetIndividualWatchListsByBVN")]
        public async Task<ActionResult<GetIndividualWatchListsByBVNResponse>> GetIndividualWatchListsByBVN(string individualBvn)
        {
            var getIndividualWatchListsByBVNQuery = new GetIndividualWatchListsByBVNQuery()
            {
                IndividualBvn = individualBvn,
                BypassCache = false
            };
            var response = await _mediator.Send(getIndividualWatchListsByBVNQuery);
            return Ok(response);
        }
    }
}
