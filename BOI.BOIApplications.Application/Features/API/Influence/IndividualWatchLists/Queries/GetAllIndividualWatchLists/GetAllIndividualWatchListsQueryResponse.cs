using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetAllIndividualWatchLists
{
    public class GetAllIndividualWatchListsQueryResponse : BaseResponse
    {
        public GetAllIndividualWatchListsQueryResponse() : base()
        {

        }

        public  List<GetAllIndividualWatchListsViewModel> GetAllIndividualWatchListsViewModel { get; set; }
    }
}
