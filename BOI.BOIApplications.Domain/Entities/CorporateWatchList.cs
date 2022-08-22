using BOI.BOIApplications.Domain.Common;

namespace BOI.BOIApplications.Domain.Entities
{
    public class CorporateWatchList : AuditableEntity
	{
		public int CorporateWatchListId { get; set; }
		public string? CompanyRegistrationNumber { get; set; }
		public string? CompanyName { get; set; }
		public string? Remarks { get; set; }
		public string? Country { get; set; }
		public string? AdditionalInformation { get; set; }
	}
}
