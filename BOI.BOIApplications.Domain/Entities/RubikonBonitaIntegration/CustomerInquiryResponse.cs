using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class CustomerInquiry
    {
        public string status { get; set; }
        public string customerCat { get; set; }
        public string customerName { get; set; }
        public string customerNumber { get; set; }
    }

    public class PersonalCustomerInquiryResponse
    {
        [JsonProperty(PropertyName = "return")]
        public List<PersonalCustomerInquiry> _return { get; set; }
    }

    public class CorporateCustomerInquiryResponse
    {
        [JsonProperty(PropertyName = "return")]
        public List<CorporateCustomerInquiry> _return { get; set; }
    }

    public class PersonalCustomerInquiry : CustomerInquiry
    {
        public string nationalIdenficationNumber { get; set; }
    }

    public class CorporateCustomerInquiry : CustomerInquiry
    {
        public string registrationNumber { get; set; }
    }
}
