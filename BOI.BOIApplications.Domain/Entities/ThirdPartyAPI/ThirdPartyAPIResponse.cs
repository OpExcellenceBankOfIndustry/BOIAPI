using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{


    public class ThirdPartyAPIResponseBase
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class ThirdPartyAPIResponse<T> : ThirdPartyAPIResponseBase
    {
        public T Data { get; set; }
    }    

    public class address
    {
        public string? town { get; set; }
        public string? lga { get; set; }
        public string? state { get; set; }
        public string? addressLine { get; set; }
    }

    public class BankListResponse
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string code { get; set; }
        public bool active { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
    }
}
