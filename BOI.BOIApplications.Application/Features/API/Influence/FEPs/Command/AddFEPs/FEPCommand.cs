using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs
{
    public class FEPCommand : IRequest<FEPCommandResponse>
    {
		public string? FepBvn { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? OtherNames { get; set; }
		public string? FullName { get; set; }
		public string? FepPosition { get; set; }
		public string? FepOrganisation { get; set; }
		public string? CreatedBy { get; set; }

	}
}
