using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList
{
    public class AddIndividualWatchListCommand : IRequest<AddIndividualWatchListCommandResponse>
    {
		public string? IndividualBvn { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? OtherNames { get; set; }
		public string? IndividualName { get; set; }
		public string? Remarks { get; set; }
		public string? Country { get; set; }
		public string? AdditionalInformation { get; set; }
		public string? CreatedBy { get; set; }

	}
}
