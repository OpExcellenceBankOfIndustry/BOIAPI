using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner
{
    public class AccountDetailsOfOwnerCommand : IRequest<AccountDetailsOfOwnerCommandResponse>
    {
        public List<AccountDetailsOfOwnerViewModel> _request;

        public AccountDetailsOfOwnerCommand(List<AccountDetailsOfOwnerViewModel> request)
        {
            _request = request;
        }


        //public long UserId { get; set; }
        //public string? UserEmail { get; set; }
        //public string? RefNumber { get; set; }
        //public string? BankName { get; set; }
        //public string? AccountNumber { get; set; }
        //public string? AccountName { get; set; }
    }
}
