using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetAllCorporateWatchLists
{
    public class GetAllCorporateWatchListsQueryResponse : BaseResponse
    {
        public GetAllCorporateWatchListsQueryResponse() : base()
        {

        }

        public List<GetAllCorporateWatchListsQueryViewModel> GetAllCorporateWatchListsQueryViewModel { get; set; }
    }
}
