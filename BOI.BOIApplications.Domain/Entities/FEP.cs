using BOI.BOIApplications.Domain.Common;

namespace BOI.BOIApplications.Domain.Entities
{
    public class FEP : AuditableEntity
	{
		public int FepId { get; set; }
		public string? FepBvn { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? OtherNames { get; set; }
		public string? FullName { get; set; }
		public string? FepPosition { get; set; }
		public string? FepOrganisation { get; set; }
	}
}
