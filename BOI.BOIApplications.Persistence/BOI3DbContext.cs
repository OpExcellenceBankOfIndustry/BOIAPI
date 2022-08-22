using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Persistence
{
    public class BOI3DbContext : DbContext
    {
        public BOI3DbContext(DbContextOptions<BOI3DbContext> options) : base(options)
        {

        }

        public DbSet<CustomerBVNResponse> CustomerBVNResponses { get; set; }
        public DbSet<CustomerNINResponse> CustomerNINResponses { get; set; }
        public DbSet<CustomerPVCResponse> CustomerPVCResponses { get; set; }
        public DbSet<CustomerDriversLicenseResponse> CustomerDriversLicenseResponses { get; set; }
        public DbSet<CustomerINTLPassportResponse> CustomerINTLPassportResponses { get; set; }

        public DbSet<BusinessCACResponse> BusinessCACResponses { get; set; }
        public DbSet<BusinessTINResponse> BusinessTINResponses { get; set; }
        public DbSet<keyPersonnel> keyPersonnelDetails { get; set; }


        ///Part of BOI2DbContext Tables -- AODropdownlist.cs file
        public DbSet<AOEmployeesRelationship> AOEmployeesRelationships { get; set; }
        public DbSet<AOJobTitle> AOJobTitles { get; set; }
        public DbSet<AOCompanyBOIDiscover> AOCompanyBOIDiscovers { get; set; }
    }
}
