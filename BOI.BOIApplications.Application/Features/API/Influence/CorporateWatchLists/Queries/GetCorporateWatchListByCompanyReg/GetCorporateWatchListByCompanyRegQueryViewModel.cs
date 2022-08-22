namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg
{
    public class GetCorporateWatchListByCompanyRegQueryViewModel
    {
        public string? CompanyRegistrationNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Remarks { get; set; }
        public string? Country { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
