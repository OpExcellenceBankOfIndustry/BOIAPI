namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry
{
    public class GetStatesByCountryQueryResponse
    {
        public string? CountryName { get; set; }
        public List<GetStatesByCountryVM> AllStates { get; set; }
    }
}
