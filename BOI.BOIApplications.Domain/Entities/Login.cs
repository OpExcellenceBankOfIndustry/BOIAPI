using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities
{
    public class Login
    {
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Text)]
        [StringLength(50)]
        public string? Email { get; set; }
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50)]
        public string? Password { get; set; }

        [Display(Name = "EndDate")]
        [MaxLength(5000)]
        public string? ReturnUrl { get; set; }

        [Display(Name = "EndDate")]
        [MaxLength(20000)]
        public string? ErrorMessage { set; get; }
    }
}
