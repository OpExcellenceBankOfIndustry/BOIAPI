using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class AccountOpening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AOAccountDetailsOfOwner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOAccountDetailsOfOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOCompanyInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyOwnsBusinessPremises = table.Column<bool>(type: "bit", nullable: false),
                    ProofOfCompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOCompanyInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AODetailsOfNextOfKins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AODetailsOfNextOfKins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AODocumentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadStatus = table.Column<int>(type: "int", nullable: false),
                    FileSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AODocumentTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOOwnershipInformationCooperate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfShareholdingCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOOwnershipInformationCooperate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOOwnershipInformationIndividual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofOfAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestEducationalQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERPAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERPACIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CERPACExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdentificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdentificationExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PassportPhotograph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyPoliticalAffilationWithAPoliticalOfficeHolder = table.Column<bool>(type: "bit", nullable: false),
                    StatePoliticalOfficerRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContestedPoliticalOffice = table.Column<bool>(type: "bit", nullable: false),
                    StatePoliticalOffice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOOwnershipInformationIndividual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AORegulatoryInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIncorporationRegistration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateBusinessStarted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCUMLNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateOfIncorporationRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormCO2AllotmentOfShares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormCO7ParticularsOfDirectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorisedShareCapital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidUpCapital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualTurnover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentNumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    ParentCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsidiariesAffiliates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfBusiness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousBusinessEngagedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationMembership = table.Column<bool>(type: "bit", nullable: false),
                    NameOfOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PresentThreatenedLitigationWithThirdParty = table.Column<bool>(type: "bit", nullable: false),
                    ThirdPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsYourCompanyQuotedOnAnyStockExchange = table.Column<bool>(type: "bit", nullable: false),
                    IndicateStockSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AORegulatoryInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AORelatedPartyInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowDoYouKnowAboutBOI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyRelationshipWithAnyBOIEmployeeOrAnyOfItsDirectors = table.Column<bool>(type: "bit", nullable: false),
                    NameOfEmployeeDirector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AORelatedPartyInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOSoleProprietorship",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofOfAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestEducationalQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERPAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CERPACIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CERPACExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdentificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdentificationExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PassportPhotograph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyPoliticalAffilationWithAPoliticalOfficeHolder = table.Column<bool>(type: "bit", nullable: false),
                    IndicatePoliticalOfficerRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContestedPoliticalOffice = table.Column<bool>(type: "bit", nullable: false),
                    IndicatePoliticalOffice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOSoleProprietorship", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AOAccountDetailsOfOwner");

            migrationBuilder.DropTable(
                name: "AOCompanyInformations");

            migrationBuilder.DropTable(
                name: "AODetailsOfNextOfKins");

            migrationBuilder.DropTable(
                name: "AODocumentTable");

            migrationBuilder.DropTable(
                name: "AOOwnershipInformationCooperate");

            migrationBuilder.DropTable(
                name: "AOOwnershipInformationIndividual");

            migrationBuilder.DropTable(
                name: "AORegulatoryInformation");

            migrationBuilder.DropTable(
                name: "AORelatedPartyInformation");

            migrationBuilder.DropTable(
                name: "AOSoleProprietorship");
        }
    }
}
