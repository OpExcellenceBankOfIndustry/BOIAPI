using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.MicroCreditLoan
{
    public interface IMCDropDownListRepository
    {
        Task<List<MCCollateralPledgedExistingLoan>> FetchAllCollateralPledgedExistingLoan();

        Task<List<MCCollateralTypeProposedCollateral>> FetchAllCollateralTypeProposedCollateral();

        Task<List<MCIndustrySector>> FetchAllIndustrySector();

        Task<List<MCLoanClass>> FetchAllLoanClass();

        Task<List<MCLoanPurpose>> FetchAllLoanPurpose();

        Task<List<MCLoanType>> FetchAllLoanType();

        Task<List<MCMoratorium>> FetchAllMoratorium();

        Task<List<MCProduct>> FetchAllProducts();

        Task<List<MCRepaymentPlan>> FetchAllRepaymentPlan();

        Task<List<MCSourceOfFund>> FetchAllSourceOfFunds();
    }
}
