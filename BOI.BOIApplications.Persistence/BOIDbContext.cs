using BOI.BOIApplications.Domain.Common;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BOI.BOIApplications.Persistence
{
    public class BOIDbContext : IdentityDbContext<UserDetail, UserRole, long>
    {
        public BOIDbContext(DbContextOptions<BOIDbContext> options)
            : base(options)
        {
        }
        //Account Opening Details
        public DbSet<AOCompanyInformation> AOCompanyInformations { get; set; }
        public DbSet<AOAccountDetailsOfOwner> AOAccountDetailsOfOwner { get; set; }
        public DbSet<AODetailsOfNextOfKin> AODetailsOfNextOfKins { get; set; }
        public DbSet<AODocumentTable> AODocumentTable { get; set; }
        public DbSet<AOOwnershipInformationCooperate> AOOwnershipInformationCooperate { get; set; }
        public DbSet<AOOwnershipInformationIndividual> AOOwnershipInformationIndividual { get; set; }
        public DbSet<AORegulatoryInformation> AORegulatoryInformation { get; set; }
        public DbSet<AORelatedPartyInformation> AORelatedPartyInformation { get; set; }
        public DbSet<AOSoleProprietorship> AOSoleProprietorship { get; set; }

       
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> LocalGovtArea { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailAttachment> EmailAttachments { get; set; }
        public DbSet<PEP> PEPs { get; set; }
        public DbSet<FEP> FEPs { get; set; }
        public DbSet<IndividualWatchList> IndividualWatchLists { get; set; }
        public DbSet<CorporateWatchList> CorporateWatchLists { get; set; }
        public DbSet<JWTCredential> JWTCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
           // modelBuilder.Ignore<AOAnnualTurnover>();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
