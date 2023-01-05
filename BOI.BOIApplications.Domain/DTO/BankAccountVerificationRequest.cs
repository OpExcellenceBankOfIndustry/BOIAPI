using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class BankAccountVerificationRequest
    {
        public string accountNumber { get; set; }
        public string bankCode { get; set; }
        public bool isSubjectConsent { get; set; }

    }
    public class BankAccountVerificationRequestView
    {
        public string accountNumber { get; set; }
        public string bankCode { get; set; }

    }

}
