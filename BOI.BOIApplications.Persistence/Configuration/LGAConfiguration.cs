using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOI.BOIApplications.Persistence.Configuration
{
    public class LGAConfiguration : IEntityTypeConfiguration<LGA>
    {
        public void Configure(EntityTypeBuilder<LGA> builder)
        {
            builder.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}

