using Microsoft.AspNetCore.Identity;

namespace BOI.BOIApplications.Domain.Entities
{
    public class UserDetail : IdentityUser<long>
    {
        public string? BusinessName { get; set; }
        public string? RCNumber { get; set; }
        public string? UserRole { get; set; }
        public string? BusinessType { get; set; }
        public string? BusinessLocation { get; set; }
        public DateTime RegisteredDate { get; set; }
        public byte[]? ProfileImage { get; set; }
        public bool DefaultPassword { get; set; }
        public Boolean Isdeleted { get; set; }

      

    }
}
