using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists
{
    public class AddCorporateWatchListsCommand : IRequest<AddCorporateWatchListsCommandResponse>
    {
        public string? CompanyRegistrationNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Remarks { get; set; }
        public string? Country { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? CreatedBy { get; set; }
    }
}
