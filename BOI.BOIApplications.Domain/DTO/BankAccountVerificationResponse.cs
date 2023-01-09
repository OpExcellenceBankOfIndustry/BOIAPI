using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class BankAccountVerificationResponse
    {
        public bool success { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
       
    }
    public class BankDetails
    {
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bankName { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public object parentId { get; set; }
        public string status { get; set; }
        public object reason { get; set; }
        public bool dataValidation { get; set; }
        public bool selfieValidation { get; set; }
        public bool isConsent { get; set; }
        public string idNumber { get; set; }
        public string businessId { get; set; }
        public BankDetails bankDetails { get; set; }
        public string type { get; set; }
        public bool allValidationPassed { get; set; }
        public DateTime requestedAt { get; set; }
        public string requestedById { get; set; }
        public string country { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime lastModifiedAt { get; set; }
        
        public RequestedBy requestedBy { get; set; }
    }

    

    public class RequestedBy
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string id { get; set; }
    }

    


}
