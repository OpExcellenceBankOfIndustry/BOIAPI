using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    //public class GetCustomerDetailsResponse
    //{
    //    [JsonProperty(PropertyName = "ns1:findCustomerKYCInfoResponse")]
    //    public Ns1Findcustomerkycinforesponse ns1findCustomerKYCInfoResponse { get; set; }
    //}

    public class GetCustomerDetailsResponse
    {
        [JsonProperty(PropertyName = "return")]
        public ReturnGetCustomerDetailsResponse _return { get; set; }
    }

    public class ReturnGetCustomerDetailsResponse
    {
        //[JsonProperty(PropertyName = "@xmlns:ns2")]
        //public string xmlnsns2 { get; set; }
        //public string offlineMode { get; set; }
        //public string offlineable { get; set; }
        //public string successFlag { get; set; }
        //public string workflowRequired { get; set; }
        public Accountdata[] accountData { get; set; }
        public Addressdata addressData { get; set; }
        public Contactdata[] contactData { get; set; }
        public Custominfo customInfo { get; set; }
        public string customerCat { get; set; }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string customerNumber { get; set; }
        public string customerTypeDesc { get; set; }
        public Identitydata identityData { get; set; }
        public Nonpersonalcustomerinfo[] nonPersonalCustomerInfo { get; set; }
    }

    public class Addressdata
    {
        public string addressLine1 { get; set; }
        public string city { get; set; }
        public string customerAddressId { get; set; }
        public string primaryAddressFg { get; set; }
        public string state { get; set; }
    }

    public class Custominfo
    {
        public string offlineMode { get; set; }
        public string offlineable { get; set; }
        public string successFlag { get; set; }
        public string workflowRequired { get; set; }
        public Customscreeninfoci[] customScreenInfoCI { get; set; }
    }

    public class Customscreeninfoci
    {
        public string screenTemplateId { get; set; }
        public string sectionName { get; set; }
        public object udsFieldData { get; set; }
    }

    public class Identitydata
    {
        public string bankConfirmationFlg { get; set; }
        public string businessUnitId { get; set; }
        public string excludeChannelAcctValidationFg { get; set; }
        public string excludePinValidationFg { get; set; }
        public string lockUserOperationRequiredFg { get; set; }
        public string offlineMode { get; set; }
        public string offlineable { get; set; }
        public string operationCode { get; set; }
        public string passwordInvalid { get; set; }
        public string userId { get; set; }
        public string userRoleId { get; set; }
        public string workflowRequired { get; set; }
        public string countryOfIssue { get; set; }
        public string identityDesc { get; set; }
        public string identityNumber { get; set; }
        public string identityType { get; set; }
        public string strIssueDate { get; set; }
        public string verifiedFlag { get; set; }
    }

    public class Accountdata
    {
        public string accountNo { get; set; }
        public string offlineMode { get; set; }
        public string offlineable { get; set; }
        public string successFlag { get; set; }
        public string workflowRequired { get; set; }
        public string acctName { get; set; }
        public string productDesc { get; set; }
    }

    public class Contactdata
    {
        public string contact { get; set; }
        public string contactModeDesc { get; set; }
        public string contactModeTypeCd { get; set; }
    }

    public class Nonpersonalcustomerinfo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string orgPersonContactId { get; set; }
        public string personalContactCustomerId { get; set; }
        public string positionDesc { get; set; }
    }



}
