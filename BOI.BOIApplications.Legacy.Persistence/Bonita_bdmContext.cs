using System;
using System.Collections.Generic;
using BOI.BOIApplications.Legacy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOI.BOIApplications.Legacy.Persistence
{
    public partial class Bonita_bdmContext : DbContext
    {
        public Bonita_bdmContext()
        {
        }

        public Bonita_bdmContext(DbContextOptions<Bonita_bdmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boiemployee> Boiemployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boiemployee>(entity =>
            {
                entity.HasKey(e => e.Employeeid)
                    .HasName("boiemployee_pkey");

                entity.ToTable("boiemployee");

                entity.Property(e => e.Employeeid)
                    .HasMaxLength(10)
                    .HasColumnName("employeeid");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(50)
                    .HasColumnName("accountnumber");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasColumnName("department");

                entity.Property(e => e.Division)
                    .HasMaxLength(50)
                    .HasColumnName("division");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Grade)
                    .HasMaxLength(50)
                    .HasColumnName("grade");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Middleinitial)
                    .HasMaxLength(50)
                    .HasColumnName("middleinitial");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Sortcode)
                    .HasMaxLength(50)
                    .HasColumnName("sortcode");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
