using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOI.BOIApplications.Persistence.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
