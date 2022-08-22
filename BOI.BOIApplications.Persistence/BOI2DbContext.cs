using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence
{
    public class BOI2DbContext : DbContext
    {
        public BOI2DbContext(DbContextOptions<BOI2DbContext> options) : base(options)
        {

        }
        //Micro Credit Dropdown Details
        public DbSet<MCCollateralPledgedExistingLoan> MCCollateralPledgedExistingLoans { get; set; }
        public DbSet<MCCollateralTypeProposedCollateral> MCCollateralTypeProposedCollateral { get; set; }
        public DbSet<MCIndustrySector> MCIndustrySector { get; set; }
        public DbSet<MCLoanClass> MCLoanClass { get; set; }
        public DbSet<MCLoanPurpose> MCLoanPurpose { get; set; }
        public DbSet<MCLoanType> MCLoanType { get; set; }
        public DbSet<MCMoratorium> MCMoratorium { get; set; }
        public DbSet<MCProduct> MCProducts { get; set; }
        public DbSet<MCRepaymentPlan> MCRepaymentPlan { get; set; }
        public DbSet<MCSourceOfFund> MCSourceOfFunds { get; set; }

        //Account Opening Dropdown Details
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AOCompanyType> AOCompanyType { get; set; }
        public DbSet<AOMaritalStatus> AOMaritalStatus { get; set; }
        public DbSet<AOAnnualTurnover> AOAnnualTurnover { get; set; }
        public DbSet<AOIdentificationType> AOIdentificationType { get; set; }
        public DbSet<AOStakeholderCapacity> AOStakeholderCapacity { get; set; }
        public DbSet<AOHighestEducationalQualification> AOHighestEducationalQualification { get; set; }
        public DbSet<AOTitle> AOTitle { get; set; }

    }
}
