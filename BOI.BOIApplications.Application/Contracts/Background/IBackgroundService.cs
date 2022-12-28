using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.Background
{
    public interface IBackgroundService
    {
        public Task PostData();
    }
}
