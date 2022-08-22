using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.AccountOpeningModels
{
    public class AORegulatoryInformation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RefNumber { get; set; }
        public string? CompanyRegistrationNumber { get; set; }
        public DateTimeOffset DateOfIncorporationRegistration { get; set; }
        public DateTimeOffset DateBusinessStarted { get; set; }
        public string? TIN { get; set; }
        public string? SCUMLNumber { get; set; }
        public string? CertificateOfIncorporationRegistration { get; set; }
        public string? FormCO2AllotmentOfShares { get; set; }
        public string? FormCO7ParticularsOfDirectors { get; set; }
        public string? Memart { get; set; }
        public string? BoardResolution { get; set; }
        public string? AuthorisedShareCapital { get; set; }
        public string? PaidUpCapital { get; set; }
        public string? AnnualTurnover  { get; set; }
        public int CurrentNumberOfEmployees { get; set; }
        public string? ParentCompany { get; set; }
        public string? SubsidiariesAffiliates { get; set; }
        public string? NatureOfBusiness { get; set; }
        public string? PreviousBusinessEngagedIn { get; set; }
        public string? OrganizationMembership { get; set; }
        public string? NameOfOrganization { get; set; }
        public string? MembershipNumber { get; set; }
        public DateTimeOffset JoinedDate { get; set; }
        public string? PresentThreatenedLitigationWithThirdParty { get; set; }
        public string? ThirdPartyName { get; set; }
        public string? SuitNumber { get; set; }
        public string? IsYourCompanyQuotedOnAnyStockExchange { get; set; }
        public string? IndicateStockSymbol { get; set; }
        public string? StockExchange { get; set; }
    }
}
