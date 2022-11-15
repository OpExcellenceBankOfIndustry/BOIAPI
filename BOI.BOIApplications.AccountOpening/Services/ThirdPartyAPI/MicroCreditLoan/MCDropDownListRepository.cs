using BOI.BOIApplications.Application.Contracts.MicroCreditLoan;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services.MicroCreditLoan
{
    public class MCDropDownListRepository : IMCDropDownListRepository
    {
        private readonly BOI2DbContext _dbc;

        public MCDropDownListRepository(BOI2DbContext dbc)
        {
            _dbc = dbc;
        }
        public async Task<List<MCCollateralPledgedExistingLoan>> FetchAllCollateralPledgedExistingLoan()
        {
            try
            {
                var collateralPledgedExistingLoan = await _dbc.MCCollateralPledgedExistingLoans.OrderBy(e => e.name).ToListAsync();

                return collateralPledgedExistingLoan;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<MCCollateralTypeProposedCollateral>> FetchAllCollateralTypeProposedCollateral()
        {
            try
            {
                var collateralTypeProposedCollateral = await _dbc.MCCollateralTypeProposedCollateral.OrderBy(e => e.name).ToListAsync();

                return collateralTypeProposedCollateral;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<MCIndustrySector>> FetchAllIndustrySector()
        {
            try
            {
                var industrySector = await _dbc.MCIndustrySector.OrderBy(e => e.name).ToListAsync();

                return industrySector;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<MCLoanClass>> FetchAllLoanClass()
        {
            try
            {
                var loanClass = await _dbc.MCLoanClass.ToListAsync();

                return loanClass;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<MCLoanPurpose>> FetchAllLoanPurpose()
        {
            try
            {
                var loanPurpose = await _dbc.MCLoanPurpose.OrderBy(e => e.name).ToListAsync();

                return loanPurpose;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MCLoanType>> FetchAllLoanType()
        {
            try
            {
                var loanType = await _dbc.MCLoanType.ToListAsync();

                return loanType;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<MCMoratorium>> FetchAllMoratorium()
        {
            try
            {
                var moratorium = await _dbc.MCMoratorium.ToListAsync();

                return moratorium;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MCProduct>> FetchAllProducts()
        {
            try
            {
                var products = await _dbc.MCProducts.OrderBy(e => e.name).ToListAsync();

                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<MCRepaymentPlan>> FetchAllRepaymentPlan()
        {
            try
            {
                var repaymentPlan = await _dbc.MCRepaymentPlan.ToListAsync();

                return repaymentPlan;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MCSourceOfFund>> FetchAllSourceOfFunds()
        {
            try
            {
                var sourceOfFunds = await _dbc.MCSourceOfFunds.OrderBy(e => e.name).ToListAsync();

                return sourceOfFunds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
