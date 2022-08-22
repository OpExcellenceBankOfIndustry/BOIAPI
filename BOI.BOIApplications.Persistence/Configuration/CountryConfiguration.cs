using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOI.BOIApplications.Persistence.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
