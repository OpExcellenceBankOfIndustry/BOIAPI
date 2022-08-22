using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists
{
    public class AddCorporateWatchListsViewModel
    {
        public string? CompanyRegistrationNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
    }
}
