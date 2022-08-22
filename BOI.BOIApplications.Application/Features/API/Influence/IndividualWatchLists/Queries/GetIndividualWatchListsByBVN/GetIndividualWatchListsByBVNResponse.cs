using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN
{
    public class GetIndividualWatchListsByBVNResponse : BaseResponse
    {
        public GetIndividualWatchListsByBVNResponse() : base()  
        {

        }

        public GetIndividualWatchListsByBVNViewModel GetIndividualWatchListsByBVNViewModel { get; set; }
    }
}
