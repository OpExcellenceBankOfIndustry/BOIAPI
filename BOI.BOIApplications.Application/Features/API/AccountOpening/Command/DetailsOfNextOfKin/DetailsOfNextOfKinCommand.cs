using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin
{
    public class DetailsOfNextOfKinCommand : IRequest<DetailsOfNextOfKinCommandResponse>
    {
        public List<DetailsOfNextOfKinViewModel> _request;

        public DetailsOfNextOfKinCommand(List<DetailsOfNextOfKinViewModel> request)
        {
            _request = request;
        }
        //public long UserId { get; set; }
        //public string? UserEmail { get; set; }
        //public string? RefNumber { get; set; }
        //public string? Title { get; set; }
        //public string? FirstName { get; set; }
        //public string? Surname { get; set; }
        //public string? OtherNames { get; set; }
        //public DateTimeOffset DateOfBirth { get; set; }
        //public string? PlaceOfBirth { get; set; }
        //public string? Gender { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? EmailAddress { get; set; }
        //public string? HomeAddress { get; set; }
        //public string? State { get; set; }
        //public string? LGA { get; set; }
        //public string? TownCity { get; set; }
    }
}
