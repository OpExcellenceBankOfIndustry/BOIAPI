using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DocumentTable
{
    public class DocumentTableResponse
    {
        public bool Status { get; set; }
        public string FileLocation { get; set; }

        public string FileMessage { get; set; }
    }
}
