using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList
{
    public class AddIndividualWatchListCommandResponse : BaseResponse
    {
        public AddIndividualWatchListCommandResponse() : base()
        {

        }

        public AddIndividualWatchListViewModel AddIndividualWatchListViewModel { get; set; }
    }
}

