using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProCrm.Ldi.Api.Domain;

#nullable disable
namespace ProCrm.Ldi.Api.Models
{
    public partial class ProCRMContext:DbContext
    {
        public ProCRMContext()
        {
        }

        public ProCRMContext(DbContextOptions<ProCRMContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }

        public virtual DbSet<LdiDomain> LdiDomains { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ProCrm;Connect Timeout=30;User id=procrm;Password=procrm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<LdiDomain>(entity =>
            {
                entity.ToTable("LdiDomain");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(50);
                entity.Property(e => e.AttachedTo).HasMaxLength(50);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(100);
                entity.Property(e => e.JobTitle).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.Company).HasMaxLength(100);
                entity.Property(e => e.WebSite).HasMaxLength(3000);
                entity.Property(e => e.EmailAddress).HasMaxLength(100);
                entity.Property(e => e.MailAddress).HasMaxLength(100);
                entity.Property(e => e.Facebook).HasMaxLength(100);
                entity.Property(e => e.Instagram).HasMaxLength(100);
                entity.Property(e => e.Comments).HasMaxLength(100);

            });

          

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
