using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.MicroCreditModels
{
   
    public class Bank
    {
        [Key]
        //public int bank_id { get; set; }
        //public string? bank { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
    }

    public class MCCollateralPledgedExistingLoan
    {
        [Key]
        //public int collateral_id { get; set; }
        //public string? collateral_pledged { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }

    public class MCCollateralTypeProposedCollateral
    {
        [Key]
        //public int collateral_id { get; set; }
        //public string? collateral_type_proposed { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCIndustrySector
    {
        [Key]
        //public int ind_id { get; set; }
        //public string? sector { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCLoanClass
    {
        [Key]
        //public int loan_class_id { get; set; }
        //public string? loan_class { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCLoanPurpose
    {
        [Key]
        //public int loan_purpose_id { get; set; }
        //public string? loan_purpose { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCLoanType
    {
        [Key]
        //public int loan_type_id { get; set; }
        //public string? loan_type { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
    }
    public class MCMoratorium
    {
        [Key]
        //public int moratorium_id { get; set; }
        //public string? moratorium { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCProduct
    {
        [Key]
        //public int product_id { get; set; }
        //public string? product { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCRepaymentPlan
    {
        [Key]
        //public int repayment_plan_id { get; set; }
        //public string? repayment_plan { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class MCSourceOfFund
    {
        [Key]
        //public int source_id { get; set; }
        //public string? source_funds { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }


}
