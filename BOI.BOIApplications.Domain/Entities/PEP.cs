using BOI.BOIApplications.Domain.Common;

namespace BOI.BOIApplications.Domain.Entities
{
    public class PEP : AuditableEntity
	{
		public int PepId { get; set; }
		public string? PepBvn { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? OtherNames { get; set; }
		public string? FullName { get; set; }
		public string? Location { get; set; }
		public string? CurrentPoliticalParty { get; set; }
		public string? CurrentPoliticalPosition { get; set; }
		public string? PastPoliticalParty { get; set; }
		public string? PastPoliticalPosition { get; set; }
	}
}
