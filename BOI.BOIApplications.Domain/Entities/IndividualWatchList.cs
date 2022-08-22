
using BOI.BOIApplications.Domain.Common;

namespace BOI.BOIApplications.Domain.Entities
{
    public class IndividualWatchList : AuditableEntity
	{
		public int IndividualWatchListId { get; set; }
		public string? IndividualBvn { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? OtherNames { get; set; }
		public string? IndividualName { get; set; }
		public string? Remarks { get; set; }
		public string? Country { get; set; }
		public string? AdditionalInformation { get; set; }
	}
}
