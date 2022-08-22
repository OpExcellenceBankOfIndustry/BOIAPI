using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
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
    public class AODropDownListController : ControllerBase
    {
        private IAODropDownListRepository _DropDownListRepo;

        public AODropDownListController(IAODropDownListRepository DropDownListRepo)
        {
            _DropDownListRepo = DropDownListRepo;
        }

        /// <summary>
        /// An endpoint to get All Banks
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/DropDownList/banks", Name = "GetAllBanks")]
        public async Task<ActionResult<Bank>> GetAllBanks()
        {
            var response = await _DropDownListRepo.FetchAllBanks();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Company Type
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/companyTypes", Name = "GetAllCompanyType")]
        public async Task<ActionResult<AOCompanyType>> GetAllCompanyType()
        {
            var response = await _DropDownListRepo.FetchAllCompanyType();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Marital Status
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/GetAllMaritalStatus", Name = "GetAllMaritalStatus")]
        public async Task<ActionResult<AOMaritalStatus>> GetAllMaritalStatus()
        {
            var response = await _DropDownListRepo.FetchAllMaritalStatus();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Annual Turnover
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/annualTurnovers", Name = "GetAllAnnualTurnover")]
        public async Task<ActionResult<AOAnnualTurnover>> GetAllAnnualTurnover()
        {
            var response = await _DropDownListRepo.FetchAllAnnualTurnover();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Identification Type
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/typesID", Name = "GetAllIdentificationType")]
        public async Task<ActionResult<AOIdentificationType>> GetAllIdentificationType()
        {
            var response = await _DropDownListRepo.FetchAllIdentificationType();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Stakeholder Capacity
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/GetAllStakeholderCapacity", Name = "GetAllStakeholderCapacity")]
        public async Task<ActionResult<AOStakeholderCapacity>> GetAllStakeholderCapacity()
        {
            var response = await _DropDownListRepo.FetchAllStakeholderCapacity();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Highest Educational Qualification
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/qualifications", Name = "GetAllHighestEducationalQualification")]
        public async Task<ActionResult<AOHighestEducationalQualification>> GetAllHighestEducationalQualification()
        {
            var response = await _DropDownListRepo.FetchAllHighestEducationalQualification();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Title
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/Title", Name = "GetAllTitle")]
        public async Task<ActionResult<AOTitle>> GetAllTitle()
        {
            var response = await _DropDownListRepo.FetchAllTitle();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Employees Relationship
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/employeesRelationships", Name = "GetAllEmployeesRelationship")]
        public async Task<ActionResult<AOEmployeesRelationship>> GetAllEmployeesRelationship()
        {
            var response = await _DropDownListRepo.FetchEmployeesRelationship();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Job Title
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/jobTitles", Name = "GetAllJobTitle")]
        public async Task<ActionResult<AOJobTitle>> GetAllJobTitle()
        {
            var response = await _DropDownListRepo.FetchAllJobTitle();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get Company BOI Discovery
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/AODropDownList/companyBOIDiscovers", Name = "GetCompanyBOIDiscover")]
        public async Task<ActionResult<AOCompanyBOIDiscover>> GetCompanyBOIDiscover()
        {
            var response = await _DropDownListRepo.FetchCompanyBOIDiscover();

            return Ok(response);
        }

    }
}
