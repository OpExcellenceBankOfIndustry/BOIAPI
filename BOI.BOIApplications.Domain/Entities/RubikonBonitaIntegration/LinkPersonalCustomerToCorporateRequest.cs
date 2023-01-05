using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    public class LinkPersonalCustomerToCorporateRequest
    {
        public int channelId { get; set; }
        public string? serviceChannelCode { get; set; }
        public string? transmissionTime { get; set; }
        public int businessUnitId { get; set; }
        public string? corporateCustNo { get; set; }
        public string? personalCustNo { get; set; }
        public string? orgPositionCode { get; set; }
        public string? addressLine1 { get; set; }
        public string? addressLine2 { get; set; }
        public string? addressLine3 { get; set; }
        public string? addressLine4 { get; set; }
        public string? cityCode { get; set; }
        public string? stateCode { get; set; }
        public string? countryCode { get; set; }
        public int postalCode { get; set; }
        public int shareholdingOwnershipPercentage { get; set; }
        public string? businessPhoneNo { get; set; }
        public string? businessEmailAddr { get; set; }
        public int faxNo { get; set; }
        public int orgPositionId { get; set; }
    }
}
