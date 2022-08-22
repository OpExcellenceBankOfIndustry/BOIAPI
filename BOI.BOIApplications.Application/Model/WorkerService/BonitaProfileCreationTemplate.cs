using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Model.WorkerService
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BonitaProfileCreationTemplate
    {
        [JsonProperty("S/N")]
        public long? SN { get; set; }

        [JsonProperty("Staff ID")]
        public string? StaffId { get; set; }

        [JsonProperty("First Name")]
        public string? FirstName { get; set; }

        [JsonProperty("Middle Name Initial")]
        public string? MiddleNameInitial { get; set; }

        [JsonProperty("Last Name")]
        public string? LastName { get; set; }

        [JsonProperty("Username")]
        public string? Username { get; set; }

        [JsonProperty("Grade")]
        public string? Grade { get; set; }

        [JsonProperty("Department")]
        public string? Department { get; set; }

        [JsonProperty("Division")]
        public string? Division { get; set; }

        [JsonProperty("Unit")]
        public string? Unit { get; set; }

        [JsonProperty("Location")]
        public string? Location { get; set; }

        [JsonProperty("Account Number")]
        public string? AccountNumber { get; set; }

        [JsonProperty("Sort Code")]
        public string? SortCode { get; set; }

        [JsonProperty("Role")]
        public string? Role { get; set; }
    }
}
