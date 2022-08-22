using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities
{
    public class LGA
    {
        //public int LGAId { get; set; }
        //public string? LGAName { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public int StateId { get; set; }
        public ICollection<City>? City { get; set; }
    }
}
