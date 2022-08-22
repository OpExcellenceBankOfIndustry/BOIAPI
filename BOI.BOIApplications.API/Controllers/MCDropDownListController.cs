using BOI.BOIApplications.Application.Contracts.MicroCreditLoan;
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
    public class MCDropDownListController : ControllerBase
    {
        private readonly IMCDropDownListRepository _DropDownListRepo;

        public MCDropDownListController(IMCDropDownListRepository DropDownListRepo)
        {
            _DropDownListRepo = DropDownListRepo;
        }

        /// <summary>
        /// An endpoint to get All Collateral Pledged and Existing Loan
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/pledgedCollaterals", Name = "GetAllCollateralPledgedExistingLoan")]
        public async Task<ActionResult<MCCollateralPledgedExistingLoan>> GetAllCollateralPledgedExistingLoan()
        {
            var response = await _DropDownListRepo.FetchAllCollateralPledgedExistingLoan();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Collateral Type and Proposed Collateral
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/collateralTypes", Name = "GetAllCollateralTypeProposedCollateral")]
        public async Task<ActionResult<MCCollateralTypeProposedCollateral>> GetAllCollateralTypeProposedCollateral()
        {
            var response = await _DropDownListRepo.FetchAllCollateralTypeProposedCollateral();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Industry Sector
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/industrialSectors", Name = "GetAllIndustrySector")]
        public async Task<ActionResult<MCIndustrySector>> GetAllIndustrySector()
        {
            var response = await _DropDownListRepo.FetchAllIndustrySector();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Loan Class
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/loanClasses", Name = "GetAllLoanClass")]
        public async Task<ActionResult<MCLoanClass>> GetAllLoanClass()
        {
            var response = await _DropDownListRepo.FetchAllLoanClass();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Loan Purpose
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/loanPurposes", Name = "GetAllLoanPurpose")]
        public async Task<ActionResult<MCLoanPurpose>> GetAllLoanPurpose()
        {
            var response = await _DropDownListRepo.FetchAllLoanPurpose();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Loan Type
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/loanTypes", Name = "GetAllLoanType")]
        public async Task<ActionResult<MCLoanType>> GetAllLoanType()
        {
            var response = await _DropDownListRepo.FetchAllLoanType();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Moratorium
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/moratoriums", Name = "GetAllMoratorium")]
        public async Task<ActionResult<MCMoratorium>> GetAllMoratorium()
        {
            var response = await _DropDownListRepo.FetchAllMoratorium();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Product
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/products", Name = "GetAllProduct")]
        public async Task<ActionResult<MCProduct>> GetAllProduct()
        {
            var response = await _DropDownListRepo.FetchAllProducts();

            return Ok(response);
        }
        /// <summary>
        /// An endpoint to get All Repayment Plan
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/repaymentPlans", Name = "GetAllRepaymentPlan")]
        public async Task<ActionResult<MCRepaymentPlan>> GetAllRepaymentPlan()
        {
            var response = await _DropDownListRepo.FetchAllRepaymentPlan();

            return Ok(response);
        }

        /// <summary>
        /// An endpoint to get All Source Of Funds
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MCDropDownList/fundSources", Name = "GetAllSourceOfFunds")]
        public async Task<ActionResult<MCSourceOfFund>> GetAllSourceOfFunds()
        {
            var response = await _DropDownListRepo.FetchAllSourceOfFunds();

            return Ok(response);
        }
    }
}
