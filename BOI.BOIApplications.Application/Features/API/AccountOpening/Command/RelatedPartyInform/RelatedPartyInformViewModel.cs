using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform
{
    public class RelatedPartyInformViewModel
    {
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RefNumber { get; set; }
        public string? HowDoYouKnowAboutBOI { get; set; }
        public string? AnyRelationshipWithAnyBOIEmployeeOrAnyOfItsDirectors { get; set; }
        public string? NameOfEmployeeDirector { get; set; }
        public string? Relationship { get; set; }

        public string code { get; set; }
        public string ModelMessage { get; set; }
    }
}
