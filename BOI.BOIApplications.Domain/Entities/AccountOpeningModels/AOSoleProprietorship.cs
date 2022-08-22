using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.AccountOpeningModels
{
    public class AOSoleProprietorship
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RefNumber { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? OtherNames { get; set; }
        public string? MaidenName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? HomeAddress { get; set; }
        public string? ProofOfAddress { get; set; }
        public string? State { get; set; }
        public string? LGA { get; set; }
        public string? TownCity { get; set; }
        public string? HighestEducationalQualification { get; set; }
        public string? BVN { get; set; }
        public string? NIN { get; set; }
        public string? TIN { get; set; }
        public string? PercentageOwnership { get; set; }
        public string? Nationality { get; set; }
        public string? CERPAC { get; set; }
        public DateTimeOffset CERPACIssueDate { get; set; }
        public DateTimeOffset CERPACExpiryDate { get; set; }
        public string? IdentificationType { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? IdentificationFile { get; set; }
        public DateTimeOffset IdentificationIssueDate { get; set; }
        public DateTimeOffset IdentificationExpiryDate { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? Occupation { get; set; }
        public string? JobTitle { get; set; }
        public string? UploadCV { get; set; }
        public string? AnyPoliticalAffilationWithAPoliticalOfficeHolder { get; set; }
        public string? IndicatePoliticalOfficerRelationship { get; set; }
        public string? ContestedPoliticalOffice { get; set; }
        public string? IndicatePoliticalOffice { get; set; }
    }
}
