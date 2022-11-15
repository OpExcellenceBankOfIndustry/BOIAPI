using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class ErrorCodeDescriptionTable
    {
        public int RecordId { get; set; }
        public string Error_Code { get; set; }
        public string Error_Desc { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string Release_Version { get; set; }
    }
}
