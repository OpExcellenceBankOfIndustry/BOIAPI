using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists
{
    public class AddCorporateWatchListsCommandResponse : BaseResponse
    {
        public AddCorporateWatchListsCommandResponse() : base() 
        {

        }

        public AddCorporateWatchListsViewModel AddCorporateWatchListsViewModel { get; set; }
    }
}
