using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities
{
    public class BankList
    {
        public long Id { get; set; }
        public int bankId { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string code { get; set; }
        public bool active { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
    }


    public class BankL
    {
      
        public string? id { get; set; }
        public string? name { get; set; }
    }
}
