using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.AccountOpeningModels
{
    public class AODropdownlist
    {

    }
    public class AOCompanyType
    {
        [Key]
       // public int company_type_id { get; set; }
       // public string? company_type { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOMaritalStatus
    {
        [Key]
        //public int Id { get; set; }
        //public string? MaritalStatus { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOAnnualTurnover
    {
        [Key]
        //public int Id { get; set; }
        //public string? AnnualTurnover { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOIdentificationType
    {
        [Key]
        //public int Id { get; set; }
        //public string? IdentificationType { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOStakeholderCapacity
    {
        [Key]
        //public int Id { get; set; }
        //public string? StakeholderCapacity { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOHighestEducationalQualification
    {
        [Key]
        //public int Id { get; set; }
        //public string? HighestEducationalQualification { get; set; }
        public int id { get; set; }
        public string? name { get; set; }

    }
    public class AOTitle
    {
        [Key]
        //public int Id { get; set; }
        //public string? Title { get; set; }

        public int id { get; set; }
        public string? name { get; set; }
    }

    public class AOEmployeesRelationship
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
    }
    public class AOJobTitle
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
    }
    public class AOCompanyBOIDiscover
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
    }

}
