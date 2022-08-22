namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState
{
    public class GetAllLGAsByStateQueryResponse
    {
        public string? StateName { get; set; }
        public List<GetAllLGAsByStateVM> AllLgas { get; set; }
    }
}
