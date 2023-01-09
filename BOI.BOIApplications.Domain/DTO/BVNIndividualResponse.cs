using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.DTO
{
    public class BVNIndividualResponse
    {
        public string? Bvn { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public bool isAvailable { get; set; }
        public string? Message { get; set; }

    }
}
