using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN
{
    public class GetFEPsByBVNQueryViewModel
    {
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
