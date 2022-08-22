﻿using System;
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
        public T? Data { get; set; }
    }

    

    public class address
    {
        public string? town { get; set; }
        public string? lga { get; set; }
        public string? state { get; set; }
        public string? addressLine { get; set; }
    }
}
