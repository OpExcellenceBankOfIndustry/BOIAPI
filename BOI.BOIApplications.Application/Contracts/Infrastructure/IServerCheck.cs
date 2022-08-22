using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.Infrastructure
{
    public interface IServerCheck
    {
        Task<bool> IsServerStillUp();
        Task<bool> IsWebsiteStillUp();

    }
}
