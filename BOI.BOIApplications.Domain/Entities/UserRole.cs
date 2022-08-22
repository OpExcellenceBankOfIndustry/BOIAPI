using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities
{
    public class UserRole : IdentityRole<long>
    {
        public string? RoleName { get; set; }
        public Boolean Isdeleted { get; set; }
    }
}
