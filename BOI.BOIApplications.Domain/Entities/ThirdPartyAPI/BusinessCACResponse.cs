using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class BusinessCACResponse : BaseResponse
    {
        public string? id { get; set; }
        public string? status { get; set; }
        public string? businessId { get; set; }
        public string? parentId { get; set; }
        public bool isConsent { get; set; }
        public string? type { get; set; }
        public string? searchTerm { get; set; }
        public string? name { get; set; }
        public string? registrationNumber { get; set; }
        public string? tin { get; set; }
        public DateTimeOffset requestedDate { get; set; }
        public string? jtbTin { get; set; }
        public string? taxOffice { get; set; }
        public string? email { get; set; }
        public string? companyStatus { get; set; }
        public string? phone { get; set; }
        public DateTimeOffset requestedAt { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset lastModifiedAt { get; set; }

        public string? typeOfEntity { get; set; }
        public string? activity { get; set; }
        public DateTimeOffset registrationDate { get; set; }

        public string? address { get; set; }
        public string? state { get; set; }
        public string? lga { get; set; }
        public string? city { get; set; }

        public string? websiteEmail { get; set; }

        public virtual List<keyPersonnel>? keyPersonnel { get; set; }

        public string? branchAddress { get; set; }
        public string? headOfficeAddress { get; set; }
        public string? objectives { get; set; }
    }
}
