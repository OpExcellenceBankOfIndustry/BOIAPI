using BOI.BOIApplications.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOI.BOIApplications.Persistence.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
