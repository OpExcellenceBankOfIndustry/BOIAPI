using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.AccountOpeningModels
{
    public class AODetailsOfNextOfKin
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RefNumber { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? OtherNames { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress   { get; set; }
        public string? HomeAddress { get; set; }
        public string? State { get; set; }
        public string? LGA { get; set; }
        public string? TownCity { get; set; }
    }
}
