using System.ComponentModel.DataAnnotations.Schema;

namespace BOI.BOIApplications.Domain.Entities
{
    public class JWTCredential
    {
        public int JWTCredentialId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Channel { get; set; }
        [NotMapped]
        public string? Role { get; set; }
    }
}
