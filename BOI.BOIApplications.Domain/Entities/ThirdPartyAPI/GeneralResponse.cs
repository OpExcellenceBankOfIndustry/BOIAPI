using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class GeneralResponse
    {
            public string? Id { get; set; }
            public string? idNumber { get; set; }
            public DateTimeOffset requestedDate { get; set; }
            public string? status { get; set; }
            public bool dataValidation { get; set; }
            public bool selfieValidation { get; set; }
            public string? firstName { get; set; }
            public string? middleName { get; set; }
            public string? lastName { get; set; }
            public string? image { get; set; }
           
            public string? mobile { get; set; }
            public DateTimeOffset dateOfBirth { get; set; }
            public bool isConsent { get; set; }
            public bool shouldRetrivedNin { get; set; }
            public string? businessId { get; set; }
            public string? type { get; set; }
            public string? gender { get; set; }
            public DateTimeOffset requestedAt { get; set; }
            public string? country { get; set; }
            public DateTimeOffset createdAt { get; set; }
            public DateTimeOffset lastModifiedAt { get; set; }
        //BVN
        public string? enrollmentBranch { get; set; }
        public string? enrollmentInstitution { get; set; }


        //NIN
        public string? email { get; set; }
        public string? birthState { get; set; }
        public string? nokState { get; set; }
        public string? religion { get; set; }
        public string? birthLGA { get; set; }
        public string? birthCountry { get; set; }
        public address? address { get; set; }
        public string? town { get; set; }
        public string? lga { get; set; }
        public string? state { get; set; }
        public string? addressLine { get; set; }

        //NDL
        public DateTimeOffset issuedDate { get; set; }
        public DateTimeOffset expiredDate { get; set; }
        public string? stateOfIssuance { get; set; }
        public bool notifyWhenIdExpire { get; set; }
    }
}
