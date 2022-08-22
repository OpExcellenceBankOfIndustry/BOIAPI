using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.ThirdPartyAPI
{
    public class CustomerDriversLicenseResponse : BaseResponse
    {
            [Key]
            public int NDLId { get; set; }
            public string? Id { get; set; }
            public string? idNumber { get; set; }
            public DateTimeOffset requestedDate { get; set; }
            public string? status { get; set; }
            public bool dataValidation { get; set; }
            public bool selfieValidation { get; set; }
            public string? firstName { get; set; }
            public string? middleName { get; set; }
            public string? lastName { get; set; }
            public DateTimeOffset issuedDate { get; set; }
            public DateTimeOffset expiredDate { get; set; }
            public string? stateOfIssuance { get; set; }
            public bool notifyWhenIdExpire { get; set; }
            public string? image { get; set; }
            public string? imageHeaderN { get; set; }
            public byte[]? NDLImage { get; set; }
        
            public string? mobile { get; set; }
            public string? email { get; set; }
            public DateTimeOffset dateOfBirth { get; set; }
            public bool isConsent { get; set; }
            public string? businessId { get; set; }
            public string? type { get; set; }
            public string? gender { get; set; }
            public DateTimeOffset requestedAt { get; set; }
            public string? country { get; set; }
            public DateTimeOffset createdAt { get; set; }
            public DateTimeOffset lastModifiedAt { get; set; }

    }
}
